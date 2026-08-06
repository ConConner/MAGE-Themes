using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace mage.Controls;

public enum ColorChannel
{
    Red,
    Green,
    Blue
}

[DefaultEvent(nameof(ValueChanged))]
public unsafe class ColorBar : Control
{
    // 15bpp: 5 bits per channel -> 32 levels
    private const int Levels = 32;
    private const int MaxValue = Levels - 1;

    private Bitmap _cache;
    private bool _dirty = true;
    private bool _dragging;

    private ColorChannel _channel = ColorChannel.Red;
    private int _red, _green, _blue;
    private int _markerWidth = 4;
    private int _minBarHeight = 3;

    public ColorBar()
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
        Height = 20;
        TabStop = true;
    }

    [Category("Appearance")]
    public ColorChannel Channel
    {
        get => _channel;
        set
        {
            if (_channel == value) return;
            _channel = value;
            MarkDirty();
        }
    }

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
    private Color _borderColor = Color.Black;

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
    private Color _markerColor = Color.White;

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

    [Category("Layout"), DefaultValue(3)]
    public int MinimumBarHeight
    {
        get => _minBarHeight;
        set => _minBarHeight = Math.Max(1, value);
    }

    /// <summary>Value of this bar's channel, 0..31.</summary>
    [Category("Behavior"), DefaultValue(0)]
    public int Value
    {
        get => GetChannel(_channel);
        set => SetChannelInternal(_channel, value, true);
    }

    [Category("Behavior"), DefaultValue(0)]
    public int Red
    {
        get => _red;
        set => SetChannelInternal(ColorChannel.Red, value, true);
    }

    [Category("Behavior"), DefaultValue(0)]
    public int Green
    {
        get => _green;
        set => SetChannelInternal(ColorChannel.Green, value, true);
    }

    [Category("Behavior"), DefaultValue(0)]
    public int Blue
    {
        get => _blue;
        set => SetChannelInternal(ColorChannel.Blue, value, true);
    }

    /// <summary>Current color expanded to 8 bit per channel.</summary>
    [Browsable(false)]
    public Color SelectedColor =>
        Color.FromArgb(Expand5To8(_red), Expand5To8(_green), Expand5To8(_blue));

    public event EventHandler ValueChanged;
    public event EventHandler ValueCommitted;

    public void SetColor(int red, int green, int blue)
    {
        SetChannelInternal(ColorChannel.Red, red, false);
        SetChannelInternal(ColorChannel.Green, green, false);
        SetChannelInternal(ColorChannel.Blue, blue, false);
    }

    private static int Expand5To8(int v) => (v << 3) | (v >> 2);

    private int GetChannel(ColorChannel c) =>
        c switch
        {
            ColorChannel.Red => _red,
            ColorChannel.Green => _green,
            _ => _blue
        };

    private void SetChannelInternal(ColorChannel c, int value, bool raise)
    {
        value = Math.Clamp(value, 0, MaxValue);
        if (GetChannel(c) == value) return;

        switch (c)
        {
            case ColorChannel.Red:
                _red = value;
                break;
            case ColorChannel.Green:
                _green = value;
                break;
            default:
                _blue = value;
                break;
        }

        MarkDirty();
        if (raise && c == _channel) OnValueChanged(EventArgs.Empty);
    }

    protected virtual void OnValueChanged(EventArgs e) =>
        ValueChanged?.Invoke(this, e);

    protected virtual void OnValueCommitted(EventArgs e) =>
        ValueCommitted?.Invoke(this, e);

    private void MarkDirty()
    {
        _dirty = true;
        Invalidate();
    }

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
            Math.Max(width, _markerWidth),
            Math.Max(height, _minBarHeight),
            specified
        );
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        _dirty = true;
    }

    // --- input --------------------------------------------------------

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button != MouseButtons.Left) return;
        Focus();
        _dragging = true;
        ValueFromX(e.X);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (_dragging) ValueFromX(e.X);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        if (!_dragging) return;
        _dragging = false;
        OnValueCommitted(EventArgs.Empty);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        int step = e.Control ? 4 : 1;
        switch (e.KeyCode)
        {
            case Keys.Left:
                Value -= step;
                e.Handled = true;
                break;
            case Keys.Right:
                Value += step;
                e.Handled = true;
                break;
            case Keys.Home:
                Value = 0;
                e.Handled = true;
                break;
            case Keys.End:
                Value = MaxValue;
                e.Handled = true;
                break;
        }
        if (e.Handled) OnValueCommitted(EventArgs.Empty);
    }

    protected override bool IsInputKey(Keys keyData) =>
        keyData is Keys.Left or Keys.Right or Keys.Home or Keys.End
            || base.IsInputKey(keyData);

    /// <summary>Maps a pixel x to a value using segment centers.</summary>
    private void ValueFromX(int x)
    {
        int w = Math.Max(1, Width);
        x = Math.Clamp(x, 0, w - 1);
        Value = x * Levels / w;
    }

    // --- rendering ----------------------------------------------------

    protected override void OnPaint(PaintEventArgs e)
    {
        if (Width <= 0 || Height <= 0) return;
        if (
            _dirty
            || _cache == null
            || _cache.Width != Width
            || _cache.Height != Height
        )
        {
            _cache?.Dispose();
            _cache = Render(Width, Height);
            _dirty = false;
        }
        e.Graphics.DrawImageUnscaled(_cache, 0, 0);
    }

    private Bitmap Render(int width, int height)
    {
        Bitmap bmp = new Bitmap(width, height, PixelFormat.Format32bppRgb);
        BitmapData data = bmp.LockBits(
            new Rectangle(0, 0, width, height),
            ImageLockMode.WriteOnly,
            bmp.PixelFormat
        );

        // 5 bit channels expanded to 8 bit positions 23..16 / 15..8 / 7..0
        int r8 = Expand5To8(_red);
        int g8 = Expand5To8(_green);
        int b8 = Expand5To8(_blue);

        int baseColor = _channel switch
        {
            ColorChannel.Red => (g8 << 8) | b8,
            ColorChannel.Green => (r8 << 16) | b8,
            _ => (r8 << 16) | (g8 << 8)
        };
        int shift = _channel switch
        {
            ColorChannel.Red => 16,
            ColorChannel.Green => 8,
            _ => 0
        };

        int stride = data.Stride / 4;
        byte* rowBase = (byte*)data.Scan0;
        int* row0 = (int*)rowBase;

        for (int x = 0; x < width; x++)
        {
            int level = x * Levels / width; // 0..31, no wrap
            row0[x] = baseColor | (Expand5To8(level) << shift);
        }

        long rowBytes = (long)width * 4;
        for (int y = 1; y < height; y++)
        {
            Buffer.MemoryCopy(
                rowBase,
                rowBase + (long)y * data.Stride,
                rowBytes,
                rowBytes
            );
        }

        DrawMarker(data, stride, width, height);

        bmp.UnlockBits(data);
        return bmp;
    }

    private void DrawMarker(BitmapData data, int stride, int width, int height)
    {
        int value = GetChannel(_channel);

        // center marker on the middle of the value's segment
        int segStart = value * width / Levels;
        int segEnd = (value + 1) * width / Levels;
        int center = (segStart + segEnd) / 2;
        int start = Math.Clamp(
            center - _markerWidth / 2,
            0,
            Math.Max(0, width - _markerWidth)
        );
        int end = Math.Min(width, start + _markerWidth);

        int border = _borderColor.ToArgb() & 0xFFFFFF;
        int fill = _markerColor.ToArgb() & 0xFFFFFF;
        int* ptr = (int*)data.Scan0;

        for (int y = 0; y < height; y++)
        {
            int* p = ptr + y * stride;
            bool edgeRow = y == 0 || y == height - 1;
            for (int x = start; x < end; x++)
            {
                bool edgeCol = x == start || x == end - 1;
                p[x] = edgeRow || edgeCol ? border : fill;
            }
        }
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) _cache?.Dispose();
        base.Dispose(disposing);
    }
}
