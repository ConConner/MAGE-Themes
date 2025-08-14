namespace mage.Editors.NewEditors
{
    partial class FormMinimapNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMinimapNew));
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_coor = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_tile = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_spring = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_import = new System.Windows.Forms.ToolStripDropDownButton();
            statusStrip_importRaw = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_export = new System.Windows.Forms.ToolStripDropDownButton();
            statusStrip_exportRaw = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_exportImage = new System.Windows.Forms.ToolStripMenuItem();
            button_apply = new System.Windows.Forms.ToolStripDropDownButton();
            group_selection = new System.Windows.Forms.GroupBox();
            splitContainer1 = new System.Windows.Forms.SplitContainer();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_coor, statusLabel_tile, statusLabel_changes, statusStrip_spring, statusStrip_import, statusStrip_export, button_apply });
            statusStrip.Location = new System.Drawing.Point(0, 426);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(800, 24);
            statusStrip.TabIndex = 12;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel_coor
            // 
            statusLabel_coor.AutoSize = false;
            statusLabel_coor.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            statusLabel_coor.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            statusLabel_coor.Name = "statusLabel_coor";
            statusLabel_coor.Size = new System.Drawing.Size(70, 19);
            statusLabel_coor.Text = "(0, 0)";
            statusLabel_coor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel_tile
            // 
            statusLabel_tile.AutoSize = false;
            statusLabel_tile.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            statusLabel_tile.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            statusLabel_tile.Name = "statusLabel_tile";
            statusLabel_tile.Size = new System.Drawing.Size(70, 19);
            statusLabel_tile.Text = "Tile:";
            statusLabel_tile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 19);
            statusLabel_changes.Text = "-";
            // 
            // statusStrip_spring
            // 
            statusStrip_spring.Name = "statusStrip_spring";
            statusStrip_spring.Size = new System.Drawing.Size(463, 19);
            statusStrip_spring.Spring = true;
            // 
            // statusStrip_import
            // 
            statusStrip_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusStrip_import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { statusStrip_importRaw });
            statusStrip_import.Name = "statusStrip_import";
            statusStrip_import.Size = new System.Drawing.Size(56, 22);
            statusStrip_import.Text = "Import";
            // 
            // statusStrip_importRaw
            // 
            statusStrip_importRaw.Name = "statusStrip_importRaw";
            statusStrip_importRaw.Size = new System.Drawing.Size(180, 22);
            statusStrip_importRaw.Text = "Raw...";
            // 
            // statusStrip_export
            // 
            statusStrip_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusStrip_export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { statusStrip_exportRaw, statusStrip_exportImage });
            statusStrip_export.Name = "statusStrip_export";
            statusStrip_export.Size = new System.Drawing.Size(54, 22);
            statusStrip_export.Text = "Export";
            // 
            // statusStrip_exportRaw
            // 
            statusStrip_exportRaw.Name = "statusStrip_exportRaw";
            statusStrip_exportRaw.Size = new System.Drawing.Size(180, 22);
            statusStrip_exportRaw.Text = "Raw...";
            // 
            // statusStrip_exportImage
            // 
            statusStrip_exportImage.Name = "statusStrip_exportImage";
            statusStrip_exportImage.Size = new System.Drawing.Size(180, 22);
            statusStrip_exportImage.Text = "Image...";
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Image = Properties.Resources.toolbar_save;
            button_apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_apply.Name = "button_apply";
            button_apply.ShowDropDownArrow = false;
            button_apply.Size = new System.Drawing.Size(58, 22);
            button_apply.Text = "Apply";
            // 
            // group_selection
            // 
            group_selection.Dock = System.Windows.Forms.DockStyle.Top;
            group_selection.Location = new System.Drawing.Point(6, 3);
            group_selection.Name = "group_selection";
            group_selection.Size = new System.Drawing.Size(231, 100);
            group_selection.TabIndex = 13;
            group_selection.TabStop = false;
            group_selection.Text = "Selection";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer1.Location = new System.Drawing.Point(0, 0);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(group_selection);
            splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            splitContainer1.Size = new System.Drawing.Size(800, 426);
            splitContainer1.SplitterDistance = 240;
            splitContainer1.TabIndex = 14;
            // 
            // FormMinimapNew
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(statusStrip);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormMinimapNew";
            Text = "Map Editor";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_coor;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_tile;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip_spring;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_import;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_importRaw;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_export;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_exportRaw;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_exportImage;
        private System.Windows.Forms.ToolStripDropDownButton button_apply;
        private System.Windows.Forms.GroupBox group_selection;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}