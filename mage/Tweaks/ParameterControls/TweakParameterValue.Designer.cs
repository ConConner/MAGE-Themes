namespace mage.Tweaks.ParameterControls
{
    partial class TweakParameterValue
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
            txb_value = new mage.Theming.CustomControls.FlatTextBox();
            SuspendLayout();
            // 
            // lbl_name
            // 
            lbl_name.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lbl_name.AutoEllipsis = true;
            lbl_name.Location = new System.Drawing.Point(3, 3);
            lbl_name.Name = "lbl_name";
            lbl_name.Size = new System.Drawing.Size(111, 23);
            lbl_name.TabIndex = 0;
            lbl_name.Text = "Display Name";
            lbl_name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txb_value
            // 
            txb_value.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            txb_value.BorderColor = System.Drawing.Color.Black;
            txb_value.DisplayBorder = true;
            txb_value.Location = new System.Drawing.Point(120, 3);
            txb_value.MaxLength = 32767;
            txb_value.Multiline = false;
            txb_value.Name = "txb_value";
            txb_value.OnTextChanged = null;
            txb_value.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_value.PlaceholderText = "";
            txb_value.ReadOnly = false;
            txb_value.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_value.SelectionStart = 0;
            txb_value.Size = new System.Drawing.Size(100, 23);
            txb_value.TabIndex = 1;
            txb_value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_value.ValueBox = false;
            txb_value.WordWrap = true;
            txb_value.TextChanged += txb_value_TextChanged;
            // 
            // TweakParameterValue
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            Controls.Add(txb_value);
            Controls.Add(lbl_name);
            Name = "TweakParameterValue";
            Size = new System.Drawing.Size(223, 30);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lbl_name;
        private Theming.CustomControls.FlatTextBox txb_value;
    }
}
