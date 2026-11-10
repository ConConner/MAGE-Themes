using System;
using System.Collections.Generic;
using System.Linq;

namespace mage
{
    /// <summary>
    /// A block of Samus graphics as used by the top and bottom half of Samus. It is stored uncompressed
    /// as a 2 byte header (amount of tiles in the first and second row) followed by the tiles of both rows.
    /// The game copies the first row to the upper and the second row to the lower VRAM row every frame.
    /// </summary>
    public class SamusGfx
    {
        public const int TileLength = 0x20;

        /// <summary>
        /// Offset of the header in the ROM, or -1 if the block does not exist in the ROM yet
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The length of the data at <see cref="Offset"/> the last time it was read or written
        /// </summary>
        public int OrigLength { get; set; }

        public int Length => 2 + (RowTiles[0] + RowTiles[1]) * TileLength;

        public readonly int[] RowTiles = new int[2];
        public readonly byte[][] Rows = new byte[2][];

        private SamusGfx() { }

        public SamusGfx(ByteStream romStream, int offset)
        {
            Offset = offset;
            for (int r = 0; r < 2; r++)
            {
                RowTiles[r] = romStream.Read8(offset + r);
                Rows[r] = new byte[RowTiles[r] * TileLength];
            }
            romStream.CopyToArray(offset + 2, Rows[0], 0, Rows[0].Length);
            romStream.CopyToArray(offset + 2 + Rows[0].Length, Rows[1], 0, Rows[1].Length);
            OrigLength = Length;
        }

        public static SamusGfx Empty
        {
            get
            {
                SamusGfx gfx = new SamusGfx() { Offset = -1 };
                gfx.Rows[0] = Array.Empty<byte>();
                gfx.Rows[1] = Array.Empty<byte>();
                return gfx;
            }
        }

        /// <summary>
        /// Creates a copy of the graphics that does not exist in the ROM yet
        /// </summary>
        public SamusGfx Clone()
        {
            SamusGfx copy = new SamusGfx() { Offset = -1 };
            for (int r = 0; r < 2; r++)
            {
                copy.RowTiles[r] = RowTiles[r];
                copy.Rows[r] = (byte[])Rows[r].Clone();
            }
            return copy;
        }

        /// <summary>
        /// Changes the amount of tiles in a row, keeping as many of the existing tiles as possible
        /// </summary>
        public void SetRow(int row, int tiles, byte[] data)
        {
            RowTiles[row] = tiles;
            Rows[row] = data;
        }

        public static byte[] ResizeRowData(byte[] data, int tiles)
        {
            byte[] resized = new byte[tiles * TileLength];
            Array.Copy(data, resized, Math.Min(data.Length, resized.Length));
            return resized;
        }

        /// <param name="x">Pixel position in the row</param>
        /// <param name="y">Pixel position in the row (0-7)</param>
        public int GetPixel(int row, int x, int y)
        {
            int index = PixelIndex(row, x, y);
            if (index < 0) return -1;
            byte b = Rows[row][index];
            return (x & 1) == 0 ? b & 0xF : b >> 4;
        }

        public void SetPixel(int row, int x, int y, int palIndex)
        {
            int index = PixelIndex(row, x, y);
            if (index < 0 || palIndex < 0) return;
            byte b = Rows[row][index];
            if ((x & 1) == 0) b = (byte)((b & 0xF0) | (palIndex & 0xF));
            else b = (byte)((b & 0x0F) | ((palIndex & 0xF) << 4));
            Rows[row][index] = b;
        }

        private int PixelIndex(int row, int x, int y)
        {
            if (x < 0 || y < 0 || y >= 8 || x >= RowTiles[row] * 8) return -1;
            return (x / 8) * TileLength + y * 4 + (x % 8) / 2;
        }

        public ByteStream ToByteStream()
        {
            ByteStream bs = new ByteStream(Length);
            bs.Write8((byte)RowTiles[0]);
            bs.Write8((byte)RowTiles[1]);
            foreach (byte b in Rows[0]) bs.Write8(b);
            foreach (byte b in Rows[1]) bs.Write8(b);
            return bs;
        }

        public bool DiffersFrom(ByteStream romStream)
        {
            if (Offset < 0 || Length != OrigLength) return true;
            ByteStream bs = ToByteStream();
            for (int i = 0; i < Length; i++)
                if (bs.Data[i] != romStream.Read8(Offset + i)) return true;
            return false;
        }

        public static bool IsValid(ByteStream romStream, int offset)
        {
            if (offset < 0 || offset + 2 >= romStream.Length) return false;
            int length = 2 + (romStream.Read8(offset) + romStream.Read8(offset + 1)) * TileLength;
            return offset + length <= romStream.Length;
        }
    }

    /// <summary>
    /// The body OAM of a Samus animation frame. Frames that point to the same OAM share the same parts list.
    /// </summary>
    public class SamusOamData
    {
        public int Offset { get; set; }
        public int OrigLength { get; set; }
        public List<OAM.Part> Parts { get; }

        public int Length => 2 + Parts.Count * 6;

        public SamusOamData(List<OAM.Part> parts, int offset = -1)
        {
            Parts = parts;
            Offset = offset;
            OrigLength = offset < 0 ? 0 : Length;
        }

        public static SamusOamData Read(ByteStream romStream, int offset)
        {
            int count = romStream.Read16(offset) & 0xFF;
            List<OAM.Part> parts = new List<OAM.Part>(count);
            for (int i = 0; i < count; i++)
            {
                int p = offset + 2 + i * 6;
                parts.Add(new OAM.Part(romStream.Read16(p), romStream.Read16(p + 2), romStream.Read16(p + 4)));
            }
            return new SamusOamData(parts, offset);
        }

        public SamusOamData Clone() => new SamusOamData(new List<OAM.Part>(Parts));

        public ByteStream ToByteStream()
        {
            ByteStream bs = new ByteStream(Length);
            bs.Write16((ushort)Parts.Count);
            foreach (OAM.Part part in Parts)
            {
                foreach (ushort attr in part.GetAttributes()) bs.Write16(attr);
            }
            return bs;
        }

        public bool DiffersFrom(ByteStream romStream)
        {
            if (Offset < 0 || Length != OrigLength) return true;
            ByteStream bs = ToByteStream();
            for (int i = 0; i < Length; i++)
                if (bs.Data[i] != romStream.Read8(Offset + i)) return true;
            return false;
        }
    }

    public class SamusFrame
    {
        public SamusGfx Top { get; set; }
        public SamusGfx Bottom { get; set; }
        public SamusOamData Oam { get; set; }

        public SamusFrame(SamusGfx top, SamusGfx bottom, SamusOamData oam)
        {
            Top = top;
            Bottom = bottom;
            Oam = oam;
        }
    }

    /// <summary>
    /// Which graphics a tile in Samus' VRAM was copied from
    /// </summary>
    public readonly record struct SamusTileSource(SamusGfx Gfx, int Row, int Tile);

    /// <summary>
    /// A Samus animation: a list of frames, each pointing to the graphics of the top and bottom half,
    /// the body OAM and how long the frame is displayed. The list ends with an empty frame.
    /// </summary>
    public class SamusAnimation
    {
        public const int FrameLength = 0x10;
        public const int MaxFrames = 0xFF;

        // VRAM tile the game copies each part of the graphics to (see TransferSamusGraphics)
        public const int TopVramTile = 0x00;
        public const int BottomVramTile = 0x14;
        public const int VramRowTiles = 0x20;
        public const int MaxTopTiles = BottomVramTile - TopVramTile;
        public const int MaxBottomTiles = VramRowTiles - BottomVramTile;
        public const int VramRows = 2;

        public int Offset { get; private set; }
        private int origNumFrames;

        /// <summary>
        /// The body OAM of every frame. The duration of a frame is the timer of the animation frame.
        /// Kept as an <see cref="OAM"/> so OAM drawing and OAM editor actions can be used.
        /// </summary>
        public OAM Oam { get; }
        public List<SamusFrame> Frames { get; }

        // Data that was referenced when loading, used to find data no longer referenced after saving
        private readonly Dictionary<int, int> loadedGfx = new();
        private readonly Dictionary<int, int> loadedOam = new();

        public SamusAnimation(int offset)
        {
            ByteStream romStream = ROM.Stream;
            Offset = offset;

            Oam = new OAM() { Frames = new List<OAM.Frame>() };
            Frames = new List<SamusFrame>();

            Dictionary<int, SamusGfx> gfxCache = new();
            Dictionary<int, SamusOamData> oamCache = new();

            int addr = offset;
            while (true)
            {
                if (addr + FrameLength > romStream.Length) throw new FormatException("Animation does not end.");
                byte timer = romStream.Read8(addr + 12);
                if (timer == 0) break;
                if (Frames.Count >= MaxFrames) throw new FormatException("Animation has too many frames.");

                int topPtr = ReadDataPointer(romStream, addr);
                int bottomPtr = ReadDataPointer(romStream, addr + 4);
                int oamPtr = ReadDataPointer(romStream, addr + 8);
                if (!SamusGfx.IsValid(romStream, topPtr) || !SamusGfx.IsValid(romStream, bottomPtr))
                    throw new FormatException("Invalid graphics pointer.");

                if (!gfxCache.TryGetValue(topPtr, out SamusGfx top)) gfxCache[topPtr] = top = new SamusGfx(romStream, topPtr);
                if (!gfxCache.TryGetValue(bottomPtr, out SamusGfx bottom)) gfxCache[bottomPtr] = bottom = new SamusGfx(romStream, bottomPtr);
                if (!oamCache.TryGetValue(oamPtr, out SamusOamData oam)) oamCache[oamPtr] = oam = SamusOamData.Read(romStream, oamPtr);

                Frames.Add(new SamusFrame(top, bottom, oam));
                Oam.Frames.Add(new OAM.Frame(timer, oam.Parts, oam.Parts.Count));

                addr += FrameLength;
            }

            if (Frames.Count == 0) throw new FormatException("Animation has no frames.");

            Oam.NumFrames = Frames.Count;
            origNumFrames = Frames.Count;
            foreach (var kvp in gfxCache) loadedGfx[kvp.Key] = kvp.Value.OrigLength;
            foreach (var kvp in oamCache) loadedOam[kvp.Key] = kvp.Value.OrigLength;
        }

        private static int ReadDataPointer(ByteStream romStream, int addr)
        {
            int raw = romStream.Read32(addr);
            int ptr = romStream.ReadPtr(addr);
            if ((raw >> 24) != 0x08 || ptr >= romStream.Length) throw new FormatException("Invalid pointer.");
            return ptr;
        }

        public static bool IsAnimation(int offset)
        {
            try { return new SamusAnimation(offset).Frames.Count > 0; }
            catch { return false; }
        }

        public int NumFrames => Frames.Count;

        /// <summary>
        /// Frames that share OAM data share the same parts list, so part count changes have to be passed on
        /// </summary>
        public void SyncPartCounts()
        {
            for (int i = 0; i < Oam.Frames.Count; i++)
            {
                OAM.Frame frame = Oam.Frames[i];
                if (frame.numParts == frame.parts.Count) continue;
                frame.numParts = frame.parts.Count;
                Oam.Frames[i] = frame;
            }
        }

        public void InsertFrame(int index, SamusFrame frame, int duration)
        {
            Frames.Insert(index, frame);
            Oam.Frames.Insert(index, new OAM.Frame(duration, frame.Oam.Parts, frame.Oam.Parts.Count));
            Oam.NumFrames = Frames.Count;
        }

        public void RemoveFrame(int index)
        {
            Frames.RemoveAt(index);
            Oam.Frames.RemoveAt(index);
            Oam.NumFrames = Frames.Count;
        }

        public void SwapFrames(int a, int b)
        {
            (Frames[a], Frames[b]) = (Frames[b], Frames[a]);
            (Oam.Frames[a], Oam.Frames[b]) = (Oam.Frames[b], Oam.Frames[a]);
        }

        /// <summary>
        /// Replaces the OAM data of a frame, keeping its duration
        /// </summary>
        public void SetFrameOam(int index, SamusOamData oam)
        {
            Frames[index].Oam = oam;
            OAM.Frame frame = Oam.Frames[index];
            frame.parts = oam.Parts;
            frame.numParts = oam.Parts.Count;
            Oam.Frames[index] = frame;
        }

        #region VRAM
        /// <summary>
        /// Builds Samus' object VRAM like the game does for the given frame
        /// </summary>
        /// <param name="sources">Where each of the first <see cref="VramRows"/> rows of tiles was copied from</param>
        public byte[] BuildVram(int frameIndex, out SamusTileSource?[] sources)
        {
            byte[] vram = new byte[0x8000];
            sources = new SamusTileSource?[VramRows * VramRowTiles];
            SamusFrame frame = Frames[frameIndex];

            // Same order as the game, later copies overwrite earlier ones
            CopyRow(vram, sources, frame.Top, 0, TopVramTile);
            CopyRow(vram, sources, frame.Top, 1, TopVramTile + VramRowTiles);
            CopyRow(vram, sources, frame.Bottom, 0, BottomVramTile);
            CopyRow(vram, sources, frame.Bottom, 1, BottomVramTile + VramRowTiles);
            return vram;
        }

        private static void CopyRow(byte[] vram, SamusTileSource?[] sources, SamusGfx gfx, int row, int dstTile)
        {
            for (int t = 0; t < gfx.RowTiles[row]; t++)
            {
                int tile = dstTile + t;
                if (tile >= sources.Length) break;
                Array.Copy(gfx.Rows[row], t * SamusGfx.TileLength, vram, tile * SamusGfx.TileLength, SamusGfx.TileLength);
                sources[tile] = new SamusTileSource(gfx, row, t);
            }
        }
        #endregion

        #region Saving
        /// <summary>
        /// Writes the animation and all of its graphics and OAM to the ROM. Data shared with other animations
        /// is edited for all of them, data that grows is moved and every pointer to it is updated.
        /// </summary>
        public void Save(ByteStream romStream)
        {
            SyncPartCounts();

            foreach (SamusGfx gfx in Frames.SelectMany(f => new[] { f.Top, f.Bottom }).Distinct())
            {
                if (!gfx.DiffersFrom(romStream)) continue;
                gfx.Offset = WriteData(romStream, gfx.ToByteStream(), gfx.Offset, gfx.OrigLength, loadedGfx);
                gfx.OrigLength = gfx.Length;
            }

            foreach (SamusOamData oam in Frames.Select(f => f.Oam).Distinct())
            {
                if (!oam.DiffersFrom(romStream)) continue;
                oam.Offset = WriteData(romStream, oam.ToByteStream(), oam.Offset, oam.OrigLength, loadedOam);
                oam.OrigLength = oam.Length;
            }

            // Frame list
            ByteStream table = new ByteStream();
            for (int i = 0; i < Frames.Count; i++)
            {
                table.WritePtr(Frames[i].Top.Offset);
                table.WritePtr(Frames[i].Bottom.Offset);
                table.WritePtr(Frames[i].Oam.Offset);
                table.Write32(Oam.Frames[i].duration & 0xFF);
            }
            for (int i = 0; i < 4; i++) table.Write32(0);
            Offset = WriteData(romStream, table, Offset, (origNumFrames + 1) * FrameLength, null);
            origNumFrames = Frames.Count;

            FreeUnreferencedData(romStream);
        }

        /// <param name="loaded">Data loaded with the animation, old locations of moved data are removed from it since they are already freed</param>
        private static int WriteData(ByteStream romStream, ByteStream data, int offset, int origLength, Dictionary<int, int>? loaded)
        {
            if (offset < 0) return romStream.AddData(data);

            // Same length can be overwritten without touching anything around it
            if (data.Length == origLength)
            {
                romStream.CopyFromArray(data.Data, 0, offset, data.Length);
                return offset;
            }

            // Shrinks in place, or moves the data and updates every pointer to it
            int oldOffset = offset;
            romStream.Write2(data, origLength, ref offset, true);
            if (offset != oldOffset) loaded?.Remove(oldOffset);
            return offset;
        }

        // Frees data this animation used when it was loaded that nothing points to anymore
        private void FreeUnreferencedData(ByteStream romStream)
        {
            HashSet<int> usedGfx = Frames.SelectMany(f => new[] { f.Top.Offset, f.Bottom.Offset }).ToHashSet();
            HashSet<int> usedOam = Frames.Select(f => f.Oam.Offset).ToHashSet();

            void Free(Dictionary<int, int> loaded, HashSet<int> used)
            {
                foreach (var kvp in loaded.ToList())
                {
                    if (used.Contains(kvp.Key)) continue;
                    loaded.Remove(kvp.Key);
                    if (romStream.GetPointers(kvp.Key).Count > 0) continue;
                    romStream.MarkFreeSpace(kvp.Key, kvp.Value, 0);
                }
            }
            Free(loadedGfx, usedGfx);
            Free(loadedOam, usedOam);

            // Data that was moved or created is now what this animation loaded
            foreach (SamusFrame f in Frames)
            {
                loadedGfx[f.Top.Offset] = f.Top.OrigLength;
                loadedGfx[f.Bottom.Offset] = f.Bottom.OrigLength;
                loadedOam[f.Oam.Offset] = f.Oam.OrigLength;
            }
        }
        #endregion
    }
}
