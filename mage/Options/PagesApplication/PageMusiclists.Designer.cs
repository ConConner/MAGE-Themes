namespace mage.Options.Pages
{
    partial class PageMusiclists
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
            txb_preview = new mage.Theming.CustomControls.FlatTextBox();
            lst_muslists = new System.Windows.Forms.ListBox();
            btn_select_path = new System.Windows.Forms.Button();
            textBox_path = new mage.Theming.CustomControls.FlatTextBox();
            group_Musiclists = new System.Windows.Forms.GroupBox();
            grp_info.SuspendLayout();
            group_Musiclists.SuspendLayout();
            SuspendLayout();
            // 
            // grp_info
            // 
            grp_info.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            grp_info.Controls.Add(txb_preview);
            grp_info.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            grp_info.Location = new System.Drawing.Point(167, 58);
            grp_info.Name = "grp_info";
            grp_info.Padding = new System.Windows.Forms.Padding(6, 6, 6, 3);
            grp_info.Size = new System.Drawing.Size(267, 253);
            grp_info.TabIndex = 6;
            grp_info.TabStop = false;
            grp_info.Text = "List Preview";
            // 
            // txb_preview
            // 
            txb_preview.BorderColor = System.Drawing.Color.Black;
            txb_preview.DisplayBorder = false;
            txb_preview.Dock = System.Windows.Forms.DockStyle.Fill;
            txb_preview.Location = new System.Drawing.Point(6, 22);
            txb_preview.MaxLength = 32767;
            txb_preview.Multiline = true;
            txb_preview.Name = "txb_preview";
            txb_preview.OnTextChanged = null;
            txb_preview.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_preview.PlaceholderText = "";
            txb_preview.ReadOnly = true;
            txb_preview.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_preview.SelectionStart = 0;
            txb_preview.Size = new System.Drawing.Size(255, 228);
            txb_preview.TabIndex = 0;
            txb_preview.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_preview.ValueBox = false;
            txb_preview.WordWrap = true;
            // 
            // lst_muslists
            // 
            lst_muslists.BorderStyle = System.Windows.Forms.BorderStyle.None;
            lst_muslists.Dock = System.Windows.Forms.DockStyle.Fill;
            lst_muslists.Font = new System.Drawing.Font("Segoe UI Semilight", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            lst_muslists.FormattingEnabled = true;
            lst_muslists.ItemHeight = 15;
            lst_muslists.Location = new System.Drawing.Point(6, 22);
            lst_muslists.Name = "lst_muslists";
            lst_muslists.Size = new System.Drawing.Size(146, 228);
            lst_muslists.TabIndex = 5;
            lst_muslists.SelectedIndexChanged += lst_muslists_SelectedIndexChanged;
            // 
            // btn_select_path
            // 
            btn_select_path.Image = Properties.Resources.toolbar_open;
            btn_select_path.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_select_path.Location = new System.Drawing.Point(6, 6);
            btn_select_path.Name = "btn_select_path";
            btn_select_path.Size = new System.Drawing.Size(155, 23);
            btn_select_path.TabIndex = 4;
            btn_select_path.Text = "Set Musiclists Path";
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
            textBox_path.Multiline = true;
            textBox_path.Name = "textBox_path";
            textBox_path.OnTextChanged = null;
            textBox_path.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_path.PlaceholderText = "";
            textBox_path.ReadOnly = true;
            textBox_path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_path.SelectionStart = 0;
            textBox_path.Size = new System.Drawing.Size(267, 46);
            textBox_path.TabIndex = 7;
            textBox_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_path.ValueBox = false;
            textBox_path.WordWrap = true;
            // 
            // group_Musiclists
            // 
            group_Musiclists.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            group_Musiclists.Controls.Add(lst_muslists);
            group_Musiclists.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            group_Musiclists.Location = new System.Drawing.Point(6, 58);
            group_Musiclists.Name = "group_Musiclists";
            group_Musiclists.Padding = new System.Windows.Forms.Padding(6, 6, 3, 3);
            group_Musiclists.Size = new System.Drawing.Size(155, 253);
            group_Musiclists.TabIndex = 8;
            group_Musiclists.TabStop = false;
            group_Musiclists.Text = "Musiclists";
            // 
            // PageMusiclists
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            Controls.Add(group_Musiclists);
            Controls.Add(textBox_path);
            Controls.Add(grp_info);
            Controls.Add(btn_select_path);
            Name = "PageMusiclists";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(440, 317);
            grp_info.ResumeLayout(false);
            group_Musiclists.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grp_info;
        private Theming.CustomControls.FlatTextBox txb_preview;
        private System.Windows.Forms.ListBox lst_muslists;
        private System.Windows.Forms.Button btn_select_path;
        private Theming.CustomControls.FlatTextBox textBox_path;
        private System.Windows.Forms.GroupBox group_Musiclists;
    }
}
