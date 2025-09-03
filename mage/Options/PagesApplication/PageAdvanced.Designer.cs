namespace mage.Options.Pages
{
    partial class PageAdvanced
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
            checkBox_experimental = new System.Windows.Forms.CheckBox();
            checkBox_legacyEditors = new System.Windows.Forms.CheckBox();
            SuspendLayout();
            // 
            // checkBox_experimental
            // 
            checkBox_experimental.AutoSize = true;
            checkBox_experimental.Location = new System.Drawing.Point(6, 6);
            checkBox_experimental.Name = "checkBox_experimental";
            checkBox_experimental.Size = new System.Drawing.Size(178, 19);
            checkBox_experimental.TabIndex = 11;
            checkBox_experimental.Text = "Enable experimental features";
            checkBox_experimental.UseVisualStyleBackColor = true;
            checkBox_experimental.CheckedChanged += checkBox_experimental_CheckedChanged;
            // 
            // checkBox_legacyEditors
            // 
            checkBox_legacyEditors.AutoSize = true;
            checkBox_legacyEditors.Location = new System.Drawing.Point(6, 31);
            checkBox_legacyEditors.Name = "checkBox_legacyEditors";
            checkBox_legacyEditors.Size = new System.Drawing.Size(187, 19);
            checkBox_legacyEditors.TabIndex = 12;
            checkBox_legacyEditors.Text = "Use Legacy Editors if they exist";
            checkBox_legacyEditors.UseVisualStyleBackColor = true;
            checkBox_legacyEditors.CheckedChanged += checkBox_legacyEditors_CheckedChanged;
            // 
            // PageAdvanced
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(checkBox_legacyEditors);
            Controls.Add(checkBox_experimental);
            Name = "PageAdvanced";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(358, 196);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox_experimental;
        private System.Windows.Forms.CheckBox checkBox_legacyEditors;
    }
}
