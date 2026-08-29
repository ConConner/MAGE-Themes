using mage.Theming;
using mage.Utility;
using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace mage.Editors.NewEditors;

/// <summary>Standalone color-picking dialog, reusing the same color controls as <see cref="FormPaletteNew"/>.</summary>
public partial class FormColorPicker : Form
{
    private bool init = false;

    public ushort SelectedArgb { get; private set; }

    public FormColorPicker(ushort initialArgb)
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);
        ThemeSwitcher.ThemeChanged += ThemeSwitcher_ThemeChanged;
        ThemeColorBar();

        textBox_hex_color.TextChanged += TextBox_hex_color_TextChanged;

        SelectedArgb = initialArgb;
        PaletteColor.ArgbToRgb5(initialArgb, out int r, out int g, out int b);
        UpdateSelectedColor(r, g, b);
    }

    private void ThemeSwitcher_ThemeChanged(object? sender, EventArgs e) => ThemeColorBar();

    private void ThemeColorBar()
    {
        colorBar_blue.MarkerColor = colorBar_green.MarkerColor = colorBar_red.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorBar_blue.BorderColor = colorBar_green.BorderColor = colorBar_red.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;

        colorPicker.MarkerColor = ThemeSwitcher.ProjectTheme.BackgroundColor;
        colorPicker.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;

        panel_preview.BorderStyle = BorderStyle.FixedSingle;
    }

    private void UpdateSelectedColor(int r, int g, int b, bool preventColorPickerUpdate = false, bool preventTextBoxUpdate = false)
    {
        init = true;

        Color current = PaletteColor.Rgb5ToColor(r, g, b);

        colorBar_red.SetColor(r, g, b);
        colorBar_green.SetColor(r, g, b);
        colorBar_blue.SetColor(r, g, b);

        numericUpDown_red.Value = r;
        numericUpDown_green.Value = g;
        numericUpDown_blue.Value = b;

        if (!preventTextBoxUpdate) textBox_hex_color.Text = ColorOperations.ToHexString(current);
        if (!preventColorPickerUpdate) colorPicker.SetRgb5(r, g, b);

        panel_preview.BackColor = current;

        SelectedArgb = PaletteColor.Rgb5ToArgb(r, g, b);

        init = false;
    }

    private void colorBars_ValueChanged(object sender, EventArgs e)
    {
        if (init) return;
        var bar = sender as mage.Controls.ColorBar;
        if (bar is null) return;

        UpdateSelectedColor(bar.Red, bar.Green, bar.Blue);
    }

    private void colorPicker_ColorChanged(object sender, EventArgs e)
    {
        if (init) return;
        colorPicker.GetRgb5(out int red, out int green, out int blue);
        UpdateSelectedColor(red, green, blue, true);
    }

    private void numericUpDown_ValueChanged(object sender, EventArgs e)
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

        string text = textBox_hex_color.Text;
        text = Regex.Match(text, @"[0-9a-fA-F]+").Value;
        if (text.Length != 6) return;
        text = text.Insert(0, "#");
        Color c = ColorTranslator.FromHtml(text);

        PaletteColor.ColorToRgb5(c, out int r, out int g, out int b);

        UpdateSelectedColor(r, g, b, false, true);
    }

    private void button_ok_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void button_cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
}
