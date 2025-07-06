using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Bookmarks;

public partial class FormBookmarks : Form
{
    private List<BookmarkFolder> Collections = BookmarkManager.TestBookmarks;
    public Bookmark DialogResult = null;
    private bool isDialog = false;
    Subject<string> searchSubject;

    public FormBookmarks(bool isDialog = false)
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(this.Controls, this);
        ThemeSwitcher.InjectPaintOverrides(this.Controls);

        // Handling Search textbox
        textBox_search.TextChanged += TextBox_search_TextChanged;
        textBox_search.PlaceholderText = "Search...";
        searchSubject = new Subject<string>();
        searchSubject
            .Throttle(TimeSpan.FromMilliseconds(500))
            .Subscribe(doSearch);

        this.isDialog = isDialog;
        if (isDialog) HandleDialog();

        tree_bookmarks.Nodes.Clear();
        LoadColletions();
    }

    
    private void LoadColletions()
    {
        listbox_collections.Items.Clear();
        foreach (BookmarkFolder collection in Collections)
        {
            listbox_collections.Items.Add(collection.Name);
        }
    }

    private void AddCollection(BookmarkFolder collection)
    {
        string originalName = collection.Name;
        int duplicate = 0;
        while (listbox_collections.Items.Contains(collection.Name))
        {
            duplicate++;
            collection.Name = originalName + duplicate;
        }

        Collections.Add(collection);
        LoadColletions();
    }

    private void listbox_collections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listbox_collections.SelectedIndex == -1) return;
        BookmarkFolder collection = Collections[listbox_collections.SelectedIndex];
        LoadBookmarksFromCollection(collection);
        DisplayBookmarkDetails(collection);
    }


    private void LoadBookmarksFromCollection(BookmarkFolder collection, string searchString = "")
    {
        tree_bookmarks.Nodes.Clear();
        group_details.Enabled = false;
        textBox_name.Text = String.Empty;
        textBox_description.Text = String.Empty;
        textBox_value.Text = String.Empty;

        foreach (BookmarkItem item in collection.Items) AddNodesFromFolderRecursive(item, tree_bookmarks.Nodes, searchString);
        tree_bookmarks.ExpandAll();
    }

    private void AddNodesFromFolderRecursive(BookmarkItem item, TreeNodeCollection rootNode, string searchString = "")
    {
        bool doSearch = searchString != "";
        TreeNode itemNode = null;

        if (item is BookmarkFolder)
        {
            BookmarkFolder folder = item as BookmarkFolder;
            itemNode = new(folder.Name, 0, 0);
            itemNode.Tag = folder;

            foreach (BookmarkItem bmi in folder.Items) AddNodesFromFolderRecursive(bmi, itemNode.Nodes, searchString);

            if (doSearch && (itemNode.Nodes.Count < 1 && !itemNode.Text.Contains(searchString))) return;
        }

        if (item is Bookmark)
        {
            Bookmark bm = item as Bookmark;
            itemNode = new(bm.Name, 1, 1);
            itemNode.Tag = bm;

            if (doSearch && !itemNode.Text.Contains(searchString)) return;
        }

        rootNode.Add(itemNode);
    }

    private void tree_bookmarks_AfterSelect(object sender, TreeViewEventArgs e)
    {
        DisplayBookmarkDetails(tree_bookmarks.SelectedNode.Tag as BookmarkItem);
    }


    private void TextBox_search_TextChanged(object? sender, EventArgs e) => searchSubject.OnNext(textBox_search.Text);

    private void doSearch(string searchString)
    {
        if (listbox_collections.InvokeRequired)
        {
            listbox_collections.Invoke(new System.Action(() => doSearch(searchString)));
            return;
        }

        if (listbox_collections.SelectedIndex == -1 || listbox_collections.SelectedIndex >= Collections.Count) return;
        BookmarkFolder collection = Collections[listbox_collections.SelectedIndex];
        if (collection == null) return;

        LoadBookmarksFromCollection(collection, searchString);
    }

    private void DisplayBookmarkDetails(BookmarkItem item)
    {
        group_details.Enabled = true;
        textBox_value.Enabled = false;
        textBox_value.Text = String.Empty;

        textBox_name.Text = item.Name;
        textBox_description.Text = item.Description;

        if (item is not Bookmark) return;
        textBox_value.Enabled = true;
        textBox_value.Text = Hex.ToString((item as Bookmark).Value);
    }


    #region Dialog
    private void HandleDialog()
    {
        Text = "Select Bookmark";
        statusStrip1.Visible = false;
    }
    private void tree_bookmarks_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (!isDialog || tree_bookmarks.SelectedNode == null) return;
        if (tree_bookmarks.SelectedNode.Tag is not Bookmark) return;

        DialogResult = tree_bookmarks.SelectedNode.Tag as Bookmark;
        Close();
    }
    #endregion


    #region export/import
    private void button_export_Click(object sender, EventArgs e)
    {
        if (listbox_collections.SelectedIndex == -1)
        {
            MessageBox.Show("No bookmark collection selected", "Select Collection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        BookmarkFolder collection = Collections[listbox_collections.SelectedIndex];

        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "MAGE Bookmark Collection (*.mbc)|*.mbc";
        dialog.FileName = collection.Name;
        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            //convert key pair to json object
            string data = BookmarkManager.Serialize(collection);
            File.WriteAllText(dialog.FileName, data);
        }
    }

    private void button_import_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "MAGE Bookmark Collection (*.mbc)|*.mbc";
        if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
            if (!File.Exists(dialog.FileName)) return;
            string json = File.ReadAllText(dialog.FileName);
            try
            {
                BookmarkFolder collection = BookmarkManager.Deserialize(json);
                AddCollection(collection);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Collection import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    #endregion

    
}
