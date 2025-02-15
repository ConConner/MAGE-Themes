using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Controls;

/// <summary>
/// A group of objects that represent a colored rectangle on the OamView.
/// </summary>
/// <param name="Rectangle">The rectangle to draw</param>
/// <param name="DrawPen">The color and stroke width to use</param>
/// <param name="indent">a value that is applied to the width and height of the rectangle AFTER its zoomed</param>
public class Drawable
{
    public Drawable() : this(Rectangle.Empty, Pens.Red) {}
    public Drawable(Rectangle Rectangle, Pen DrawPen, int indent = 0)
    {
        this.Rectangle = Rectangle;
        this.DrawPens = new List<Pen>() { DrawPen };
        this.Indent = indent;
    }

    public int X => Rectangle.X;
    public int Y => Rectangle.Y;
    public int Width => Rectangle.Width;
    public int Height => Rectangle.Height;
    public Point Location => Rectangle.Location;

    private Rectangle rectangle = Rectangle.Empty;
    public Rectangle Rectangle
    {
        get => rectangle;
        set
        {
            if (rectangle == value) return;

            OldRectangle = rectangle;
            rectangle = value;

            InvalidateDrawable(this);
        }
    }
    public Rectangle OldRectangle { get; set; }
    public List<Pen> DrawPens { get; set; }
    public int Indent { get; set; }
    public bool Visible { get; set; } = true;
    public Action<Drawable> InvalidateDrawable { get; set; }
}