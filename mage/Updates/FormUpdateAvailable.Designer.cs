namespace mage.Updates
{
    partial class FormUpdateAvailable
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
            pictureBoxWithInterpolationMode1 = new Theming.CustomControls.PictureBoxWithInterpolationMode();
            label_mageVersion = new System.Windows.Forms.Label();
            button_dismiss = new System.Windows.Forms.Button();
            button_skip = new System.Windows.Forms.Button();
            button_download = new System.Windows.Forms.Button();
            textBox_description = new Theming.CustomControls.FlatTextBox();
            button_viewPage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxWithInterpolationMode1).BeginInit();
            SuspendLayout();
            // 
            // pictureBoxWithInterpolationMode1
            // 
            pictureBoxWithInterpolationMode1.Image = Properties.Resources.magePNG;
            pictureBoxWithInterpolationMode1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            pictureBoxWithInterpolationMode1.Location = new System.Drawing.Point(12, 12);
            pictureBoxWithInterpolationMode1.Name = "pictureBoxWithInterpolationMode1";
            pictureBoxWithInterpolationMode1.Size = new System.Drawing.Size(65, 65);
            pictureBoxWithInterpolationMode1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            pictureBoxWithInterpolationMode1.TabIndex = 0;
            pictureBoxWithInterpolationMode1.TabStop = false;
            // 
            // label_mageVersion
            // 
            label_mageVersion.AutoSize = true;
            label_mageVersion.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            label_mageVersion.Location = new System.Drawing.Point(83, 12);
            label_mageVersion.Name = "label_mageVersion";
            label_mageVersion.Size = new System.Drawing.Size(478, 65);
            label_mageVersion.TabIndex = 1;
            label_mageVersion.Text = "MAGE Themes 1.1.0";
            // 
            // button_dismiss
            // 
            button_dismiss.Location = new System.Drawing.Point(12, 218);
            button_dismiss.Name = "button_dismiss";
            button_dismiss.Size = new System.Drawing.Size(79, 23);
            button_dismiss.TabIndex = 3;
            button_dismiss.Text = "Dismiss";
            button_dismiss.UseVisualStyleBackColor = true;
            button_dismiss.Click += button_dismiss_Click;
            // 
            // button_skip
            // 
            button_skip.Location = new System.Drawing.Point(97, 218);
            button_skip.Name = "button_skip";
            button_skip.Size = new System.Drawing.Size(101, 23);
            button_skip.TabIndex = 4;
            button_skip.Text = "Skip this version";
            button_skip.UseVisualStyleBackColor = true;
            button_skip.Click += button_skip_Click;
            // 
            // button_download
            // 
            button_download.Location = new System.Drawing.Point(482, 218);
            button_download.Name = "button_download";
            button_download.Size = new System.Drawing.Size(79, 23);
            button_download.TabIndex = 5;
            button_download.Text = "Download";
            button_download.UseVisualStyleBackColor = true;
            button_download.Click += button_download_Click;
            // 
            // textBox_description
            // 
            textBox_description.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_description.BorderColor = System.Drawing.Color.Black;
            textBox_description.DisplayBorder = false;
            textBox_description.Location = new System.Drawing.Point(12, 92);
            textBox_description.MaxLength = 32767;
            textBox_description.Multiline = true;
            textBox_description.Name = "textBox_description";
            textBox_description.OnTextChanged = null;
            textBox_description.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_description.PlaceholderText = "";
            textBox_description.ReadOnly = false;
            textBox_description.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_description.SelectionStart = 0;
            textBox_description.Size = new System.Drawing.Size(549, 120);
            textBox_description.TabIndex = 6;
            textBox_description.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_description.ValueBox = false;
            textBox_description.WordWrap = true;
            // 
            // button_viewPage
            // 
            button_viewPage.Location = new System.Drawing.Point(367, 218);
            button_viewPage.Name = "button_viewPage";
            button_viewPage.Size = new System.Drawing.Size(109, 23);
            button_viewPage.TabIndex = 7;
            button_viewPage.Text = "View release page";
            button_viewPage.UseVisualStyleBackColor = true;
            button_viewPage.Click += button_viewPage_Click;
            // 
            // FormUpdateAvailable
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoSize = true;
            ClientSize = new System.Drawing.Size(573, 253);
            Controls.Add(button_viewPage);
            Controls.Add(textBox_description);
            Controls.Add(button_download);
            Controls.Add(button_skip);
            Controls.Add(button_dismiss);
            Controls.Add(label_mageVersion);
            Controls.Add(pictureBoxWithInterpolationMode1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormUpdateAvailable";
            ShowIcon = false;
            Text = "New Version Available";
            ((System.ComponentModel.ISupportInitialize)pictureBoxWithInterpolationMode1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Theming.CustomControls.PictureBoxWithInterpolationMode pictureBoxWithInterpolationMode1;
        private System.Windows.Forms.Label label_mageVersion;
        private System.Windows.Forms.Button button_dismiss;
        private System.Windows.Forms.Button button_skip;
        private System.Windows.Forms.Button button_download;
        private Theming.CustomControls.FlatTextBox textBox_description;
        private System.Windows.Forms.Button button_viewPage;
    }
}