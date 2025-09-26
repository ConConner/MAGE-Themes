using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            for (byte i = 0; i < Version.NumOfTilesets; i++)
            {
                //Create Controls
                GroupBox group = new GroupBox()
                {
                    Text = $"Tileset {Hex.ToString(i)}",
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                };
                Tileset t = new Tileset(ROM.Stream, i);
                VramBG vram = new VramBG(t, true);
                TileView tv = new TileView()
                {
                    Location = new(5, 15)
                };
                tv.Tag = i;
                group.Tag = i;
                group.Controls.Add(tv);
                group.PerformLayout();

                //Add to Form
                pnl_flow.Controls.Add(group);
                tv.BackgroundImage = vram.Image;
                tv.Click += pressedTileset;
                tv.Cursor = Cursors.Hand;
            }

            ThemeSwitcher.ChangeTheme(this.Controls, this);
            ThemeSwitcher.InjectPaintOverrides(this.Controls);
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
