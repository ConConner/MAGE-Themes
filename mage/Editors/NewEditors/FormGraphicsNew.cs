using mage.Controls;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;

namespace mage.Editors.NewEditors;

public partial class FormGraphicsNew : Form
{
    private enum Tools
    {
        Select,
        Brush,
        Fill,
        Eyedropper
    }

    private bool init = false;

    // fields
    private FormMain main;
    private GFX loadedGFX;
    private Palette loadedPalette;

    private TileDisplay tileDisplay_palette;
    private DualColorBox colorDisplay;

    public FormGraphicsNew(FormMain main, int gfxOffset, int width, int height, int palOffset)
    {
        InitializeComponent();

        // Theme Switching
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.main = main;

        init = true;
        textBox_imageOffset.Text = Hex.ToString(gfxOffset);
        textBox_palOffset.Text = Hex.ToString(palOffset);
        if (height == 0) checkBox_compressed.Checked = true;
        else
        {
            numericUpDown_width.Value = width;
            numericUpDown_height.Value = height;
        }
        init = false;

        //Populate toolstrip
        AddPaletteDisplay();

        LoadData();
    }

    private void LoadData()
    {
        if (!LoadPalette(0)) return;
        if (!LoadNewGFX()) return;
        DrawPalette();
        DrawGFX();
    }

    private void AddPaletteDisplay()
    {
        tileDisplay_palette = new()
        {
            TileSize = 21,
        };
        colorDisplay = new();

        var paletteHost = new ToolStripControlHost(tileDisplay_palette)
        {
            AutoSize = false,
            Size = new Size(16 * 16 + 17, 22)
        };
        toolStrip_palette.Items.Insert(toolStrip_palette.Items.IndexOf(button_increasePalette), paletteHost);

        var colorHost = new ToolStripControlHost(colorDisplay);
        toolStrip_palette.Items.Insert(0, colorHost);
    }

    #region General Events
    private void button_load_Click(object sender, EventArgs e) => LoadData();
    #endregion

    #region GFX
    private bool LoadNewGFX()
    {
        int offset;
        try
        {
            offset = Hex.ToInt(textBox_imageOffset.Text);
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                        + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        int width = (int)numericUpDown_height.Value;

        if (checkBox_compressed.Checked)
        {
            try
            {
                int len = ROM.Stream.Read32(offset) >> 8;
                if (ROM.Stream.Read8(offset) != 0x10 || len == 0)
                {
                    throw new FormatException();
                }
                loadedGFX = new GFX(ROM.Stream, offset, width);
                if (loadedGFX.origLen == 0)
                {
                    throw new FormatException();
                }
            }
            catch
            {
                MessageBox.Show("There are no compressed graphics at the given offset.",
                    "Compressed graphics error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        else
        {
            int height = (int)numericUpDown_height.Value;
            loadedGFX = new GFX(ROM.Stream, offset, width, height);
        }

        statusLabel_changes.Text = "";
        return true;
    }

    private void DrawGFX()
    {
        tileDisplay_gfx.TileImage = loadedGFX.Draw4bpp(loadedPalette, 0, true);
        statusLabel_size.Text = tileDisplay_gfx.TileImage.Width + " x " + tileDisplay_gfx.TileImage.Height;
    }

    private void checkBox_compressed_CheckedChanged(object sender, EventArgs e)
    {
        numericUpDown_height.Enabled = !checkBox_compressed.Checked;
    }
    #endregion

    #region Palette
    private bool LoadPalette(int diff)
    {
        try
        {
            int offset = Hex.ToInt(textBox_palOffset.Text);
            if (diff != 0)
            {
                offset += diff;
                textBox_palOffset.Text = Hex.ToString(offset);
            }

            loadedPalette = new Palette(ROM.Stream, offset, 1);
        }
        catch (Exception ex)
        {
            MessageBox.Show("The offset entered was not valid.\n\n" + ex.GetType().ToString() + '\n'
                    + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        return true;
    }

    private void DrawPalette()
    {
        tileDisplay_palette.TileImage = loadedPalette.Draw(16, 0, 1, gridColorArgb: 0);
    }

    private void button_increasePalette_Click(object sender, EventArgs e)
    {
        LoadPalette(32);
        DrawPalette();
        DrawGFX();
    }

    private void button_decreasePalette_Click(object sender, EventArgs e)
    {
        LoadPalette(-32);
        DrawPalette();
        DrawGFX();
    }
    #endregion

    #region Zoom
    const int maxZoom = 4;

    private void button_imageZoomIn_Click(object sender, EventArgs e) => updateZoom(tileDisplay_gfx.Zoom + 1);
    private void button_imageZoomOut_Click(object sender, EventArgs e) => updateZoom(tileDisplay_gfx.Zoom - 1);

    private void tileDisplay_gfx_Scrolled(object sender, MouseEventArgs e)
    {
        if ((ModifierKeys & Keys.Control) == Keys.Control)
        {
            if (e.Delta > 0) updateZoom(tileDisplay_gfx.Zoom + 1);
            if (e.Delta < 0) updateZoom(tileDisplay_gfx.Zoom - 1);
        }
    }

    private void updateZoom(int value)
    {
        tileDisplay_gfx.Zoom = Math.Clamp(value, 0, maxZoom);
        button_imageZoomIn.Enabled = tileDisplay_gfx.Zoom < maxZoom;
        button_imageZoomOut.Enabled = tileDisplay_gfx.Zoom > 0;
        label_imageZoom.Text = $"{1 << tileDisplay_gfx.Zoom}00%";
    }
    #endregion
}
