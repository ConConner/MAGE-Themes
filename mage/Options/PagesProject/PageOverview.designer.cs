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
            group_resources = new System.Windows.Forms.GroupBox();
            label_spritesets = new System.Windows.Forms.Label();
            textBox_spritesets = new mage.Theming.CustomControls.FlatTextBox();
            label_animatedPalettes = new System.Windows.Forms.Label();
            textBox_animatedPalettes = new mage.Theming.CustomControls.FlatTextBox();
            label_animatedGraphics = new System.Windows.Forms.Label();
            textBox_animatedGraphics = new mage.Theming.CustomControls.FlatTextBox();
            label_animatedTilesets = new System.Windows.Forms.Label();
            textBox_animatedTilesets = new mage.Theming.CustomControls.FlatTextBox();
            label_tilesets = new System.Windows.Forms.Label();
            textBox_tilesets = new mage.Theming.CustomControls.FlatTextBox();
            group_about.SuspendLayout();
            group_resources.SuspendLayout();
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
            group_about.Controls.Add(label_createdValue);
            group_about.Controls.Add(label_lastModifiedValue);
            group_about.Controls.Add(label_created);
            group_about.Controls.Add(label_lastModified);
            group_about.Dock = System.Windows.Forms.DockStyle.Top;
            group_about.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            group_about.Location = new System.Drawing.Point(6, 6);
            group_about.Name = "group_about";
            group_about.Size = new System.Drawing.Size(423, 77);
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
            group_rooms.AutoSize = true;
            group_rooms.Dock = System.Windows.Forms.DockStyle.Top;
            group_rooms.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            group_rooms.Location = new System.Drawing.Point(6, 83);
            group_rooms.Name = "group_rooms";
            group_rooms.Size = new System.Drawing.Size(423, 28);
            group_rooms.TabIndex = 15;
            group_rooms.TabStop = false;
            group_rooms.Text = "Rooms";
            // 
            // group_resources
            // 
            group_resources.Controls.Add(label_spritesets);
            group_resources.Controls.Add(textBox_spritesets);
            group_resources.Controls.Add(label_animatedPalettes);
            group_resources.Controls.Add(textBox_animatedPalettes);
            group_resources.Controls.Add(label_animatedGraphics);
            group_resources.Controls.Add(textBox_animatedGraphics);
            group_resources.Controls.Add(label_animatedTilesets);
            group_resources.Controls.Add(textBox_animatedTilesets);
            group_resources.Controls.Add(label_tilesets);
            group_resources.Controls.Add(textBox_tilesets);
            group_resources.Dock = System.Windows.Forms.DockStyle.Top;
            group_resources.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            group_resources.Location = new System.Drawing.Point(6, 111);
            group_resources.Name = "group_resources";
            group_resources.Size = new System.Drawing.Size(423, 173);
            group_resources.TabIndex = 16;
            group_resources.TabStop = false;
            group_resources.Text = "Resources";
            // 
            // label_spritesets
            // 
            label_spritesets.AutoSize = true;
            label_spritesets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_spritesets.Location = new System.Drawing.Point(37, 148);
            label_spritesets.Name = "label_spritesets";
            label_spritesets.Size = new System.Drawing.Size(57, 15);
            label_spritesets.TabIndex = 9;
            label_spritesets.Text = "Spritesets";
            // 
            // textBox_spritesets
            // 
            textBox_spritesets.BorderColor = System.Drawing.Color.Black;
            textBox_spritesets.DisplayBorder = true;
            textBox_spritesets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox_spritesets.Location = new System.Drawing.Point(6, 144);
            textBox_spritesets.MaxLength = 32767;
            textBox_spritesets.Multiline = false;
            textBox_spritesets.Name = "textBox_spritesets";
            textBox_spritesets.OnTextChanged = null;
            textBox_spritesets.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_spritesets.PlaceholderText = "";
            textBox_spritesets.ReadOnly = false;
            textBox_spritesets.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_spritesets.SelectionStart = 0;
            textBox_spritesets.Size = new System.Drawing.Size(25, 23);
            textBox_spritesets.TabIndex = 8;
            textBox_spritesets.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_spritesets.ValueBox = false;
            textBox_spritesets.WordWrap = true;
            // 
            // label_animatedPalettes
            // 
            label_animatedPalettes.AutoSize = true;
            label_animatedPalettes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_animatedPalettes.Location = new System.Drawing.Point(37, 119);
            label_animatedPalettes.Name = "label_animatedPalettes";
            label_animatedPalettes.Size = new System.Drawing.Size(103, 15);
            label_animatedPalettes.TabIndex = 7;
            label_animatedPalettes.Text = "Animated Palettes";
            // 
            // textBox_animatedPalettes
            // 
            textBox_animatedPalettes.BorderColor = System.Drawing.Color.Black;
            textBox_animatedPalettes.DisplayBorder = true;
            textBox_animatedPalettes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox_animatedPalettes.Location = new System.Drawing.Point(6, 115);
            textBox_animatedPalettes.MaxLength = 32767;
            textBox_animatedPalettes.Multiline = false;
            textBox_animatedPalettes.Name = "textBox_animatedPalettes";
            textBox_animatedPalettes.OnTextChanged = null;
            textBox_animatedPalettes.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_animatedPalettes.PlaceholderText = "";
            textBox_animatedPalettes.ReadOnly = false;
            textBox_animatedPalettes.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_animatedPalettes.SelectionStart = 0;
            textBox_animatedPalettes.Size = new System.Drawing.Size(25, 23);
            textBox_animatedPalettes.TabIndex = 6;
            textBox_animatedPalettes.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_animatedPalettes.ValueBox = false;
            textBox_animatedPalettes.WordWrap = true;
            // 
            // label_animatedGraphics
            // 
            label_animatedGraphics.AutoSize = true;
            label_animatedGraphics.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_animatedGraphics.Location = new System.Drawing.Point(37, 90);
            label_animatedGraphics.Name = "label_animatedGraphics";
            label_animatedGraphics.Size = new System.Drawing.Size(108, 15);
            label_animatedGraphics.TabIndex = 5;
            label_animatedGraphics.Text = "Animated Graphics";
            // 
            // textBox_animatedGraphics
            // 
            textBox_animatedGraphics.BorderColor = System.Drawing.Color.Black;
            textBox_animatedGraphics.DisplayBorder = true;
            textBox_animatedGraphics.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox_animatedGraphics.Location = new System.Drawing.Point(6, 86);
            textBox_animatedGraphics.MaxLength = 32767;
            textBox_animatedGraphics.Multiline = false;
            textBox_animatedGraphics.Name = "textBox_animatedGraphics";
            textBox_animatedGraphics.OnTextChanged = null;
            textBox_animatedGraphics.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_animatedGraphics.PlaceholderText = "";
            textBox_animatedGraphics.ReadOnly = false;
            textBox_animatedGraphics.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_animatedGraphics.SelectionStart = 0;
            textBox_animatedGraphics.Size = new System.Drawing.Size(25, 23);
            textBox_animatedGraphics.TabIndex = 4;
            textBox_animatedGraphics.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_animatedGraphics.ValueBox = false;
            textBox_animatedGraphics.WordWrap = true;
            // 
            // label_animatedTilesets
            // 
            label_animatedTilesets.AutoSize = true;
            label_animatedTilesets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_animatedTilesets.Location = new System.Drawing.Point(37, 61);
            label_animatedTilesets.Name = "label_animatedTilesets";
            label_animatedTilesets.Size = new System.Drawing.Size(100, 15);
            label_animatedTilesets.TabIndex = 3;
            label_animatedTilesets.Text = "Animated Tilesets";
            // 
            // textBox_animatedTilesets
            // 
            textBox_animatedTilesets.BorderColor = System.Drawing.Color.Black;
            textBox_animatedTilesets.DisplayBorder = true;
            textBox_animatedTilesets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox_animatedTilesets.Location = new System.Drawing.Point(6, 57);
            textBox_animatedTilesets.MaxLength = 32767;
            textBox_animatedTilesets.Multiline = false;
            textBox_animatedTilesets.Name = "textBox_animatedTilesets";
            textBox_animatedTilesets.OnTextChanged = null;
            textBox_animatedTilesets.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_animatedTilesets.PlaceholderText = "";
            textBox_animatedTilesets.ReadOnly = false;
            textBox_animatedTilesets.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_animatedTilesets.SelectionStart = 0;
            textBox_animatedTilesets.Size = new System.Drawing.Size(25, 23);
            textBox_animatedTilesets.TabIndex = 2;
            textBox_animatedTilesets.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_animatedTilesets.ValueBox = false;
            textBox_animatedTilesets.WordWrap = true;
            // 
            // label_tilesets
            // 
            label_tilesets.AutoSize = true;
            label_tilesets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label_tilesets.Location = new System.Drawing.Point(37, 32);
            label_tilesets.Name = "label_tilesets";
            label_tilesets.Size = new System.Drawing.Size(45, 15);
            label_tilesets.TabIndex = 1;
            label_tilesets.Text = "Tilesets";
            // 
            // textBox_tilesets
            // 
            textBox_tilesets.BorderColor = System.Drawing.Color.Black;
            textBox_tilesets.DisplayBorder = true;
            textBox_tilesets.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBox_tilesets.Location = new System.Drawing.Point(6, 28);
            textBox_tilesets.MaxLength = 32767;
            textBox_tilesets.Multiline = false;
            textBox_tilesets.Name = "textBox_tilesets";
            textBox_tilesets.OnTextChanged = null;
            textBox_tilesets.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_tilesets.PlaceholderText = "";
            textBox_tilesets.ReadOnly = false;
            textBox_tilesets.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_tilesets.SelectionStart = 0;
            textBox_tilesets.Size = new System.Drawing.Size(25, 23);
            textBox_tilesets.TabIndex = 0;
            textBox_tilesets.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_tilesets.ValueBox = false;
            textBox_tilesets.WordWrap = true;
            // 
            // PageOverview
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(group_resources);
            Controls.Add(group_rooms);
            Controls.Add(group_about);
            Name = "PageOverview";
            Padding = new System.Windows.Forms.Padding(6);
            Size = new System.Drawing.Size(435, 349);
            group_about.ResumeLayout(false);
            group_about.PerformLayout();
            group_resources.ResumeLayout(false);
            group_resources.PerformLayout();
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
        private System.Windows.Forms.GroupBox group_resources;
        private System.Windows.Forms.Label label_animatedTilesets;
        private Theming.CustomControls.FlatTextBox textBox_animatedTilesets;
        private System.Windows.Forms.Label label_tilesets;
        private Theming.CustomControls.FlatTextBox textBox_tilesets;
        private System.Windows.Forms.Label label_spritesets;
        private Theming.CustomControls.FlatTextBox textBox_spritesets;
        private System.Windows.Forms.Label label_animatedPalettes;
        private Theming.CustomControls.FlatTextBox textBox_animatedPalettes;
        private System.Windows.Forms.Label label_animatedGraphics;
        private Theming.CustomControls.FlatTextBox textBox_animatedGraphics;
    }
}
