namespace mage.Bookmarks
{
    partial class BookmarkCopyDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BookmarkCopyDialog));
            label_bookmarkName = new System.Windows.Forms.Label();
            radio_global = new System.Windows.Forms.RadioButton();
            group_copyTo = new System.Windows.Forms.GroupBox();
            radio_project = new System.Windows.Forms.RadioButton();
            radio_createCollection = new System.Windows.Forms.RadioButton();
            radio_addToExisting = new System.Windows.Forms.RadioButton();
            group_collection = new System.Windows.Forms.GroupBox();
            list_collections = new System.Windows.Forms.ListBox();
            checkbox_includePath = new System.Windows.Forms.CheckBox();
            button_ok = new System.Windows.Forms.Button();
            button_cancel = new System.Windows.Forms.Button();
            group_copyTo.SuspendLayout();
            group_collection.SuspendLayout();
            SuspendLayout();
            // 
            // label_bookmarkName
            // 
            label_bookmarkName.AutoSize = true;
            label_bookmarkName.Location = new System.Drawing.Point(12, 9);
            label_bookmarkName.Name = "label_bookmarkName";
            label_bookmarkName.Size = new System.Drawing.Size(64, 15);
            label_bookmarkName.TabIndex = 0;
            label_bookmarkName.Text = "Bookmark:";
            // 
            // radio_global
            // 
            radio_global.AutoSize = true;
            radio_global.Location = new System.Drawing.Point(6, 22);
            radio_global.Name = "radio_global";
            radio_global.Size = new System.Drawing.Size(178, 19);
            radio_global.TabIndex = 2;
            radio_global.Text = "Global Bookmark Collections";
            radio_global.UseVisualStyleBackColor = true;
            radio_global.CheckedChanged += radio_global_CheckedChanged;
            // 
            // group_copyTo
            // 
            group_copyTo.Controls.Add(radio_project);
            group_copyTo.Controls.Add(radio_global);
            group_copyTo.Location = new System.Drawing.Point(12, 30);
            group_copyTo.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            group_copyTo.Name = "group_copyTo";
            group_copyTo.Size = new System.Drawing.Size(231, 77);
            group_copyTo.TabIndex = 3;
            group_copyTo.TabStop = false;
            group_copyTo.Text = "Copy Bookmark to:";
            // 
            // radio_project
            // 
            radio_project.AutoSize = true;
            radio_project.Location = new System.Drawing.Point(6, 47);
            radio_project.Name = "radio_project";
            radio_project.Size = new System.Drawing.Size(181, 19);
            radio_project.TabIndex = 3;
            radio_project.Text = "Project Bookmark Collections";
            radio_project.UseVisualStyleBackColor = true;
            radio_project.CheckedChanged += radio_global_CheckedChanged;
            // 
            // radio_createCollection
            // 
            radio_createCollection.AutoSize = true;
            radio_createCollection.Location = new System.Drawing.Point(6, 22);
            radio_createCollection.Name = "radio_createCollection";
            radio_createCollection.Size = new System.Drawing.Size(198, 19);
            radio_createCollection.TabIndex = 4;
            radio_createCollection.Text = "Create new Bookmark Collection";
            radio_createCollection.UseVisualStyleBackColor = true;
            radio_createCollection.CheckedChanged += radio_createCollection_CheckedChanged;
            // 
            // radio_addToExisting
            // 
            radio_addToExisting.AutoSize = true;
            radio_addToExisting.Location = new System.Drawing.Point(6, 47);
            radio_addToExisting.Name = "radio_addToExisting";
            radio_addToExisting.Size = new System.Drawing.Size(219, 19);
            radio_addToExisting.TabIndex = 5;
            radio_addToExisting.Text = "Add to existing Bookmark Collection";
            radio_addToExisting.UseVisualStyleBackColor = true;
            radio_addToExisting.CheckedChanged += radio_createCollection_CheckedChanged;
            // 
            // group_collection
            // 
            group_collection.Controls.Add(list_collections);
            group_collection.Controls.Add(radio_createCollection);
            group_collection.Controls.Add(radio_addToExisting);
            group_collection.Location = new System.Drawing.Point(12, 113);
            group_collection.Name = "group_collection";
            group_collection.Size = new System.Drawing.Size(231, 179);
            group_collection.TabIndex = 6;
            group_collection.TabStop = false;
            group_collection.Text = "Collection";
            // 
            // list_collections
            // 
            list_collections.FormattingEnabled = true;
            list_collections.ItemHeight = 15;
            list_collections.Location = new System.Drawing.Point(6, 76);
            list_collections.Name = "list_collections";
            list_collections.Size = new System.Drawing.Size(219, 94);
            list_collections.TabIndex = 6;
            // 
            // checkbox_includePath
            // 
            checkbox_includePath.AutoSize = true;
            checkbox_includePath.Checked = true;
            checkbox_includePath.CheckState = System.Windows.Forms.CheckState.Checked;
            checkbox_includePath.Location = new System.Drawing.Point(12, 298);
            checkbox_includePath.Name = "checkbox_includePath";
            checkbox_includePath.Size = new System.Drawing.Size(114, 19);
            checkbox_includePath.TabIndex = 7;
            checkbox_includePath.Text = "Include Full Path";
            checkbox_includePath.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            button_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_ok.Location = new System.Drawing.Point(87, 331);
            button_ok.Name = "button_ok";
            button_ok.Size = new System.Drawing.Size(75, 23);
            button_ok.TabIndex = 8;
            button_ok.Text = "OK";
            button_ok.UseVisualStyleBackColor = true;
            button_ok.Click += button_ok_Click;
            // 
            // button_cancel
            // 
            button_cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            button_cancel.Location = new System.Drawing.Point(168, 331);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new System.Drawing.Size(75, 23);
            button_cancel.TabIndex = 9;
            button_cancel.Text = "Cancel";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            // 
            // BookmarkCopyDialog
            // 
            AcceptButton = button_ok;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            CancelButton = button_cancel;
            ClientSize = new System.Drawing.Size(255, 366);
            Controls.Add(button_cancel);
            Controls.Add(button_ok);
            Controls.Add(checkbox_includePath);
            Controls.Add(group_collection);
            Controls.Add(group_copyTo);
            Controls.Add(label_bookmarkName);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BookmarkCopyDialog";
            Text = "Copy Bookmark";
            group_copyTo.ResumeLayout(false);
            group_copyTo.PerformLayout();
            group_collection.ResumeLayout(false);
            group_collection.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label_bookmarkName;
        private System.Windows.Forms.RadioButton radio_global;
        private System.Windows.Forms.GroupBox group_copyTo;
        private System.Windows.Forms.RadioButton radio_project;
        private System.Windows.Forms.RadioButton radio_createCollection;
        private System.Windows.Forms.RadioButton radio_addToExisting;
        private System.Windows.Forms.GroupBox group_collection;
        private System.Windows.Forms.ListBox list_collections;
        private System.Windows.Forms.CheckBox checkbox_includePath;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}