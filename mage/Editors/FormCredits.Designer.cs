namespace mage.Editors
{
    partial class FormCredits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCredits));
            statusStrip_main = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            spring = new System.Windows.Forms.ToolStripStatusLabel();
            statusButton_import = new System.Windows.Forms.ToolStripDropDownButton();
            statusButton_export = new System.Windows.Forms.ToolStripDropDownButton();
            button_apply = new System.Windows.Forms.ToolStripDropDownButton();
            dataGrid_credits = new System.Windows.Forms.DataGridView();
            button_testCredits = new System.Windows.Forms.ToolStripDropDownButton();
            statusStrip_main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_credits).BeginInit();
            SuspendLayout();
            // 
            // statusStrip_main
            // 
            statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_changes, button_testCredits, spring, statusButton_import, statusButton_export, button_apply });
            statusStrip_main.Location = new System.Drawing.Point(6, 501);
            statusStrip_main.Name = "statusStrip_main";
            statusStrip_main.Size = new System.Drawing.Size(450, 24);
            statusStrip_main.TabIndex = 3;
            statusStrip_main.Text = "statusStrip1";
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(16, 19);
            statusLabel_changes.Text = "-";
            // 
            // spring
            // 
            spring.Name = "spring";
            spring.Size = new System.Drawing.Size(213, 17);
            spring.Spring = true;
            // 
            // statusButton_import
            // 
            statusButton_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusButton_import.Image = (System.Drawing.Image)resources.GetObject("statusButton_import.Image");
            statusButton_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            statusButton_import.Name = "statusButton_import";
            statusButton_import.ShowDropDownArrow = false;
            statusButton_import.Size = new System.Drawing.Size(47, 22);
            statusButton_import.Text = "Import";
            // 
            // statusButton_export
            // 
            statusButton_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusButton_export.Image = (System.Drawing.Image)resources.GetObject("statusButton_export.Image");
            statusButton_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            statusButton_export.Name = "statusButton_export";
            statusButton_export.ShowDropDownArrow = false;
            statusButton_export.Size = new System.Drawing.Size(45, 20);
            statusButton_export.Text = "Export";
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Image = Properties.Resources.toolbar_save;
            button_apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_apply.Name = "button_apply";
            button_apply.ShowDropDownArrow = false;
            button_apply.Size = new System.Drawing.Size(58, 20);
            button_apply.Text = "Apply";
            // 
            // dataGrid_credits
            // 
            dataGrid_credits.AllowUserToOrderColumns = true;
            dataGrid_credits.AllowUserToResizeRows = false;
            dataGrid_credits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGrid_credits.Dock = System.Windows.Forms.DockStyle.Fill;
            dataGrid_credits.Location = new System.Drawing.Point(6, 6);
            dataGrid_credits.Name = "dataGrid_credits";
            dataGrid_credits.RowHeadersVisible = false;
            dataGrid_credits.RowTemplate.Height = 25;
            dataGrid_credits.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dataGrid_credits.Size = new System.Drawing.Size(450, 495);
            dataGrid_credits.TabIndex = 4;
            dataGrid_credits.CellValueChanged += dataGrid_credits_CellValueChanged;
            // 
            // button_testCredits
            // 
            button_testCredits.Image = Properties.Resources.control_play_blue;
            button_testCredits.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_testCredits.Name = "button_testCredits";
            button_testCredits.ShowDropDownArrow = false;
            button_testCredits.Size = new System.Drawing.Size(87, 22);
            button_testCredits.Text = "Test Credits";
            // 
            // FormCredits
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(462, 531);
            Controls.Add(dataGrid_credits);
            Controls.Add(statusStrip_main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormCredits";
            Padding = new System.Windows.Forms.Padding(6);
            Text = "Credits Editor";
            FormClosing += FormCredits_FormClosing;
            statusStrip_main.ResumeLayout(false);
            statusStrip_main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGrid_credits).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.ToolStripStatusLabel spring;
        private System.Windows.Forms.ToolStripDropDownButton statusButton_import;
        private System.Windows.Forms.ToolStripDropDownButton statusButton_export;
        private System.Windows.Forms.ToolStripDropDownButton button_apply;
        private System.Windows.Forms.DataGridView dataGrid_credits;
        private System.Windows.Forms.ToolStripDropDownButton button_testCredits;
    }
}