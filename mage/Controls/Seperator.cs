using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Controls;

public class Seperator : Control
{
    private Orientation _orientation = Orientation.Vertical;

    [DefaultValue(typeof(Color), "ControlDark")]
    public Color Color { get; set; } = SystemColors.ControlDark;

    [DefaultValue(Orientation.Vertical)]
    public Orientation Orientation
    {
        get => _orientation;
        set { _orientation = value; SetSize(); }
    }

    public Seperator()
    {
        SetStyle(ControlStyles.ResizeRedraw | ControlStyles.FixedHeight |
                 ControlStyles.FixedWidth | ControlStyles.Selectable, false);
        SetSize();
    }

    private void SetSize()
    {
        Size = Orientation == Orientation.Vertical
            ? new Size(1, 50)
            : new Size(50, 1);
    }

    protected override void SetBoundsCore(int x, int y, int width, int height,
                                      BoundsSpecified specified)
    {
        if (Orientation == Orientation.Vertical)
            height = Math.Max(1, height);   // keep width 1
        else
            width = Math.Max(1, width);   // keep height 1

        base.SetBoundsCore(x, y, Orientation == Orientation.Vertical ? 1 : width,
                           Orientation == Orientation.Vertical ? height : 1,
                           specified);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        using var pen = new Pen(Color);
        if (Orientation == Orientation.Vertical)
            e.Graphics.DrawLine(pen, 0, 0, 0, Height - 1);
        else
            e.Graphics.DrawLine(pen, 0, 0, Width - 1, 0);
    }
}
