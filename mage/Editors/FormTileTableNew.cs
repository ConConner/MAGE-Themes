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
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace mage.Editors
{
    public partial class FormTileTableNew : Form, Editor
    {
        #region Fields
        private bool init = false;

        Pen CursorPen = new Pen(Color.Red, 1);
        Pen SelectionPenWhite = new Pen(Color.White, 1) { DashPattern = new float[] { 2, 3 } };
        Pen SelectionPenBlack = new Pen(Color.Black, 1) { DashPattern = new float[] { 2, 3 }, DashOffset = 2 };

        // UI Preferences
        private bool showPalette = false;
        private bool ShowPalette
        {
            get => showPalette;
            set
            {
                if (showPalette == value) return;

                showPalette = value;
                paletteView.Visible = showPalette;
                checkBox_showPalette.Checked = showPalette;
                panel_gfxAndPal.SplitterDistance = showPalette ? 339 : 60;
                Program.Config.TileTableEditorShowPalettePreview = showPalette;
            }
        }
        private bool copyPalette = true;
        private bool CopyPalette
        {
            get => copyPalette;
            set
            {
                if (value == copyPalette) return;
                copyPalette = value;
                checkBox_copyPalette.Checked = copyPalette;
                Program.Config.TileTableEditorCopyPalette = copyPalette;
            }
        }

        // Drawables for UI
        private Drawable PaletteCursor;
        private Drawable PaletteSelection;

        private Drawable GfxCursor;
        private Drawable GfxSelection;
        private Point GfxSelectionPivot;

        private Drawable TableCursor;
        private Drawable TableSelection;
        private Point TableSelectionPivot;
        private bool TableSelectionVisible
        {
            get => TableSelection.Visible;
            set
            {
                TableSelection.Visible = value;

                // Activate/deactivate buttons
                button_flipH.Enabled = value;
                button_flipV.Enabled = value;
                button_paletteDecrease.Enabled = value;
                button_paletteIncrease.Enabled = value;
            }
        }

        private Room? openedInRoom;

        // Current loaded TileTable related Data
        private ushort[] tileTable;
        private int numOfTiles;
        private int origLen;
        private byte[] gfxData;
        Palette palette;

        private ushort[,] selectedTiles;
        private Size selectedTilesSize
        {
            get
            {
                if (selectedTiles == null) return new Size(0, 0);
                return new Size(selectedTiles.GetLength(0), selectedTiles.GetLength(1));
            }
        }
        #endregion

        public FormTileTableNew()
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            //Editor Config
            ShowPalette = Program.Config.TileTableEditorShowPalettePreview;
            CopyPalette = Program.Config.TileTableEditorCopyPalette;

            // Palette View
            PaletteCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = true };
            PaletteSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = true };
            PaletteSelection.DrawPens.Add(SelectionPenBlack);
            paletteView.AddDrawable(PaletteCursor);
            paletteView.AddDrawable(PaletteSelection);

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

        #region Helpers
        /// <summary>
        /// Gets the index for a single tile from the tile x and y position on a metatile canvas.
        /// </summary>
        /// <param name="canvasWidth">Width of the metatile canvas. Width in metatiles</param>
        private int GetIndexFromLocation(int x, int y, int canvasWidth)
        {
            int xx = x / 2;
            int yy = y / 2;
            int tile = (yy * canvasWidth + xx) * 4;
            int align = (y % 2 * 2) + (x % 2);
            return (tile + align);
        }

        /// <summary>
        /// Gets the index for a single tile from the tile x and y position on a metatile canvas.
        /// </summary>
        /// <param name="canvasWidth">Width of the metatile canvas. Width in metatiles</param>
        private int GetIndexFromLocation(Point location, int canvasWidth) => GetIndexFromLocation(location.X, location.Y, canvasWidth);

        private void SelectTilesFromGFX()
        {
            // Get all selected tiles
            int width = GfxSelection.Width / 8;
            int height = GfxSelection.Height / 8;
            selectedTiles = new ushort[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    // Get number for current tile
                    int gfxNum = (GfxSelection.X / 8 + x) + ((GfxSelection.Y / 8 + y) * 32);
                    //Apply current palette
                    if (CopyPalette) gfxNum |= (comboBox_palette.SelectedIndex << 12);
                    selectedTiles[x, y] = (ushort)gfxNum;
                }
        }

        private void SelectTilesFromTable()
        {
            // Get all selected tiles
            int width = TableSelection.Width / 8;
            int height = TableSelection.Height / 8;
            selectedTiles = new ushort[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    int index = GetIndexFromLocation(TableSelection.X / 8 + x, TableSelection.Y / 8 + y, tableView.TileImage.Width / 16);
                    selectedTiles[x, y] = tileTable[index];
                }
        }

        private ushort CreateTile(int index, ushort gfxNum, Byte? pal = null)
        {
            ushort old = tileTable[index];

            return (ushort)(
                (pal != null ? pal << 12 : old & 0xF000) |
                (old & 0xC00) |
                gfxNum
            );
        }

        private void PlaceTiles(Point location)
        {
            if (selectedTiles == null) return;

            int canvasWidth = tableView.TileImage.Width / 8;
            int canvasHeight = tableView.TileImage.Height / 8;

            for (int x = 0; x < selectedTilesSize.Width; x++)
                for (int y = 0; y < selectedTilesSize.Height; y++)
                {
                    if (location.X + x >= canvasWidth || location.Y + y >= canvasHeight || location.X + x < 0 || location.Y + y < 0) continue;

                    int index = GetIndexFromLocation(location.X + x, location.Y + y, tableView.TileImage.Width / 16);
                    ushort tile = selectedTiles[x, y];
                    if (!CopyPalette) tile = (ushort)(tile & 0xFFF | tileTable[index] & 0xF000);

                    tileTable[index] = tile;
                }

            DrawTileTable((Bitmap)tableView.TileImage);
        }

        private void TransformSelection(Func<ushort, ushort> transformation)
        {
            if (!TableSelectionVisible) return;

            int xPos = TableSelection.X / 8;
            int yPos = TableSelection.Y / 8;

            for (int x = 0; x < selectedTilesSize.Width; x++)
                for (int y = 0; y < selectedTilesSize.Height; y++)
                {
                    int index = GetIndexFromLocation(xPos + x, yPos + y, tableView.TileImage.Width / 16);
                    ushort tile = tileTable[index];
                    ushort newTile = transformation(tile);
                    tileTable[index] = newTile;
                }

            DrawTileTable((Bitmap)tableView.TileImage);
            TableSelection.InvalidateDrawable(TableSelection);
        }
        #endregion

        #region Drawing and Setup Code
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
            paletteView.TileImage = palette.Draw(16, 0, 16, 0x0);
            group_palette.Enabled = true;

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
        public void UpdateEditor()
        {
            throw new NotImplementedException();
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.H:
                case Keys.X:
                    button_flipH_Click(sender, e);
                    break;

                case Keys.V:
                case Keys.Y:
                    button_flipV_Click(sender, e);
                    break;

                default:
                    break;
            }
        }

        private void comboBox_tileset_SelectedIndexChanged(object sender, EventArgs e) => InitializeWithTileset();

        private void comboBox_palette_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Update UI Selection
            int index = comboBox_palette.SelectedIndex;
            PaletteSelection.Rectangle = new Rectangle(0, index * 17, 16 * 16 + 17, 17);

            if (init) return;
            DrawGFX();
            if (GfxSelection.Visible) SelectTilesFromGFX();
        }

        private void button_flipH_Click(object sender, EventArgs e)
            => TransformSelection((ushort tile) => (ushort)(tile ^ 0x400));

        private void button_flipV_Click(object sender, EventArgs e)
            => TransformSelection((ushort tile) => (ushort)(tile ^ 0x800));

        private void button_paletteIncrease_Click(object sender, EventArgs e)
            => TransformSelection((ushort tile) =>
            {
                int palette = tile >> 12;
                palette = (palette + 1) % 16;
                tile = (ushort)((tile & 0x0FFF) | (palette << 12));
                return tile;
            });

        private void button_paletteDecrease_Click(object sender, EventArgs e)
            => TransformSelection((ushort tile) =>
            {
                int palette = tile >> 12;
                palette = (palette + 16 - 1) % 16;
                tile = (ushort)((tile & 0x0FFF) | (palette << 12));
                return tile;
            });
        #region Palette Display
        private void checkBox_showPalette_CheckedChanged(object sender, EventArgs e) => ShowPalette = checkBox_showPalette.Checked;
        private void checkBox_copyPalette_CheckedChanged(object sender, EventArgs e) => CopyPalette = checkBox_copyPalette.Checked;

        // MOUSE
        private void paletteView_TileMouseMove(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (PaletteCursor.Y == e.TilePixelPosition.Y) return;
            PaletteCursor.Visible = true;
            PaletteCursor.Rectangle = new Rectangle(0, Math.Min(e.TilePixelPosition.Y, 17 * 15), 16 * 16 + 17, 17);
        }

        private void paletteView_TileMouseDown(object sender, TileDisplay.TileDisplayArgs e)
        {
            PaletteCursor.Visible = false;
            comboBox_palette.SelectedIndex = e.TilePixelPosition.Y / 17;
        }
        #endregion

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
            if (e.X < 0 || e.Y < 0 || e.X >= gfxView.Width || e.Y >= gfxView.Height) return;

            GfxCursor.Visible = false;
            TableSelectionVisible = false;

            GfxSelection.Visible = true;
            GfxSelection.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, e.TileSize, e.TileSize);
            GfxSelectionPivot = GfxSelection.Location;
        }

        private void tile_gfxView_TileMouseMove(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (e.TilePixelPosition == GfxCursor.Rectangle.Location || gfxView.TileImage == null) return;
            if (e.X < 0 || e.Y < 0 || e.X >= gfxView.Width || e.Y >= gfxView.Height) return;

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

        private void tile_gfxView_TileMouseUp(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (gfxView.TileImage == null) return;

            GfxCursor.Visible = true;

            SelectTilesFromGFX();
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
        //ZOOM
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
        private void tableView_TileMouseDown(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (tableView.TileImage == null || !TableCursor.Visible) return;
            if (e.X < 0 || e.Y < 0 || e.X >= tableView.Width || e.Y >= tableView.Height) return;

            if (e.Button == MouseButtons.Left)
            {
                PlaceTiles(e.TileIndexPosition);
                TableCursor.InvalidateDrawable(TableCursor);
                return;
            }
            if (e.Button == MouseButtons.Right)
            {
                TableCursor.Visible = false;
                GfxSelection.Visible = false;

                TableSelectionVisible = true;
                TableSelection.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, e.TileSize, e.TileSize);
                TableSelectionPivot = TableSelection.Location;
                return;
            }
        }

        private void tableView_TileMouseMove(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (e.TilePixelPosition == TableCursor.Rectangle.Location || tableView.TileImage == null) return;
            if (e.X < 0 || e.Y < 0 || e.X >= tableView.Width || e.Y >= tableView.Height) return;

            TableCursor.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, selectedTilesSize.Width * e.TileSize, selectedTilesSize.Height * e.TileSize);

            if (e.Button == MouseButtons.Left) PlaceTiles(e.TileIndexPosition);
            else if (e.Button == MouseButtons.Right)
            {
                TableCursor.Visible = false;

                Size SelectionSize = new Size(
                    Math.Abs(e.TilePixelPosition.X - TableSelectionPivot.X) + e.TileSize,
                    Math.Abs(e.TilePixelPosition.Y - TableSelectionPivot.Y) + e.TileSize
                );
                Point SelectionPosition = new Point(
                    Math.Min(e.TilePixelPosition.X, TableSelectionPivot.X),
                    Math.Min(e.TilePixelPosition.Y, TableSelectionPivot.Y)
                );
                TableSelection.Rectangle = new Rectangle(SelectionPosition, SelectionSize);

                return;
            }

            TableCursor.Visible = true;
        }

        private void tableView_TileMouseUp(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (tableView.TileImage == null) return;

            TableCursor.Visible = true;

            if (TableSelectionVisible)
            {
                SelectTilesFromTable();
                TableCursor.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, selectedTilesSize.Width * e.TileSize, selectedTilesSize.Height * e.TileSize);
            }
        }

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
