namespace mage
{
    partial class FormWeapon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWeapon));
            treeView = new System.Windows.Forms.TreeView();
            button_gfx = new System.Windows.Forms.Button();
            button_palette = new System.Windows.Forms.Button();
            button_apply = new System.Windows.Forms.Button();
            button_close = new System.Windows.Forms.Button();
            textBox_value = new mage.Theming.CustomControls.FlatTextBox();
            textBox_gfx = new mage.Theming.CustomControls.FlatTextBox();
            textBox_palette = new mage.Theming.CustomControls.FlatTextBox();
            textBox_valOffset = new mage.Theming.CustomControls.FlatTextBox();
            label_value = new System.Windows.Forms.Label();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // treeView
            // 
            treeView.HideSelection = false;
            treeView.Location = new System.Drawing.Point(14, 14);
            treeView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            treeView.Name = "treeView";
            treeView.Size = new System.Drawing.Size(228, 307);
            treeView.TabIndex = 0;
            treeView.TabStop = false;
            treeView.AfterSelect += treeView_AfterSelect;
            // 
            // button_gfx
            // 
            button_gfx.Enabled = false;
            button_gfx.Location = new System.Drawing.Point(250, 43);
            button_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_gfx.Name = "button_gfx";
            button_gfx.Size = new System.Drawing.Size(88, 27);
            button_gfx.TabIndex = 0;
            button_gfx.Text = "Edit GFX";
            button_gfx.UseVisualStyleBackColor = true;
            button_gfx.Click += button_gfx_Click;
            // 
            // button_palette
            // 
            button_palette.Enabled = false;
            button_palette.Location = new System.Drawing.Point(250, 114);
            button_palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_palette.Name = "button_palette";
            button_palette.Size = new System.Drawing.Size(88, 27);
            button_palette.TabIndex = 1;
            button_palette.Text = "Edit palette";
            button_palette.UseVisualStyleBackColor = true;
            button_palette.Click += button_palette_Click;
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Location = new System.Drawing.Point(250, 215);
            button_apply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(88, 27);
            button_apply.TabIndex = 3;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // button_close
            // 
            button_close.Location = new System.Drawing.Point(250, 297);
            button_close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_close.Name = "button_close";
            button_close.Size = new System.Drawing.Size(88, 27);
            button_close.TabIndex = 4;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // textBox_value
            // 
            textBox_value.BorderColor = System.Drawing.Color.Black;
            textBox_value.DisplayBorder = true;
            textBox_value.Enabled = false;
            textBox_value.Location = new System.Drawing.Point(301, 186);
            textBox_value.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_value.MaxLength = 32767;
            textBox_value.Multiline = false;
            textBox_value.Name = "textBox_value";
            textBox_value.OnTextChanged = null;
            textBox_value.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_value.PlaceholderText = "";
            textBox_value.ReadOnly = false;
            textBox_value.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_value.SelectionStart = 0;
            textBox_value.Size = new System.Drawing.Size(37, 23);
            textBox_value.TabIndex = 2;
            textBox_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_value.ValueBox = false;
            textBox_value.WordWrap = true;
            textBox_value.TextChanged += textBox_value_TextChanged;
            // 
            // textBox_gfx
            // 
            textBox_gfx.BorderColor = System.Drawing.Color.Black;
            textBox_gfx.DisplayBorder = false;
            textBox_gfx.Location = new System.Drawing.Point(252, 14);
            textBox_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_gfx.MaxLength = 32767;
            textBox_gfx.Multiline = false;
            textBox_gfx.Name = "textBox_gfx";
            textBox_gfx.OnTextChanged = null;
            textBox_gfx.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_gfx.PlaceholderText = "";
            textBox_gfx.ReadOnly = true;
            textBox_gfx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_gfx.SelectionStart = 0;
            textBox_gfx.Size = new System.Drawing.Size(64, 23);
            textBox_gfx.TabIndex = 0;
            textBox_gfx.TabStop = false;
            textBox_gfx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_gfx.ValueBox = false;
            textBox_gfx.WordWrap = true;
            // 
            // textBox_palette
            // 
            textBox_palette.BorderColor = System.Drawing.Color.Black;
            textBox_palette.DisplayBorder = false;
            textBox_palette.Location = new System.Drawing.Point(252, 85);
            textBox_palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_palette.MaxLength = 32767;
            textBox_palette.Multiline = false;
            textBox_palette.Name = "textBox_palette";
            textBox_palette.OnTextChanged = null;
            textBox_palette.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_palette.PlaceholderText = "";
            textBox_palette.ReadOnly = true;
            textBox_palette.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_palette.SelectionStart = 0;
            textBox_palette.Size = new System.Drawing.Size(64, 23);
            textBox_palette.TabIndex = 0;
            textBox_palette.TabStop = false;
            textBox_palette.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_palette.ValueBox = false;
            textBox_palette.WordWrap = true;
            // 
            // textBox_valOffset
            // 
            textBox_valOffset.BorderColor = System.Drawing.Color.Black;
            textBox_valOffset.DisplayBorder = false;
            textBox_valOffset.Location = new System.Drawing.Point(252, 157);
            textBox_valOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_valOffset.MaxLength = 32767;
            textBox_valOffset.Multiline = false;
            textBox_valOffset.Name = "textBox_valOffset";
            textBox_valOffset.OnTextChanged = null;
            textBox_valOffset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_valOffset.PlaceholderText = "";
            textBox_valOffset.ReadOnly = true;
            textBox_valOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_valOffset.SelectionStart = 0;
            textBox_valOffset.Size = new System.Drawing.Size(64, 23);
            textBox_valOffset.TabIndex = 0;
            textBox_valOffset.TabStop = false;
            textBox_valOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_valOffset.ValueBox = false;
            textBox_valOffset.WordWrap = true;
            // 
            // label_value
            // 
            label_value.AutoSize = true;
            label_value.Location = new System.Drawing.Point(250, 190);
            label_value.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_value.Name = "label_value";
            label_value.Size = new System.Drawing.Size(38, 15);
            label_value.TabIndex = 0;
            label_value.Text = "Value:";
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_changes });
            statusStrip.Location = new System.Drawing.Point(0, 330);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(351, 22);
            statusStrip.TabIndex = 5;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 17);
            statusLabel_changes.Text = "-";
            // 
            // FormWeapon
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(351, 352);
            Controls.Add(statusStrip);
            Controls.Add(label_value);
            Controls.Add(textBox_valOffset);
            Controls.Add(textBox_palette);
            Controls.Add(textBox_gfx);
            Controls.Add(textBox_value);
            Controls.Add(button_close);
            Controls.Add(button_apply);
            Controls.Add(button_palette);
            Controls.Add(button_gfx);
            Controls.Add(treeView);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormWeapon";
            Text = "Weapon Editor";
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView;
        private System.Windows.Forms.Button button_gfx;
        private System.Windows.Forms.Button button_palette;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_close;
        private mage.Theming.CustomControls.FlatTextBox textBox_value;
        private mage.Theming.CustomControls.FlatTextBox textBox_gfx;
        private mage.Theming.CustomControls.FlatTextBox textBox_palette;
        private mage.Theming.CustomControls.FlatTextBox textBox_valOffset;
        private System.Windows.Forms.Label label_value;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
    }
}