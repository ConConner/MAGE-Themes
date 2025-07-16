﻿using mage.Theming;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace mage
{
    public partial class FormMinimap : Form, Editor
    {
        // fields
        private Palette palette;
        private Bitmap mapImg;
        private Bitmap squaresImg;

        private Minimap currMap;
        private Point mPos;
        private Point sPos;
        private int selSquare;

        private bool isMF;
        private int numTiles;

        private FormMain main;
        private ByteStream romStream;
        private Status status;

        // constructor
        public FormMinimap(FormMain main)
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            this.main = main;
            this.romStream = ROM.Stream;
            Initialize(main.Room.AreaID);
        }

        public void UpdateEditor()
        {
            int paletteOffset = Version.MinimapPaletteOffset;
            int numPalettes;
            if (isMF) { numPalettes = 3; }
            else { numPalettes = 5; }
            palette = new Palette(romStream, paletteOffset, numPalettes);
            palette.SetARGB(1, 0, 0);

            DrawSquares();
            DrawMap();
            DrawSelSquare();
        }

        private void Initialize(byte areaID)
        {
            status = new Status(statusLabel_changes, button_apply);

            selSquare = -1;
            mPos = new Point(-1, -1);
            sPos = new Point(-1, -1);

            // check game
            int numPalettes;
            numTiles = 0x200;
            isMF = Version.IsMF;
            if (isMF)
            {
                numPalettes = 3;
                Patch p = new Patch(Properties.Resources.MF_U_addMinimapTiles);
                if (!p.IsApplied()) { numTiles = 0x1C0; }
                comboBox_type.Items.AddRange(new string[] { "Normal", "Hidden" });
            }
            else
            {
                numPalettes = 5;
                Patch p = new Patch(Properties.Resources.ZM_U_addMinimapTiles);
                if (!p.IsApplied()) { numTiles = 0x180; }
                comboBox_view.Items.Add("Start");
                comboBox_type.Items.AddRange(new string[] { "Start", "Normal", "Heated", "Hidden", "Heated (hidden)" });
                comboBox_palette.Items.Add("3");
                comboBox_palette.Items.Add("4");
            }

            // get palette
            int paletteOffset = Version.MinimapPaletteOffset;
            palette = new Palette(romStream, paletteOffset, numPalettes);

            // draw squares
            DrawSquares();
            gfxView_squares.BackColor = Color.Black;
            comboBox_palette.SelectedIndex = 1;

            // populate area list and load area
            comboBox_area.Items.AddRange(Version.AreaNames);
            int numOfMinimaps = Version.NumOfMinimaps;
            int currNum = comboBox_area.Items.Count;
            for (int i = currNum; i < numOfMinimaps; i++)
            {
                comboBox_area.Items.Add("Extra " + Hex.ToString(i - currNum + 1));
            }
            comboBox_area.SelectedIndex = areaID;

            // initialize squares and minimap image
            gfxView_map.Initialize(1, 8);
            gfxView_squares.Initialize(1, 10);
        }

        private unsafe void DrawSquares()
        {
            // get minimap gfx data
            byte[] data = new byte[numTiles * 32];
            romStream.CopyToArray(Version.MinimapGfxOffset, data, 0, data.Length);

            // create bitmap
            int height = numTiles / 32;
            squaresImg = new Bitmap(322, height * 10 + 2, PixelFormat.Format4bppIndexed);

            palette.SetBitmapPalette(squaresImg, 1, 1);
            ColorPalette cp = squaresImg.Palette;
            cp.Entries[0] = Color.Transparent;
            squaresImg.Palette = cp;

            Rectangle rect = new Rectangle(0, 0, squaresImg.Width, squaresImg.Height);
            BitmapData imgData = squaresImg.LockBits(rect, ImageLockMode.WriteOnly, squaresImg.PixelFormat);

            int width = imgData.Stride;
            byte* imgPtr = (byte*)imgData.Scan0 + width * 2 + 1;
            int index = 0;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < 32; x++)
                {
                    for (int r = 0; r < 8; r++)
                    {
                        for (int pp = 0; pp < 4; pp++)
                        {
                            byte val = data[index++];
                            *imgPtr++ = (byte)(((val & 0xF) << 4) | (val >> 4));
                        }
                        imgPtr += (width - 4);
                    }
                    imgPtr -= (width * 8 - 5);
                }
                imgPtr += (width * 9 + 4);
            }

            squaresImg.UnlockBits(imgData);
            gfxView_squares.Size = new Size(squaresImg.Width * 2, squaresImg.Height * 2);
            panel_squares.Height = gfxView_squares.Height + 17;
            gfxView_squares.BackgroundImage = squaresImg;
        }

        private void comboBox_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMinimap();
        }

        private void LoadMinimap()
        {
            //button_generate.Enabled = comboBox_area.SelectedIndex <= 6;

            byte areaID = (byte)comboBox_area.SelectedIndex;
            try
            {
                currMap = ROM.LoadMinimap(areaID);
            }
            catch (CorruptDataException)
            {
                var result = MessageBox.Show("Minimap data was corrupt.\n\n"
                    + "Would you like to try replacing it with blank data?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if (result == DialogResult.Yes)
                {
                    int pointer = Version.MinimapDataOffset + areaID * 4;
                    int offset = Add.BlankMinimap();
                    romStream.WritePtr(pointer, offset);
                    currMap = new Minimap(romStream, areaID);
                }
                else { return; }
            }

            if (comboBox_view.SelectedIndex == 0) { DrawMap(); }
            else { comboBox_view.SelectedIndex = 0; }

            status.LoadNew();
        }

        private void comboBox_view_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawMap();
        }

        private void DrawMap()
        {
            mapImg = currMap.Draw(romStream, palette, comboBox_view.SelectedIndex);
            gfxView_map.BackgroundImage = mapImg;
        }

        private void comboBox_palette_SelectedIndexChanged(object sender, EventArgs e)
        {
            palette.SetBitmapPalette(squaresImg, comboBox_palette.SelectedIndex, 1);
            ColorPalette cp = squaresImg.Palette;
            cp.Entries[0] = Color.Transparent;
            squaresImg.Palette = cp;
            gfxView_squares.Invalidate();
        }

        private void SetNewSquare()
        {
            // set new value on minimap
            int squareNum = selSquare;
            int val = selSquare;
            if (checkBox_xflip.Checked) { val |= 0x400; }
            if (checkBox_yflip.Checked) { val |= 0x800; }

            int pal = comboBox_type.SelectedIndex;
            // fusion and hidden
            if (isMF && pal == 1) { pal = 2; }
            val |= (pal << 12);

            currMap.SetSquare(mPos, (ushort)val);
            currMap.Edited = true;

            // get palette and square number
            int view = comboBox_view.SelectedIndex;
            Minimap.GetSquareDisplayInfo(view, ref pal, ref squareNum, isMF);

            // draw new square
            GFX gfx = new GFX(romStream, Version.MinimapGfxOffset + squareNum * 0x20, 1, 1);
            Bitmap square = gfx.Draw4bpp(palette, pal, true);

            ColorPalette cp = square.Palette;
            cp.Entries[0] = Color.Black;
            square.Palette = cp;

            // flip image
            int flip = 0;
            if (checkBox_xflip.Checked) { flip |= 1; }
            if (checkBox_yflip.Checked) { flip |= 2; }
            if (flip != 0) { Draw.Flip4bpp(square, flip); }

            using (Graphics g = Graphics.FromImage(mapImg))
            {
                g.DrawImage(square, mPos.X * 8, mPos.Y * 8);
            }

            Sound.PlaySound("map.wav");
            status.ChangeMade();
        }

        private void DrawSelSquare()
        {
            if (selSquare == -1) { return; }

            int type = comboBox_type.SelectedIndex;
            if (isMF) { type++; }

            GFX gfx = new GFX(romStream, Version.MinimapGfxOffset + selSquare * 0x20, 1, 1);
            Bitmap square = gfx.Draw4bpp(palette, type, true);

            // set first color black
            ColorPalette cp = square.Palette;
            cp.Entries[0] = Color.Black;
            square.Palette = cp;

            // flip image
            int flip = 0;
            if (checkBox_xflip.Checked) { flip |= 1; }
            if (checkBox_yflip.Checked) { flip |= 2; }
            if (flip != 0) { Draw.Flip4bpp(square, flip); }

            gfxView_sel.BackgroundImage = square;
        }

        private void SelectedSquareChanged(object sender, EventArgs e)
        {
            DrawSelSquare();
        }

        private void gfxView_map_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X >> 4;
            int y = e.Y >> 4;
            if (x == mPos.X && y == mPos.Y) { return; }
            if (x < 0 || x >= 32 || y < 0 || y >= 32) { return; }

            mPos = new Point(x, y);

            if (e.Button == MouseButtons.Left && selSquare != -1)
            {
                SetNewSquare();
                Rectangle r = new Rectangle(mPos.X * 16, mPos.Y * 16, 16, 16);
                gfxView_map.Invalidate(r);
            }

            // draw red rectangle
            Rectangle rect = gfxView_map.redRect;
            gfxView_map.MoveRed(x, y);
            rect = Draw.Union(rect, gfxView_map.redRect);
            gfxView_map.Invalidate(rect);

            // update info
            ushort val = currMap.GetSquare(mPos);
            statusLabel_tile.Text = "Tile: " + Hex.ToString(val & 0x3FF);
            statusLabel_coor.Text = "(" + Hex.ToString(mPos.X) + ", " + Hex.ToString(mPos.Y) + ")";
        }

        private void gfxView_map_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (selSquare != -1)
                {
                    SetNewSquare();
                    Rectangle rect = new Rectangle(mPos.X * 16, mPos.Y * 16, 16, 16);
                    gfxView_map.Invalidate(rect);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                ushort val = currMap.GetSquare(mPos);
                selSquare = val & 0x3FF;
                label_selSquare.Text = Hex.ToString(selSquare);

                int pal = (val >> 12);
                if (isMF && pal == 2)
                {
                    pal = 1;
                }

                comboBox_type.SelectedIndex = pal;

                checkBox_xflip.Checked = ((val & 0x400) != 0);
                checkBox_yflip.Checked = ((val & 0x800) != 0);

                DrawSelSquare();
            }
        }

        private void gfxView_squares_MouseMove(object sender, MouseEventArgs e)
        {
            int x = e.X / 20;
            int y = e.Y / 20;
            if (x == sPos.X && y == sPos.Y) { return; }
            if (x >= 32 || y >= numTiles / 32) { return; }

            sPos = new Point(x, y);

            // draw red rectangle
            Rectangle rect = gfxView_squares.redRect;
            gfxView_squares.redRect = new Rectangle(x * 20 + 2, y * 20 + 2, 19, 19);
            rect = Draw.Union(rect, gfxView_squares.redRect);
            gfxView_squares.Invalidate(rect);
        }

        private void gfxView_squares_MouseDown(object sender, MouseEventArgs e)
        {
            selSquare = sPos.Y * 32 + sPos.X;
            label_selSquare.Text = Hex.ToString(selSquare);

            checkBox_xflip.Checked = false;
            checkBox_yflip.Checked = false;

            int pal = comboBox_palette.SelectedIndex;
            if (isMF)
            {
                if (pal == 2) { pal = 1; }
                else { pal = 0; }
            }
            comboBox_type.SelectedIndex = pal;

            DrawSelSquare();
        }

        private void button_editGFX_Click(object sender, EventArgs e)
        {
            int height = numTiles / 32;
            FormGraphics form = new FormGraphics(main, Version.MinimapGfxOffset, 32, height, Version.MinimapPaletteOffset);
            form.Show();
        }

        private void button_bgColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            cd.Color = gfxView_squares.BackColor;

            if (cd.ShowDialog() == DialogResult.OK)
            {
                gfxView_squares.BackColor = cd.Color;
            }
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            ROM.SaveMinimap(currMap);
            status.Save();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void statusStrip_importRaw_Click(object sender, EventArgs e)
        {
            OpenFileDialog openRaw = new OpenFileDialog();
            openRaw.Filter = "All files (*.*)|*.*";
            if (openRaw.ShowDialog() == DialogResult.OK)
            {
                byte[] temp = System.IO.File.ReadAllBytes(openRaw.FileName);
                ByteStream input = new ByteStream(temp);
                currMap.Import(input);
                currMap.Write(romStream, true, false);
                DrawMap();

                status.Import();
            }
        }

        private void statusStrip_exportRaw_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveRaw = new SaveFileDialog();
            saveRaw.Filter = "All files (*.*)|*.*";
            if (saveRaw.ShowDialog() == DialogResult.OK)
            {
                ByteStream output = new ByteStream();
                currMap.Write(output, false, true);
                output.Export(saveRaw.FileName);
            }
        }

        private void statusStrip_exportImage_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveMap = new SaveFileDialog();
            saveMap.Filter = "PNG files (*.png)|*.png";
            if (saveMap.ShowDialog() == DialogResult.OK)
            {
                mapImg.Save(saveMap.FileName);
            }
        }

        //These fields will be used for map room cycling if multiple rooms overlap
        int lastIndex = 0;
        List<byte> lastList = new();

        private void FormMinimap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.G) { return; }
            if (mPos.X == -1) { return; }

            int area = comboBox_area.SelectedIndex;
            if (area >= Version.RoomsPerArea.Length) { return; }

            byte x = (byte)mPos.X;
            byte y = (byte)mPos.Y;

            int numOfRooms = Version.RoomsPerArea[area];

            //Loop throug all rooms and get list of rooms that match
            List<byte> matchingRooms = new();
            for (byte r = 0; r < numOfRooms; r++)
            {
                //Get Data from the room
                Room room = null;
                try { room = new Room(area, r); }
                catch { continue; }

                if (room.Contains(x, y)) matchingRooms.Add(r);
            }

            if (matchingRooms.Count == 1) main.JumpToRoom(area, matchingRooms[0]);

            if (matchingRooms.Count > 1)
            {
                //Set data up for cycling
                if (!lastList.SequenceEqual(matchingRooms))
                {
                    lastIndex = 0;
                    lastList = matchingRooms;
                }
                else
                {
                    lastIndex++;
                    if (lastIndex >= matchingRooms.Count) lastIndex = 0;
                    lastList = matchingRooms;
                }
                main.JumpToRoom(area, matchingRooms[lastIndex]);
            }

            return;
        }

        private void button_generate_Click(object sender, EventArgs e)
        {
            comboBox_type.SelectedIndex = 1;

            //clearing old map
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 32; j++)
                {
                    selSquare = 0x140;
                    mPos = new Point(i, j);
                    SetNewSquare();
                }
            }

            selSquare = 0x87;

            //Loop through each room and room header in the current selected area
            byte area = (byte)comboBox_area.SelectedIndex;
            for (int i = 0; i < Version.RoomsPerArea[(byte)comboBox_area.SelectedIndex]; i++)
            {
                //Create Room Object, read map coordinates
                Room rm = new Room(area, i);
                int width = rm.Width / 0xF;
                int height = rm.Height / 0xA;

                int offset = romStream.ReadPtr(Version.AreaHeaderOffset + area * 4) + (i * 0x3C);
                byte mapX = romStream.Read8(offset + 0x35);
                byte mapY = romStream.Read8(offset + 0x36);

                //place map tile
                for (int j = 0; j < width; j++)
                {
                    for (int k = 0; k < height; k++)
                    {
                        mPos = new Point(mapX + j, mapY + k);
                        SetNewSquare();
                    }
                }
            }

            gfxView_map.Invalidate();
        }
    }
}
