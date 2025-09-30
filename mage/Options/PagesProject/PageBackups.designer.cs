namespace mage.Options.Pages
{
    partial class PageBackups
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
            checkBox_moveBackups = new System.Windows.Forms.CheckBox();
            label_backupFormat = new System.Windows.Forms.Label();
            textBox_backupFormat = new mage.Theming.CustomControls.FlatTextBox();
            SuspendLayout();
            // 
            // checkBox_moveBackups
            // 
            checkBox_moveBackups.AutoSize = true;
            checkBox_moveBackups.Location = new System.Drawing.Point(9, 9);
            checkBox_moveBackups.Name = "checkBox_moveBackups";
            checkBox_moveBackups.Size = new System.Drawing.Size(221, 19);
            checkBox_moveBackups.TabIndex = 0;
            checkBox_moveBackups.Text = "Save backups in a Backups/ directory";
            checkBox_moveBackups.UseVisualStyleBackColor = true;
            checkBox_moveBackups.CheckedChanged += checkBox_moveBackups_CheckedChanged;
            // 
            // label_backupFormat
            // 
            label_backupFormat.AutoSize = true;
            label_backupFormat.Location = new System.Drawing.Point(9, 34);
            label_backupFormat.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            label_backupFormat.Name = "label_backupFormat";
            label_backupFormat.Size = new System.Drawing.Size(123, 15);
            label_backupFormat.TabIndex = 1;
            label_backupFormat.Text = "Backup Name format:";
            // 
            // textBox_backupFormat
            // 
            textBox_backupFormat.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_backupFormat.BorderColor = System.Drawing.Color.Black;
            textBox_backupFormat.DisplayBorder = true;
            textBox_backupFormat.Location = new System.Drawing.Point(9, 52);
            textBox_backupFormat.MaxLength = 32767;
            textBox_backupFormat.Multiline = false;
            textBox_backupFormat.Name = "textBox_backupFormat";
            textBox_backupFormat.OnTextChanged = null;
            textBox_backupFormat.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_backupFormat.PlaceholderText = "";
            textBox_backupFormat.ReadOnly = false;
            textBox_backupFormat.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_backupFormat.SelectionStart = 0;
            textBox_backupFormat.Size = new System.Drawing.Size(417, 23);
            textBox_backupFormat.TabIndex = 2;
            textBox_backupFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_backupFormat.ValueBox = false;
            textBox_backupFormat.WordWrap = true;
            textBox_backupFormat.TextChanged += textBox_backupFormat_TextChanged;
            // 
            // PageBackups
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(textBox_backupFormat);
            Controls.Add(label_backupFormat);
            Controls.Add(checkBox_moveBackups);
            Name = "PageBackups";
            Padding = new System.Windows.Forms.Padding(6);
            Size = new System.Drawing.Size(435, 349);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_moveBackups;
        private System.Windows.Forms.Label label_backupFormat;
        private Theming.CustomControls.FlatTextBox textBox_backupFormat;
    }
}
