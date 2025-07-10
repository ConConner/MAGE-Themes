namespace mage
{
    partial class FormTileset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTileset));
            textBox_offsetVal = new Theming.CustomControls.FlatTextBox();
            label_offset = new System.Windows.Forms.Label();
            button_close = new System.Windows.Forms.Button();
            button_apply = new System.Windows.Forms.Button();
            textBox_rleGfx = new Theming.CustomControls.FlatTextBox();
            textBox_palette = new Theming.CustomControls.FlatTextBox();
            textBox_lz77gfx = new Theming.CustomControls.FlatTextBox();
            textBox_tileTable = new Theming.CustomControls.FlatTextBox();
            label_rleGfx = new System.Windows.Forms.Label();
            label_palette = new System.Windows.Forms.Label();
            label_lz77gfx = new System.Windows.Forms.Label();
            label_tileTable = new System.Windows.Forms.Label();
            textBox_animTileset = new Theming.CustomControls.FlatTextBox();
            textBox_animPalette = new Theming.CustomControls.FlatTextBox();
            label_animTileset = new System.Windows.Forms.Label();
            label_animPalette = new System.Windows.Forms.Label();
            label_tileset = new System.Windows.Forms.Label();
            comboBox_tileset = new Theming.CustomControls.FlatComboBox();
            groupBox_data = new System.Windows.Forms.GroupBox();
            button_editTileTable = new System.Windows.Forms.Button();
            button_editAnimTileset = new System.Windows.Forms.Button();
            button_editLZ77 = new System.Windows.Forms.Button();
            button_editRLE = new System.Windows.Forms.Button();
            button_editPalette = new System.Windows.Forms.Button();
            button_editAnimPalette = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            groupBox_data.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_offsetVal
            // 
            textBox_offsetVal.BorderColor = System.Drawing.Color.Black;
            textBox_offsetVal.DisplayBorder = false;
            textBox_offsetVal.Location = new System.Drawing.Point(65, 262);
            textBox_offsetVal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_offsetVal.MaxLength = 32767;
            textBox_offsetVal.Multiline = false;
            textBox_offsetVal.Name = "textBox_offsetVal";
            textBox_offsetVal.OnTextChanged = null;
            textBox_offsetVal.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_offsetVal.PlaceholderText = "";
            textBox_offsetVal.ReadOnly = true;
            textBox_offsetVal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_offsetVal.SelectionStart = 0;
            textBox_offsetVal.Size = new System.Drawing.Size(64, 23);
            textBox_offsetVal.TabIndex = 0;
            textBox_offsetVal.TabStop = false;
            textBox_offsetVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_offsetVal.ValueBox = false;
            textBox_offsetVal.WordWrap = true;
            // 
            // label_offset
            // 
            label_offset.AutoSize = true;
            label_offset.Location = new System.Drawing.Point(12, 262);
            label_offset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_offset.Name = "label_offset";
            label_offset.Size = new System.Drawing.Size(42, 15);
            label_offset.TabIndex = 0;
            label_offset.Text = "Offset:";
            // 
            // button_close
            // 
            button_close.Location = new System.Drawing.Point(174, 257);
            button_close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_close.Name = "button_close";
            button_close.Size = new System.Drawing.Size(88, 27);
            button_close.TabIndex = 3;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Location = new System.Drawing.Point(174, 224);
            button_apply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(88, 27);
            button_apply.TabIndex = 2;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // textBox_rleGfx
            // 
            textBox_rleGfx.BorderColor = System.Drawing.Color.Black;
            textBox_rleGfx.DisplayBorder = true;
            textBox_rleGfx.Location = new System.Drawing.Point(82, 22);
            textBox_rleGfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_rleGfx.MaxLength = 32767;
            textBox_rleGfx.Multiline = false;
            textBox_rleGfx.Name = "textBox_rleGfx";
            textBox_rleGfx.OnTextChanged = null;
            textBox_rleGfx.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_rleGfx.PlaceholderText = "";
            textBox_rleGfx.ReadOnly = false;
            textBox_rleGfx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_rleGfx.SelectionStart = 0;
            textBox_rleGfx.Size = new System.Drawing.Size(76, 23);
            textBox_rleGfx.TabIndex = 0;
            textBox_rleGfx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_rleGfx.ValueBox = true;
            textBox_rleGfx.WordWrap = true;
            textBox_rleGfx.TextChanged += textBox_TextChanged;
            // 
            // textBox_palette
            // 
            textBox_palette.BorderColor = System.Drawing.Color.Black;
            textBox_palette.DisplayBorder = true;
            textBox_palette.Location = new System.Drawing.Point(82, 52);
            textBox_palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_palette.MaxLength = 32767;
            textBox_palette.Multiline = false;
            textBox_palette.Name = "textBox_palette";
            textBox_palette.OnTextChanged = null;
            textBox_palette.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_palette.PlaceholderText = "";
            textBox_palette.ReadOnly = false;
            textBox_palette.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_palette.SelectionStart = 0;
            textBox_palette.Size = new System.Drawing.Size(76, 23);
            textBox_palette.TabIndex = 2;
            textBox_palette.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_palette.ValueBox = true;
            textBox_palette.WordWrap = true;
            textBox_palette.TextChanged += textBox_TextChanged;
            // 
            // textBox_lz77gfx
            // 
            textBox_lz77gfx.BorderColor = System.Drawing.Color.Black;
            textBox_lz77gfx.DisplayBorder = true;
            textBox_lz77gfx.Location = new System.Drawing.Point(82, 82);
            textBox_lz77gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_lz77gfx.MaxLength = 32767;
            textBox_lz77gfx.Multiline = false;
            textBox_lz77gfx.Name = "textBox_lz77gfx";
            textBox_lz77gfx.OnTextChanged = null;
            textBox_lz77gfx.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_lz77gfx.PlaceholderText = "";
            textBox_lz77gfx.ReadOnly = false;
            textBox_lz77gfx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_lz77gfx.SelectionStart = 0;
            textBox_lz77gfx.Size = new System.Drawing.Size(76, 23);
            textBox_lz77gfx.TabIndex = 4;
            textBox_lz77gfx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_lz77gfx.ValueBox = true;
            textBox_lz77gfx.WordWrap = true;
            textBox_lz77gfx.TextChanged += textBox_TextChanged;
            // 
            // textBox_tileTable
            // 
            textBox_tileTable.BorderColor = System.Drawing.Color.Black;
            textBox_tileTable.DisplayBorder = true;
            textBox_tileTable.Location = new System.Drawing.Point(82, 112);
            textBox_tileTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_tileTable.MaxLength = 32767;
            textBox_tileTable.Multiline = false;
            textBox_tileTable.Name = "textBox_tileTable";
            textBox_tileTable.OnTextChanged = null;
            textBox_tileTable.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_tileTable.PlaceholderText = "";
            textBox_tileTable.ReadOnly = false;
            textBox_tileTable.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_tileTable.SelectionStart = 0;
            textBox_tileTable.Size = new System.Drawing.Size(76, 23);
            textBox_tileTable.TabIndex = 6;
            textBox_tileTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_tileTable.ValueBox = true;
            textBox_tileTable.WordWrap = true;
            textBox_tileTable.TextChanged += textBox_TextChanged;
            // 
            // label_rleGfx
            // 
            label_rleGfx.AutoSize = true;
            label_rleGfx.Location = new System.Drawing.Point(7, 25);
            label_rleGfx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_rleGfx.Name = "label_rleGfx";
            label_rleGfx.Size = new System.Drawing.Size(53, 15);
            label_rleGfx.TabIndex = 0;
            label_rleGfx.Text = "RLE GFX:";
            // 
            // label_palette
            // 
            label_palette.AutoSize = true;
            label_palette.Location = new System.Drawing.Point(7, 55);
            label_palette.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_palette.Name = "label_palette";
            label_palette.Size = new System.Drawing.Size(46, 15);
            label_palette.TabIndex = 0;
            label_palette.Text = "Palette:";
            // 
            // label_lz77gfx
            // 
            label_lz77gfx.AutoSize = true;
            label_lz77gfx.Location = new System.Drawing.Point(6, 85);
            label_lz77gfx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_lz77gfx.Name = "label_lz77gfx";
            label_lz77gfx.Size = new System.Drawing.Size(59, 15);
            label_lz77gfx.TabIndex = 0;
            label_lz77gfx.Text = "LZ77 GFX:";
            // 
            // label_tileTable
            // 
            label_tileTable.AutoSize = true;
            label_tileTable.Location = new System.Drawing.Point(7, 115);
            label_tileTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileTable.Name = "label_tileTable";
            label_tileTable.Size = new System.Drawing.Size(57, 15);
            label_tileTable.TabIndex = 0;
            label_tileTable.Text = "Tile table:";
            // 
            // textBox_animTileset
            // 
            textBox_animTileset.BorderColor = System.Drawing.Color.Black;
            textBox_animTileset.DisplayBorder = true;
            textBox_animTileset.Location = new System.Drawing.Point(122, 142);
            textBox_animTileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_animTileset.MaxLength = 32767;
            textBox_animTileset.Multiline = false;
            textBox_animTileset.Name = "textBox_animTileset";
            textBox_animTileset.OnTextChanged = null;
            textBox_animTileset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_animTileset.PlaceholderText = "";
            textBox_animTileset.ReadOnly = false;
            textBox_animTileset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_animTileset.SelectionStart = 0;
            textBox_animTileset.Size = new System.Drawing.Size(35, 23);
            textBox_animTileset.TabIndex = 7;
            textBox_animTileset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_animTileset.ValueBox = false;
            textBox_animTileset.WordWrap = true;
            textBox_animTileset.TextChanged += textBox_TextChanged;
            // 
            // textBox_animPalette
            // 
            textBox_animPalette.BorderColor = System.Drawing.Color.Black;
            textBox_animPalette.DisplayBorder = true;
            textBox_animPalette.Location = new System.Drawing.Point(122, 172);
            textBox_animPalette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_animPalette.MaxLength = 32767;
            textBox_animPalette.Multiline = false;
            textBox_animPalette.Name = "textBox_animPalette";
            textBox_animPalette.OnTextChanged = null;
            textBox_animPalette.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_animPalette.PlaceholderText = "";
            textBox_animPalette.ReadOnly = false;
            textBox_animPalette.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_animPalette.SelectionStart = 0;
            textBox_animPalette.Size = new System.Drawing.Size(35, 23);
            textBox_animPalette.TabIndex = 8;
            textBox_animPalette.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_animPalette.ValueBox = false;
            textBox_animPalette.WordWrap = true;
            textBox_animPalette.TextChanged += textBox_TextChanged;
            // 
            // label_animTileset
            // 
            label_animTileset.AutoSize = true;
            label_animTileset.Location = new System.Drawing.Point(7, 145);
            label_animTileset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_animTileset.Name = "label_animTileset";
            label_animTileset.Size = new System.Drawing.Size(96, 15);
            label_animTileset.TabIndex = 0;
            label_animTileset.Text = "Animated tileset:";
            // 
            // label_animPalette
            // 
            label_animPalette.AutoSize = true;
            label_animPalette.Location = new System.Drawing.Point(7, 175);
            label_animPalette.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_animPalette.Name = "label_animPalette";
            label_animPalette.Size = new System.Drawing.Size(101, 15);
            label_animPalette.TabIndex = 0;
            label_animPalette.Text = "Animated palette:";
            // 
            // label_tileset
            // 
            label_tileset.AutoSize = true;
            label_tileset.Location = new System.Drawing.Point(10, 228);
            label_tileset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileset.Name = "label_tileset";
            label_tileset.Size = new System.Drawing.Size(43, 15);
            label_tileset.TabIndex = 0;
            label_tileset.Text = "Tileset:";
            // 
            // comboBox_tileset
            // 
            comboBox_tileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_tileset.FormattingEnabled = true;
            comboBox_tileset.Location = new System.Drawing.Point(65, 225);
            comboBox_tileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_tileset.Name = "comboBox_tileset";
            comboBox_tileset.Size = new System.Drawing.Size(56, 23);
            comboBox_tileset.TabIndex = 1;
            comboBox_tileset.SelectedIndexChanged += comboBox_tileset_SelectedIndexChanged;
            // 
            // groupBox_data
            // 
            groupBox_data.Controls.Add(button_editTileTable);
            groupBox_data.Controls.Add(button_editAnimTileset);
            groupBox_data.Controls.Add(button_editLZ77);
            groupBox_data.Controls.Add(button_editRLE);
            groupBox_data.Controls.Add(button_editPalette);
            groupBox_data.Controls.Add(button_editAnimPalette);
            groupBox_data.Controls.Add(label_rleGfx);
            groupBox_data.Controls.Add(textBox_rleGfx);
            groupBox_data.Controls.Add(textBox_palette);
            groupBox_data.Controls.Add(label_animPalette);
            groupBox_data.Controls.Add(textBox_lz77gfx);
            groupBox_data.Controls.Add(label_animTileset);
            groupBox_data.Controls.Add(textBox_tileTable);
            groupBox_data.Controls.Add(textBox_animPalette);
            groupBox_data.Controls.Add(label_palette);
            groupBox_data.Controls.Add(textBox_animTileset);
            groupBox_data.Controls.Add(label_lz77gfx);
            groupBox_data.Controls.Add(label_tileTable);
            groupBox_data.Location = new System.Drawing.Point(14, 13);
            groupBox_data.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_data.Name = "groupBox_data";
            groupBox_data.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_data.Size = new System.Drawing.Size(247, 204);
            groupBox_data.TabIndex = 0;
            groupBox_data.TabStop = false;
            groupBox_data.Text = "Data";
            // 
            // button_editTileTable
            // 
            button_editTileTable.Location = new System.Drawing.Point(164, 111);
            button_editTileTable.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_editTileTable.Name = "button_editTileTable";
            button_editTileTable.Size = new System.Drawing.Size(76, 25);
            button_editTileTable.TabIndex = 11;
            button_editTileTable.Text = "Edit";
            button_editTileTable.UseVisualStyleBackColor = true;
            button_editTileTable.Click += button_editTileTable_Click;
            // 
            // button_editAnimTileset
            // 
            button_editAnimTileset.Location = new System.Drawing.Point(164, 141);
            button_editAnimTileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_editAnimTileset.Name = "button_editAnimTileset";
            button_editAnimTileset.Size = new System.Drawing.Size(76, 25);
            button_editAnimTileset.TabIndex = 10;
            button_editAnimTileset.Text = "Edit";
            button_editAnimTileset.UseVisualStyleBackColor = true;
            button_editAnimTileset.Click += button_editAnimTileset_Click;
            // 
            // button_editLZ77
            // 
            button_editLZ77.Location = new System.Drawing.Point(164, 81);
            button_editLZ77.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_editLZ77.Name = "button_editLZ77";
            button_editLZ77.Size = new System.Drawing.Size(76, 25);
            button_editLZ77.TabIndex = 5;
            button_editLZ77.Text = "Edit";
            button_editLZ77.UseVisualStyleBackColor = true;
            button_editLZ77.Click += button_editLZ77_Click;
            // 
            // button_editRLE
            // 
            button_editRLE.Location = new System.Drawing.Point(164, 21);
            button_editRLE.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_editRLE.Name = "button_editRLE";
            button_editRLE.Size = new System.Drawing.Size(76, 25);
            button_editRLE.TabIndex = 1;
            button_editRLE.Text = "Edit";
            button_editRLE.UseVisualStyleBackColor = true;
            button_editRLE.Click += button_editRLE_Click;
            // 
            // button_editPalette
            // 
            button_editPalette.Location = new System.Drawing.Point(164, 51);
            button_editPalette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_editPalette.Name = "button_editPalette";
            button_editPalette.Size = new System.Drawing.Size(76, 25);
            button_editPalette.TabIndex = 3;
            button_editPalette.Text = "Edit";
            button_editPalette.UseVisualStyleBackColor = true;
            button_editPalette.Click += button_editPalette_Click;
            // 
            // button_editAnimPalette
            // 
            button_editAnimPalette.Location = new System.Drawing.Point(164, 171);
            button_editAnimPalette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_editAnimPalette.Name = "button_editAnimPalette";
            button_editAnimPalette.Size = new System.Drawing.Size(76, 25);
            button_editAnimPalette.TabIndex = 9;
            button_editAnimPalette.Text = "Edit";
            button_editAnimPalette.UseVisualStyleBackColor = true;
            button_editAnimPalette.Click += button_editAnimPalette_Click;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_changes });
            statusStrip.Location = new System.Drawing.Point(0, 291);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(275, 22);
            statusStrip.TabIndex = 4;
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 17);
            statusLabel_changes.Text = "-";
            // 
            // FormTileset
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(275, 313);
            Controls.Add(statusStrip);
            Controls.Add(groupBox_data);
            Controls.Add(comboBox_tileset);
            Controls.Add(label_tileset);
            Controls.Add(textBox_offsetVal);
            Controls.Add(label_offset);
            Controls.Add(button_close);
            Controls.Add(button_apply);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormTileset";
            Text = "Tileset Editor";
            groupBox_data.ResumeLayout(false);
            groupBox_data.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private mage.Theming.CustomControls.FlatTextBox textBox_offsetVal;
        private System.Windows.Forms.Label label_offset;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button button_apply;
        private mage.Theming.CustomControls.FlatTextBox textBox_rleGfx;
        private mage.Theming.CustomControls.FlatTextBox textBox_palette;
        private mage.Theming.CustomControls.FlatTextBox textBox_lz77gfx;
        private mage.Theming.CustomControls.FlatTextBox textBox_tileTable;
        private System.Windows.Forms.Label label_rleGfx;
        private System.Windows.Forms.Label label_palette;
        private System.Windows.Forms.Label label_lz77gfx;
        private System.Windows.Forms.Label label_tileTable;
        private mage.Theming.CustomControls.FlatTextBox textBox_animTileset;
        private mage.Theming.CustomControls.FlatTextBox textBox_animPalette;
        private System.Windows.Forms.Label label_animTileset;
        private System.Windows.Forms.Label label_animPalette;
        private System.Windows.Forms.Label label_tileset;
        private mage.Theming.CustomControls.FlatComboBox comboBox_tileset;
        private System.Windows.Forms.GroupBox groupBox_data;
        private System.Windows.Forms.Button button_editPalette;
        private System.Windows.Forms.Button button_editAnimPalette;
        private System.Windows.Forms.Button button_editLZ77;
        private System.Windows.Forms.Button button_editRLE;
        private System.Windows.Forms.Button button_editAnimTileset;
        private System.Windows.Forms.Button button_editTileTable;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
    }
}