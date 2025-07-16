using mage.Properties;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace mage.Controls;

public class TileTableTooltip : ToolTip
{
    public Image TileGFX { get; set; } = null;
    public Point PositionOnImage = new Point(-1, -1);
    public ushort TileVal = 0;
    public int TileID => TileVal & 0x3FF;
    public int TilePal => TileVal >> 12;
    public bool FlipH => (TileVal & 0x400) != 0;
    public bool FlipV => (TileVal & 0x800) != 0;

    public TileTableTooltip()
    {
        this.OwnerDraw = true;
        this.Popup += TileTableTooltip_Popup;
        this.Draw += TileTableTooltip_Draw;
    }

    private void TileTableTooltip_Popup(object? sender, PopupEventArgs e)
    {
        e.ToolTipSize = new Size(85, 151);
    }

    private void TileTableTooltip_Draw(object? sender, DrawToolTipEventArgs e)
    {
        Graphics g = e.Graphics;
        SolidBrush backgroundBrush = new SolidBrush(ThemeSwitcher.ProjectTheme.BackgroundColor);
        SolidBrush textBrush = new SolidBrush(ThemeSwitcher.ProjectTheme.TextColor);
        Pen outlinePen = new Pen(ThemeSwitcher.ProjectTheme.PrimaryOutline, 1);
        Pen secOutlinePen = new Pen(ThemeSwitcher.ProjectTheme.SecondaryOutline, 1);

        const int margin = 5;
        const int previewSize = 56;

        //Texts
        string caption = "Tile Info";
        Font captionFont = new Font(e.Font, FontStyle.Bold | FontStyle.Underline);
        SizeF captionSize = g.MeasureString(caption, e.Font);

        Font regularFont = e.Font;
        int regularHeight = (int)g.MeasureString("W", regularFont).Height;

        // Icons
        Bitmap hArrow = Resources.flip_h;
        Bitmap vArrow = Resources.flip_v;

        /// DRAWING THE TOOLTIP
        Point drawLocation = new Point(e.Bounds.X + margin, e.Bounds.Y + margin);

        // Background and Outline
        g.FillRectangle(backgroundBrush, e.Bounds);
        g.DrawRectangle(outlinePen, new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1));

        // Title text
        g.DrawString(caption, captionFont, textBrush, drawLocation);
        drawLocation.Y += (int)captionSize.Height + margin;
        
        // Tile ID
        g.DrawString($"ID:\t {Hex.ToString(TileID)}", regularFont, textBrush, drawLocation);
        drawLocation.Y += regularHeight + margin;

        // Palette
        g.DrawString($"Pal:\t {Hex.ToString(TilePal)}", regularFont, textBrush, drawLocation);
        drawLocation.Y += regularHeight + margin;

        // Tile Preview
        if (TileGFX != null && PositionOnImage.X != -1)
        {
            // Draw Outline boxes for Image preview
            g.DrawRectangle(secOutlinePen, new Rectangle(drawLocation.X + vArrow.Width, drawLocation.Y, previewSize, hArrow.Height));
            g.DrawRectangle(secOutlinePen, new Rectangle(drawLocation.X, drawLocation.Y + hArrow.Height, vArrow.Width, previewSize - 2));

            // Draw Flip Icons (Yes these numbers are truly magic. I dont know why they are required but they make it look good)
            if (FlipH) g.DrawImage(hArrow, new Point(drawLocation.X + vArrow.Width + previewSize / 2 - hArrow.Width / 2 - 2, drawLocation.Y - 1));
            if (FlipV) g.DrawImage(vArrow, new Point(drawLocation.X - 1, drawLocation.Y + hArrow.Height + previewSize / 2 - vArrow.Height / 2 - 2));

            // Draw actual Tile
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(
                TileGFX, 
                new Rectangle(drawLocation.X + vArrow.Width + 1, drawLocation.Y + hArrow.Height + 1, previewSize, previewSize), 
                new Rectangle(PositionOnImage.X, PositionOnImage.Y, 7, 7), GraphicsUnit.Pixel
            );
        }
    }
}
