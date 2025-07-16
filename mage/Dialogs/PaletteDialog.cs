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

namespace mage.Dialogs;

public partial class PaletteDialog : Form
{
    public int SelectedIndex = -1;
    Pen CursorPen = new Pen(Color.Red, 1);
    private Drawable cursor;

    public PaletteDialog(Palette palette, int len)
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        DialogResult = DialogResult.Cancel;
        Bitmap paletteImage = palette.Draw(16, 0, len, 0x0);
        paletteView.TileImage = paletteImage;
        Size = new Size(Size.Width, paletteView.Location.Y + paletteView.Size.Height + 12 + 39);

        cursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
        paletteView.AddDrawable(cursor);

        for (int i = 0; i < len; i++) comboBox_palette.Items.Add(Hex.ToString(i));
    }

    private void paletteView_TileMouseMove(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        cursor.Visible = true;
        cursor.Rectangle = new Rectangle(0, Math.Min(e.TilePixelPosition.Y, 17 * 15), 16 * 16 + 17, 17);
    }

    private void paletteView_TileMouseUp(object sender, mage.Controls.TileDisplay.TileDisplayArgs e)
    {
        SelectedIndex = e.TileIndexPosition.Y;
        DialogResult = DialogResult.OK;
        Close();
    }

    private void button_cancel_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void comboBox_palette_SelectedIndexChanged(object sender, EventArgs e)
    {
        button_ok.Enabled = true;
    }

    private void button_ok_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        SelectedIndex = comboBox_palette.SelectedIndex;
    }
}
