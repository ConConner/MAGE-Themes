namespace mage.Bookmarks
{
    partial class FormBookmarks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node0");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBookmarks));
            tree_bookmarks = new System.Windows.Forms.TreeView();
            imageList_treeIcons = new System.Windows.Forms.ImageList(components);
            listbox_globalCollections = new System.Windows.Forms.ListBox();
            group_globalCollections = new System.Windows.Forms.GroupBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            spring = new System.Windows.Forms.ToolStripStatusLabel();
            button_import = new System.Windows.Forms.ToolStripDropDownButton();
            button_export = new System.Windows.Forms.ToolStripDropDownButton();
            panel_main = new System.Windows.Forms.Panel();
            panel_bookmarks = new System.Windows.Forms.Panel();
            group_bookmarks = new System.Windows.Forms.GroupBox();
            textBox_search = new Theming.CustomControls.FlatTextBox();
            panel_collections = new System.Windows.Forms.Panel();
            panel_projectCollections = new System.Windows.Forms.Panel();
            group_projectCollections = new System.Windows.Forms.GroupBox();
            listbox_projectCollections = new System.Windows.Forms.ListBox();
            panel_globalCollections = new System.Windows.Forms.Panel();
            panel_internalCollections = new System.Windows.Forms.Panel();
            group_internalCollections = new System.Windows.Forms.GroupBox();
            listbox_internalCollections = new System.Windows.Forms.ListBox();
            group_details = new System.Windows.Forms.GroupBox();
            textBox_description = new Theming.CustomControls.FlatTextBox();
            label_description = new System.Windows.Forms.Label();
            textBox_value = new Theming.CustomControls.FlatTextBox();
            label_value = new System.Windows.Forms.Label();
            textBox_name = new Theming.CustomControls.FlatTextBox();
            label_name = new System.Windows.Forms.Label();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            glToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            projectBookmarkCollectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            automaticallyExpandNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            allLayersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            Layer1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            Layer2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            layer3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            layer4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            context_treeview = new System.Windows.Forms.ContextMenuStrip(components);
            group_globalCollections.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel_main.SuspendLayout();
            panel_bookmarks.SuspendLayout();
            group_bookmarks.SuspendLayout();
            panel_collections.SuspendLayout();
            panel_projectCollections.SuspendLayout();
            group_projectCollections.SuspendLayout();
            panel_globalCollections.SuspendLayout();
            panel_internalCollections.SuspendLayout();
            group_internalCollections.SuspendLayout();
            group_details.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tree_bookmarks
            // 
            tree_bookmarks.AllowDrop = true;
            tree_bookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tree_bookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            tree_bookmarks.HideSelection = false;
            tree_bookmarks.HotTracking = true;
            tree_bookmarks.ImageIndex = 0;
            tree_bookmarks.ImageList = imageList_treeIcons;
            tree_bookmarks.Location = new System.Drawing.Point(3, 42);
            tree_bookmarks.Name = "tree_bookmarks";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            tree_bookmarks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode1 });
            tree_bookmarks.SelectedImageIndex = 0;
            tree_bookmarks.Size = new System.Drawing.Size(371, 380);
            tree_bookmarks.TabIndex = 0;
            tree_bookmarks.ItemDrag += tree_bookmarks_ItemDrag;
            tree_bookmarks.AfterSelect += tree_bookmarks_AfterSelect;
            tree_bookmarks.NodeMouseClick += tree_bookmarks_NodeMouseClick;
            tree_bookmarks.NodeMouseDoubleClick += tree_bookmarks_NodeMouseDoubleClick;
            tree_bookmarks.DragDrop += tree_bookmarks_DragDrop;
            tree_bookmarks.DragEnter += tree_bookmarks_DragEnter;
            // 
            // imageList_treeIcons
            // 
            imageList_treeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            imageList_treeIcons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList_treeIcons.ImageStream");
            imageList_treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            imageList_treeIcons.Images.SetKeyName(0, "folder");
            imageList_treeIcons.Images.SetKeyName(1, "bookmark");
            // 
            // listbox_globalCollections
            // 
            listbox_globalCollections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listbox_globalCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            listbox_globalCollections.FormattingEnabled = true;
            listbox_globalCollections.ItemHeight = 15;
            listbox_globalCollections.Location = new System.Drawing.Point(3, 19);
            listbox_globalCollections.Name = "listbox_globalCollections";
            listbox_globalCollections.Size = new System.Drawing.Size(155, 138);
            listbox_globalCollections.TabIndex = 1;
            listbox_globalCollections.SelectedIndexChanged += listbox_globalCollections_SelectedIndexChanged;
            // 
            // group_globalCollections
            // 
            group_globalCollections.Controls.Add(listbox_globalCollections);
            group_globalCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            group_globalCollections.Location = new System.Drawing.Point(0, 3);
            group_globalCollections.Name = "group_globalCollections";
            group_globalCollections.Size = new System.Drawing.Size(161, 160);
            group_globalCollections.TabIndex = 2;
            group_globalCollections.TabStop = false;
            group_globalCollections.Text = "Global Collections";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { spring, button_import, button_export });
            statusStrip1.Location = new System.Drawing.Point(0, 461);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(756, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // spring
            // 
            spring.Name = "spring";
            spring.Size = new System.Drawing.Size(649, 17);
            spring.Spring = true;
            // 
            // button_import
            // 
            button_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            button_import.Image = (System.Drawing.Image)resources.GetObject("button_import.Image");
            button_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_import.Name = "button_import";
            button_import.ShowDropDownArrow = false;
            button_import.Size = new System.Drawing.Size(47, 20);
            button_import.Text = "Import";
            button_import.Click += button_import_Click;
            // 
            // button_export
            // 
            button_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            button_export.Image = (System.Drawing.Image)resources.GetObject("button_export.Image");
            button_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_export.Name = "button_export";
            button_export.ShowDropDownArrow = false;
            button_export.Size = new System.Drawing.Size(45, 20);
            button_export.Text = "Export";
            button_export.Click += button_export_Click;
            // 
            // panel_main
            // 
            panel_main.Controls.Add(panel_bookmarks);
            panel_main.Controls.Add(panel_collections);
            panel_main.Controls.Add(group_details);
            panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_main.Location = new System.Drawing.Point(0, 24);
            panel_main.Name = "panel_main";
            panel_main.Padding = new System.Windows.Forms.Padding(6);
            panel_main.Size = new System.Drawing.Size(756, 437);
            panel_main.TabIndex = 4;
            // 
            // panel_bookmarks
            // 
            panel_bookmarks.Controls.Add(group_bookmarks);
            panel_bookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_bookmarks.Location = new System.Drawing.Point(167, 6);
            panel_bookmarks.Name = "panel_bookmarks";
            panel_bookmarks.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            panel_bookmarks.Size = new System.Drawing.Size(389, 425);
            panel_bookmarks.TabIndex = 5;
            // 
            // group_bookmarks
            // 
            group_bookmarks.Controls.Add(tree_bookmarks);
            group_bookmarks.Controls.Add(textBox_search);
            group_bookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            group_bookmarks.Location = new System.Drawing.Point(6, 0);
            group_bookmarks.Name = "group_bookmarks";
            group_bookmarks.Size = new System.Drawing.Size(377, 425);
            group_bookmarks.TabIndex = 3;
            group_bookmarks.TabStop = false;
            group_bookmarks.Text = "Bookmarks";
            // 
            // textBox_search
            // 
            textBox_search.BorderColor = System.Drawing.Color.Black;
            textBox_search.DisplayBorder = true;
            textBox_search.Dock = System.Windows.Forms.DockStyle.Top;
            textBox_search.Location = new System.Drawing.Point(3, 19);
            textBox_search.MaxLength = 32767;
            textBox_search.Multiline = false;
            textBox_search.Name = "textBox_search";
            textBox_search.OnTextChanged = null;
            textBox_search.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_search.PlaceholderText = "";
            textBox_search.ReadOnly = false;
            textBox_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_search.SelectionStart = 0;
            textBox_search.Size = new System.Drawing.Size(371, 23);
            textBox_search.TabIndex = 1;
            textBox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_search.ValueBox = false;
            textBox_search.WordWrap = true;
            // 
            // panel_collections
            // 
            panel_collections.Controls.Add(panel_projectCollections);
            panel_collections.Controls.Add(panel_globalCollections);
            panel_collections.Controls.Add(panel_internalCollections);
            panel_collections.Dock = System.Windows.Forms.DockStyle.Left;
            panel_collections.Location = new System.Drawing.Point(6, 6);
            panel_collections.Name = "panel_collections";
            panel_collections.Size = new System.Drawing.Size(161, 425);
            panel_collections.TabIndex = 6;
            // 
            // panel_projectCollections
            // 
            panel_projectCollections.Controls.Add(group_projectCollections);
            panel_projectCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_projectCollections.Location = new System.Drawing.Point(0, 260);
            panel_projectCollections.Name = "panel_projectCollections";
            panel_projectCollections.Size = new System.Drawing.Size(161, 165);
            panel_projectCollections.TabIndex = 2;
            // 
            // group_projectCollections
            // 
            group_projectCollections.Controls.Add(listbox_projectCollections);
            group_projectCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            group_projectCollections.Location = new System.Drawing.Point(0, 0);
            group_projectCollections.Name = "group_projectCollections";
            group_projectCollections.Size = new System.Drawing.Size(161, 165);
            group_projectCollections.TabIndex = 3;
            group_projectCollections.TabStop = false;
            group_projectCollections.Text = "Project Collections";
            // 
            // listbox_projectCollections
            // 
            listbox_projectCollections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listbox_projectCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            listbox_projectCollections.FormattingEnabled = true;
            listbox_projectCollections.ItemHeight = 15;
            listbox_projectCollections.Location = new System.Drawing.Point(3, 19);
            listbox_projectCollections.Name = "listbox_projectCollections";
            listbox_projectCollections.Size = new System.Drawing.Size(155, 143);
            listbox_projectCollections.TabIndex = 1;
            listbox_projectCollections.SelectedIndexChanged += listbox_projectCollections_SelectedIndexChanged;
            // 
            // panel_globalCollections
            // 
            panel_globalCollections.Controls.Add(group_globalCollections);
            panel_globalCollections.Dock = System.Windows.Forms.DockStyle.Top;
            panel_globalCollections.Location = new System.Drawing.Point(0, 94);
            panel_globalCollections.Name = "panel_globalCollections";
            panel_globalCollections.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            panel_globalCollections.Size = new System.Drawing.Size(161, 166);
            panel_globalCollections.TabIndex = 1;
            // 
            // panel_internalCollections
            // 
            panel_internalCollections.Controls.Add(group_internalCollections);
            panel_internalCollections.Dock = System.Windows.Forms.DockStyle.Top;
            panel_internalCollections.Location = new System.Drawing.Point(0, 0);
            panel_internalCollections.Name = "panel_internalCollections";
            panel_internalCollections.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            panel_internalCollections.Size = new System.Drawing.Size(161, 94);
            panel_internalCollections.TabIndex = 0;
            // 
            // group_internalCollections
            // 
            group_internalCollections.Controls.Add(listbox_internalCollections);
            group_internalCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            group_internalCollections.Location = new System.Drawing.Point(0, 0);
            group_internalCollections.Name = "group_internalCollections";
            group_internalCollections.Size = new System.Drawing.Size(161, 91);
            group_internalCollections.TabIndex = 4;
            group_internalCollections.TabStop = false;
            group_internalCollections.Text = "Internal Collections";
            // 
            // listbox_internalCollections
            // 
            listbox_internalCollections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listbox_internalCollections.Dock = System.Windows.Forms.DockStyle.Fill;
            listbox_internalCollections.FormattingEnabled = true;
            listbox_internalCollections.ItemHeight = 15;
            listbox_internalCollections.Location = new System.Drawing.Point(3, 19);
            listbox_internalCollections.Name = "listbox_internalCollections";
            listbox_internalCollections.Size = new System.Drawing.Size(155, 69);
            listbox_internalCollections.TabIndex = 1;
            listbox_internalCollections.SelectedIndexChanged += listbox_internalCollections_SelectedIndexChanged;
            // 
            // group_details
            // 
            group_details.Controls.Add(textBox_description);
            group_details.Controls.Add(label_description);
            group_details.Controls.Add(textBox_value);
            group_details.Controls.Add(label_value);
            group_details.Controls.Add(textBox_name);
            group_details.Controls.Add(label_name);
            group_details.Dock = System.Windows.Forms.DockStyle.Right;
            group_details.Location = new System.Drawing.Point(556, 6);
            group_details.Name = "group_details";
            group_details.Size = new System.Drawing.Size(194, 425);
            group_details.TabIndex = 4;
            group_details.TabStop = false;
            group_details.Text = "Details";
            // 
            // textBox_description
            // 
            textBox_description.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_description.BorderColor = System.Drawing.Color.Black;
            textBox_description.DisplayBorder = true;
            textBox_description.Location = new System.Drawing.Point(6, 125);
            textBox_description.MaxLength = 32767;
            textBox_description.Multiline = true;
            textBox_description.Name = "textBox_description";
            textBox_description.OnTextChanged = null;
            textBox_description.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_description.PlaceholderText = "";
            textBox_description.ReadOnly = false;
            textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_description.SelectionStart = 0;
            textBox_description.Size = new System.Drawing.Size(182, 294);
            textBox_description.TabIndex = 5;
            textBox_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_description.ValueBox = false;
            textBox_description.WordWrap = true;
            // 
            // label_description
            // 
            label_description.AutoSize = true;
            label_description.Location = new System.Drawing.Point(6, 107);
            label_description.Name = "label_description";
            label_description.Size = new System.Drawing.Size(70, 15);
            label_description.TabIndex = 4;
            label_description.Text = "Description:";
            // 
            // textBox_value
            // 
            textBox_value.BorderColor = System.Drawing.Color.Black;
            textBox_value.DisplayBorder = true;
            textBox_value.Location = new System.Drawing.Point(6, 81);
            textBox_value.MaxLength = 32767;
            textBox_value.Multiline = false;
            textBox_value.Name = "textBox_value";
            textBox_value.OnTextChanged = null;
            textBox_value.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_value.PlaceholderText = "";
            textBox_value.ReadOnly = false;
            textBox_value.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_value.SelectionStart = 0;
            textBox_value.Size = new System.Drawing.Size(182, 23);
            textBox_value.TabIndex = 3;
            textBox_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_value.ValueBox = false;
            textBox_value.WordWrap = true;
            // 
            // label_value
            // 
            label_value.AutoSize = true;
            label_value.Location = new System.Drawing.Point(6, 63);
            label_value.Name = "label_value";
            label_value.Size = new System.Drawing.Size(38, 15);
            label_value.TabIndex = 2;
            label_value.Text = "Value:";
            // 
            // textBox_name
            // 
            textBox_name.BorderColor = System.Drawing.Color.Black;
            textBox_name.DisplayBorder = true;
            textBox_name.Location = new System.Drawing.Point(6, 37);
            textBox_name.MaxLength = 32767;
            textBox_name.Multiline = false;
            textBox_name.Name = "textBox_name";
            textBox_name.OnTextChanged = null;
            textBox_name.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_name.PlaceholderText = "";
            textBox_name.ReadOnly = false;
            textBox_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_name.SelectionStart = 0;
            textBox_name.Size = new System.Drawing.Size(182, 23);
            textBox_name.TabIndex = 1;
            textBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_name.ValueBox = false;
            textBox_name.WordWrap = true;
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new System.Drawing.Point(6, 19);
            label_name.Name = "label_name";
            label_name.Size = new System.Drawing.Size(42, 15);
            label_name.TabIndex = 0;
            label_name.Text = "Name:";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { newToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(756, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { glToolStripMenuItem, projectBookmarkCollectionToolStripMenuItem });
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            newToolStripMenuItem.Text = "New";
            // 
            // glToolStripMenuItem
            // 
            glToolStripMenuItem.Name = "glToolStripMenuItem";
            glToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            glToolStripMenuItem.Text = "Global Bookmark Collection";
            // 
            // projectBookmarkCollectionToolStripMenuItem
            // 
            projectBookmarkCollectionToolStripMenuItem.Name = "projectBookmarkCollectionToolStripMenuItem";
            projectBookmarkCollectionToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            projectBookmarkCollectionToolStripMenuItem.Text = "Project Bookmark Collection";
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { automaticallyExpandNodesToolStripMenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            viewToolStripMenuItem.Text = "View";
            // 
            // automaticallyExpandNodesToolStripMenuItem
            // 
            automaticallyExpandNodesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { allLayersToolStripMenuItem, toolStripSeparator1, Layer1ToolStripMenuItem, Layer2ToolStripMenuItem, layer3ToolStripMenuItem, layer4ToolStripMenuItem });
            automaticallyExpandNodesToolStripMenuItem.Name = "automaticallyExpandNodesToolStripMenuItem";
            automaticallyExpandNodesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            automaticallyExpandNodesToolStripMenuItem.Text = "Auto expand Nodes";
            // 
            // allLayersToolStripMenuItem
            // 
            allLayersToolStripMenuItem.Name = "allLayersToolStripMenuItem";
            allLayersToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            allLayersToolStripMenuItem.Tag = "-1";
            allLayersToolStripMenuItem.Text = "All Layers";
            allLayersToolStripMenuItem.Click += allLayersToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            toolStripSeparator1.Click += allLayersToolStripMenuItem_Click;
            // 
            // Layer1ToolStripMenuItem
            // 
            Layer1ToolStripMenuItem.Name = "Layer1ToolStripMenuItem";
            Layer1ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            Layer1ToolStripMenuItem.Tag = "0";
            Layer1ToolStripMenuItem.Text = "None";
            Layer1ToolStripMenuItem.Click += allLayersToolStripMenuItem_Click;
            // 
            // Layer2ToolStripMenuItem
            // 
            Layer2ToolStripMenuItem.Name = "Layer2ToolStripMenuItem";
            Layer2ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            Layer2ToolStripMenuItem.Tag = "1";
            Layer2ToolStripMenuItem.Text = "Layer 1";
            Layer2ToolStripMenuItem.Click += allLayersToolStripMenuItem_Click;
            // 
            // layer3ToolStripMenuItem
            // 
            layer3ToolStripMenuItem.Name = "layer3ToolStripMenuItem";
            layer3ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            layer3ToolStripMenuItem.Tag = "2";
            layer3ToolStripMenuItem.Text = "Layer 2";
            layer3ToolStripMenuItem.Click += allLayersToolStripMenuItem_Click;
            // 
            // layer4ToolStripMenuItem
            // 
            layer4ToolStripMenuItem.Name = "layer4ToolStripMenuItem";
            layer4ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            layer4ToolStripMenuItem.Tag = "3";
            layer4ToolStripMenuItem.Text = "Layer 3";
            layer4ToolStripMenuItem.Click += allLayersToolStripMenuItem_Click;
            // 
            // context_treeview
            // 
            context_treeview.Name = "context_treeview";
            context_treeview.Size = new System.Drawing.Size(181, 26);
            // 
            // FormBookmarks
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(756, 483);
            Controls.Add(panel_main);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "FormBookmarks";
            Text = "Bookmarks";
            group_globalCollections.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel_main.ResumeLayout(false);
            panel_bookmarks.ResumeLayout(false);
            group_bookmarks.ResumeLayout(false);
            panel_collections.ResumeLayout(false);
            panel_projectCollections.ResumeLayout(false);
            group_projectCollections.ResumeLayout(false);
            panel_globalCollections.ResumeLayout(false);
            panel_internalCollections.ResumeLayout(false);
            group_internalCollections.ResumeLayout(false);
            group_details.ResumeLayout(false);
            group_details.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TreeView tree_bookmarks;
        private System.Windows.Forms.ListBox listbox_globalCollections;
        private System.Windows.Forms.GroupBox group_globalCollections;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.GroupBox group_bookmarks;
        private System.Windows.Forms.ImageList imageList_treeIcons;
        private System.Windows.Forms.Panel panel_bookmarks;
        private System.Windows.Forms.GroupBox group_details;
        private Theming.CustomControls.FlatTextBox textBox_value;
        private System.Windows.Forms.Label label_value;
        private Theming.CustomControls.FlatTextBox textBox_name;
        private System.Windows.Forms.Label label_name;
        private Theming.CustomControls.FlatTextBox textBox_description;
        private System.Windows.Forms.Label label_description;
        private System.Windows.Forms.ToolStripStatusLabel spring;
        private System.Windows.Forms.ToolStripDropDownButton button_import;
        private System.Windows.Forms.ToolStripDropDownButton button_export;
        private Theming.CustomControls.FlatTextBox textBox_search;
        private System.Windows.Forms.Panel panel_collections;
        private System.Windows.Forms.Panel panel_internalCollections;
        private System.Windows.Forms.Panel panel_projectCollections;
        private System.Windows.Forms.Panel panel_globalCollections;
        private System.Windows.Forms.GroupBox group_projectCollections;
        private System.Windows.Forms.ListBox listbox_projectCollections;
        private System.Windows.Forms.GroupBox group_internalCollections;
        private System.Windows.Forms.ListBox listbox_internalCollections;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem glToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectBookmarkCollectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem automaticallyExpandNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allLayersToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem Layer1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Layer2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem layer4ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip context_treeview;
    }
}