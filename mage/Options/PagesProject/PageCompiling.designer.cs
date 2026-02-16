namespace mage.Options.Pages
{
    partial class PageCompiling
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
            checkBox_enableCompilation = new System.Windows.Forms.CheckBox();
            group_compilationSettings = new System.Windows.Forms.GroupBox();
            chb_ignoreErrors = new System.Windows.Forms.CheckBox();
            label_scriptPath = new System.Windows.Forms.Label();
            button_selectScriptPath = new System.Windows.Forms.Button();
            textBox_scriptPath = new mage.Theming.CustomControls.FlatTextBox();
            group_compilationSettings.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox_enableCompilation
            // 
            checkBox_enableCompilation.AutoSize = true;
            checkBox_enableCompilation.Location = new System.Drawing.Point(6, 6);
            checkBox_enableCompilation.Name = "checkBox_enableCompilation";
            checkBox_enableCompilation.Size = new System.Drawing.Size(169, 19);
            checkBox_enableCompilation.TabIndex = 0;
            checkBox_enableCompilation.Text = "Enable Hybrid Compilation";
            checkBox_enableCompilation.UseVisualStyleBackColor = true;
            checkBox_enableCompilation.CheckedChanged += checkBox_enableCompilation_CheckedChanged;
            // 
            // group_compilationSettings
            // 
            group_compilationSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            group_compilationSettings.Controls.Add(chb_ignoreErrors);
            group_compilationSettings.Controls.Add(label_scriptPath);
            group_compilationSettings.Controls.Add(button_selectScriptPath);
            group_compilationSettings.Controls.Add(textBox_scriptPath);
            group_compilationSettings.Location = new System.Drawing.Point(6, 31);
            group_compilationSettings.Name = "group_compilationSettings";
            group_compilationSettings.Size = new System.Drawing.Size(423, 99);
            group_compilationSettings.TabIndex = 1;
            group_compilationSettings.TabStop = false;
            group_compilationSettings.Text = "Compilation settings";
            // 
            // chb_ignoreErrors
            // 
            chb_ignoreErrors.AutoSize = true;
            chb_ignoreErrors.Location = new System.Drawing.Point(6, 72);
            chb_ignoreErrors.Name = "chb_ignoreErrors";
            chb_ignoreErrors.Size = new System.Drawing.Size(339, 19);
            chb_ignoreErrors.TabIndex = 2;
            chb_ignoreErrors.Text = "Automatically ignore errors and continue with default ROM";
            chb_ignoreErrors.UseVisualStyleBackColor = true;
            chb_ignoreErrors.CheckedChanged += chb_ignoreErrors_CheckedChanged;
            // 
            // label_scriptPath
            // 
            label_scriptPath.AutoSize = true;
            label_scriptPath.Location = new System.Drawing.Point(6, 22);
            label_scriptPath.Margin = new System.Windows.Forms.Padding(3);
            label_scriptPath.Name = "label_scriptPath";
            label_scriptPath.Size = new System.Drawing.Size(67, 15);
            label_scriptPath.TabIndex = 2;
            label_scriptPath.Text = "Script Path:";
            // 
            // button_selectScriptPath
            // 
            button_selectScriptPath.Location = new System.Drawing.Point(6, 43);
            button_selectScriptPath.Name = "button_selectScriptPath";
            button_selectScriptPath.Size = new System.Drawing.Size(75, 23);
            button_selectScriptPath.TabIndex = 1;
            button_selectScriptPath.Text = "Select";
            button_selectScriptPath.UseVisualStyleBackColor = true;
            button_selectScriptPath.Click += button_selectScriptPath_Click;
            // 
            // textBox_scriptPath
            // 
            textBox_scriptPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_scriptPath.BorderColor = System.Drawing.Color.Black;
            textBox_scriptPath.DisplayBorder = true;
            textBox_scriptPath.Location = new System.Drawing.Point(87, 43);
            textBox_scriptPath.MaxLength = 32767;
            textBox_scriptPath.Multiline = false;
            textBox_scriptPath.Name = "textBox_scriptPath";
            textBox_scriptPath.OnTextChanged = null;
            textBox_scriptPath.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_scriptPath.PlaceholderText = "";
            textBox_scriptPath.ReadOnly = false;
            textBox_scriptPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_scriptPath.SelectionStart = 0;
            textBox_scriptPath.Size = new System.Drawing.Size(330, 23);
            textBox_scriptPath.TabIndex = 0;
            textBox_scriptPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_scriptPath.ValueBox = false;
            textBox_scriptPath.WordWrap = true;
            textBox_scriptPath.TextChanged += textBox_scriptPath_TextChanged;
            // 
            // PageCompiling
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(group_compilationSettings);
            Controls.Add(checkBox_enableCompilation);
            Name = "PageCompiling";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(435, 349);
            group_compilationSettings.ResumeLayout(false);
            group_compilationSettings.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_enableCompilation;
        private System.Windows.Forms.GroupBox group_compilationSettings;
        private System.Windows.Forms.Label label_scriptPath;
        private System.Windows.Forms.Button button_selectScriptPath;
        private Theming.CustomControls.FlatTextBox textBox_scriptPath;
        private System.Windows.Forms.CheckBox chb_ignoreErrors;
    }
}
