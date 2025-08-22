using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Bookmarks;

public partial class BookmarkCopyDialog : Form
{
    public struct BookmarkCopyDialogResult
    {
        public ListBox GoalListBox;
        public List<BookmarkFolder> GoalCollections;
        public bool CreateNewCollection;
        public BookmarkFolder SelectedCollection;
        public bool IncludePath;
    }

    public BookmarkCopyDialogResult CopyDialogResult;
    private FormBookmarks Parent;

    public BookmarkCopyDialog(BookmarkItem sourceItem, FormBookmarks parent)
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(this.Controls, this);
        ThemeSwitcher.InjectPaintOverrides(this.Controls);

        Parent = parent;

        // Set label
        if (sourceItem is BookmarkFolder folder) label_bookmarkName.Text = $"Folder: {folder.Name} ({folder.CountBookmarks()})";
        if (sourceItem is Bookmark) label_bookmarkName.Text = $"Bookmark: {sourceItem.Name}";

        radio_project.Checked = true;
        radio_createCollection.Checked = true;

        radio_global.Enabled = parent.LastCollectionUsed.Box != parent.listbox_globalCollections;
        if (parent.LastCollectionUsed.Box == parent.listbox_projectCollections)
        {
            radio_project.Enabled = false;
            radio_global.Checked = true;
        }
    }

    private void button_ok_Click(object sender, EventArgs e)
    {
        // Get selected collection from listbox
        BookmarkFolder selectedCollection = null;
        List<BookmarkFolder> collectionSource = radio_global.Checked ? BookmarkManager.GlobalCollections : BookmarkManager.ProjectCollections;
        if (list_collections.SelectedIndex != -1) selectedCollection = collectionSource[list_collections.SelectedIndex];

        CopyDialogResult = new()
        {
            GoalListBox = radio_global.Checked ? Parent.listbox_globalCollections : Parent.listbox_projectCollections,
            GoalCollections = collectionSource,
            CreateNewCollection = radio_createCollection.Checked,
            SelectedCollection = selectedCollection,
            IncludePath = checkbox_includePath.Checked
        };

        DialogResult = DialogResult.OK;
        Close();
    }

    private void button_cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void radio_global_CheckedChanged(object sender, EventArgs e)
    {
        List<BookmarkFolder> collectionsSource = BookmarkManager.ProjectCollections;
        if (radio_global.Checked) collectionsSource = BookmarkManager.GlobalCollections;

        list_collections.Items.Clear();
        foreach (BookmarkFolder collection in collectionsSource) list_collections.Items.Add(collection.Name);
    }

    private void radio_createCollection_CheckedChanged(object sender, EventArgs e)
    {
        list_collections.Enabled = radio_addToExisting.Checked;
    }
}
