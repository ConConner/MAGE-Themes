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
            sep_parameters = new mage.Controls.Seperator();
            btn_applyRevert = new System.Windows.Forms.Button();
            pnl_parameters = new System.Windows.Forms.Panel();
            lbl_parameters = new System.Windows.Forms.Label();
            txb_description = new mage.Theming.CustomControls.FlatTextBox();
            lbl_author = new System.Windows.Forms.Label();
            lbl_authorLabel = new System.Windows.Forms.Label();
            lbl_descriptionLabel = new System.Windows.Forms.Label();
            lbl_name = new System.Windows.Forms.Label();
            lbl_labelName = new System.Windows.Forms.Label();
            grp_tweaks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pnl_main).BeginInit();
            pnl_main.Panel1.SuspendLayout();
            pnl_main.Panel2.SuspendLayout();
            pnl_main.SuspendLayout();
            grp_properties.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(0, 429);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(734, 22);
            statusStrip1.TabIndex = 0;
            statusStrip1.Text = "statusStrip1";
            // 
            // grp_tweaks
            // 
            grp_tweaks.Controls.Add(lst_tweaks);
            grp_tweaks.Dock = System.Windows.Forms.DockStyle.Fill;
            grp_tweaks.Location = new System.Drawing.Point(6, 6);
            grp_tweaks.Name = "grp_tweaks";
            grp_tweaks.Size = new System.Drawing.Size(427, 420);
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
            lst_tweaks.Size = new System.Drawing.Size(421, 398);
            lst_tweaks.TabIndex = 0;
            lst_tweaks.UseCompatibleStateImageBehavior = false;
            lst_tweaks.View = System.Windows.Forms.View.Details;
            lst_tweaks.ItemSelectionChanged += lst_tweaks_ItemSelectionChanged;
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
            pnl_main.Size = new System.Drawing.Size(734, 429);
            pnl_main.SplitterDistance = 436;
            pnl_main.TabIndex = 2;
            // 
            // grp_properties
            // 
            grp_properties.Controls.Add(sep_parameters);
            grp_properties.Controls.Add(btn_applyRevert);
            grp_properties.Controls.Add(pnl_parameters);
            grp_properties.Controls.Add(lbl_parameters);
            grp_properties.Controls.Add(txb_description);
            grp_properties.Controls.Add(lbl_author);
            grp_properties.Controls.Add(lbl_authorLabel);
            grp_properties.Controls.Add(lbl_descriptionLabel);
            grp_properties.Controls.Add(lbl_name);
            grp_properties.Controls.Add(lbl_labelName);
            grp_properties.Dock = System.Windows.Forms.DockStyle.Fill;
            grp_properties.Location = new System.Drawing.Point(3, 6);
            grp_properties.Name = "grp_properties";
            grp_properties.Size = new System.Drawing.Size(285, 420);
            grp_properties.TabIndex = 0;
            grp_properties.TabStop = false;
            grp_properties.Text = "Properties";
            // 
            // sep_parameters
            // 
            sep_parameters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sep_parameters.Location = new System.Drawing.Point(6, 154);
            sep_parameters.Name = "sep_parameters";
            sep_parameters.Orientation = System.Windows.Forms.Orientation.Horizontal;
            sep_parameters.Size = new System.Drawing.Size(273, 1);
            sep_parameters.TabIndex = 9;
            sep_parameters.Text = "seperator1";
            // 
            // btn_applyRevert
            // 
            btn_applyRevert.Location = new System.Drawing.Point(204, 391);
            btn_applyRevert.Name = "btn_applyRevert";
            btn_applyRevert.Size = new System.Drawing.Size(75, 23);
            btn_applyRevert.TabIndex = 8;
            btn_applyRevert.Text = "Apply";
            btn_applyRevert.UseVisualStyleBackColor = true;
            btn_applyRevert.Click += btn_applyRevert_Click;
            // 
            // pnl_parameters
            // 
            pnl_parameters.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnl_parameters.AutoScroll = true;
            pnl_parameters.Location = new System.Drawing.Point(6, 182);
            pnl_parameters.Name = "pnl_parameters";
            pnl_parameters.Size = new System.Drawing.Size(273, 203);
            pnl_parameters.TabIndex = 7;
            // 
            // lbl_parameters
            // 
            lbl_parameters.AutoSize = true;
            lbl_parameters.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_parameters.Location = new System.Drawing.Point(6, 161);
            lbl_parameters.Margin = new System.Windows.Forms.Padding(3);
            lbl_parameters.Name = "lbl_parameters";
            lbl_parameters.Size = new System.Drawing.Size(74, 15);
            lbl_parameters.TabIndex = 6;
            lbl_parameters.Text = "Parameters:";
            // 
            // txb_description
            // 
            txb_description.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_description.AutoScroll = true;
            txb_description.BorderColor = System.Drawing.Color.Black;
            txb_description.DisplayBorder = false;
            txb_description.Location = new System.Drawing.Point(86, 61);
            txb_description.MaxLength = 32767;
            txb_description.Multiline = true;
            txb_description.Name = "txb_description";
            txb_description.OnTextChanged = null;
            txb_description.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_description.PlaceholderText = "";
            txb_description.ReadOnly = true;
            txb_description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_description.SelectionStart = 0;
            txb_description.Size = new System.Drawing.Size(193, 87);
            txb_description.TabIndex = 5;
            txb_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_description.ValueBox = false;
            txb_description.WordWrap = true;
            // 
            // lbl_author
            // 
            lbl_author.AutoSize = true;
            lbl_author.Location = new System.Drawing.Point(83, 42);
            lbl_author.Name = "lbl_author";
            lbl_author.Size = new System.Drawing.Size(102, 15);
            lbl_author.TabIndex = 4;
            lbl_author.Text = "Insert Author here";
            // 
            // lbl_authorLabel
            // 
            lbl_authorLabel.AutoSize = true;
            lbl_authorLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_authorLabel.Location = new System.Drawing.Point(6, 42);
            lbl_authorLabel.Margin = new System.Windows.Forms.Padding(3);
            lbl_authorLabel.Name = "lbl_authorLabel";
            lbl_authorLabel.Size = new System.Drawing.Size(49, 15);
            lbl_authorLabel.TabIndex = 3;
            lbl_authorLabel.Text = "Author:";
            // 
            // lbl_descriptionLabel
            // 
            lbl_descriptionLabel.AutoSize = true;
            lbl_descriptionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_descriptionLabel.Location = new System.Drawing.Point(6, 64);
            lbl_descriptionLabel.Margin = new System.Windows.Forms.Padding(3);
            lbl_descriptionLabel.Name = "lbl_descriptionLabel";
            lbl_descriptionLabel.Size = new System.Drawing.Size(74, 15);
            lbl_descriptionLabel.TabIndex = 2;
            lbl_descriptionLabel.Text = "Description:";
            // 
            // lbl_name
            // 
            lbl_name.AutoSize = true;
            lbl_name.Location = new System.Drawing.Point(83, 21);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new System.Drawing.Size(97, 15);
            lbl_name.TabIndex = 1;
            lbl_name.Text = "Insert Name here";
            // 
            // lbl_labelName
            // 
            lbl_labelName.AutoSize = true;
            lbl_labelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_labelName.Location = new System.Drawing.Point(6, 21);
            lbl_labelName.Margin = new System.Windows.Forms.Padding(3);
            lbl_labelName.Name = "lbl_labelName";
            lbl_labelName.Size = new System.Drawing.Size(43, 15);
            lbl_labelName.TabIndex = 0;
            lbl_labelName.Text = "Name:";
            // 
            // FormTweaks
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(734, 451);
            Controls.Add(pnl_main);
            Controls.Add(statusStrip1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(750, 490);
            Name = "FormTweaks";
            Text = "Tweak Manager";
            grp_tweaks.ResumeLayout(false);
            pnl_main.Panel1.ResumeLayout(false);
            pnl_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pnl_main).EndInit();
            pnl_main.ResumeLayout(false);
            grp_properties.ResumeLayout(false);
            grp_properties.PerformLayout();
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
        private System.Windows.Forms.Label lbl_labelName;
        private Theming.CustomControls.FlatTextBox txb_description;
        private System.Windows.Forms.Label lbl_author;
        private System.Windows.Forms.Label lbl_authorLabel;
        private System.Windows.Forms.Label lbl_descriptionLabel;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.Label lbl_parameters;
        private System.Windows.Forms.Button btn_applyRevert;
        private System.Windows.Forms.Panel pnl_parameters;
        private Controls.Seperator sep_parameters;
    }
}