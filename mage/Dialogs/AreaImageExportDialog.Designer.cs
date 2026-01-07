namespace mage.Dialogs
{
    partial class AreaImageExportDialog
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
            checkBox_roomRequireDoors = new System.Windows.Forms.CheckBox();
            listbox_excludedRooms = new System.Windows.Forms.ListBox();
            label_excluded = new System.Windows.Forms.Label();
            button_save = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // checkBox_roomRequireDoors
            // 
            checkBox_roomRequireDoors.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkBox_roomRequireDoors.AutoSize = true;
            checkBox_roomRequireDoors.Checked = true;
            checkBox_roomRequireDoors.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_roomRequireDoors.Location = new System.Drawing.Point(12, 204);
            checkBox_roomRequireDoors.Name = "checkBox_roomRequireDoors";
            checkBox_roomRequireDoors.Size = new System.Drawing.Size(181, 19);
            checkBox_roomRequireDoors.TabIndex = 2;
            checkBox_roomRequireDoors.Text = "Exclude rooms without doors";
            checkBox_roomRequireDoors.UseVisualStyleBackColor = true;
            // 
            // listbox_excludedRooms
            // 
            listbox_excludedRooms.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            listbox_excludedRooms.FormattingEnabled = true;
            listbox_excludedRooms.Location = new System.Drawing.Point(12, 27);
            listbox_excludedRooms.Name = "listbox_excludedRooms";
            listbox_excludedRooms.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            listbox_excludedRooms.Size = new System.Drawing.Size(175, 169);
            listbox_excludedRooms.TabIndex = 3;
            // 
            // label_excluded
            // 
            label_excluded.AutoSize = true;
            label_excluded.Location = new System.Drawing.Point(12, 9);
            label_excluded.Name = "label_excluded";
            label_excluded.Size = new System.Drawing.Size(95, 15);
            label_excluded.TabIndex = 4;
            label_excluded.Text = "Excluded Rooms";
            // 
            // button_save
            // 
            button_save.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button_save.Location = new System.Drawing.Point(12, 229);
            button_save.Name = "button_save";
            button_save.Size = new System.Drawing.Size(175, 23);
            button_save.TabIndex = 5;
            button_save.Text = "Save Area Image";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // AreaImageExportDialog
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(200, 261);
            Controls.Add(button_save);
            Controls.Add(checkBox_roomRequireDoors);
            Controls.Add(label_excluded);
            Controls.Add(listbox_excludedRooms);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AreaImageExportDialog";
            ShowIcon = false;
            Text = "Export Area As Image";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox_roomRequireDoors;
        private System.Windows.Forms.ListBox listbox_excludedRooms;
        private System.Windows.Forms.Label label_excluded;
        private System.Windows.Forms.Button button_save;
    }
}