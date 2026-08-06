using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace mage.Controls;

[DefaultEvent(nameof(ColorChanged))]
public unsafe class HsvColorPicker : Control
{
    private const int Max = 255;

    private Bitmap _gradient; // static, depends only on size
    private Bitmap _cache; // gradient + markers
    private bool _dirty = true;

    private enum Drag
    {
        None,
        Matrix,
        Bar
    }

    private Drag _drag;

    private int _hue, _sat = Max, _val = Max;

    private int _barWidth = 20;
    private int _gap = 4;
    private int _markerWidth = 4;
    private int _markerRadius = 5;

    private Color _borderColor = Color.Black;
    private Color _markerColor = Color.White;

    public HsvColorPicker()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw
                | ControlStyles.Selectable,
            true
        );
        Width = 256;
        Height = 200;
        TabStop = true;
    }

    // --- appearance ---------------------------------------------------

    [Category("Appearance")]
    public Color BorderColor
    {
        get => _borderColor;
        set
        {
            if (_borderColor == value) return;
            _borderColor = value;
            MarkDirty();
        }
    }

    [Category("Appearance")]
    public Color MarkerColor
    {
        get => _markerColor;
        set
        {
            if (_markerColor == value) return;
            _markerColor = value;
            MarkDirty();
        }
    }

    [Category("Appearance"), DefaultValue(4)]
    public int MarkerWidth
    {
        get => _markerWidth;
        set
        {
            value = Math.Max(2, value);
            if (_markerWidth == value) return;
            _markerWidth = value;
            MarkDirty();
        }
    }

    [Category("Appearance"), DefaultValue(5)]
    public int MarkerRadius
    {
        get => _markerRadius;
        set
        {
            value = Math.Max(2, value);
            if (_markerRadius == value) return;
            _markerRadius = value;
            MarkDirty();
        }
    }

    [Category("Layout"), DefaultValue(20)]
    public int ValueBarWidth
    {
        get => _barWidth;
        set
        {
            value = Math.Max(3, value);
            if (_barWidth == value) return;
            _barWidth = value;
            InvalidateGradient();
        }
    }

    [Category("Layout"), DefaultValue(4)]
    public int Spacing
    {
        get => _gap;
        set
        {
            value = Math.Max(0, value);
            if (_gap == value) return;
            _gap = value;
            InvalidateGradient();
        }
    }

    // --- state --------------------------------------------------------

    [Category("Behavior"), DefaultValue(0)]
    public int Hue
    {
        get => _hue;
        set => SetHsv(value, _sat, _val, true);
    }

    [Category("Behavior"), DefaultValue(255)]
    public int Saturation
    {
        get => _sat;
        set => SetHsv(_hue, value, _val, true);
    }

    [Category("Behavior"), DefaultValue(255)]
    public int Value
    {
        get => _val;
        set => SetHsv(_hue, _sat, value, true);
    }

    /// <summary>Current color, quantized to 15bpp then expanded to 8 bit.</summary>
    [Browsable(false)]
    public Color SelectedColor
    {
        get
        {
            GetRgb5(out int r, out int g, out int b);
            return Color.FromArgb(Expand5To8(r), Expand5To8(g), Expand5To8(b));
        }
    }

    public event EventHandler ColorChanged;
    public event EventHandler ColorCommitted;

    protected virtual void OnColorChanged(EventArgs e) =>
        ColorChanged?.Invoke(this, e);

    protected virtual void OnColorCommitted(EventArgs e) =>
        ColorCommitted?.Invoke(this, e);

    // --- rgb api ------------------------------------------------------

    /// <summary>Gets the current color as 5 bit channels (0..31).</summary>
    public void GetRgb5(out int red, out int green, out int blue)
    {
        HsvToRgb(_hue, _sat, _val, out int r, out int g, out int b);
        red = r >> 3;
        green = g >> 3;
        blue = b >> 3;
    }

    /// <summary>Sets the color from 5 bit channels (0..31).</summary>
    public void SetRgb5(int red, int green, int blue) =>
        SetRgb8(
            Expand5To8(Math.Clamp(red, 0, 31)),
            Expand5To8(Math.Clamp(green, 0, 31)),
            Expand5To8(Math.Clamp(blue, 0, 31))
        );

    public void SetRgb8(int red, int green, int blue)
    {
        RgbToHsv(
            Math.Clamp(red, 0, 255),
            Math.Clamp(green, 0, 255),
            Math.Clamp(blue, 0, 255),
            out int h,
            out int s,
            out int v
        );
        if (s == 0) h = _hue;
        if (v == 0) s = _sat;
        SetHsv(h, s, v, true);
    }

    public void SetColor(Color c) => SetRgb8(c.R, c.G, c.B);

    public void SetHsv(int hue, int sat, int val) => SetHsv(hue, sat, val, true);

    private void SetHsv(int hue, int sat, int val, bool raise)
    {
        hue = ((hue % (Max + 1)) + Max + 1) % (Max + 1);
        sat = Math.Clamp(sat, 0, Max);
        val = Math.Clamp(val, 0, Max);
        if (hue == _hue && sat == _sat && val == _val) return;

        _hue = hue;
        _sat = sat;
        _val = val;
        MarkDirty();
        if (raise) OnColorChanged(EventArgs.Empty);
    }

    private static int Expand5To8(int v) => (v << 3) | (v >> 2);

    // --- layout -------------------------------------------------------

    [Browsable(false)]
    public Rectangle MatrixRectangle =>
        new Rectangle(0, 0, Math.Max(1, Width - _barWidth - _gap), Height);

    [Browsable(false)]
    public Rectangle ValueBarRectangle =>
        new Rectangle(Width - _barWidth, 0, _barWidth, Height);

    protected override void SetBoundsCore(
        int x,
        int y,
        int width,
        int height,
        BoundsSpecified specified
    )
    {
        base.SetBoundsCore(
            x,
            y,
            Math.Max(width, _barWidth + _gap + 8),
            Math.Max(height, _markerWidth * 2),
            specified
        );
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        InvalidateGradient();
    }

    private void MarkDirty()
    {
        _dirty = true;
        Invalidate();
    }

    private void InvalidateGradient()
    {
        _gradient?.Dispose();
        _gradient = null;
        MarkDirty();
    }

    // --- input --------------------------------------------------------

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button != MouseButtons.Left) return;
        Focus();

        if (e.X >= ValueBarRectangle.Left)
        {
            _drag = Drag.Bar;
            ValueFromY(e.Y);
        }
        else
        {
            _drag = Drag.Matrix;
            HueSatFromPoint(e.X, e.Y);
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        switch (_drag)
        {
            case Drag.Bar:
                ValueFromY(e.Y);
                break;
            case Drag.Matrix:
                HueSatFromPoint(e.X, e.Y);
                break;
        }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        if (_drag == Drag.None) return;
        _drag = Drag.None;
        OnColorCommitted(EventArgs.Empty);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        int step = e.Control ? 16 : 4;
        switch (e.KeyCode)
        {
            case Keys.Left:
                Hue -= step;
                e.Handled = true;
                break;
            case Keys.Right:
                Hue += step;
                e.Handled = true;
                break;
            case Keys.Up:
                Saturation += step;
                e.Handled = true;
                break;
            case Keys.Down:
                Saturation -= step;
                e.Handled = true;
                break;
            case Keys.PageUp:
                Value += step;
                e.Handled = true;
                break;
            case Keys.PageDown:
                Value -= step;
                e.Handled = true;
                break;
        }
        if (e.Handled) OnColorCommitted(EventArgs.Empty);
    }

    protected override bool IsInputKey(Keys keyData) =>
        keyData
            is Keys.Left
                or Keys.Right
                or Keys.Up
                or Keys.Down
                or Keys.PageUp
                or Keys.PageDown
            || base.IsInputKey(keyData);

    private void ValueFromY(int y)
    {
        int travel = Math.Max(1, Height - _markerWidth);
        y = Math.Clamp(y - _markerWidth / 2, 0, travel);
        SetHsv(_hue, _sat, Max - (y * Max + travel / 2) / travel, true);
    }

    private void HueSatFromPoint(int x, int y)
    {
        Rectangle m = MatrixRectangle;
        int tw = Math.Max(1, m.Width - 1);
        int th = Math.Max(1, m.Height - 1);
        x = Math.Clamp(x, 0, tw);
        y = Math.Clamp(y, 0, th);
        SetHsv(
            (x * Max + tw / 2) / tw,
            Max - (y * Max + th / 2) / th,
            _val,
            true
        );
    }

    // --- rendering ----------------------------------------------------

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Width <= 0 || Height <= 0) return;

        if (_gradient == null
            || _gradient.Width != Width
            || _gradient.Height != Height)
        {
            _gradient?.Dispose();
            _gradient = RenderGradient(Width, Height);
            _dirty = true;
        }

        if (
            _dirty
            || _cache == null
            || _cache.Width != Width
            || _cache.Height != Height
        )
        {
            _cache?.Dispose();
            _cache = Compose(_gradient);
            _dirty = false;
        }

        e.Graphics.DrawImageUnscaled(_cache, 0, 0);
    }

    /// <summary>Static gradients: full value hue/sat matrix + grey value ramp.</summary>
    private Bitmap RenderGradient(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb);
        BitmapData data = bmp.LockBits(
            new Rectangle(0, 0, width, height),
            ImageLockMode.WriteOnly,
            bmp.PixelFormat
        );

        int stride = data.Stride / 4;
        int* ptr = (int*)data.Scan0;
        int back = BackColor.ToArgb() & 0xFFFFFF;

        Rectangle m = MatrixRectangle;
        Rectangle bar = ValueBarRectangle;

        // hue (x) / saturation (y) at full value
        int tw = Math.Max(1, m.Width - 1);
        int th = Math.Max(1, m.Height - 1);
        for (int y = 0; y < m.Height; y++)
        {
            int s = Max - y * Max / th;
            int* p = ptr + (m.Top + y) * stride;
            for (int x = 0; x < m.Width; x++)
            {
                HsvToRgb(x * Max / tw, s, Max, out int r, out int g, out int b);
                p[m.Left + x] = (r << 16) | (g << 8) | b;
            }
        }

        // gap + vertical value ramp (white top -> black bottom)
        int bth = Math.Max(1, bar.Height - 1);
        for (int y = 0; y < height; y++)
        {
            int* p = ptr + y * stride;
            for (int x = m.Right; x < bar.Left; x++) p[x] = back;

            int v = Max - y * Max / bth;
            int grey = (v << 16) | (v << 8) | v;
            for (int x = bar.Left; x < bar.Right; x++) p[x] = grey;
        }

        bmp.UnlockBits(data);
        return bmp;
    }

    private Bitmap Compose(Bitmap gradient)
    {
        Bitmap bmp = (Bitmap)gradient.Clone();
        BitmapData data = bmp.LockBits(
            new Rectangle(0, 0, bmp.Width, bmp.Height),
            ImageLockMode.ReadWrite,
            bmp.PixelFormat
        );

        int stride = data.Stride / 4;
        int* ptr = (int*)data.Scan0;

        DrawCircleMarker(ptr, stride, MatrixRectangle);
        DrawBarMarker(ptr, stride, ValueBarRectangle);

        bmp.UnlockBits(data);
        return bmp;
    }

    private void DrawBarMarker(int* ptr, int stride, Rectangle bar)
    {
        int travel = Math.Max(0, bar.Height - _markerWidth);
        int start = ((Max - _val) * travel + Max / 2) / Max;
        int end = Math.Min(bar.Height, start + _markerWidth);

        int border = _borderColor.ToArgb() & 0xFFFFFF;
        int fill = _markerColor.ToArgb() & 0xFFFFFF;

        for (int y = start; y < end; y++)
        {
            int* p = ptr + (bar.Top + y) * stride;
            bool edgeRow = y == start || y == end - 1;
            for (int x = 0; x < bar.Width; x++)
            {
                bool edgeCol = x == 0 || x == bar.Width - 1;
                p[bar.Left + x] = edgeRow || edgeCol ? border : fill;
            }
        }
    }

    /// <summary>Ring marker: outer border ring, inner ring in marker color.</summary>
    private void DrawCircleMarker(int* ptr, int stride, Rectangle m)
    {
        int tw = Math.Max(1, m.Width - 1);
        int th = Math.Max(1, m.Height - 1);
        int cx = m.Left + (_hue * tw + Max / 2) / Max;
        int cy = m.Top + ((Max - _sat) * th + Max / 2) / Max;

        int rOut = _markerRadius;
        int rIn = Math.Max(1, _markerRadius - 2);

        int border = _borderColor.ToArgb() & 0xFFFFFF;
        int fill = _markerColor.ToArgb() & 0xFFFFFF;

        int outSq = rOut * rOut;
        int midSq = (rOut - 1) * (rOut - 1);
        int inSq = rIn * rIn;

        for (int dy = -rOut; dy <= rOut; dy++)
        {
            int y = cy + dy;
            if (y < m.Top || y >= m.Bottom) continue;
            int* p = ptr + y * stride;

            for (int dx = -rOut; dx <= rOut; dx++)
            {
                int x = cx + dx;
                if (x < m.Left || x >= m.Right) continue;

                int d = dx * dx + dy * dy;
                if (d > outSq) continue;

                if (d > midSq) p[x] = border;
                else if (d >= inSq) p[x] = fill;
            }
        }
    }

    // --- hsv <-> rgb (all components 0..255) --------------------------

    public static void HsvToRgb(
        int h,
        int s,
        int v,
        out int r,
        out int g,
        out int b
    )
    {
        if (s == 0)
        {
            r = g = b = v;
            return;
        }

        int region = h * 6 / 256;
        int rem = h * 6 - region * 256;
        int p = v * (255 - s) / 255;
        int q = v * (255 - s * rem / 255) / 255;
        int t = v * (255 - s * (255 - rem) / 255) / 255;

        switch (region)
        {
            case 0:
                r = v;
                g = t;
                b = p;
                break;
            case 1:
                r = q;
                g = v;
                b = p;
                break;
            case 2:
                r = p;
                g = v;
                b = t;
                break;
            case 3:
                r = p;
                g = q;
                b = v;
                break;
            case 4:
                r = t;
                g = p;
                b = v;
                break;
            default:
                r = v;
                g = p;
                b = q;
                break;
        }
    }

    public static void RgbToHsv(
        int r,
        int g,
        int b,
        out int h,
        out int s,
        out int v
    )
    {
        int max = Math.Max(r, Math.Max(g, b));
        int min = Math.Min(r, Math.Min(g, b));
        int delta = max - min;

        v = max;
        s = max == 0 ? 0 : delta * 255 / max;

        if (delta == 0)
        {
            h = 0;
            return;
        }

        int hue6;
        if (max == r) hue6 = (g - b) * 256 / delta;
        else if (max == g) hue6 = 512 + (b - r) * 256 / delta;
        else hue6 = 1024 + (r - g) * 256 / delta;

        h = ((hue6 / 6) + 256) % 256;
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            _cache?.Dispose();
            _gradient?.Dispose();
        }
        base.Dispose(disposing);
    }
}