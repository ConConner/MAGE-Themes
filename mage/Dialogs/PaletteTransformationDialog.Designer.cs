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
            tab_gradient = new System.Windows.Forms.TabPage();
            radio_gradientVertical = new System.Windows.Forms.RadioButton();
            radio_gradientHorizontal = new System.Windows.Forms.RadioButton();
            tab_hue = new System.Windows.Forms.TabPage();
            button_apply = new System.Windows.Forms.Button();
            button_cancel = new System.Windows.Forms.Button();
            pnl_generic = new System.Windows.Forms.Panel();
            checkBox_preview = new System.Windows.Forms.CheckBox();
            tabControl.SuspendLayout();
            tab_gradient.SuspendLayout();
            pnl_generic.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.BorderColor = System.Drawing.Color.Empty;
            tabControl.Controls.Add(tab_gradient);
            tabControl.Controls.Add(tab_hue);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(357, 87);
            tabControl.TabIndex = 0;
            tabControl.TabIndexChanged += tabControl_TabIndexChanged;
            // 
            // tab_gradient
            // 
            tab_gradient.Controls.Add(radio_gradientVertical);
            tab_gradient.Controls.Add(radio_gradientHorizontal);
            tab_gradient.Location = new System.Drawing.Point(4, 25);
            tab_gradient.Name = "tab_gradient";
            tab_gradient.Padding = new System.Windows.Forms.Padding(3);
            tab_gradient.Size = new System.Drawing.Size(349, 58);
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
            // tab_hue
            // 
            tab_hue.Location = new System.Drawing.Point(4, 25);
            tab_hue.Name = "tab_hue";
            tab_hue.Padding = new System.Windows.Forms.Padding(3);
            tab_hue.Size = new System.Drawing.Size(192, 71);
            tab_hue.TabIndex = 1;
            tab_hue.Text = "Hue";
            tab_hue.UseVisualStyleBackColor = true;
            // 
            // button_apply
            // 
            button_apply.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_apply.Location = new System.Drawing.Point(278, 6);
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
            button_cancel.Location = new System.Drawing.Point(197, 6);
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
            pnl_generic.Location = new System.Drawing.Point(0, 87);
            pnl_generic.Name = "pnl_generic";
            pnl_generic.Size = new System.Drawing.Size(357, 35);
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
            ClientSize = new System.Drawing.Size(357, 122);
            Controls.Add(tabControl);
            Controls.Add(pnl_generic);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaletteTransformationDialog";
            Text = "Transform Selection";
            tabControl.ResumeLayout(false);
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
    }
}