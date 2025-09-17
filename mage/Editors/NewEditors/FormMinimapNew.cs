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

namespace mage.Editors.NewEditors;

public partial class FormMinimapNew : Form, Editor
{
    // Shortcuts
    private string[] tileTypeItems => Version.IsMF ?
        new[] { "Normal", "Hidden" } :
        new[] { "Start", "Normal", "Heated", "Hidden", "Heated (hidden)" };
    private string[] mapStateItems => Version.IsMF ?
        new[] { "Explored", "Downloaded" } :
        new[] { "Explored", "Downloaded", "Start" };
    private int numOfPalettes => Version.IsMF ? 3 : 5;

    // Properties
    private bool tilesFlippedH = false;
    private bool TilesFlippedH
    {
        get => tilesFlippedH;
        set
        {
            if (value == tilesFlippedH) return;
            tilesFlippedH = value;

            button_flipTilesH.Checked = value;
            DrawTiles(TilesFlippedH, TilesFlippedV);
        }
    }
    private bool tilesFlippedV = false;
    private bool TilesFlippedV
    {
        get => tilesFlippedV;
        set
        {
            if (value == tilesFlippedV) return;
            tilesFlippedV = value;

            button_flipTilesV.Checked = value;
            DrawTiles(TilesFlippedH, TilesFlippedV);
        }
    }

    // fields
    private const int maxZoom = 4;

    private FlatComboBox comboBox_tilesType;

    private bool init = false;
    private Minimap LoadedMap;
    private Palette palette;
    private int numTiles;
    private Status status;

    private FormMain main;
    private ByteStream romStream;

    private int selectedArea = -1;
    private int SelectedArea
    {
        get => selectedArea;
        set
        {
            if (selectedArea == value) return;
            selectedArea = value;
            LoadMap();
        }
    }

    public FormMinimapNew(FormMain main)
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;
        this.romStream = ROM.Stream;

        //Tile Display Setup
        UpdateMapZoom(1);
        UpdateTilesZoom(1);

        status = new Status(statusLabel_changes, button_apply);
        AddTypeComboboxes();
        SetValuesBasedOnGame();
        SetPalette();
        PopulateBoxesBasedOnGame();

        DrawTiles();
        tileDisplay_tiles.BackColor = Color.Black;
        comboBox_tilesType.SelectedIndex = Version.IsMF ? 0 : 1;
    }

    public void UpdateEditor()
    {

    }

    #region Setup
    private void AddTypeComboboxes()
    {
        // Create combobox
        comboBox_tilesType = new()
        {
            Width = 101,
            DropDownStyle = ComboBoxStyle.DropDownList,
        };
        comboBox_tilesType.SelectedIndexChanged += ComboBox_tilesType_SelectedIndexChanged;
        ThemeSwitcher.ChangeTheme(comboBox_tilesType);

        // Add to toolStrip
        var host = new ToolStripControlHost(comboBox_tilesType);
        toolStrip_tiles.Items.Insert(0, host);
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

        palette.SetBitmapPalette(tileImage, 1, 1);
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

        palette.SetBitmapPalette(img, comboBox_tilesType.SelectedIndex + (Version.IsMF ? 1 : 0), 1);
        ColorPalette cp = img.Palette;
        cp.Entries[0] = Color.Transparent;
        img.Palette = cp;
        tileDisplay_tiles.Invalidate();
    }

    private void button_flipTilesH_Click(object sender, EventArgs e) => TilesFlippedH = !TilesFlippedH;
    private void button_flipTilesV_Click(object sender, EventArgs e) => TilesFlippedV = !TilesFlippedV;
    #endregion

    #region Map
    private void LoadMap()
    {
        try
        {
            LoadedMap = ROM.LoadMinimap((byte)SelectedArea);
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

        status.LoadNew();
    }

    private void DrawMap()
    {
        tileDisplay_map.TileImage = LoadedMap.Draw(romStream, palette, comboBox_state.SelectedIndex);
    }

    private void comboBox_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        SelectedArea = comboBox_area.SelectedIndex;
    }

    private void comboBox_state_SelectedIndexChanged(object sender, EventArgs e)
    {
        DrawMap();
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
    #endregion

    #region Import / Export
    #endregion
}
