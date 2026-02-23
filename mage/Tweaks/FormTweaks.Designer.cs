namespace mage.Tweaks
{
    partial class FormTweaks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTweaks));
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            grp_tweaks = new System.Windows.Forms.GroupBox();
            lst_tweaks = new System.Windows.Forms.ListView();
            clm_name = new System.Windows.Forms.ColumnHeader();
            clm_author = new System.Windows.Forms.ColumnHeader();
            pnl_main = new System.Windows.Forms.SplitContainer();
            grp_properties = new System.Windows.Forms.GroupBox();
            grp_tweaks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnl_main).BeginInit();
            pnl_main.Panel1.SuspendLayout();
            pnl_main.Panel2.SuspendLayout();
            pnl_main.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(797, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // grp_tweaks
            // 
            grp_tweaks.Controls.Add(lst_tweaks);
            grp_tweaks.Dock = System.Windows.Forms.DockStyle.Fill;
            grp_tweaks.Location = new System.Drawing.Point(6, 6);
            grp_tweaks.Name = "grp_tweaks";
            grp_tweaks.Size = new System.Drawing.Size(490, 419);
            grp_tweaks.TabIndex = 1;
            grp_tweaks.TabStop = false;
            grp_tweaks.Text = "Tweaks";
            // 
            // lst_tweaks
            // 
            lst_tweaks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lst_tweaks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] { clm_name, clm_author });
            lst_tweaks.Dock = System.Windows.Forms.DockStyle.Fill;
            lst_tweaks.FullRowSelect = true;
            lst_tweaks.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            lst_tweaks.Location = new System.Drawing.Point(3, 19);
            lst_tweaks.MultiSelect = false;
            lst_tweaks.Name = "lst_tweaks";
            lst_tweaks.Size = new System.Drawing.Size(484, 397);
            lst_tweaks.TabIndex = 0;
            lst_tweaks.UseCompatibleStateImageBehavior = false;
            lst_tweaks.View = System.Windows.Forms.View.Details;
            lst_tweaks.Resize += lst_tweaks_Resize;
            // 
            // clm_name
            // 
            clm_name.Text = "Name";
            clm_name.Width = 300;
            // 
            // clm_author
            // 
            clm_author.Text = "Author";
            clm_author.Width = 150;
            // 
            // pnl_main
            // 
            pnl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            pnl_main.Location = new System.Drawing.Point(0, 0);
            pnl_main.Name = "pnl_main";
            // 
            // pnl_main.Panel1
            // 
            pnl_main.Panel1.Controls.Add(grp_tweaks);
            pnl_main.Panel1.Padding = new System.Windows.Forms.Padding(6, 6, 3, 3);
            // 
            // pnl_main.Panel2
            // 
            pnl_main.Panel2.Controls.Add(grp_properties);
            pnl_main.Panel2.Padding = new System.Windows.Forms.Padding(3, 6, 6, 3);
            pnl_main.Size = new System.Drawing.Size(797, 428);
            pnl_main.SplitterDistance = 499;
            pnl_main.TabIndex = 2;
            // 
            // grp_properties
            // 
            grp_properties.Dock = System.Windows.Forms.DockStyle.Fill;
            grp_properties.Location = new System.Drawing.Point(3, 6);
            grp_properties.Name = "grp_properties";
            grp_properties.Size = new System.Drawing.Size(285, 419);
            grp_properties.TabIndex = 0;
            grp_properties.TabStop = false;
            grp_properties.Text = "Properties";
            // 
            // FormTweaks
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(797, 450);
            Controls.Add(pnl_main);
            Controls.Add(statusStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormTweaks";
            Text = "Tweak Manager";
            grp_tweaks.ResumeLayout(false);
            pnl_main.Panel1.ResumeLayout(false);
            pnl_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnl_main).EndInit();
            pnl_main.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox grp_tweaks;
        private System.Windows.Forms.SplitContainer pnl_main;
        private System.Windows.Forms.ListView lst_tweaks;
        private System.Windows.Forms.ColumnHeader clm_name;
        private System.Windows.Forms.ColumnHeader clm_author;
        private System.Windows.Forms.GroupBox grp_properties;
    }
}