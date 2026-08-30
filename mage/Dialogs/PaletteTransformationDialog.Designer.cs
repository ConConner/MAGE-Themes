namespace mage.Dialogs
{
    partial class PaletteTransformationDialog
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
            tabControl = new mage.Theming.CustomControls.FlatTabControl();
            tab_hue = new System.Windows.Forms.TabPage();
            button_resetLightness = new System.Windows.Forms.Button();
            button_resetChroma = new System.Windows.Forms.Button();
            button_resetHue = new System.Windows.Forms.Button();
            num_lightness = new mage.Theming.CustomControls.FlatNumericUpDown();
            num_chroma = new mage.Theming.CustomControls.FlatNumericUpDown();
            num_hue = new mage.Theming.CustomControls.FlatNumericUpDown();
            lbl_lightness = new System.Windows.Forms.Label();
            lbl_chroma = new System.Windows.Forms.Label();
            trackBar_lightness = new mage.Theming.CustomControls.FlatTrackBar();
            trackBar_chroma = new mage.Theming.CustomControls.FlatTrackBar();
            lbl_hue = new System.Windows.Forms.Label();
            trackBar_hue = new mage.Theming.CustomControls.FlatTrackBar();
            tab_gradient = new System.Windows.Forms.TabPage();
            radio_gradientVertical = new System.Windows.Forms.RadioButton();
            radio_gradientHorizontal = new System.Windows.Forms.RadioButton();
            button_apply = new System.Windows.Forms.Button();
            button_cancel = new System.Windows.Forms.Button();
            pnl_generic = new System.Windows.Forms.Panel();
            checkBox_preview = new System.Windows.Forms.CheckBox();
            tabControl.SuspendLayout();
            tab_hue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_lightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_chroma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_hue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_lightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_chroma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_hue).BeginInit();
            tab_gradient.SuspendLayout();
            pnl_generic.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.BorderColor = System.Drawing.Color.Empty;
            tabControl.Controls.Add(tab_hue);
            tabControl.Controls.Add(tab_gradient);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(403, 121);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_TabIndexChanged;
            // 
            // tab_hue
            // 
            tab_hue.Controls.Add(button_resetLightness);
            tab_hue.Controls.Add(button_resetChroma);
            tab_hue.Controls.Add(button_resetHue);
            tab_hue.Controls.Add(num_lightness);
            tab_hue.Controls.Add(num_chroma);
            tab_hue.Controls.Add(num_hue);
            tab_hue.Controls.Add(lbl_lightness);
            tab_hue.Controls.Add(lbl_chroma);
            tab_hue.Controls.Add(trackBar_lightness);
            tab_hue.Controls.Add(trackBar_chroma);
            tab_hue.Controls.Add(lbl_hue);
            tab_hue.Controls.Add(trackBar_hue);
            tab_hue.Location = new System.Drawing.Point(4, 25);
            tab_hue.Name = "tab_hue";
            tab_hue.Padding = new System.Windows.Forms.Padding(3);
            tab_hue.Size = new System.Drawing.Size(395, 92);
            tab_hue.TabIndex = 1;
            tab_hue.Text = "Color";
            tab_hue.UseVisualStyleBackColor = true;
            // 
            // button_resetLightness
            // 
            button_resetLightness.Enabled = false;
            button_resetLightness.Image = Properties.Resources.toolbar_undo;
            button_resetLightness.Location = new System.Drawing.Point(365, 61);
            button_resetLightness.Name = "button_resetLightness";
            button_resetLightness.Size = new System.Drawing.Size(23, 23);
            button_resetLightness.TabIndex = 11;
            button_resetLightness.UseVisualStyleBackColor = true;
            button_resetLightness.Click += button_resetLightness_Click;
            // 
            // button_resetChroma
            // 
            button_resetChroma.Enabled = false;
            button_resetChroma.Image = Properties.Resources.toolbar_undo;
            button_resetChroma.Location = new System.Drawing.Point(365, 32);
            button_resetChroma.Name = "button_resetChroma";
            button_resetChroma.Size = new System.Drawing.Size(23, 23);
            button_resetChroma.TabIndex = 10;
            button_resetChroma.UseVisualStyleBackColor = true;
            button_resetChroma.Click += button_resetChroma_Click;
            // 
            // button_resetHue
            // 
            button_resetHue.Enabled = false;
            button_resetHue.Image = Properties.Resources.toolbar_undo;
            button_resetHue.Location = new System.Drawing.Point(365, 3);
            button_resetHue.Name = "button_resetHue";
            button_resetHue.Size = new System.Drawing.Size(23, 23);
            button_resetHue.TabIndex = 9;
            button_resetHue.UseVisualStyleBackColor = true;
            button_resetHue.Click += button_resetHue_Click;
            // 
            // num_lightness
            // 
            num_lightness.Location = new System.Drawing.Point(313, 61);
            num_lightness.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            num_lightness.Name = "num_lightness";
            num_lightness.Size = new System.Drawing.Size(46, 23);
            num_lightness.TabIndex = 8;
            num_lightness.ValueChanged += num_hue_ValueChanged;
            // 
            // num_chroma
            // 
            num_chroma.Location = new System.Drawing.Point(313, 32);
            num_chroma.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            num_chroma.Name = "num_chroma";
            num_chroma.Size = new System.Drawing.Size(46, 23);
            num_chroma.TabIndex = 7;
            num_chroma.ValueChanged += num_hue_ValueChanged;
            // 
            // num_hue
            // 
            num_hue.Location = new System.Drawing.Point(313, 3);
            num_hue.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            num_hue.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            num_hue.Name = "num_hue";
            num_hue.Size = new System.Drawing.Size(46, 23);
            num_hue.TabIndex = 6;
            num_hue.ValueChanged += num_hue_ValueChanged;
            // 
            // lbl_lightness
            // 
            lbl_lightness.AutoSize = true;
            lbl_lightness.Location = new System.Drawing.Point(8, 63);
            lbl_lightness.Name = "lbl_lightness";
            lbl_lightness.Size = new System.Drawing.Size(60, 15);
            lbl_lightness.TabIndex = 5;
            lbl_lightness.Text = "Lightness:";
            // 
            // lbl_chroma
            // 
            lbl_chroma.AutoSize = true;
            lbl_chroma.Location = new System.Drawing.Point(8, 34);
            lbl_chroma.Name = "lbl_chroma";
            lbl_chroma.Size = new System.Drawing.Size(53, 15);
            lbl_chroma.TabIndex = 4;
            lbl_chroma.Text = "Chroma:";
            // 
            // trackBar_lightness
            // 
            trackBar_lightness.BorderColor = System.Drawing.Color.DimGray;
            trackBar_lightness.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_lightness.Location = new System.Drawing.Point(74, 59);
            trackBar_lightness.Maximum = 100;
            trackBar_lightness.Minimum = -100;
            trackBar_lightness.Name = "trackBar_lightness";
            trackBar_lightness.Size = new System.Drawing.Size(233, 23);
            trackBar_lightness.TabIndex = 3;
            trackBar_lightness.ThumbColor = System.Drawing.Color.White;
            trackBar_lightness.ThumbWidth = 10;
            trackBar_lightness.TrackColor = System.Drawing.Color.Gray;
            trackBar_lightness.TrackHeight = 4;
            trackBar_lightness.ValueChanged += trackBar_lightness_ValueChanged;
            // 
            // trackBar_chroma
            // 
            trackBar_chroma.BorderColor = System.Drawing.Color.DimGray;
            trackBar_chroma.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_chroma.Location = new System.Drawing.Point(74, 30);
            trackBar_chroma.Maximum = 100;
            trackBar_chroma.Minimum = -100;
            trackBar_chroma.Name = "trackBar_chroma";
            trackBar_chroma.Size = new System.Drawing.Size(233, 23);
            trackBar_chroma.TabIndex = 2;
            trackBar_chroma.ThumbColor = System.Drawing.Color.White;
            trackBar_chroma.ThumbWidth = 10;
            trackBar_chroma.TrackColor = System.Drawing.Color.Gray;
            trackBar_chroma.TrackHeight = 4;
            trackBar_chroma.ValueChanged += trackBar_lightness_ValueChanged;
            // 
            // lbl_hue
            // 
            lbl_hue.AutoSize = true;
            lbl_hue.Location = new System.Drawing.Point(8, 5);
            lbl_hue.Name = "lbl_hue";
            lbl_hue.Size = new System.Drawing.Size(32, 15);
            lbl_hue.TabIndex = 1;
            lbl_hue.Text = "Hue:";
            // 
            // trackBar_hue
            // 
            trackBar_hue.BorderColor = System.Drawing.Color.DimGray;
            trackBar_hue.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_hue.Location = new System.Drawing.Point(74, 1);
            trackBar_hue.Maximum = 180;
            trackBar_hue.Minimum = -180;
            trackBar_hue.Name = "trackBar_hue";
            trackBar_hue.Size = new System.Drawing.Size(233, 23);
            trackBar_hue.TabIndex = 0;
            trackBar_hue.ThumbColor = System.Drawing.Color.White;
            trackBar_hue.ThumbWidth = 10;
            trackBar_hue.TrackColor = System.Drawing.Color.Gray;
            trackBar_hue.TrackHeight = 4;
            trackBar_hue.ValueChanged += trackBar_lightness_ValueChanged;
            // 
            // tab_gradient
            // 
            tab_gradient.Controls.Add(radio_gradientVertical);
            tab_gradient.Controls.Add(radio_gradientHorizontal);
            tab_gradient.Location = new System.Drawing.Point(4, 25);
            tab_gradient.Name = "tab_gradient";
            tab_gradient.Padding = new System.Windows.Forms.Padding(3);
            tab_gradient.Size = new System.Drawing.Size(192, 71);
            tab_gradient.TabIndex = 0;
            tab_gradient.Text = "Gradient";
            tab_gradient.UseVisualStyleBackColor = true;
            // 
            // radio_gradientVertical
            // 
            radio_gradientVertical.AutoSize = true;
            radio_gradientVertical.Location = new System.Drawing.Point(8, 31);
            radio_gradientVertical.Name = "radio_gradientVertical";
            radio_gradientVertical.Size = new System.Drawing.Size(63, 19);
            radio_gradientVertical.TabIndex = 1;
            radio_gradientVertical.Text = "Vertical";
            radio_gradientVertical.UseVisualStyleBackColor = true;
            radio_gradientVertical.CheckedChanged += radio_gradientVertical_CheckedChanged;
            // 
            // radio_gradientHorizontal
            // 
            radio_gradientHorizontal.AutoSize = true;
            radio_gradientHorizontal.Checked = true;
            radio_gradientHorizontal.Location = new System.Drawing.Point(8, 6);
            radio_gradientHorizontal.Name = "radio_gradientHorizontal";
            radio_gradientHorizontal.Size = new System.Drawing.Size(80, 19);
            radio_gradientHorizontal.TabIndex = 0;
            radio_gradientHorizontal.TabStop = true;
            radio_gradientHorizontal.Text = "Horizontal";
            radio_gradientHorizontal.UseVisualStyleBackColor = true;
            radio_gradientHorizontal.CheckedChanged += radio_gradientVertical_CheckedChanged;
            // 
            // button_apply
            // 
            button_apply.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_apply.Location = new System.Drawing.Point(324, 6);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(75, 23);
            button_apply.TabIndex = 1;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // button_cancel
            // 
            button_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_cancel.Location = new System.Drawing.Point(243, 6);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new System.Drawing.Size(75, 23);
            button_cancel.TabIndex = 2;
            button_cancel.Text = "Cancel";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            // 
            // pnl_generic
            // 
            pnl_generic.Controls.Add(checkBox_preview);
            pnl_generic.Controls.Add(button_cancel);
            pnl_generic.Controls.Add(button_apply);
            pnl_generic.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnl_generic.Location = new System.Drawing.Point(0, 121);
            pnl_generic.Name = "pnl_generic";
            pnl_generic.Size = new System.Drawing.Size(403, 35);
            pnl_generic.TabIndex = 3;
            // 
            // checkBox_preview
            // 
            checkBox_preview.AutoSize = true;
            checkBox_preview.Checked = true;
            checkBox_preview.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_preview.Location = new System.Drawing.Point(12, 9);
            checkBox_preview.Name = "checkBox_preview";
            checkBox_preview.Size = new System.Drawing.Size(67, 19);
            checkBox_preview.TabIndex = 3;
            checkBox_preview.Text = "Preview";
            checkBox_preview.UseVisualStyleBackColor = true;
            checkBox_preview.CheckedChanged += checkBox_preview_CheckedChanged;
            // 
            // PaletteTransformationDialog
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(403, 156);
            Controls.Add(tabControl);
            Controls.Add(pnl_generic);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaletteTransformationDialog";
            Text = "Transform Selection";
            tabControl.ResumeLayout(false);
            tab_hue.ResumeLayout(false);
            tab_hue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_lightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_chroma).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_hue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_lightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_chroma).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_hue).EndInit();
            tab_gradient.ResumeLayout(false);
            tab_gradient.PerformLayout();
            pnl_generic.ResumeLayout(false);
            pnl_generic.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Theming.CustomControls.FlatTabControl tabControl;
        private System.Windows.Forms.TabPage tab_gradient;
        private System.Windows.Forms.TabPage tab_hue;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Panel pnl_generic;
        private System.Windows.Forms.CheckBox checkBox_preview;
        private System.Windows.Forms.RadioButton radio_gradientVertical;
        private System.Windows.Forms.RadioButton radio_gradientHorizontal;
        private mage.Theming.CustomControls.FlatTrackBar trackBar_hue;
        private System.Windows.Forms.Label lbl_lightness;
        private System.Windows.Forms.Label lbl_chroma;
        private mage.Theming.CustomControls.FlatTrackBar trackBar_lightness;
        private mage.Theming.CustomControls.FlatTrackBar trackBar_chroma;
        private System.Windows.Forms.Label lbl_hue;
        private Theming.CustomControls.FlatNumericUpDown num_lightness;
        private Theming.CustomControls.FlatNumericUpDown num_chroma;
        private Theming.CustomControls.FlatNumericUpDown num_hue;
        private System.Windows.Forms.Button button_resetHue;
        private System.Windows.Forms.Button button_resetLightness;
        private System.Windows.Forms.Button button_resetChroma;
    }
}