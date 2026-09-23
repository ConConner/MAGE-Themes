using System;
using System.Collections.Generic;
using System.Drawing;

namespace mage.Utility;

public static class BlockFill
{
    /// <summary>
    /// Fills the tiles equal to the one at <paramref name="start"/> on <paramref name="layer"/>.
    /// With <paramref name="neighbouring"/> only the 4-connected area around <paramref name="start"/> is filled,
    /// otherwise every equal tile in the room is.
    /// Every filled block takes a random block from <paramref name="pool"/>.
    /// The result covers the bounding box of the filled area; blocks outside the area keep their current values,
    /// so it can be applied as a plain block edit.
    /// </summary>
    /// <param name="layer">Backgrounds index of the layer to match on (0-2 for BGs, 3 for clipdata).</param>
    public static bool TryFill(Backgrounds backgrounds, Point start, int layer, IReadOnlyList<Block> pool,
        bool neighbouring, Random rng, out Block[,] blocks, out Point origin)
    {
        blocks = null;
        origin = start;
        if (pool.Count == 0 || start.X < 0 || start.Y < 0 || start.X >= backgrounds.width || start.Y >= backgrounds.height)
        {
            return false;
        }

        ushort[,] layerBlocks = backgrounds[layer].blocks;
        ushort target = layerBlocks[start.X, start.Y];

        bool[,] filled = new bool[backgrounds.width, backgrounds.height];
        int minX = start.X, maxX = start.X, minY = start.Y, maxY = start.Y;

        if (neighbouring)
        {
            Stack<Point> open = new();
            open.Push(start);
            filled[start.X, start.Y] = true;

            while (open.Count > 0)
            {
                Point p = open.Pop();
                minX = Math.Min(minX, p.X); maxX = Math.Max(maxX, p.X);
                minY = Math.Min(minY, p.Y); maxY = Math.Max(maxY, p.Y);

                foreach (Point n in new[] { new Point(p.X - 1, p.Y), new Point(p.X + 1, p.Y), new Point(p.X, p.Y - 1), new Point(p.X, p.Y + 1) })
                {
                    if (n.X < 0 || n.Y < 0 || n.X >= backgrounds.width || n.Y >= backgrounds.height) { continue; }
                    if (filled[n.X, n.Y] || layerBlocks[n.X, n.Y] != target) { continue; }
                    filled[n.X, n.Y] = true;
                    open.Push(n);
                }
            }
        }
        else
        {
            minX = backgrounds.width; minY = backgrounds.height;
            maxX = maxY = 0;
            for (int y = 0; y < backgrounds.height; y++)
            {
                for (int x = 0; x < backgrounds.width; x++)
                {
                    if (layerBlocks[x, y] != target) { continue; }
                    filled[x, y] = true;
                    minX = Math.Min(minX, x); maxX = Math.Max(maxX, x);
                    minY = Math.Min(minY, y); maxY = Math.Max(maxY, y);
                }
            }
        }

        origin = new Point(minX, minY);
        blocks = new Block[maxX - minX + 1, maxY - minY + 1];
        for (int y = minY; y <= maxY; y++)
        {
            for (int x = minX; x <= maxX; x++)
            {
                blocks[x - minX, y - minY] = filled[x, y]
                    ? pool[rng.Next(pool.Count)]
                    : backgrounds.GetBlock(x, y);
            }
        }
        return true;
    }
}
