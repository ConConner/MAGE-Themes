using mage.Bookmarks;
using mage.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Versioning;
using System.Windows.Forms;

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

    private bool hexSanitized = false;
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Behavior")]
    [Description("Enables hex/decimal sanitization for this text box.")]
    public bool HexSanitized
    {
        get => hexSanitized;
        set
        {
            hexSanitized = value;
            if (value)
            {
                textBox.KeyPress += textBoxKeyPress_HexSanitized;
                textBox.TextChanged += textBoxTextChanged_HexSanitized;
            }
            else
            {
                textBox.KeyPress -= textBoxKeyPress_HexSanitized;
                textBox.TextChanged -= textBoxTextChanged_HexSanitized;
            }
        }
    }
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Behavior")]
    [Description("Maximum allowed numeric value for sanitized input.")]
    public int HexSanitizedMaxValue { get; set; } = -1;

    #endregion

    #region events
    [Browsable(true)]
    [EditorBrowsable(EditorBrowsableState.Always)]
    [Category("Behavior")]
    [Description("Occurs when the text is changed.")]
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


    private void textBoxKeyPress_HexSanitized(object sender, KeyPressEventArgs e)
    {   //sanitize input to only allow hex characters, and convert lowercase to uppercase on the fly
        char c = e.KeyChar;

        if (char.IsControl(c))
            return;

        if (char.IsDigit(c))
            return;

        if (c >= 'A' && c <= 'F')
            return;

        if (c >= 'a' && c <= 'f')
        {
            e.KeyChar = char.ToUpper(c);
            return;
        }

        e.Handled = true;
    }

    private bool _sanitizing = false;

    private void textBoxTextChanged_HexSanitized(object sender, EventArgs e)
    {
        if (_sanitizing)
            return;

        _sanitizing = true;

        string raw = textBox.Text.ToUpper();

        // Filter invalid characters
        string filtered = new string(raw.Where(c =>
            char.IsDigit(c) ||
            (c >= 'A' && c <= 'F')
        ).ToArray());

        // If filtering changed the text, update it
        if (filtered != raw)
        {
            int pos = textBox.SelectionStart;
            textBox.Text = filtered;
            textBox.SelectionStart = Math.Min(pos, textBox.Text.Length);
            raw = filtered;
        }

        if (raw.Length > 0)
        {
            bool containsHexLetters = raw.Any(c => c >= 'A' && c <= 'F');
            int value;

            if (Hex.radix == 10 && !containsHexLetters)
            {
                if (int.TryParse(raw, out value))
                {
                    if (HexSanitizedMaxValue >= 0 && value > HexSanitizedMaxValue)
                    {
                        value = HexSanitizedMaxValue;
                        textBox.Text = value.ToString("X");
                        textBox.SelectionStart = textBox.Text.Length;
                    }
                }
            }
            else
            {
                if (int.TryParse(raw, System.Globalization.NumberStyles.HexNumber, null, out value))
                {
                    if (value > HexSanitizedMaxValue)
                    {
                        value = HexSanitizedMaxValue;
                        textBox.Text = value.ToString("X");
                        textBox.SelectionStart = textBox.Text.Length;
                    }
                }
            }
        }

        _sanitizing = false;

        // Fire the public TextChanged event
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
