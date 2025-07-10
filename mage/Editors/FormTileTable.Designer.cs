namespace mage
{
    partial class FormTileTable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTileTable));
            button_apply = new System.Windows.Forms.Button();
            button_close = new System.Windows.Forms.Button();
            comboBox_bg = new Theming.CustomControls.FlatComboBox();
            label_tileset = new System.Windows.Forms.Label();
            comboBox_tileset = new Theming.CustomControls.FlatComboBox();
            label_size = new System.Windows.Forms.Label();
            comboBox_room = new Theming.CustomControls.FlatComboBox();
            comboBox_area = new Theming.CustomControls.FlatComboBox();
            panel_result = new System.Windows.Forms.Panel();
            gfxView_result = new GfxView();
            panel_gfx = new System.Windows.Forms.Panel();
            gfxView_gfx = new GfxView();
            button_hflipTL = new System.Windows.Forms.Button();
            button_hflipTR = new System.Windows.Forms.Button();
            button_hflipBR = new System.Windows.Forms.Button();
            button_hflipBL = new System.Windows.Forms.Button();
            button_vflipTR = new System.Windows.Forms.Button();
            button_vflipBR = new System.Windows.Forms.Button();
            button_vflipBL = new System.Windows.Forms.Button();
            button_vflipTL = new System.Windows.Forms.Button();
            button_palTR = new System.Windows.Forms.Button();
            button_palTL = new System.Windows.Forms.Button();
            button_palBL = new System.Windows.Forms.Button();
            button_palBR = new System.Windows.Forms.Button();
            tabControl = new Theming.CustomControls.FlatTabControl();
            tabPage_tileset = new System.Windows.Forms.TabPage();
            button_flip_v = new System.Windows.Forms.Button();
            button_flip_h = new System.Windows.Forms.Button();
            label_height = new System.Windows.Forms.Label();
            numericUpDown_height = new Theming.CustomControls.FlatNumericUpDown();
            tabPage_background = new System.Windows.Forms.TabPage();
            label_bg = new System.Windows.Forms.Label();
            label_room = new System.Windows.Forms.Label();
            label_area = new System.Windows.Forms.Label();
            comboBox_size = new Theming.CustomControls.FlatComboBox();
            tabPage_offset = new System.Windows.Forms.TabPage();
            label_shift = new System.Windows.Forms.Label();
            numericUpDown_shift = new Theming.CustomControls.FlatNumericUpDown();
            button_go = new System.Windows.Forms.Button();
            textBox_pal = new Theming.CustomControls.FlatTextBox();
            textBox_gfx = new Theming.CustomControls.FlatTextBox();
            textBox_ttb = new Theming.CustomControls.FlatTextBox();
            label_palette = new System.Windows.Forms.Label();
            label_graphics = new System.Windows.Forms.Label();
            label_tileTable = new System.Windows.Forms.Label();
            label_pal = new System.Windows.Forms.Label();
            comboBox_palette = new Theming.CustomControls.FlatComboBox();
            checkBox_copyPalette = new System.Windows.Forms.CheckBox();
            label_tileTL = new System.Windows.Forms.Label();
            label_tileBL = new System.Windows.Forms.Label();
            label_tileTR = new System.Windows.Forms.Label();
            label_tileBR = new System.Windows.Forms.Label();
            panel_text = new System.Windows.Forms.Panel();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_tile = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_spring = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_import = new System.Windows.Forms.ToolStripDropDownButton();
            statusStrip_importTileTable = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_export = new System.Windows.Forms.ToolStripDropDownButton();
            statusStrip_exportTileTable = new System.Windows.Forms.ToolStripMenuItem();
            checkBox_preserveData = new System.Windows.Forms.CheckBox();
            gfxView_tile = new GfxView();
            panel_result.SuspendLayout();
            panel_gfx.SuspendLayout();
            tabControl.SuspendLayout();
            tabPage_tileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).BeginInit();
            tabPage_background.SuspendLayout();
            tabPage_offset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_shift).BeginInit();
            panel_text.SuspendLayout();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Location = new System.Drawing.Point(264, 69);
            button_apply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(82, 27);
            button_apply.TabIndex = 2;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // button_close
            // 
            button_close.Location = new System.Drawing.Point(264, 103);
            button_close.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_close.Name = "button_close";
            button_close.Size = new System.Drawing.Size(82, 27);
            button_close.TabIndex = 3;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            // 
            // comboBox_bg
            // 
            comboBox_bg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_bg.FormattingEnabled = true;
            comboBox_bg.Items.AddRange(new object[] { "BG0", "BG3" });
            comboBox_bg.Location = new System.Drawing.Point(166, 22);
            comboBox_bg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_bg.Name = "comboBox_bg";
            comboBox_bg.Size = new System.Drawing.Size(52, 23);
            comboBox_bg.TabIndex = 8;
            comboBox_bg.SelectedIndexChanged += comboBox_bg_SelectedIndexChanged;
            // 
            // label_tileset
            // 
            label_tileset.AutoSize = true;
            label_tileset.Location = new System.Drawing.Point(7, 16);
            label_tileset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileset.Name = "label_tileset";
            label_tileset.Size = new System.Drawing.Size(43, 15);
            label_tileset.TabIndex = 6;
            label_tileset.Text = "Tileset:";
            // 
            // comboBox_tileset
            // 
            comboBox_tileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_tileset.FormattingEnabled = true;
            comboBox_tileset.Location = new System.Drawing.Point(62, 13);
            comboBox_tileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_tileset.Name = "comboBox_tileset";
            comboBox_tileset.Size = new System.Drawing.Size(52, 23);
            comboBox_tileset.TabIndex = 7;
            comboBox_tileset.SelectedIndexChanged += comboBox_tileset_SelectedIndexChanged;
            // 
            // label_size
            // 
            label_size.AutoSize = true;
            label_size.Location = new System.Drawing.Point(7, 58);
            label_size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_size.Name = "label_size";
            label_size.Size = new System.Drawing.Size(30, 15);
            label_size.TabIndex = 0;
            label_size.Text = "Size:";
            // 
            // comboBox_room
            // 
            comboBox_room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_room.FormattingEnabled = true;
            comboBox_room.Location = new System.Drawing.Point(106, 22);
            comboBox_room.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_room.Name = "comboBox_room";
            comboBox_room.Size = new System.Drawing.Size(52, 23);
            comboBox_room.TabIndex = 1;
            comboBox_room.SelectedIndexChanged += comboBox_bg_SelectedIndexChanged;
            // 
            // comboBox_area
            // 
            comboBox_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_area.FormattingEnabled = true;
            comboBox_area.Location = new System.Drawing.Point(9, 22);
            comboBox_area.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_area.Name = "comboBox_area";
            comboBox_area.Size = new System.Drawing.Size(89, 23);
            comboBox_area.TabIndex = 0;
            comboBox_area.SelectedIndexChanged += comboBox_area_SelectedIndexChanged;
            // 
            // panel_result
            // 
            panel_result.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel_result.AutoScroll = true;
            panel_result.Controls.Add(gfxView_result);
            panel_result.Location = new System.Drawing.Point(574, 14);
            panel_result.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_result.Name = "panel_result";
            panel_result.Size = new System.Drawing.Size(273, 468);
            panel_result.TabIndex = 9;
            // 
            // gfxView_result
            // 
            gfxView_result.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_result.Location = new System.Drawing.Point(0, 0);
            gfxView_result.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_result.Name = "gfxView_result";
            gfxView_result.Size = new System.Drawing.Size(252, 449);
            gfxView_result.TabIndex = 0;
            gfxView_result.TabStop = false;
            gfxView_result.MouseDown += gfxView_result_MouseDown;
            gfxView_result.MouseMove += gfxView_result_MouseMove;
            // 
            // panel_gfx
            // 
            panel_gfx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            panel_gfx.AutoScroll = true;
            panel_gfx.Controls.Add(gfxView_gfx);
            panel_gfx.Location = new System.Drawing.Point(14, 167);
            panel_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_gfx.Name = "panel_gfx";
            panel_gfx.Size = new System.Drawing.Size(530, 315);
            panel_gfx.TabIndex = 10;
            // 
            // gfxView_gfx
            // 
            gfxView_gfx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_gfx.Location = new System.Drawing.Point(0, 0);
            gfxView_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_gfx.Name = "gfxView_gfx";
            gfxView_gfx.Size = new System.Drawing.Size(506, 295);
            gfxView_gfx.TabIndex = 0;
            gfxView_gfx.TabStop = false;
            gfxView_gfx.MouseDown += gfxView_gfx_MouseDown;
            gfxView_gfx.MouseMove += gfxView_gfx_MouseMove;
            // 
            // button_hflipTL
            // 
            button_hflipTL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_hflipTL.Location = new System.Drawing.Point(414, 16);
            button_hflipTL.Margin = new System.Windows.Forms.Padding(0);
            button_hflipTL.Name = "button_hflipTL";
            button_hflipTL.Size = new System.Drawing.Size(47, 23);
            button_hflipTL.TabIndex = 12;
            button_hflipTL.UseVisualStyleBackColor = true;
            button_hflipTL.Click += button_hflip_Click;
            // 
            // button_hflipTR
            // 
            button_hflipTR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_hflipTR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button_hflipTR.Location = new System.Drawing.Point(461, 16);
            button_hflipTR.Margin = new System.Windows.Forms.Padding(0);
            button_hflipTR.Name = "button_hflipTR";
            button_hflipTR.Size = new System.Drawing.Size(47, 23);
            button_hflipTR.TabIndex = 13;
            button_hflipTR.UseVisualStyleBackColor = true;
            button_hflipTR.Click += button_hflip_Click;
            // 
            // button_hflipBR
            // 
            button_hflipBR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_hflipBR.Location = new System.Drawing.Point(461, 131);
            button_hflipBR.Margin = new System.Windows.Forms.Padding(0);
            button_hflipBR.Name = "button_hflipBR";
            button_hflipBR.Size = new System.Drawing.Size(47, 23);
            button_hflipBR.TabIndex = 15;
            button_hflipBR.UseVisualStyleBackColor = true;
            button_hflipBR.Click += button_hflip_Click;
            // 
            // button_hflipBL
            // 
            button_hflipBL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_hflipBL.Location = new System.Drawing.Point(414, 131);
            button_hflipBL.Margin = new System.Windows.Forms.Padding(0);
            button_hflipBL.Name = "button_hflipBL";
            button_hflipBL.Size = new System.Drawing.Size(47, 23);
            button_hflipBL.TabIndex = 14;
            button_hflipBL.UseVisualStyleBackColor = true;
            button_hflipBL.Click += button_hflip_Click;
            // 
            // button_vflipTR
            // 
            button_vflipTR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_vflipTR.Location = new System.Drawing.Point(508, 39);
            button_vflipTR.Margin = new System.Windows.Forms.Padding(0);
            button_vflipTR.Name = "button_vflipTR";
            button_vflipTR.Size = new System.Drawing.Size(23, 46);
            button_vflipTR.TabIndex = 16;
            button_vflipTR.UseVisualStyleBackColor = true;
            button_vflipTR.Click += button_vflip_Click;
            // 
            // button_vflipBR
            // 
            button_vflipBR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_vflipBR.Location = new System.Drawing.Point(508, 85);
            button_vflipBR.Margin = new System.Windows.Forms.Padding(0);
            button_vflipBR.Name = "button_vflipBR";
            button_vflipBR.Size = new System.Drawing.Size(23, 46);
            button_vflipBR.TabIndex = 17;
            button_vflipBR.UseVisualStyleBackColor = true;
            button_vflipBR.Click += button_vflip_Click;
            // 
            // button_vflipBL
            // 
            button_vflipBL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_vflipBL.Location = new System.Drawing.Point(391, 85);
            button_vflipBL.Margin = new System.Windows.Forms.Padding(0);
            button_vflipBL.Name = "button_vflipBL";
            button_vflipBL.Size = new System.Drawing.Size(23, 46);
            button_vflipBL.TabIndex = 19;
            button_vflipBL.UseVisualStyleBackColor = true;
            button_vflipBL.Click += button_vflip_Click;
            // 
            // button_vflipTL
            // 
            button_vflipTL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_vflipTL.Location = new System.Drawing.Point(391, 39);
            button_vflipTL.Margin = new System.Windows.Forms.Padding(0);
            button_vflipTL.Name = "button_vflipTL";
            button_vflipTL.Size = new System.Drawing.Size(23, 46);
            button_vflipTL.TabIndex = 18;
            button_vflipTL.UseVisualStyleBackColor = true;
            button_vflipTL.Click += button_vflip_Click;
            // 
            // button_palTR
            // 
            button_palTR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_palTR.Location = new System.Drawing.Point(508, 16);
            button_palTR.Margin = new System.Windows.Forms.Padding(0);
            button_palTR.Name = "button_palTR";
            button_palTR.Size = new System.Drawing.Size(23, 23);
            button_palTR.TabIndex = 20;
            button_palTR.UseVisualStyleBackColor = true;
            button_palTR.MouseUp += button_pal_MouseUp;
            // 
            // button_palTL
            // 
            button_palTL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_palTL.Location = new System.Drawing.Point(391, 16);
            button_palTL.Margin = new System.Windows.Forms.Padding(0);
            button_palTL.Name = "button_palTL";
            button_palTL.Size = new System.Drawing.Size(23, 23);
            button_palTL.TabIndex = 21;
            button_palTL.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            button_palTL.UseVisualStyleBackColor = true;
            button_palTL.MouseUp += button_pal_MouseUp;
            // 
            // button_palBL
            // 
            button_palBL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_palBL.Location = new System.Drawing.Point(391, 131);
            button_palBL.Margin = new System.Windows.Forms.Padding(0);
            button_palBL.Name = "button_palBL";
            button_palBL.Size = new System.Drawing.Size(23, 23);
            button_palBL.TabIndex = 22;
            button_palBL.UseVisualStyleBackColor = true;
            button_palBL.MouseUp += button_pal_MouseUp;
            // 
            // button_palBR
            // 
            button_palBR.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            button_palBR.Location = new System.Drawing.Point(508, 131);
            button_palBR.Margin = new System.Windows.Forms.Padding(0);
            button_palBR.Name = "button_palBR";
            button_palBR.Size = new System.Drawing.Size(23, 23);
            button_palBR.TabIndex = 23;
            button_palBR.UseVisualStyleBackColor = true;
            button_palBR.MouseUp += button_pal_MouseUp;
            // 
            // tabControl
            // 
            tabControl.BorderColor = System.Drawing.Color.Empty;
            tabControl.Controls.Add(tabPage_tileset);
            tabControl.Controls.Add(tabPage_background);
            tabControl.Controls.Add(tabPage_offset);
            tabControl.Location = new System.Drawing.Point(14, 14);
            tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(243, 115);
            tabControl.TabIndex = 24;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabPage_tileset
            // 
            tabPage_tileset.BackColor = System.Drawing.SystemColors.Control;
            tabPage_tileset.Controls.Add(button_flip_v);
            tabPage_tileset.Controls.Add(button_flip_h);
            tabPage_tileset.Controls.Add(label_height);
            tabPage_tileset.Controls.Add(numericUpDown_height);
            tabPage_tileset.Controls.Add(comboBox_tileset);
            tabPage_tileset.Controls.Add(label_tileset);
            tabPage_tileset.Location = new System.Drawing.Point(4, 25);
            tabPage_tileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_tileset.Name = "tabPage_tileset";
            tabPage_tileset.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_tileset.Size = new System.Drawing.Size(235, 86);
            tabPage_tileset.TabIndex = 1;
            tabPage_tileset.Text = "Tileset";
            // 
            // button_flip_v
            // 
            button_flip_v.Location = new System.Drawing.Point(128, 46);
            button_flip_v.Name = "button_flip_v";
            button_flip_v.Size = new System.Drawing.Size(75, 23);
            button_flip_v.TabIndex = 11;
            button_flip_v.Text = "Flip V";
            button_flip_v.UseVisualStyleBackColor = true;
            button_flip_v.Click += button_flip_v_Click;
            // 
            // button_flip_h
            // 
            button_flip_h.Location = new System.Drawing.Point(128, 12);
            button_flip_h.Name = "button_flip_h";
            button_flip_h.Size = new System.Drawing.Size(75, 23);
            button_flip_h.TabIndex = 10;
            button_flip_h.Text = "Flip H";
            button_flip_h.UseVisualStyleBackColor = true;
            button_flip_h.Click += button_flip_h_Click;
            // 
            // label_height
            // 
            label_height.AutoSize = true;
            label_height.Location = new System.Drawing.Point(7, 48);
            label_height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_height.Name = "label_height";
            label_height.Size = new System.Drawing.Size(46, 15);
            label_height.TabIndex = 9;
            label_height.Text = "Height:";
            // 
            // numericUpDown_height
            // 
            numericUpDown_height.Enabled = false;
            numericUpDown_height.Hexadecimal = true;
            numericUpDown_height.Location = new System.Drawing.Point(62, 46);
            numericUpDown_height.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_height.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numericUpDown_height.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown_height.Name = "numericUpDown_height";
            numericUpDown_height.Size = new System.Drawing.Size(52, 23);
            numericUpDown_height.TabIndex = 8;
            numericUpDown_height.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown_height.ValueChanged += numericUpDown_height_ValueChanged;
            // 
            // tabPage_background
            // 
            tabPage_background.BackColor = System.Drawing.SystemColors.Control;
            tabPage_background.Controls.Add(label_bg);
            tabPage_background.Controls.Add(label_room);
            tabPage_background.Controls.Add(label_area);
            tabPage_background.Controls.Add(comboBox_size);
            tabPage_background.Controls.Add(comboBox_bg);
            tabPage_background.Controls.Add(comboBox_area);
            tabPage_background.Controls.Add(comboBox_room);
            tabPage_background.Controls.Add(label_size);
            tabPage_background.Location = new System.Drawing.Point(4, 25);
            tabPage_background.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_background.Name = "tabPage_background";
            tabPage_background.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_background.Size = new System.Drawing.Size(235, 86);
            tabPage_background.TabIndex = 0;
            tabPage_background.Text = "Background";
            // 
            // label_bg
            // 
            label_bg.AutoSize = true;
            label_bg.Location = new System.Drawing.Point(162, 3);
            label_bg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_bg.Name = "label_bg";
            label_bg.Size = new System.Drawing.Size(25, 15);
            label_bg.TabIndex = 12;
            label_bg.Text = "BG:";
            // 
            // label_room
            // 
            label_room.AutoSize = true;
            label_room.Location = new System.Drawing.Point(103, 3);
            label_room.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_room.Name = "label_room";
            label_room.Size = new System.Drawing.Size(42, 15);
            label_room.TabIndex = 11;
            label_room.Text = "Room:";
            // 
            // label_area
            // 
            label_area.AutoSize = true;
            label_area.Location = new System.Drawing.Point(6, 3);
            label_area.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_area.Name = "label_area";
            label_area.Size = new System.Drawing.Size(34, 15);
            label_area.TabIndex = 10;
            label_area.Text = "Area:";
            // 
            // comboBox_size
            // 
            comboBox_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_size.Enabled = false;
            comboBox_size.FormattingEnabled = true;
            comboBox_size.Items.AddRange(new object[] { "256 x 256", "512 x 256", "256 x 512" });
            comboBox_size.Location = new System.Drawing.Point(49, 53);
            comboBox_size.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_size.Name = "comboBox_size";
            comboBox_size.Size = new System.Drawing.Size(87, 23);
            comboBox_size.TabIndex = 9;
            comboBox_size.SelectedIndexChanged += comboBox_size_SelectedIndexChanged;
            // 
            // tabPage_offset
            // 
            tabPage_offset.BackColor = System.Drawing.SystemColors.Control;
            tabPage_offset.Controls.Add(label_shift);
            tabPage_offset.Controls.Add(numericUpDown_shift);
            tabPage_offset.Controls.Add(button_go);
            tabPage_offset.Controls.Add(textBox_pal);
            tabPage_offset.Controls.Add(textBox_gfx);
            tabPage_offset.Controls.Add(textBox_ttb);
            tabPage_offset.Controls.Add(label_palette);
            tabPage_offset.Controls.Add(label_graphics);
            tabPage_offset.Controls.Add(label_tileTable);
            tabPage_offset.Location = new System.Drawing.Point(4, 25);
            tabPage_offset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_offset.Name = "tabPage_offset";
            tabPage_offset.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_offset.Size = new System.Drawing.Size(235, 86);
            tabPage_offset.TabIndex = 2;
            tabPage_offset.Text = "Offset";
            // 
            // label_shift
            // 
            label_shift.AutoSize = true;
            label_shift.Location = new System.Drawing.Point(7, 55);
            label_shift.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_shift.Name = "label_shift";
            label_shift.Size = new System.Drawing.Size(34, 15);
            label_shift.TabIndex = 10;
            label_shift.Text = "Shift:";
            // 
            // numericUpDown_shift
            // 
            numericUpDown_shift.Hexadecimal = true;
            numericUpDown_shift.Location = new System.Drawing.Point(50, 53);
            numericUpDown_shift.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_shift.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            numericUpDown_shift.Name = "numericUpDown_shift";
            numericUpDown_shift.Size = new System.Drawing.Size(52, 23);
            numericUpDown_shift.TabIndex = 9;
            // 
            // button_go
            // 
            button_go.Location = new System.Drawing.Point(136, 52);
            button_go.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_go.Name = "button_go";
            button_go.Size = new System.Drawing.Size(88, 27);
            button_go.TabIndex = 6;
            button_go.Text = "Go";
            button_go.UseVisualStyleBackColor = true;
            button_go.Click += button_go_Click;
            // 
            // textBox_pal
            // 
            textBox_pal.BorderColor = System.Drawing.Color.Black;
            textBox_pal.DisplayBorder = true;
            textBox_pal.Location = new System.Drawing.Point(156, 22);
            textBox_pal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_pal.MaxLength = 32767;
            textBox_pal.Multiline = false;
            textBox_pal.Name = "textBox_pal";
            textBox_pal.OnTextChanged = null;
            textBox_pal.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_pal.PlaceholderText = "";
            textBox_pal.ReadOnly = false;
            textBox_pal.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_pal.SelectionStart = 0;
            textBox_pal.Size = new System.Drawing.Size(68, 23);
            textBox_pal.TabIndex = 5;
            textBox_pal.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_pal.ValueBox = true;
            textBox_pal.WordWrap = true;
            // 
            // textBox_gfx
            // 
            textBox_gfx.BorderColor = System.Drawing.Color.Black;
            textBox_gfx.DisplayBorder = true;
            textBox_gfx.Location = new System.Drawing.Point(82, 22);
            textBox_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_gfx.MaxLength = 32767;
            textBox_gfx.Multiline = false;
            textBox_gfx.Name = "textBox_gfx";
            textBox_gfx.OnTextChanged = null;
            textBox_gfx.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_gfx.PlaceholderText = "";
            textBox_gfx.ReadOnly = false;
            textBox_gfx.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_gfx.SelectionStart = 0;
            textBox_gfx.Size = new System.Drawing.Size(68, 23);
            textBox_gfx.TabIndex = 4;
            textBox_gfx.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_gfx.ValueBox = true;
            textBox_gfx.WordWrap = true;
            // 
            // textBox_ttb
            // 
            textBox_ttb.BorderColor = System.Drawing.Color.Black;
            textBox_ttb.DisplayBorder = true;
            textBox_ttb.Location = new System.Drawing.Point(7, 22);
            textBox_ttb.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_ttb.MaxLength = 32767;
            textBox_ttb.Multiline = false;
            textBox_ttb.Name = "textBox_ttb";
            textBox_ttb.OnTextChanged = null;
            textBox_ttb.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_ttb.PlaceholderText = "";
            textBox_ttb.ReadOnly = false;
            textBox_ttb.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_ttb.SelectionStart = 0;
            textBox_ttb.Size = new System.Drawing.Size(68, 23);
            textBox_ttb.TabIndex = 3;
            textBox_ttb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_ttb.ValueBox = true;
            textBox_ttb.WordWrap = true;
            // 
            // label_palette
            // 
            label_palette.AutoSize = true;
            label_palette.Location = new System.Drawing.Point(153, 3);
            label_palette.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_palette.Name = "label_palette";
            label_palette.Size = new System.Drawing.Size(46, 15);
            label_palette.TabIndex = 2;
            label_palette.Text = "Palette:";
            // 
            // label_graphics
            // 
            label_graphics.AutoSize = true;
            label_graphics.Location = new System.Drawing.Point(78, 3);
            label_graphics.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_graphics.Name = "label_graphics";
            label_graphics.Size = new System.Drawing.Size(56, 15);
            label_graphics.TabIndex = 1;
            label_graphics.Text = "Graphics:";
            // 
            // label_tileTable
            // 
            label_tileTable.AutoSize = true;
            label_tileTable.Location = new System.Drawing.Point(4, 3);
            label_tileTable.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileTable.Name = "label_tileTable";
            label_tileTable.Size = new System.Drawing.Size(57, 15);
            label_tileTable.TabIndex = 0;
            label_tileTable.Text = "Tile table:";
            // 
            // label_pal
            // 
            label_pal.AutoSize = true;
            label_pal.Location = new System.Drawing.Point(15, 140);
            label_pal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_pal.Name = "label_pal";
            label_pal.Size = new System.Drawing.Size(46, 15);
            label_pal.TabIndex = 26;
            label_pal.Text = "Palette:";
            // 
            // comboBox_palette
            // 
            comboBox_palette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_palette.Enabled = false;
            comboBox_palette.FormattingEnabled = true;
            comboBox_palette.Location = new System.Drawing.Point(72, 136);
            comboBox_palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_palette.Name = "comboBox_palette";
            comboBox_palette.Size = new System.Drawing.Size(46, 23);
            comboBox_palette.TabIndex = 27;
            comboBox_palette.SelectedIndexChanged += comboBox_palette_SelectedIndexChanged;
            // 
            // checkBox_copyPalette
            // 
            checkBox_copyPalette.AutoSize = true;
            checkBox_copyPalette.Location = new System.Drawing.Point(146, 138);
            checkBox_copyPalette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_copyPalette.Name = "checkBox_copyPalette";
            checkBox_copyPalette.Size = new System.Drawing.Size(103, 19);
            checkBox_copyPalette.TabIndex = 28;
            checkBox_copyPalette.Text = "Copy palette #";
            checkBox_copyPalette.UseVisualStyleBackColor = true;
            // 
            // label_tileTL
            // 
            label_tileTL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label_tileTL.Location = new System.Drawing.Point(-16, 16);
            label_tileTL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileTL.Name = "label_tileTL";
            label_tileTL.Size = new System.Drawing.Size(35, 15);
            label_tileTL.TabIndex = 29;
            label_tileTL.Text = "–";
            label_tileTL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_tileBL
            // 
            label_tileBL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            label_tileBL.Location = new System.Drawing.Point(-16, 62);
            label_tileBL.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileBL.Name = "label_tileBL";
            label_tileBL.Size = new System.Drawing.Size(35, 15);
            label_tileBL.TabIndex = 30;
            label_tileBL.Text = "–";
            label_tileBL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label_tileTR
            // 
            label_tileTR.AutoSize = true;
            label_tileTR.Location = new System.Drawing.Point(539, 55);
            label_tileTR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileTR.Name = "label_tileTR";
            label_tileTR.Size = new System.Drawing.Size(13, 15);
            label_tileTR.TabIndex = 31;
            label_tileTR.Text = "–";
            // 
            // label_tileBR
            // 
            label_tileBR.AutoSize = true;
            label_tileBR.Location = new System.Drawing.Point(539, 101);
            label_tileBR.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileBR.Name = "label_tileBR";
            label_tileBR.Size = new System.Drawing.Size(13, 15);
            label_tileBR.TabIndex = 32;
            label_tileBR.Text = "–";
            // 
            // panel_text
            // 
            panel_text.Controls.Add(label_tileTL);
            panel_text.Controls.Add(label_tileBL);
            panel_text.Location = new System.Drawing.Point(365, 39);
            panel_text.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_text.Name = "panel_text";
            panel_text.Size = new System.Drawing.Size(23, 92);
            panel_text.TabIndex = 33;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_tile, statusLabel_changes, statusStrip_spring, statusStrip_import, statusStrip_export });
            statusStrip.Location = new System.Drawing.Point(0, 487);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(852, 24);
            statusStrip.TabIndex = 34;
            // 
            // statusLabel_tile
            // 
            statusLabel_tile.AutoSize = false;
            statusLabel_tile.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            statusLabel_tile.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            statusLabel_tile.Name = "statusLabel_tile";
            statusLabel_tile.Size = new System.Drawing.Size(80, 19);
            statusLabel_tile.Text = "Tile:";
            statusLabel_tile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 19);
            statusLabel_changes.Text = "-";
            // 
            // statusStrip_spring
            // 
            statusStrip_spring.Name = "statusStrip_spring";
            statusStrip_spring.Size = new System.Drawing.Size(633, 19);
            statusStrip_spring.Spring = true;
            // 
            // statusStrip_import
            // 
            statusStrip_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusStrip_import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { statusStrip_importTileTable });
            statusStrip_import.Name = "statusStrip_import";
            statusStrip_import.Size = new System.Drawing.Size(56, 22);
            statusStrip_import.Text = "Import";
            // 
            // statusStrip_importTileTable
            // 
            statusStrip_importTileTable.Name = "statusStrip_importTileTable";
            statusStrip_importTileTable.Size = new System.Drawing.Size(131, 22);
            statusStrip_importTileTable.Text = "Tile Table...";
            statusStrip_importTileTable.Click += statusStrip_importTileTable_Click;
            // 
            // statusStrip_export
            // 
            statusStrip_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusStrip_export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { statusStrip_exportTileTable });
            statusStrip_export.Name = "statusStrip_export";
            statusStrip_export.Size = new System.Drawing.Size(54, 22);
            statusStrip_export.Text = "Export";
            // 
            // statusStrip_exportTileTable
            // 
            statusStrip_exportTileTable.Name = "statusStrip_exportTileTable";
            statusStrip_exportTileTable.Size = new System.Drawing.Size(131, 22);
            statusStrip_exportTileTable.Text = "Tile Table...";
            statusStrip_exportTileTable.Click += statusStrip_exportTileTable_Click;
            // 
            // checkBox_preserveData
            // 
            checkBox_preserveData.AutoSize = true;
            checkBox_preserveData.Location = new System.Drawing.Point(264, 28);
            checkBox_preserveData.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_preserveData.Name = "checkBox_preserveData";
            checkBox_preserveData.Size = new System.Drawing.Size(93, 34);
            checkBox_preserveData.TabIndex = 35;
            checkBox_preserveData.Text = "Preserve\r\nexisting data";
            checkBox_preserveData.UseVisualStyleBackColor = true;
            // 
            // gfxView_tile
            // 
            gfxView_tile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_tile.Location = new System.Drawing.Point(414, 39);
            gfxView_tile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_tile.Name = "gfxView_tile";
            gfxView_tile.Size = new System.Drawing.Size(93, 92);
            gfxView_tile.TabIndex = 25;
            gfxView_tile.TabStop = false;
            gfxView_tile.MouseDown += gfxView_tile_MouseDown;
            // 
            // FormTileTable
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(852, 511);
            Controls.Add(checkBox_preserveData);
            Controls.Add(statusStrip);
            Controls.Add(panel_text);
            Controls.Add(label_tileBR);
            Controls.Add(label_tileTR);
            Controls.Add(checkBox_copyPalette);
            Controls.Add(comboBox_palette);
            Controls.Add(label_pal);
            Controls.Add(gfxView_tile);
            Controls.Add(tabControl);
            Controls.Add(button_palBR);
            Controls.Add(button_palBL);
            Controls.Add(button_close);
            Controls.Add(button_palTL);
            Controls.Add(button_palTR);
            Controls.Add(button_apply);
            Controls.Add(button_vflipBL);
            Controls.Add(button_vflipTL);
            Controls.Add(button_vflipBR);
            Controls.Add(button_vflipTR);
            Controls.Add(button_hflipBR);
            Controls.Add(button_hflipBL);
            Controls.Add(button_hflipTR);
            Controls.Add(button_hflipTL);
            Controls.Add(panel_gfx);
            Controls.Add(panel_result);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(868, 550);
            Name = "FormTileTable";
            Text = "Tile Table Editor";
            panel_result.ResumeLayout(false);
            panel_gfx.ResumeLayout(false);
            tabControl.ResumeLayout(false);
            tabPage_tileset.ResumeLayout(false);
            tabPage_tileset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).EndInit();
            tabPage_background.ResumeLayout(false);
            tabPage_background.PerformLayout();
            tabPage_offset.ResumeLayout(false);
            tabPage_offset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_shift).EndInit();
            panel_text.ResumeLayout(false);
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_close;
        private System.Windows.Forms.Label label_size;
        private mage.Theming.CustomControls.FlatComboBox comboBox_room;
        private mage.Theming.CustomControls.FlatComboBox comboBox_area;
        private System.Windows.Forms.Label label_tileset;
        private mage.Theming.CustomControls.FlatComboBox comboBox_tileset;
        private System.Windows.Forms.Panel panel_result;
        private System.Windows.Forms.Panel panel_gfx;
        private mage.Theming.CustomControls.FlatComboBox comboBox_bg;
        private System.Windows.Forms.Button button_hflipTL;
        private System.Windows.Forms.Button button_hflipTR;
        private System.Windows.Forms.Button button_hflipBR;
        private System.Windows.Forms.Button button_hflipBL;
        private System.Windows.Forms.Button button_vflipTR;
        private System.Windows.Forms.Button button_vflipBR;
        private System.Windows.Forms.Button button_vflipBL;
        private System.Windows.Forms.Button button_vflipTL;
        private System.Windows.Forms.Button button_palTR;
        private System.Windows.Forms.Button button_palTL;
        private System.Windows.Forms.Button button_palBL;
        private System.Windows.Forms.Button button_palBR;
        private mage.Theming.CustomControls.FlatTabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_background;
        private System.Windows.Forms.TabPage tabPage_tileset;
        private mage.Theming.CustomControls.FlatComboBox comboBox_size;
        private System.Windows.Forms.Label label_height;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_height;
        private System.Windows.Forms.TabPage tabPage_offset;
        private System.Windows.Forms.Label label_palette;
        private System.Windows.Forms.Label label_graphics;
        private System.Windows.Forms.Label label_tileTable;
        private mage.Theming.CustomControls.FlatTextBox textBox_pal;
        private mage.Theming.CustomControls.FlatTextBox textBox_gfx;
        private mage.Theming.CustomControls.FlatTextBox textBox_ttb;
        private System.Windows.Forms.Button button_go;
        private System.Windows.Forms.Label label_bg;
        private System.Windows.Forms.Label label_room;
        private System.Windows.Forms.Label label_area;
        private GfxView gfxView_gfx;
        private GfxView gfxView_tile;
        private GfxView gfxView_result;
        private System.Windows.Forms.Label label_pal;
        private mage.Theming.CustomControls.FlatComboBox comboBox_palette;
        private System.Windows.Forms.CheckBox checkBox_copyPalette;
        private System.Windows.Forms.Label label_tileTL;
        private System.Windows.Forms.Label label_tileBL;
        private System.Windows.Forms.Label label_tileTR;
        private System.Windows.Forms.Label label_tileBR;
        private System.Windows.Forms.Panel panel_text;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_tile;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.CheckBox checkBox_preserveData;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_shift;
        private System.Windows.Forms.Label label_shift;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip_spring;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_import;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_export;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_importTileTable;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_exportTileTable;
        private System.Windows.Forms.Button button_flip_v;
        private System.Windows.Forms.Button button_flip_h;
    }
}