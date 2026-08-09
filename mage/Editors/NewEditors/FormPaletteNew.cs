using mage.Actions;
using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mage.Editors.NewEditors;

public partial class FormPaletteNew : Form
{
    public static void OpenPaletteEditor(bool tileset, byte value)
    {
        if (Program.ExperimentalFeaturesEnabled) new FormPaletteNew(tileset, value).Show();
        else new FormPalette(FormMain.Instance, tileset, value).Show();
    }
    public static void OpenPaletteEditor(int offset, int rows)
    {
        if (Program.ExperimentalFeaturesEnabled) new FormPaletteNew(offset, rows).Show();
        else new FormPalette(FormMain.Instance, offset, rows).Show();
    }

    #region Fields
    // State
    private bool init = false;
    private bool ignoreColorSwatchUpdate = false;
    private Palette palette;
    private Status status;

    // Undo Redo
    private GenericUndoRedo undoRedo = new();

    // Drawables
    #endregion

    #region Constructor
    private FormPaletteNew()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);
        ThemeSwitcher.ThemeChanged += ThemeSwitcher_ThemeChanged;
        ThemeColorBar();

        textBox_hex_color.TextChanged += TextBox_hex_color_TextChanged;

        status = new(statusLabel_changes, button_apply);

        updateZoom(1);
        tileDisplay_pal.ShowGrid = true;
    }

    public FormPaletteNew(bool tileset, byte value) : this()
    {
        if (tileset) LoadPaletteFromTileset(value);
        else LoadPaletteFromSprite(value);
    }

    public FormPaletteNew(int offset, int rows) : this()
    {
        textBox_offset.Text = Hex.ToString(offset);
        numericUpDown_rows.Value = rows;

        LoadPalette();
    }
    #endregion

    #region Generic Helpers
    private void ThemeColorBar()
    {
        colorBar_blue.MarkerColor = colorBar_green.MarkerColor = colorBar_red.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorBar_blue.BorderColor = colorBar_green.BorderColor = colorBar_red.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;

        colorPicker.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorPicker.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;

        colorSwatch.SwatchOutlineColor = ThemeSwitcher.ProjectTheme.SecondaryOutline;
        colorSwatch.SwapGlyphColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;
        colorSwatch.SwapGlyphHotColor = ThemeSwitcher.ProjectTheme.AccentColor;
    }

    private void LoadPalette()
    {
        try
        {
            int offset = Hex.ToInt(textBox_offset.Text);
            int rows = (int)numericUpDown_rows.Value;

            palette = new Palette(ROM.Stream, offset, rows);
            DrawPalette();
            status.LoadNew();
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LoadPaletteFromTileset(byte tileset)
    {
        int headerOffset = Version.TilesetOffset + tileset * 0x14;
        int BGpaletteOffset = ROM.Stream.ReadPtr(headerOffset + 0x4);

        textBox_offset.Text = Hex.ToString(BGpaletteOffset);
        numericUpDown_rows.Value = 14;
        LoadPalette();
    }

    private void LoadPaletteFromSprite(byte sprite)
    {
        if (sprite < 0x10) { return; }

        // TODO: reuse code
        int addVal = (sprite - 0x10) * 4;

        // get gfx rows
        int numGfxRows;
        if (Version.IsMF)
        {
            int offset = Version.SpriteGfxRowsOffset + addVal;
            numGfxRows = ROM.Stream.Read16(offset) / 0x800;
        }
        else
        {
            int offset = Version.SpriteGfxOffset + addVal;
            int gfxOffset = ROM.Stream.ReadPtr(offset);
            numGfxRows = Math.Max(ROM.Stream.Read16(gfxOffset + 1) / 0x800, 1);
        }

        // get palette
        int palPtr = Version.SpritePaletteOffset + addVal;
        int palOffset = ROM.Stream.ReadPtr(palPtr);
        // code to move ends here

        textBox_offset.Text = Hex.ToString(palOffset);
        numericUpDown_rows.Value = numGfxRows;
        LoadPalette();
    }

    private void Save()
    {

    }

    /// <summary>
    /// Prompts the user if they want to save the current changes or cancel.
    /// </summary>
    /// <returns>False if cancelled. True for other options. Saves if yes is clicked</returns>
    private bool CheckUnsaved()
    {
        DialogResult result = MessageBox.Show("Do you want to save changes to Palette?",
            "Unsaved Changes", MessageBoxButtons.YesNoCancel);
        if (result == DialogResult.Cancel) return false;
        if (result == DialogResult.Yes) Save();
        return true;
    }

    private Color Rgb5ToColor(int r, int g, int b) => Color.FromArgb(r * 8, g * 8, b * 8);
    private void ColorToRgb5(Color c, out int r, out int g, out int b)
    {
        r = c.R / 8;
        g = c.G / 8;
        b = c.B / 8;
    }
    #endregion

    #region Generic Events
    private void ThemeSwitcher_ThemeChanged(object? sender, EventArgs e) => ThemeColorBar();

    private void button_load_Click(object sender, EventArgs e) => LoadPalette();

    private void button_minus_Click(object sender, EventArgs e)
    {
        textBox_offset.Text = Hex.ToString(Hex.ToInt(textBox_offset.Text) - 0x20);
        LoadPalette();
    }

    private void button_plus_Click(object sender, EventArgs e)
    {
        textBox_offset.Text = Hex.ToString(Hex.ToInt(textBox_offset.Text) + 0x20);
        LoadPalette();
    }

    private void button_grid_CheckStateChanged(object sender, EventArgs e) => tileDisplay_pal.ShowGrid = button_grid.Checked;
    #endregion

    #region Color Controls
    private void UpdateSelectedColor(int r, int g, int b, bool preventColorPickerUpdate = false, bool preventTextBoxUpdate = false)
    {
        init = true;

        Color current = Rgb5ToColor(r, g, b);

        colorBar_red.SetColor(r, g, b);
        colorBar_green.SetColor(r, g, b);
        colorBar_blue.SetColor(r, g, b);

        numericUpDown_red.Value = r;
        numericUpDown_green.Value = g;
        numericUpDown_blue.Value = b;

        if (!preventTextBoxUpdate) textBox_hex_color.Text = ColorOperations.ToHexString(current);
        if (!preventColorPickerUpdate) colorPicker.SetRgb5(r, g, b);

        ignoreColorSwatchUpdate = true;
        colorSwatch.PrimaryColor = current;
        ignoreColorSwatchUpdate = false;

        init = false;
    }

    private void colorBars_ValueChanged(object sender, EventArgs e)
    {
        if (init) return;
        var bar = sender as ColorBar;
        if (bar is null) return;

        UpdateSelectedColor(bar.Red, bar.Green, bar.Blue);
    }

    private void colorPicker_ColorChanged(object sender, EventArgs e)
    {
        if (init) return;
        int red, green, blue;
        colorPicker.GetRgb5(out red, out green, out blue);
        UpdateSelectedColor(red, green, blue, true);
    }

    private void numericUpDown_red_ValueChanged(object sender, EventArgs e)
    {
        if (init) return;
        int r = (int)numericUpDown_red.Value;
        int g = (int)numericUpDown_green.Value;
        int b = (int)numericUpDown_blue.Value;
        UpdateSelectedColor(r, g, b);
    }

    private void TextBox_hex_color_TextChanged(object? sender, EventArgs e)
    {
        if (init) return;

        //Do a Regex check if value is actually a hex number
        string text = textBox_hex_color.Text;
        text = Regex.Match(text, @"[0-9a-fA-F]+").Value;
        if (text.Length != 6) return; //if 6 numbers are not given
        text = text.Insert(0, "#");
        Color c = ColorTranslator.FromHtml(text);

        int r, g, b;
        ColorToRgb5(c, out r, out g, out b);

        UpdateSelectedColor(r, g, b, false, true);
    }

    private void colorSwatch_ColorsChanged(object sender, EventArgs e)
    {
        if (ignoreColorSwatchUpdate) return;
        int r, g, b;
        ColorToRgb5(colorSwatch.PrimaryColor, out r, out g, out b);
        UpdateSelectedColor(r, g, b);
    }
    #endregion

    #region Palette Display
    private void DrawPalette()
    {
        tileDisplay_pal.TileImage = palette.Draw(16, 0, palette.Rows, noGrid: true);
    }
    #endregion

    #region Zoom
    const int maxZoom = 4;

    private void button_imageZoomIn_Click(object sender, EventArgs e) => updateZoom(tileDisplay_pal.Zoom + 1);
    private void button_imageZoomOut_Click(object sender, EventArgs e) => updateZoom(tileDisplay_pal.Zoom - 1);

    private void tileDisplay_pal_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) updateZoom(tileDisplay_pal.Zoom + 1);
            if (e.Delta < 0) updateZoom(tileDisplay_pal.Zoom - 1);
        }
    }

    private void updateZoom(int value)
    {
        tileDisplay_pal.Zoom = Math.Clamp(value, 0, maxZoom);
        button_ZoomIn.Enabled = tileDisplay_pal.Zoom < maxZoom;
        button_ZoomOut.Enabled = tileDisplay_pal.Zoom > 0;
        label_Zoom.Text = $"{1 << tileDisplay_pal.Zoom}00%";
    }
    #endregion
}
