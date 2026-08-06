using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
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

    private FormPaletteNew()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);
    }

    public FormPaletteNew(bool tileset, byte value)
    {
        InitializeComponent();
    }

    public FormPaletteNew(int offset, int rows)
    {
        InitializeComponent();
    }

    private void colorBar_red_ValueChanged(object sender, EventArgs e)
    {
        var bar = sender as ColorBar;
        SetColorAll(bar.Red, bar.Green, bar.Blue);
    }

    private void SetColorAll(int r, int g, int b)
    {
        colorBar_red.SetColor(r, g, b);
        colorBar_green.SetColor(r, g, b);
        colorBar_blue.SetColor(r, g, b);
    }
}
