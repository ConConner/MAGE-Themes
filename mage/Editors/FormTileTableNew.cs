using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace mage.Editors
{
    public partial class FormTileTableNew : Form
    {
        #region Fields
        private bool init = false;

        Pen CursorPen = new Pen(Color.Red, 1);
        Pen SelectionPenWhite = new Pen(Color.White, 1) { DashPattern = new float[] { 2, 3 } };
        Pen SelectionPenBlack = new Pen(Color.Black, 1) { DashPattern = new float[] { 2, 3 }, DashOffset = 2 };

        // Drawables for UI
        private Drawable GfxCursor;
        private Drawable GfxSelection;
        private Point GfxSelectionPivot;

        private Drawable TableCursor;
        private Drawable TableSelection;
        private Point TableSelectionPivot;

        private Room? openedInRoom;

        // Current loaded TileTable related Data
        private ushort[] tileTable;
        private int numOfTiles;
        private int origLen;
        private byte[] gfxData;
        Palette palette;
        #endregion

        public FormTileTableNew()
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            // GFX View Setup
            GfxCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
            GfxSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = false };
            GfxSelection.DrawPens.Add(SelectionPenBlack);
            gfxView.AddDrawable(GfxCursor);
            gfxView.AddDrawable(GfxSelection);
            updateGfxZoom(1);

            // Table View Setup
            TableCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
            TableSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = false };
            TableSelection.DrawPens.Add(SelectionPenBlack);
            tableView.AddDrawable(TableCursor);
            tableView.AddDrawable(TableSelection);
            updateTableZoom(0);

            // Controls Setup
            SetupComboboxes();
        }

        public FormTileTableNew(Room room) : this()
        {
            openedInRoom = room;
            comboBox_tileset.SelectedIndex = room.tileset.number;
        }

        private void SetupComboboxes()
        {
            int numTilesets = Version.NumOfTilesets;
            for (int i = 0; i < numTilesets; i++)
            {
                comboBox_tileset.Items.Add(Hex.ToString(i));
            }

            for (int i = 0; i < 16; i++)
            {
                comboBox_palette.Items.Add(Hex.ToString(i));
            }
        }

        #region Drawing and Setup Code
        private void InitializeWithTileset()
        {
            init = true;

            // get tileset and vram
            Tileset tileset = new Tileset(ROM.Stream, (byte)comboBox_tileset.SelectedIndex);
            VramBG vram = new VramBG(tileset, false);
            gfxData = new byte[0x8000];
            Array.Copy(vram.BGtiles, gfxData, 0x8000);
            palette = vram.BGpalette;

            // initialize tiletable
            tileTable = new ushort[0x1000];
            ushort[] origTileTable = tileset.tileTable;
            numOfTiles = origTileTable.Length;
            origLen = numOfTiles;

            // Copy original Data and set remaining space as empty tiles
            origTileTable.CopyTo(tileTable, 0);
            for (int i = numOfTiles; i < 0x1000; i++) tileTable[i] = 0x40;

            // Palette
            comboBox_palette.SelectedIndex = 0;
            paletteView.TileImage = palette.Draw(16, 0, 16);

            // set tileset image
            int height = numOfTiles / 64;
            numericUpDown_height.Enabled = true;
            numericUpDown_height.Value = height;
            DrawGFX();
            SetTileTableImage(256, numOfTiles / 4);

            init = false;
        }

        private void DrawGFX()
        {
            GFX gfx = new GFX(gfxData, 32);
            Bitmap gfxImg = gfx.Draw15bpp(palette, comboBox_palette.SelectedIndex, false);

            gfxView.TileImage = gfxImg;
        }

        private void SetTileTableImage(int width, int height)
        {
            Bitmap resultImg = new Bitmap(width, height, PixelFormat.Format16bppArgb1555);
            DrawTileTable(resultImg);
            tableView.TileImage = resultImg;
        }

        private unsafe void DrawTileTable(Bitmap image)
        {
            int w = image.Width;
            int index = 0;
            ushort[,] _palette = palette.ARGBs;

            Rectangle rect = new Rectangle(0, 0, image.Width, image.Height);
            BitmapData imgData = image.LockBits(rect, ImageLockMode.WriteOnly, image.PixelFormat);

            ushort* startPtr = (ushort*)imgData.Scan0;
            ushort* imgPtr = startPtr;

            for (int t = 0; t < numOfTiles; t++)
            {
                int x = 0, y = 0;
                switch (tab_select.SelectedIndex)
                {
                    case 0:
                        x = ((t % 64) / 4) * 16 + (t % 2) * 8;
                        y = (t / 64) * 16 + ((t % 4) / 2) * 8;
                        break;
                    case 1:
                    //switch (comboBox_size.SelectedIndex)
                    //{
                    //    case 0:
                    //    case 2:
                    //        x = (t % 32) * 8;
                    //        y = (t / 32) * 8;
                    //        break;
                    //    case 1:
                    //        x = (t / 0x400) * 256 + (t % 32) * 8;
                    //        y = ((t / 32) % 32) * 8;
                    //        break;
                    //}
                    //break;
                    case 2:
                        x = (t % 32) * 8;
                        y = (t / 32) * 8;
                        break;
                }
                imgPtr = startPtr + y * w + x;

                ushort currTile = tileTable[index++];
                int tileNum = currTile & 0x3FF;
                // check for valid tile number
                //if (tab_select.SelectedIndex == 2)
                //{
                //    tileNum -= (int)numericUpDown_shift.Value;
                //    if (tileNum < 0) { continue; }
                //}
                tileNum *= 0x20;
                if (tileNum >= gfxData.Length) { continue; }
                int pal = currTile >> 12;
                int flip = (currTile >> 10) & 3;

                switch (flip)
                {
                    // no flip
                    case 0:
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr++ = _palette[pal, val & 0xF];
                                *imgPtr++ = _palette[pal, val >> 4];
                            }
                            // end of row
                            imgPtr += (w - 8);
                        }
                        break;
                    // x flip
                    case 1:
                        imgPtr += 7;
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr-- = _palette[pal, val & 0xF];
                                *imgPtr-- = _palette[pal, val >> 4];
                            }
                            // end of row
                            imgPtr += (w + 8);
                        }
                        break;
                    // y flip
                    case 2:
                        imgPtr += (w * 7);
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr++ = _palette[pal, val & 0xF];
                                *imgPtr++ = _palette[pal, val >> 4];
                            }
                            // end of row
                            imgPtr -= (w + 8);
                        }
                        break;
                    // xy flip
                    case 3:
                        imgPtr += (w * 7 + 7);
                        for (int r = 0; r < 8; r++)
                        {
                            for (int pp = 0; pp < 4; pp++)
                            {
                                byte val = gfxData[tileNum++];
                                *imgPtr-- = _palette[pal, val & 0xF];
                                *imgPtr-- = _palette[pal, val >> 4];
                            }
                            // end of row
                            imgPtr -= (w - 8);
                        }
                        break;
                }
            }

            image.UnlockBits(imgData);
        }
        #endregion

        #region Events
        private void comboBox_tileset_SelectedIndexChanged(object sender, EventArgs e) => InitializeWithTileset();

        private void comboBox_palette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init) return;
            DrawGFX();
        }

        #region GFX Display
        // ZOOM
        private const int maxZoom = 4;
        private void button_gfxZoomIn_Click(object sender, EventArgs e) => updateGfxZoom(gfxView.Zoom + 1);

        private void button_gfxZoomOut_Click(object sender, EventArgs e) => updateGfxZoom(gfxView.Zoom - 1);

        private void updateGfxZoom(int value)
        {
            gfxView.Zoom = Math.Clamp(value, 0, maxZoom);
            button_gfxZoomIn.Enabled = gfxView.Zoom < maxZoom;
            button_gfxZoomOut.Enabled = gfxView.Zoom > 0;
            label_gfxZoom.Text = $"{1 << gfxView.Zoom}00%";
        }

        // MOUSE
        private void tile_gfxView_TileMouseDown(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (gfxView.TileImage == null) return;

            GfxCursor.Visible = false;
            GfxSelection.Visible = true;
            GfxSelection.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, e.TileSize, e.TileSize);
            GfxSelectionPivot = GfxSelection.Location;
        }

        private void tile_gfxView_TileMouseMove(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (e.TilePixelPosition == GfxCursor.Rectangle.Location || gfxView.TileImage == null) return;

            GfxCursor.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, e.TileSize, e.TileSize);

            if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && GfxSelection.Visible)
            {
                GfxCursor.Visible = false;

                Size SelectionSize = new Size(
                    Math.Abs(e.TilePixelPosition.X - GfxSelectionPivot.X) + e.TileSize,
                    Math.Abs(e.TilePixelPosition.Y - GfxSelectionPivot.Y) + e.TileSize
                );
                Point SelectionPosition = new Point(
                    Math.Min(e.TilePixelPosition.X, GfxSelectionPivot.X),
                    Math.Min(e.TilePixelPosition.Y, GfxSelectionPivot.Y)
                );
                GfxSelection.Rectangle = new Rectangle(SelectionPosition, SelectionSize);

                return;
            }

            GfxCursor.Visible = true;
        }

        private void tile_gfxView_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
        {
            if (gfxView.TileImage == null) return;

            GfxCursor.Visible = true;
        }

        private void gfxView_Scrolled(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0) updateGfxZoom(gfxView.Zoom + 1);
                if (e.Delta < 0) updateGfxZoom(gfxView.Zoom - 1);
            }
        }
        #endregion

        #region Table Display
        // ZOOM
        private void button_tableZoomIn_Click(object sender, EventArgs e) => updateTableZoom(tableView.Zoom + 1);

        private void button_tableZoomOut_Click(object sender, EventArgs e) => updateTableZoom(tableView.Zoom - 1);

        private void updateTableZoom(int value)
        {
            tableView.Zoom = Math.Clamp(value, 0, maxZoom);
            button_tableZoomIn.Enabled = tableView.Zoom < maxZoom;
            button_tableZoomOut.Enabled = tableView.Zoom > 0;
            label_tableZoom.Text = $"{1 << tableView.Zoom}00%";
        }

        //MOUSE
        private void tableView_Scrolled(object sender, MouseEventArgs e)
        {
            if ((ModifierKeys & Keys.Control) == Keys.Control)
            {
                if (e.Delta > 0) updateTableZoom(tableView.Zoom + 1);
                if (e.Delta < 0) updateTableZoom(tableView.Zoom - 1);
            }
        }
        #endregion
        #endregion
    }
}
