using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace mage.Warnings;

public class ErrorListPanel : UserControl
{
    private const int HeaderHeight = 24;
    private const int RowHeight = 20;
    private const int IconSize = 16;

    private readonly Panel _header = new();
    private readonly Label _title = new();
    private readonly ListView _list = new();

    private ClipdataError[] _items = Array.Empty<ClipdataError>();
    private bool _collapsed;
    private int _expandedHeight = 160;

    public event Action<ClipdataError>? ErrorActivated;

    public ErrorListPanel()
    {
        SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
        Height = _expandedHeight;

        // ThemeSwitcher.ChangeTheme walks every control recursively and, for any
        // ListView it finds (including this panel's internal _list), attaches its
        // own DrawItem/DrawSubItem handlers on top of ours. Since it runs after
        // InitializeComponent, its handlers fire last and paint blank subitem text
        // over what we already drew. This panel fully owns its own theming, so
        // opt the whole subtree out via the "unthemed" convention ThemeSwitcher checks for.
        Tag = "unthemed";

        _header.Dock = DockStyle.Top;
        _header.Height = HeaderHeight;
        _header.Cursor = Cursors.Hand;
        _header.Click += (_, _) => Collapsed = !Collapsed;

        _title.AutoSize = false;
        _title.Dock = DockStyle.Fill;
        _title.TextAlign = ContentAlignment.MiddleLeft;
        _title.Padding = new Padding(6, 0, 0, 0);
        _title.Click += (_, _) => Collapsed = !Collapsed;
        _header.Controls.Add(_title);

        _list.Dock = DockStyle.Fill;
        _list.View = View.Details;
        _list.VirtualMode = true;
        _list.OwnerDraw = true;
        _list.FullRowSelect = true;
        _list.MultiSelect = false;
        _list.HideSelection = false;
        _list.HeaderStyle = ColumnHeaderStyle.Nonclickable;
        _list.BorderStyle = BorderStyle.None;
        _list.VirtualListSize = 0;

        _list.Columns.Add("", 24);
        _list.Columns.Add("Position", 90);
        _list.Columns.Add("Rule", 160);
        _list.Columns.Add("Description", 400);

        _list.RetrieveVirtualItem += OnRetrieveVirtualItem;
        _list.DrawColumnHeader += OnDrawColumnHeader;
        _list.DrawItem += OnDrawItem;
        _list.DrawSubItem += OnDrawSubItem;
        _list.MouseDoubleClick += (_, _) => ActivateSelected();
        _list.KeyDown += (_, e) =>
        {
            if (e.KeyCode == Keys.Enter) ActivateSelected();
        };

        _list.ClientSizeChanged += (_, _) => AutoSizeLastColumn();
        _list.ColumnWidthChanged += (_, e) =>
        {
            if (e.ColumnIndex != _list.Columns.Count - 1) AutoSizeLastColumn();
        };

        Controls.Add(_list);
        Controls.Add(_header);
        ApplyTheme();
    }

    #region Theme

    [Category("Theme")] public Color HeaderBackColor { get; set; } = Color.FromArgb(45, 45, 48);
    [Category("Theme")] public Color HeaderForeColor { get; set; } = Color.Gainsboro;
    [Category("Theme")] public Color ListBackColor { get; set; } = Color.FromArgb(30, 30, 30);
    [Category("Theme")] public Color RowForeColor { get; set; } = Color.Gainsboro;
    [Category("Theme")] public Color AlternateRowBackColor { get; set; } = Color.FromArgb(35, 35, 38);
    [Category("Theme")] public Color SelectedRowBackColor { get; set; } = Color.FromArgb(38, 79, 120);
    [Category("Theme")] public Color SelectedRowForeColor { get; set; } = Color.White;
    [Category("Theme")] public Color GridLineColor { get; set; } = Color.FromArgb(50, 50, 53);
    [Category("Theme")] public Color OutlineColor { get; set; } = Color.FromArgb(63, 63, 70);

    /// <summary>Placeholder — assign your warning glyph.</summary>
    [Category("Theme")] public Image? WarningIcon { get; set; }

    public void ApplyTheme()
    {
        _header.BackColor = HeaderBackColor;
        _title.ForeColor = HeaderForeColor;
        _list.BackColor = ListBackColor;
        _list.ForeColor = RowForeColor;
        Padding = new Padding(1);
        Invalidate(true);
        _list.Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        using var pen = new Pen(OutlineColor);
        var r = ClientRectangle;
        r.Width -= 1; r.Height -= 1;
        e.Graphics.DrawRectangle(pen, r);
    }

    #endregion

    #region Data

    /// <summary>Hook this to RuleValidator.ErrorsChanged.</summary>
    public void SetSource(RuleValidator validator)
    {
        validator.ErrorsChanged -= OnErrorsChanged;
        validator.ErrorsChanged += OnErrorsChanged;
        OnErrorsChanged(validator);
    }

    private void OnErrorsChanged(RuleValidator validator)
    {
        if (InvokeRequired) { BeginInvoke(() => OnErrorsChanged(validator)); return; }
        SetErrors(validator.Errors);
    }

    private bool _suppressActivate;

    public void SetErrors(IReadOnlyDictionary<(int x, int y), List<ClipdataError>> errors)
    {
        _items = errors
            .OrderBy(kv => kv.Key.y)
            .ThenBy(kv => kv.Key.x)
            .SelectMany(kv => kv.Value)
            .ToArray();

        _suppressActivate = true;
        try
        {
            _list.BeginUpdate();
            _list.SelectedIndices.Clear();
            _list.VirtualListSize = _items.Length;
            _list.EndUpdate();
            _list.Invalidate();
        }
        finally { _suppressActivate = false; }

        AutoSizeLastColumn();
        _list.Invalidate();

        UpdateTitle();
    }

    private void OnRetrieveVirtualItem(object? sender, RetrieveVirtualItemEventArgs e)
    {
        e.Item = new ListViewItem(new string[4]);
    }

    private void ActivateSelected()
    {
        if (_suppressActivate) return;
        if (_list.SelectedIndices.Count == 0) return;
        int i = _list.SelectedIndices[0];
        if (i < 0 || i >= _items.Length) return;

        _suppressActivate = true;
        try { ErrorActivated?.Invoke(_items[i]); }
        finally { _suppressActivate = false; }
    }

    #endregion

    #region Collapse

    [Category("Behavior")]
    public bool Collapsed
    {
        get => _collapsed;
        set
        {
            if (_collapsed == value) return;
            if (value) _expandedHeight = Height;
            _collapsed = value;
            _list.Visible = !value;
            Height = value ? HeaderHeight + 2 : _expandedHeight;
            UpdateTitle();
        }
    }

    #endregion

    #region Drawing

    private void UpdateTitle() =>
    _title.Text =
        $"{(_collapsed ? "▶" : "▼")}  {_items.Length} " +
        $"Issue{(_items.Length == 1 ? "" : "s")}";

    private void OnDrawColumnHeader(object? sender, DrawListViewColumnHeaderEventArgs e)
    {
        using var bg = new SolidBrush(HeaderBackColor);
        e.Graphics.FillRectangle(bg, e.Bounds);
        using var line = new Pen(OutlineColor);
        e.Graphics.DrawLine(line, e.Bounds.Right - 1, e.Bounds.Top,
            e.Bounds.Right - 1, e.Bounds.Bottom - 1);
        e.Graphics.DrawLine(line, e.Bounds.Left, e.Bounds.Bottom - 1,
            e.Bounds.Right, e.Bounds.Bottom - 1);

        TextRenderer.DrawText(e.Graphics, e.Header!.Text, Font,
            Rectangle.Inflate(e.Bounds, -6, 0), HeaderForeColor,
            TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
    }

    private void OnDrawItem(object? sender, DrawListViewItemEventArgs e)
    {
        if (e.ItemIndex < 0 || e.ItemIndex >= _items.Length) return;
        bool selected = (e.State & ListViewItemStates.Selected) != 0;

        Color back = selected
            ? SelectedRowBackColor
            : (e.ItemIndex % 2 == 0 ? ListBackColor : AlternateRowBackColor);

        using (var bg = new SolidBrush(back))
            e.Graphics.FillRectangle(bg, e.Bounds);

        using (var grid = new Pen(GridLineColor))
            e.Graphics.DrawLine(grid, e.Bounds.Left, e.Bounds.Bottom - 1,
                e.Bounds.Right, e.Bounds.Bottom - 1);
    }

    private void OnDrawSubItem(object? sender, DrawListViewSubItemEventArgs e)
    {
        if (e.ItemIndex < 0 || e.ItemIndex >= _items.Length) return;
        var err = _items[e.ItemIndex];

        bool selected = (e.ItemState & ListViewItemStates.Selected) != 0;
        Color fore = selected ? SelectedRowForeColor : RowForeColor;

        // e.Item.Bounds is unreliable in virtual mode (the item isn't actually
        // attached to the control), so it resolves to an empty rect and text
        // silently fails to draw. Use e.Bounds instead — but for column 0, WinForms
        // reports the *entire row's* bounds rather than just that column's, so clamp it.
        Rectangle cellBounds = e.ColumnIndex == 0
            ? new Rectangle(e.Bounds.Left, e.Bounds.Top, _list.Columns[0].Width, e.Bounds.Height)
            : e.Bounds;

        switch (e.ColumnIndex)
        {
            case 0:
                if (WarningIcon is not null)
                {
                    e.Graphics.DrawImage(WarningIcon,
                        new Rectangle(
                            cellBounds.Left + (cellBounds.Width - IconSize) / 2,
                            cellBounds.Top + (cellBounds.Height - IconSize) / 2,
                            IconSize, IconSize));
                }
                break;
            case 1:
                DrawCell(e.Graphics, cellBounds, $"({err.X}, {err.Y})", fore);
                break;
            case 2:
                DrawCell(e.Graphics, cellBounds, err.Rule?.Name ?? string.Empty, fore);
                break;
            case 3:
                DrawCell(e.Graphics, cellBounds, err.Message, fore);
                break;
        }
    }

    private void DrawCell(Graphics g, Rectangle bounds, string text, Color fore)
    {
        bounds.Inflate(-4, 0);
        TextRenderer.DrawText(g, text, Font, bounds, fore,
            TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis
            | TextFormatFlags.NoPrefix);
    }

    private void AutoSizeLastColumn()
    {
        if (_list.Columns.Count == 0) return;

        int fixedWidth = 0;
        for (int i = 0; i < _list.Columns.Count - 1; i++)
            fixedWidth += _list.Columns[i].Width;

        // ClientSize already excludes the scrollbar once it appears,
        // but it lags by one layout pass in virtual mode — compute it.
        int avail = _list.ClientSize.Width;
        bool scroll = _list.VirtualListSize * RowHeight > _list.ClientSize.Height;
        if (scroll && _list.ClientSize.Width == _list.Width)
            avail -= SystemInformation.VerticalScrollBarWidth;

        int last = Math.Max(60, avail - fixedWidth);
        if (_list.Columns[^1].Width != last)
            _list.Columns[^1].Width = last;
    }
    #endregion
}
