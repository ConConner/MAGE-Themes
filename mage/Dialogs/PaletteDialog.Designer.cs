namespace mage.Dialogs
{
    partial class PaletteDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteDialog));
            button_ok = new System.Windows.Forms.Button();
            button_cancel = new System.Windows.Forms.Button();
            label_palette = new System.Windows.Forms.Label();
            comboBox_palette = new Theming.CustomControls.FlatComboBox();
            paletteView = new Controls.TileDisplay();
            SuspendLayout();
            // 
            // button_ok
            // 
            button_ok.Enabled = false;
            button_ok.Location = new System.Drawing.Point(129, 12);
            button_ok.Name = "button_ok";
            button_ok.Size = new System.Drawing.Size(75, 23);
            button_ok.TabIndex = 0;
            button_ok.Text = "OK";
            button_ok.UseVisualStyleBackColor = true;
            button_ok.Click += button_ok_Click;
            // 
            // button_cancel
            // 
            button_cancel.Location = new System.Drawing.Point(210, 12);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new System.Drawing.Size(75, 23);
            button_cancel.TabIndex = 1;
            button_cancel.Text = "Cancel";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            // 
            // label_palette
            // 
            label_palette.AutoSize = true;
            label_palette.Location = new System.Drawing.Point(12, 16);
            label_palette.Name = "label_palette";
            label_palette.Size = new System.Drawing.Size(33, 15);
            label_palette.TabIndex = 2;
            label_palette.Text = "Row:";
            // 
            // comboBox_palette
            // 
            comboBox_palette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_palette.FormattingEnabled = true;
            comboBox_palette.Location = new System.Drawing.Point(51, 13);
            comboBox_palette.Name = "comboBox_palette";
            comboBox_palette.Size = new System.Drawing.Size(46, 23);
            comboBox_palette.TabIndex = 3;
            comboBox_palette.SelectedIndexChanged += comboBox_palette_SelectedIndexChanged;
            // 
            // paletteView
            // 
            paletteView.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            paletteView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            paletteView.Location = new System.Drawing.Point(12, 42);
            paletteView.Name = "paletteView";
            paletteView.ShowGrid = false;
            paletteView.Size = new System.Drawing.Size(273, 273);
            paletteView.TabIndex = 4;
            paletteView.TabStop = false;
            paletteView.Text = "tileDisplay1";
            paletteView.TileImage = null;
            paletteView.TileSize = 17;
            paletteView.Zoom = 0;
            paletteView.TileMouseUp += paletteView_TileMouseUp;
            paletteView.TileMouseMove += paletteView_TileMouseMove;
            // 
            // PaletteDialog
            // 
            AcceptButton = button_ok;
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            CancelButton = button_cancel;
            ClientSize = new System.Drawing.Size(297, 327);
            Controls.Add(paletteView);
            Controls.Add(comboBox_palette);
            Controls.Add(label_palette);
            Controls.Add(button_cancel);
            Controls.Add(button_ok);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaletteDialog";
            ShowIcon = false;
            SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            Text = "Select Palette";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label_palette;
        private Theming.CustomControls.FlatComboBox comboBox_palette;
        private Controls.TileDisplay paletteView;
    }
}