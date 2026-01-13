using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Controls;

internal class DualColorBox : Control
{
    private Color _colorLeft = Color.Black;
    private Color _colorRight = Color.White;

    public DualColorBox()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw |
            ControlStyles.UserPaint,
            true);

        Size = new Size(18, 18);
        MinimumSize = new Size(18, 18);
        MaximumSize = new Size(18, 18);
    }

    [Category("Appearance")]
    public Color ColorLeft
    {
        get => _colorLeft;
        set
        {
            if (_colorLeft == value) return;
            _colorLeft = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color ColorRight
    {
        get => _colorRight;
        set
        {
            if (_colorRight == value) return;
            _colorRight = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.Clear(BackColor);
        e.Graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

        var inner = new Rectangle(1, 1, 16, 16);

        Point[] leftTri =
        {
            new Point(inner.Left, inner.Top),
            new Point(inner.Left, inner.Bottom),
            new Point(inner.Right, inner.Top)
        };

        Point[] rightTri =
        {
            new Point(inner.Right, inner.Bottom),
            new Point(inner.Right, inner.Top),
            new Point(inner.Left, inner.Bottom)
        };

        using (var bLeft = new SolidBrush(_colorLeft))
            e.Graphics.FillPolygon(bLeft, leftTri);

        using (var bRight = new SolidBrush(_colorRight))
            e.Graphics.FillPolygon(bRight, rightTri);

        using (var penDiag = new Pen(Color.FromArgb(80, Color.Black), 1))
            e.Graphics.DrawLine(penDiag, inner.Right, inner.Top, inner.Left, inner.Bottom);

        using (var penBorder = new Pen(Color.Black, 1))
            e.Graphics.DrawRectangle(penBorder, inner);
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);

        if (Width != 18 || Height != 18)
        {
            Width = 18;
            Height = 18;
        }
    }
}
