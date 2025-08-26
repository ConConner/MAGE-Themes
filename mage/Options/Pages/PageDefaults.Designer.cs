namespace mage.Options.Pages
{
    partial class PageDefaults
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
            group_background = new System.Windows.Forms.GroupBox();
            checkBox_bg3 = new System.Windows.Forms.CheckBox();
            checkBox_bg2 = new System.Windows.Forms.CheckBox();
            checkBox_bg1 = new System.Windows.Forms.CheckBox();
            checkBox_bg0 = new System.Windows.Forms.CheckBox();
            group_clipdata = new System.Windows.Forms.GroupBox();
            checkBox_none = new System.Windows.Forms.RadioButton();
            checkBox_values = new System.Windows.Forms.RadioButton();
            checkBox_collision = new System.Windows.Forms.RadioButton();
            checkBox_breakable = new System.Windows.Forms.RadioButton();
            label_defaultValues = new System.Windows.Forms.Label();
            group_roomObjects = new System.Windows.Forms.GroupBox();
            checkBox_screenOutlines = new System.Windows.Forms.CheckBox();
            checkBox_scrolls = new System.Windows.Forms.CheckBox();
            checkBox_doors = new System.Windows.Forms.CheckBox();
            checkBox_spriteOutlines = new System.Windows.Forms.CheckBox();
            checkBox_sprites = new System.Windows.Forms.CheckBox();
            seperator1 = new mage.Controls.Seperator();
            label_numberBase = new System.Windows.Forms.Label();
            radio_hex = new System.Windows.Forms.RadioButton();
            radio_dec = new System.Windows.Forms.RadioButton();
            seperator2 = new mage.Controls.Seperator();
            checkBox_hideTooltips = new System.Windows.Forms.CheckBox();
            group_background.SuspendLayout();
            group_clipdata.SuspendLayout();
            group_roomObjects.SuspendLayout();
            SuspendLayout();
            // 
            // group_background
            // 
            group_background.Controls.Add(checkBox_bg3);
            group_background.Controls.Add(checkBox_bg2);
            group_background.Controls.Add(checkBox_bg1);
            group_background.Controls.Add(checkBox_bg0);
            group_background.Location = new System.Drawing.Point(6, 27);
            group_background.Name = "group_background";
            group_background.Size = new System.Drawing.Size(95, 150);
            group_background.TabIndex = 0;
            group_background.TabStop = false;
            group_background.Text = "Backgrounds";
            // 
            // checkBox_bg3
            // 
            checkBox_bg3.AutoSize = true;
            checkBox_bg3.Location = new System.Drawing.Point(6, 97);
            checkBox_bg3.Name = "checkBox_bg3";
            checkBox_bg3.Size = new System.Drawing.Size(78, 19);
            checkBox_bg3.TabIndex = 3;
            checkBox_bg3.Text = "View BG 3";
            checkBox_bg3.UseVisualStyleBackColor = true;
            checkBox_bg3.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_bg2
            // 
            checkBox_bg2.AutoSize = true;
            checkBox_bg2.Location = new System.Drawing.Point(6, 72);
            checkBox_bg2.Name = "checkBox_bg2";
            checkBox_bg2.Size = new System.Drawing.Size(78, 19);
            checkBox_bg2.TabIndex = 2;
            checkBox_bg2.Text = "View BG 2";
            checkBox_bg2.UseVisualStyleBackColor = true;
            checkBox_bg2.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_bg1
            // 
            checkBox_bg1.AutoSize = true;
            checkBox_bg1.Location = new System.Drawing.Point(6, 47);
            checkBox_bg1.Name = "checkBox_bg1";
            checkBox_bg1.Size = new System.Drawing.Size(78, 19);
            checkBox_bg1.TabIndex = 1;
            checkBox_bg1.Text = "View BG 1";
            checkBox_bg1.UseVisualStyleBackColor = true;
            checkBox_bg1.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_bg0
            // 
            checkBox_bg0.AutoSize = true;
            checkBox_bg0.Location = new System.Drawing.Point(6, 22);
            checkBox_bg0.Name = "checkBox_bg0";
            checkBox_bg0.Size = new System.Drawing.Size(78, 19);
            checkBox_bg0.TabIndex = 0;
            checkBox_bg0.Text = "View BG 0";
            checkBox_bg0.UseVisualStyleBackColor = true;
            checkBox_bg0.CheckedChanged += checkBox_ValueChanged;
            // 
            // group_clipdata
            // 
            group_clipdata.Controls.Add(checkBox_none);
            group_clipdata.Controls.Add(checkBox_values);
            group_clipdata.Controls.Add(checkBox_collision);
            group_clipdata.Controls.Add(checkBox_breakable);
            group_clipdata.Location = new System.Drawing.Point(107, 27);
            group_clipdata.Name = "group_clipdata";
            group_clipdata.Size = new System.Drawing.Size(153, 150);
            group_clipdata.TabIndex = 1;
            group_clipdata.TabStop = false;
            group_clipdata.Text = "Clipdata";
            // 
            // checkBox_none
            // 
            checkBox_none.AutoSize = true;
            checkBox_none.Location = new System.Drawing.Point(6, 22);
            checkBox_none.Name = "checkBox_none";
            checkBox_none.Size = new System.Drawing.Size(54, 19);
            checkBox_none.TabIndex = 3;
            checkBox_none.TabStop = true;
            checkBox_none.Text = "None";
            checkBox_none.UseVisualStyleBackColor = true;
            checkBox_none.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_values
            // 
            checkBox_values.AutoSize = true;
            checkBox_values.Location = new System.Drawing.Point(6, 97);
            checkBox_values.Name = "checkBox_values";
            checkBox_values.Size = new System.Drawing.Size(118, 19);
            checkBox_values.TabIndex = 2;
            checkBox_values.TabStop = true;
            checkBox_values.Text = "View block values";
            checkBox_values.UseVisualStyleBackColor = true;
            checkBox_values.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_collision
            // 
            checkBox_collision.AutoSize = true;
            checkBox_collision.Location = new System.Drawing.Point(6, 47);
            checkBox_collision.Name = "checkBox_collision";
            checkBox_collision.Size = new System.Drawing.Size(142, 19);
            checkBox_collision.TabIndex = 0;
            checkBox_collision.TabStop = true;
            checkBox_collision.Text = "View collision outlines";
            checkBox_collision.UseVisualStyleBackColor = true;
            checkBox_collision.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_breakable
            // 
            checkBox_breakable.AutoSize = true;
            checkBox_breakable.Location = new System.Drawing.Point(6, 72);
            checkBox_breakable.Name = "checkBox_breakable";
            checkBox_breakable.Size = new System.Drawing.Size(141, 19);
            checkBox_breakable.TabIndex = 1;
            checkBox_breakable.TabStop = true;
            checkBox_breakable.Text = "View breakable blocks";
            checkBox_breakable.UseVisualStyleBackColor = true;
            checkBox_breakable.CheckedChanged += checkBox_ValueChanged;
            // 
            // label_defaultValues
            // 
            label_defaultValues.AutoSize = true;
            label_defaultValues.Location = new System.Drawing.Point(6, 6);
            label_defaultValues.Margin = new System.Windows.Forms.Padding(3);
            label_defaultValues.Name = "label_defaultValues";
            label_defaultValues.Size = new System.Drawing.Size(254, 15);
            label_defaultValues.TabIndex = 2;
            label_defaultValues.Text = "Default view configuration for the Room Editor";
            // 
            // group_roomObjects
            // 
            group_roomObjects.Controls.Add(checkBox_screenOutlines);
            group_roomObjects.Controls.Add(checkBox_scrolls);
            group_roomObjects.Controls.Add(checkBox_doors);
            group_roomObjects.Controls.Add(checkBox_spriteOutlines);
            group_roomObjects.Controls.Add(checkBox_sprites);
            group_roomObjects.Location = new System.Drawing.Point(266, 27);
            group_roomObjects.Name = "group_roomObjects";
            group_roomObjects.Size = new System.Drawing.Size(140, 150);
            group_roomObjects.TabIndex = 3;
            group_roomObjects.TabStop = false;
            group_roomObjects.Text = "Room Objects";
            // 
            // checkBox_screenOutlines
            // 
            checkBox_screenOutlines.AutoSize = true;
            checkBox_screenOutlines.Location = new System.Drawing.Point(6, 122);
            checkBox_screenOutlines.Name = "checkBox_screenOutlines";
            checkBox_screenOutlines.Size = new System.Drawing.Size(133, 19);
            checkBox_screenOutlines.TabIndex = 5;
            checkBox_screenOutlines.Text = "View screen outlines";
            checkBox_screenOutlines.UseVisualStyleBackColor = true;
            checkBox_screenOutlines.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_scrolls
            // 
            checkBox_scrolls.AutoSize = true;
            checkBox_scrolls.Location = new System.Drawing.Point(6, 97);
            checkBox_scrolls.Name = "checkBox_scrolls";
            checkBox_scrolls.Size = new System.Drawing.Size(88, 19);
            checkBox_scrolls.TabIndex = 4;
            checkBox_scrolls.Text = "View Scrolls";
            checkBox_scrolls.UseVisualStyleBackColor = true;
            checkBox_scrolls.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_doors
            // 
            checkBox_doors.AutoSize = true;
            checkBox_doors.Location = new System.Drawing.Point(6, 72);
            checkBox_doors.Name = "checkBox_doors";
            checkBox_doors.Size = new System.Drawing.Size(85, 19);
            checkBox_doors.TabIndex = 3;
            checkBox_doors.Text = "View Doors";
            checkBox_doors.UseVisualStyleBackColor = true;
            checkBox_doors.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_spriteOutlines
            // 
            checkBox_spriteOutlines.AutoSize = true;
            checkBox_spriteOutlines.Location = new System.Drawing.Point(6, 47);
            checkBox_spriteOutlines.Name = "checkBox_spriteOutlines";
            checkBox_spriteOutlines.Size = new System.Drawing.Size(124, 19);
            checkBox_spriteOutlines.TabIndex = 2;
            checkBox_spriteOutlines.Text = "View Sprite outline";
            checkBox_spriteOutlines.UseVisualStyleBackColor = true;
            checkBox_spriteOutlines.CheckedChanged += checkBox_ValueChanged;
            // 
            // checkBox_sprites
            // 
            checkBox_sprites.AutoSize = true;
            checkBox_sprites.Location = new System.Drawing.Point(6, 22);
            checkBox_sprites.Name = "checkBox_sprites";
            checkBox_sprites.Size = new System.Drawing.Size(89, 19);
            checkBox_sprites.TabIndex = 1;
            checkBox_sprites.Text = "View Sprites";
            checkBox_sprites.UseVisualStyleBackColor = true;
            checkBox_sprites.CheckedChanged += checkBox_ValueChanged;
            // 
            // seperator1
            // 
            seperator1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            seperator1.Location = new System.Drawing.Point(6, 183);
            seperator1.Name = "seperator1";
            seperator1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            seperator1.Size = new System.Drawing.Size(399, 1);
            seperator1.TabIndex = 4;
            seperator1.Text = "seperator1";
            // 
            // label_numberBase
            // 
            label_numberBase.AutoSize = true;
            label_numberBase.Location = new System.Drawing.Point(6, 190);
            label_numberBase.Margin = new System.Windows.Forms.Padding(3);
            label_numberBase.Name = "label_numberBase";
            label_numberBase.Size = new System.Drawing.Size(81, 15);
            label_numberBase.TabIndex = 5;
            label_numberBase.Text = "Number Base:";
            // 
            // radio_hex
            // 
            radio_hex.AutoSize = true;
            radio_hex.Location = new System.Drawing.Point(6, 211);
            radio_hex.Name = "radio_hex";
            radio_hex.Size = new System.Drawing.Size(246, 19);
            radio_hex.TabIndex = 6;
            radio_hex.TabStop = true;
            radio_hex.Text = "(HEX) Represent numbers as Hexadecimal";
            radio_hex.UseVisualStyleBackColor = true;
            radio_hex.CheckedChanged += radio_hex_CheckedChanged;
            // 
            // radio_dec
            // 
            radio_dec.AutoSize = true;
            radio_dec.Location = new System.Drawing.Point(6, 236);
            radio_dec.Name = "radio_dec";
            radio_dec.Size = new System.Drawing.Size(220, 19);
            radio_dec.TabIndex = 7;
            radio_dec.TabStop = true;
            radio_dec.Text = "(DEC) Represent numbers as Decimal";
            radio_dec.UseVisualStyleBackColor = true;
            radio_dec.CheckedChanged += radio_hex_CheckedChanged;
            // 
            // seperator2
            // 
            seperator2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            seperator2.Location = new System.Drawing.Point(6, 261);
            seperator2.Name = "seperator2";
            seperator2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            seperator2.Size = new System.Drawing.Size(399, 1);
            seperator2.TabIndex = 8;
            seperator2.Text = "seperator2";
            // 
            // checkBox_hideTooltips
            // 
            checkBox_hideTooltips.AutoSize = true;
            checkBox_hideTooltips.Location = new System.Drawing.Point(6, 268);
            checkBox_hideTooltips.Name = "checkBox_hideTooltips";
            checkBox_hideTooltips.Size = new System.Drawing.Size(108, 19);
            checkBox_hideTooltips.TabIndex = 9;
            checkBox_hideTooltips.Text = "Disable Tooltips";
            checkBox_hideTooltips.UseVisualStyleBackColor = true;
            checkBox_hideTooltips.CheckedChanged += checkBox_hideTooltips_CheckedChanged;
            // 
            // PageDefaults
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(checkBox_hideTooltips);
            Controls.Add(seperator2);
            Controls.Add(radio_dec);
            Controls.Add(radio_hex);
            Controls.Add(label_numberBase);
            Controls.Add(seperator1);
            Controls.Add(group_roomObjects);
            Controls.Add(label_defaultValues);
            Controls.Add(group_clipdata);
            Controls.Add(group_background);
            Name = "PageDefaults";
            Padding = new System.Windows.Forms.Padding(3);
            Size = new System.Drawing.Size(411, 302);
            group_background.ResumeLayout(false);
            group_background.PerformLayout();
            group_clipdata.ResumeLayout(false);
            group_clipdata.PerformLayout();
            group_roomObjects.ResumeLayout(false);
            group_roomObjects.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox group_background;
        private System.Windows.Forms.CheckBox checkBox_bg0;
        private System.Windows.Forms.CheckBox checkBox_bg3;
        private System.Windows.Forms.CheckBox checkBox_bg2;
        private System.Windows.Forms.CheckBox checkBox_bg1;
        private System.Windows.Forms.GroupBox group_clipdata;
        private System.Windows.Forms.RadioButton checkBox_collision;
        private System.Windows.Forms.RadioButton checkBox_breakable;
        private System.Windows.Forms.RadioButton checkBox_values;
        private System.Windows.Forms.Label label_defaultValues;
        private System.Windows.Forms.GroupBox group_roomObjects;
        private System.Windows.Forms.CheckBox checkBox_screenOutlines;
        private System.Windows.Forms.CheckBox checkBox_scrolls;
        private System.Windows.Forms.CheckBox checkBox_doors;
        private System.Windows.Forms.CheckBox checkBox_spriteOutlines;
        private System.Windows.Forms.CheckBox checkBox_sprites;
        private System.Windows.Forms.RadioButton checkBox_none;
        private Controls.Seperator seperator1;
        private System.Windows.Forms.Label label_numberBase;
        private System.Windows.Forms.RadioButton radio_hex;
        private System.Windows.Forms.RadioButton radio_dec;
        private Controls.Seperator seperator2;
        private System.Windows.Forms.CheckBox checkBox_hideTooltips;
    }
}
