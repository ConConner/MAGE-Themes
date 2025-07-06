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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Node1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Node2");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Node5");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Node3", new System.Windows.Forms.TreeNode[] { treeNode3 });
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Node6");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Node7");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Node0", new System.Windows.Forms.TreeNode[] { treeNode1, treeNode2, treeNode4, treeNode5, treeNode6 });
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Node4");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBookmarks));
            tree_bookmarks = new System.Windows.Forms.TreeView();
            imageList_treeIcons = new System.Windows.Forms.ImageList(components);
            listbox_collections = new System.Windows.Forms.ListBox();
            group_collections = new System.Windows.Forms.GroupBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            spring = new System.Windows.Forms.ToolStripStatusLabel();
            button_import = new System.Windows.Forms.ToolStripDropDownButton();
            button_export = new System.Windows.Forms.ToolStripDropDownButton();
            panel_main = new System.Windows.Forms.Panel();
            panel_bookmarks = new System.Windows.Forms.Panel();
            group_bookmarks = new System.Windows.Forms.GroupBox();
            group_details = new System.Windows.Forms.GroupBox();
            textBox_description = new Theming.CustomControls.FlatTextBox();
            label_description = new System.Windows.Forms.Label();
            textBox_value = new Theming.CustomControls.FlatTextBox();
            label_value = new System.Windows.Forms.Label();
            textBox_name = new Theming.CustomControls.FlatTextBox();
            label_name = new System.Windows.Forms.Label();
            textBox_search = new Theming.CustomControls.FlatTextBox();
            group_collections.SuspendLayout();
            statusStrip1.SuspendLayout();
            panel_main.SuspendLayout();
            panel_bookmarks.SuspendLayout();
            group_bookmarks.SuspendLayout();
            group_details.SuspendLayout();
            SuspendLayout();
            // 
            // tree_bookmarks
            // 
            tree_bookmarks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            tree_bookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            tree_bookmarks.HideSelection = false;
            tree_bookmarks.HotTracking = true;
            tree_bookmarks.ImageIndex = 0;
            tree_bookmarks.ImageList = imageList_treeIcons;
            tree_bookmarks.Location = new System.Drawing.Point(3, 42);
            tree_bookmarks.Name = "tree_bookmarks";
            treeNode1.Name = "Node1";
            treeNode1.Text = "Node1";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Node2";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Node5";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Node3";
            treeNode5.Name = "Node6";
            treeNode5.Text = "Node6";
            treeNode6.Name = "Node7";
            treeNode6.Text = "Node7";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Node0";
            treeNode8.Name = "Node4";
            treeNode8.Text = "Node4";
            tree_bookmarks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] { treeNode7, treeNode8 });
            tree_bookmarks.SelectedImageIndex = 0;
            tree_bookmarks.Size = new System.Drawing.Size(384, 371);
            tree_bookmarks.TabIndex = 0;
            tree_bookmarks.AfterSelect += tree_bookmarks_AfterSelect;
            tree_bookmarks.NodeMouseDoubleClick += tree_bookmarks_NodeMouseDoubleClick;
            // 
            // imageList_treeIcons
            // 
            imageList_treeIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            imageList_treeIcons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList_treeIcons.ImageStream");
            imageList_treeIcons.TransparentColor = System.Drawing.Color.Transparent;
            imageList_treeIcons.Images.SetKeyName(0, "folder");
            imageList_treeIcons.Images.SetKeyName(1, "bookmark");
            // 
            // listbox_collections
            // 
            listbox_collections.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listbox_collections.Dock = System.Windows.Forms.DockStyle.Fill;
            listbox_collections.FormattingEnabled = true;
            listbox_collections.ItemHeight = 15;
            listbox_collections.Location = new System.Drawing.Point(3, 19);
            listbox_collections.Name = "listbox_collections";
            listbox_collections.Size = new System.Drawing.Size(142, 394);
            listbox_collections.TabIndex = 1;
            listbox_collections.SelectedIndexChanged += listbox_collections_SelectedIndexChanged;
            // 
            // group_collections
            // 
            group_collections.Controls.Add(listbox_collections);
            group_collections.Dock = System.Windows.Forms.DockStyle.Left;
            group_collections.Location = new System.Drawing.Point(6, 6);
            group_collections.Name = "group_collections";
            group_collections.Size = new System.Drawing.Size(148, 416);
            group_collections.TabIndex = 2;
            group_collections.TabStop = false;
            group_collections.Text = "Collections";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { spring, button_import, button_export });
            statusStrip1.Location = new System.Drawing.Point(0, 428);
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
            panel_main.Controls.Add(group_details);
            panel_main.Controls.Add(group_collections);
            panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_main.Location = new System.Drawing.Point(0, 0);
            panel_main.Name = "panel_main";
            panel_main.Padding = new System.Windows.Forms.Padding(6);
            panel_main.Size = new System.Drawing.Size(756, 428);
            panel_main.TabIndex = 4;
            // 
            // panel_bookmarks
            // 
            panel_bookmarks.Controls.Add(group_bookmarks);
            panel_bookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_bookmarks.Location = new System.Drawing.Point(154, 6);
            panel_bookmarks.Name = "panel_bookmarks";
            panel_bookmarks.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            panel_bookmarks.Size = new System.Drawing.Size(402, 416);
            panel_bookmarks.TabIndex = 5;
            // 
            // group_bookmarks
            // 
            group_bookmarks.Controls.Add(tree_bookmarks);
            group_bookmarks.Controls.Add(textBox_search);
            group_bookmarks.Dock = System.Windows.Forms.DockStyle.Fill;
            group_bookmarks.Location = new System.Drawing.Point(6, 0);
            group_bookmarks.Name = "group_bookmarks";
            group_bookmarks.Size = new System.Drawing.Size(390, 416);
            group_bookmarks.TabIndex = 3;
            group_bookmarks.TabStop = false;
            group_bookmarks.Text = "Bookmarks";
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
            group_details.Size = new System.Drawing.Size(194, 416);
            group_details.TabIndex = 4;
            group_details.TabStop = false;
            group_details.Text = "Details";
            // 
            // textBox_description
            // 
            textBox_description.BorderColor = System.Drawing.Color.Black;
            textBox_description.DisplayBorder = true;
            textBox_description.Location = new System.Drawing.Point(6, 125);
            textBox_description.MaxLength = 32767;
            textBox_description.Multiline = true;
            textBox_description.Name = "textBox_description";
            textBox_description.OnTextChanged = null;
            textBox_description.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_description.ReadOnly = false;
            textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_description.SelectionStart = 0;
            textBox_description.Size = new System.Drawing.Size(182, 285);
            textBox_description.TabIndex = 5;
            textBox_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            textBox_value.ReadOnly = false;
            textBox_value.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_value.SelectionStart = 0;
            textBox_value.Size = new System.Drawing.Size(182, 23);
            textBox_value.TabIndex = 3;
            textBox_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            textBox_name.ReadOnly = false;
            textBox_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_name.SelectionStart = 0;
            textBox_name.Size = new System.Drawing.Size(182, 23);
            textBox_name.TabIndex = 1;
            textBox_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            textBox_search.ReadOnly = false;
            textBox_search.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_search.SelectionStart = 0;
            textBox_search.Size = new System.Drawing.Size(384, 23);
            textBox_search.TabIndex = 1;
            textBox_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_search.WordWrap = true;
            // 
            // FormBookmarks
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(756, 450);
            Controls.Add(panel_main);
            Controls.Add(statusStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormBookmarks";
            Text = "Bookmarks";
            group_collections.ResumeLayout(false);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            panel_main.ResumeLayout(false);
            panel_bookmarks.ResumeLayout(false);
            group_bookmarks.ResumeLayout(false);
            group_details.ResumeLayout(false);
            group_details.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TreeView tree_bookmarks;
        private System.Windows.Forms.ListBox listbox_collections;
        private System.Windows.Forms.GroupBox group_collections;
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
    }
}