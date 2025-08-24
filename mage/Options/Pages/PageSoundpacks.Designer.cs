namespace mage.Options.Pages
{
    partial class PageSoundpacks
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            grp_info = new System.Windows.Forms.GroupBox();
            txb_info = new mage.Theming.CustomControls.FlatTextBox();
            lst_packs = new System.Windows.Forms.ListBox();
            btn_select_path = new System.Windows.Forms.Button();
            textBox_path = new mage.Theming.CustomControls.FlatTextBox();
            group_soundpacks = new System.Windows.Forms.GroupBox();
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            grp_info.SuspendLayout();
            group_soundpacks.SuspendLayout();
            SuspendLayout();
            // 
            // grp_info
            // 
            grp_info.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grp_info.Controls.Add(txb_info);
            grp_info.Location = new System.Drawing.Point(167, 35);
            grp_info.Name = "grp_info";
            grp_info.Padding = new System.Windows.Forms.Padding(6, 6, 6, 3);
            grp_info.Size = new System.Drawing.Size(267, 254);
            grp_info.TabIndex = 6;
            grp_info.TabStop = false;
            grp_info.Text = "Pack Info";
            // 
            // txb_info
            // 
            txb_info.BorderColor = System.Drawing.Color.Black;
            txb_info.DisplayBorder = false;
            txb_info.Dock = System.Windows.Forms.DockStyle.Fill;
            txb_info.Location = new System.Drawing.Point(6, 22);
            txb_info.MaxLength = 32767;
            txb_info.Multiline = true;
            txb_info.Name = "txb_info";
            txb_info.OnTextChanged = null;
            txb_info.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_info.PlaceholderText = "";
            txb_info.ReadOnly = true;
            txb_info.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_info.SelectionStart = 0;
            txb_info.Size = new System.Drawing.Size(255, 229);
            txb_info.TabIndex = 0;
            txb_info.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_info.ValueBox = false;
            txb_info.WordWrap = true;
            // 
            // lst_packs
            // 
            lst_packs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lst_packs.Dock = System.Windows.Forms.DockStyle.Fill;
            lst_packs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lst_packs.FormattingEnabled = true;
            lst_packs.ItemHeight = 21;
            lst_packs.Location = new System.Drawing.Point(6, 22);
            lst_packs.Name = "lst_packs";
            lst_packs.Size = new System.Drawing.Size(146, 229);
            lst_packs.TabIndex = 5;
            lst_packs.SelectedIndexChanged += lst_packs_SelectedIndexChanged;
            // 
            // btn_select_path
            // 
            btn_select_path.Image = Properties.Resources.toolbar_open;
            btn_select_path.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_select_path.Location = new System.Drawing.Point(6, 6);
            btn_select_path.Name = "btn_select_path";
            btn_select_path.Size = new System.Drawing.Size(155, 23);
            btn_select_path.TabIndex = 4;
            btn_select_path.Text = "Set Soundpacks Path";
            btn_select_path.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            btn_select_path.UseVisualStyleBackColor = true;
            btn_select_path.Click += btn_select_path_Click;
            // 
            // textBox_path
            // 
            textBox_path.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_path.BorderColor = System.Drawing.Color.Black;
            textBox_path.DisplayBorder = false;
            textBox_path.Location = new System.Drawing.Point(167, 6);
            textBox_path.MaxLength = 32767;
            textBox_path.Multiline = false;
            textBox_path.Name = "textBox_path";
            textBox_path.OnTextChanged = null;
            textBox_path.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_path.PlaceholderText = "";
            textBox_path.ReadOnly = true;
            textBox_path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_path.SelectionStart = 0;
            textBox_path.Size = new System.Drawing.Size(267, 23);
            textBox_path.TabIndex = 7;
            textBox_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_path.ValueBox = false;
            textBox_path.WordWrap = true;
            // 
            // group_soundpacks
            // 
            group_soundpacks.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            group_soundpacks.Controls.Add(lst_packs);
            group_soundpacks.Location = new System.Drawing.Point(6, 35);
            group_soundpacks.Name = "group_soundpacks";
            group_soundpacks.Padding = new System.Windows.Forms.Padding(6, 6, 3, 3);
            group_soundpacks.Size = new System.Drawing.Size(155, 254);
            group_soundpacks.TabIndex = 8;
            group_soundpacks.TabStop = false;
            group_soundpacks.Text = "Soundpacks";
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(3, 292);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(434, 22);
            statusStrip1.TabIndex = 9;
            statusStrip1.Text = "statusStrip1";
            // 
            // PageSoundpacks
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            Controls.Add(statusStrip1);
            Controls.Add(group_soundpacks);
            Controls.Add(textBox_path);
            Controls.Add(grp_info);
            Controls.Add(btn_select_path);
            Name = "PageSoundpacks";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(440, 317);
            grp_info.ResumeLayout(false);
            group_soundpacks.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox grp_info;
        private Theming.CustomControls.FlatTextBox txb_info;
        private System.Windows.Forms.ListBox lst_packs;
        private System.Windows.Forms.Button btn_select_path;
        private Theming.CustomControls.FlatTextBox textBox_path;
        private System.Windows.Forms.GroupBox group_soundpacks;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
