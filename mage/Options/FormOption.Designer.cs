namespace mage.Options
{
    partial class FormOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOption));
            panel_main = new System.Windows.Forms.SplitContainer();
            listBox_pages = new System.Windows.Forms.ListBox();
            seperator1 = new mage.Controls.Seperator();
            ((System.ComponentModel.ISupportInitialize)panel_main).BeginInit();
            panel_main.Panel1.SuspendLayout();
            panel_main.SuspendLayout();
            SuspendLayout();
            // 
            // panel_main
            // 
            panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            panel_main.Location = new System.Drawing.Point(0, 0);
            panel_main.Name = "panel_main";
            // 
            // panel_main.Panel1
            // 
            panel_main.Panel1.Controls.Add(listBox_pages);
            panel_main.Panel1.Controls.Add(seperator1);
            panel_main.Panel1.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            panel_main.Size = new System.Drawing.Size(524, 361);
            panel_main.SplitterDistance = 131;
            panel_main.TabIndex = 0;
            // 
            // listBox_pages
            // 
            listBox_pages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listBox_pages.Dock = System.Windows.Forms.DockStyle.Fill;
            listBox_pages.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            listBox_pages.FormattingEnabled = true;
            listBox_pages.ItemHeight = 21;
            listBox_pages.Location = new System.Drawing.Point(6, 3);
            listBox_pages.Name = "listBox_pages";
            listBox_pages.Size = new System.Drawing.Size(121, 355);
            listBox_pages.TabIndex = 0;
            listBox_pages.SelectedIndexChanged += listBox_Pages_SelectedIndexChanged;
            // 
            // seperator1
            // 
            seperator1.Dock = System.Windows.Forms.DockStyle.Right;
            seperator1.Location = new System.Drawing.Point(127, 3);
            seperator1.Name = "seperator1";
            seperator1.Size = new System.Drawing.Size(1, 355);
            seperator1.TabIndex = 0;
            seperator1.Text = "seperator1";
            // 
            // FormOption
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(524, 361);
            Controls.Add(panel_main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(540, 400);
            Name = "FormOption";
            Text = "Options";
            panel_main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panel_main).EndInit();
            panel_main.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.SplitContainer panel_main;
        private System.Windows.Forms.ListBox listBox_pages;
        private Controls.Seperator seperator1;
    }
}