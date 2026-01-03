using mage.Dialogs;
using mage.Theming;
using mage.Theming.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using mage.Controls;
using System.Drawing.Drawing2D;

namespace mage.Editors.NewEditors;

public partial class FormMinimapNew : Form, Editor
{
    private struct MapTile
    {
        public MapTile(ushort value)
        {
            TileID = value & 0x3FF;
            xFlip = ((value >> 10) & 0b1) == 1;
            yFlip = ((value >> 11) & 0b1) == 1;
            Palette = value >> 12;
        }
        public MapTile() { }

        public int TileID { get; set; } = 0;
        public bool xFlip { get; set; } = false;
        public bool yFlip { get; set; } = false;
        public int Palette { get; set; } = 0;

        public int Flip => (xFlip ? 1 : 0) | (yFlip ? 2 : 0);

        public static implicit operator ushort(MapTile t) => (ushort)(t.TileID | (t.xFlip ? 0x400 : 0) | (t.yFlip ? 0x800 : 0) | t.Palette << 12);
        public static implicit operator MapTile(ushort v) => new(v);
    }

    // Shortcuts
    private string[] tileTypeItems => Version.IsMF ?
        new[] { "Unexplored (Visual)", "Normal", "Hidden" } :
        new[] { "Start", "Normal", "Heated", "Hidden", "Heated (hidden)" };
    private string[] mapStateItems => Version.IsMF ?
        new[] { "Explored", "Downloaded" } :
        new[] { "Explored", "Downloaded", "Start" };
    private int numOfPalettes => Version.IsMF ? 3 : 5;
    private int tilesBorderSize => 1;

    #region Properties
    private bool TilesFlippedH
    {
        get => tilesFlippedH;
        set
        {
            if (value == tilesFlippedH) return;
            tilesFlippedH = value;

            button_flipTilesH.Checked = value;
            DrawTiles(TilesFlippedH, TilesFlippedV);
            SelectFromTiles();
        }
    }
    private bool tilesFlippedH = false;
    private bool TilesFlippedV
    {
        get => tilesFlippedV;
        set
        {
            if (value == tilesFlippedV) return;
            tilesFlippedV = value;

            button_flipTilesV.Checked = value;
            DrawTiles(TilesFlippedH, TilesFlippedV);
            SelectFromTiles();
        }
    }
    private bool tilesFlippedV = false;

    private int SelectedArea
    {
        get => selectedArea;
        set
        {
            if (selectedArea == value) return;
            if (status.UnsavedChanges && !CheckUnsaved())
            {
                comboBox_area.SelectedIndex = selectedArea;
                return;
            }

            selectedArea = value;
            roomListReloadRequired = true;
            if (ViewRoomOutlines) LoadRooms((byte)value);
            LoadMap();
        }
    }
    private int selectedArea = -1;

    private Size selectedTilesSize
    {
        get
        {
            if (selectedTiles == null) return new Size(0, 0);
            return new Size(selectedTiles.GetLength(0), selectedTiles.GetLength(1));
        }
    }
    private MapTile[,] selectedTiles;

    private bool ViewRoomOutlines
    {
        get => viewRoomOutlines;
        set
        {
            viewRoomOutlines = value;
            button_viewRooms.Checked = value;
            Program.Config.MapEditorViewRoomOutlines = value;

            LoadRooms((byte)SelectedArea);
            foreach (Drawable d in roomOutlines) d.Visible = value;
            tileDisplay_map.Invalidate();
        }
    }
    private bool viewRoomOutlines = false;
    #endregion

    #region Fields
    Pen CursorPen = new Pen(Color.Red, 1);
    Pen GridPen = new Pen(Color.Gray, 1);
    Pen SelectionPenWhite = new Pen(Color.White, 1) { DashPattern = new float[] { 2, 3 } };
    Pen SelectionPenBlack = new Pen(Color.Black, 1) { DashPattern = new float[] { 2, 3 }, DashOffset = 2 };
    Pen RoomOutlinePenLight = new Pen(Color.HotPink, 1) { DashPattern = new float[] { 2, 2 }, Alignment = PenAlignment.Inset };
    Pen RoomOutlinePenDark = new Pen(Color.Red, 1) { DashPattern = new float[] { 2, 2 }, DashOffset = 1, Alignment = PenAlignment.Inset };

    private bool init = false;
    private const int maxZoom = 4;

    private FlatComboBox comboBox_tilesType;
    private FlatComboBox comboBox_mapType;

    private Minimap LoadedMap;
    private Palette palette;
    private int numTiles;
    private Status status;

    private FormMain main;
    private ByteStream romStream;

    private bool roomListReloadRequired = true;
    private List<Room?> Rooms = new();
    private List<Room> roomJumpList = new();
    private int lastJumpIndex = -1;
    private List<Drawable> roomOutlines = new();

    // Drawables for UI
    private Drawable TileCursor;
    private Drawable TileSelection;
    private Point TileSelectionPivot;

    private Drawable MapCursor;
    private Drawable MapSelection;
    private Point MapSelectionPivot;
    private bool MapSelectionVisible
    {
        get => MapSelection.Visible;
        set
        {
            MapSelection.Visible = value;

            // Activate/deactivate buttons
            button_flipMapH.Enabled = value;
            button_flipMapV.Enabled = value;
            comboBox_mapType.Enabled = value;
        }
    }
    #endregion


    public FormMinimapNew(FormMain main)
    {
        InitializeComponent();

        splitContainer_main.SplitterDistance = 386; // Theres a WinForms Designer bug that resizes this splitter after every build

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;
        this.romStream = ROM.Stream;
        status = new Status(statusLabel_changes, button_apply);

        //Tile Display Setup
        SetupDrawables();
        UpdateMapZoom(1);
        UpdateTilesZoom(1);

        AddTypeComboboxes();
        SetValuesBasedOnGame();
        SetPalette();
        PopulateBoxesBasedOnGame();

        ViewRoomOutlines = Program.Config.MapEditorViewRoomOutlines;

        DrawTiles();
        tileDisplay_tiles.BackColor = Color.Black;
        comboBox_tilesType.SelectedIndex = 1;
    }


    public void UpdateEditor()
    {
        int paletteOffset = Version.MinimapPaletteOffset;
        palette = new Palette(romStream, paletteOffset, numOfPalettes);
        palette.SetARGB(1, 0, 0);

        DrawTiles();
        DrawMap();
        roomListReloadRequired = true;
    }

    private void Save()
    {
        ROM.SaveMinimap(LoadedMap);
        status.Save();
    }

    /// <summary>
    /// Prompts the user if they want to save the current changes or cancel.
    /// </summary>
    /// <returns>False if cancelled. True for other options. Saves if yes is clicked</returns>
    private bool CheckUnsaved()
    {
        DialogResult result = MessageBox.Show("Do you want to save changes to the Map?",
            "Unsaved Changes", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) Save();
        return true;
    }

    #region Setup
    private void SetupDrawables()
    {
        MapCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
        MapSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = false };
        MapSelection.DrawPens.Add(SelectionPenBlack);
        tileDisplay_map.AddDrawable(MapCursor);
        tileDisplay_map.AddDrawable(MapSelection);

        TileCursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
        TileSelection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = false };
        TileSelection.DrawPens.Add(SelectionPenBlack);
        tileDisplay_tiles.AddDrawable(TileCursor);
        tileDisplay_tiles.AddDrawable(TileSelection);
    }

    private void AddTypeComboboxes()
    {
        // Create comboboxes
        comboBox_tilesType = new()
        {
            Width = 101,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        comboBox_tilesType.SelectedIndexChanged += ComboBox_tilesType_SelectedIndexChanged;
        ThemeSwitcher.ChangeTheme(comboBox_tilesType);

        comboBox_mapType = new()
        {
            Width = 101,
            DropDownStyle = ComboBoxStyle.DropDownList,
            Enabled = false,
        };
        comboBox_mapType.SelectedIndexChanged += ComboBox_mapType_SelectedIndexChanged;
        ThemeSwitcher.ChangeTheme(comboBox_mapType);

        // Add to toolStrips
        var tilesHost = new ToolStripControlHost(comboBox_tilesType);
        toolStrip_tiles.Items.Insert(0, tilesHost);
        var mapHost = new ToolStripControlHost(comboBox_mapType);
        toolStrip_map.Items.Insert(0, mapHost);
    }

    private void SetValuesBasedOnGame()
    {
        numTiles = 0x200;
        if (Version.IsMF)
        {
            Patch mfP = new Patch(Properties.Resources.MF_U_addMinimapTiles);
            if (!mfP.IsApplied()) numTiles = 0x1C0;
            return;
        }

        Patch zmP = new Patch(Properties.Resources.ZM_U_addMinimapTiles);
        if (!zmP.IsApplied()) numTiles = 0x180;
    }

    private void PopulateBoxesBasedOnGame()
    {
        // State
        comboBox_state.Items.AddRange(mapStateItems);

        // Tiles Type
        comboBox_tilesType.Items.AddRange(tileTypeItems);
        comboBox_tilesType.SelectedIndex = Version.IsMF ? 0 : 1;

        comboBox_mapType.Items.AddRange(tileTypeItems);
        comboBox_mapType.SelectedIndex = -1;

        // Areas
        comboBox_area.Items.AddRange(Version.AreaNames);
        int numberOfMinimaps = Version.NumOfMinimaps;
        int currNum = comboBox_area.Items.Count;
        for (int i = currNum; i < numberOfMinimaps; i++)
        {
            comboBox_area.Items.Add($"Extra {Hex.ToString(i - currNum + 1)}");
        }
        comboBox_area.SelectedIndex = main.Room.AreaID;
    }

    private void SetPalette()
    {
        int palOffset = Version.MinimapPaletteOffset;
        palette = new Palette(romStream, palOffset, numOfPalettes);
    }
    #endregion

    #region Tiles
    private unsafe void DrawTiles(bool xFlip = false, bool yFlip = false)
    {
        // get minimap gfx data
        byte[] data = new byte[numTiles * 32];
        romStream.CopyToArray(Version.MinimapGfxOffset, data, 0, data.Length);

        // create bitmap
        const int tilesWide = 32;
        int height = numTiles / tilesWide;
        Bitmap tileImage = new Bitmap(tilesWide * 10 + 2, height * 10 + 2, PixelFormat.Format4bppIndexed);

        int palRow = comboBox_tilesType.SelectedIndex + (Version.IsMF ? 1 : 0);
        palette.SetBitmapPalette(tileImage, palRow, 1);
        ColorPalette cp = tileImage.Palette;
        cp.Entries[0] = Color.Transparent;
        tileImage.Palette = cp;

        Rectangle rect = new Rectangle(0, 0, tileImage.Width, tileImage.Height);
        BitmapData imgData = tileImage.LockBits(rect, ImageLockMode.WriteOnly, tileImage.PixelFormat);


        // Function to get the pointer to a specific pixel pair on a map tile
        byte* getPointerForPixelPair(int tileX, int tileY, int row, int pixelpair, bool flipH = false, bool flipV = false, int gap = 1)
        {
            //Gap is always *2
            int width = imgData.Stride;
            byte* basePtr = (byte*)imgData.Scan0 + width * (gap * 2) + gap;

            int actualR = flipV ? (7 - row) : row;
            int actualPP = flipH ? (3 - pixelpair) : pixelpair;

            return basePtr + (tileY * width * (8 + 2 * gap)) + (tileX * (4 + gap)) + (actualR * width) + actualPP;
        }


        for (int y = 0; y < height; y++) // For each row of tiles
        {
            for (int x = 0; x < tilesWide; x++) // For each column in the row
            {
                for (int r = 0; r < 8; r++) // For each pixel row in the tile
                {
                    for (int pp = 0; pp < 4; pp++) // For each pair of pixels in the row (4bpp = 2 pixels per byte)
                    {
                        // Data for current tile
                        int index = (y * 32 + x) * 32 + r * 4 + pp;
                        byte val = data[index];

                        byte* pixelPtr = getPointerForPixelPair(x, y, r, pp, xFlip, yFlip, gap: 1);

                        if (xFlip) *pixelPtr = val;
                        else *pixelPtr = (byte)(((val & 0xF) << 4) | (val >> 4));
                    }
                }
            }
        }

        tileImage.UnlockBits(imgData);
        tileDisplay_tiles.TileImage = tileImage;
    }

    private void ComboBox_tilesType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        Bitmap img = (Bitmap)tileDisplay_tiles.TileImage;
        if (img == null) return;

        palette.SetBitmapPalette(img, comboBox_tilesType.SelectedIndex, 1);
        ColorPalette cp = img.Palette;
        cp.Entries[0] = Color.Transparent;
        img.Palette = cp;
        tileDisplay_tiles.Invalidate();

        SelectFromTiles();
    }

    private void button_flipTilesH_Click(object sender, EventArgs e) => TilesFlippedH = !TilesFlippedH;
    private void button_flipTilesV_Click(object sender, EventArgs e) => TilesFlippedV = !TilesFlippedV;

    private void SelectFromTiles()
    {
        if (!TileSelection.Visible) return;

        int tS = tileDisplay_tiles.TileSize;
        int width = TileSelection.Width / tS;
        int height = TileSelection.Height / tS;
        selectedTiles = new MapTile[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int tileNum = (TileSelection.X / tS + x) + ((TileSelection.Y / tS + y) * 32);
                int palette = comboBox_tilesType.SelectedIndex;
                if (Version.IsMF && palette == 1) { palette = 0; }
                selectedTiles[x, y] = new MapTile()
                {
                    TileID = tileNum,
                    Palette = palette,
                    xFlip = TilesFlippedH,
                    yFlip = TilesFlippedV,
                };
            }
    }

    private void tileDisplay_tiles_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (tileDisplay_tiles.TileImage == null) return;
        if (e.X < 0 || e.Y < 0 || e.X > tileDisplay_tiles.Width || e.Y > tileDisplay_tiles.Height) return;
        if (e.TileIndexPosition.X >= 32 || e.TileIndexPosition.Y > numTiles / 32) return;

        TileCursor.Visible = false;
        MapSelectionVisible = false;

        TileSelection.Visible = true;
        TileSelection.Rectangle = new Rectangle(e.TilePixelPosition.X + tilesBorderSize, e.TilePixelPosition.Y + tilesBorderSize, e.TileSize, e.TileSize);
        TileSelectionPivot = TileSelection.Location;
    }

    private void tileDisplay_tiles_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (tileDisplay_tiles.TileImage == null) return;
        if (e.X < 0 || e.Y < 0 || e.X > tileDisplay_tiles.Width || e.Y > tileDisplay_tiles.Height) return;
        if (e.TileIndexPosition.X >= 32 || e.TileIndexPosition.Y >= numTiles / 32) return;

        TileCursor.Rectangle = new Rectangle(e.TilePixelPosition.X + tilesBorderSize, e.TilePixelPosition.Y + tilesBorderSize, e.TileSize, e.TileSize);

        int id = e.TileIndexPosition.X + e.TileIndexPosition.Y * 32;
        statusLabel_coor.Text = $"ID: {Hex.ToString(id)}";

        if ((e.Button == MouseButtons.Left || e.Button == MouseButtons.Right) && TileSelection.Visible)
        {
            TileCursor.Visible = false;

            Size SelectionSize = new Size(
                Math.Abs(e.TilePixelPosition.X + tilesBorderSize - TileSelectionPivot.X) + e.TileSize,
                Math.Abs(e.TilePixelPosition.Y + tilesBorderSize - TileSelectionPivot.Y) + e.TileSize
            );
            Point SelectionPosition = new Point(
                Math.Min(e.TilePixelPosition.X + tilesBorderSize, TileSelectionPivot.X),
                Math.Min(e.TilePixelPosition.Y + tilesBorderSize, TileSelectionPivot.Y)
            );
            TileSelection.Rectangle = new Rectangle(SelectionPosition, SelectionSize);

            return;
        }

        TileCursor.Visible = true;
    }

    private void tileDisplay_tiles_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (tileDisplay_tiles.TileImage == null) return;

        TileCursor.Visible = true;

        SelectFromTiles();
    }
    #endregion

    #region Map
    private void LoadMap()
    {
        try
        {
            Minimap _temp = ROM.LoadMinimap((byte)SelectedArea);
            LoadedMap = _temp.Copy();
        }
        catch (CorruptDataException)
        {
            var result = MessageBox.Show("Minimap data was corrupt.\n\n"
                    + "Would you like to try replacing it with blank data?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (result == DialogResult.Yes)
            {
                int pointer = Version.MinimapDataOffset + SelectedArea * 4;
                int offset = Add.BlankMinimap();
                romStream.WritePtr(pointer, offset);
                LoadedMap = new Minimap(romStream, (byte)SelectedArea);
            }
            else return;
        }

        if (comboBox_state.SelectedIndex == 0) { DrawMap(); }
        else { comboBox_state.SelectedIndex = 0; }

        MapSelectionVisible = false;
        MapCursor.Visible = false;
        selectedTiles = null;

        status.LoadNew();
    }

    private void DrawMap()
    {
        tileDisplay_map.TileImage = LoadedMap.Draw(romStream, palette, comboBox_state.SelectedIndex);
    }

    private void button_flipMapH_Click(object sender, EventArgs e)
    {
        if (!MapSelectionVisible) return;

        int xPos = MapSelection.X / tileDisplay_map.TileSize;
        int yPos = MapSelection.Y / tileDisplay_map.TileSize;
        int width = selectedTilesSize.Width;
        int height = selectedTilesSize.Height;

        MapTile[,] flippedTiles = new MapTile[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int realPosX = xPos + x;
                int realPosY = yPos + y;

                MapTile tile = LoadedMap.GetSquare(new(realPosX, realPosY));
                tile.xFlip = !tile.xFlip;
                flippedTiles[width - x - 1, y] = tile;
            }

        selectedTiles = flippedTiles;
        PasteSelectedTiles(new(xPos, yPos));
        MapSelection.InvalidateDrawable(MapSelection);
        status.ChangeMade();
    }

    private void button_flipMapV_Click(object sender, EventArgs e)
    {
        if (!MapSelectionVisible) return;

        int xPos = MapSelection.X / tileDisplay_map.TileSize;
        int yPos = MapSelection.Y / tileDisplay_map.TileSize;
        int width = selectedTilesSize.Width;
        int height = selectedTilesSize.Height;

        MapTile[,] flippedTiles = new MapTile[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int realPosX = xPos + x;
                int realPosY = yPos + y;

                MapTile tile = LoadedMap.GetSquare(new(realPosX, realPosY));
                tile.yFlip = !tile.yFlip;
                flippedTiles[x, height - y - 1] = tile;
            }

        selectedTiles = flippedTiles;
        PasteSelectedTiles(new(xPos, yPos));
        MapSelection.InvalidateDrawable(MapSelection);
        status.ChangeMade();
    }

    private void ComboBox_mapType_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (!MapSelectionVisible || init) return;
        if (comboBox_mapType.SelectedIndex == -1) return;

        int xPos = MapSelection.X / tileDisplay_map.TileSize;
        int yPos = MapSelection.Y / tileDisplay_map.TileSize;
        int width = selectedTilesSize.Width;
        int height = selectedTilesSize.Height;

        MapTile[,] modifiedTiles = new MapTile[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int realPosX = xPos + x;
                int realPosY = yPos + y;

                MapTile tile = LoadedMap.GetSquare(new(realPosX, realPosY));
                tile.Palette = comboBox_mapType.SelectedIndex;
                if (Version.IsMF && tile.Palette == 1) tile.Palette = 0;
                modifiedTiles[x, y] = tile;
            }

        selectedTiles = modifiedTiles;
        PasteSelectedTiles(new(xPos, yPos));
        MapSelection.InvalidateDrawable(MapSelection);
        status.ChangeMade();
    }

    private void comboBox_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedArea = comboBox_area.SelectedIndex;
    }

    private void comboBox_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawMap();
    }

    private void button_grid_CheckStateChanged(object sender, EventArgs e) => tileDisplay_map.ShowGrid = button_grid.Checked;

    private void PasteSelectedTiles(Point location)
    {
        if (selectedTiles == null) return;

        int widthTiles = tileDisplay_map.TileImage.Width / tileDisplay_map.TileSize;
        int heightTiles = tileDisplay_map.TileImage.Height / tileDisplay_map.TileSize;

        for (int x = 0; x < selectedTilesSize.Width; x++)
            for (int y = 0; y < selectedTilesSize.Height; y++)
            {
                if (location.X + x >= widthTiles || location.Y + y >= heightTiles || location.X + x < 0 || location.Y + y < 0) continue;

                MapTile tile = selectedTiles[x, y];
                LoadedMap.SetSquare(new(location.X + x, location.Y + y), tile);
                LoadedMap.Edited = true;

                // Draw New Square (Copied code so might be bad)
                int pal = tile.Palette;
                int tileId = tile.TileID;
                Minimap.GetSquareDisplayInfo(comboBox_state.SelectedIndex, ref pal, ref tileId, Version.IsMF);

                GFX gfx = new GFX(romStream, Version.MinimapGfxOffset + tileId * 0x20, 1, 1);
                Bitmap square = gfx.Draw4bpp(palette, pal, true);
                ColorPalette cp = square.Palette;
                cp.Entries[0] = Color.Black;
                square.Palette = cp;

                if (tile.Flip != 0) Draw.Flip4bpp(square, tile.Flip);
                using (Graphics g = Graphics.FromImage(tileDisplay_map.TileImage))
                {
                    Point p = new((location.X + x) * tileDisplay_map.TileSize, (location.Y + y) * tileDisplay_map.TileSize);
                    g.DrawImage(square, p.X, p.Y);
                }

            }

        Sound.PlaySound("map.wav");
        status.ChangeMade();
    }

    private void SelectFromMap()
    {
        if (!MapSelectionVisible) return;

        int width = MapSelection.Width / tileDisplay_map.TileSize;
        int height = MapSelection.Height / tileDisplay_map.TileSize;
        selectedTiles = new MapTile[width, height];

        int checkType = -1;
        int checkFlip = -1;
        bool sharedType = true;
        bool sharedFlip = true;

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                Point p = new(MapSelection.X / tileDisplay_map.TileSize + x, MapSelection.Y / tileDisplay_map.TileSize + y);
                MapTile tile = LoadedMap.GetSquare(p);

                // Compare with the other selected map tiles
                if (checkType == -1) checkType = tile.Palette;
                if (checkFlip == -1) checkFlip = tile.Flip;
                sharedType = checkType == tile.Palette && sharedType;
                sharedFlip = checkFlip == tile.Flip && sharedFlip;

                selectedTiles[x, y] = tile;
            }

        if (sharedType)
        {
            if (Version.IsMF && checkType == 0) checkType = 1;
            init = true;
            comboBox_mapType.SelectedIndex = checkType;
            init = false;
        }
    }

    private void tileDisplay_map_TileMouseDown(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (tileDisplay_map.TileImage == null || !MapCursor.Visible) return;
        if (e.X < 0 || e.Y < 0 || e.X > tileDisplay_map.Width || e.Y > tileDisplay_map.Height) return;

        if (e.Button == MouseButtons.Left)
        {
            PasteSelectedTiles(e.TileIndexPosition);
            MapCursor.InvalidateDrawable(MapCursor);
            return;
        }
        if (e.Button == MouseButtons.Right)
        {
            MapCursor.Visible = false;
            TileSelection.Visible = false;

            MapSelectionVisible = true;
            MapSelection.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, e.TileSize, e.TileSize);
            MapSelectionPivot = MapSelection.Location;

            return;
        }
    }

    private void tileDisplay_map_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (e.TilePixelPosition == MapCursor.Rectangle.Location || tileDisplay_map.TileImage == null) return;
        if (e.X < 0 || e.Y < 0 || e.X >= tileDisplay_map.Width || e.Y >= tileDisplay_map.Height) return;

        MapCursor.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, selectedTilesSize.Width * e.TileSize, selectedTilesSize.Height * e.TileSize);
        statusLabel_coor.Text = $"({Hex.ToString(e.TileIndexPosition.X)}, {Hex.ToString(e.TileIndexPosition.Y)})";

        if (e.Button == MouseButtons.Left) PasteSelectedTiles(e.TileIndexPosition);
        else if (e.Button == MouseButtons.Right)
        {
            MapCursor.Visible = false;

            Size SelectionSize = new Size(
                Math.Abs(e.TilePixelPosition.X - MapSelectionPivot.X) + e.TileSize,
                Math.Abs(e.TilePixelPosition.Y - MapSelectionPivot.Y) + e.TileSize
            );
            Point SelectionPosition = new Point(
                Math.Min(e.TilePixelPosition.X, MapSelectionPivot.X),
                Math.Min(e.TilePixelPosition.Y, MapSelectionPivot.Y)
            );
            MapSelection.Rectangle = new Rectangle(SelectionPosition, SelectionSize);

            return;
        }

        MapCursor.Visible = true;
    }

    private void tileDisplay_map_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        if (tileDisplay_map.TileImage == null) return;

        MapCursor.Visible = true;

        if (MapSelectionVisible)
        {
            comboBox_mapType.SelectedIndex = -1;
            SelectFromMap();
            MapCursor.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, selectedTilesSize.Width * e.TileSize, selectedTilesSize.Height * e.TileSize);
        }
    }
    #endregion

    #region Room Display
    private void button_viewRooms_Click(object sender, EventArgs e) => ViewRoomOutlines = !ViewRoomOutlines;

    private void LoadRooms(byte area)
    {
        if (roomListReloadRequired == false) return;

        Rooms = new();
        if (area < Version.RoomsPerArea.Length)
            for (byte i = 0; i < Version.RoomsPerArea[area]; i++)
            {
                Room? r = null;
                try { r = new Room(area, i); }
                catch { }
                Rooms.Add(r);
            }
        SetRoomOutlines();

        roomListReloadRequired = false;
    }

    private void SetRoomOutlines()
    {
        roomOutlines.Clear();
        tileDisplay_map.ResetDrawables();

        foreach (Room r in Rooms)
        {
            Point roomPos = new(r.header.mapX * tileDisplay_map.TileSize, r.header.mapY * tileDisplay_map.TileSize);
            Size roomSize = new(r.WidthInScreens * tileDisplay_map.TileSize, r.HeightInScreens * tileDisplay_map.TileSize);
            Rectangle roomRect = new(roomPos, roomSize);

            bool increasePenWidth = tileDisplay_map.Zoom >= 2;
            RoomOutlinePenLight.Width = increasePenWidth ? 2 : 1;
            RoomOutlinePenDark.Width = increasePenWidth ? 2 : 1;
            Drawable outline = new(roomRect, RoomOutlinePenLight, increasePenWidth ? 0 : 1)
            {
                Visible = ViewRoomOutlines,
            };
            outline.DrawPens.Add(RoomOutlinePenDark);

            roomOutlines.Add(outline);
            tileDisplay_map.AddDrawable(outline);
        }

        // Add back cursor and selection
        tileDisplay_map.AddDrawable(MapSelection);
        tileDisplay_map.AddDrawable(MapCursor);

        tileDisplay_map.Invalidate();
    }

    private void JumpToRoom()
    {
        if (MapCursor == null) return;
        LoadRooms((byte)SelectedArea);

        byte x = (byte)(MapCursor.X / tileDisplay_map.TileSize);
        byte y = (byte)(MapCursor.Y / tileDisplay_map.TileSize);

        //Loop throug all rooms and get list of rooms that match
        List<Room> matchingRooms = new();

        foreach (Room? r in Rooms)
        {
            if (r == null) continue;
            if (r.Contains(x, y)) matchingRooms.Add(r);
        }

        if (matchingRooms.Count == 1) main.JumpToRoom(matchingRooms[0].AreaID, matchingRooms[0].RoomID);

        if (matchingRooms.Count > 1)
        {
            //Set data up for cycling
            if (!roomJumpList.SequenceEqual(matchingRooms))
            {
                lastJumpIndex = 0;
                roomJumpList = matchingRooms;
            }
            else
            {
                lastJumpIndex++;
                if (lastJumpIndex >= matchingRooms.Count) lastJumpIndex = 0;
                roomJumpList = matchingRooms;
            }
            main.JumpToRoom(matchingRooms[lastJumpIndex].AreaID, matchingRooms[lastJumpIndex].RoomID);
        }

        return;
    }
    #endregion

    #region Zooming
    private void button_mapZoomIn_Click(object sender, EventArgs e) => UpdateMapZoom(tileDisplay_map.Zoom + 1);
    private void button_mapZoomOut_Click(object sender, EventArgs e) => UpdateMapZoom(tileDisplay_map.Zoom - 1);
    private void UpdateMapZoom(int value)
    {
        tileDisplay_map.Zoom = Math.Clamp(value, 0, maxZoom);
        button_mapZoomIn.Enabled = tileDisplay_map.Zoom < maxZoom;
        button_mapZoomOut.Enabled = tileDisplay_map.Zoom > 0;
        label_mapZoom.Text = $"{1 << tileDisplay_map.Zoom}00%";

        SetRoomOutlines();
    }

    private void button_tilesZoomIn_Click(object sender, EventArgs e) => UpdateTilesZoom(tileDisplay_tiles.Zoom + 1);
    private void button_tilesZoomOut_Click(object sender, EventArgs e) => UpdateTilesZoom(tileDisplay_tiles.Zoom - 1);
    private void UpdateTilesZoom(int value)
    {
        tileDisplay_tiles.Zoom = Math.Clamp(value, 0, maxZoom);
        button_tilesZoomIn.Enabled = tileDisplay_tiles.Zoom < maxZoom;
        button_tilesZoomOut.Enabled = tileDisplay_tiles.Zoom > 0;
        label_tilesZoom.Text = $"{1 << tileDisplay_tiles.Zoom}00%";
    }

    private void tileDisplay_tiles_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) UpdateTilesZoom(tileDisplay_tiles.Zoom + 1);
            if (e.Delta < 0) UpdateTilesZoom(tileDisplay_tiles.Zoom - 1);
        }
    }
    private void tileDisplay_map_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) UpdateMapZoom(tileDisplay_map.Zoom + 1);
            if (e.Delta < 0) UpdateMapZoom(tileDisplay_map.Zoom - 1);
        }
    }
    #endregion

    #region Import / Export
    private void statusStrip_exportRaw_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveRaw = new SaveFileDialog();
        saveRaw.Filter = "All files (*.*)|*.*";
        if (saveRaw.ShowDialog() == DialogResult.OK)
        {
            ByteStream output = new ByteStream();
            LoadedMap.Write(output, false, true);
            output.Export(saveRaw.FileName);
        }
    }

    private void statusStrip_exportImage_Click(object sender, EventArgs e)
    {
        SaveFileDialog saveMap = new SaveFileDialog();
        saveMap.Filter = "PNG files (*.png)|*.png";
        if (saveMap.ShowDialog() == DialogResult.OK)
        {
            tileDisplay_map.TileImage.Save(saveMap.FileName);
        }
    }

    private void statusStrip_importRaw_Click(object sender, EventArgs e)
    {
        OpenFileDialog openRaw = new OpenFileDialog();
        openRaw.Filter = "All files (*.*)|*.*";
        if (openRaw.ShowDialog() == DialogResult.OK)
        {
            byte[] temp = System.IO.File.ReadAllBytes(openRaw.FileName);
            ByteStream input = new ByteStream(temp);
            LoadedMap.Import(input);
            LoadedMap.Write(romStream, true, false);
            DrawMap();

            status.Import();
        }
    }
    #endregion

    #region Other Events
    private void button_apply_Click(object sender, EventArgs e) => Save();

    private void FormMinimapNew_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (!status.UnsavedChanges) return;
        if (!CheckUnsaved()) e.Cancel = true;
    }

    private void FormMinimapNew_KeyDown(object sender, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.H:
            case Keys.X:
                if (MapSelectionVisible) button_flipMapH_Click(sender, e);
                else button_flipTilesH_Click(sender, e);
                break;

            case Keys.V:
            case Keys.Y:
                if (MapSelectionVisible) button_flipMapV_Click(sender, e);
                else button_flipTilesV_Click(sender, e);
                break;

            case Keys.G:
                JumpToRoom();
                break;

            default:
                break;
        }
    }

    private void button_editGfx_Click(object sender, EventArgs e)
    {
        int height = numTiles / 32;
        FormGraphics form = new FormGraphics(main, Version.MinimapGfxOffset, 32, height, Version.MinimapPaletteOffset);
        form.Show();
    }
    #endregion
}
