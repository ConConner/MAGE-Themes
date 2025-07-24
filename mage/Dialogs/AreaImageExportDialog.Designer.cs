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
            button_choose = new System.Windows.Forms.Button();
            checkBox_roomRequireDoors = new System.Windows.Forms.CheckBox();
            listbox_excludedRooms = new System.Windows.Forms.ListBox();
            label_excluded = new System.Windows.Forms.Label();
            button_save = new System.Windows.Forms.Button();
            panel1 = new mage.Controls.ExtendedPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // button_choose
            // 
            button_choose.Location = new System.Drawing.Point(12, 12);
            button_choose.Name = "button_choose";
            button_choose.Size = new System.Drawing.Size(181, 21);
            button_choose.TabIndex = 0;
            button_choose.Text = "Choose save location";
            button_choose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            button_choose.UseVisualStyleBackColor = true;
            button_choose.Click += button_choose_Click;
            // 
            // checkBox_roomRequireDoors
            // 
            checkBox_roomRequireDoors.AutoSize = true;
            checkBox_roomRequireDoors.Checked = true;
            checkBox_roomRequireDoors.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_roomRequireDoors.Location = new System.Drawing.Point(0, 164);
            checkBox_roomRequireDoors.Name = "checkBox_roomRequireDoors";
            checkBox_roomRequireDoors.Size = new System.Drawing.Size(181, 19);
            checkBox_roomRequireDoors.TabIndex = 2;
            checkBox_roomRequireDoors.Text = "Exclude rooms without doors";
            checkBox_roomRequireDoors.UseVisualStyleBackColor = true;
            // 
            // listbox_excludedRooms
            // 
            listbox_excludedRooms.FormattingEnabled = true;
            listbox_excludedRooms.ItemHeight = 15;
            listbox_excludedRooms.Location = new System.Drawing.Point(1, 34);
            listbox_excludedRooms.Name = "listbox_excludedRooms";
            listbox_excludedRooms.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            listbox_excludedRooms.Size = new System.Drawing.Size(181, 124);
            listbox_excludedRooms.TabIndex = 3;
            // 
            // label_excluded
            // 
            label_excluded.AutoSize = true;
            label_excluded.Location = new System.Drawing.Point(0, 16);
            label_excluded.Name = "label_excluded";
            label_excluded.Size = new System.Drawing.Size(95, 15);
            label_excluded.TabIndex = 4;
            label_excluded.Text = "Excluded Rooms";
            // 
            // button_save
            // 
            button_save.Location = new System.Drawing.Point(0, 189);
            button_save.Name = "button_save";
            button_save.Size = new System.Drawing.Size(181, 23);
            button_save.TabIndex = 5;
            button_save.Text = "Save Area Image";
            button_save.UseVisualStyleBackColor = true;
            button_save.Click += button_save_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(button_save);
            panel1.Controls.Add(label_excluded);
            panel1.Controls.Add(checkBox_roomRequireDoors);
            panel1.Controls.Add(listbox_excludedRooms);
            panel1.Enabled = false;
            panel1.Location = new System.Drawing.Point(12, 39);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(182, 212);
            panel1.TabIndex = 6;
            // 
            // AreaImageExportDialog
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(206, 263);
            Controls.Add(panel1);
            Controls.Add(button_choose);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AreaImageExportDialog";
            Text = "Export Area As Image";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button button_choose;
        private System.Windows.Forms.CheckBox checkBox_roomRequireDoors;
        private System.Windows.Forms.ListBox listbox_excludedRooms;
        private System.Windows.Forms.Label label_excluded;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Panel panel1;
    }
}