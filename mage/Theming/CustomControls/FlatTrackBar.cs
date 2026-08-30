using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace mage.Theming.CustomControls;

[DesignerCategory("Code")]
public class FlatTrackBar : Control, ISupportInitialize
{
    private int minimum = 0;
    private int maximum = 10;
    private int value = 0;
    private int smallChange = 1;
    private int largeChange = 5;
    private bool dragging;

    private bool initializing;

    public void BeginInit() => initializing = true;

    public void EndInit()
    {
        initializing = false;
        Value = value; // re-clamp now that Min/Max are set
        Invalidate();
    }

    public FlatTrackBar()
    {
        SetStyle(
            ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw
                | ControlStyles.UserPaint
                | ControlStyles.Selectable,
            true);
        Height = 24;
        TabStop = true;
    }

    public event EventHandler ValueChanged;

    [DefaultValue(0)]
    public int Minimum
    {
        get => minimum;
        set { minimum = value; Value = this.value; Invalidate(); }
    }

    [DefaultValue(10)]
    public int Maximum
    {
        get => maximum;
        set { maximum = value; Value = this.value; Invalidate(); }
    }

    [DefaultValue(0)]
    public int Value
    {
        get => value;
        set
        {
            int clamped = Math.Clamp(value, minimum, Math.Max(minimum, maximum));
            if (clamped == this.value) return;
            this.value = clamped;
            if (!initializing) ValueChanged?.Invoke(this, EventArgs.Empty);
            Invalidate();
        }
    }

    [DefaultValue(1)]
    public int SmallChange { get => smallChange; set => smallChange = value; }

    [DefaultValue(5)]
    public int LargeChange { get => largeChange; set => largeChange = value; }

    // Theme hooks — assign these from ChangeTheme
    public Color TrackColor { get; set; } = Color.Gray;
    public Color FillColor { get; set; } = Color.DodgerBlue;
    public Color ThumbColor { get; set; } = Color.White;
    public Color BorderColor { get; set; } = Color.DimGray;

    public int ThumbWidth { get; set; } = 10;
    public int TrackHeight { get; set; } = 4;

    private int Range => Math.Max(1, maximum - minimum);

    private Rectangle ThumbRect
    {
        get
        {
            int usable = Width - ThumbWidth;
            int x = (int)((value - minimum) / (float)Range * usable);
            return new Rectangle(x, 0, ThumbWidth, Height);
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        var g = e.Graphics;
        g.Clear(BackColor);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        int cy = Height / 2;
        var track = new Rectangle(
            ThumbWidth / 2,
            cy - TrackHeight / 2,
            Width - ThumbWidth,
            TrackHeight);

        var thumb = ThumbRect;
        thumb.Inflate(0, -3);

        using (var b = new SolidBrush(TrackColor))
            g.FillRectangle(b, track);

        //var filled = track with { Width = thumb.X + thumb.Width / 2 - track.X };
        //if (filled.Width > 0)
        //{
        //    using var b = new SolidBrush(FillColor);
        //    g.FillRectangle(b, filled);
        //}

        using (var b = new SolidBrush(ThumbColor))
            g.FillRectangle(b, thumb);
        using (var p = new Pen(BorderColor))
            g.DrawRectangle(p, thumb);
    }

    private void SetValueFromMouse(int mouseX)
    {
        int usable = Math.Max(1, Width - ThumbWidth);
        float pos = (mouseX - ThumbWidth / 2f) / usable;
        Value = minimum + (int)Math.Round(pos * Range);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);
        if (e.Button != MouseButtons.Left) return;
        Focus();
        dragging = true;
        SetValueFromMouse(e.X);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        base.OnMouseMove(e);
        if (dragging) SetValueFromMouse(e.X);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        base.OnMouseUp(e);
        dragging = false;
    }

    protected override void OnMouseWheel(MouseEventArgs e)
    {
        base.OnMouseWheel(e);
        Value += Math.Sign(e.Delta) * smallChange;
    }

    protected override bool IsInputKey(Keys keyData) =>
        keyData is Keys.Left or Keys.Right or Keys.Home or Keys.End
            or Keys.PageUp or Keys.PageDown || base.IsInputKey(keyData);

    protected override void OnKeyDown(KeyEventArgs e)
    {
        base.OnKeyDown(e);
        switch (e.KeyCode)
        {
            case Keys.Left: Value -= smallChange; break;
            case Keys.Right: Value += smallChange; break;
            case Keys.PageDown: Value -= largeChange; break;
            case Keys.PageUp: Value += largeChange; break;
            case Keys.Home: Value = minimum; break;
            case Keys.End: Value = maximum; break;
            default: return;
        }
        e.Handled = true;
    }

    protected override void OnGotFocus(EventArgs e) { base.OnGotFocus(e); Invalidate(); }
    protected override void OnLostFocus(EventArgs e) { base.OnLostFocus(e); Invalidate(); }
}
