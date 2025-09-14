namespace mage.Options.Pages
{
    partial class PageUpdates
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
            checkBox_auto_update = new System.Windows.Forms.CheckBox();
            checkBox_notifyMajor = new System.Windows.Forms.CheckBox();
            seperator1 = new mage.Controls.Seperator();
            button_checkNow = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // checkBox_auto_update
            // 
            checkBox_auto_update.AutoSize = true;
            checkBox_auto_update.Location = new System.Drawing.Point(6, 6);
            checkBox_auto_update.Name = "checkBox_auto_update";
            checkBox_auto_update.Size = new System.Drawing.Size(179, 19);
            checkBox_auto_update.TabIndex = 11;
            checkBox_auto_update.Text = "Check for updates on startup";
            checkBox_auto_update.UseVisualStyleBackColor = true;
            checkBox_auto_update.CheckedChanged += checkBox_auto_update_CheckedChanged;
            // 
            // checkBox_notifyMajor
            // 
            checkBox_notifyMajor.AutoSize = true;
            checkBox_notifyMajor.Location = new System.Drawing.Point(6, 31);
            checkBox_notifyMajor.Name = "checkBox_notifyMajor";
            checkBox_notifyMajor.Size = new System.Drawing.Size(182, 19);
            checkBox_notifyMajor.TabIndex = 12;
            checkBox_notifyMajor.Text = "Only check for major updates";
            checkBox_notifyMajor.UseVisualStyleBackColor = true;
            checkBox_notifyMajor.CheckedChanged += checkBox_notifyMajor_CheckedChanged;
            // 
            // seperator1
            // 
            seperator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            seperator1.Location = new System.Drawing.Point(6, 56);
            seperator1.Name = "seperator1";
            seperator1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            seperator1.Size = new System.Drawing.Size(346, 1);
            seperator1.TabIndex = 13;
            seperator1.Text = "seperator1";
            // 
            // button_checkNow
            // 
            button_checkNow.Location = new System.Drawing.Point(6, 63);
            button_checkNow.Name = "button_checkNow";
            button_checkNow.Size = new System.Drawing.Size(156, 23);
            button_checkNow.TabIndex = 14;
            button_checkNow.Text = "Check for Updates now";
            button_checkNow.UseVisualStyleBackColor = true;
            button_checkNow.Click += button_checkNow_Click;
            // 
            // PageUpdates
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(button_checkNow);
            Controls.Add(seperator1);
            Controls.Add(checkBox_notifyMajor);
            Controls.Add(checkBox_auto_update);
            Name = "PageUpdates";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(358, 196);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.CheckBox checkBox_auto_update;
        private System.Windows.Forms.CheckBox checkBox_notifyMajor;
        private Controls.Seperator seperator1;
        private System.Windows.Forms.Button button_checkNow;
    }
}
