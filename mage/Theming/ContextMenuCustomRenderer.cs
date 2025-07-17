using System.Drawing;
using System.Windows.Forms;

namespace mage.Theming;

public sealed class ContextMenuCustomRenderer : ToolStripProfessionalRenderer
{
    private readonly ColorTheme _theme = ThemeSwitcher.ProjectTheme;

    public ContextMenuCustomRenderer() : base(new ThemedColorTable()) { }

    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
        var g = e.Graphics;
        var bounds = new Rectangle(Point.Empty, e.Item.Size);

        if (e.Item.Selected && e.Item.Enabled)
        {
            using var brush = new SolidBrush(_theme.AccentColor);
            g.FillRectangle(brush, bounds);
        }
        else
        {
            using var brush = new SolidBrush(_theme.BackgroundColor);
            g.FillRectangle(brush, bounds);
        }
    }

    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
        e.TextColor = e.Item.Enabled
            ? (e.Item.Selected ? _theme.TextColorHighlight : _theme.TextColor)
            : _theme.TextColorDisabled;
        base.OnRenderItemText(e);
    }

    protected override void OnRenderItemCheck(ToolStripItemImageRenderEventArgs e)
    {
        // simple check-mark drawn with accent color
        if (e.Item is ToolStripMenuItem item && item.Checked)
        {
            using var pen = new Pen(_theme.AccentColor, 2);
            var g = e.Graphics;
            g.DrawLines(pen, new[]
            {
                new Point(e.ImageRectangle.Left + 2, e.ImageRectangle.Top + 5),
                new Point(e.ImageRectangle.Left + 5, e.ImageRectangle.Top + 8),
                new Point(e.ImageRectangle.Left + 9, e.ImageRectangle.Top + 3)
            });
        }
    }

    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
        using var pen = new Pen(_theme.SecondaryOutline);
        var y = e.Item.Height / 2;
        e.Graphics.DrawLine(pen, 2, y, e.Item.Width - 2, y);
    }

    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
        using var pen = new Pen(_theme.PrimaryOutline);
        e.Graphics.DrawRectangle(pen, 0, 0, e.AffectedBounds.Width - 1, e.AffectedBounds.Height - 1);
    }

    private sealed class ThemedColorTable : ProfessionalColorTable
    {
        private readonly ColorTheme _theme = ThemeSwitcher.ProjectTheme;

        public override Color MenuBorder => _theme.PrimaryOutline;
        public override Color MenuItemBorder => _theme.SecondaryOutline;
        public override Color MenuItemSelected => _theme.AccentColor;
        public override Color MenuItemSelectedGradientBegin => _theme.AccentColor;
        public override Color MenuItemSelectedGradientEnd => _theme.AccentColor;
        public override Color MenuStripGradientBegin => _theme.BackgroundColor;
        public override Color MenuStripGradientEnd => _theme.BackgroundColor;
        public override Color ToolStripDropDownBackground => _theme.BackgroundColor;
        public override Color ImageMarginGradientBegin => _theme.BackgroundColor;
        public override Color ImageMarginGradientMiddle => _theme.BackgroundColor;
        public override Color ImageMarginGradientEnd => _theme.BackgroundColor;
    }
}
