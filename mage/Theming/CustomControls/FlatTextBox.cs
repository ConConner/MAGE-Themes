using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Versioning;
using System.Drawing.Drawing2D;
using mage.Bookmarks;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;

namespace mage.Theming.CustomControls;

[SupportedOSPlatform("windows")]
public partial class FlatTextBox : UserControl
{
    #region Properties

    public override Color BackColor
    {
        get => textBox.BackColor;
        set
        {
            textBox.BackColor = value;
            base.BackColor = value;
        }
    }
    public bool Multiline
    {
        get => textBox.Multiline;
        set
        {
            textBox.Multiline = value;
        }
    }
    private Color borderColor = Color.Black;
    public Color BorderColor
    {
        get => borderColor;
        set
        {
            borderColor = value;
            Invalidate();
        }
    }
    public bool DisplayBorder { get; set; } = true;
    public override Color ForeColor { get => textBox.ForeColor; set => textBox.ForeColor = value; }
    public bool ReadOnly { get => textBox.ReadOnly; set => textBox.ReadOnly = value; }
    public new BorderStyle BorderStyle
    {
        get => (BorderStyle)base.BorderStyle;
        set
        {
            if (value == BorderStyle.None)
            {
                textBox.Location = new Point(0, 0);
                DisplayBorder = false;
            }
            else
            {
                textBox.Location = new Point(3, 3);
                DisplayBorder = true;
            }
            base.BorderStyle = BorderStyle.None;
        }
    }
    override public string Text { get => textBox.Text; set => textBox.Text = value; }
    public string PlaceholderText { get => textBox.PlaceholderText; set => textBox.PlaceholderText = value; }
    public int MaxLength { get => textBox.MaxLength; set => textBox.MaxLength = value; }
    public bool WordWrap { get => textBox.WordWrap; set => textBox.WordWrap = value; }
    public int SelectionStart { get => textBox.SelectionStart; set => textBox.SelectionStart = value; }
    public HorizontalAlignment TextAlign { get => textBox.TextAlign; set => textBox.TextAlign = value; }
    public ScrollBars ScrollBars { get => textBox.ScrollBars; set => textBox.ScrollBars = value; }
    public override bool Focused
    {
        get
        {
            if (textBox.Focused || base.Focused) return true;
            return false;
        }
    }

    public bool valueBox = false;
    public bool ValueBox
    {
        get => valueBox;
        set
        {
            valueBox = value;
            textBox.ContextMenuStrip = null;
            if (valueBox) textBox.ContextMenuStrip = new ContextMenuStrip();
        }
    }
    #endregion

    #region events
    public new event EventHandler TextChanged
    {
        add => OnTextChanged += value;
        remove => OnTextChanged -= value;
    }
    public EventHandler OnTextChanged { get; set; }

    private void textBoxTextChanged(object sender, EventArgs e)
    {
        OnTextChanged?.Invoke(this, e);
    }
    #endregion

    public FlatTextBox()
    {
        InitializeComponent();
    }

    #region methods
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        //Draw Border
        if (!DisplayBorder) return;

        Rectangle border = new Rectangle(Point.Empty, Size);
        border.Width--; border.Height--;
        Pen p = new Pen(BorderColor);
        e.Graphics.DrawRectangle(p, border);
        p.Dispose();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);

        int x = DisplayBorder ? 3 : 0;
        int y = 4;
        if (Multiline)
        {
            textBox.SetBounds(x, y,
                              ClientSize.Width - 2 * x,
                              ClientSize.Height - 2 * y);
        }
        else
        {
            Height = 23;
            textBox.SetBounds(x, y,
                              ClientSize.Width - 2 * x,
                              textBox.PreferredHeight);
        }

        if (Parent != null)
        {
            Rectangle r = Bounds;
            r.Inflate(2, 2);
            Parent.Invalidate(r, true);
        }
    }

    private void FlatTextBox_MouseDown(object sender, MouseEventArgs e)
    {
        textBox.Focus();
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
        if (!ValueBox || Text == "") return;
        int value = Hex.ToInt(Text);

        //TODO: Check here if value is a bookmark
        Config.AddRecentOffset(Program.Config, Text, value);
    }



    //Conversions
    public static implicit operator TextBox(FlatTextBox b) => b.textBox;

    #region Context Menu
    private void textBox_MouseUp(object sender, MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right || !ValueBox) return;
        RecentOffsets.ContextTextBox = this;
        RecentOffsets.Context.Show(this, new Point(0, this.Height));
    }

    #endregion
    #endregion
}
