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

namespace mage.Dialogs
{
    public partial class TilesetDialog : Form
    {
        public byte SelectedTileset { get; set; }

        public List<VramBG> TilesetImages;

        public TilesetDialog()
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(this.Controls, this);
            ThemeSwitcher.InjectPaintOverrides(this.Controls);

            for (byte i = 0; i < Version.NumOfTilesets; i++)
            {
                //Create Controls
                Tileset t = new Tileset(ROM.Stream, i);
                VramBG vram = new VramBG(t, true);
                TileView tv = new TileView();
                tv.Tag = i;

                //Add to Form
                pnl_flow.Controls.Add(tv);
                tv.BackgroundImage = vram.Image;
                tv.Click += pressedTileset;
                tv.Cursor = Cursors.Hand;
            }
        }

        private void pressedTileset(object sender, EventArgs e)
        {
            byte id = (byte)(sender as TileView).Tag;
            SelectedTileset = id;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
