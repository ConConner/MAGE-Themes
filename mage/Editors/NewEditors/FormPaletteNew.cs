using mage.Actions;
using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
    }

    public FormPaletteNew(bool tileset, byte value) : this()
    {
    }

    public FormPaletteNew(int offset, int rows) : this()
    {
    }
    #endregion

    #region Generic Helpers
    private void ThemeColorBar()
    {
        colorBar_blue.MarkerColor = colorBar_green.MarkerColor = colorBar_red.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorBar_blue.BorderColor = colorBar_green.BorderColor = colorBar_red.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;

        colorPicker.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorPicker.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;
    }

    private Color Rgb5ToColor(int r, int g, int b) => Color.FromArgb(r * 8, g * 8, b * 8);

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
    #endregion

    #region Generic Events
    private void ThemeSwitcher_ThemeChanged(object? sender, EventArgs e) => ThemeColorBar();
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

        pictureBox_chosenColor.BackColor = current;

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

        int r = c.R / 8;
        int g = c.G / 8;
        int b = c.B / 8;

        UpdateSelectedColor(r, g, b, false, true);
    }
    #endregion

    #region Palette Display
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
