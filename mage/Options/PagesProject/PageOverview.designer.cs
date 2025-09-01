namespace mage.Options.Pages
{
    partial class PageOverview
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
            label_created = new System.Windows.Forms.Label();
            label_lastModified = new System.Windows.Forms.Label();
            group_about = new System.Windows.Forms.GroupBox();
            label_createdValue = new System.Windows.Forms.Label();
            label_lastModifiedValue = new System.Windows.Forms.Label();
            group_rooms = new System.Windows.Forms.GroupBox();
            group_about.SuspendLayout();
            SuspendLayout();
            // 
            // label_created
            // 
            label_created.AutoSize = true;
            label_created.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_created.Location = new System.Drawing.Point(6, 28);
            label_created.Margin = new System.Windows.Forms.Padding(3);
            label_created.Name = "label_created";
            label_created.Size = new System.Drawing.Size(51, 15);
            label_created.TabIndex = 12;
            label_created.Text = "Created:";
            // 
            // label_lastModified
            // 
            label_lastModified.AutoSize = true;
            label_lastModified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_lastModified.Location = new System.Drawing.Point(6, 49);
            label_lastModified.Margin = new System.Windows.Forms.Padding(3);
            label_lastModified.Name = "label_lastModified";
            label_lastModified.Size = new System.Drawing.Size(82, 15);
            label_lastModified.TabIndex = 13;
            label_lastModified.Text = "Last modified:";
            // 
            // group_about
            // 
            group_about.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            group_about.Controls.Add(label_createdValue);
            group_about.Controls.Add(label_lastModifiedValue);
            group_about.Controls.Add(label_created);
            group_about.Controls.Add(label_lastModified);
            group_about.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            group_about.Location = new System.Drawing.Point(6, 12);
            group_about.Name = "group_about";
            group_about.Size = new System.Drawing.Size(423, 79);
            group_about.TabIndex = 14;
            group_about.TabStop = false;
            group_about.Text = "Project";
            // 
            // label_createdValue
            // 
            label_createdValue.AutoSize = true;
            label_createdValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_createdValue.Location = new System.Drawing.Point(94, 28);
            label_createdValue.Margin = new System.Windows.Forms.Padding(3);
            label_createdValue.Name = "label_createdValue";
            label_createdValue.Size = new System.Drawing.Size(0, 15);
            label_createdValue.TabIndex = 15;
            // 
            // label_lastModifiedValue
            // 
            label_lastModifiedValue.AutoSize = true;
            label_lastModifiedValue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_lastModifiedValue.Location = new System.Drawing.Point(94, 49);
            label_lastModifiedValue.Margin = new System.Windows.Forms.Padding(3);
            label_lastModifiedValue.Name = "label_lastModifiedValue";
            label_lastModifiedValue.Size = new System.Drawing.Size(0, 15);
            label_lastModifiedValue.TabIndex = 14;
            // 
            // group_rooms
            // 
            group_rooms.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            group_rooms.AutoSize = true;
            group_rooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            group_rooms.Location = new System.Drawing.Point(6, 97);
            group_rooms.Name = "group_rooms";
            group_rooms.Size = new System.Drawing.Size(423, 28);
            group_rooms.TabIndex = 15;
            group_rooms.TabStop = false;
            group_rooms.Text = "Rooms";
            // 
            // PageOverview
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(group_rooms);
            Controls.Add(group_about);
            Name = "PageOverview";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(435, 404);
            group_about.ResumeLayout(false);
            group_about.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label label_created;
        private System.Windows.Forms.Label label_lastModified;
        private System.Windows.Forms.GroupBox group_about;
        private System.Windows.Forms.GroupBox group_rooms;
        private System.Windows.Forms.Label label_createdValue;
        private System.Windows.Forms.Label label_lastModifiedValue;
    }
}
