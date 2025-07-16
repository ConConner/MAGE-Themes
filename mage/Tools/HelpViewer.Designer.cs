namespace mage.Tools
{
    partial class HelpViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpViewer));
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            navigateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            mAGEHelpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            technicalInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            group_help = new System.Windows.Forms.GroupBox();
            panel_help = new System.Windows.Forms.Panel();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            menuStrip1.SuspendLayout();
            group_help.SuspendLayout();
            panel_help.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { navigateToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(623, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // navigateToolStripMenuItem
            // 
            navigateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { mAGEHelpToolStripMenuItem, technicalInformationToolStripMenuItem });
            navigateToolStripMenuItem.Name = "navigateToolStripMenuItem";
            navigateToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            navigateToolStripMenuItem.Text = "Navigate";
            // 
            // mAGEHelpToolStripMenuItem
            // 
            mAGEHelpToolStripMenuItem.Name = "mAGEHelpToolStripMenuItem";
            mAGEHelpToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            mAGEHelpToolStripMenuItem.Text = "MAGE Help";
            // 
            // technicalInformationToolStripMenuItem
            // 
            technicalInformationToolStripMenuItem.Name = "technicalInformationToolStripMenuItem";
            technicalInformationToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            technicalInformationToolStripMenuItem.Text = "Technical Information";
            // 
            // group_help
            // 
            group_help.Dock = System.Windows.Forms.DockStyle.Fill;
            group_help.Location = new System.Drawing.Point(6, 3);
            group_help.Name = "group_help";
            group_help.Size = new System.Drawing.Size(611, 578);
            group_help.TabIndex = 2;
            group_help.TabStop = false;
            // 
            // panel_help
            // 
            panel_help.Controls.Add(group_help);
            panel_help.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_help.Location = new System.Drawing.Point(0, 24);
            panel_help.Name = "panel_help";
            panel_help.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            panel_help.Size = new System.Drawing.Size(623, 584);
            panel_help.TabIndex = 3;
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 608);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(623, 22);
            statusStrip1.TabIndex = 4;
            statusStrip1.Text = "statusStrip1";
            // 
            // HelpViewer
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(623, 630);
            Controls.Add(panel_help);
            Controls.Add(statusStrip1);
            Controls.Add(menuStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "HelpViewer";
            Text = "MAGE Themes Help";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            group_help.ResumeLayout(false);
            panel_help.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem navigateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mAGEHelpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem technicalInformationToolStripMenuItem;
        private System.Windows.Forms.GroupBox group_help;
        private System.Windows.Forms.Panel panel_help;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}