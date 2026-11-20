using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mage
{
    /// <summary>
    /// Removes indexed assets from the ROM and leaves one blank asset of every cleared type behind.
    /// When rooms are cleared, every area keeps a single blank room. The data of the removed assets is marked as free space,
    /// unless something that is not cleared still points to it.
    /// </summary>
    public static class RomClearer
    {
        /// <summary>
        /// The types of assets that can be cleared
        /// </summary>
        [Flags]
        public enum Asset
        {
            None = 0,
            Rooms = 1 << 0,
            RoomSprites = 1 << 1,
            Doors = 1 << 2,
            Scrolls = 1 << 3,
            AreaConnections = 1 << 4,
            DoorEvents = 1 << 5,
            LocationNames = 1 << 6,
            HatchLockEvents = 1 << 7,
            Tilesets = 1 << 8,
            AnimatedTilesets = 1 << 9,
            AnimatedGraphics = 1 << 10,
            AnimatedPalettes = 1 << 11,
            Spritesets = 1 << 12,
            Minimaps = 1 << 13,
            Demos = 1 << 14,
            All = (1 << 15) - 1,
        }

        /// <summary>
        /// Returns the assets that have to be cleared as well, because they refer to cleared assets.
        /// References that can simply be reset to the blank asset (e.g. the tileset of a room) are reset instead.
        /// </summary>
        public static Asset WithDependencies(Asset assets)
        {
            Asset result = assets;
            Asset previous;
            do
            {
                previous = result;
                // doors, scrolls, hatch lock events and location names refer to rooms
                if (result.HasFlag(Asset.Rooms)) result |= Asset.RoomSprites | Asset.Doors | Asset.Scrolls | Asset.HatchLockEvents | Asset.LocationNames;
                // area connections and door events refer to doors
                if (result.HasFlag(Asset.Doors)) result |= Asset.AreaConnections | Asset.DoorEvents;
                // animated tilesets consist only of animated graphics numbers
                if (result.HasFlag(Asset.AnimatedGraphics)) result |= Asset.AnimatedTilesets;
            } while (result != previous);
            return result;
        }
        /// <summary>
        /// The result of <see cref="Clear"/>
        /// </summary>
        public class Result
        {
            /// <summary>Number of bytes the removed assets occupied</summary>
            public int CandidateBytes { get; internal set; }
            /// <summary>Number of bytes that were marked as free space</summary>
            public int FreedBytes { get; internal set; }
            /// <summary>Data that was kept because something else still points to it</summary>
            public List<string> KeptData { get; } = new();
            /// <summary>Data whose size could not be determined and was therefore not freed</summary>
            public List<string> SkippedData { get; } = new();
            /// <summary>Every range that was marked as free space</summary>
            public List<(int Start, int End, string Label)> FreedRanges { get; } = new();
        }

        private class Block
        {
            public int Start;
            public int End;
            public string Label;
        }

        // free space below this offset is never reused by MAGE
        private const int MinFreeOffset = 0xA0000;
        // a blank room is one screen
        private const byte BlankRoomWidth = 15 + 4;
        private const byte BlankRoomHeight = 10 + 4;

        public static bool IsSupported => Version.GameCode == "BMXE" || Version.GameCode == "AMTE";

        // captured state
        private static ByteStream rom;
        private static Result result;
        private static List<Block> candidates;
        private static List<Block> ignoredReferrers;
        private static List<Block> protectedData;
        private static HashSet<int> entryPoints;
        private static int numAreas;
        private static int[] areaRoomLists;
        private static int[] areaScrollLists;
        private static int mfHatchLockLength;
        private static int[] areaScrollTerminators;
        private static int[] hatchLockCounts;
        private static List<int> demoNumbers;
        private static Asset clearing;

        private static bool Clears(Asset asset) => (clearing & asset) != 0;

        /// <summary>
        /// Clears the selected assets (and their dependencies, see <see cref="WithDependencies"/>) of the ROM that is currently loaded.
        /// Edited data that has not been written to the ROM is lost.
        /// Throws when something fails. The ROM and the counts are restored in that case.
        /// </summary>
        public static Result Clear(Asset assets = Asset.All)
        {
            if (!IsSupported) throw new NotSupportedException("Clearing is only supported for Zero Mission (U) and Fusion (U).");

            byte[] backup = ROM.BackupData();
            byte[] roomsPerArea = (byte[])Version.RoomsPerArea.Clone();
            byte numTilesets = Version.NumOfTilesets;
            byte numAnimTilesets = Version.NumOfAnimTilesets;
            byte numAnimGfx = Version.NumOfAnimGfx;
            byte numAnimPalettes = Version.NumOfAnimPalettes;
            byte numSpritesets = Version.NumOfSpritesets;
            Version.ProjectState project = Version.project;

            try
            {
                rom = ROM.Stream;
                result = new Result();
                candidates = new();
                ignoredReferrers = new();
                protectedData = new();
                entryPoints = new();
                numAreas = Version.AreaNames.Length;
                clearing = WithDependencies(assets);
                if (clearing == Asset.None) return result;

                // the code changes are needed to read the door event and location name tables (MAGE applies them when opening the connection editor)
                if (Clears(Asset.DoorEvents) && !Version.DoorEventCode.IsApplied()) Version.DoorEventCode.Apply();
                if (Clears(Asset.LocationNames) && !Version.LocationNameCode.IsApplied()) Version.LocationNameCode.Apply();

                // find all data
                GetDemoNumbers();
                if (Clears(Asset.Rooms | Asset.RoomSprites)) CollectRooms();
                if (Clears(Asset.Doors)) CollectDoors();
                if (Clears(Asset.Scrolls)) CollectScrolls();
                if (Clears(Asset.Tilesets)) CollectTilesets();
                CollectAnimations();
                if (Clears(Asset.Spritesets)) CollectSpritesets();
                CollectConnections();
                if (Clears(Asset.HatchLockEvents)) CollectHatchLocks();
                if (Clears(Asset.Minimaps)) CollectMinimaps();
                if (Clears(Asset.Demos)) CollectDemos();

                // free everything that isn't referenced from somewhere else
                List<Block> toFree = ResolveReferences();
                FreeBlocks(toFree);

                // write blank assets and reset references to removed assets
                if (Clears(Asset.Tilesets)) WriteTilesets();
                else FixTilesets();
                WriteAnimations();
                if (Clears(Asset.Spritesets)) WriteSpritesets();
                if (Clears(Asset.Rooms)) WriteRooms();
                else FixRooms();
                if (Clears(Asset.Doors)) WriteDoors();
                if (Clears(Asset.Scrolls)) WriteScrolls();
                WriteConnections();
                if (Clears(Asset.HatchLockEvents)) WriteHatchLocks();
                if (Clears(Asset.Minimaps)) WriteMinimaps();
                if (Clears(Asset.Demos)) WriteDemos();
                else if (Clears(Asset.Doors)) FixDemos();

                Version.UpdateProject();
                return result;
            }
            catch
            {
                ROM.RestoreData(backup);
                Array.Copy(roomsPerArea, Version.RoomsPerArea, roomsPerArea.Length);
                Version.NumOfTilesets = numTilesets;
                Version.NumOfAnimTilesets = numAnimTilesets;
                Version.NumOfAnimGfx = numAnimGfx;
                Version.NumOfAnimPalettes = numAnimPalettes;
                Version.NumOfSpritesets = numSpritesets;
                Version.project = project;
                throw;
            }
            finally
            {
                rom = null;
                candidates = null;
                ignoredReferrers = null;
                protectedData = null;
                entryPoints = null;
            }
        }

        #region collecting

        /// <summary>
        /// Adds data that gets freed if nothing else points to it.
        /// Only pointers to the start, to a multiple of <paramref name="step"/> or to one of the <paramref name="entryOffsets"/>
        /// count as references, every other word that looks like a pointer is most likely part of graphics or sound data.
        /// </summary>
        private static void AddCandidate(int start, int length, string label, int step = 0, params int[] entryOffsets)
        {
            if (length <= 0) return;
            if (start < 0 || start + length > rom.Length)
            {
                result.SkippedData.Add($"{label}: invalid pointer {Hex.ToString(start)}");
                return;
            }
            candidates.Add(new Block { Start = start, End = start + length, Label = label });

            entryPoints.Add(start);
            if (step > 0) for (int o = start + step; o < start + length; o += step) entryPoints.Add(o);
            foreach (int o in entryOffsets) entryPoints.Add(start + o);
        }

        /// <summary>
        /// Marks data whose pointers will be overwritten. Pointers inside it don't keep other data alive.
        /// </summary>
        private static void AddIgnoredReferrer(int start, int length)
        {
            if (length <= 0) return;
            ignoredReferrers.Add(new Block { Start = start, End = start + length });
        }

        /// <summary>
        /// Marks data that gets rewritten in place and must never be freed.
        /// </summary>
        private static void AddProtected(int start, int length)
        {
            if (length <= 0) return;
            protectedData.Add(new Block { Start = start, End = start + length });
        }

        /// <summary>
        /// A table that is rewritten in place: its first <paramref name="keepLength"/> bytes are kept, the rest is freed
        /// </summary>
        private static void AddTable(int start, int oldLength, int keepLength, string label, int entrySize = 0)
        {
            if (entrySize == 0) entrySize = keepLength;
            AddIgnoredReferrer(start, oldLength);
            AddProtected(start, keepLength);
            AddCandidate(start + keepLength, oldLength - keepLength, label, entrySize);
        }

        private static void TryAddCandidate(int start, Func<int, int> getLength, string label, int step = 0, params int[] entryOffsets)
        {
            int length;
            try { length = getLength(start); }
            catch { length = -1; }

            if (length <= 0)
            {
                result.SkippedData.Add($"{label} at {Hex.ToString(start)}: size could not be determined");
                return;
            }
            AddCandidate(start, length, label, step, entryOffsets);
        }

        private static int LZ77Length(int offset)
        {
            if (offset < 0 || offset + 4 > rom.Length) return -1;
            if (rom.Read8(offset) != 0x10) return -1;
            int size = rom.Read8(offset + 1) | (rom.Read8(offset + 2) << 8) | (rom.Read8(offset + 3) << 16);
            if (size == 0 || size > 0x40000) return -1;

            rom.Seek(offset);
            int len = Compress.DecompLZ77(rom, new ByteStream());
            if (offset + len > rom.Length) return -1;
            return len;
        }

        /// <summary>LZ77 background with a 4 byte header</summary>
        private static int LZ77BgLength(int offset)
        {
            int len = LZ77Length(offset + 4);
            if (len <= 0) return -1;
            return len + 4;
        }

        /// <summary>RLE background with a 2 byte header (width, height)</summary>
        private static int RLEBgLength(int offset)
        {
            if (offset < 0 || offset + 3 > rom.Length) return -1;
            byte width = rom.Read8(offset);
            byte height = rom.Read8(offset + 1);
            if (width == 0 || height == 0) return -1;
            byte numBytes = rom.Read8(offset + 2);
            if (numBytes != 1 && numBytes != 2) return -1;

            rom.Seek(offset + 2);
            int len = Compress.DecompRLE(rom, new ByteStream());
            if (offset + 2 + len > rom.Length) return -1;
            return len + 2;
        }

        private static int EnemyListLength(int offset)
        {
            for (int i = 0; i < 0x100; i++)
            {
                int o = offset + i * 3;
                if (o + 3 > rom.Length) return -1;
                if (rom.Read8(o) == 0xFF && rom.Read8(o + 1) == 0xFF && rom.Read8(o + 2) == 0xFF) return (i + 1) * 3;
            }
            return -1;
        }

        private static int SpritesetLength(int offset)
        {
            for (int i = 0; i < 0x40; i++)
            {
                int o = offset + i * 2;
                if (o + 2 > rom.Length) return -1;
                if (rom.Read16(o) == 0) return (i + 1) * 2;
            }
            return -1;
        }

        private static int TileTableLength(int offset)
        {
            byte rows = rom.Read8(offset + 1);
            if (rows == 0)
            {
                rows = 0x40;
                foreach (string line in Version.TileTableLengths.Split('\n'))
                {
                    string[] items = line.Trim().Split('=');
                    if (items.Length != 2) continue;
                    if (offset == Convert.ToInt32(items[0], 16))
                    {
                        rows = Convert.ToByte(items[1], 16);
                        break;
                    }
                }
            }
            return rows * 0x80 + 2;
        }

        private static void CollectRooms()
        {
            areaRoomLists = new int[numAreas];
            for (int a = 0; a < numAreas; a++)
            {
                int list = rom.ReadPtr(Version.AreaHeaderOffset + a * 4);
                int numRooms = Version.RoomsPerArea[a];
                areaRoomLists[a] = list;
                string area = Version.AreaNames[a];

                // the first room entry is rewritten, all others are removed
                bool rooms = Clears(Asset.Rooms);
                if (rooms) AddTable(list, numRooms * 0x3C, 0x3C, $"{area} room entries");

                for (int r = 0; r < numRooms; r++)
                {
                    Header h = new Header(rom, (byte)a, (byte)r);
                    string room = $"{area} room {Hex.ToString(r)}";

                    if (!rooms)
                    {
                        // only the room sprite pointers are replaced
                        int entry = list + r * 0x3C;
                        AddIgnoredReferrer(entry + 0x20, 4);
                        AddIgnoredReferrer(entry + 0x28, 4);
                        AddIgnoredReferrer(entry + 0x30, 4);
                        CollectRoomSprites(h, room);
                        continue;
                    }

                    // same priority as in BG
                    if ((h.BG0prop & 0x40) != 0) TryAddCandidate(h.BG0ptr, LZ77BgLength, room + " BG0", 0, 4);
                    else if ((h.BG0prop & 0x10) != 0) TryAddCandidate(h.BG0ptr, RLEBgLength, room + " BG0", 0, 2);
                    if ((h.BG1prop & 0x10) != 0) TryAddCandidate(h.BG1ptr, RLEBgLength, room + " BG1", 0, 2);
                    if ((h.BG2prop & 0x10) != 0) TryAddCandidate(h.BG2ptr, RLEBgLength, room + " BG2", 0, 2);
                    TryAddCandidate(h.clipPtr, RLEBgLength, room + " clipdata", 0, 2);
                    TryAddCandidate(h.BG3ptr, LZ77BgLength, room + " BG3", 0, 4);
                    CollectRoomSprites(h, room);
                }
            }
        }

        private static void CollectRoomSprites(Header h, string room)
        {
            TryAddCandidate(h.enemyList0ptr, EnemyListLength, room + " sprites 0");
            if (h.spriteset1event > 0) TryAddCandidate(h.enemyList1ptr, EnemyListLength, room + " sprites 1");
            if (h.spriteset2event > 0) TryAddCandidate(h.enemyList2ptr, EnemyListLength, room + " sprites 2");
        }

        private static void CollectDoors()
        {
            // the door lists are replaced by new ones
            AddIgnoredReferrer(Version.DoorsOffset, numAreas * 4);

            for (int a = 0; a < numAreas; a++)
            {
                int list = rom.ReadPtr(Version.DoorsOffset + a * 4);
                int count = 0;
                while (count < 0x100 && rom.Read8(list + count * 12) != 0) count++;

                // the terminating entry only needs its first byte
                AddCandidate(list, count * 12 + 1, $"{Version.AreaNames[a]} doors", 12);
            }
        }

        private static void CollectScrolls()
        {
            areaScrollLists = new int[numAreas];
            areaScrollTerminators = new int[numAreas];

            for (int a = 0; a < numAreas; a++)
            {
                int list = rom.ReadPtr(Version.ScrollsOffset + a * 4);
                areaScrollLists[a] = list;
                int count = 0;

                while (true)
                {
                    if (count >= 0x100) throw new InvalidOperationException($"Scroll list of {Version.AreaNames[a]} has no end.");
                    int entry = rom.ReadPtr(list + count * 4);
                    if (rom.Read8(entry) == 0xFF)
                    {
                        // the entry list is terminated by a pointer to an entry starting with FF. It's shared, so it's kept
                        areaScrollTerminators[a] = entry;
                        break;
                    }
                    int length = rom.Read8(entry + 1) * 8 + 2;
                    AddCandidate(entry, length, $"{Version.AreaNames[a]} scroll {Hex.ToString(rom.Read8(entry))}");
                    count++;
                }

                AddTable(list, (count + 1) * 4, 4, $"{Version.AreaNames[a]} scroll list");
            }
        }

        private static void CollectTilesets()
        {
            int table = Version.TilesetOffset;
            int count = Version.NumOfTilesets;
            AddTable(table, count * 0x14, 0x14, "Tileset entries");

            for (int t = 0; t < count; t++)
            {
                int entry = table + t * 0x14;
                string label = $"Tileset {Hex.ToString(t)}";
                TryAddCandidate(rom.ReadPtr(entry), LZ77Length, label + " gfx");
                AddCandidate(rom.ReadPtr(entry + 4), 14 * 0x20, label + " palette", 0x20);
                TryAddCandidate(rom.ReadPtr(entry + 8), LZ77Length, label + " BG3 gfx");
                TryAddCandidate(rom.ReadPtr(entry + 0xC), TileTableLength, label + " tile table", 0, 2);
            }
        }

        private static void CollectAnimations()
        {
            // animated tilesets only contain IDs
            if (Clears(Asset.AnimatedTilesets))
            {
                AddTable(Version.AnimTilesetOffset, Version.NumOfAnimTilesets * 0x30, 0x30, "Animated tileset entries");
            }

            if (Clears(Asset.AnimatedGraphics))
            {
                int table = Version.AnimGfxOffset;
                int count = Version.NumOfAnimGfx;
                AddTable(table, count * 8, 8, "Animated graphics entries");
                for (int i = 0; i < count; i++)
                {
                    byte states = rom.Read8(table + i * 8 + 2);
                    AddCandidate(rom.ReadPtr(table + i * 8 + 4), Math.Max(1, (int)states) * 0x80, $"Animated graphics {Hex.ToString(i)}", 0x20);
                }
            }

            if (Clears(Asset.AnimatedPalettes))
            {
                int table = Version.AnimPaletteOffset;
                int count = Version.NumOfAnimPalettes;
                AddTable(table, count * 8, 8, "Animated palette entries");
                for (int i = 0; i < count; i++)
                {
                    byte states = rom.Read8(table + i * 8 + 2);
                    AddCandidate(rom.ReadPtr(table + i * 8 + 4), Math.Max(1, (int)states) * 0x20, $"Animated palette {Hex.ToString(i)}", 0x20);
                }
            }
        }

        private static void CollectSpritesets()
        {
            int table = Version.SpritesetOffset;
            int count = Version.NumOfSpritesets;
            AddTable(table, count * 4, 4, "Spriteset list");

            for (int i = 0; i < count; i++)
            {
                TryAddCandidate(rom.ReadPtr(table + i * 4), SpritesetLength, $"Spriteset {Hex.ToString(i)}");
            }
        }

        /// <summary>
        /// Number of entries in a list that ends with an entry starting with FF
        /// </summary>
        private static int TerminatedListCount(int offset, int entrySize, string label)
        {
            for (int i = 0; i < 0x100; i++)
            {
                if (rom.Read8(offset + i * entrySize) == 0xFF) return i;
            }
            throw new InvalidOperationException($"{label} have no end.");
        }

        private static void CollectTerminatedList(int offset, string label)
        {
            // 3 bytes each. Only the first byte of the terminator is counted, the entry might be cut off
            int count = TerminatedListCount(offset, 3, label);
            if (count > 0) AddTable(offset, count * 3 + 1, 3, label);
        }

        private static void CollectConnections()
        {
            if (Clears(Asset.AreaConnections)) CollectTerminatedList(Version.AreaConnectionsOffset, "Area connections");
            if (Clears(Asset.LocationNames)) CollectTerminatedList(Version.LocationNamesOffset, "Location names");

            // door events (counted, 4 bytes each). The first entry is replaced with one that never matches,
            // because the game's loop always checks the first entry
            if (!Clears(Asset.DoorEvents)) return;
            int count = Version.NumOfDoorEvents;
            if (count > 0) AddTable(Version.DoorEventsOffset, count * 4, 4, "Door events");
        }

        private static void CollectHatchLocks()
        {
            if (Version.IsMF)
            {
                // one list for all areas, 4 bytes each, terminated by F0 F0
                int offset = Version.HatchLockEventsOffset;
                mfHatchLockLength = Version.NumOfHatchLockEvents * 4 + 2;
                if (mfHatchLockLength >= 6) AddTable(offset, mfHatchLockLength, 6, "Hatch lock events", 4);
                return;
            }

            // one list per area, 8 bytes each, with a count per area
            hatchLockCounts = new int[numAreas];
            AddIgnoredReferrer(Version.HatchLockEventsOffset, numAreas * 4);
            for (int a = 0; a < numAreas; a++)
            {
                int count = rom.Read16(Version.NumOfHatchLockEventsOffset + a * 2);
                hatchLockCounts[a] = count;
                int list = rom.ReadPtr(Version.HatchLockEventsOffset + a * 4);
                if (count == 0) continue;

                // the first entry is rewritten in place
                AddProtected(list, 8);
                AddCandidate(list + 8, (count - 1) * 8, $"{Version.AreaNames[a]} hatch lock events", 8);
            }
        }

        private static void CollectMinimaps()
        {
            int table = Version.MinimapDataOffset;
            int count = Version.NumOfMinimaps;
            AddIgnoredReferrer(table, count * 4);

            for (int i = 0; i < count; i++)
            {
                TryAddCandidate(rom.ReadPtr(table + i * 4), LZ77Length, $"Minimap {Hex.ToString(i)}");
            }
        }

        private static void GetDemoNumbers()
        {
            demoNumbers = new List<int>();
            for (int i = 0; i < Version.NumOfDemos; i++)
            {
                int num = Version.IsMF ? i : rom.Read8(0x363CE8 + i);
                if (!demoNumbers.Contains(num)) demoNumbers.Add(num);
            }
        }

        private static void CollectDemos()
        {
            foreach (int num in demoNumbers)
            {
                int entry = Version.DemoInputOffset + num * 0x10;
                AddIgnoredReferrer(entry, 0x10);
                AddCandidate(rom.ReadPtr(entry), rom.Read16(entry + 4), $"Demo {Hex.ToString(num)} inputs");
                AddCandidate(rom.ReadPtr(entry + 8), rom.Read16(entry + 0xC), $"Demo {Hex.ToString(num)} durations");
            }
        }

        #endregion

        #region freeing

        private static List<Block> SortAndMerge(IEnumerable<Block> blocks, bool mergeAdjacent)
        {
            List<Block> sorted = blocks.OrderBy(b => b.Start).ThenByDescending(b => b.End).ToList();
            List<Block> merged = new();
            foreach (Block b in sorted)
            {
                Block last = merged.Count > 0 ? merged[^1] : null;
                if (last != null && (b.Start < last.End || (mergeAdjacent && b.Start == last.End)))
                {
                    last.End = Math.Max(last.End, b.End);
                    continue;
                }
                merged.Add(new Block { Start = b.Start, End = b.End, Label = b.Label });
            }
            return merged;
        }

        /// <summary>
        /// Index of the block containing <paramref name="offset"/> in a sorted, non overlapping list, or -1
        /// </summary>
        private static int FindBlock(List<Block> blocks, int offset)
        {
            int lo = 0, hi = blocks.Count - 1;
            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;
                Block b = blocks[mid];
                if (offset < b.Start) hi = mid - 1;
                else if (offset >= b.End) lo = mid + 1;
                else return mid;
            }
            return -1;
        }

        /// <summary>
        /// Removes all data that is still referenced by a pointer that isn't overwritten or freed.
        /// Only pointers to entry points of the data count (see <see cref="AddCandidate"/>).
        /// Data that is referenced at its start is kept completely, data referenced in the middle is kept from that point on.
        /// </summary>
        private static List<Block> ResolveReferences()
        {
            // remove protected data from the candidates
            List<Block> blocks = SortAndMerge(candidates, false);
            List<Block> protect = SortAndMerge(protectedData, true);
            foreach (Block p in protect)
            {
                List<Block> split = new();
                foreach (Block b in blocks)
                {
                    if (b.End <= p.Start || b.Start >= p.End) { split.Add(b); continue; }
                    if (b.Start < p.Start) split.Add(new Block { Start = b.Start, End = p.Start, Label = b.Label });
                    if (b.End > p.End) split.Add(new Block { Start = p.End, End = b.End, Label = b.Label });
                }
                blocks = split;
            }

            result.CandidateBytes = blocks.Sum(b => b.End - b.Start);
            List<Block> ignored = SortAndMerge(ignoredReferrers, true);

            // find every word that looks like a pointer into one of the blocks
            byte[] data = rom.Data;
            int romLength = rom.Length;
            List<(int Location, int Target)> pointers = new();
            for (int i = 0; i + 4 <= romLength; i += 4)
            {
                byte top = data[i + 3];
                if (top != 0x08 && top != 0x09) continue;
                int target = data[i] | (data[i + 1] << 8) | (data[i + 2] << 16) | ((top - 8) << 24);
                if (!entryPoints.Contains(target)) continue;
                if (FindBlock(blocks, target) == -1) continue;
                if (FindBlock(ignored, i) != -1) continue;
                pointers.Add((i, target));
            }

            // pointers inside blocks that are freed don't count. Repeat until nothing changes, because
            // blocks that are kept can contain pointers to other blocks
            bool changed = true;
            while (changed)
            {
                changed = false;
                foreach (var (location, target) in pointers)
                {
                    if (FindBlock(blocks, location) != -1) continue;
                    int index = FindBlock(blocks, target);
                    if (index == -1) continue;

                    Block b = blocks[index];
                    result.KeptData.Add($"{b.Label}: {Hex.ToString(target)}-{Hex.ToString(b.End - 1)} (pointer at {Hex.ToString(location)})");
                    if (target == b.Start) blocks.RemoveAt(index);
                    else b.End = target;
                    changed = true;
                }
            }

            return blocks;
        }

        private static bool IsFreeSpaceHeader(int offset)
        {
            byte[] data = rom.Data;
            return offset % 4 == 0 && offset + 6 <= rom.Length
                && data[offset] == 'm' && data[offset + 1] == 'a' && data[offset + 2] == 'g' && data[offset + 3] == 'e';
        }

        /// <summary>
        /// Fills the blocks with FF and writes MAGE's free space headers ("mage" + u16 length) so the space gets reused
        /// </summary>
        private static void FreeBlocks(List<Block> blocks)
        {
            byte[] data = rom.Data;
            int metroidStart = Version.IsMF ? int.MaxValue : Version.MetroidOffset;

            foreach (Block b in blocks) result.FreedRanges.Add((b.Start, b.End, b.Label));

            foreach (Block b in SortAndMerge(blocks, true))
            {
                int start = Math.Max(b.Start, MinFreeOffset);
                int end = Math.Min(b.End, metroidStart);
                if (end - start <= 0) continue;

                // merge with free space that directly follows
                while (true)
                {
                    int next = end;
                    while (next % 4 != 0 && next < rom.Length && data[next] == 0) next++;
                    if (!IsFreeSpaceHeader(next)) break;
                    int len = data[next + 4] | (data[next + 5] << 8);
                    if (len < 6) break;
                    end = next + len;
                }

                for (int i = start; i < end; i++) data[i] = 0xFF;

                // free space headers have to be aligned
                int pos = start;
                while (pos % 4 != 0 && pos < end) data[pos++] = 0;

                while (end - pos >= 6)
                {
                    int len = Math.Min(end - pos, 0xFFF0);
                    int remaining = end - pos - len;
                    if (remaining > 0 && remaining < 6) len -= 8;

                    rom.Seek(pos);
                    rom.WriteASCII("mage");
                    rom.Write16((ushort)len);
                    pos += len;
                }

                result.FreedBytes += b.End - b.Start;
            }
        }

        #endregion

        #region writing

        private static int AddData(byte[] bytes)
        {
            return rom.AddData(new ByteStream(bytes));
        }

        private static void WriteTilesets()
        {
            int gfx = Add.BlankLZ77Gfx();
            int palette = AddData(new byte[14 * 0x20]);
            int bg3Gfx = Add.BlankLZ77Gfx();
            int tileTable = Add.BlankTileTable();

            int entry = Version.TilesetOffset;
            rom.WritePtr(entry, gfx);
            rom.WritePtr(entry + 4, palette);
            rom.WritePtr(entry + 8, bg3Gfx);
            rom.WritePtr(entry + 0xC, tileTable);
            rom.Write8(entry + 0x10, 0);
            rom.Write8(entry + 0x11, 0);
            rom.Write16(entry + 0x12, 0);
            Version.NumOfTilesets = 1;
        }

        /// <summary>
        /// Resets the animated tilesets and palettes of the remaining tilesets to the blank ones
        /// </summary>
        private static void FixTilesets()
        {
            for (int t = 0; t < Version.NumOfTilesets; t++)
            {
                int entry = Version.TilesetOffset + t * 0x14;
                if (Clears(Asset.AnimatedTilesets)) rom.Write8(entry + 0x10, 0);
                if (Clears(Asset.AnimatedPalettes)) rom.Write8(entry + 0x11, 0);
            }
        }

        private static void WriteAnimations()
        {
            if (Clears(Asset.AnimatedTilesets))
            {
                int offset = Version.AnimTilesetOffset;
                for (int i = 0; i < 0x30; i++) rom.Write8(offset + i, 0);
                Version.NumOfAnimTilesets = 1;
            }

            if (Clears(Asset.AnimatedGraphics))
            {
                WriteAnimEntry(Version.AnimGfxOffset, AddData(new byte[0x80]));
                Version.NumOfAnimGfx = 1;
            }

            if (Clears(Asset.AnimatedPalettes))
            {
                WriteAnimEntry(Version.AnimPaletteOffset, AddData(new byte[0x20]));
                Version.NumOfAnimPalettes = 1;
            }
        }

        private static void WriteAnimEntry(int offset, int dataOffset)
        {
            rom.Write8(offset, 0);      // type
            rom.Write8(offset + 1, 0);  // delay
            rom.Write8(offset + 2, 1);  // number of states
            rom.Write8(offset + 3, 0);
            rom.WritePtr(offset + 4, dataOffset);
        }

        private static void WriteSpritesets()
        {
            rom.WritePtr(Version.SpritesetOffset, AddData(new byte[2]));
            Version.NumOfSpritesets = 1;
            Add.WriteSpritesetLimit(0);
        }

        private static void WriteRooms()
        {
            for (int a = 0; a < numAreas; a++)
            {
                ByteStream h = new ByteStream();
                h.Write8(0);    // tileset
                h.Write8(0x10); // BG0 prop
                h.Write8(0x10); // BG1 prop
                h.Write8(0x10); // BG2 prop
                h.Write8(0x40); // BG3 prop
                h.WritePtr(Add.BlankBgRLE(BlankRoomWidth, BlankRoomHeight));
                h.WritePtr(Add.BlankBgRLE(BlankRoomWidth, BlankRoomHeight));
                h.WritePtr(Add.BlankBgRLE(BlankRoomWidth, BlankRoomHeight));
                h.WritePtr(Add.BlankBgRLE(BlankRoomWidth, BlankRoomHeight)); // clipdata
                h.WritePtr(Add.BlankBgLZ77());
                h.Write8(0);    // BG3 scrolling
                h.Write8(0);    // transparency
                h.WritePtr(Add.BlankEnemySet());
                h.Write8(0);    // spriteset 0
                h.Write8(0);    // spriteset 1 event
                h.WritePtr(Add.BlankEnemySet());
                h.Write8(0);    // spriteset 1
                h.Write8(0);    // spriteset 2 event
                h.WritePtr(Add.BlankEnemySet());
                h.Write8(0);    // spriteset 2
                h.Write8(0);    // map x
                h.Write8(0);    // map y
                h.Write8(0);    // effect
                h.Write8(0xFF); // effect y
                h.Write16(0);   // music

                Array.Copy(h.Data, 0, rom.Data, areaRoomLists[a], 0x3C);
                Version.RoomsPerArea[a] = 1;
            }
        }

        /// <summary>
        /// Updates the remaining rooms when only some of the assets they use were cleared
        /// </summary>
        private static void FixRooms()
        {
            if (!Clears(Asset.RoomSprites | Asset.Tilesets | Asset.Spritesets)) return;

            for (int a = 0; a < numAreas; a++)
            {
                int list = rom.ReadPtr(Version.AreaHeaderOffset + a * 4);
                for (int r = 0; r < Version.RoomsPerArea[a]; r++)
                {
                    int entry = list + r * 0x3C;
                    if (Clears(Asset.RoomSprites))
                    {
                        rom.WritePtr(entry + 0x20, Add.BlankEnemySet());
                        rom.WritePtr(entry + 0x28, Add.BlankEnemySet());
                        rom.WritePtr(entry + 0x30, Add.BlankEnemySet());
                        rom.Write8(entry + 0x25, 0); // spriteset 1 event
                        rom.Write8(entry + 0x2D, 0); // spriteset 2 event
                    }
                    if (Clears(Asset.Tilesets)) rom.Write8(entry, 0);
                    if (Clears(Asset.Spritesets))
                    {
                        rom.Write8(entry + 0x24, 0);
                        rom.Write8(entry + 0x2C, 0);
                        rom.Write8(entry + 0x34, 0);
                    }
                }
            }
        }

        private static void WriteDoors()
        {
            // The game loads rooms through the door the player came from, so every area needs a door 0
            for (int a = 0; a < numAreas; a++)
            {
                byte[] list = new byte[24];
                list[0] = 0x12;     // no hatch
                list[1] = 0;        // source room
                list[2] = 1;        // x start
                list[3] = 1;        // x end
                list[4] = 8;        // y start
                list[5] = 11;       // y end
                list[6] = 0;        // destination door

                rom.WritePtr(Version.DoorsOffset + a * 4, AddData(list));
            }
        }

        private static void WriteScrolls()
        {
            for (int a = 0; a < numAreas; a++)
            {
                rom.WritePtr(areaScrollLists[a], areaScrollTerminators[a]);
            }
        }

        private static void WriteTerminatedList(int offset)
        {
            // lists without entries are already empty
            if (rom.Read8(offset) == 0xFF) return;
            rom.Write8(offset, 0xFF);
            rom.Write8(offset + 1, 0xFF);
            rom.Write8(offset + 2, 0xFF);
        }

        private static void WriteConnections()
        {
            if (Clears(Asset.AreaConnections)) WriteTerminatedList(Version.AreaConnectionsOffset);
            if (Clears(Asset.LocationNames)) WriteTerminatedList(Version.LocationNamesOffset);
            if (!Clears(Asset.DoorEvents)) return;

            // never matches: area FF doesn't exist
            byte[] sentinel = { 0xFF, 0xFF, 0, 0 };
            if (Version.NumOfDoorEvents > 0)
            {
                Array.Copy(sentinel, 0, rom.Data, Version.DoorEventsOffset, sentinel.Length);
            }
            else
            {
                // the table has no space of its own, it might have been freed already
                rom.WritePtr(Version.DoorEventsPointerOffset, AddData(sentinel));
            }
            Version.NumOfDoorEvents = 0;
        }

        private static void WriteHatchLocks()
        {
            if (Version.IsMF)
            {
                // event 0, area 0, room 0 (stored + 1), no hatches
                byte[] list = { 0, 0, 1, 0, 0xF0, 0xF0 };
                if (mfHatchLockLength >= list.Length)
                {
                    Array.Copy(list, 0, rom.Data, Version.HatchLockEventsOffset, list.Length);
                }
                else
                {
                    rom.WritePtr(Version.HatchLockEventsPointerOffset, AddData(list));
                }
                Version.NumOfHatchLockEvents = 1;
                return;
            }

            // room 0, event 0, after event, no hatches
            for (int a = 0; a < numAreas; a++)
            {
                int ptr = Version.HatchLockEventsOffset + a * 4;
                if (hatchLockCounts[a] > 0)
                {
                    int offset = rom.ReadPtr(ptr);
                    for (int i = 0; i < 8; i++) rom.Write8(offset + i, 0);
                }
                else
                {
                    rom.WritePtr(ptr, AddData(new byte[8]));
                }
                rom.Write16(Version.NumOfHatchLockEventsOffset + a * 2, 1);
            }
        }

        private static void WriteMinimaps()
        {
            int table = Version.MinimapDataOffset;
            for (int i = 0; i < Version.NumOfMinimaps; i++)
            {
                rom.WritePtr(table + i * 4, Add.BlankMinimap());
            }
        }

        private static void WriteDemos()
        {
            foreach (int num in demoNumbers)
            {
                // a single start press ends the demo
                int entry = Version.DemoInputOffset + num * 0x10;
                rom.WritePtr(entry, AddData(new byte[] { 8, 0 }));
                rom.Write16(entry + 4, 2);
                rom.WritePtr(entry + 8, AddData(new byte[] { 1, 0 }));
                rom.Write16(entry + 0xC, 2);

                SetDemoDoor(num);
            }
        }

        /// <summary>
        /// Lets the demos start at door 0, because all other doors were removed
        /// </summary>
        private static void FixDemos()
        {
            foreach (int num in demoNumbers) SetDemoDoor(num);
        }

        private static void SetDemoDoor(int num)
        {
            int ram;
            if (Version.IsMF) ram = Version.DemoRamOffset + num * 0x1C;
            else ram = rom.ReadPtr(Version.DemoRamOffset + num * 4);
            rom.Write8(ram + 1, 0);
        }

        #endregion

        /// <summary>
        /// Creates a short summary of the result for the user
        /// </summary>
        public static string Summarize(Result r)
        {
            StringBuilder sb = new();
            sb.AppendLine($"Freed 0x{r.FreedBytes:X} of 0x{r.CandidateBytes:X} bytes.");
            if (r.KeptData.Count > 0) sb.AppendLine($"{r.KeptData.Count} data ranges were kept because other data still points to them.");
            if (r.SkippedData.Count > 0) sb.AppendLine($"{r.SkippedData.Count} assets were not freed because their size could not be determined.");
            return sb.ToString();
        }
    }
}
