using FuzzySharp;
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
    // Struct for keeping track of last selected values
    private struct CollectionBox
    {
        public ListBox Box;
        public int SelectedIndex;
    }

    private bool init = false;

    // Dialog Values
    public TreeNode ResultValue = null;
    private bool isDialog = false;
    
    private List<BookmarkFolder> CurrentCollections = BookmarkManager.InternalCollections;
    Subject<string> searchSubject;
    TreeNode SelectedTreeNode;
    BookmarkItem SelectedItem;

    // Last used Collection
    CollectionBox lastCollectionUsed = new() { Box = null, SelectedIndex = -1 }; 
    CollectionBox LastCollectionUsed
    {
        get => lastCollectionUsed;
        set
        {
            var old = lastCollectionUsed;
            lastCollectionUsed = value;

            if (value.Box != old.Box)
            {
                if (value.Box == listbox_internalCollections)
                {
                    Program.Config.BookmarkLastUsedCollection = Config.BookmarkCollection.Internal;
                    CurrentCollections = BookmarkManager.InternalCollections;
                }
                if (value.Box == listbox_globalCollections)
                {
                    Program.Config.BookmarkLastUsedCollection = Config.BookmarkCollection.Global;
                    CurrentCollections = BookmarkManager.GlobalCollections;
                }
                if (value.Box == listbox_projectCollections)
                {
                    Program.Config.BookmarkLastUsedCollection = Config.BookmarkCollection.Project;
                    CurrentCollections = BookmarkManager.ProjectCollections;
                }
            }

            if (value.SelectedIndex != -1 && value.SelectedIndex < value.Box.Items.Count)
            {
                BookmarkFolder collection = CurrentCollections[value.SelectedIndex];
                DisplayBookmarkDetails(collection);

                if (value.Box == old.Box && value.SelectedIndex == old.SelectedIndex) return;

                Program.Config.BookmarkLastUsedCollectionIndex = value.SelectedIndex;

                if ((value.SelectedIndex != old.SelectedIndex) || (value.Box != old.Box))
                {
                    value.Box.SelectedIndex = value.SelectedIndex;
                    PopulateTreeViewFromCollection(collection);
                }
            }
        }
    }

    //Config
    int expandDepth = 1;
    int ExpandDepth
    {
        get => expandDepth;
        set
        {
            expandDepth = value;
            Program.Config.BookmarkExpandDepth = value;

            allLayersToolStripMenuItem.Checked = false;
            Layer1ToolStripMenuItem.Checked = false;
            Layer2ToolStripMenuItem.Checked = false;
            layer3ToolStripMenuItem.Checked = false;
            layer4ToolStripMenuItem.Checked = false;

            switch (expandDepth)
            {
                case -1:
                    allLayersToolStripMenuItem.Checked = true;
                    break;
                case 0:
                    Layer1ToolStripMenuItem.Checked = true;
                    break;
                case 1:
                    Layer2ToolStripMenuItem.Checked = true;
                    break;
                case 2:
                    layer3ToolStripMenuItem.Checked = true;
                    break;
                case 3:
                    layer4ToolStripMenuItem.Checked = true;
                    break;
            }
        }
    }

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

        // Add events to other text input
        textBox_name.TextChanged += TextBox_name_TextChanged;
        textBox_description.TextChanged += TextBox_description_TextChanged;
        textBox_value.TextChanged += TextBox_value_TextChanged;

        group_details.Visible = false;

        this.isDialog = isDialog;
        if (isDialog) HandleDialog();

        tree_bookmarks.Nodes.Clear();
        LoadColletions();

        // Load Config
        ExpandDepth = Program.Config.BookmarkExpandDepth;
        LastCollectionUsed = new()
        {
            Box = FromBoxEnumToObject(Program.Config.BookmarkLastUsedCollection),
            SelectedIndex = Program.Config.BookmarkLastUsedCollectionIndex
        };
    }

    private ListBox FromBoxEnumToObject(Config.BookmarkCollection collection)
    {
        if (collection == Config.BookmarkCollection.Internal) return listbox_internalCollections;
        if (collection == Config.BookmarkCollection.Global) return listbox_globalCollections;
        if (collection == Config.BookmarkCollection.Project) return listbox_projectCollections;
        return null;
    }

    private void LoadColletions()
    {
        listbox_globalCollections.Items.Clear();
        listbox_internalCollections.Items.Clear();
        listbox_projectCollections.Items.Clear();

        foreach (BookmarkFolder collection in BookmarkManager.InternalCollections)
            listbox_internalCollections.Items.Add(collection.Name);
        foreach (BookmarkFolder collection in BookmarkManager.GlobalCollections)
            listbox_globalCollections.Items.Add(collection.Name);
        foreach (BookmarkFolder collection in BookmarkManager.ProjectCollections)
            listbox_projectCollections.Items.Add(collection.Name);
    }

    private void AddCollection(BookmarkFolder collection, ListBox collectionsBox, List<BookmarkFolder> goalCollections)
    {
        string originalName = collection.Name;
        int duplicate = 0;
        while (collectionsBox.Items.Contains(collection.Name))
        {
            duplicate++;
            collection.Name = originalName + duplicate;
        }

        goalCollections.Add(collection);
        LoadColletions();
    }


    private void listbox_internalCollections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listbox_internalCollections.SelectedIndex == -1) return;

        CurrentCollections = BookmarkManager.InternalCollections;
        LastCollectionUsed = new()
        {
            Box = listbox_internalCollections,
            SelectedIndex = listbox_internalCollections.SelectedIndex
        };

        listbox_globalCollections.SelectedIndex = -1;
        listbox_projectCollections.SelectedIndex = -1;

        selectedCollection();
    }
    private void listbox_globalCollections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listbox_globalCollections.SelectedIndex == -1) return;

        CurrentCollections = BookmarkManager.GlobalCollections;
        LastCollectionUsed = new()
        {
            Box = listbox_globalCollections,
            SelectedIndex = listbox_globalCollections.SelectedIndex
        };

        listbox_internalCollections.SelectedIndex = -1;
        listbox_projectCollections.SelectedIndex = -1;

        selectedCollection();
    }
    private void listbox_projectCollections_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listbox_projectCollections.SelectedIndex == -1) return;

        CurrentCollections = BookmarkManager.ProjectCollections;
        LastCollectionUsed = new()
        {
            Box = listbox_projectCollections,
            SelectedIndex = listbox_projectCollections.SelectedIndex
        };

        listbox_internalCollections.SelectedIndex = -1;
        listbox_globalCollections.SelectedIndex = -1;

        selectedCollection();
    }
    private void selectedCollection()
    {
        SelectedTreeNode = null;
        tree_bookmarks.SelectedNode = null;

        SelectedItem = CurrentCollections[LastCollectionUsed.Box.SelectedIndex];
    }


    private void PopulateTreeViewFromCollection(BookmarkFolder collection)
    {
        tree_bookmarks.BeginUpdate();

        tree_bookmarks.Nodes.Clear();
        foreach (BookmarkItem item in collection.Items) AddNodesFromFolderRecursive(item, tree_bookmarks.Nodes, "");

        tree_bookmarks.EndUpdate();
    }

    private void AddNodesFromFolderRecursive(BookmarkItem item, TreeNodeCollection rootNode, string pathName, int nestedLevel = 0)
    {
        string searchString = textBox_search.Text;
        bool doSearch = searchString != "";
        TreeNode itemNode = null;

        pathName += item.Name;

        if (item is BookmarkFolder)
        {
            BookmarkFolder folder = item as BookmarkFolder;
            itemNode = new(folder.Name, 0, 0);
            itemNode.Tag = folder;

            foreach (BookmarkItem bmi in folder.Items) AddNodesFromFolderRecursive(bmi, itemNode.Nodes, pathName, nestedLevel + 1);

            if (doSearch && (itemNode.Nodes.Count < 1)) return;
        }

        if (item is Bookmark)
        {
            Bookmark bm = item as Bookmark;
            itemNode = new(bm.Name, 1, 1);
            itemNode.Tag = bm;

            if (doSearch && !satisfiesSearch(pathName, searchString)) return;
        }

        rootNode.Add(itemNode);
        if (nestedLevel < expandDepth || expandDepth == -1) itemNode.Expand();
    }

    private void tree_bookmarks_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        tree_bookmarks.SelectedNode = e.Node;
    }

    private void tree_bookmarks_AfterSelect(object sender, TreeViewEventArgs e)
    {
        listbox_globalCollections.SelectedItem = null;
        SelectedTreeNode = e.Node;
        SelectedItem = e.Node.Tag as BookmarkItem;

        DisplayBookmarkDetails(tree_bookmarks.SelectedNode.Tag as BookmarkItem);
    }

    private void DisplayBookmarkDetails(BookmarkItem item)
    {
        init = true;

        group_details.Visible = true;
        group_details.Enabled = (LastCollectionUsed.Box != listbox_internalCollections);

        textBox_value.Visible = false;
        label_value.Visible = false;
        textBox_value.Text = String.Empty;

        textBox_name.Text = item.Name;
        textBox_description.Text = item.Description;

        if (item is not Bookmark)
        {
            init = false;
            return;
        }
        textBox_value.Visible = true;
        label_value.Visible = true;
        textBox_value.Text = Hex.ToString((item as Bookmark).Value);

        init = false;
    }


    #region Search
    private void TextBox_search_TextChanged(object? sender, EventArgs e) => searchSubject.OnNext(textBox_search.Text);

    private bool satisfiesSearch(string string1, string string2)
    {
        string1 = string1.ToLower().Trim();
        string2 = string2.ToLower().Trim();
        return Fuzz.PartialRatio(string1, string2) >= 70;
    }

    private void doSearch(string searchString)
    {
        if (LastCollectionUsed.Box.InvokeRequired)
        {
            LastCollectionUsed.Box.Invoke(new System.Action(() => doSearch(searchString)));
            return;
        }

        if (LastCollectionUsed.Box.SelectedIndex == -1 || LastCollectionUsed.Box.SelectedIndex >= CurrentCollections.Count) return;
        BookmarkFolder collection = CurrentCollections[LastCollectionUsed.Box.SelectedIndex];
        if (collection == null) return;

        PopulateTreeViewFromCollection(collection);
    }

    #endregion

    #region Edit Bookmarks
    private void TextBox_name_TextChanged(object? sender, EventArgs e)
    {
        if (init) return;
        if (SelectedTreeNode == null && SelectedItem == null) return;
        SelectedItem.Name = textBox_name.Text;

        if (SelectedTreeNode != null)
        {
            tree_bookmarks.BeginUpdate();
            SelectedTreeNode.Text = SelectedItem.Name;
            tree_bookmarks.EndUpdate();
        }
        if (LastCollectionUsed.Box != null && LastCollectionUsed.Box.SelectedIndex != -1)
        {
            LastCollectionUsed.Box.Items[LastCollectionUsed.Box.SelectedIndex] = SelectedItem.Name;
        }
    }

    private void TextBox_value_TextChanged(object? sender, EventArgs e)
    {
        if (init) return;
        if (LastCollectionUsed.Box != null) return;
        if (SelectedTreeNode == null && SelectedItem == null) return;
        (SelectedItem as Bookmark).Value = Hex.ToInt(textBox_value.Text);
    }

    private void TextBox_description_TextChanged(object? sender, EventArgs e)
    {
        if (init) return;
        if (SelectedTreeNode == null && SelectedItem == null) return;
        SelectedItem.Description = textBox_description.Text;
    }
    #endregion

    #region Dialog
    private void HandleDialog()
    {
        Text = "Select Bookmark";
        statusStrip1.Visible = false;
        newToolStripMenuItem.Visible = false;
    }
    private void tree_bookmarks_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        if (!isDialog || tree_bookmarks.SelectedNode == null) return;
        if (tree_bookmarks.SelectedNode.Tag is not Bookmark) return;

        ResultValue = tree_bookmarks.SelectedNode;
        DialogResult = DialogResult.OK;
        Close();
    }
    #endregion

    #region export/import
    private void button_export_Click(object sender, EventArgs e)
    {
        if (listbox_globalCollections.SelectedIndex == -1)
        {
            MessageBox.Show("No bookmark collection selected", "Select Collection", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }
        BookmarkFolder collection = CurrentCollections[LastCollectionUsed.Box.SelectedIndex];

        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "MAGE Bookmark Collection (*.mbc)|*.mbc";
        dialog.FileName = collection.Name;
        if (dialog.ShowDialog() == DialogResult.OK)
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
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            if (!File.Exists(dialog.FileName)) return;
            string json = File.ReadAllText(dialog.FileName);
            try
            {
                BookmarkFolder collection = BookmarkManager.Deserialize(json);
                AddCollection(collection, listbox_globalCollections, BookmarkManager.GlobalCollections);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Collection import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion


    #region MENU STRIP
    private void allLayersToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (sender == null) return;
        ToolStripMenuItem item = sender as ToolStripMenuItem;
        int depth = -1;
        if (int.TryParse(item.Tag as string, out depth)) ExpandDepth = depth;
    }
    #endregion
}
