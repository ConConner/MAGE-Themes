using FuzzySharp;
using mage.Options;
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
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Bookmarks;

public partial class FormBookmarks : Form, Editor
{
    // Struct for keeping track of last selected values
    public struct CollectionBox
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
    TreeNode ContextMenuTreeNode;
    BookmarkItem SelectedItem;

    // Last used Collection
    CollectionBox lastCollectionUsed = new() { Box = null, SelectedIndex = -1 };
    public CollectionBox LastCollectionUsed
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
            else if (value.SelectedIndex == -1)
            {
                tree_bookmarks.Nodes.Clear();
                Program.Config.BookmarkLastUsedCollectionIndex = value.SelectedIndex;
                DisplayBookmarkDetails(null);
            }
        }
    }
    BookmarkFolder CurrentSelectedCollection => CurrentCollections[LastCollectionUsed.SelectedIndex];
    bool AllowedToEdit => LastCollectionUsed.Box != listbox_internalCollections && !isDialog;

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

    public void UpdateEditor()
    {
        LoadColletions();
        if (LastCollectionUsed.SelectedIndex == -1) return;
        PopulateTreeViewFromCollection(CurrentCollections[LastCollectionUsed.SelectedIndex]);
    }

    public static void UpdateBookmarkEditor()
    {
        foreach (Form f in Application.OpenForms)
        {
            if (f is not FormBookmarks editor) continue;
            editor.UpdateEditor();
        }
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

    private TreeNode CreateBookmarkItemNode(BookmarkItem bookmarkItem)
    {
        int nodeImageIndex = bookmarkItem is BookmarkFolder ? 0 : 1;

        TreeNode itemNode = new(bookmarkItem.Name, nodeImageIndex, nodeImageIndex);
        itemNode.Tag = bookmarkItem;

        return itemNode;
    }

    private void AddNodesFromFolderRecursive(BookmarkItem item, TreeNodeCollection rootNode, string pathName, int nestedLevel = 0)
    {
        string searchString = textBox_search.Text;
        bool doSearch = searchString != "";
        TreeNode itemNode = CreateBookmarkItemNode(item);

        pathName += item.Name;

        if (item is BookmarkFolder)
        {
            BookmarkFolder folder = item as BookmarkFolder;
            foreach (BookmarkItem bmi in folder!.Items)
                AddNodesFromFolderRecursive(bmi, itemNode.Nodes, pathName, nestedLevel + 1);

            if (doSearch && (itemNode.Nodes.Count < 1)) return;
        }

        if (item is Bookmark && doSearch && !satisfiesSearch(pathName, searchString)) return;

        rootNode.Add(itemNode);
        if (nestedLevel < expandDepth || expandDepth == -1) itemNode.Expand();
    }

    private void tree_bookmarks_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
    {
        tree_bookmarks.SelectedNode = e.Node;
    }

    private void tree_bookmarks_MouseClick(object sender, MouseEventArgs e)
    {
        var hit = tree_bookmarks.HitTest(e.Location);

        if (e.Button == MouseButtons.Right)
        {
            ContextMenuTreeNode = hit.Node;
            button_createFolder.Enabled = AllowedToEdit;
            button_createBookmark.Enabled = AllowedToEdit;
            button_createCopy.Enabled = hit.Node != null && !isDialog;
            button_exportFolder.Enabled = hit.Node != null && hit.Node.Tag is BookmarkFolder;
            button_delete.Enabled = hit.Node != null && AllowedToEdit;
        }
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
        if (item == null)
        {
            init = true;
            group_details.Enabled = false;
            textBox_name.Text = String.Empty;
            textBox_description.Text = String.Empty;
            textBox_value.Text = String.Empty;
            init = false;
            return;
        }

        init = true;
        bool isBookmark = item is Bookmark;

        group_details.Visible = true;

        textBox_name.ReadOnly = !AllowedToEdit;
        textBox_description.ReadOnly = !AllowedToEdit;
        textBox_value.ReadOnly = !AllowedToEdit;

        textBox_value.Visible = isBookmark;
        label_value.Visible = isBookmark;
        textBox_value.Text = String.Empty;

        textBox_name.Text = item.Name;
        textBox_description.Text = item.Description;

        if (!isBookmark)
        {
            init = false;
            return;
        }
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

        if (LastCollectionUsed.SelectedIndex == -1 || LastCollectionUsed.SelectedIndex >= CurrentCollections.Count) return;
        BookmarkFolder collection = CurrentSelectedCollection;
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

    #region Drag & Drop
    private void tree_bookmarks_ItemDrag(object sender, ItemDragEventArgs e)
    {
        DragDropEffects effect = DragDropEffects.All;
        if (!AllowedToEdit) effect = DragDropEffects.None;
        DoDragDrop(e.Item, effect);
    }
    private void tree_bookmarks_DragEnter(object sender, DragEventArgs e)
    {
        e.Effect = DragDropEffects.All;
        if (!AllowedToEdit) e.Effect = DragDropEffects.None;
    }
    private void tree_bookmarks_DragDrop(object sender, DragEventArgs e)
    {
        if (!AllowedToEdit) return;
        TreeView tv = sender as TreeView;

        Point targetPoint = tv.PointToClient(new Point(e.X, e.Y));
        TreeNode targetNode = tv.GetNodeAt(targetPoint);
        TreeNode draggedNode = e.Data.GetData(typeof(TreeNode)) as TreeNode;

        dropNode(draggedNode, targetNode);

        tv.SelectedNode = draggedNode;
    }

    private void dropNode(TreeNode draggedNode, TreeNode targetNode, int insertionIndex = -1)
    {
        if (draggedNode == null) return;
        if (targetNode == null) //Dropped on treeview root
        {
            moveBookmark(draggedNode, CurrentSelectedCollection, insertionIndex);
            return;
        }
        if (draggedNode.Equals(targetNode)) return;

        // Check if target node is folder or bookmark
        BookmarkItem targetNodeItem = targetNode.Tag as BookmarkItem;
        if (targetNodeItem == null) return;

        if (targetNodeItem is Bookmark)
        {
            // Stop dropping here and try it on the parent
            dropNode(draggedNode, targetNode.Parent, targetNode.Index + 1);
            return;
        }

        // targetNodeItem IS Folder
        if (canDropOnNode(draggedNode, targetNode)) moveBookmark(draggedNode, targetNode, insertionIndex);
    }

    private void moveBookmark(TreeNode nodeToMove, TreeNode newParentNode, int index = -1)
    {
        if (nodeToMove.Tag is not BookmarkItem) throw new ArgumentException($"Node {nodeToMove} does not contain a valid BookmarkItem");
        if (newParentNode.Tag is not BookmarkFolder && newParentNode != null) throw new ArgumentException($"The newParentNode needs to contain a valid BookmarkFolder");

        TreeNode oldParentNode = nodeToMove.Parent;
        BookmarkItem itemToMove = nodeToMove.Tag as BookmarkItem;
        BookmarkFolder newParentFolder = newParentNode.Tag as BookmarkFolder;
        BookmarkFolder? oldParentFolder = null;
        if (oldParentNode != null) oldParentFolder = oldParentNode.Tag as BookmarkFolder;

        // Append or insert item
        tree_bookmarks.BeginUpdate();
        TreeNode insertNode = nodeToMove.Clone() as TreeNode;
        if (index != -1)
        {
            newParentNode.Nodes.Insert(index, insertNode);
            newParentFolder.InsertItem(index, itemToMove);
        }
        else
        {
            newParentNode.Nodes.Add(insertNode);
            newParentFolder.AddItem(itemToMove);
        }
        nodeToMove.Remove();
        insertNode.Expand();
        if (oldParentFolder != null) oldParentFolder.Items.Remove(itemToMove);
        else CurrentSelectedCollection.Items.Remove(itemToMove);
        tree_bookmarks.EndUpdate();
    }
    private void moveBookmark(TreeNode nodeToMove, BookmarkFolder newParenFolder, int index = -1)
    {
        if (nodeToMove.Tag is not BookmarkItem) throw new ArgumentException($"Node {nodeToMove} does not contain a valid BookmarkItem");

        TreeNode oldParentNode = nodeToMove.Parent;
        BookmarkItem itemToMove = nodeToMove.Tag as BookmarkItem;
        BookmarkFolder? oldParentFolder = null;
        if (oldParentNode != null) oldParentFolder = oldParentNode.Tag as BookmarkFolder;

        // Append or insert item
        tree_bookmarks.BeginUpdate();
        TreeNode insertNode = nodeToMove.Clone() as TreeNode;
        if (index != -1)
        {
            tree_bookmarks.Nodes.Insert(index, insertNode);
            newParenFolder.InsertItem(index, itemToMove);
        }
        else
        {
            tree_bookmarks.Nodes.Add(insertNode);
            newParenFolder.AddItem(itemToMove);
        }
        nodeToMove.Remove();
        insertNode.Expand();
        if (oldParentFolder != null) oldParentFolder.Items.Remove(itemToMove);
        else CurrentSelectedCollection.Items.Remove(itemToMove);
        tree_bookmarks.EndUpdate();
    }

    private bool canDropOnNode(TreeNode node, TreeNode target)
    {
        TreeNode parent = target;
        bool canDrop = true;
        while (canDrop && parent != null)
        {
            canDrop = !Object.ReferenceEquals(node, parent);
            parent = parent.Parent;
        }

        return canDrop;
    }
    #endregion

    #region Dialog
    private void HandleDialog()
    {
        Text = "Select Bookmark";
        statusStrip1.Visible = false;
        button_addGlobal.Visible = false;
        button_projectAdd.Visible = false;
        button_globalRemove.Visible = false;
        button_projectRemove.Visible = false;
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
        if (LastCollectionUsed.SelectedIndex == -1)
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

    private void ImportCollection(ListBox goalBox, List<BookmarkFolder> goalCollection)
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
                AddCollection(collection, goalBox, goalCollection);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Collection import failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void button_exportFolder_Click(object sender, EventArgs e)
    {
        if (ContextMenuTreeNode.Tag is not BookmarkFolder folder) return;

        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "MAGE Bookmark Collection (*.mbc)|*.mbc";
        dialog.FileName = folder.Name;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            //convert key pair to json object
            string data = BookmarkManager.Serialize(folder);
            File.WriteAllText(dialog.FileName, data);
        }
    }

    private void button_importGlobal_Click(object sender, EventArgs e)
    {
        ImportCollection(listbox_globalCollections, BookmarkManager.GlobalCollections);
    }

    private void button_importProject_Click(object sender, EventArgs e)
    {
        ImportCollection(listbox_projectCollections, BookmarkManager.ProjectCollections);
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

    private void button_expand_Click(object sender, EventArgs e)
    {
        tree_bookmarks.BeginUpdate();
        tree_bookmarks.ExpandAll();
        tree_bookmarks.EndUpdate();
    }

    private void button_collapse_Click(object sender, EventArgs e)
    {
        tree_bookmarks.BeginUpdate();
        tree_bookmarks.CollapseAll();
        tree_bookmarks.EndUpdate();
    }
    #endregion

    #region adding/removing
    private void AddNewBookmarkItem(BookmarkItem item, TreeNode node)
    {
        // Find a parent to add the bookmark to
        BookmarkItem currentNodeItem = null;
        TreeNode parentNode = null;
        BookmarkFolder parentFolder = null;

        if (node != null) currentNodeItem = node.Tag as BookmarkItem;
        if (currentNodeItem != null && currentNodeItem is BookmarkFolder)
        {
            parentNode = node;
            parentFolder = currentNodeItem as BookmarkFolder;
        }
        else
        {
            if (node != null) parentNode = node.Parent;
            parentFolder = CurrentSelectedCollection;
            if (parentNode != null) parentFolder = parentNode.Tag as BookmarkFolder;
        }

        // Add bookmark to Collection and TreeView
        TreeNode newItemNode = CreateBookmarkItemNode(item);
        if (parentNode == null) tree_bookmarks.Nodes.Add(newItemNode);
        else
        {
            parentNode.Nodes.Add(newItemNode);
            parentNode.Expand();
        }

        parentFolder.AddItem(item);
        tree_bookmarks.SelectedNode = newItemNode;
    }

    private void button_createBookmark_Click(object sender, EventArgs e)
    {
        Bookmark newBookmark = new() { Name = "New Bookmark" };
        AddNewBookmarkItem(newBookmark, ContextMenuTreeNode);
    }

    private void button_createFolder_Click(object sender, EventArgs e)
    {
        BookmarkFolder newFolder = new() { Name = "New Folder" };
        AddNewBookmarkItem(newFolder, ContextMenuTreeNode);
    }

    private void button_delete_Click(object sender, EventArgs e)
    {
        if (ContextMenuTreeNode == null) return;
        TreeNode node = ContextMenuTreeNode;
        BookmarkItem item = node.Tag as BookmarkItem;

        // Extra confirmation required when deleting a folder with content
        if (
            item is BookmarkFolder folder
            && folder.Items.Count > 0
            && MessageBox.Show($"Are you sure you want to delete the folder?\nAll contained bookmarks will be deleted.", "Delete Folder?", MessageBoxButtons.YesNo)
            != DialogResult.Yes
        ) return;

        // Find Parent of Bookmark Item from the treeview
        TreeNode nodeParent = node.Parent;
        BookmarkFolder parentFolder = CurrentSelectedCollection;
        if (nodeParent != null) parentFolder = nodeParent.Tag as BookmarkFolder;

        parentFolder.Items.Remove(item);
        ContextMenuTreeNode.Remove();
    }

    private void button_createCopy_Click(object sender, EventArgs e)
    {
        Config.BookmarkCollection lastUsed = Config.BookmarkCollection.Internal;

        BookmarkItem itemToCopy = ContextMenuTreeNode.Tag as BookmarkItem;
        BookmarkCopyDialog bcd = new(itemToCopy, this);
        if (bcd.ShowDialog() != DialogResult.OK) return;
        var copyResult = bcd.CopyDialogResult;

        // Copy Item
        int newSelectedIndex = -1;
        BookmarkPath itemPath = itemToCopy.CreateBookmarkPath();
        BookmarkFolder collectionToCopyTo = copyResult.SelectedCollection;

        // Check if collection already exists
        int indexOfExisting = copyResult.GoalListBox.Items.IndexOf(itemPath.Root.Name);
        if (copyResult.CreateNewCollection && indexOfExisting == -1) // Case where collection doesnt exist but should be created
        {
            collectionToCopyTo = new BookmarkFolder()
            {
                Name = itemPath.Root.Name,
                Description = itemPath.Root.Description,
            };
            copyResult.GoalListBox.Items.Add(collectionToCopyTo.Name);
            copyResult.GoalCollections.Add(collectionToCopyTo);
            newSelectedIndex = copyResult.GoalListBox.Items.Count - 1;
        }
        else if (copyResult.CreateNewCollection && indexOfExisting != -1) // Case where collection already exists and should be created
        {
            collectionToCopyTo = copyResult.GoalCollections[indexOfExisting];
            newSelectedIndex = indexOfExisting;
        }
        else // Case where an existing collection is being used
        {
            newSelectedIndex = copyResult.GoalListBox.Items.IndexOf(copyResult.SelectedCollection.Name);
        }
        collectionToCopyTo.AddItemWithPath(itemPath, copyResult.IncludePath, false);

        // Select newly copied item
        LastCollectionUsed = new()
        {
            Box = copyResult.GoalListBox,
            SelectedIndex = newSelectedIndex
        };
    }

    private void button_addGlobal_Click(object sender, EventArgs e)
    {
        BookmarkFolder newCollection = new BookmarkFolder();
        newCollection.Name = "New Collection";
        AddCollection(newCollection, listbox_globalCollections, BookmarkManager.GlobalCollections);
    }

    private void button_projectAdd_Click(object sender, EventArgs e)
    {
        BookmarkFolder newCollection = new BookmarkFolder();
        newCollection.Name = "New Collection";
        AddCollection(newCollection, listbox_projectCollections, BookmarkManager.ProjectCollections);
    }

    private void button_globalRemove_Click(object sender, EventArgs e)
    {
        if (listbox_globalCollections.SelectedIndex == -1) return;
        if (MessageBox.Show("Are you sure you want to delete this collection and all Bookmarks inside?",
            "Delete Collection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        BookmarkManager.GlobalCollections.RemoveAt(listbox_globalCollections.SelectedIndex);
        listbox_globalCollections.Items.RemoveAt(listbox_globalCollections.SelectedIndex);
        LastCollectionUsed = new()
        {
            Box = LastCollectionUsed.Box,
            SelectedIndex = -1
        };
    }

    private void button_projectRemove_Click(object sender, EventArgs e)
    {
        if (listbox_projectCollections.SelectedIndex == -1) return;
        if (MessageBox.Show("Are you sure you want to delete this collection and all Bookmarks inside?",
            "Delete Collection", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;
        BookmarkManager.ProjectCollections.RemoveAt(listbox_projectCollections.SelectedIndex);
        listbox_projectCollections.Items.RemoveAt(listbox_projectCollections.SelectedIndex);
        LastCollectionUsed = new()
        {
            Box = LastCollectionUsed.Box,
            SelectedIndex = -1
        };
    }
    #endregion
}
