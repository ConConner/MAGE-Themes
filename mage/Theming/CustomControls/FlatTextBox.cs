using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Versioning;
using System.Drawing.Drawing2D;
using mage.Bookmarks;
using System.Collections.Generic;

namespace mage.Theming.CustomControls;

[SupportedOSPlatform("windows")]
partial class FlatTextBox : UserControl
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

    public bool StoreValue { get; set; } = false;
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

    private ContextMenuStrip context;

    public FlatTextBox()
    {
        InitializeComponent();

        textBox.TextChanged += textBoxTextChanged;
        textBox.ContextMenuStrip = context = new ContextMenuStrip();
        context.Opening += Context_Opening;
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
    }

    protected override void OnSizeChanged(EventArgs e)
    {
        base.OnSizeChanged(e);

        if (Multiline) return;
        else Height = 23;
    }

    private void FlatTextBox_MouseDown(object sender, MouseEventArgs e)
    {
        textBox.Focus();
    }

    private void textBox_Leave(object sender, EventArgs e)
    {
        if (!StoreValue || Text == "") return;
        int value = Hex.ToInt(Text);

        //TODO: Check here if value is a bookmark
        Config.AddRecentOffset(Program.Config, Text, value);
    }

    //Conversions
    public static implicit operator TextBox(FlatTextBox b) => b.textBox;

    //Context Menu
    private void Context_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        context.Items.Clear();
        foreach (KeyValuePair<string, int> kvp in Program.Config.RecentOffsets)
        {
            ToolStripButton button = new();
            button.Text = kvp.Key;
            button.Tag = kvp.Value.ToString();
            button.Click += RecentOffsetButtonPressed;

            context.Items.Add(button);
        }
        if (context.Items.Count >= 1) context.Items.Add(new ToolStripSeparator());

        ToolStripButton bookmarkButton = new();
        bookmarkButton.Text = "Choose Bookmark...";
        bookmarkButton.Click += BookmarkButton_Click;

        context.Items.Add(bookmarkButton);
    }

    private void BookmarkButton_Click(object? sender, EventArgs e)
    {
        FormBookmarks dialog = new FormBookmarks(true);
        if (dialog.ShowDialog() != DialogResult.OK) return;

        TreeNode result = dialog.ResultValue;
        Bookmark bookmark = result.Tag as Bookmark;

        Text = Hex.ToString(bookmark.Value);
        Config.AddRecentOffset(Program.Config, result.FullPath, bookmark.Value);
    }

    private void RecentOffsetButtonPressed(object? sender, EventArgs e)
    {
        if (sender == null) return;
        ToolStripButton button = sender as ToolStripButton;
        if (button == null) return;

        int value = 0;
        if (int.TryParse(button.Tag as string, out value))
        {
            Text = Hex.ToString(value);
        }
    }

    #endregion
}
