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
            group_emulators.SuspendLayout();
            panel_emulatorControls.SuspendLayout();
            SuspendLayout();
            // 
            // statusStrip1
            // 
            statusStrip1.Location = new System.Drawing.Point(3, 310);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(352, 22);
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
            group_emulators.Size = new System.Drawing.Size(346, 164);
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
            listBox_emulators.Size = new System.Drawing.Size(337, 110);
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
            panel_emulatorControls.Size = new System.Drawing.Size(337, 29);
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
            label_currentEmulator.Size = new System.Drawing.Size(346, 34);
            label_currentEmulator.TabIndex = 12;
            label_currentEmulator.Text = "Current Emulator path:";
            // 
            // PageRom
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(label_currentEmulator);
            Controls.Add(group_emulators);
            Controls.Add(statusStrip1);
            Name = "PageRom";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(358, 335);
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
    }
}
