using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace mage.Controls;

[DefaultEvent(nameof(ColorsChanged))]
public class DualColorSwatch : Control
{
    private Color _primaryColor = Color.Black;
    private Color _secondaryColor = Color.White;

    private Color _swatchOutlineColor = SystemColors.ControlDarkDark;
    private Color _swapGlyphColor = SystemColors.ControlDarkDark;
    private Color _swapGlyphHotColor = SystemColors.Highlight;

    private Rectangle _primaryRect;
    private Rectangle _secondaryRect;
    private Rectangle _swapRect;

    private bool _swapHot;

    public DualColorSwatch()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint
                | ControlStyles.SupportsTransparentBackColor,
            true);

        BackColor = Color.Transparent;
        Size = new Size(60, 60);
    }

    [Category("Appearance")]
    [Description("The currently selected (primary) color.")]
    public Color PrimaryColor
    {
        get => _primaryColor;
        set
        {
            if (_primaryColor == value) return;
            _primaryColor = value;
            OnPrimaryColorChanged(EventArgs.Empty);
            OnColorsChanged(EventArgs.Empty);
            Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("The secondary color.")]
    public Color SecondaryColor
    {
        get => _secondaryColor;
        set
        {
            if (_secondaryColor == value) return;
            _secondaryColor = value;
            OnSecondaryColorChanged(EventArgs.Empty);
            OnColorsChanged(EventArgs.Empty);
            Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("Outline color of both color swatches.")]
    public Color SwatchOutlineColor
    {
        get => _swatchOutlineColor;
        set
        {
            if (_swatchOutlineColor == value) return;
            _swatchOutlineColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("Default color of the swap arrows.")]
    public Color SwapGlyphColor
    {
        get => _swapGlyphColor;
        set
        {
            if (_swapGlyphColor == value) return;
            _swapGlyphColor = value;
            Invalidate();
        }
    }

    [Category("Appearance")]
    [Description("Color of the swap arrows when hovered.")]
    public Color SwapGlyphHotColor
    {
        get => _swapGlyphHotColor;
        set
        {
            if (_swapGlyphHotColor == value) return;
            _swapGlyphHotColor = value;
            Invalidate();
        }
    }

    [Category("Property Changed")]
    [Description("Raised when the primary color is set to a new value.")]
    public event EventHandler PrimaryColorChanged;

    [Category("Property Changed")]
    [Description("Raised when the secondary color is set to a new value.")]
    public event EventHandler SecondaryColorChanged;

    [Category("Property Changed")]
    [Description("Raised when either color changes.")]
    public event EventHandler ColorsChanged;

    [Category("Action")]
    [Description("Raised when primary and secondary color are swapped.")]
    public event EventHandler ColorsSwapped;

    protected virtual void OnPrimaryColorChanged(EventArgs e) =>
        PrimaryColorChanged?.Invoke(this, e);

    protected virtual void OnSecondaryColorChanged(EventArgs e) =>
        SecondaryColorChanged?.Invoke(this, e);

    protected virtual void OnColorsChanged(EventArgs e) =>
        ColorsChanged?.Invoke(this, e);

    protected virtual void OnColorsSwapped(EventArgs e) =>
        ColorsSwapped?.Invoke(this, e);

    /// <summary>Swaps primary and secondary color.</summary>
    public void SwapColors()
    {
        Color tmp = _primaryColor;
        _primaryColor = _secondaryColor;
        _secondaryColor = tmp;

        OnPrimaryColorChanged(EventArgs.Empty);
        OnSecondaryColorChanged(EventArgs.Empty);
        OnColorsSwapped(EventArgs.Empty);
        OnColorsChanged(EventArgs.Empty);
        Invalidate();
    }

    /// <summary>Sets both colors, raising events only once.</summary>
    public void SetColors(Color primary, Color secondary)
    {
        bool primaryChanged = _primaryColor != primary;
        bool secondaryChanged = _secondaryColor != secondary;
        if (!primaryChanged && !secondaryChanged) return;

        _primaryColor = primary;
        _secondaryColor = secondary;

        if (primaryChanged) OnPrimaryColorChanged(EventArgs.Empty);
        if (secondaryChanged) OnSecondaryColorChanged(EventArgs.Empty);
        OnColorsChanged(EventArgs.Empty);
        Invalidate();
    }

    private void UpdateLayout()
    {
        int pad = 2;
        int glyph = 12;
        int box = Math.Min(Width - 2 * pad, Height - 2 * pad) - 1;
        if (box < 4) box = 4;

        int swatch = Math.Max(4, (int)Math.Round(box * 0.72));
        int offset = box - swatch;

        int left = pad;
        int top = pad;

        _primaryRect = new Rectangle(left, top, swatch, swatch);
        _secondaryRect = new Rectangle(
            left + offset, top + offset, swatch, swatch);

        _swapRect = new Rectangle(_primaryRect.Right + pad, _secondaryRect.Top - glyph - pad, glyph, glyph);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        UpdateLayout();

        Graphics g = e.Graphics;
        g.SmoothingMode = SmoothingMode.AntiAlias;

        DrawSwatch(g, _secondaryRect, _secondaryColor, false);
        DrawSwatch(g, _primaryRect, _primaryColor, true);
        DrawSwapGlyph(g, _swapRect, _swapHot);
    }

    private void DrawSwatch(Graphics g, Rectangle r, Color c, bool primary)
    {
        using (var b = new SolidBrush(Color.FromArgb(255, c)))
            g.FillRectangle(b, r);

        using (var p = new Pen(_swatchOutlineColor))
            g.DrawRectangle(p, r);
    }

    private void DrawSwapGlyph(Graphics g, Rectangle r, bool hot)
    {
        Color color = hot ? _swapGlyphHotColor : _swapGlyphColor;

        using (var p = new Pen(color, 1.2f))
        {
            p.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(p, r.Left + 1, r.Top + 4, r.Right - 2, r.Top + 4);
            g.DrawLine(p, r.Right - 2, r.Bottom - 4, r.Left + 1, r.Bottom - 4);
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);

        bool swapHot = _swapRect.Contains(e.Location);
        bool overSecondary = _secondaryRect.Contains(e.Location)
            && !_primaryRect.Contains(e.Location);

        Cursor = (swapHot || overSecondary) ? Cursors.Hand : Cursors.Default;

        if (swapHot != _swapHot)
        {
            _swapHot = swapHot;
            Invalidate();
        }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
        base.OnMouseLeave(e);
        if (_swapHot)
        {
            _swapHot = false;
            Invalidate();
        }
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
        base.OnMouseClick(e);

        if (_swapRect.Contains(e.Location))
        {
            SwapColors();
            return;
        }

        if (_secondaryRect.Contains(e.Location)
            && !_primaryRect.Contains(e.Location))
        {
            SwapColors();
        }
    }
}