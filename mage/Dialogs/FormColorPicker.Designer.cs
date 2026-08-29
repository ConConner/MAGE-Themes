namespace mage.Editors.NewEditors
{
    partial class FormColorPicker
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            colorPicker = new mage.Controls.HsvColorPicker();
            label_red = new System.Windows.Forms.Label();
            label_green = new System.Windows.Forms.Label();
            label_blue = new System.Windows.Forms.Label();
            numericUpDown_red = new mage.Theming.CustomControls.FlatNumericUpDown();
            numericUpDown_green = new mage.Theming.CustomControls.FlatNumericUpDown();
            numericUpDown_blue = new mage.Theming.CustomControls.FlatNumericUpDown();
            colorBar_red = new mage.Controls.ColorBar();
            colorBar_green = new mage.Controls.ColorBar();
            colorBar_blue = new mage.Controls.ColorBar();
            label_hex_color = new System.Windows.Forms.Label();
            textBox_hex_color = new mage.Theming.CustomControls.FlatTextBox();
            panel_preview = new System.Windows.Forms.Panel();
            button_ok = new System.Windows.Forms.Button();
            button_cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_red).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_green).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_blue).BeginInit();
            SuspendLayout();
            //
            // colorPicker
            //
            colorPicker.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            colorPicker.BorderColor = System.Drawing.Color.Black;
            colorPicker.Location = new System.Drawing.Point(12, 12);
            colorPicker.MarkerColor = System.Drawing.Color.White;
            colorPicker.Name = "colorPicker";
            colorPicker.Size = new System.Drawing.Size(257, 178);
            colorPicker.TabIndex = 0;
            colorPicker.Text = "colorPicker";
            colorPicker.ColorChanged += colorPicker_ColorChanged;
            //
            // label_red
            //
            label_red.AutoSize = true;
            label_red.Location = new System.Drawing.Point(12, 202);
            label_red.Name = "label_red";
            label_red.Size = new System.Drawing.Size(30, 15);
            label_red.TabIndex = 1;
            label_red.Text = "Red:";
            //
            // label_green
            //
            label_green.AutoSize = true;
            label_green.Location = new System.Drawing.Point(12, 231);
            label_green.Name = "label_green";
            label_green.Size = new System.Drawing.Size(41, 15);
            label_green.TabIndex = 2;
            label_green.Text = "Green:";
            //
            // label_blue
            //
            label_blue.AutoSize = true;
            label_blue.Location = new System.Drawing.Point(12, 260);
            label_blue.Name = "label_blue";
            label_blue.Size = new System.Drawing.Size(33, 15);
            label_blue.TabIndex = 3;
            label_blue.Text = "Blue:";
            //
            // numericUpDown_red
            //
            numericUpDown_red.Hexadecimal = true;
            numericUpDown_red.Location = new System.Drawing.Point(70, 200);
            numericUpDown_red.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown_red.Name = "numericUpDown_red";
            numericUpDown_red.Size = new System.Drawing.Size(32, 23);
            numericUpDown_red.TabIndex = 4;
            numericUpDown_red.ValueChanged += numericUpDown_ValueChanged;
            //
            // numericUpDown_green
            //
            numericUpDown_green.Hexadecimal = true;
            numericUpDown_green.Location = new System.Drawing.Point(70, 229);
            numericUpDown_green.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown_green.Name = "numericUpDown_green";
            numericUpDown_green.Size = new System.Drawing.Size(32, 23);
            numericUpDown_green.TabIndex = 5;
            numericUpDown_green.ValueChanged += numericUpDown_ValueChanged;
            //
            // numericUpDown_blue
            //
            numericUpDown_blue.Hexadecimal = true;
            numericUpDown_blue.Location = new System.Drawing.Point(70, 258);
            numericUpDown_blue.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown_blue.Name = "numericUpDown_blue";
            numericUpDown_blue.Size = new System.Drawing.Size(32, 23);
            numericUpDown_blue.TabIndex = 6;
            numericUpDown_blue.ValueChanged += numericUpDown_ValueChanged;
            //
            // colorBar_red
            //
            colorBar_red.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            colorBar_red.BorderColor = System.Drawing.Color.Black;
            colorBar_red.Channel = mage.Controls.ColorChannel.Red;
            colorBar_red.Location = new System.Drawing.Point(110, 200);
            colorBar_red.MarkerColor = System.Drawing.Color.White;
            colorBar_red.Name = "colorBar_red";
            colorBar_red.Size = new System.Drawing.Size(159, 23);
            colorBar_red.TabIndex = 7;
            colorBar_red.Text = "colorBar_red";
            colorBar_red.ValueChanged += colorBars_ValueChanged;
            //
            // colorBar_green
            //
            colorBar_green.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            colorBar_green.BorderColor = System.Drawing.Color.Black;
            colorBar_green.Channel = mage.Controls.ColorChannel.Green;
            colorBar_green.Location = new System.Drawing.Point(110, 229);
            colorBar_green.MarkerColor = System.Drawing.Color.White;
            colorBar_green.Name = "colorBar_green";
            colorBar_green.Size = new System.Drawing.Size(159, 23);
            colorBar_green.TabIndex = 8;
            colorBar_green.Text = "colorBar_green";
            colorBar_green.ValueChanged += colorBars_ValueChanged;
            //
            // colorBar_blue
            //
            colorBar_blue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            colorBar_blue.BorderColor = System.Drawing.Color.Black;
            colorBar_blue.Channel = mage.Controls.ColorChannel.Blue;
            colorBar_blue.Location = new System.Drawing.Point(110, 258);
            colorBar_blue.MarkerColor = System.Drawing.Color.White;
            colorBar_blue.Name = "colorBar_blue";
            colorBar_blue.Size = new System.Drawing.Size(159, 23);
            colorBar_blue.TabIndex = 9;
            colorBar_blue.Text = "colorBar_blue";
            colorBar_blue.ValueChanged += colorBars_ValueChanged;
            //
            // label_hex_color
            //
            label_hex_color.AutoSize = true;
            label_hex_color.Location = new System.Drawing.Point(12, 293);
            label_hex_color.Name = "label_hex_color";
            label_hex_color.Size = new System.Drawing.Size(52, 15);
            label_hex_color.TabIndex = 10;
            label_hex_color.Text = "24b Hex:";
            //
            // textBox_hex_color
            //
            textBox_hex_color.BorderColor = System.Drawing.Color.Black;
            textBox_hex_color.DisplayBorder = true;
            textBox_hex_color.HexSanitized = false;
            textBox_hex_color.HexSanitizedMaxValue = -1;
            textBox_hex_color.Location = new System.Drawing.Point(70, 289);
            textBox_hex_color.MaxLength = 32767;
            textBox_hex_color.Multiline = false;
            textBox_hex_color.Name = "textBox_hex_color";
            textBox_hex_color.OnTextChanged = null;
            textBox_hex_color.Padding = new System.Windows.Forms.Padding(4, 3, 4, 2);
            textBox_hex_color.PlaceholderText = "";
            textBox_hex_color.ReadOnly = false;
            textBox_hex_color.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_hex_color.SelectionStart = 0;
            textBox_hex_color.Size = new System.Drawing.Size(130, 23);
            textBox_hex_color.TabIndex = 11;
            textBox_hex_color.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_hex_color.ValueBox = false;
            textBox_hex_color.WordWrap = true;
            //
            // panel_preview
            //
            panel_preview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel_preview.Location = new System.Drawing.Point(210, 289);
            panel_preview.Name = "panel_preview";
            panel_preview.Size = new System.Drawing.Size(59, 23);
            panel_preview.TabIndex = 12;
            //
            // button_ok
            //
            button_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            button_ok.Location = new System.Drawing.Point(113, 326);
            button_ok.Name = "button_ok";
            button_ok.Size = new System.Drawing.Size(75, 25);
            button_ok.TabIndex = 13;
            button_ok.Text = "OK";
            button_ok.UseVisualStyleBackColor = true;
            button_ok.Click += button_ok_Click;
            //
            // button_cancel
            //
            button_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            button_cancel.Location = new System.Drawing.Point(194, 326);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new System.Drawing.Size(75, 25);
            button_cancel.TabIndex = 14;
            button_cancel.Text = "Cancel";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            //
            // FormColorPicker
            //
            AcceptButton = button_ok;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            CancelButton = button_cancel;
            ClientSize = new System.Drawing.Size(281, 363);
            Controls.Add(colorPicker);
            Controls.Add(label_red);
            Controls.Add(label_green);
            Controls.Add(label_blue);
            Controls.Add(numericUpDown_red);
            Controls.Add(numericUpDown_green);
            Controls.Add(numericUpDown_blue);
            Controls.Add(colorBar_red);
            Controls.Add(colorBar_green);
            Controls.Add(colorBar_blue);
            Controls.Add(label_hex_color);
            Controls.Add(textBox_hex_color);
            Controls.Add(panel_preview);
            Controls.Add(button_ok);
            Controls.Add(button_cancel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormColorPicker";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Pick a Color";
            ((System.ComponentModel.ISupportInitialize)numericUpDown_red).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_green).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_blue).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private mage.Controls.HsvColorPicker colorPicker;
        private System.Windows.Forms.Label label_red;
        private System.Windows.Forms.Label label_green;
        private System.Windows.Forms.Label label_blue;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_red;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_green;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_blue;
        private mage.Controls.ColorBar colorBar_red;
        private mage.Controls.ColorBar colorBar_green;
        private mage.Controls.ColorBar colorBar_blue;
        private System.Windows.Forms.Label label_hex_color;
        private mage.Theming.CustomControls.FlatTextBox textBox_hex_color;
        private System.Windows.Forms.Panel panel_preview;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
    }
}
