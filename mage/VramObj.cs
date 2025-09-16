using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace mage
{
    public class VramObj
    {
        public byte[] objTiles;
        public Palette palette;
        public GFX VramGFX => new GFX(objTiles, 32);

        private Dictionary<int, int> rowAssignments;
        private ByteStream romStream;

        public VramObj(GFX gfx, Palette pal, Boolean loadCommonGraphics = true)
        {
            romStream = ROM.Stream;
            int dstOffset = 0;
            if (loadCommonGraphics) dstOffset += 0x4000;
            LoadGenericData(loadCommonGraphics);

            // copy gfx
            int length = Math.Min(0x8000 - dstOffset, gfx.data.Length);
            Buffer.BlockCopy(gfx.data, 0, objTiles, dstOffset, length);

            //palette
            if (loadCommonGraphics)
            {
                // Math.Clamp fixes a bug where palette row length can be determined by decompressed
                //   graphics calculated height and could get calculated to a number larger than 15
                palette.Copy(pal, 0, 8 % 16, Math.Clamp(pal.Rows, 0, 8));
            }
            else // Shifts palette for current offset to row 0
            {
                Palette tempPalette = new Palette(romStream, pal.Offset, pal.Rows);
                palette.Copy(tempPalette, 0, 0, pal.Rows);
            }
        }

        public VramObj(Spriteset spriteset, Boolean loadCommonGraphics = true)
        {
            romStream = ROM.Stream;
            LoadGenericData(loadCommonGraphics);

            rowAssignments = new Dictionary<int, int>();
            for (int i = 0; i < spriteset.spriteIDs.Count; i++)
            {
                byte spriteID = spriteset.spriteIDs[i];
                byte gfxRow = spriteset.gfxRows[i];
                LoadSprite(spriteID, gfxRow);
            }
        }

        public VramObj(byte spriteID, bool primary, Boolean loadCommonGraphics = true)
        {
            romStream = ROM.Stream;
            LoadGenericData(loadCommonGraphics);

            rowAssignments = new Dictionary<int, int>();
            if (!primary)
            {
                byte temp;
                if (Version.SSpriteOwner.TryGetValue(spriteID, out temp))
                {
                    spriteID = temp;
                }
            }

            LoadSprite(spriteID, 0);
        }

        private void LoadGenericData(bool loadCommonGraphics)
        {
            // gfx
            objTiles = new byte[0x8000];
            if (loadCommonGraphics) // Shows common in-game OAM graphics
            {
                byte[] data = ROM.GenericSpriteGfx.data;
                Buffer.BlockCopy(data, 0, objTiles, 0x800, data.Length);
            }

            // palette
            palette = new Palette(16);
            if (loadCommonGraphics) // Shows palette for common in-game OAM
            {
                Palette genPal = ROM.GenericSpritePalette;
                palette.Copy(genPal, 0, 2, genPal.Rows);
            }
        }

        private void LoadSprite(byte spriteID, byte gfxRow)
        {
            if (spriteID < 0x10 || gfxRow >= 8) { return; }

            try
            {
                int addVal = (spriteID - 0x10) * 4;
                int offset = Version.SpriteGfxOffset + addVal;
                int gfxOffset = romStream.ReadPtr(offset);

                // check if already exists
                if (rowAssignments.ContainsKey(gfxOffset))
                {
                    if (rowAssignments[gfxRow] == gfxRow) { return; }
                }

                // get gfx
                int numGfxRows;
                GFX gfx;
                if (Version.IsMF)
                {
                    offset = Version.SpriteGfxRowsOffset + addVal;
                    numGfxRows = romStream.Read16(offset) / 0x800;
                    gfx = new GFX(romStream, gfxOffset, 32, numGfxRows * 2);
                }
                else
                {
                    numGfxRows = Math.Max(romStream.Read16(gfxOffset + 1) / 0x800, 1);
                    gfx = new GFX(romStream, gfxOffset);
                }

                // get palette
                offset = Version.SpritePaletteOffset + addVal;
                int paletteOffset = romStream.ReadPtr(offset);
                Palette spPalette = new Palette(romStream, paletteOffset, numGfxRows);

                // copy gfx
                int dstOffset = 0x4000 + gfxRow * 0x800;
                int length = Math.Min(0x8000 - dstOffset, gfx.data.Length);
                Buffer.BlockCopy(gfx.data, 0, objTiles, dstOffset, length);
                // copy palette
                palette.Copy(spPalette, 0, (8 + gfxRow) % 16, spPalette.Rows);
            }
            catch { return; }
        }

        public Bitmap DrawSpriteset(int totalRows, List<byte> spriteIDs, List<byte> gfxRows, List<SpriteGFX> spriteGfx)
        {
            // reload spriteset gfx
            rowAssignments = new Dictionary<int, int>();
            for (int i = 0; i < spriteIDs.Count; i++)
            {
                byte spriteID = spriteIDs[i];
                byte gfxRow = gfxRows[i];
                LoadSprite(spriteID, gfxRow);
            }

            // draw
            Bitmap gfxImg = new Bitmap(256, totalRows * 16, PixelFormat.Format16bppRgb555);

            int prev = -1;
            for (int s = 0; s < gfxRows.Count; s++)  // for each slot
            {
                SpriteGFX sp = spriteGfx[s];

                // graphics
                int yStart = gfxRows[s];
                int yEnd = Math.Min(yStart + sp.NumGfxRows, 8);

                if (yStart == prev || yStart == 8)
                {
                    prev = yStart;
                    continue;
                }
                yStart &= 7;

                GFX gfx = new GFX(objTiles, 32);
                using (Graphics g = Graphics.FromImage(gfxImg))
                {
                    int row = yStart + 8;
                    int drawHeight = (yEnd - yStart) * 2;
                    Bitmap img = gfx.Draw4bppSpriteset(palette, row, drawHeight);
                    g.DrawImage(img, 0, yStart * 16);
                }

                prev = yStart;
            }

            return gfxImg;
        }
    }
}
