﻿namespace mage
{
    partial class FormHeader
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHeader));
            textBox_tileset = new Theming.CustomControls.FlatTextBox();
            label_tileset = new System.Windows.Forms.Label();
            textBox_BG0pointer = new Theming.CustomControls.FlatTextBox();
            textBox_BG1pointer = new Theming.CustomControls.FlatTextBox();
            textBox_BG2pointer = new Theming.CustomControls.FlatTextBox();
            textBox_BG3pointer = new Theming.CustomControls.FlatTextBox();
            textBox_CLPpointer = new Theming.CustomControls.FlatTextBox();
            textBox_BG0prop = new Theming.CustomControls.FlatTextBox();
            textBox_BG1prop = new Theming.CustomControls.FlatTextBox();
            textBox_BG2prop = new Theming.CustomControls.FlatTextBox();
            textBox_BG3prop = new Theming.CustomControls.FlatTextBox();
            label_BG0 = new System.Windows.Forms.Label();
            label_BG1 = new System.Windows.Forms.Label();
            label_BG2 = new System.Windows.Forms.Label();
            label_BG3 = new System.Windows.Forms.Label();
            label_CLP = new System.Windows.Forms.Label();
            label_BGpointer = new System.Windows.Forms.Label();
            label_prop = new System.Windows.Forms.Label();
            textBox_BG3scroll = new Theming.CustomControls.FlatTextBox();
            textBox_transparency = new Theming.CustomControls.FlatTextBox();
            label_BG3scroll = new System.Windows.Forms.Label();
            label_transparency = new System.Windows.Forms.Label();
            groupBox_BGdata = new System.Windows.Forms.GroupBox();
            btn_tileset_preset = new System.Windows.Forms.Button();
            btn_bg3_prop = new System.Windows.Forms.Button();
            btn_bg0_prop = new System.Windows.Forms.Button();
            btn_bg1_prop = new System.Windows.Forms.Button();
            btn_bg2_prop = new System.Windows.Forms.Button();
            btn_bg3_presets = new System.Windows.Forms.Button();
            textBox_effectYpos = new Theming.CustomControls.FlatTextBox();
            label1 = new System.Windows.Forms.Label();
            label_effect = new System.Windows.Forms.Label();
            textBox_effect = new Theming.CustomControls.FlatTextBox();
            groupBox_spritesetData = new System.Windows.Forms.GroupBox();
            label_second = new System.Windows.Forms.Label();
            label_first = new System.Windows.Forms.Label();
            label_default = new System.Windows.Forms.Label();
            label_event = new System.Windows.Forms.Label();
            label_spriteset = new System.Windows.Forms.Label();
            label_spritesetPointer = new System.Windows.Forms.Label();
            textBox_defaultPointer = new Theming.CustomControls.FlatTextBox();
            textBox_defaultSpriteset = new Theming.CustomControls.FlatTextBox();
            textBox_secondEvent = new Theming.CustomControls.FlatTextBox();
            textBox_secondPointer = new Theming.CustomControls.FlatTextBox();
            textBox_secondSpriteset = new Theming.CustomControls.FlatTextBox();
            textBox_firstEvent = new Theming.CustomControls.FlatTextBox();
            textBox_firstPointer = new Theming.CustomControls.FlatTextBox();
            textBox_firstSpriteset = new Theming.CustomControls.FlatTextBox();
            groupBox_misc = new System.Windows.Forms.GroupBox();
            btn_open_map = new System.Windows.Forms.Button();
            label_music = new System.Windows.Forms.Label();
            textBox_music = new Theming.CustomControls.FlatTextBox();
            label_mapY = new System.Windows.Forms.Label();
            label_mapX = new System.Windows.Forms.Label();
            textBox_mapX = new Theming.CustomControls.FlatTextBox();
            textBox_mapY = new Theming.CustomControls.FlatTextBox();
            button_apply = new System.Windows.Forms.Button();
            label_room = new System.Windows.Forms.Label();
            label_area = new System.Windows.Forms.Label();
            comboBox_room = new Theming.CustomControls.FlatComboBox();
            comboBox_area = new Theming.CustomControls.FlatComboBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            lbl_spring = new System.Windows.Forms.ToolStripStatusLabel();
            lbl_offset = new System.Windows.Forms.ToolStripStatusLabel();
            button_close = new System.Windows.Forms.Button();
            groupBox_BGdata.SuspendLayout();
            groupBox_spritesetData.SuspendLayout();
            groupBox_misc.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // textBox_tileset
            // 
            textBox_tileset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_tileset.DisplayBorder = true;
            textBox_tileset.Location = new System.Drawing.Point(102, 40);
            textBox_tileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_tileset.MaxLength = 32767;
            textBox_tileset.Multiline = false;
            textBox_tileset.Name = "textBox_tileset";
            textBox_tileset.OnTextChanged = null;
            textBox_tileset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_tileset.PlaceholderText = "";
            textBox_tileset.ReadOnly = false;
            textBox_tileset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_tileset.SelectionStart = 0;
            textBox_tileset.Size = new System.Drawing.Size(35, 23);
            textBox_tileset.TabIndex = 0;
            textBox_tileset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_tileset.ValueBox = false;
            textBox_tileset.WordWrap = true;
            textBox_tileset.TextChanged += textBox_TextChanged;
            // 
            // label_tileset
            // 
            label_tileset.AutoSize = true;
            label_tileset.Location = new System.Drawing.Point(7, 44);
            label_tileset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileset.Name = "label_tileset";
            label_tileset.Size = new System.Drawing.Size(43, 15);
            label_tileset.TabIndex = 0;
            label_tileset.Text = "Tileset:";
            // 
            // textBox_BG0pointer
            // 
            textBox_BG0pointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG0pointer.DisplayBorder = true;
            textBox_BG0pointer.Location = new System.Drawing.Point(225, 40);
            textBox_BG0pointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG0pointer.MaxLength = 32767;
            textBox_BG0pointer.Multiline = false;
            textBox_BG0pointer.Name = "textBox_BG0pointer";
            textBox_BG0pointer.OnTextChanged = null;
            textBox_BG0pointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG0pointer.PlaceholderText = "";
            textBox_BG0pointer.ReadOnly = false;
            textBox_BG0pointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG0pointer.SelectionStart = 0;
            textBox_BG0pointer.Size = new System.Drawing.Size(54, 23);
            textBox_BG0pointer.TabIndex = 5;
            textBox_BG0pointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG0pointer.ValueBox = true;
            textBox_BG0pointer.WordWrap = true;
            textBox_BG0pointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_BG1pointer
            // 
            textBox_BG1pointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG1pointer.DisplayBorder = true;
            textBox_BG1pointer.Location = new System.Drawing.Point(225, 70);
            textBox_BG1pointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG1pointer.MaxLength = 32767;
            textBox_BG1pointer.Multiline = false;
            textBox_BG1pointer.Name = "textBox_BG1pointer";
            textBox_BG1pointer.OnTextChanged = null;
            textBox_BG1pointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG1pointer.PlaceholderText = "";
            textBox_BG1pointer.ReadOnly = false;
            textBox_BG1pointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG1pointer.SelectionStart = 0;
            textBox_BG1pointer.Size = new System.Drawing.Size(54, 23);
            textBox_BG1pointer.TabIndex = 7;
            textBox_BG1pointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG1pointer.ValueBox = true;
            textBox_BG1pointer.WordWrap = true;
            textBox_BG1pointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_BG2pointer
            // 
            textBox_BG2pointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG2pointer.DisplayBorder = true;
            textBox_BG2pointer.Location = new System.Drawing.Point(225, 100);
            textBox_BG2pointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG2pointer.MaxLength = 32767;
            textBox_BG2pointer.Multiline = false;
            textBox_BG2pointer.Name = "textBox_BG2pointer";
            textBox_BG2pointer.OnTextChanged = null;
            textBox_BG2pointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG2pointer.PlaceholderText = "";
            textBox_BG2pointer.ReadOnly = false;
            textBox_BG2pointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG2pointer.SelectionStart = 0;
            textBox_BG2pointer.Size = new System.Drawing.Size(54, 23);
            textBox_BG2pointer.TabIndex = 9;
            textBox_BG2pointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG2pointer.ValueBox = true;
            textBox_BG2pointer.WordWrap = true;
            textBox_BG2pointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_BG3pointer
            // 
            textBox_BG3pointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG3pointer.DisplayBorder = true;
            textBox_BG3pointer.Location = new System.Drawing.Point(225, 130);
            textBox_BG3pointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG3pointer.MaxLength = 32767;
            textBox_BG3pointer.Multiline = false;
            textBox_BG3pointer.Name = "textBox_BG3pointer";
            textBox_BG3pointer.OnTextChanged = null;
            textBox_BG3pointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG3pointer.PlaceholderText = "";
            textBox_BG3pointer.ReadOnly = false;
            textBox_BG3pointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG3pointer.SelectionStart = 0;
            textBox_BG3pointer.Size = new System.Drawing.Size(54, 23);
            textBox_BG3pointer.TabIndex = 11;
            textBox_BG3pointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG3pointer.ValueBox = true;
            textBox_BG3pointer.WordWrap = true;
            textBox_BG3pointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_CLPpointer
            // 
            textBox_CLPpointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_CLPpointer.DisplayBorder = true;
            textBox_CLPpointer.Location = new System.Drawing.Point(225, 160);
            textBox_CLPpointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_CLPpointer.MaxLength = 32767;
            textBox_CLPpointer.Multiline = false;
            textBox_CLPpointer.Name = "textBox_CLPpointer";
            textBox_CLPpointer.OnTextChanged = null;
            textBox_CLPpointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_CLPpointer.PlaceholderText = "";
            textBox_CLPpointer.ReadOnly = false;
            textBox_CLPpointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_CLPpointer.SelectionStart = 0;
            textBox_CLPpointer.Size = new System.Drawing.Size(54, 23);
            textBox_CLPpointer.TabIndex = 13;
            textBox_CLPpointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_CLPpointer.ValueBox = true;
            textBox_CLPpointer.WordWrap = true;
            textBox_CLPpointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_BG0prop
            // 
            textBox_BG0prop.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG0prop.DisplayBorder = true;
            textBox_BG0prop.Location = new System.Drawing.Point(287, 41);
            textBox_BG0prop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG0prop.MaxLength = 32767;
            textBox_BG0prop.Multiline = false;
            textBox_BG0prop.Name = "textBox_BG0prop";
            textBox_BG0prop.OnTextChanged = null;
            textBox_BG0prop.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG0prop.PlaceholderText = "";
            textBox_BG0prop.ReadOnly = false;
            textBox_BG0prop.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG0prop.SelectionStart = 0;
            textBox_BG0prop.Size = new System.Drawing.Size(29, 23);
            textBox_BG0prop.TabIndex = 6;
            textBox_BG0prop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG0prop.ValueBox = false;
            textBox_BG0prop.WordWrap = true;
            textBox_BG0prop.TextChanged += textBox_TextChanged;
            // 
            // textBox_BG1prop
            // 
            textBox_BG1prop.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG1prop.DisplayBorder = true;
            textBox_BG1prop.Location = new System.Drawing.Point(287, 71);
            textBox_BG1prop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG1prop.MaxLength = 32767;
            textBox_BG1prop.Multiline = false;
            textBox_BG1prop.Name = "textBox_BG1prop";
            textBox_BG1prop.OnTextChanged = null;
            textBox_BG1prop.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG1prop.PlaceholderText = "";
            textBox_BG1prop.ReadOnly = false;
            textBox_BG1prop.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG1prop.SelectionStart = 0;
            textBox_BG1prop.Size = new System.Drawing.Size(29, 23);
            textBox_BG1prop.TabIndex = 8;
            textBox_BG1prop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG1prop.ValueBox = false;
            textBox_BG1prop.WordWrap = true;
            textBox_BG1prop.TextChanged += textBox_TextChanged;
            // 
            // textBox_BG2prop
            // 
            textBox_BG2prop.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG2prop.DisplayBorder = true;
            textBox_BG2prop.Location = new System.Drawing.Point(287, 100);
            textBox_BG2prop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG2prop.MaxLength = 32767;
            textBox_BG2prop.Multiline = false;
            textBox_BG2prop.Name = "textBox_BG2prop";
            textBox_BG2prop.OnTextChanged = null;
            textBox_BG2prop.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG2prop.PlaceholderText = "";
            textBox_BG2prop.ReadOnly = false;
            textBox_BG2prop.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG2prop.SelectionStart = 0;
            textBox_BG2prop.Size = new System.Drawing.Size(29, 23);
            textBox_BG2prop.TabIndex = 10;
            textBox_BG2prop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG2prop.ValueBox = false;
            textBox_BG2prop.WordWrap = true;
            textBox_BG2prop.TextChanged += textBox_TextChanged;
            // 
            // textBox_BG3prop
            // 
            textBox_BG3prop.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG3prop.DisplayBorder = true;
            textBox_BG3prop.Location = new System.Drawing.Point(287, 130);
            textBox_BG3prop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG3prop.MaxLength = 32767;
            textBox_BG3prop.Multiline = false;
            textBox_BG3prop.Name = "textBox_BG3prop";
            textBox_BG3prop.OnTextChanged = null;
            textBox_BG3prop.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG3prop.PlaceholderText = "";
            textBox_BG3prop.ReadOnly = false;
            textBox_BG3prop.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG3prop.SelectionStart = 0;
            textBox_BG3prop.Size = new System.Drawing.Size(29, 23);
            textBox_BG3prop.TabIndex = 12;
            textBox_BG3prop.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG3prop.ValueBox = false;
            textBox_BG3prop.WordWrap = true;
            textBox_BG3prop.TextChanged += textBox_TextChanged;
            // 
            // label_BG0
            // 
            label_BG0.AutoSize = true;
            label_BG0.Location = new System.Drawing.Point(178, 44);
            label_BG0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_BG0.Name = "label_BG0";
            label_BG0.Size = new System.Drawing.Size(34, 15);
            label_BG0.TabIndex = 0;
            label_BG0.Text = "BG 0:";
            // 
            // label_BG1
            // 
            label_BG1.AutoSize = true;
            label_BG1.Location = new System.Drawing.Point(178, 74);
            label_BG1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_BG1.Name = "label_BG1";
            label_BG1.Size = new System.Drawing.Size(34, 15);
            label_BG1.TabIndex = 0;
            label_BG1.Text = "BG 1:";
            // 
            // label_BG2
            // 
            label_BG2.AutoSize = true;
            label_BG2.Location = new System.Drawing.Point(178, 104);
            label_BG2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_BG2.Name = "label_BG2";
            label_BG2.Size = new System.Drawing.Size(34, 15);
            label_BG2.TabIndex = 0;
            label_BG2.Text = "BG 2:";
            // 
            // label_BG3
            // 
            label_BG3.AutoSize = true;
            label_BG3.Location = new System.Drawing.Point(178, 134);
            label_BG3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_BG3.Name = "label_BG3";
            label_BG3.Size = new System.Drawing.Size(34, 15);
            label_BG3.TabIndex = 0;
            label_BG3.Text = "BG 3:";
            // 
            // label_CLP
            // 
            label_CLP.AutoSize = true;
            label_CLP.Location = new System.Drawing.Point(178, 164);
            label_CLP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_CLP.Name = "label_CLP";
            label_CLP.Size = new System.Drawing.Size(31, 15);
            label_CLP.TabIndex = 0;
            label_CLP.Text = "Clip:";
            // 
            // label_BGpointer
            // 
            label_BGpointer.AutoSize = true;
            label_BGpointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            label_BGpointer.Location = new System.Drawing.Point(225, 18);
            label_BGpointer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_BGpointer.Name = "label_BGpointer";
            label_BGpointer.Size = new System.Drawing.Size(40, 13);
            label_BGpointer.TabIndex = 0;
            label_BGpointer.Text = "Pointer";
            // 
            // label_prop
            // 
            label_prop.AutoSize = true;
            label_prop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            label_prop.Location = new System.Drawing.Point(287, 19);
            label_prop.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_prop.Name = "label_prop";
            label_prop.Size = new System.Drawing.Size(29, 13);
            label_prop.TabIndex = 0;
            label_prop.Text = "Prop";
            // 
            // textBox_BG3scroll
            // 
            textBox_BG3scroll.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_BG3scroll.DisplayBorder = true;
            textBox_BG3scroll.Location = new System.Drawing.Point(102, 100);
            textBox_BG3scroll.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_BG3scroll.MaxLength = 32767;
            textBox_BG3scroll.Multiline = false;
            textBox_BG3scroll.Name = "textBox_BG3scroll";
            textBox_BG3scroll.OnTextChanged = null;
            textBox_BG3scroll.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_BG3scroll.PlaceholderText = "";
            textBox_BG3scroll.ReadOnly = false;
            textBox_BG3scroll.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_BG3scroll.SelectionStart = 0;
            textBox_BG3scroll.Size = new System.Drawing.Size(35, 23);
            textBox_BG3scroll.TabIndex = 2;
            textBox_BG3scroll.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_BG3scroll.ValueBox = false;
            textBox_BG3scroll.WordWrap = true;
            textBox_BG3scroll.TextChanged += textBox_TextChanged;
            // 
            // textBox_transparency
            // 
            textBox_transparency.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_transparency.DisplayBorder = true;
            textBox_transparency.Location = new System.Drawing.Point(102, 70);
            textBox_transparency.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_transparency.MaxLength = 32767;
            textBox_transparency.Multiline = false;
            textBox_transparency.Name = "textBox_transparency";
            textBox_transparency.OnTextChanged = null;
            textBox_transparency.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_transparency.PlaceholderText = "";
            textBox_transparency.ReadOnly = false;
            textBox_transparency.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_transparency.SelectionStart = 0;
            textBox_transparency.Size = new System.Drawing.Size(35, 23);
            textBox_transparency.TabIndex = 1;
            textBox_transparency.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_transparency.ValueBox = false;
            textBox_transparency.WordWrap = true;
            textBox_transparency.TextChanged += textBox_TextChanged;
            // 
            // label_BG3scroll
            // 
            label_BG3scroll.AutoSize = true;
            label_BG3scroll.Location = new System.Drawing.Point(7, 104);
            label_BG3scroll.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_BG3scroll.Name = "label_BG3scroll";
            label_BG3scroll.Size = new System.Drawing.Size(62, 15);
            label_BG3scroll.TabIndex = 0;
            label_BG3scroll.Text = "BG3 scroll:";
            // 
            // label_transparency
            // 
            label_transparency.AutoSize = true;
            label_transparency.Location = new System.Drawing.Point(7, 74);
            label_transparency.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_transparency.Name = "label_transparency";
            label_transparency.Size = new System.Drawing.Size(79, 15);
            label_transparency.TabIndex = 0;
            label_transparency.Text = "Transparency:";
            // 
            // groupBox_BGdata
            // 
            groupBox_BGdata.Controls.Add(btn_tileset_preset);
            groupBox_BGdata.Controls.Add(btn_bg3_prop);
            groupBox_BGdata.Controls.Add(btn_bg0_prop);
            groupBox_BGdata.Controls.Add(btn_bg1_prop);
            groupBox_BGdata.Controls.Add(btn_bg2_prop);
            groupBox_BGdata.Controls.Add(btn_bg3_presets);
            groupBox_BGdata.Controls.Add(textBox_BG0pointer);
            groupBox_BGdata.Controls.Add(label_transparency);
            groupBox_BGdata.Controls.Add(textBox_effectYpos);
            groupBox_BGdata.Controls.Add(label1);
            groupBox_BGdata.Controls.Add(label_BG3scroll);
            groupBox_BGdata.Controls.Add(label_effect);
            groupBox_BGdata.Controls.Add(textBox_effect);
            groupBox_BGdata.Controls.Add(textBox_BG1pointer);
            groupBox_BGdata.Controls.Add(textBox_transparency);
            groupBox_BGdata.Controls.Add(textBox_BG3prop);
            groupBox_BGdata.Controls.Add(textBox_BG3scroll);
            groupBox_BGdata.Controls.Add(label_BG3);
            groupBox_BGdata.Controls.Add(label_tileset);
            groupBox_BGdata.Controls.Add(textBox_BG2pointer);
            groupBox_BGdata.Controls.Add(textBox_tileset);
            groupBox_BGdata.Controls.Add(label_BG2);
            groupBox_BGdata.Controls.Add(textBox_BG2prop);
            groupBox_BGdata.Controls.Add(textBox_BG3pointer);
            groupBox_BGdata.Controls.Add(label_BG0);
            groupBox_BGdata.Controls.Add(label_CLP);
            groupBox_BGdata.Controls.Add(textBox_CLPpointer);
            groupBox_BGdata.Controls.Add(label_BG1);
            groupBox_BGdata.Controls.Add(textBox_BG1prop);
            groupBox_BGdata.Controls.Add(label_prop);
            groupBox_BGdata.Controls.Add(label_BGpointer);
            groupBox_BGdata.Controls.Add(textBox_BG0prop);
            groupBox_BGdata.Location = new System.Drawing.Point(14, 14);
            groupBox_BGdata.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_BGdata.Name = "groupBox_BGdata";
            groupBox_BGdata.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_BGdata.Size = new System.Drawing.Size(354, 194);
            groupBox_BGdata.TabIndex = 0;
            groupBox_BGdata.TabStop = false;
            groupBox_BGdata.Text = "Background Data";
            // 
            // btn_tileset_preset
            // 
            btn_tileset_preset.Image = Properties.Resources.toolbar_patches;
            btn_tileset_preset.Location = new System.Drawing.Point(144, 40);
            btn_tileset_preset.Name = "btn_tileset_preset";
            btn_tileset_preset.Size = new System.Drawing.Size(23, 23);
            btn_tileset_preset.TabIndex = 19;
            btn_tileset_preset.UseVisualStyleBackColor = true;
            btn_tileset_preset.Click += btn_tileset_preset_Click;
            // 
            // btn_bg3_prop
            // 
            btn_bg3_prop.Image = Properties.Resources.toolbar_patches;
            btn_bg3_prop.Location = new System.Drawing.Point(323, 130);
            btn_bg3_prop.Name = "btn_bg3_prop";
            btn_bg3_prop.Size = new System.Drawing.Size(23, 23);
            btn_bg3_prop.TabIndex = 18;
            btn_bg3_prop.UseVisualStyleBackColor = true;
            btn_bg3_prop.Click += btn_bg3_prop_Click;
            // 
            // btn_bg0_prop
            // 
            btn_bg0_prop.Image = Properties.Resources.toolbar_patches;
            btn_bg0_prop.Location = new System.Drawing.Point(323, 41);
            btn_bg0_prop.Name = "btn_bg0_prop";
            btn_bg0_prop.Size = new System.Drawing.Size(23, 23);
            btn_bg0_prop.TabIndex = 17;
            btn_bg0_prop.UseVisualStyleBackColor = true;
            btn_bg0_prop.Click += btn_bg0_prop_Click;
            // 
            // btn_bg1_prop
            // 
            btn_bg1_prop.Image = Properties.Resources.toolbar_patches;
            btn_bg1_prop.Location = new System.Drawing.Point(323, 71);
            btn_bg1_prop.Name = "btn_bg1_prop";
            btn_bg1_prop.Size = new System.Drawing.Size(23, 23);
            btn_bg1_prop.TabIndex = 16;
            btn_bg1_prop.UseVisualStyleBackColor = true;
            btn_bg1_prop.Click += btn_bg1_prop_Click;
            // 
            // btn_bg2_prop
            // 
            btn_bg2_prop.Image = Properties.Resources.toolbar_patches;
            btn_bg2_prop.Location = new System.Drawing.Point(323, 100);
            btn_bg2_prop.Name = "btn_bg2_prop";
            btn_bg2_prop.Size = new System.Drawing.Size(23, 23);
            btn_bg2_prop.TabIndex = 15;
            btn_bg2_prop.UseVisualStyleBackColor = true;
            btn_bg2_prop.Click += btn_bg2_prop_Click;
            // 
            // btn_bg3_presets
            // 
            btn_bg3_presets.Image = Properties.Resources.toolbar_patches;
            btn_bg3_presets.Location = new System.Drawing.Point(144, 100);
            btn_bg3_presets.Name = "btn_bg3_presets";
            btn_bg3_presets.Size = new System.Drawing.Size(23, 23);
            btn_bg3_presets.TabIndex = 14;
            btn_bg3_presets.UseVisualStyleBackColor = true;
            btn_bg3_presets.Click += btn_bg3_presets_Click;
            // 
            // textBox_effectYpos
            // 
            textBox_effectYpos.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_effectYpos.DisplayBorder = true;
            textBox_effectYpos.Location = new System.Drawing.Point(102, 160);
            textBox_effectYpos.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_effectYpos.MaxLength = 32767;
            textBox_effectYpos.Multiline = false;
            textBox_effectYpos.Name = "textBox_effectYpos";
            textBox_effectYpos.OnTextChanged = null;
            textBox_effectYpos.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_effectYpos.PlaceholderText = "";
            textBox_effectYpos.ReadOnly = false;
            textBox_effectYpos.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_effectYpos.SelectionStart = 0;
            textBox_effectYpos.Size = new System.Drawing.Size(35, 23);
            textBox_effectYpos.TabIndex = 4;
            textBox_effectYpos.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_effectYpos.ValueBox = false;
            textBox_effectYpos.WordWrap = true;
            textBox_effectYpos.TextChanged += textBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(7, 164);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(72, 15);
            label1.TabIndex = 0;
            label1.Text = "Effect Y pos:";
            // 
            // label_effect
            // 
            label_effect.AutoSize = true;
            label_effect.Location = new System.Drawing.Point(7, 134);
            label_effect.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_effect.Name = "label_effect";
            label_effect.Size = new System.Drawing.Size(40, 15);
            label_effect.TabIndex = 0;
            label_effect.Text = "Effect:";
            // 
            // textBox_effect
            // 
            textBox_effect.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_effect.DisplayBorder = true;
            textBox_effect.Location = new System.Drawing.Point(102, 130);
            textBox_effect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_effect.MaxLength = 32767;
            textBox_effect.Multiline = false;
            textBox_effect.Name = "textBox_effect";
            textBox_effect.OnTextChanged = null;
            textBox_effect.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_effect.PlaceholderText = "";
            textBox_effect.ReadOnly = false;
            textBox_effect.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_effect.SelectionStart = 0;
            textBox_effect.Size = new System.Drawing.Size(35, 23);
            textBox_effect.TabIndex = 3;
            textBox_effect.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_effect.ValueBox = false;
            textBox_effect.WordWrap = true;
            textBox_effect.TextChanged += textBox_TextChanged;
            // 
            // groupBox_spritesetData
            // 
            groupBox_spritesetData.Controls.Add(label_second);
            groupBox_spritesetData.Controls.Add(label_first);
            groupBox_spritesetData.Controls.Add(label_default);
            groupBox_spritesetData.Controls.Add(label_event);
            groupBox_spritesetData.Controls.Add(label_spriteset);
            groupBox_spritesetData.Controls.Add(label_spritesetPointer);
            groupBox_spritesetData.Controls.Add(textBox_defaultPointer);
            groupBox_spritesetData.Controls.Add(textBox_defaultSpriteset);
            groupBox_spritesetData.Controls.Add(textBox_secondEvent);
            groupBox_spritesetData.Controls.Add(textBox_secondPointer);
            groupBox_spritesetData.Controls.Add(textBox_secondSpriteset);
            groupBox_spritesetData.Controls.Add(textBox_firstEvent);
            groupBox_spritesetData.Controls.Add(textBox_firstPointer);
            groupBox_spritesetData.Controls.Add(textBox_firstSpriteset);
            groupBox_spritesetData.Location = new System.Drawing.Point(14, 215);
            groupBox_spritesetData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_spritesetData.Name = "groupBox_spritesetData";
            groupBox_spritesetData.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_spritesetData.Size = new System.Drawing.Size(239, 168);
            groupBox_spritesetData.TabIndex = 1;
            groupBox_spritesetData.TabStop = false;
            groupBox_spritesetData.Text = "Spriteset Data";
            // 
            // label_second
            // 
            label_second.AutoSize = true;
            label_second.Location = new System.Drawing.Point(7, 104);
            label_second.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_second.Name = "label_second";
            label_second.Size = new System.Drawing.Size(49, 15);
            label_second.TabIndex = 0;
            label_second.Text = "Second:";
            // 
            // label_first
            // 
            label_first.AutoSize = true;
            label_first.Location = new System.Drawing.Point(7, 74);
            label_first.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_first.Name = "label_first";
            label_first.Size = new System.Drawing.Size(32, 15);
            label_first.TabIndex = 0;
            label_first.Text = "First:";
            // 
            // label_default
            // 
            label_default.AutoSize = true;
            label_default.Location = new System.Drawing.Point(7, 44);
            label_default.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_default.Name = "label_default";
            label_default.Size = new System.Drawing.Size(48, 15);
            label_default.TabIndex = 0;
            label_default.Text = "Default:";
            // 
            // label_event
            // 
            label_event.AutoSize = true;
            label_event.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            label_event.Location = new System.Drawing.Point(192, 18);
            label_event.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_event.Name = "label_event";
            label_event.Size = new System.Drawing.Size(35, 13);
            label_event.TabIndex = 0;
            label_event.Text = "Event";
            // 
            // label_spriteset
            // 
            label_spriteset.AutoSize = true;
            label_spriteset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            label_spriteset.Location = new System.Drawing.Point(152, 18);
            label_spriteset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_spriteset.Name = "label_spriteset";
            label_spriteset.Size = new System.Drawing.Size(23, 13);
            label_spriteset.TabIndex = 0;
            label_spriteset.Text = "Set";
            // 
            // label_spritesetPointer
            // 
            label_spritesetPointer.AutoSize = true;
            label_spritesetPointer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point);
            label_spritesetPointer.Location = new System.Drawing.Point(69, 18);
            label_spritesetPointer.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_spritesetPointer.Name = "label_spritesetPointer";
            label_spritesetPointer.Size = new System.Drawing.Size(40, 13);
            label_spritesetPointer.TabIndex = 0;
            label_spritesetPointer.Text = "Pointer";
            // 
            // textBox_defaultPointer
            // 
            textBox_defaultPointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_defaultPointer.DisplayBorder = true;
            textBox_defaultPointer.Location = new System.Drawing.Point(69, 40);
            textBox_defaultPointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_defaultPointer.MaxLength = 32767;
            textBox_defaultPointer.Multiline = false;
            textBox_defaultPointer.Name = "textBox_defaultPointer";
            textBox_defaultPointer.OnTextChanged = null;
            textBox_defaultPointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_defaultPointer.PlaceholderText = "";
            textBox_defaultPointer.ReadOnly = false;
            textBox_defaultPointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_defaultPointer.SelectionStart = 0;
            textBox_defaultPointer.Size = new System.Drawing.Size(76, 23);
            textBox_defaultPointer.TabIndex = 0;
            textBox_defaultPointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_defaultPointer.ValueBox = true;
            textBox_defaultPointer.WordWrap = true;
            textBox_defaultPointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_defaultSpriteset
            // 
            textBox_defaultSpriteset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_defaultSpriteset.DisplayBorder = true;
            textBox_defaultSpriteset.Location = new System.Drawing.Point(152, 40);
            textBox_defaultSpriteset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_defaultSpriteset.MaxLength = 32767;
            textBox_defaultSpriteset.Multiline = false;
            textBox_defaultSpriteset.Name = "textBox_defaultSpriteset";
            textBox_defaultSpriteset.OnTextChanged = null;
            textBox_defaultSpriteset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_defaultSpriteset.PlaceholderText = "";
            textBox_defaultSpriteset.ReadOnly = false;
            textBox_defaultSpriteset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_defaultSpriteset.SelectionStart = 0;
            textBox_defaultSpriteset.Size = new System.Drawing.Size(35, 23);
            textBox_defaultSpriteset.TabIndex = 1;
            textBox_defaultSpriteset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_defaultSpriteset.ValueBox = false;
            textBox_defaultSpriteset.WordWrap = true;
            textBox_defaultSpriteset.TextChanged += textBox_TextChanged;
            // 
            // textBox_secondEvent
            // 
            textBox_secondEvent.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_secondEvent.DisplayBorder = true;
            textBox_secondEvent.Location = new System.Drawing.Point(194, 100);
            textBox_secondEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_secondEvent.MaxLength = 32767;
            textBox_secondEvent.Multiline = false;
            textBox_secondEvent.Name = "textBox_secondEvent";
            textBox_secondEvent.OnTextChanged = null;
            textBox_secondEvent.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_secondEvent.PlaceholderText = "";
            textBox_secondEvent.ReadOnly = false;
            textBox_secondEvent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_secondEvent.SelectionStart = 0;
            textBox_secondEvent.Size = new System.Drawing.Size(35, 23);
            textBox_secondEvent.TabIndex = 7;
            textBox_secondEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_secondEvent.ValueBox = false;
            textBox_secondEvent.WordWrap = true;
            textBox_secondEvent.TextChanged += textBox_TextChanged;
            // 
            // textBox_secondPointer
            // 
            textBox_secondPointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_secondPointer.DisplayBorder = true;
            textBox_secondPointer.Location = new System.Drawing.Point(69, 100);
            textBox_secondPointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_secondPointer.MaxLength = 32767;
            textBox_secondPointer.Multiline = false;
            textBox_secondPointer.Name = "textBox_secondPointer";
            textBox_secondPointer.OnTextChanged = null;
            textBox_secondPointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_secondPointer.PlaceholderText = "";
            textBox_secondPointer.ReadOnly = false;
            textBox_secondPointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_secondPointer.SelectionStart = 0;
            textBox_secondPointer.Size = new System.Drawing.Size(76, 23);
            textBox_secondPointer.TabIndex = 5;
            textBox_secondPointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_secondPointer.ValueBox = true;
            textBox_secondPointer.WordWrap = true;
            textBox_secondPointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_secondSpriteset
            // 
            textBox_secondSpriteset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_secondSpriteset.DisplayBorder = true;
            textBox_secondSpriteset.Location = new System.Drawing.Point(152, 100);
            textBox_secondSpriteset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_secondSpriteset.MaxLength = 32767;
            textBox_secondSpriteset.Multiline = false;
            textBox_secondSpriteset.Name = "textBox_secondSpriteset";
            textBox_secondSpriteset.OnTextChanged = null;
            textBox_secondSpriteset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_secondSpriteset.PlaceholderText = "";
            textBox_secondSpriteset.ReadOnly = false;
            textBox_secondSpriteset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_secondSpriteset.SelectionStart = 0;
            textBox_secondSpriteset.Size = new System.Drawing.Size(35, 23);
            textBox_secondSpriteset.TabIndex = 6;
            textBox_secondSpriteset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_secondSpriteset.ValueBox = false;
            textBox_secondSpriteset.WordWrap = true;
            textBox_secondSpriteset.TextChanged += textBox_TextChanged;
            // 
            // textBox_firstEvent
            // 
            textBox_firstEvent.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_firstEvent.DisplayBorder = true;
            textBox_firstEvent.Location = new System.Drawing.Point(194, 70);
            textBox_firstEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_firstEvent.MaxLength = 32767;
            textBox_firstEvent.Multiline = false;
            textBox_firstEvent.Name = "textBox_firstEvent";
            textBox_firstEvent.OnTextChanged = null;
            textBox_firstEvent.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_firstEvent.PlaceholderText = "";
            textBox_firstEvent.ReadOnly = false;
            textBox_firstEvent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_firstEvent.SelectionStart = 0;
            textBox_firstEvent.Size = new System.Drawing.Size(35, 23);
            textBox_firstEvent.TabIndex = 4;
            textBox_firstEvent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_firstEvent.ValueBox = false;
            textBox_firstEvent.WordWrap = true;
            textBox_firstEvent.TextChanged += textBox_TextChanged;
            // 
            // textBox_firstPointer
            // 
            textBox_firstPointer.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_firstPointer.DisplayBorder = true;
            textBox_firstPointer.Location = new System.Drawing.Point(69, 70);
            textBox_firstPointer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_firstPointer.MaxLength = 32767;
            textBox_firstPointer.Multiline = false;
            textBox_firstPointer.Name = "textBox_firstPointer";
            textBox_firstPointer.OnTextChanged = null;
            textBox_firstPointer.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_firstPointer.PlaceholderText = "";
            textBox_firstPointer.ReadOnly = false;
            textBox_firstPointer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_firstPointer.SelectionStart = 0;
            textBox_firstPointer.Size = new System.Drawing.Size(76, 23);
            textBox_firstPointer.TabIndex = 2;
            textBox_firstPointer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_firstPointer.ValueBox = true;
            textBox_firstPointer.WordWrap = true;
            textBox_firstPointer.TextChanged += textBox_TextChanged;
            // 
            // textBox_firstSpriteset
            // 
            textBox_firstSpriteset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_firstSpriteset.DisplayBorder = true;
            textBox_firstSpriteset.Location = new System.Drawing.Point(152, 70);
            textBox_firstSpriteset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_firstSpriteset.MaxLength = 32767;
            textBox_firstSpriteset.Multiline = false;
            textBox_firstSpriteset.Name = "textBox_firstSpriteset";
            textBox_firstSpriteset.OnTextChanged = null;
            textBox_firstSpriteset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_firstSpriteset.PlaceholderText = "";
            textBox_firstSpriteset.ReadOnly = false;
            textBox_firstSpriteset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_firstSpriteset.SelectionStart = 0;
            textBox_firstSpriteset.Size = new System.Drawing.Size(35, 23);
            textBox_firstSpriteset.TabIndex = 3;
            textBox_firstSpriteset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_firstSpriteset.ValueBox = false;
            textBox_firstSpriteset.WordWrap = true;
            textBox_firstSpriteset.TextChanged += textBox_TextChanged;
            // 
            // groupBox_misc
            // 
            groupBox_misc.Controls.Add(btn_open_map);
            groupBox_misc.Controls.Add(label_music);
            groupBox_misc.Controls.Add(textBox_music);
            groupBox_misc.Controls.Add(label_mapY);
            groupBox_misc.Controls.Add(label_mapX);
            groupBox_misc.Controls.Add(textBox_mapX);
            groupBox_misc.Controls.Add(textBox_mapY);
            groupBox_misc.Location = new System.Drawing.Point(260, 215);
            groupBox_misc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_misc.Name = "groupBox_misc";
            groupBox_misc.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_misc.Size = new System.Drawing.Size(107, 168);
            groupBox_misc.TabIndex = 2;
            groupBox_misc.TabStop = false;
            groupBox_misc.Text = "Miscellaneous";
            // 
            // btn_open_map
            // 
            btn_open_map.Location = new System.Drawing.Point(7, 98);
            btn_open_map.Name = "btn_open_map";
            btn_open_map.Size = new System.Drawing.Size(90, 27);
            btn_open_map.TabIndex = 3;
            btn_open_map.Text = "Open Map";
            btn_open_map.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            btn_open_map.UseVisualStyleBackColor = true;
            btn_open_map.Click += btn_open_map_Click;
            // 
            // label_music
            // 
            label_music.AutoSize = true;
            label_music.Location = new System.Drawing.Point(7, 138);
            label_music.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_music.Name = "label_music";
            label_music.Size = new System.Drawing.Size(42, 15);
            label_music.TabIndex = 0;
            label_music.Text = "Music:";
            // 
            // textBox_music
            // 
            textBox_music.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_music.DisplayBorder = true;
            textBox_music.Location = new System.Drawing.Point(62, 134);
            textBox_music.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_music.MaxLength = 32767;
            textBox_music.Multiline = false;
            textBox_music.Name = "textBox_music";
            textBox_music.OnTextChanged = null;
            textBox_music.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_music.PlaceholderText = "";
            textBox_music.ReadOnly = false;
            textBox_music.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_music.SelectionStart = 0;
            textBox_music.Size = new System.Drawing.Size(35, 23);
            textBox_music.TabIndex = 2;
            textBox_music.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_music.ValueBox = false;
            textBox_music.WordWrap = true;
            textBox_music.TextChanged += textBox_TextChanged;
            // 
            // label_mapY
            // 
            label_mapY.AutoSize = true;
            label_mapY.Location = new System.Drawing.Point(7, 67);
            label_mapY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_mapY.Name = "label_mapY";
            label_mapY.Size = new System.Drawing.Size(44, 15);
            label_mapY.TabIndex = 0;
            label_mapY.Text = "Map Y:";
            // 
            // label_mapX
            // 
            label_mapX.AutoSize = true;
            label_mapX.Location = new System.Drawing.Point(7, 30);
            label_mapX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_mapX.Name = "label_mapX";
            label_mapX.Size = new System.Drawing.Size(44, 15);
            label_mapX.TabIndex = 0;
            label_mapX.Text = "Map X:";
            // 
            // textBox_mapX
            // 
            textBox_mapX.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_mapX.DisplayBorder = true;
            textBox_mapX.Location = new System.Drawing.Point(62, 27);
            textBox_mapX.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_mapX.MaxLength = 32767;
            textBox_mapX.Multiline = false;
            textBox_mapX.Name = "textBox_mapX";
            textBox_mapX.OnTextChanged = null;
            textBox_mapX.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_mapX.PlaceholderText = "";
            textBox_mapX.ReadOnly = false;
            textBox_mapX.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_mapX.SelectionStart = 0;
            textBox_mapX.Size = new System.Drawing.Size(35, 23);
            textBox_mapX.TabIndex = 0;
            textBox_mapX.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_mapX.ValueBox = false;
            textBox_mapX.WordWrap = true;
            textBox_mapX.TextChanged += textBox_TextChanged;
            // 
            // textBox_mapY
            // 
            textBox_mapY.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_mapY.DisplayBorder = true;
            textBox_mapY.Location = new System.Drawing.Point(62, 63);
            textBox_mapY.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_mapY.MaxLength = 32767;
            textBox_mapY.Multiline = false;
            textBox_mapY.Name = "textBox_mapY";
            textBox_mapY.OnTextChanged = null;
            textBox_mapY.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_mapY.PlaceholderText = "";
            textBox_mapY.ReadOnly = false;
            textBox_mapY.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_mapY.SelectionStart = 0;
            textBox_mapY.Size = new System.Drawing.Size(35, 23);
            textBox_mapY.TabIndex = 1;
            textBox_mapY.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_mapY.ValueBox = false;
            textBox_mapY.WordWrap = true;
            textBox_mapY.TextChanged += textBox_TextChanged;
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Location = new System.Drawing.Point(260, 386);
            button_apply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(107, 27);
            button_apply.TabIndex = 5;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // label_room
            // 
            label_room.AutoSize = true;
            label_room.Location = new System.Drawing.Point(20, 421);
            label_room.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_room.Name = "label_room";
            label_room.Size = new System.Drawing.Size(42, 15);
            label_room.TabIndex = 0;
            label_room.Text = "Room:";
            // 
            // label_area
            // 
            label_area.AutoSize = true;
            label_area.Location = new System.Drawing.Point(20, 392);
            label_area.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_area.Name = "label_area";
            label_area.Size = new System.Drawing.Size(34, 15);
            label_area.TabIndex = 0;
            label_area.Text = "Area:";
            // 
            // comboBox_room
            // 
            comboBox_room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_room.FormattingEnabled = true;
            comboBox_room.Location = new System.Drawing.Point(70, 418);
            comboBox_room.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_room.Name = "comboBox_room";
            comboBox_room.Size = new System.Drawing.Size(182, 23);
            comboBox_room.TabIndex = 4;
            comboBox_room.SelectedIndexChanged += comboBox_room_SelectedIndexChanged;
            // 
            // comboBox_area
            // 
            comboBox_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_area.FormattingEnabled = true;
            comboBox_area.Location = new System.Drawing.Point(70, 389);
            comboBox_area.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_area.Name = "comboBox_area";
            comboBox_area.Size = new System.Drawing.Size(182, 23);
            comboBox_area.TabIndex = 3;
            comboBox_area.SelectedIndexChanged += comboBox_area_SelectedIndexChanged;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_changes, lbl_spring, lbl_offset });
            statusStrip.Location = new System.Drawing.Point(0, 451);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(382, 22);
            statusStrip.TabIndex = 7;
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 17);
            statusLabel_changes.Text = "-";
            // 
            // lbl_spring
            // 
            lbl_spring.Name = "lbl_spring";
            lbl_spring.Size = new System.Drawing.Size(311, 17);
            lbl_spring.Spring = true;
            // 
            // lbl_offset
            // 
            lbl_offset.Name = "lbl_offset";
            lbl_offset.Size = new System.Drawing.Size(42, 17);
            lbl_offset.Text = "Offset:";
            // 
            // button_close
            // 
            button_close.Location = new System.Drawing.Point(260, 415);
            button_close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_close.Name = "button_close";
            button_close.Size = new System.Drawing.Size(107, 27);
            button_close.TabIndex = 6;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // FormHeader
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(382, 473);
            Controls.Add(statusStrip);
            Controls.Add(label_room);
            Controls.Add(label_area);
            Controls.Add(comboBox_room);
            Controls.Add(comboBox_area);
            Controls.Add(button_close);
            Controls.Add(button_apply);
            Controls.Add(groupBox_misc);
            Controls.Add(groupBox_spritesetData);
            Controls.Add(groupBox_BGdata);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormHeader";
            Text = "Header Editor";
            groupBox_BGdata.ResumeLayout(false);
            groupBox_BGdata.PerformLayout();
            groupBox_spritesetData.ResumeLayout(false);
            groupBox_spritesetData.PerformLayout();
            groupBox_misc.ResumeLayout(false);
            groupBox_misc.PerformLayout();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private mage.Theming.CustomControls.FlatTextBox textBox_tileset;
        private System.Windows.Forms.Label label_tileset;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG0pointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG1pointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG2pointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG3pointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_CLPpointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG0prop;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG1prop;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG2prop;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG3prop;
        private System.Windows.Forms.Label label_BG0;
        private System.Windows.Forms.Label label_BG1;
        private System.Windows.Forms.Label label_BG2;
        private System.Windows.Forms.Label label_BG3;
        private System.Windows.Forms.Label label_CLP;
        private System.Windows.Forms.Label label_BGpointer;
        private System.Windows.Forms.Label label_prop;
        private mage.Theming.CustomControls.FlatTextBox textBox_BG3scroll;
        private mage.Theming.CustomControls.FlatTextBox textBox_transparency;
        private System.Windows.Forms.Label label_BG3scroll;
        private System.Windows.Forms.Label label_transparency;
        private System.Windows.Forms.GroupBox groupBox_BGdata;
        private System.Windows.Forms.GroupBox groupBox_spritesetData;
        private System.Windows.Forms.Label label_spritesetPointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_defaultPointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_defaultSpriteset;
        private mage.Theming.CustomControls.FlatTextBox textBox_secondEvent;
        private mage.Theming.CustomControls.FlatTextBox textBox_secondPointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_secondSpriteset;
        private mage.Theming.CustomControls.FlatTextBox textBox_firstEvent;
        private mage.Theming.CustomControls.FlatTextBox textBox_firstPointer;
        private mage.Theming.CustomControls.FlatTextBox textBox_firstSpriteset;
        private mage.Theming.CustomControls.FlatTextBox textBox_effectYpos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_effect;
        private mage.Theming.CustomControls.FlatTextBox textBox_effect;
        private System.Windows.Forms.Label label_second;
        private System.Windows.Forms.Label label_first;
        private System.Windows.Forms.Label label_default;
        private System.Windows.Forms.Label label_event;
        private System.Windows.Forms.Label label_spriteset;
        private System.Windows.Forms.GroupBox groupBox_misc;
        private System.Windows.Forms.Label label_music;
        private mage.Theming.CustomControls.FlatTextBox textBox_music;
        private System.Windows.Forms.Label label_mapY;
        private System.Windows.Forms.Label label_mapX;
        private mage.Theming.CustomControls.FlatTextBox textBox_mapX;
        private mage.Theming.CustomControls.FlatTextBox textBox_mapY;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Label label_room;
        private System.Windows.Forms.Label label_area;
        private mage.Theming.CustomControls.FlatComboBox comboBox_room;
        private mage.Theming.CustomControls.FlatComboBox comboBox_area;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.ToolStripStatusLabel lbl_spring;
        private System.Windows.Forms.ToolStripStatusLabel lbl_offset;
        private System.Windows.Forms.Button btn_open_map;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Button btn_bg3_presets;
        private System.Windows.Forms.Button btn_bg2_prop;
        private System.Windows.Forms.Button btn_bg3_prop;
        private System.Windows.Forms.Button btn_bg0_prop;
        private System.Windows.Forms.Button btn_bg1_prop;
        private System.Windows.Forms.Button btn_tileset_preset;
    }
}