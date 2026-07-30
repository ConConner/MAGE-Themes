using System;
using System.Collections.Generic;
using System.Linq;

namespace mage.Utility
{
    /// <summary>
    /// Learns tile adjacency rules and frequency weights from sample tile grids,
    /// for use by <see cref="WfcSolver"/>.
    /// </summary>
    public class WfcModel
    {
        private readonly Dictionary<ushort, int> frequency = new();
        private readonly Dictionary<ushort, HashSet<ushort>> rightOf = new();
        private readonly Dictionary<ushort, HashSet<ushort>> leftOf = new();
        private readonly Dictionary<ushort, HashSet<ushort>> belowOf = new();
        private readonly Dictionary<ushort, HashSet<ushort>> aboveOf = new();
        private static readonly HashSet<ushort> Empty = new();

        public int SampleCount { get; private set; }
        public bool HasTiles => frequency.Count > 0;
        public IReadOnlyCollection<ushort> AllTiles => frequency.Keys;

        /// <summary>
        /// Learns adjacency/frequency data from a sample grid. If <paramref name="isMasked"/>
        /// is given, masked cells (and edges touching them) are excluded from training —
        /// used to skip a room's own target fill region when it is otherwise part of the corpus.
        /// </summary>
        public void Learn(ushort[,] grid, Func<int, int, bool> isMasked = null)
        {
            int width = grid.GetLength(0);
            int height = grid.GetLength(1);
            if (width == 0 || height == 0) { return; }

            SampleCount++;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (isMasked != null && isMasked(x, y)) { continue; }

                    ushort tile = grid[x, y];
                    frequency.TryGetValue(tile, out int n);
                    frequency[tile] = n + 1;

                    if (x + 1 < width && !(isMasked?.Invoke(x + 1, y) ?? false))
                    {
                        Link(tile, grid[x + 1, y], rightOf, leftOf);
                    }
                    if (y + 1 < height && !(isMasked?.Invoke(x, y + 1) ?? false))
                    {
                        Link(tile, grid[x, y + 1], belowOf, aboveOf);
                    }
                }
            }
        }

        private static void Link(ushort a, ushort b, Dictionary<ushort, HashSet<ushort>> forward, Dictionary<ushort, HashSet<ushort>> backward)
        {
            if (!forward.TryGetValue(a, out HashSet<ushort> f)) { forward[a] = f = new HashSet<ushort>(); }
            f.Add(b);

            if (!backward.TryGetValue(b, out HashSet<ushort> bwd)) { backward[b] = bwd = new HashSet<ushort>(); }
            bwd.Add(a);
        }

        public int Frequency(ushort tile) => frequency.TryGetValue(tile, out int n) ? n : 0;

        public HashSet<ushort> RightOf(ushort tile) => rightOf.TryGetValue(tile, out var s) ? s : Empty;
        public HashSet<ushort> LeftOf(ushort tile) => leftOf.TryGetValue(tile, out var s) ? s : Empty;
        public HashSet<ushort> BelowOf(ushort tile) => belowOf.TryGetValue(tile, out var s) ? s : Empty;
        public HashSet<ushort> AboveOf(ushort tile) => aboveOf.TryGetValue(tile, out var s) ? s : Empty;

        public ushort MostFrequentTile() => frequency.OrderByDescending(kvp => kvp.Value).First().Key;
    }

    /// <summary>
    /// Solves a single rectangular region against a <see cref="WfcModel"/> using
    /// standard wave-function-collapse constraint propagation.
    /// </summary>
    public class WfcSolver
    {
        private readonly WfcModel model;
        private readonly int width;
        private readonly int height;
        private readonly HashSet<ushort>[,] domains;
        private readonly Random rng;

        public WfcSolver(WfcModel model, int width, int height, int seed)
        {
            this.model = model;
            this.width = width;
            this.height = height;
            rng = new Random(seed);

            domains = new HashSet<ushort>[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    domains[x, y] = new HashSet<ushort>(model.AllTiles);
                }
            }
        }

        /// <summary>
        /// Restricts the domain of cell (x,y) to tiles compatible with a fixed, already-placed
        /// tile sitting just outside the solve area at offset (dx,dy) (one of the 4 cardinal directions).
        /// If applying the constraint would empty the domain, it is skipped rather than
        /// leaving the cell unsolvable.
        /// </summary>
        public void ConstrainFromNeighbor(int x, int y, int dx, int dy, ushort neighborTile)
        {
            HashSet<ushort> allowed = dx switch
            {
                -1 => model.RightOf(neighborTile),
                1 => model.LeftOf(neighborTile),
                _ => dy switch
                {
                    -1 => model.BelowOf(neighborTile),
                    1 => model.AboveOf(neighborTile),
                    _ => Empty,
                }
            };
            if (allowed.Count == 0) { return; }

            HashSet<ushort> intersected = new(domains[x, y]);
            intersected.IntersectWith(allowed);
            if (intersected.Count > 0) { domains[x, y] = intersected; }
        }

        private static readonly HashSet<ushort> Empty = new();

        /// <returns>true if fully collapsed without contradiction, false otherwise.</returns>
        public bool Solve()
        {
            // seed propagation from any cells already pinned to a single tile by border constraints
            Stack<(int x, int y)> stack = new();
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (domains[x, y].Count == 1) { stack.Push((x, y)); }
                }
            }
            if (!Propagate(stack)) { return false; }

            while (true)
            {
                (int cx, int cy, bool found) = PickLowestEntropyCell();
                if (!found) { return true; }

                ushort chosen = ChooseWeighted(domains[cx, cy]);
                domains[cx, cy] = new HashSet<ushort> { chosen };

                stack.Clear();
                stack.Push((cx, cy));
                if (!Propagate(stack)) { return false; }
            }
        }

        private bool Propagate(Stack<(int x, int y)> stack)
        {
            while (stack.Count > 0)
            {
                (int x, int y) = stack.Pop();
                HashSet<ushort> domain = domains[x, y];

                if (x - 1 >= 0 && !PropagateTo(x - 1, y, -1, 0, domain, stack)) { return false; }
                if (x + 1 < width && !PropagateTo(x + 1, y, 1, 0, domain, stack)) { return false; }
                if (y - 1 >= 0 && !PropagateTo(x, y - 1, 0, -1, domain, stack)) { return false; }
                if (y + 1 < height && !PropagateTo(x, y + 1, 0, 1, domain, stack)) { return false; }
            }
            return true;
        }

        // dx/dy = direction from the collapsed/updated cell to the neighbor at (nx,ny)
        private bool PropagateTo(int nx, int ny, int dx, int dy, HashSet<ushort> sourceDomain, Stack<(int x, int y)> stack)
        {
            HashSet<ushort> neighborDomain = domains[nx, ny];
            if (neighborDomain.Count <= 1) { return true; }

            HashSet<ushort> allowed = new();
            foreach (ushort t in sourceDomain)
            {
                HashSet<ushort> options = dx switch
                {
                    1 => model.RightOf(t),
                    -1 => model.LeftOf(t),
                    _ => dy switch
                    {
                        1 => model.BelowOf(t),
                        -1 => model.AboveOf(t),
                        _ => Empty,
                    }
                };
                allowed.UnionWith(options);
            }

            int before = neighborDomain.Count;
            neighborDomain.IntersectWith(allowed);
            if (neighborDomain.Count == 0) { return false; }
            if (neighborDomain.Count != before) { stack.Push((nx, ny)); }
            return true;
        }

        private (int, int, bool) PickLowestEntropyCell()
        {
            double bestEntropy = double.MaxValue;
            int bestX = -1, bestY = -1;
            bool any = false;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int count = domains[x, y].Count;
                    if (count <= 1) { continue; }

                    any = true;
                    double entropy = ShannonEntropy(domains[x, y]) + rng.NextDouble() * 1e-6;
                    if (entropy < bestEntropy)
                    {
                        bestEntropy = entropy;
                        bestX = x;
                        bestY = y;
                    }
                }
            }

            return (bestX, bestY, any);
        }

        private double ShannonEntropy(HashSet<ushort> domain)
        {
            double total = 0;
            foreach (ushort t in domain) { total += model.Frequency(t); }
            if (total <= 0) { return 0; }

            double entropy = 0;
            foreach (ushort t in domain)
            {
                double p = model.Frequency(t) / total;
                if (p > 0) { entropy -= p * Math.Log(p); }
            }
            return entropy;
        }

        private ushort ChooseWeighted(HashSet<ushort> domain)
        {
            int total = 0;
            foreach (ushort t in domain) { total += model.Frequency(t); }

            if (total <= 0)
            {
                int idx = rng.Next(domain.Count);
                return domain.Skip(idx).First();
            }

            int roll = rng.Next(total);
            int acc = 0;
            foreach (ushort t in domain)
            {
                acc += model.Frequency(t);
                if (roll < acc) { return t; }
            }

            return domain.First();
        }

        public ushort GetResult(int x, int y) => domains[x, y].First();
    }

    /// <summary>
    /// Orchestrates solving a region: retries with fresh random seeds on contradiction,
    /// and falls back to the corpus's most frequent tile if no attempt fully collapses.
    /// </summary>
    public static class WaveFunctionFiller
    {
        public const int DefaultMaxAttempts = 20;

        /// <param name="getNeighborTile">
        /// Given local region coords (x,y) and an offset (dx,dy) to one of the 4 cardinal
        /// neighbors, returns the already-placed tile value at that neighbor if it lies
        /// outside the region being filled, or null if it's inside the region (unconstrained)
        /// or out of bounds.
        /// </param>
        public static ushort[,] Fill(WfcModel model, int width, int height,
            Func<int, int, int, int, ushort?> getNeighborTile, int maxAttempts = DefaultMaxAttempts)
        {
            Random seedSource = new();

            for (int attempt = 0; attempt < maxAttempts; attempt++)
            {
                WfcSolver solver = new(model, width, height, seedSource.Next());
                ApplyBorderConstraints(solver, width, height, getNeighborTile);

                if (solver.Solve())
                {
                    ushort[,] result = new ushort[width, height];
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            result[x, y] = solver.GetResult(x, y);
                        }
                    }
                    return result;
                }
            }

            // last resort: guarantee termination with a uniform fallback fill
            ushort fallbackTile = model.MostFrequentTile();
            ushort[,] fallback = new ushort[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    fallback[x, y] = fallbackTile;
                }
            }
            return fallback;
        }

        private static void ApplyBorderConstraints(WfcSolver solver, int width, int height,
            Func<int, int, int, int, ushort?> getNeighborTile)
        {
            (int, int)[] directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    foreach ((int dx, int dy) in directions)
                    {
                        ushort? neighbor = getNeighborTile(x, y, dx, dy);
                        if (neighbor.HasValue) { solver.ConstrainFromNeighbor(x, y, dx, dy, neighbor.Value); }
                    }
                }
            }
        }
    }
}
