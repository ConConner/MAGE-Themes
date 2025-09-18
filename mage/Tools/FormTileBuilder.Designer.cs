namespace mage
{
    partial class FormTileBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTileBuilder));
            checkBox_TL = new System.Windows.Forms.CheckBox();
            checkBox_TR = new System.Windows.Forms.CheckBox();
            checkBox_BL = new System.Windows.Forms.CheckBox();
            checkBox_BR = new System.Windows.Forms.CheckBox();
            comboBox_T = new mage.Theming.CustomControls.FlatComboBox();
            comboBox_L = new mage.Theming.CustomControls.FlatComboBox();
            comboBox_R = new mage.Theming.CustomControls.FlatComboBox();
            comboBox_B = new mage.Theming.CustomControls.FlatComboBox();
            comboBox_center = new mage.Theming.CustomControls.FlatComboBox();
            panel_black = new mage.Controls.ExtendedPanel();
            comboBox_palette = new mage.Theming.CustomControls.FlatComboBox();
            label_palette = new System.Windows.Forms.Label();
            button_apply = new System.Windows.Forms.Button();
            button_close = new System.Windows.Forms.Button();
            numericUpDown_tile = new mage.Theming.CustomControls.FlatNumericUpDown();
            label_tile = new System.Windows.Forms.Label();
            panel_black2 = new mage.Controls.ExtendedPanel();
            gfxView_curr = new GfxView();
            gfxView_tile = new GfxView();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tile).BeginInit();
            panel_black2.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox_TL
            // 
            checkBox_TL.AutoSize = true;
            checkBox_TL.Location = new System.Drawing.Point(61, 43);
            checkBox_TL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_TL.Name = "checkBox_TL";
            checkBox_TL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            checkBox_TL.Size = new System.Drawing.Size(62, 19);
            checkBox_TL.TabIndex = 0;
            checkBox_TL.Text = "Corner";
            checkBox_TL.UseVisualStyleBackColor = true;
            checkBox_TL.CheckedChanged += control_ValueChanged;
            // 
            // checkBox_TR
            // 
            checkBox_TR.AutoSize = true;
            checkBox_TR.Location = new System.Drawing.Point(231, 43);
            checkBox_TR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_TR.Name = "checkBox_TR";
            checkBox_TR.Size = new System.Drawing.Size(62, 19);
            checkBox_TR.TabIndex = 1;
            checkBox_TR.Text = "Corner";
            checkBox_TR.UseVisualStyleBackColor = true;
            checkBox_TR.CheckedChanged += control_ValueChanged;
            // 
            // checkBox_BL
            // 
            checkBox_BL.AutoSize = true;
            checkBox_BL.Location = new System.Drawing.Point(61, 162);
            checkBox_BL.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_BL.Name = "checkBox_BL";
            checkBox_BL.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            checkBox_BL.Size = new System.Drawing.Size(62, 19);
            checkBox_BL.TabIndex = 2;
            checkBox_BL.Text = "Corner";
            checkBox_BL.UseVisualStyleBackColor = true;
            checkBox_BL.CheckedChanged += control_ValueChanged;
            // 
            // checkBox_BR
            // 
            checkBox_BR.AutoSize = true;
            checkBox_BR.Location = new System.Drawing.Point(231, 162);
            checkBox_BR.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_BR.Name = "checkBox_BR";
            checkBox_BR.Size = new System.Drawing.Size(62, 19);
            checkBox_BR.TabIndex = 3;
            checkBox_BR.Text = "Corner";
            checkBox_BR.UseVisualStyleBackColor = true;
            checkBox_BR.CheckedChanged += control_ValueChanged;
            // 
            // comboBox_T
            // 
            comboBox_T.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_T.FormattingEnabled = true;
            comboBox_T.Location = new System.Drawing.Point(131, 14);
            comboBox_T.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_T.Name = "comboBox_T";
            comboBox_T.Size = new System.Drawing.Size(95, 23);
            comboBox_T.TabIndex = 5;
            comboBox_T.SelectedIndexChanged += control_ValueChanged;
            // 
            // comboBox_L
            // 
            comboBox_L.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_L.FormattingEnabled = true;
            comboBox_L.Location = new System.Drawing.Point(14, 97);
            comboBox_L.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_L.Name = "comboBox_L";
            comboBox_L.Size = new System.Drawing.Size(107, 23);
            comboBox_L.TabIndex = 6;
            comboBox_L.SelectedIndexChanged += control_ValueChanged;
            // 
            // comboBox_R
            // 
            comboBox_R.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_R.FormattingEnabled = true;
            comboBox_R.Location = new System.Drawing.Point(236, 97);
            comboBox_R.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_R.Name = "comboBox_R";
            comboBox_R.Size = new System.Drawing.Size(107, 23);
            comboBox_R.TabIndex = 7;
            comboBox_R.SelectedIndexChanged += control_ValueChanged;
            // 
            // comboBox_B
            // 
            comboBox_B.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_B.FormattingEnabled = true;
            comboBox_B.Location = new System.Drawing.Point(131, 186);
            comboBox_B.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_B.Name = "comboBox_B";
            comboBox_B.Size = new System.Drawing.Size(95, 23);
            comboBox_B.TabIndex = 8;
            comboBox_B.SelectedIndexChanged += control_ValueChanged;
            // 
            // comboBox_center
            // 
            comboBox_center.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_center.FormattingEnabled = true;
            comboBox_center.Location = new System.Drawing.Point(117, 224);
            comboBox_center.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_center.Name = "comboBox_center";
            comboBox_center.Size = new System.Drawing.Size(123, 23);
            comboBox_center.TabIndex = 9;
            comboBox_center.SelectedIndexChanged += control_ValueChanged;
            // 
            // panel_black
            // 
            panel_black.BackColor = System.Drawing.Color.Black;
            panel_black.Location = new System.Drawing.Point(131, 63);
            panel_black.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_black.Name = "panel_black";
            panel_black.Size = new System.Drawing.Size(96, 95);
            panel_black.TabIndex = 11;
            // 
            // comboBox_palette
            // 
            comboBox_palette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_palette.FormattingEnabled = true;
            comboBox_palette.Location = new System.Drawing.Point(289, 224);
            comboBox_palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_palette.Name = "comboBox_palette";
            comboBox_palette.Size = new System.Drawing.Size(52, 23);
            comboBox_palette.TabIndex = 12;
            comboBox_palette.SelectedIndexChanged += comboBox_palette_SelectedIndexChanged;
            // 
            // label_palette
            // 
            label_palette.AutoSize = true;
            label_palette.Location = new System.Drawing.Point(286, 205);
            label_palette.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_palette.Name = "label_palette";
            label_palette.Size = new System.Drawing.Size(46, 15);
            label_palette.TabIndex = 13;
            label_palette.Text = "Palette:";
            // 
            // button_apply
            // 
            button_apply.Location = new System.Drawing.Point(161, 258);
            button_apply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(88, 27);
            button_apply.TabIndex = 14;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // button_close
            // 
            button_close.Location = new System.Drawing.Point(255, 258);
            button_close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_close.Name = "button_close";
            button_close.Size = new System.Drawing.Size(88, 27);
            button_close.TabIndex = 15;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // numericUpDown_tile
            // 
            numericUpDown_tile.Hexadecimal = true;
            numericUpDown_tile.Location = new System.Drawing.Point(14, 224);
            numericUpDown_tile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_tile.Name = "numericUpDown_tile";
            numericUpDown_tile.Size = new System.Drawing.Size(52, 23);
            numericUpDown_tile.TabIndex = 16;
            numericUpDown_tile.ValueChanged += numericUpDown_tile_ValueChanged;
            // 
            // label_tile
            // 
            label_tile.AutoSize = true;
            label_tile.Location = new System.Drawing.Point(10, 205);
            label_tile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tile.Name = "label_tile";
            label_tile.Size = new System.Drawing.Size(28, 15);
            label_tile.TabIndex = 17;
            label_tile.Text = "Tile:";
            // 
            // panel_black2
            // 
            panel_black2.BackColor = System.Drawing.Color.Black;
            panel_black2.Controls.Add(gfxView_curr);
            panel_black2.Location = new System.Drawing.Point(14, 255);
            panel_black2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_black2.Name = "panel_black2";
            panel_black2.Size = new System.Drawing.Size(30, 30);
            panel_black2.TabIndex = 20;
            // 
            // gfxView_curr
            // 
            gfxView_curr.BackColor = System.Drawing.SystemColors.Control;
            gfxView_curr.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_curr.Location = new System.Drawing.Point(1, 1);
            gfxView_curr.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_curr.Name = "gfxView_curr";
            gfxView_curr.Size = new System.Drawing.Size(28, 28);
            gfxView_curr.TabIndex = 19;
            gfxView_curr.TabStop = false;
            // 
            // gfxView_tile
            // 
            gfxView_tile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_tile.Location = new System.Drawing.Point(132, 65);
            gfxView_tile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_tile.Name = "gfxView_tile";
            gfxView_tile.Size = new System.Drawing.Size(93, 92);
            gfxView_tile.TabIndex = 10;
            gfxView_tile.TabStop = false;
            // 
            // FormTileBuilder
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(357, 299);
            Controls.Add(label_tile);
            Controls.Add(numericUpDown_tile);
            Controls.Add(button_close);
            Controls.Add(button_apply);
            Controls.Add(label_palette);
            Controls.Add(comboBox_palette);
            Controls.Add(gfxView_tile);
            Controls.Add(comboBox_center);
            Controls.Add(comboBox_B);
            Controls.Add(comboBox_R);
            Controls.Add(comboBox_L);
            Controls.Add(comboBox_T);
            Controls.Add(checkBox_BR);
            Controls.Add(checkBox_BL);
            Controls.Add(checkBox_TR);
            Controls.Add(checkBox_TL);
            Controls.Add(panel_black);
            Controls.Add(panel_black2);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormTileBuilder";
            Text = "Map Tile Builder";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_tile).EndInit();
            panel_black2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_TL;
        private System.Windows.Forms.CheckBox checkBox_TR;
        private System.Windows.Forms.CheckBox checkBox_BL;
        private System.Windows.Forms.CheckBox checkBox_BR;
        private mage.Theming.CustomControls.FlatComboBox comboBox_T;
        private mage.Theming.CustomControls.FlatComboBox comboBox_L;
        private mage.Theming.CustomControls.FlatComboBox comboBox_R;
        private mage.Theming.CustomControls.FlatComboBox comboBox_B;
        private mage.Theming.CustomControls.FlatComboBox comboBox_center;
        private GfxView gfxView_tile;
        private mage.Theming.CustomControls.FlatComboBox comboBox_palette;
        private System.Windows.Forms.Label label_palette;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_close;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_tile;
        private System.Windows.Forms.Label label_tile;
        private GfxView gfxView_curr;
        private Controls.ExtendedPanel panel_black;
        private Controls.ExtendedPanel panel_black2;
    }
}