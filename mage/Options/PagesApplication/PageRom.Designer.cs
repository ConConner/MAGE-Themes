namespace mage.Options.Pages
{
    partial class PageRom
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
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            group_emulators = new System.Windows.Forms.GroupBox();
            listBox_emulators = new System.Windows.Forms.ListBox();
            panel_emulatorControls = new System.Windows.Forms.Panel();
            button_add = new System.Windows.Forms.Button();
            button_remove = new System.Windows.Forms.Button();
            label_currentEmulator = new System.Windows.Forms.Label();
            seperator1 = new mage.Controls.Seperator();
            label_testPath = new System.Windows.Forms.Label();
            button_selectPath = new System.Windows.Forms.Button();
            textBox_testPath = new mage.Theming.CustomControls.FlatTextBox();
            group_emulators.SuspendLayout();
            panel_emulatorControls.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(3, 310);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(361, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // group_emulators
            // 
            group_emulators.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            group_emulators.Controls.Add(listBox_emulators);
            group_emulators.Controls.Add(panel_emulatorControls);
            group_emulators.Location = new System.Drawing.Point(6, 6);
            group_emulators.Name = "group_emulators";
            group_emulators.Padding = new System.Windows.Forms.Padding(6, 6, 3, 3);
            group_emulators.Size = new System.Drawing.Size(355, 164);
            group_emulators.TabIndex = 11;
            group_emulators.TabStop = false;
            group_emulators.Text = "Emulators";
            // 
            // listBox_emulators
            // 
            listBox_emulators.BorderStyle = System.Windows.Forms.BorderStyle.None;
            listBox_emulators.Dock = System.Windows.Forms.DockStyle.Fill;
            listBox_emulators.FormattingEnabled = true;
            listBox_emulators.ItemHeight = 15;
            listBox_emulators.Location = new System.Drawing.Point(6, 22);
            listBox_emulators.Name = "listBox_emulators";
            listBox_emulators.Size = new System.Drawing.Size(346, 110);
            listBox_emulators.TabIndex = 1;
            listBox_emulators.SelectedIndexChanged += listBox_emulators_SelectedIndexChanged;
            // 
            // panel_emulatorControls
            // 
            panel_emulatorControls.Controls.Add(button_add);
            panel_emulatorControls.Controls.Add(button_remove);
            panel_emulatorControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel_emulatorControls.Location = new System.Drawing.Point(6, 132);
            panel_emulatorControls.Name = "panel_emulatorControls";
            panel_emulatorControls.Size = new System.Drawing.Size(346, 29);
            panel_emulatorControls.TabIndex = 0;
            // 
            // button_add
            // 
            button_add.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button_add.Image = Properties.Resources.toolbar_add;
            button_add.Location = new System.Drawing.Point(3, 3);
            button_add.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            button_add.Name = "button_add";
            button_add.Size = new System.Drawing.Size(23, 23);
            button_add.TabIndex = 12;
            button_add.UseVisualStyleBackColor = true;
            button_add.Click += button_add_Click;
            // 
            // button_remove
            // 
            button_remove.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            button_remove.Image = Properties.Resources.delete;
            button_remove.Location = new System.Drawing.Point(29, 3);
            button_remove.Name = "button_remove";
            button_remove.Size = new System.Drawing.Size(23, 23);
            button_remove.TabIndex = 13;
            button_remove.UseVisualStyleBackColor = true;
            button_remove.Click += button_remove_Click;
            // 
            // label_currentEmulator
            // 
            label_currentEmulator.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label_currentEmulator.Location = new System.Drawing.Point(6, 176);
            label_currentEmulator.Margin = new System.Windows.Forms.Padding(3);
            label_currentEmulator.Name = "label_currentEmulator";
            label_currentEmulator.Size = new System.Drawing.Size(355, 34);
            label_currentEmulator.TabIndex = 12;
            label_currentEmulator.Text = "Current Emulator path:";
            // 
            // seperator1
            // 
            seperator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            seperator1.Location = new System.Drawing.Point(6, 216);
            seperator1.Name = "seperator1";
            seperator1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            seperator1.Size = new System.Drawing.Size(355, 1);
            seperator1.TabIndex = 13;
            seperator1.Text = "seperator1";
            // 
            // label_testPath
            // 
            label_testPath.AutoSize = true;
            label_testPath.Location = new System.Drawing.Point(6, 223);
            label_testPath.Margin = new System.Windows.Forms.Padding(3);
            label_testPath.Name = "label_testPath";
            label_testPath.Size = new System.Drawing.Size(356, 15);
            label_testPath.TabIndex = 14;
            label_testPath.Text = "Test-ROM path. Add one, if there are issues launching a Test-ROM.";
            // 
            // button_selectPath
            // 
            button_selectPath.Location = new System.Drawing.Point(6, 244);
            button_selectPath.Name = "button_selectPath";
            button_selectPath.Size = new System.Drawing.Size(75, 23);
            button_selectPath.TabIndex = 15;
            button_selectPath.Text = "Select";
            button_selectPath.UseVisualStyleBackColor = true;
            button_selectPath.Click += button_selectPath_Click;
            // 
            // textBox_testPath
            // 
            textBox_testPath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_testPath.BorderColor = System.Drawing.Color.Black;
            textBox_testPath.DisplayBorder = true;
            textBox_testPath.Location = new System.Drawing.Point(87, 244);
            textBox_testPath.MaxLength = 32767;
            textBox_testPath.Multiline = false;
            textBox_testPath.Name = "textBox_testPath";
            textBox_testPath.OnTextChanged = null;
            textBox_testPath.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_testPath.PlaceholderText = "";
            textBox_testPath.ReadOnly = false;
            textBox_testPath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_testPath.SelectionStart = 0;
            textBox_testPath.Size = new System.Drawing.Size(274, 23);
            textBox_testPath.TabIndex = 16;
            textBox_testPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_testPath.ValueBox = false;
            textBox_testPath.WordWrap = true;
            // 
            // PageRom
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(textBox_testPath);
            Controls.Add(button_selectPath);
            Controls.Add(label_testPath);
            Controls.Add(seperator1);
            Controls.Add(label_currentEmulator);
            Controls.Add(group_emulators);
            Controls.Add(statusStrip1);
            Name = "PageRom";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(367, 335);
            group_emulators.ResumeLayout(false);
            panel_emulatorControls.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox group_emulators;
        private System.Windows.Forms.ListBox listBox_emulators;
        private System.Windows.Forms.Panel panel_emulatorControls;
        private System.Windows.Forms.Button button_add;
        private System.Windows.Forms.Button button_remove;
        private System.Windows.Forms.Label label_currentEmulator;
        private Controls.Seperator seperator1;
        private System.Windows.Forms.Label label_testPath;
        private System.Windows.Forms.Button button_selectPath;
        private Theming.CustomControls.FlatTextBox textBox_testPath;
    }
}
