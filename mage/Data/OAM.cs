using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace mage
{
    public class OAM
    {
        public static int XPosRange => 1 << 9;
        public static int YPosRange => 1 << 8;
        public static int MaxPartSize => 64;
        public static int MaxWidth => XPosRange + MaxPartSize;
        public static int MaxHeight => YPosRange + MaxPartSize;
        public static int FrameOriginX => XPosRange / 2;
        public static int FrameOriginY => YPosRange / 2;

        public static JsonSerializerOptions SerializerOptions { get; } = new()
        {
            IncludeFields = true,
            WriteIndented = true,
        };

        public struct Frame
        {
            public int duration;
            public List<Part> parts;
            public int numParts;

            public int width;
            public int height;
            public int xOffset;
            public int yOffset;

            public Frame(int duration, List<Part> parts, int numParts)
            {
                this.duration = duration;
                this.parts = parts;
                this.numParts = numParts;

                width = 0;
                height = 0;
                xOffset = 0;
                yOffset = 0;

                foreach (Part part in parts)
                {
                    width = Math.Max(part.Dimensions.Width, width);
                    height = Math.Max(part.Dimensions.Height, height);
                    xOffset = Math.Min(part.xPos, xOffset);
                    yOffset = Math.Min(part.yPos, yOffset);
                }
            }

            public static Frame Empty => new Frame(1, new List<Part>(), 0);
        }

        public struct Part
        {
            //Fields
            public int xPos, yPos;
            public int shape;
            public int flip;
            public int size;
            public int tileNum;
            public int palRow;

            [JsonIgnore]
            public bool Xflip => (flip & 0b1) != 0;
            [JsonIgnore]
            public bool Yflip => (flip & 0b10) != 0;

            //Constructor
            public Part(ushort attr0, ushort attr1, ushort attr2)
            {
                yPos = attr0 & 0xFF;
                if (yPos >= 128) { yPos -= 256; }
                xPos = attr1 & 0x1FF;
                if (xPos >= 256) { xPos -= 512; }
                shape = attr0 >> 14;
                flip = (attr1 >> 12) & 0b11;
                size = attr1 >> 14;
                tileNum = attr2 & 0x3FF;
                palRow = attr2 >> 12;
            }

            public static Part Empty => new Part(0, 0, 0);

            //Properties
            [JsonIgnore]
            public Rectangle Area => new Rectangle(xPos, yPos, Dimensions.Width, Dimensions.Height);

            [JsonIgnore]
            public Size Dimensions
            {
                get
                {
                    switch (shape * 4 + size)
                    {
                        case 0:
                            return new Size(8, 8);
                        case 1:
                            return new Size(16, 16);
                        case 2:
                            return new Size(32, 32);
                        case 3:
                            return new Size(64, 64);
                        case 4:
                            return new Size(16, 8);
                        case 5:
                            return new Size(32, 8);
                        case 6:
                            return new Size(32, 16);
                        case 7:
                            return new Size(64, 32);
                        case 8:
                            return new Size(8, 16);
                        case 9:
                            return new Size(8, 32);
                        case 10:
                            return new Size(16, 32);
                        case 11:
                            return new Size(32, 64);
                    }
                    throw new FormatException();
                }
            }

            public ushort[] GetAttributes()
            {
                ushort attr0 = 0, attr1 = 0, attr2 = 0;
                attr0 |= (ushort)((yPos + (yPos < 0 ? 256 : 0)) & 0xFF);
                attr0 |= (ushort)(shape << 14);

                attr1 |= (ushort)((xPos + (xPos < 0 ? 512 : 0)) & 0x1FF);
                attr1 |= (ushort)((flip & 0b11) << 12);
                attr1 |= (ushort)(size << 14);

                attr2 |= (ushort)(tileNum & 0x3FF);
                attr2 |= (ushort)(palRow << 12);

                return new ushort[] { attr0, attr1, attr2 };
            }
        }

        /// <summary>
        /// A <see cref="Rectangle"/> that encapsulates all of the frames
        /// </summary>
        [JsonIgnore]
        public Rectangle Bounds
        {
            get
            {
                Rectangle oamBounds = new();
                foreach (Frame frame in Frames)
                {
                    foreach (Part part in frame.parts)
                    {
                        Rectangle partBounds = new Rectangle(part.xPos, part.yPos, part.Dimensions.Width, part.Dimensions.Height);
                        oamBounds = Rectangle.Union(partBounds, oamBounds);
                    }
                }
                return oamBounds;
            }
        }

        // data
        public int NumFrames;
        public List<Frame> Frames;

        private int origAddr;
        private ByteStream romStream;

        [JsonConstructor]
        public OAM() {}

        public OAM(int offset)
        {
            this.origAddr = offset;
            this.romStream = ROM.Stream;

            Frames = new List<Frame>();
            while (true)
            {
                ushort duration = romStream.Read16(offset + 4);
                if (duration == 0) { break; }
                int attrOffset = romStream.ReadPtr(offset);

                romStream.Seek(attrOffset);
                int numAttrs = romStream.Read16();
                List<Part> parts = new List<Part>();
                for (int i = 0; i < numAttrs; i++)
                {
                    ushort attr0 = romStream.Read16();
                    ushort attr1 = romStream.Read16();
                    ushort attr2 = romStream.Read16();
                    Part attrs = new Part(attr0, attr1, attr2);
                    parts.Add(attrs);
                }

                Frame frame = new Frame(duration, parts, numAttrs);
                Frames.Add(frame);

                offset += 8;
            }

            this.NumFrames = Frames.Count;
        }

        #region Normal Drawing
        /// <summary>
        /// Returns a Bitmap where the sprite is drawn in the top left corner. Bitmap size matches that of the sprite.
        /// </summary>
        /// <returns></returns>
        public Bitmap Draw(byte[] gfx, Palette pal, int row, int frameNum)
        {
            int xEnd = 0;
            int yEnd = 0;

            // get position offsets and max size
            Frame frame = Frames[frameNum];
            foreach (Part part in frame.parts)
            {
                Size s = part.Dimensions;
                if (part.xPos + s.Width > xEnd) { xEnd = part.xPos + s.Width; }
                if (part.yPos + s.Height > yEnd) { yEnd = part.yPos + s.Height; }
            }

            xEnd -= frame.xOffset;
            yEnd -= frame.yOffset;

            // draw
            Bitmap spriteImg = new Bitmap(xEnd, yEnd, PixelFormat.Format16bppArgb1555);
            Rectangle dstRect = new Rectangle(0, 0, spriteImg.Width, spriteImg.Height);
            BitmapData spriteData = spriteImg.LockBits(dstRect, ImageLockMode.WriteOnly, spriteImg.PixelFormat);

            // for each part
            for (int i = frame.numParts - 1; i >= 0; i--)
            {
                Part part = frame.parts[i];

                // use coordinates >= 0
                int xPos = part.xPos - frame.xOffset;
                int yPos = part.yPos - frame.yOffset;

                // get bitmap of part
                int tileNum = (part.tileNum + row * 64) % 1024;
                int palRow = (part.palRow + row) % 16;
                Size s = part.Dimensions;
                Rectangle rect = new Rectangle(tileNum % 32, tileNum / 32, s.Width / 8, s.Height / 8);
                Bitmap gfxImg = DrawRegion(gfx, pal, palRow, rect);

                // draw
                DrawPart(gfxImg, spriteData, part.flip, xPos, yPos);
            }

            spriteImg.UnlockBits(spriteData);
            return spriteImg;
        }

        // TODO: combine functions?
        private unsafe Bitmap DrawRegion(byte[] gfx, Palette pal, int row, Rectangle region)
        {
            int w = region.Width * 8;
            int h = region.Height * 8;
            Bitmap img = new Bitmap(w, h, PixelFormat.Format16bppArgb1555);

            Rectangle rect = new Rectangle(0, 0, w, h);
            BitmapData imgData = img.LockBits(rect, ImageLockMode.WriteOnly, img.PixelFormat);

            int xEnd = region.X + region.Width;
            int yEnd = region.Y + region.Height;
            ushort[,] palette = pal.ARGBs;

            ushort* imgPtr = (ushort*)imgData.Scan0;

            for (int y = region.Y; y < yEnd; y++)  // for each tile down
            {
                for (int x = region.X; x < xEnd; x++)  // for each tile across
                {
                    //              row in vram; tile;  max vram size;
                    int index = (y * 0x400 + x * 0x20) % 0x8000;

                    for (int r = 0; r < 8; r++)  // for each row in tile
                    {
                        for (int pp = 0; pp < 4; pp++)  // for each pixel pair
                        {
                            byte val = gfx[index++];
                            *imgPtr++ = palette[row, val & 0xF];
                            *imgPtr++ = palette[row, val >> 4];
                        }
                        imgPtr += (w - 8);
                    }
                    imgPtr -= (w * 8 - 8);
                }
                imgPtr += (w * 7);
            }

            img.UnlockBits(imgData);
            return img;
        }

        private unsafe void DrawPart(Bitmap src, BitmapData dstData, int flip, int x, int y)
        {
            int srcWidth = src.Width;
            int srcHeight = src.Height;
            int dstWidth = dstData.Stride / 2;

            Rectangle rect = new Rectangle(0, 0, srcWidth, srcHeight);
            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, src.PixelFormat);

            ushort* srcPtr = (ushort*)srcData.Scan0;
            ushort* dstPtr = (ushort*)dstData.Scan0;
            dstPtr += y * dstWidth + x;

            int i, j;
            switch (flip)
            {
                case 0:
                    i = 1;
                    j = 0;
                    break;
                case 1:
                    i = -1;
                    j = 2 * srcWidth;
                    srcPtr += srcWidth - 1;
                    break;
                case 2:
                    i = 1;
                    j = -2 * srcWidth;
                    srcPtr += srcWidth * (srcHeight - 1);
                    break;
                case 3:
                    i = -1;
                    j = 0;
                    srcPtr += srcWidth * srcHeight - 1;
                    break;
                default:
                    throw new ArgumentException("Invalid value for flip");
            }

            for (int v = 0; v < srcHeight; v++)
            {
                for (int u = 0; u < srcWidth; u++)
                {
                    ushort srcPx = *srcPtr;
                    srcPtr += i;

                    if (srcPx < 0x8000)
                    {
                        dstPtr++;
                    }
                    else
                    {
                        *dstPtr++ = srcPx;
                    }
                }
                srcPtr += j;
                dstPtr += dstWidth - srcWidth;
            }

            src.UnlockBits(srcData);
        }
        #endregion

        #region Real Drawing

        /// <summary>
        /// Creates a Bitmap where the sprite is drawn in the center/the sprites origin. 
        /// </summary>
        /// <returns></returns>
        public Bitmap DrawReal(byte[] gfx, Palette pal, int row, int frameNum)
        {
            Bitmap spriteImg = new Bitmap(MaxWidth, MaxHeight, PixelFormat.Format16bppArgb1555);
            Rectangle dstRect = new Rectangle(0, 0, spriteImg.Width, spriteImg.Height);

            // The center/"origin" of the bitmap
            Point originPos = new Point(XPosRange / 2, YPosRange/2);

            // draw for each part
            BitmapData spriteData = spriteImg.LockBits(dstRect, ImageLockMode.WriteOnly, spriteImg.PixelFormat);
            Frame frame = Frames[frameNum];

            for (int i = frame.numParts - 1; i >= 0; i--)
            {
                Part part = frame.parts[i];

                // get bitmap of part
                int tileNum = (part.tileNum + row * 64) % 1024;
                int palRow = (part.palRow + row) % 16;
                Size s = part.Dimensions;
                Rectangle rect = new Rectangle(tileNum % 32, tileNum / 32, s.Width / 8, s.Height / 8);
                Bitmap gfxImg = DrawRegion(gfx, pal, palRow, rect);

                // draw
                DrawPart(gfxImg, spriteData, part.flip, part.xPos + FrameOriginX, part.yPos + FrameOriginY);
            }

            spriteImg.UnlockBits(spriteData);
            return spriteImg;
        }
        #endregion

        public string Serialize() => JsonSerializer.Serialize(this, SerializerOptions);

        public string ToASM(string animationName = "oam")
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(".align");
            sb.AppendLine($"OAM_{animationName}_Animation:");
            for (int i = 0; i < NumFrames; i++)
            {
                Frame frame = Frames[i];
                sb.AppendLine($"\t.dw @{animationName}_Frame{Hex.ToPrefixedPaddedString(i)}, {Hex.ToPrefixedPaddedString(frame.duration)}");
            }
            sb.AppendLine("\t.dw 0,0");

            sb.AppendLine();

            for (int i = 0; i < NumFrames; i++)
            {
                Frame frame = Frames[i];
                sb.AppendLine($"@OAM_{animationName}_Frame{Hex.ToPrefixedPaddedString(i)}:");
                sb.AppendLine($"\t.dh {Hex.ToPrefixedPaddedString(frame.numParts)}");

                foreach (Part p in frame.parts)
                {
                    ushort[] attributes = p.GetAttributes();
                    sb.AppendLine($"\t.dh {Hex.ToPrefixedPaddedString(attributes[0])},{Hex.ToPrefixedPaddedString(attributes[1])},{Hex.ToPrefixedPaddedString(attributes[2])}");
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static OAM? Deserialize(string json)
        {
            try 
            { 
                OAM? result = JsonSerializer.Deserialize<OAM>(json, SerializerOptions);
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show("File did not contain OAM Data or it was corrupted.", "Invalid OAM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public static bool IsOAM(int offset)
        {
            for (int i = 0; i < 0xFFFF; i += 8)
            {
                if (ROM.Stream.Read16(offset + i + 4) == 0) return true;
            }
            return false;
        }
    }
}
