namespace mage
{
    partial class FormPatches
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPatches));
            button_apply = new System.Windows.Forms.Button();
            button_close = new System.Windows.Forms.Button();
            listView_patches = new System.Windows.Forms.ListView();
            columnHeader_patches = new System.Windows.Forms.ColumnHeader();
            columnHeader_author = new System.Windows.Forms.ColumnHeader();
            columnHeader_applied = new System.Windows.Forms.ColumnHeader();
            SuspendLayout();
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Location = new System.Drawing.Point(12, 182);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(75, 23);
            button_apply.TabIndex = 1;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // button_close
            // 
            button_close.Location = new System.Drawing.Point(276, 182);
            button_close.Name = "button_close";
            button_close.Size = new System.Drawing.Size(75, 23);
            button_close.TabIndex = 2;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // listView_patches
            // 
            listView_patches.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { columnHeader_patches, columnHeader_author, columnHeader_applied });
            listView_patches.FullRowSelect = true;
            listView_patches.Location = new System.Drawing.Point(12, 12);
            listView_patches.MultiSelect = false;
            listView_patches.Name = "listView_patches";
            listView_patches.Size = new System.Drawing.Size(339, 164);
            listView_patches.TabIndex = 0;
            listView_patches.UseCompatibleStateImageBehavior = false;
            listView_patches.View = System.Windows.Forms.View.Details;
            listView_patches.SelectedIndexChanged += listView_patches_SelectedIndexChanged;
            // 
            // columnHeader_patches
            // 
            columnHeader_patches.Text = "Patches";
            columnHeader_patches.Width = 203;
            // 
            // columnHeader_author
            // 
            columnHeader_author.Text = "Author";
            columnHeader_author.Width = 85;
            // 
            // columnHeader_applied
            // 
            columnHeader_applied.Text = "Applied";
            columnHeader_applied.Width = 51;
            // 
            // FormPatches
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(363, 217);
            Controls.Add(listView_patches);
            Controls.Add(button_close);
            Controls.Add(button_apply);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormPatches";
            Text = "Patches";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.ListView listView_patches;
        private System.Windows.Forms.ColumnHeader columnHeader_patches;
        private System.Windows.Forms.ColumnHeader columnHeader_applied;
        private System.Windows.Forms.ColumnHeader columnHeader_author;
    }
}