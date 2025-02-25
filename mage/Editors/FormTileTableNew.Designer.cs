namespace mage.Editors
{
    partial class FormTileTableNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTileTableNew));
            panel_gfxView = new System.Windows.Forms.Panel();
            gfxView = new Controls.TileDisplay();
            panel_Main = new System.Windows.Forms.SplitContainer();
            panel_gfxAndPal = new System.Windows.Forms.SplitContainer();
            group_palette = new System.Windows.Forms.GroupBox();
            checkBox_copyPalette = new System.Windows.Forms.CheckBox();
            checkBox_showPalette = new System.Windows.Forms.CheckBox();
            paletteView = new Controls.TileDisplay();
            comboBox_palette = new Theming.CustomControls.FlatComboBox();
            label_pal = new System.Windows.Forms.Label();
            group_gfx = new System.Windows.Forms.GroupBox();
            toolStrip_gfx = new System.Windows.Forms.ToolStrip();
            button_gfxZoomIn = new System.Windows.Forms.ToolStripButton();
            button_gfxZoomOut = new System.Windows.Forms.ToolStripButton();
            label_gfxZoom = new System.Windows.Forms.ToolStripLabel();
            panel_select = new System.Windows.Forms.Panel();
            tab_select = new Theming.CustomControls.FlatTabControl();
            tabPage_tileset = new System.Windows.Forms.TabPage();
            label_height = new System.Windows.Forms.Label();
            numericUpDown_height = new Theming.CustomControls.FlatNumericUpDown();
            comboBox_tileset = new Theming.CustomControls.FlatComboBox();
            label_tileset = new System.Windows.Forms.Label();
            tabPage_background = new System.Windows.Forms.TabPage();
            label_bg = new System.Windows.Forms.Label();
            label_room = new System.Windows.Forms.Label();
            label_area = new System.Windows.Forms.Label();
            comboBox_size = new Theming.CustomControls.FlatComboBox();
            comboBox_bg = new Theming.CustomControls.FlatComboBox();
            comboBox_area = new Theming.CustomControls.FlatComboBox();
            comboBox_room = new Theming.CustomControls.FlatComboBox();
            label_size = new System.Windows.Forms.Label();
            tabPage_offset = new System.Windows.Forms.TabPage();
            group_table = new System.Windows.Forms.GroupBox();
            panel_tableView = new System.Windows.Forms.Panel();
            tableView = new Controls.TileDisplay();
            toolStrip_table = new System.Windows.Forms.ToolStrip();
            button_flipH = new System.Windows.Forms.ToolStripButton();
            button_flipV = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            button_paletteIncrease = new System.Windows.Forms.ToolStripButton();
            button_paletteDecrease = new System.Windows.Forms.ToolStripButton();
            button_setPalette = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            button_grid = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            button_tableZoomIn = new System.Windows.Forms.ToolStripButton();
            button_tableZoomOut = new System.Windows.Forms.ToolStripButton();
            label_tableZoom = new System.Windows.Forms.ToolStripLabel();
            statusStrip_main = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            spring = new System.Windows.Forms.ToolStripStatusLabel();
            button_apply = new System.Windows.Forms.ToolStripDropDownButton();
            panel_gfxView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panel_Main).BeginInit();
            panel_Main.Panel1.SuspendLayout();
            panel_Main.Panel2.SuspendLayout();
            panel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)panel_gfxAndPal).BeginInit();
            panel_gfxAndPal.Panel1.SuspendLayout();
            panel_gfxAndPal.Panel2.SuspendLayout();
            panel_gfxAndPal.SuspendLayout();
            group_palette.SuspendLayout();
            group_gfx.SuspendLayout();
            toolStrip_gfx.SuspendLayout();
            panel_select.SuspendLayout();
            tab_select.SuspendLayout();
            tabPage_tileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).BeginInit();
            tabPage_background.SuspendLayout();
            group_table.SuspendLayout();
            panel_tableView.SuspendLayout();
            toolStrip_table.SuspendLayout();
            statusStrip_main.SuspendLayout();
            SuspendLayout();
            // 
            // panel_gfxView
            // 
            panel_gfxView.AutoScroll = true;
            panel_gfxView.Controls.Add(gfxView);
            panel_gfxView.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_gfxView.Location = new System.Drawing.Point(3, 44);
            panel_gfxView.Name = "panel_gfxView";
            panel_gfxView.Size = new System.Drawing.Size(529, 580);
            panel_gfxView.TabIndex = 0;
            // 
            // gfxView
            // 
            gfxView.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            gfxView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView.GridCellHeight = 16;
            gfxView.GridCellWidth = 16;
            gfxView.Location = new System.Drawing.Point(0, 6);
            gfxView.Name = "gfxView";
            gfxView.ShowGrid = false;
            gfxView.Size = new System.Drawing.Size(98, 72);
            gfxView.TabIndex = 0;
            gfxView.TabStop = false;
            gfxView.Tag = "unthemed";
            gfxView.Text = "tileDisplay1";
            gfxView.TileImage = null;
            gfxView.TileSize = 8;
            gfxView.Zoom = 0;
            gfxView.TileMouseDown += tile_gfxView_TileMouseDown;
            gfxView.TileMouseUp += tile_gfxView_TileMouseUp;
            gfxView.TileMouseMove += tile_gfxView_TileMouseMove;
            gfxView.Scrolled += gfxView_Scrolled;
            // 
            // panel_Main
            // 
            panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            panel_Main.Location = new System.Drawing.Point(0, 0);
            panel_Main.Name = "panel_Main";
            // 
            // panel_Main.Panel1
            // 
            panel_Main.Panel1.Controls.Add(panel_gfxAndPal);
            panel_Main.Panel1.Controls.Add(panel_select);
            panel_Main.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            panel_Main.Panel1MinSize = 303;
            // 
            // panel_Main.Panel2
            // 
            panel_Main.Panel2.Controls.Add(group_table);
            panel_Main.Panel2.Padding = new System.Windows.Forms.Padding(3, 3, 6, 3);
            panel_Main.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            panel_Main.Panel2MinSize = 262;
            panel_Main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            panel_Main.Size = new System.Drawing.Size(819, 802);
            panel_Main.SplitterDistance = 544;
            panel_Main.TabIndex = 1;
            // 
            // panel_gfxAndPal
            // 
            panel_gfxAndPal.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_gfxAndPal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            panel_gfxAndPal.IsSplitterFixed = true;
            panel_gfxAndPal.Location = new System.Drawing.Point(0, 105);
            panel_gfxAndPal.Name = "panel_gfxAndPal";
            panel_gfxAndPal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panel_gfxAndPal.Panel1
            // 
            panel_gfxAndPal.Panel1.Controls.Add(group_palette);
            panel_gfxAndPal.Panel1.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            panel_gfxAndPal.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // panel_gfxAndPal.Panel2
            // 
            panel_gfxAndPal.Panel2.Controls.Add(group_gfx);
            panel_gfxAndPal.Panel2.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            panel_gfxAndPal.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            panel_gfxAndPal.Size = new System.Drawing.Size(544, 697);
            panel_gfxAndPal.SplitterDistance = 60;
            panel_gfxAndPal.TabIndex = 1;
            // 
            // group_palette
            // 
            group_palette.Controls.Add(checkBox_copyPalette);
            group_palette.Controls.Add(checkBox_showPalette);
            group_palette.Controls.Add(paletteView);
            group_palette.Controls.Add(comboBox_palette);
            group_palette.Controls.Add(label_pal);
            group_palette.Dock = System.Windows.Forms.DockStyle.Fill;
            group_palette.Enabled = false;
            group_palette.Location = new System.Drawing.Point(6, 3);
            group_palette.Name = "group_palette";
            group_palette.Size = new System.Drawing.Size(535, 54);
            group_palette.TabIndex = 0;
            group_palette.TabStop = false;
            group_palette.Text = "Palette";
            // 
            // checkBox_copyPalette
            // 
            checkBox_copyPalette.AutoSize = true;
            checkBox_copyPalette.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            checkBox_copyPalette.Checked = true;
            checkBox_copyPalette.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_copyPalette.Location = new System.Drawing.Point(180, 24);
            checkBox_copyPalette.Name = "checkBox_copyPalette";
            checkBox_copyPalette.Size = new System.Drawing.Size(93, 19);
            checkBox_copyPalette.TabIndex = 4;
            checkBox_copyPalette.Text = "Copy Palette";
            checkBox_copyPalette.UseVisualStyleBackColor = true;
            checkBox_copyPalette.CheckedChanged += checkBox_copyPalette_CheckedChanged;
            // 
            // checkBox_showPalette
            // 
            checkBox_showPalette.AutoSize = true;
            checkBox_showPalette.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            checkBox_showPalette.Location = new System.Drawing.Point(107, 24);
            checkBox_showPalette.Name = "checkBox_showPalette";
            checkBox_showPalette.Size = new System.Drawing.Size(67, 19);
            checkBox_showPalette.TabIndex = 3;
            checkBox_showPalette.Text = "Preview";
            checkBox_showPalette.UseVisualStyleBackColor = true;
            checkBox_showPalette.CheckedChanged += checkBox_showPalette_CheckedChanged;
            // 
            // paletteView
            // 
            paletteView.BackColor = System.Drawing.SystemColors.Control;
            paletteView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            paletteView.GridCellHeight = 16;
            paletteView.GridCellWidth = 16;
            paletteView.Location = new System.Drawing.Point(8, 51);
            paletteView.Name = "paletteView";
            paletteView.ShowGrid = false;
            paletteView.Size = new System.Drawing.Size(273, 273);
            paletteView.TabIndex = 2;
            paletteView.TabStop = false;
            paletteView.Text = "tileDisplay1";
            paletteView.TileImage = null;
            paletteView.TileSize = 17;
            paletteView.Visible = false;
            paletteView.Zoom = 0;
            paletteView.TileMouseDown += paletteView_TileMouseDown;
            paletteView.TileMouseMove += paletteView_TileMouseMove;
            // 
            // comboBox_palette
            // 
            comboBox_palette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_palette.FormattingEnabled = true;
            comboBox_palette.Location = new System.Drawing.Point(55, 22);
            comboBox_palette.Name = "comboBox_palette";
            comboBox_palette.Size = new System.Drawing.Size(46, 23);
            comboBox_palette.TabIndex = 1;
            comboBox_palette.SelectedIndexChanged += comboBox_palette_SelectedIndexChanged;
            // 
            // label_pal
            // 
            label_pal.AutoSize = true;
            label_pal.Location = new System.Drawing.Point(6, 25);
            label_pal.Name = "label_pal";
            label_pal.Size = new System.Drawing.Size(43, 15);
            label_pal.TabIndex = 0;
            label_pal.Text = "Palette";
            // 
            // group_gfx
            // 
            group_gfx.Controls.Add(panel_gfxView);
            group_gfx.Controls.Add(toolStrip_gfx);
            group_gfx.Dock = System.Windows.Forms.DockStyle.Fill;
            group_gfx.Location = new System.Drawing.Point(6, 3);
            group_gfx.Name = "group_gfx";
            group_gfx.Size = new System.Drawing.Size(535, 627);
            group_gfx.TabIndex = 0;
            group_gfx.TabStop = false;
            group_gfx.Text = "Graphics";
            // 
            // toolStrip_gfx
            // 
            toolStrip_gfx.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip_gfx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { button_gfxZoomIn, button_gfxZoomOut, label_gfxZoom });
            toolStrip_gfx.Location = new System.Drawing.Point(3, 19);
            toolStrip_gfx.Name = "toolStrip_gfx";
            toolStrip_gfx.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            toolStrip_gfx.Size = new System.Drawing.Size(529, 25);
            toolStrip_gfx.TabIndex = 1;
            toolStrip_gfx.Text = "toolStrip1";
            // 
            // button_gfxZoomIn
            // 
            button_gfxZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_gfxZoomIn.Image = Properties.Resources.zoom_in;
            button_gfxZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_gfxZoomIn.Name = "button_gfxZoomIn";
            button_gfxZoomIn.Size = new System.Drawing.Size(23, 22);
            button_gfxZoomIn.Text = "Zoom In";
            button_gfxZoomIn.Click += button_gfxZoomIn_Click;
            // 
            // button_gfxZoomOut
            // 
            button_gfxZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_gfxZoomOut.Image = Properties.Resources.zoom_out;
            button_gfxZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_gfxZoomOut.Name = "button_gfxZoomOut";
            button_gfxZoomOut.Size = new System.Drawing.Size(23, 22);
            button_gfxZoomOut.Text = "Zoom Out";
            button_gfxZoomOut.Click += button_gfxZoomOut_Click;
            // 
            // label_gfxZoom
            // 
            label_gfxZoom.Name = "label_gfxZoom";
            label_gfxZoom.Size = new System.Drawing.Size(35, 22);
            label_gfxZoom.Text = "100%";
            // 
            // panel_select
            // 
            panel_select.Controls.Add(tab_select);
            panel_select.Dock = System.Windows.Forms.DockStyle.Top;
            panel_select.Location = new System.Drawing.Point(0, 0);
            panel_select.Name = "panel_select";
            panel_select.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            panel_select.Size = new System.Drawing.Size(544, 105);
            panel_select.TabIndex = 3;
            // 
            // tab_select
            // 
            tab_select.BorderColor = System.Drawing.Color.Empty;
            tab_select.Controls.Add(tabPage_tileset);
            tab_select.Controls.Add(tabPage_background);
            tab_select.Controls.Add(tabPage_offset);
            tab_select.Dock = System.Windows.Forms.DockStyle.Fill;
            tab_select.Location = new System.Drawing.Point(6, 3);
            tab_select.Name = "tab_select";
            tab_select.SelectedIndex = 0;
            tab_select.Size = new System.Drawing.Size(535, 99);
            tab_select.TabIndex = 2;
            // 
            // tabPage_tileset
            // 
            tabPage_tileset.Controls.Add(label_height);
            tabPage_tileset.Controls.Add(numericUpDown_height);
            tabPage_tileset.Controls.Add(comboBox_tileset);
            tabPage_tileset.Controls.Add(label_tileset);
            tabPage_tileset.Location = new System.Drawing.Point(4, 25);
            tabPage_tileset.Name = "tabPage_tileset";
            tabPage_tileset.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            tabPage_tileset.Size = new System.Drawing.Size(527, 70);
            tabPage_tileset.TabIndex = 0;
            tabPage_tileset.Text = "Tileset";
            // 
            // label_height
            // 
            label_height.AutoSize = true;
            label_height.Location = new System.Drawing.Point(4, 40);
            label_height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_height.Name = "label_height";
            label_height.Size = new System.Drawing.Size(46, 15);
            label_height.TabIndex = 13;
            label_height.Text = "Height:";
            // 
            // numericUpDown_height
            // 
            numericUpDown_height.Enabled = false;
            numericUpDown_height.Hexadecimal = true;
            numericUpDown_height.Location = new System.Drawing.Point(58, 38);
            numericUpDown_height.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_height.Maximum = new decimal(new int[] { 64, 0, 0, 0 });
            numericUpDown_height.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown_height.Name = "numericUpDown_height";
            numericUpDown_height.Size = new System.Drawing.Size(52, 23);
            numericUpDown_height.TabIndex = 12;
            numericUpDown_height.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDown_height.ValueChanged += numericUpDown_height_ValueChanged;
            // 
            // comboBox_tileset
            // 
            comboBox_tileset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_tileset.FormattingEnabled = true;
            comboBox_tileset.Location = new System.Drawing.Point(58, 9);
            comboBox_tileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_tileset.Name = "comboBox_tileset";
            comboBox_tileset.Size = new System.Drawing.Size(52, 23);
            comboBox_tileset.TabIndex = 11;
            comboBox_tileset.SelectedIndexChanged += comboBox_tileset_SelectedIndexChanged;
            // 
            // label_tileset
            // 
            label_tileset.AutoSize = true;
            label_tileset.Location = new System.Drawing.Point(4, 12);
            label_tileset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tileset.Name = "label_tileset";
            label_tileset.Size = new System.Drawing.Size(43, 15);
            label_tileset.TabIndex = 10;
            label_tileset.Text = "Tileset:";
            // 
            // tabPage_background
            // 
            tabPage_background.Controls.Add(label_bg);
            tabPage_background.Controls.Add(label_room);
            tabPage_background.Controls.Add(label_area);
            tabPage_background.Controls.Add(comboBox_size);
            tabPage_background.Controls.Add(comboBox_bg);
            tabPage_background.Controls.Add(comboBox_area);
            tabPage_background.Controls.Add(comboBox_room);
            tabPage_background.Controls.Add(label_size);
            tabPage_background.Location = new System.Drawing.Point(4, 25);
            tabPage_background.Name = "tabPage_background";
            tabPage_background.Size = new System.Drawing.Size(192, 71);
            tabPage_background.TabIndex = 1;
            tabPage_background.Text = "Background";
            // 
            // label_bg
            // 
            label_bg.AutoSize = true;
            label_bg.Location = new System.Drawing.Point(152, 12);
            label_bg.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_bg.Name = "label_bg";
            label_bg.Size = new System.Drawing.Size(25, 15);
            label_bg.TabIndex = 20;
            label_bg.Text = "BG:";
            // 
            // label_room
            // 
            label_room.AutoSize = true;
            label_room.Location = new System.Drawing.Point(4, 41);
            label_room.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_room.Name = "label_room";
            label_room.Size = new System.Drawing.Size(42, 15);
            label_room.TabIndex = 19;
            label_room.Text = "Room:";
            // 
            // label_area
            // 
            label_area.AutoSize = true;
            label_area.Location = new System.Drawing.Point(4, 12);
            label_area.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_area.Name = "label_area";
            label_area.Size = new System.Drawing.Size(34, 15);
            label_area.TabIndex = 18;
            label_area.Text = "Area:";
            // 
            // comboBox_size
            // 
            comboBox_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_size.Enabled = false;
            comboBox_size.FormattingEnabled = true;
            comboBox_size.Items.AddRange(new object[] { "256 x 256", "512 x 256", "256 x 512" });
            comboBox_size.Location = new System.Drawing.Point(190, 38);
            comboBox_size.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_size.Name = "comboBox_size";
            comboBox_size.Size = new System.Drawing.Size(90, 23);
            comboBox_size.TabIndex = 17;
            // 
            // comboBox_bg
            // 
            comboBox_bg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_bg.FormattingEnabled = true;
            comboBox_bg.Items.AddRange(new object[] { "BG0", "BG3" });
            comboBox_bg.Location = new System.Drawing.Point(190, 9);
            comboBox_bg.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_bg.Name = "comboBox_bg";
            comboBox_bg.Size = new System.Drawing.Size(90, 23);
            comboBox_bg.TabIndex = 16;
            // 
            // comboBox_area
            // 
            comboBox_area.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_area.FormattingEnabled = true;
            comboBox_area.Location = new System.Drawing.Point(54, 9);
            comboBox_area.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_area.Name = "comboBox_area";
            comboBox_area.Size = new System.Drawing.Size(90, 23);
            comboBox_area.TabIndex = 13;
            // 
            // comboBox_room
            // 
            comboBox_room.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_room.FormattingEnabled = true;
            comboBox_room.Location = new System.Drawing.Point(54, 38);
            comboBox_room.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_room.Name = "comboBox_room";
            comboBox_room.Size = new System.Drawing.Size(90, 23);
            comboBox_room.TabIndex = 15;
            // 
            // label_size
            // 
            label_size.AutoSize = true;
            label_size.Location = new System.Drawing.Point(152, 41);
            label_size.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_size.Name = "label_size";
            label_size.Size = new System.Drawing.Size(30, 15);
            label_size.TabIndex = 14;
            label_size.Text = "Size:";
            // 
            // tabPage_offset
            // 
            tabPage_offset.Location = new System.Drawing.Point(4, 25);
            tabPage_offset.Name = "tabPage_offset";
            tabPage_offset.Size = new System.Drawing.Size(192, 71);
            tabPage_offset.TabIndex = 2;
            tabPage_offset.Text = "Offset";
            // 
            // group_table
            // 
            group_table.Controls.Add(panel_tableView);
            group_table.Controls.Add(toolStrip_table);
            group_table.Dock = System.Windows.Forms.DockStyle.Fill;
            group_table.Location = new System.Drawing.Point(3, 3);
            group_table.Name = "group_table";
            group_table.Size = new System.Drawing.Size(262, 796);
            group_table.TabIndex = 0;
            group_table.TabStop = false;
            group_table.Text = "Tile Table";
            // 
            // panel_tableView
            // 
            panel_tableView.AutoScroll = true;
            panel_tableView.Controls.Add(tableView);
            panel_tableView.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_tableView.Location = new System.Drawing.Point(3, 44);
            panel_tableView.Name = "panel_tableView";
            panel_tableView.Size = new System.Drawing.Size(256, 749);
            panel_tableView.TabIndex = 1;
            // 
            // tableView
            // 
            tableView.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            tableView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tableView.GridCellHeight = 16;
            tableView.GridCellWidth = 16;
            tableView.Location = new System.Drawing.Point(0, 6);
            tableView.Name = "tableView";
            tableView.ShowGrid = false;
            tableView.Size = new System.Drawing.Size(256, 101);
            tableView.TabIndex = 0;
            tableView.TabStop = false;
            tableView.Tag = "unthemed";
            tableView.Text = "tileDisplay1";
            tableView.TileImage = null;
            tableView.TileSize = 8;
            tableView.Zoom = 0;
            tableView.TileMouseDown += tableView_TileMouseDown;
            tableView.TileMouseUp += tableView_TileMouseUp;
            tableView.TileMouseMove += tableView_TileMouseMove;
            tableView.Scrolled += tableView_Scrolled;
            // 
            // toolStrip_table
            // 
            toolStrip_table.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip_table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { button_flipH, button_flipV, toolStripSeparator1, button_paletteIncrease, button_paletteDecrease, button_setPalette, toolStripSeparator3, button_grid, toolStripSeparator2, button_tableZoomIn, button_tableZoomOut, label_tableZoom });
            toolStrip_table.Location = new System.Drawing.Point(3, 19);
            toolStrip_table.Name = "toolStrip_table";
            toolStrip_table.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            toolStrip_table.Size = new System.Drawing.Size(256, 25);
            toolStrip_table.TabIndex = 0;
            toolStrip_table.Text = "toolStrip1";
            // 
            // button_flipH
            // 
            button_flipH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_flipH.Enabled = false;
            button_flipH.Image = Properties.Resources.shape_flip_horizontal;
            button_flipH.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_flipH.Name = "button_flipH";
            button_flipH.Size = new System.Drawing.Size(23, 22);
            button_flipH.Text = "Flip Horizontally (H, X)";
            button_flipH.Click += button_flipH_Click;
            // 
            // button_flipV
            // 
            button_flipV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_flipV.Enabled = false;
            button_flipV.Image = Properties.Resources.shape_flip_vertical;
            button_flipV.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_flipV.Name = "button_flipV";
            button_flipV.Size = new System.Drawing.Size(23, 22);
            button_flipV.Text = "Flip Vertically (V, Y)";
            button_flipV.Click += button_flipV_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // button_paletteIncrease
            // 
            button_paletteIncrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_paletteIncrease.Enabled = false;
            button_paletteIncrease.Image = (System.Drawing.Image)resources.GetObject("button_paletteIncrease.Image");
            button_paletteIncrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_paletteIncrease.Name = "button_paletteIncrease";
            button_paletteIncrease.Size = new System.Drawing.Size(23, 22);
            button_paletteIncrease.Text = "Increase Palette (Up, I)";
            button_paletteIncrease.Click += button_paletteIncrease_Click;
            // 
            // button_paletteDecrease
            // 
            button_paletteDecrease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_paletteDecrease.Enabled = false;
            button_paletteDecrease.Image = (System.Drawing.Image)resources.GetObject("button_paletteDecrease.Image");
            button_paletteDecrease.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_paletteDecrease.Name = "button_paletteDecrease";
            button_paletteDecrease.Size = new System.Drawing.Size(23, 22);
            button_paletteDecrease.Text = "Decrease Palette (Down, D)";
            button_paletteDecrease.Click += button_paletteDecrease_Click;
            // 
            // button_setPalette
            // 
            button_setPalette.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            button_setPalette.Enabled = false;
            button_setPalette.Image = (System.Drawing.Image)resources.GetObject("button_setPalette.Image");
            button_setPalette.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_setPalette.Name = "button_setPalette";
            button_setPalette.Size = new System.Drawing.Size(27, 22);
            button_setPalette.Text = "Set";
            button_setPalette.ToolTipText = "Set Palette (P)";
            button_setPalette.Click += button_setPalette_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // button_grid
            // 
            button_grid.CheckOnClick = true;
            button_grid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_grid.Image = (System.Drawing.Image)resources.GetObject("button_grid.Image");
            button_grid.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_grid.Name = "button_grid";
            button_grid.Size = new System.Drawing.Size(23, 22);
            button_grid.Text = "toolStripButton1";
            button_grid.CheckStateChanged += button_grid_CheckStateChanged;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // button_tableZoomIn
            // 
            button_tableZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_tableZoomIn.Image = Properties.Resources.zoom_in;
            button_tableZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_tableZoomIn.Name = "button_tableZoomIn";
            button_tableZoomIn.Size = new System.Drawing.Size(23, 22);
            button_tableZoomIn.Text = "Zoom In";
            button_tableZoomIn.Click += button_tableZoomIn_Click;
            // 
            // button_tableZoomOut
            // 
            button_tableZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_tableZoomOut.Image = Properties.Resources.zoom_out;
            button_tableZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_tableZoomOut.Name = "button_tableZoomOut";
            button_tableZoomOut.Size = new System.Drawing.Size(23, 22);
            button_tableZoomOut.Text = "Zoom Out";
            button_tableZoomOut.Click += button_tableZoomOut_Click;
            // 
            // label_tableZoom
            // 
            label_tableZoom.AutoSize = false;
            label_tableZoom.Name = "label_tableZoom";
            label_tableZoom.Size = new System.Drawing.Size(42, 22);
            label_tableZoom.Text = "1600%";
            label_tableZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusStrip_main
            // 
            statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_changes, spring, button_apply });
            statusStrip_main.Location = new System.Drawing.Point(0, 802);
            statusStrip_main.Name = "statusStrip_main";
            statusStrip_main.Size = new System.Drawing.Size(819, 22);
            statusStrip_main.TabIndex = 2;
            statusStrip_main.Text = "statusStrip1";
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 17);
            statusLabel_changes.Text = "-";
            // 
            // spring
            // 
            spring.Name = "spring";
            spring.Size = new System.Drawing.Size(734, 17);
            spring.Spring = true;
            // 
            // button_apply
            // 
            button_apply.Enabled = false;
            button_apply.Image = Properties.Resources.toolbar_save;
            button_apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_apply.Name = "button_apply";
            button_apply.ShowDropDownArrow = false;
            button_apply.Size = new System.Drawing.Size(58, 20);
            button_apply.Text = "Apply";
            button_apply.Click += button_apply_Click;
            // 
            // FormTileTableNew
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(819, 824);
            Controls.Add(panel_Main);
            Controls.Add(statusStrip_main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MinimumSize = new System.Drawing.Size(610, 863);
            Name = "FormTileTableNew";
            Text = "Tile Table Editor";
            FormClosing += FormTileTableNew_FormClosing;
            KeyDown += KeyPressed;
            panel_gfxView.ResumeLayout(false);
            panel_Main.Panel1.ResumeLayout(false);
            panel_Main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panel_Main).EndInit();
            panel_Main.ResumeLayout(false);
            panel_gfxAndPal.Panel1.ResumeLayout(false);
            panel_gfxAndPal.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panel_gfxAndPal).EndInit();
            panel_gfxAndPal.ResumeLayout(false);
            group_palette.ResumeLayout(false);
            group_palette.PerformLayout();
            group_gfx.ResumeLayout(false);
            group_gfx.PerformLayout();
            toolStrip_gfx.ResumeLayout(false);
            toolStrip_gfx.PerformLayout();
            panel_select.ResumeLayout(false);
            tab_select.ResumeLayout(false);
            tabPage_tileset.ResumeLayout(false);
            tabPage_tileset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).EndInit();
            tabPage_background.ResumeLayout(false);
            tabPage_background.PerformLayout();
            group_table.ResumeLayout(false);
            group_table.PerformLayout();
            panel_tableView.ResumeLayout(false);
            toolStrip_table.ResumeLayout(false);
            toolStrip_table.PerformLayout();
            statusStrip_main.ResumeLayout(false);
            statusStrip_main.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panel_gfxView;
        private Controls.TileDisplay gfxView;
        private System.Windows.Forms.SplitContainer panel_Main;
        private System.Windows.Forms.SplitContainer panel_gfxAndPal;
        private Theming.CustomControls.FlatTabControl tab_select;
        private System.Windows.Forms.TabPage tabPage_tileset;
        private System.Windows.Forms.TabPage tabPage_background;
        private System.Windows.Forms.TabPage tabPage_offset;
        private System.Windows.Forms.Panel panel_select;
        private System.Windows.Forms.GroupBox group_gfx;
        private System.Windows.Forms.GroupBox group_palette;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.GroupBox group_table;
        private System.Windows.Forms.ToolStrip toolStrip_gfx;
        private System.Windows.Forms.ToolStripButton button_gfxZoomIn;
        private System.Windows.Forms.ToolStripButton button_gfxZoomOut;
        private System.Windows.Forms.ToolStripLabel label_gfxZoom;
        private System.Windows.Forms.Label label_pal;
        private System.Windows.Forms.ToolStrip toolStrip_table;
        private System.Windows.Forms.Panel panel_tableView;
        private Controls.TileDisplay tableView;
        private Theming.CustomControls.FlatComboBox comboBox_palette;
        private System.Windows.Forms.ToolStripButton button_tableZoomIn;
        private System.Windows.Forms.ToolStripButton button_tableZoomOut;
        private System.Windows.Forms.ToolStripLabel label_tableZoom;
        private System.Windows.Forms.Label label_height;
        private Theming.CustomControls.FlatNumericUpDown numericUpDown_height;
        private Theming.CustomControls.FlatComboBox comboBox_tileset;
        private System.Windows.Forms.Label label_tileset;
        private Controls.TileDisplay paletteView;
        private System.Windows.Forms.CheckBox checkBox_showPalette;
        private System.Windows.Forms.CheckBox checkBox_copyPalette;
        private System.Windows.Forms.ToolStripButton button_flipH;
        private System.Windows.Forms.ToolStripButton button_flipV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton button_paletteIncrease;
        private System.Windows.Forms.ToolStripButton button_paletteDecrease;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.ToolStripStatusLabel spring;
        private System.Windows.Forms.ToolStripDropDownButton button_apply;
        private System.Windows.Forms.ToolStripButton button_setPalette;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton button_grid;
        private System.Windows.Forms.Label label_bg;
        private System.Windows.Forms.Label label_room;
        private System.Windows.Forms.Label label_area;
        private Theming.CustomControls.FlatComboBox comboBox_size;
        private Theming.CustomControls.FlatComboBox comboBox_bg;
        private Theming.CustomControls.FlatComboBox comboBox_area;
        private Theming.CustomControls.FlatComboBox comboBox_room;
        private System.Windows.Forms.Label label_size;
    }
}