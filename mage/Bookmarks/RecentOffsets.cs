using mage.Theming.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace mage.Bookmarks;

public static class RecentOffsets
{
    public static ContextMenuStrip Context { get; } = new ContextMenuStrip();
    public static FlatTextBox? ContextTextBox { get; set; } = null;

    static RecentOffsets()
    {
        Context.Opening += Context_Opening;
    }

    private static void Context_Opening(object? sender, System.ComponentModel.CancelEventArgs e)
    {
        if (ContextTextBox == null)
        {
            e.Cancel = true;
            return;
        }

        var ctx = sender as ContextMenuStrip;
        if (ctx == null) return;

        ctx.Items.Clear();
        foreach (KeyValuePair<string, int> kvp in Program.Config.RecentOffsets)
        {
            ToolStripMenuItem button = new();
            button.Text = kvp.Key;
            button.Tag = kvp.Value.ToString();
            button.Click += RecentOffsetButtonPressed;

            ctx.Items.Add(button);
        }
        if (ctx.Items.Count >= 1) ctx.Items.Add(new ToolStripSeparator());

        ToolStripMenuItem bookmarkButton = new();
        bookmarkButton.Text = "Choose Bookmark...";
        bookmarkButton.Click += BookmarkButton_Click;

        ctx.Items.Add(bookmarkButton);
    }

    private static void RecentOffsetButtonPressed(object? sender, EventArgs e)
    {
        if (sender == null) return;
        ToolStripMenuItem button = sender as ToolStripMenuItem;
        if (button == null) return;

        int value = 0;
        if (int.TryParse(button.Tag as string, out value))
        {
            ContextTextBox!.Text = Hex.ToString(value);
        }
    }

    private static void BookmarkButton_Click(object? sender, EventArgs e)
    {
        FormBookmarks dialog = new FormBookmarks(true);
        if (dialog.ShowDialog() != DialogResult.OK) return;

        TreeNode result = dialog.ResultValue;
        Bookmark bookmark = result.Tag as Bookmark;

        ContextTextBox!.Text = Hex.ToString(bookmark.Value);
        Config.AddRecentOffset(Program.Config, result.FullPath, bookmark.Value);
    }
}
