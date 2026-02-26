namespace mage.Tweaks.ParameterControls
{
    partial class TweakParameterToggle
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
            chb_value = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // chb_value
            // 
            chb_value.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chb_value.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            chb_value.Location = new System.Drawing.Point(3, 3);
            chb_value.Name = "chb_value";
            chb_value.Size = new System.Drawing.Size(217, 24);
            chb_value.TabIndex = 0;
            chb_value.Text = "Display Name";
            chb_value.UseVisualStyleBackColor = true;
            chb_value.CheckedChanged += chb_value_CheckedChanged;
            // 
            // TweakParameterToggle
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            Controls.Add(chb_value);
            Name = "TweakParameterToggle";
            Size = new System.Drawing.Size(223, 30);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.CheckBox chb_value;
    }
}
