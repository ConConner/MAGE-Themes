namespace mage.Tweaks.ParameterControls
{
    partial class TweakParameterSelection
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
            lbl_name = new System.Windows.Forms.Label();
            cbb_value = new mage.Theming.CustomControls.FlatComboBox();
            SuspendLayout();
            // 
            // lbl_name
            // 
            lbl_name.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbl_name.AutoEllipsis = true;
            lbl_name.Location = new System.Drawing.Point(3, 3);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new System.Drawing.Size(97, 23);
            lbl_name.TabIndex = 0;
            lbl_name.Text = "Display Name";
            lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbb_value
            // 
            cbb_value.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cbb_value.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbb_value.FormattingEnabled = true;
            cbb_value.Location = new System.Drawing.Point(106, 3);
            cbb_value.Name = "cbb_value";
            cbb_value.Size = new System.Drawing.Size(100, 23);
            cbb_value.TabIndex = 2;
            cbb_value.SelectedIndexChanged += cbb_value_SelectedIndexChanged;
            // 
            // TweakParameterSelection
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            Controls.Add(cbb_value);
            Controls.Add(lbl_name);
            Name = "TweakParameterSelection";
            Size = new System.Drawing.Size(209, 30);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private Theming.CustomControls.FlatComboBox cbb_value;
    }
}
