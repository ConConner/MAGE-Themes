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
using mage.Dialogs;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using mage.Bookmarks;

namespace mage.Editors
{
    public partial class FormTileTableNew : Form, Editor
    {
        #region Tab Enum
        private enum Tab
        {
            Tileset,
            Background,
            Offset
        }
        #endregion

        #region Fields
        private bool init = false;

        Pen CursorPen = new Pen(Color.Red, 1);
        Pen GridPen = new Pen(Color.Gray, 1);
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
                button_setPalette.Enabled = value;
            }
        }

        private Room? openedInRoom;
        private Status Status;

        // Tooltip
        Point TableTileNumPosition;
        Timer TableTimer;
        TileTableTooltip TileTip = new TileTableTooltip()
        {
            AutoPopDelay = 0
        };

        // Current loaded TileTable related Data
        private Tab selectedTab
        {
            get
            {
                if (tab_select.SelectedIndex == 0) return Tab.Tileset;
                if (tab_select.SelectedIndex == 1) return Tab.Background;
                return Tab.Offset;
            }
        }
        private ushort[] tileTable;
        private int ttbOffset;
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

        // Old values
        private int oldSelectedTab;
        private int oldSelectedTileset;
        private int oldSelectedArea;
        private int oldSelectedRoom;
        private int oldSelectedBG;
        private int oldSelectedSize;
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
            tableView.GridPen = GridPen;
            updateTableZoom(0);

            // Tooltip
            TableTimer = new();
            TableTimer.Interval = 700;
            TableTimer.Tick += TableTimer_Tick;

            // Status
            Status = new Status(statusLabel_changes, button_apply);

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
        private int GetIndexFromLocation(int x, int y)
        {
            switch (selectedTab)
            {
                case Tab.Tileset:
                    {
                        int canvasWidth = 16;
                        int xx = x / 2;
                        int yy = y / 2;
                        int tile = (yy * canvasWidth + xx) * 4;
                        int align = (y % 2 * 2) + (x % 2);
                        return (tile + align);
                    }

                case Tab.Background:
                    {
                        int onRightPage = x / 32;
                        int tile = (y + onRightPage * 31) * 32 + x;
                        return tile;
                    }

                case Tab.Offset:
                    {
                        return y * 32 + x;
                    }
            }
            return -1;
        }

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
                    int index = GetIndexFromLocation(TableSelection.X / 8 + x, TableSelection.Y / 8 + y);
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

                    int index = GetIndexFromLocation(location.X + x, location.Y + y);
                    ushort tile = selectedTiles[x, y];
                    if (!CopyPalette) tile = (ushort)(tile & 0xFFF | tileTable[index] & 0xF000);

                    tileTable[index] = tile;
                }

            DrawTileTable((Bitmap)tableView.TileImage);
            Status.ChangeMade();
        }

        private void TransformSelection(Func<ushort, ushort> transformation)
        {
            if (!TableSelectionVisible) return;

            int xPos = TableSelection.X / 8;
            int yPos = TableSelection.Y / 8;

            for (int x = 0; x < selectedTilesSize.Width; x++)
                for (int y = 0; y < selectedTilesSize.Height; y++)
                {
                    int index = GetIndexFromLocation(xPos + x, yPos + y);
                    ushort tile = tileTable[index];
                    ushort newTile = transformation(tile);
                    tileTable[index] = newTile;
                }

            DrawTileTable((Bitmap)tableView.TileImage);
            TableSelection.InvalidateDrawable(TableSelection);
            Status.ChangeMade();
        }

        private bool PreserveExistingData(int offset)
        {
            offset = ROM.Stream.ReadPtr(offset); // Not sure why but mage does this

            List<int> pointers = ROM.Stream.GetPointers(offset);
            if (pointers.Count <= 1) return false;

            if (MessageBox.Show(
                $"This Tile Table is referenced {pointers.Count} times.\n" +
                $"Do you want to change all references?",
                "Preserve existing data",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            ) != DialogResult.Yes) return true;
            return false;
        }

        private void Save()
        {
            if (oldSelectedTab == (int)Tab.Tileset)
            {
                int ptr = Version.TilesetOffset + oldSelectedTileset * 0x14 + 0xC;
                bool shared = !PreserveExistingData(ptr);

                // tileset
                ByteStream dataToWrite = new ByteStream();
                dataToWrite.Write8(2);
                dataToWrite.Write8((byte)(numOfTiles / 64));

                for (int i = 0; i < numOfTiles; i++)
                {
                    ushort tile = tileTable[i];
                    dataToWrite.Write16(tile);
                }

                ROM.Stream.Write(dataToWrite, origLen * 2 + 2, ptr, shared);
            }
            else if (oldSelectedTab == (int)Tab.Background)
            {
                // background
                int length = tileTable.Length * 2;
                byte[] uncompTemp = new byte[length];
                Buffer.BlockCopy(tileTable, 0, uncompTemp, 0, length);
                ByteStream uncompData = new ByteStream(uncompTemp);

                // compress by LZ77
                ByteStream compData = new ByteStream();
                compData.Write32(oldSelectedSize);
                int newCompLen = Compress.CompLZ77(uncompData, length, compData);

                // get pointer
                int area = oldSelectedArea;
                int room = oldSelectedRoom;
                int bg = oldSelectedBG;
                int ptr = ROM.Stream.ReadPtr(Version.AreaHeaderOffset + area * 4) + (room * 0x3C);
                if (bg == 0)
                {
                    ptr += 8;
                }
                else
                {
                    ptr += 0x18;
                }

                // write data
                bool shared = !PreserveExistingData(ptr);
                ROM.Stream.Write(compData, origLen, ptr, shared);
            }
            else if (oldSelectedTab == (int)Tab.Offset)
            {
                // offset
                int length = tileTable.Length * 2;
                byte[] uncompTemp = new byte[length];
                Buffer.BlockCopy(tileTable, 0, uncompTemp, 0, length);
                ByteStream uncompData = new ByteStream(uncompTemp);

                // compress by LZ77
                ByteStream compData = new ByteStream();
                int newCompLen = Compress.CompLZ77(uncompData, length, compData);

                // write data
                int prevOffset = ttbOffset;
                ROM.Stream.Write2(compData, origLen, ref ttbOffset, true);
                textBox_ttb.Text = Hex.ToString(ttbOffset);

                if (prevOffset != ttbOffset)
                {
                    if (
                        MessageBox.Show(
                            "Tile table needs to be repointed.\n\nDo you want to save the new location as a Bookmark?",
                            "Repointing required", MessageBoxButtons.YesNo, MessageBoxIcon.Information
                        )
                        != DialogResult.Yes
                        || !BookmarkManager.RepointedDataCreateBookmark(prevOffset, ttbOffset)
                    )
                    {
                        string message = "Tile table was repointed to " + Hex.ToString(ttbOffset);
                        MessageBox.Show(message, "Repointed Tile Table", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            FormMain.UpdateEditors();
            Status.Save();
        }

        /// <summary>
        /// Prompts the user if they want to save the current changes or cancel.
        /// </summary>
        /// <returns>False if cancelled. True for other options. Saves if yes is clicked</returns>
        private bool CheckUnsaved()
        {
            DialogResult result = MessageBox.Show("Do you want to save changes to Tile Table?",
                "Unsaved Changes", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Cancel) return false;
            if (result == DialogResult.Yes) Save();
            return true;
        }

        /// <summary>
        /// Checks if a value changed for the background input and asks if the user wants to save changes
        /// </summary>
        /// <returns>True if the user wants to cancel the switch or values didnt change</returns>
        private bool CheckUnsavedForBackgrounds()
        {
            if (oldSelectedArea == comboBox_area.SelectedIndex && oldSelectedRoom == comboBox_room.SelectedIndex && oldSelectedBG == comboBox_bg.SelectedIndex)
                return true;
            if (Status.UnsavedChanges && !CheckUnsaved())
            {
                comboBox_area.SelectedIndex = oldSelectedArea;
                comboBox_room.SelectedIndex = oldSelectedRoom;
                comboBox_bg.SelectedIndex = oldSelectedBG;
                return true;
            }
            return false;
        }
        #endregion

        #region Drawing and Setup Code
        /// <summary>
        /// Resets all the view stuff
        /// </summary>
        private void Reset()
        {
            Status.LoadNew();

            gfxView.TileImage = null;
            tableView.TileImage = null;
            paletteView.TileImage = null;

            init = true;

            comboBox_palette.SelectedIndex = -1;
            group_palette.Enabled = false;
            comboBox_size.SelectedIndex = -1;
            comboBox_size.Enabled = false;
            numericUpDown_height.Enabled = false;
            statusLabel_tile.Text = "Tile:";

            init = false;
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

            comboBox_area.Items.AddRange(Version.AreaNames);
        }

        private void InitializeWithTileset()
        {
            init = true;
            Status.LoadNew();

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

        private void InitializeWithBackground()
        {
            init = true;

            int room = comboBox_room.SelectedIndex;
            if (room == -1)
            {
                Reset();
                return;
            }
            int bg = comboBox_bg.SelectedIndex;
            if (bg == -1)
            {
                Reset();
                return;
            }

            // get tile table
            int area = comboBox_area.SelectedIndex;
            int offset = ROM.Stream.ReadPtr(Version.AreaHeaderOffset + area * 4) + (room * 0x3C);
            int addr;
            if (bg == 0)
            {
                byte prop = ROM.Stream.Read8(offset + 1);
                if ((prop & 0x40) == 0)
                {
                    Reset();
                    return;
                }
                addr = ROM.Stream.ReadPtr(offset + 8);
            }
            else
            {
                addr = ROM.Stream.ReadPtr(offset + 0x18);
            }

            int size = ROM.Stream.Read8(addr);
            int length = ROM.Stream.Read32(addr + 4) >> 8;
            ByteStream ttb = new ByteStream(length);
            try
            {
                ROM.Stream.Seek(addr + 4);
                origLen = Compress.DecompLZ77(ROM.Stream, ttb);
            }
            catch
            {
                Reset();
                return;
            }

            tileTable = new ushort[0x800];
            ttb.CopyToArray(0, tileTable, 0, ttb.Length);
            if (size == 0)
            {
                for (int i = 0x400; i < 0x800; i++)
                {
                    tileTable[i] = 0x3FF;
                }
            }

            // get tileset and vram
            byte tsNum = ROM.Stream.Read8(offset);
            Tileset tileset = new Tileset(ROM.Stream, tsNum);
            VramBG vram = new VramBG(tileset, false);
            gfxData = new byte[0x8000];
            Array.Copy(vram.BGtiles, 0x4000, gfxData, 0, 0x8000);
            palette = vram.BGpalette;

            // Palette
            comboBox_palette.SelectedIndex = 0;
            paletteView.TileImage = palette.Draw(16, 0, 16, 0x0);
            group_palette.Enabled = true;

            // set result image
            comboBox_size.Enabled = true;
            comboBox_size.SelectedIndex = size;
            DrawGFX();
            SetBackgroundImage();

            init = false;
        }

        private void InitializeWithOffset()
        {
            try
            {
                init = true;

                ttbOffset = Hex.ToInt(textBox_ttb.Text);
                int gfxOffset = Hex.ToInt(textBox_gfx.Text);
                int palOffset = Hex.ToInt(textBox_pal.Text);

                // gfx
                ByteStream temp = new ByteStream();
                ROM.Stream.Seek(gfxOffset);
                Compress.DecompLZ77(ROM.Stream, temp);
                gfxData = temp.Data;

                // tile table
                temp = new ByteStream();
                ROM.Stream.Seek(ttbOffset);
                origLen = Compress.DecompLZ77(ROM.Stream, temp);
                numOfTiles = temp.Length / 2;
                tileTable = new ushort[numOfTiles];
                temp.CopyToArray(0, tileTable, 0, temp.Length);

                // palette
                palette = new Palette(ROM.Stream, palOffset, 16);
                comboBox_palette.SelectedIndex = 0;
                paletteView.TileImage = palette.Draw(16, 0, 16, 0x0);

                DrawGFX();
                SetTileTableImage(256, numOfTiles / 4);

                init = false;

            }
            catch
            {
                Reset();
                return;
            }

            group_palette.Enabled = true;
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

        private void SetBackgroundImage()
        {
            int size = comboBox_size.SelectedIndex;
            if (size == -1) { return; }

            int width = 256;
            int height = 256;
            numOfTiles = 0x400;
            if (size == 1)
            {
                width = 512;
                numOfTiles = 0x800;
            }
            else if (size == 2)
            {
                height = 512;
                numOfTiles = 0x800;
            }
            SetTileTableImage(width, height);
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
                        switch (comboBox_size.SelectedIndex)
                        {
                            case 0:
                            case 2:
                                x = (t % 32) * 8;
                                y = (t / 32) * 8;
                                break;
                            case 1:
                                x = (t / 0x400) * 256 + (t % 32) * 8;
                                y = ((t / 32) % 32) * 8;
                                break;
                        }
                        break;
                    case 2:
                        x = (t % 32) * 8;
                        y = (t / 32) * 8;
                        break;
                }
                imgPtr = startPtr + y * w + x;

                ushort currTile = tileTable[index++];
                int tileNum = currTile & 0x3FF;
                // check for valid tile number
                if (tab_select.SelectedIndex == 2)
                {
                    tileNum -= (int)numericUpDown_shift.Value;
                    if (tileNum < 0) { continue; }
                }
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
            if (!Status.UnsavedChanges)
            {
                switch (tab_select.SelectedIndex)
                {
                    case 0:
                        InitializeWithTileset();
                        break;
                    case 1:
                        InitializeWithBackground();
                        break;
                    case 2:
                        //InitializeWithOffset();
                        break;
                }
            }
        }

        private void button_apply_Click(object sender, EventArgs e) => Save();

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

                case Keys.W:
                case Keys.I:
                    button_paletteIncrease_Click(sender, e);
                    break;

                case Keys.S:
                case Keys.D:
                    button_paletteDecrease_Click(sender, e);
                    break;

                case Keys.G:
                    button_grid.Checked = !button_grid.Checked;
                    break;

                case Keys.P:
                    button_setPalette_Click(sender, e);
                    break;

                default:
                    break;
            }
        }

        private void comboBox_palette_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_palette.SelectedIndex == -1) return;
            // Update UI Selection
            int index = comboBox_palette.SelectedIndex;
            PaletteSelection.Rectangle = new Rectangle(0, index * 17, 16 * 16 + 17, 17);

            if (init) return;
            DrawGFX();
            if (GfxSelection.Visible) SelectTilesFromGFX();
        }

        private void button_flipH_Click(object sender, EventArgs e)
        {
            if (!TableSelectionVisible) return;

            int xPos = TableSelection.X / 8;
            int yPos = TableSelection.Y / 8;
            int width = selectedTilesSize.Width;
            int height = selectedTilesSize.Height;

            ushort[,] flippedTiles = new ushort[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    int realPosX = xPos + x;
                    int realPosY = yPos + y;
                    int index = GetIndexFromLocation(realPosX, realPosY);
                    ushort tile = tileTable[index];

                    tile = (ushort)(tile ^ 0x400); // flip x
                    flippedTiles[width - x - 1, y] = tile;
                }

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    int realPosX = xPos + x;
                    int realPosY = yPos + y;
                    int index = GetIndexFromLocation(realPosX, realPosY);
                    ushort tile = flippedTiles[x, y];
                    tileTable[index] = tile;
                }

            DrawTileTable((Bitmap)tableView.TileImage);
            TableSelection.InvalidateDrawable(TableSelection);
            Status.ChangeMade();
        }

        private void button_flipV_Click(object sender, EventArgs e)
        {
            if (!TableSelectionVisible) return;

            int xPos = TableSelection.X / 8;
            int yPos = TableSelection.Y / 8;
            int width = selectedTilesSize.Width;
            int height = selectedTilesSize.Height;

            ushort[,] flippedTiles = new ushort[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    int realPosX = xPos + x;
                    int realPosY = yPos + y;
                    int index = GetIndexFromLocation(realPosX, realPosY);
                    ushort tile = tileTable[index];

                    tile = (ushort)(tile ^ 0x800); // flip y
                    flippedTiles[x, height - y - 1] = tile;
                }

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                {
                    int realPosX = xPos + x;
                    int realPosY = yPos + y;
                    int index = GetIndexFromLocation(realPosX, realPosY);
                    ushort tile = flippedTiles[x, y];
                    tileTable[index] = tile;
                }

            DrawTileTable((Bitmap)tableView.TileImage);
            TableSelection.InvalidateDrawable(TableSelection);
            Status.ChangeMade();
        }

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

        private void button_setPalette_Click(object sender, EventArgs e)
        {
            if (!TableSelectionVisible) return;

            PaletteDialog dialog = new PaletteDialog(palette, 16);
            if (dialog.ShowDialog() != DialogResult.OK) return;

            int pal = dialog.SelectedIndex;
            TransformSelection((ushort tile) => (ushort)((tile & 0x0FFF) | (pal << 12)));
        }

        private void button_grid_CheckStateChanged(object sender, EventArgs e) => tableView.ShowGrid = button_grid.Checked;

        private void FormTileTableNew_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Status.UnsavedChanges) return;
            if (!CheckUnsaved()) e.Cancel = true;
        }


        private void tab_select_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab_select.SelectedIndex == oldSelectedTab) return;
            if (Status.UnsavedChanges && !CheckUnsaved())
            {
                tab_select.SelectedIndex = oldSelectedTab;
                return;
            }

            oldSelectedTab = tab_select.SelectedIndex;
            Reset();

            if (openedInRoom == null) return;
            if (selectedTab == Tab.Tileset)
            {
                comboBox_tileset.SelectedIndex = openedInRoom.tileset.number;
                InitializeWithTileset();
            }
            if (selectedTab == Tab.Background)
            {
                comboBox_area.SelectedIndex = openedInRoom.AreaID;
                comboBox_room.SelectedIndex = openedInRoom.RoomID;
                comboBox_bg.SelectedIndex = 1;
                InitializeWithBackground();
            }
        }

        #region Tileset Tab
        private void comboBox_tileset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_tileset.SelectedIndex == oldSelectedTileset) return;
            if (Status.UnsavedChanges && !CheckUnsaved())
            {
                comboBox_tileset.SelectedIndex = oldSelectedTileset;
                return;
            }

            oldSelectedTileset = comboBox_tileset.SelectedIndex;

            InitializeWithTileset();
        }

        private void numericUpDown_height_ValueChanged(object sender, EventArgs e)
        {
            if (init) return;
            numOfTiles = (int)numericUpDown_height.Value * 64;
            SetTileTableImage(256, numOfTiles / 4);
            Status.ChangeMade();
        }
        #endregion

        #region Background Tab
        private void comboBox_area_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CheckUnsavedForBackgrounds()) return;
            oldSelectedArea = comboBox_area.SelectedIndex;

            init = true;

            int area = comboBox_area.SelectedIndex;
            int numOfRooms = Version.RoomsPerArea[area];
            int currNum = comboBox_room.Items.Count;

            if (numOfRooms > currNum)
                for (int i = currNum; i < numOfRooms; i++) comboBox_room.Items.Add(Hex.ToString(i));

            else if (numOfRooms < currNum)
                for (int i = currNum - 1; i >= numOfRooms; i--) comboBox_room.Items.RemoveAt(i);

            comboBox_room.SelectedIndex = 0;
            InitializeWithBackground();
            Status.LoadNew();
        }

        private void RoomOrBackgroundChanged(object sender, EventArgs e)
        {
            if (init) return;
            if (CheckUnsavedForBackgrounds()) return;
            oldSelectedRoom = comboBox_room.SelectedIndex;
            oldSelectedBG = comboBox_bg.SelectedIndex;

            InitializeWithBackground();
            Status.LoadNew();
        }

        private void comboBox_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (init) return;
            oldSelectedSize = comboBox_size.SelectedIndex;
            SetBackgroundImage();
            Status.ChangeMade();
        }
        #endregion

        #region Offset Tab
        private void button_go_Click(object sender, EventArgs e)
        {
            if (Status.UnsavedChanges && !CheckUnsaved()) return;

            InitializeWithOffset();
            Status.LoadNew();
        }
        #endregion


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
            statusLabel_tile.Text = $"Tile: {Hex.ToString(e.TileIndexPosition.Y * 32 + e.TileIndexPosition.X)}";

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

            ResetToolTips();

            if (tableView.TileImage != null)
            {
                TileTip.TileGFX = tableView.TileImage;
                TileTip.TileVal = tileTable[GetIndexFromLocation(e.TileIndexPosition.X, e.TileIndexPosition.Y)];
                TileTip.PositionOnImage = e.TilePixelPosition;
            }

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


        #region ToolTips
        private void ResetToolTips()
        {
            TableTimer.Stop();
            TileTip.RemoveAll();
            TableTimer.Start();
        }

        private void panel_tableView_MouseLeave(object sender, EventArgs e) => ResetToolTips();

        private void TableTimer_Tick(object? sender, EventArgs e)
        {
            TableTimer.Stop();
            if (tableView == null || tableView.IsDisposed) return;
            Point clientMousePos = tableView.PointToClient(Cursor.Position);
            if (!tableView.ClientRectangle.Contains(clientMousePos) || Control.MouseButtons != MouseButtons.None) return;

            TileTip.Show("Dummy", tableView, clientMousePos);
        }
        #endregion

        #region Import/Export
        private void statusButton_import_Click(object sender, EventArgs e)
        {
            if (tableView.TileImage == null) return;

            OpenFileDialog openRaw = new OpenFileDialog();
            openRaw.Filter = "All files (*.*)|*.*";
            if (openRaw.ShowDialog() != DialogResult.OK) return;

            try
            {
                byte[] temp = System.IO.File.ReadAllBytes(openRaw.FileName);
                numOfTiles = temp.Length / 2;
                Array.Resize(ref tileTable, numOfTiles);
                Buffer.BlockCopy(temp, 0, tileTable, 0, temp.Length);
                Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Status.ChangeMade();
            Status.Save();
        }

        private void statusButton_export_Click(object sender, EventArgs e)
        {
            if (tableView.TileImage == null) return;

            SaveFileDialog saveRaw = new SaveFileDialog();
            saveRaw.Filter = "All files (*.*)|*.*";
            if (saveRaw.ShowDialog() != DialogResult.OK) return;

            ByteStream output = new ByteStream();
            for (int i = 0; i < numOfTiles; i++) output.Write16(tileTable[i]);

            output.Export(saveRaw.FileName);
        }
        #endregion
        #endregion


    }
}
