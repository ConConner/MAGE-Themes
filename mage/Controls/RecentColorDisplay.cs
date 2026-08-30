using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace mage.Controls;

public enum ColorMouseButton
{
    Left,
    Right,
    Middle,
}

public sealed class RecentColorClickedEventArgs : EventArgs
{
    public RecentColorClickedEventArgs(Color color, int index, ColorMouseButton button)
    {
        Color = color;
        Index = index;
        Button = button;
    }

    public Color Color { get; }

    public int Index { get; }

    public ColorMouseButton Button { get; }

    public bool IsLeftClick => Button == ColorMouseButton.Left;

    public bool IsRightClick => Button == ColorMouseButton.Right;
}

[DefaultEvent(nameof(ColorClicked))]
public class RecentColorDisplay : Control
{
    private readonly List<Color> colors = [];

    private int swatchSize = 23;
    private int swatchSpacing = 2;
    private Color outlineColor = Color.Black;
    private int outlineWidth = 1;
    private int capacity = 32;
    private int hoverIndex = -1;
    private Color highlightColor = Color.White;
    private int highlightWidth = 1;

    public RecentColorDisplay()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint
                | ControlStyles.SupportsTransparentBackColor,
            true
        );

        DoubleBuffered = true;
    }

    /// <summary>Raised when a swatch is clicked.</summary>
    public event EventHandler<RecentColorClickedEventArgs>? ColorClicked;

    [Category("Appearance")]
    [DefaultValue(23)]
    public int SwatchSize
    {
        get => swatchSize;
        set
        {
            value = Math.Max(4, value);
            if (swatchSize == value)
            {
                return;
            }

            swatchSize = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(2)]
    public int SwatchSpacing
    {
        get => swatchSpacing;
        set
        {
            value = Math.Max(0, value);
            if (swatchSpacing == value)
            {
                return;
            }

            swatchSpacing = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color OutlineColor
    {
        get => outlineColor;
        set
        {
            if (outlineColor == value)
            {
                return;
            }

            outlineColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(1)]
    public int OutlineWidth
    {
        get => outlineWidth;
        set
        {
            value = Math.Max(0, value);
            if (outlineWidth == value)
            {
                return;
            }

            outlineWidth = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    public Color HighlightColor
    {
        get => highlightColor;
        set
        {
            if (highlightColor == value)
            {
                return;
            }

            highlightColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [DefaultValue(1)]
    public int HighlightWidth
    {
        get => highlightWidth;
        set
        {
            value = Math.Max(0, value);
            if (highlightWidth == value)
            {
                return;
            }

            highlightWidth = value;
            Invalidate();
        }
    }

    /// <summary>
    /// Maximum number of colors kept in the history. Only as many as fit into
    /// the control bounds are drawn.
    /// </summary>
    [Category("Behavior")]
    [DefaultValue(32)]
    public int Capacity
    {
        get => capacity;
        set
        {
            value = Math.Max(1, value);
            if (capacity == value)
            {
                return;
            }

            capacity = value;
            TrimToCapacity();
            Invalidate();
        }
    }

    /// <summary>Colors in history, most recent first.</summary>
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<Color> Colors => colors;

    /// <summary>Number of swatches that currently fit into the control.</summary>
    [Browsable(false)]
    public int VisibleCapacity
    {
        get
        {
            int cell = swatchSize + swatchSpacing;
            int columns = (ClientSize.Width + swatchSpacing) / Math.Max(1, cell);
            int rows = (ClientSize.Height + swatchSpacing) / Math.Max(1, cell);
            return Math.Max(0, columns) * Math.Max(0, rows);
        }
    }

    /// <summary>
    /// Adds a color as the most recent entry. Existing duplicates are moved to
    /// the front instead of being added again.
    /// </summary>
    public void AddColor(Color color)
    {
        color = Normalize(color);

        int existing = IndexOf(color);
        if (existing == 0)
        {
            return;
        }

        if (existing > 0)
        {
            colors.RemoveAt(existing);
        }

        colors.Insert(0, color);
        TrimToCapacity();
        Invalidate();
    }

    public void AddColors(IEnumerable<Color> values)
    {
        ArgumentNullException.ThrowIfNull(values);

        // Reverse so the last item ends up as the most recent one.
        foreach (Color color in values.Reverse())
        {
            AddColor(color);
        }
    }

    public bool RemoveColor(Color color)
    {
        int index = IndexOf(Normalize(color));
        if (index < 0)
        {
            return false;
        }

        colors.RemoveAt(index);
        Invalidate();
        return true;
    }

    public void Clear()
    {
        if (colors.Count == 0)
        {
            return;
        }

        colors.Clear();
        hoverIndex = -1;
        Invalidate();
    }

    public bool Contains(Color color) => IndexOf(Normalize(color)) >= 0;

    protected override Size DefaultSize => new(240, 27);

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.None;
        g.PixelOffsetMode = PixelOffsetMode.None;

        int cell = swatchSize + swatchSpacing;
        int columns = Math.Max(0, (ClientSize.Width + swatchSpacing) / cell);
        int rows = Math.Max(0, (ClientSize.Height + swatchSpacing) / cell);
        int drawable = Math.Min(colors.Count, columns * rows);

        using Pen outline = new(outlineColor, Math.Max(1, outlineWidth));
        outline.Alignment = PenAlignment.Inset;

        using Pen highlight = new(highlightColor, Math.Max(1, highlightWidth));
        highlight.Alignment = PenAlignment.Inset;

        for (int i = 0; i < drawable; i++)
        {
            Rectangle bounds = GetSwatchBounds(i, columns);

            using SolidBrush fill = new(colors[i]);
            g.FillRectangle(fill, bounds);

            // Inset alignment pulls the stroke fully inside the rectangle, so
            // pass the full size; nothing gets clipped or hangs outside.
            if (outlineWidth > 0)
            {
                g.DrawRectangle(outline, bounds);
            }

            if (i == hoverIndex && highlightWidth > 0)
            {
                int inset = outlineWidth + highlightWidth - 1;
                Rectangle inner = Rectangle.Inflate(bounds, -inset, -inset);
                if (inner.Width > 0 && inner.Height > 0)
                {
                    g.DrawRectangle(highlight, inner);
                }
            }
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        int index = HitTest(e.Location);
        if (index == hoverIndex)
        {
            return;
        }

        hoverIndex = index;
        Cursor = index >= 0 ? Cursors.Hand : Cursors.Default;
        Invalidate();
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);

        if (hoverIndex < 0)
        {
            return;
        }

        hoverIndex = -1;
        Cursor = Cursors.Default;
        Invalidate();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        int index = HitTest(e.Location);
        if (index < 0)
        {
            return;
        }

        ColorMouseButton button = e.Button switch
        {
            MouseButtons.Left => ColorMouseButton.Left,
            MouseButtons.Right => ColorMouseButton.Right,
            MouseButtons.Middle => ColorMouseButton.Middle,
            _ => (ColorMouseButton)(-1),
        };

        if (button < ColorMouseButton.Left)
        {
            return;
        }

        OnColorClicked(
            new RecentColorClickedEventArgs(colors[index], index, button)
        );
    }

    protected virtual void OnColorClicked(RecentColorClickedEventArgs e) =>
        ColorClicked?.Invoke(this, e);

    private int HitTest(Point location)
    {
        int cell = swatchSize + swatchSpacing;
        int columns = Math.Max(0, (ClientSize.Width + swatchSpacing) / cell);
        int rows = Math.Max(0, (ClientSize.Height + swatchSpacing) / cell);
        int drawable = Math.Min(colors.Count, columns * rows);

        for (int i = 0; i < drawable; i++)
        {
            if (GetSwatchBounds(i, columns).Contains(location))
            {
                return i;
            }
        }

        return -1;
    }

    private Rectangle GetSwatchBounds(int index, int columns)
    {
        int cell = swatchSize + swatchSpacing;
        int column = index % columns;
        int row = index / columns;
        return new Rectangle(
            column * cell,
            row * cell,
            swatchSize,
            swatchSize
        );
    }

    private int IndexOf(Color color)
    {
        for (int i = 0; i < colors.Count; i++)
        {
            if (colors[i].ToArgb() == color.ToArgb())
            {
                return i;
            }
        }

        return -1;
    }

    private void TrimToCapacity()
    {
        if (colors.Count > capacity)
        {
            colors.RemoveRange(capacity, colors.Count - capacity);
        }
    }

    private static Color Normalize(Color color) =>
        Color.FromArgb(255, color.R, color.G, color.B);
}