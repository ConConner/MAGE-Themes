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
using System.Diagnostics;

namespace mage.Editors
{
    public partial class FormTileTableNew : Form
    {
        // Fields
        Pen CursorPen = new Pen(Color.Red, 1);
        Pen SelectionPenWhite = new Pen(Color.White, 1) { DashPattern = new float[] { 2, 3 } };
        Pen SelectionPenBlack = new Pen(Color.Black, 1) { DashPattern = new float[] { 2, 3 }, DashOffset = 2 };

        private Drawable Cursor;
        private Drawable Selection;
        private Point SelectionPivot;

        public FormTileTableNew()
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            Cursor = new Drawable(Rectangle.Empty, CursorPen, 1) { Visible = false };
            Selection = new Drawable(Rectangle.Empty, SelectionPenWhite, 1) { Visible = false };
            Selection.DrawPens.Add(SelectionPenBlack);

            tile_gfxView.AddDrawable(Cursor);
            tile_gfxView.AddDrawable(Selection);

            AddTestGfx();
        }

        private void AddTestGfx()
        {
            // Temporary testing
            Tileset t = new Tileset(ROM.Stream, 8);
            VramBG vram = new VramBG(t, false);
            byte[] gfxData = new byte[0x8000];
            Array.Copy(vram.BGtiles, gfxData, 0x8000);
            Palette palette = vram.BGpalette;

            GFX gfx = new GFX(gfxData, 32);
            Bitmap gfxImg = gfx.Draw15bpp(palette, 3, false);

            tile_gfxView.TileImage = gfxImg;
            tile_gfxView.Zoom = 2;
        }

        #region Events
        private void tile_gfxView_TileMouseDown(object sender, TileDisplay.TileDisplayArgs e)
        {
            Cursor.Visible = false;
            Selection.Visible = true;
            Selection.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, e.TileSize, e.TileSize);
            SelectionPivot = Selection.Location;
        }

        private void tile_gfxView_TileMouseMove(object sender, TileDisplay.TileDisplayArgs e)
        {
            if (e.TilePixelPosition == Cursor.Rectangle.Location) return;

            if (e.Button == MouseButtons.Left && Selection.Visible)
            {
                Cursor.Visible = false;

                Size SelectionSize = new Size(
                    Math.Abs(e.TilePixelPosition.X - SelectionPivot.X) + e.TileSize,
                    Math.Abs(e.TilePixelPosition.Y - SelectionPivot.Y) + e.TileSize
                );
                Point SelectionPosition = new Point(
                    Math.Min(e.TilePixelPosition.X, SelectionPivot.X),
                    Math.Min(e.TilePixelPosition.Y, SelectionPivot.Y)
                );
                Selection.Rectangle = new Rectangle(SelectionPosition, SelectionSize);

                return;
            }

            Cursor.Visible = true;
            Cursor.Rectangle = new Rectangle(e.TilePixelPosition.X, e.TilePixelPosition.Y, e.TileSize, e.TileSize);
        }
        #endregion
    }
}
