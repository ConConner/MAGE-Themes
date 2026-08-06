namespace mage.Editors.NewEditors
{
    partial class FormPaletteNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPaletteNew));
            panel_main = new System.Windows.Forms.SplitContainer();
            groupBox_color = new System.Windows.Forms.GroupBox();
            colorBar_blue = new mage.Controls.ColorBar();
            colorBar_green = new mage.Controls.ColorBar();
            colorBar_red = new mage.Controls.ColorBar();
            label_hex_color = new System.Windows.Forms.Label();
            textBox_hex_color = new mage.Theming.CustomControls.FlatTextBox();
            label_red = new System.Windows.Forms.Label();
            label_green = new System.Windows.Forms.Label();
            label_blue = new System.Windows.Forms.Label();
            numericUpDown_red = new mage.Theming.CustomControls.FlatNumericUpDown();
            numericUpDown_green = new mage.Theming.CustomControls.FlatNumericUpDown();
            numericUpDown_blue = new mage.Theming.CustomControls.FlatNumericUpDown();
            groupBox_currentColor = new System.Windows.Forms.GroupBox();
            pictureBox_chosenColor = new System.Windows.Forms.PictureBox();
            label_24bitVal = new System.Windows.Forms.Label();
            label_15bit = new System.Windows.Forms.Label();
            label_24bit = new System.Windows.Forms.Label();
            label_15bitVal = new System.Windows.Forms.Label();
            group_selection = new System.Windows.Forms.GroupBox();
            numericUpDown_rows = new mage.Theming.CustomControls.FlatNumericUpDown();
            label_numOfRows = new System.Windows.Forms.Label();
            label_offset = new System.Windows.Forms.Label();
            button_minus = new System.Windows.Forms.Button();
            button_plus = new System.Windows.Forms.Button();
            button_load = new System.Windows.Forms.Button();
            textBox_offset = new mage.Theming.CustomControls.FlatTextBox();
            statusStrip_main = new System.Windows.Forms.StatusStrip();
            statusLabel_tile = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            spring = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_import = new System.Windows.Forms.ToolStripDropDownButton();
            statusStrip_importRaw = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_importTLP = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_importYY = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_export = new System.Windows.Forms.ToolStripDropDownButton();
            statusStrip_exportRaw = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_exportTLP = new System.Windows.Forms.ToolStripMenuItem();
            statusStrip_exportYY = new System.Windows.Forms.ToolStripMenuItem();
            button_apply = new System.Windows.Forms.ToolStripDropDownButton();
            groupBox_map = new System.Windows.Forms.GroupBox();
            panel_palView = new mage.Controls.ExtendedPanel();
            tileDisplay_pal = new mage.Controls.TileDisplay();
            toolStrip_palette = new System.Windows.Forms.ToolStrip();
            button_undo = new System.Windows.Forms.ToolStripSplitButton();
            button_redo = new System.Windows.Forms.ToolStripSplitButton();
            toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            button_flipMapH = new System.Windows.Forms.ToolStripButton();
            button_flipMapV = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            button_grid = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            button_mapZoomIn = new System.Windows.Forms.ToolStripButton();
            button_mapZoomOut = new System.Windows.Forms.ToolStripButton();
            label_mapZoom = new System.Windows.Forms.ToolStripLabel();
            ((System.ComponentModel.ISupportInitialize)panel_main).BeginInit();
            panel_main.Panel1.SuspendLayout();
            panel_main.Panel2.SuspendLayout();
            panel_main.SuspendLayout();
            groupBox_color.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_red).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_green).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_blue).BeginInit();
            groupBox_currentColor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_chosenColor).BeginInit();
            group_selection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_rows).BeginInit();
            statusStrip_main.SuspendLayout();
            groupBox_map.SuspendLayout();
            panel_palView.SuspendLayout();
            toolStrip_palette.SuspendLayout();
            SuspendLayout();
            // 
            // panel_main
            // 
            panel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_main.Location = new System.Drawing.Point(0, 0);
            panel_main.Name = "panel_main";
            // 
            // panel_main.Panel1
            // 
            panel_main.Panel1.Controls.Add(groupBox_color);
            panel_main.Panel1.Controls.Add(groupBox_currentColor);
            panel_main.Panel1.Controls.Add(group_selection);
            panel_main.Panel1.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            // 
            // panel_main.Panel2
            // 
            panel_main.Panel2.Controls.Add(groupBox_map);
            panel_main.Panel2.Padding = new System.Windows.Forms.Padding(3, 3, 6, 3);
            panel_main.Size = new System.Drawing.Size(974, 483);
            panel_main.SplitterDistance = 288;
            panel_main.TabIndex = 0;
            // 
            // groupBox_color
            // 
            groupBox_color.Controls.Add(colorBar_blue);
            groupBox_color.Controls.Add(colorBar_green);
            groupBox_color.Controls.Add(colorBar_red);
            groupBox_color.Controls.Add(label_hex_color);
            groupBox_color.Controls.Add(textBox_hex_color);
            groupBox_color.Controls.Add(label_red);
            groupBox_color.Controls.Add(label_green);
            groupBox_color.Controls.Add(label_blue);
            groupBox_color.Controls.Add(numericUpDown_red);
            groupBox_color.Controls.Add(numericUpDown_green);
            groupBox_color.Controls.Add(numericUpDown_blue);
            groupBox_color.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox_color.Location = new System.Drawing.Point(6, 189);
            groupBox_color.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_color.Name = "groupBox_color";
            groupBox_color.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_color.Size = new System.Drawing.Size(279, 155);
            groupBox_color.TabIndex = 3;
            groupBox_color.TabStop = false;
            groupBox_color.Text = "Color Selector";
            // 
            // colorBar_blue
            // 
            colorBar_blue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            colorBar_blue.BorderColor = System.Drawing.Color.Black;
            colorBar_blue.Channel = mage.Controls.ColorChannel.Blue;
            colorBar_blue.Location = new System.Drawing.Point(111, 89);
            colorBar_blue.MarkerColor = System.Drawing.Color.White;
            colorBar_blue.Name = "colorBar_blue";
            colorBar_blue.Size = new System.Drawing.Size(161, 23);
            colorBar_blue.TabIndex = 28;
            colorBar_blue.Text = "colorBar3";
            colorBar_blue.ValueChanged += colorBar_red_ValueChanged;
            // 
            // colorBar_green
            // 
            colorBar_green.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            colorBar_green.BorderColor = System.Drawing.Color.Black;
            colorBar_green.Channel = mage.Controls.ColorChannel.Green;
            colorBar_green.Location = new System.Drawing.Point(111, 55);
            colorBar_green.MarkerColor = System.Drawing.Color.White;
            colorBar_green.Name = "colorBar_green";
            colorBar_green.Size = new System.Drawing.Size(161, 23);
            colorBar_green.TabIndex = 27;
            colorBar_green.Text = "colorBar2";
            colorBar_green.ValueChanged += colorBar_red_ValueChanged;
            // 
            // colorBar_red
            // 
            colorBar_red.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            colorBar_red.BorderColor = System.Drawing.Color.Black;
            colorBar_red.Channel = mage.Controls.ColorChannel.Red;
            colorBar_red.Location = new System.Drawing.Point(111, 22);
            colorBar_red.MarkerColor = System.Drawing.Color.White;
            colorBar_red.Name = "colorBar_red";
            colorBar_red.Size = new System.Drawing.Size(161, 23);
            colorBar_red.TabIndex = 26;
            colorBar_red.Text = "colorBar1";
            colorBar_red.ValueChanged += colorBar_red_ValueChanged;
            // 
            // label_hex_color
            // 
            label_hex_color.AutoSize = true;
            label_hex_color.Location = new System.Drawing.Point(8, 127);
            label_hex_color.Name = "label_hex_color";
            label_hex_color.Size = new System.Drawing.Size(32, 15);
            label_hex_color.TabIndex = 25;
            label_hex_color.Text = "HEX:";
            // 
            // textBox_hex_color
            // 
            textBox_hex_color.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_hex_color.BorderColor = System.Drawing.Color.Black;
            textBox_hex_color.DisplayBorder = true;
            textBox_hex_color.HexSanitized = false;
            textBox_hex_color.HexSanitizedMaxValue = -1;
            textBox_hex_color.Location = new System.Drawing.Point(57, 122);
            textBox_hex_color.MaxLength = 32767;
            textBox_hex_color.Multiline = false;
            textBox_hex_color.Name = "textBox_hex_color";
            textBox_hex_color.OnTextChanged = null;
            textBox_hex_color.Padding = new System.Windows.Forms.Padding(4, 3, 4, 2);
            textBox_hex_color.PlaceholderText = "";
            textBox_hex_color.ReadOnly = false;
            textBox_hex_color.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_hex_color.SelectionStart = 0;
            textBox_hex_color.Size = new System.Drawing.Size(215, 23);
            textBox_hex_color.TabIndex = 24;
            textBox_hex_color.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_hex_color.ValueBox = false;
            textBox_hex_color.WordWrap = true;
            // 
            // label_red
            // 
            label_red.AutoSize = true;
            label_red.Location = new System.Drawing.Point(8, 24);
            label_red.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_red.Name = "label_red";
            label_red.Size = new System.Drawing.Size(30, 15);
            label_red.TabIndex = 0;
            label_red.Text = "Red:";
            // 
            // label_green
            // 
            label_green.AutoSize = true;
            label_green.Location = new System.Drawing.Point(8, 58);
            label_green.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_green.Name = "label_green";
            label_green.Size = new System.Drawing.Size(41, 15);
            label_green.TabIndex = 0;
            label_green.Text = "Green:";
            // 
            // label_blue
            // 
            label_blue.AutoSize = true;
            label_blue.Location = new System.Drawing.Point(8, 91);
            label_blue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_blue.Name = "label_blue";
            label_blue.Size = new System.Drawing.Size(33, 15);
            label_blue.TabIndex = 0;
            label_blue.Text = "Blue:";
            // 
            // numericUpDown_red
            // 
            numericUpDown_red.Hexadecimal = true;
            numericUpDown_red.Location = new System.Drawing.Point(57, 22);
            numericUpDown_red.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_red.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown_red.Name = "numericUpDown_red";
            numericUpDown_red.Size = new System.Drawing.Size(47, 23);
            numericUpDown_red.TabIndex = 0;
            // 
            // numericUpDown_green
            // 
            numericUpDown_green.Hexadecimal = true;
            numericUpDown_green.Location = new System.Drawing.Point(57, 55);
            numericUpDown_green.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_green.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown_green.Name = "numericUpDown_green";
            numericUpDown_green.Size = new System.Drawing.Size(47, 23);
            numericUpDown_green.TabIndex = 1;
            // 
            // numericUpDown_blue
            // 
            numericUpDown_blue.Hexadecimal = true;
            numericUpDown_blue.Location = new System.Drawing.Point(57, 89);
            numericUpDown_blue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_blue.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
            numericUpDown_blue.Name = "numericUpDown_blue";
            numericUpDown_blue.Size = new System.Drawing.Size(47, 23);
            numericUpDown_blue.TabIndex = 2;
            // 
            // groupBox_currentColor
            // 
            groupBox_currentColor.Controls.Add(pictureBox_chosenColor);
            groupBox_currentColor.Controls.Add(label_24bitVal);
            groupBox_currentColor.Controls.Add(label_15bit);
            groupBox_currentColor.Controls.Add(label_24bit);
            groupBox_currentColor.Controls.Add(label_15bitVal);
            groupBox_currentColor.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox_currentColor.Location = new System.Drawing.Point(6, 123);
            groupBox_currentColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_currentColor.Name = "groupBox_currentColor";
            groupBox_currentColor.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_currentColor.Size = new System.Drawing.Size(279, 66);
            groupBox_currentColor.TabIndex = 1;
            groupBox_currentColor.TabStop = false;
            groupBox_currentColor.Text = "Current Color";
            // 
            // pictureBox_chosenColor
            // 
            pictureBox_chosenColor.Location = new System.Drawing.Point(7, 21);
            pictureBox_chosenColor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_chosenColor.Name = "pictureBox_chosenColor";
            pictureBox_chosenColor.Size = new System.Drawing.Size(35, 35);
            pictureBox_chosenColor.TabIndex = 2;
            pictureBox_chosenColor.TabStop = false;
            // 
            // label_24bitVal
            // 
            label_24bitVal.AutoSize = true;
            label_24bitVal.Location = new System.Drawing.Point(90, 38);
            label_24bitVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_24bitVal.Name = "label_24bitVal";
            label_24bitVal.Size = new System.Drawing.Size(37, 15);
            label_24bitVal.TabIndex = 27;
            label_24bitVal.Text = "0, 0, 0";
            // 
            // label_15bit
            // 
            label_15bit.AutoSize = true;
            label_15bit.Location = new System.Drawing.Point(48, 21);
            label_15bit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_15bit.Name = "label_15bit";
            label_15bit.Size = new System.Drawing.Size(41, 15);
            label_15bit.TabIndex = 18;
            label_15bit.Text = "15-bit:";
            // 
            // label_24bit
            // 
            label_24bit.AutoSize = true;
            label_24bit.Location = new System.Drawing.Point(48, 38);
            label_24bit.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_24bit.Name = "label_24bit";
            label_24bit.Size = new System.Drawing.Size(41, 15);
            label_24bit.TabIndex = 26;
            label_24bit.Text = "24-bit:";
            // 
            // label_15bitVal
            // 
            label_15bitVal.AutoSize = true;
            label_15bitVal.Location = new System.Drawing.Point(90, 21);
            label_15bitVal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_15bitVal.Name = "label_15bitVal";
            label_15bitVal.Size = new System.Drawing.Size(42, 15);
            label_15bitVal.TabIndex = 19;
            label_15bitVal.Text = "0x0000";
            // 
            // group_selection
            // 
            group_selection.Controls.Add(numericUpDown_rows);
            group_selection.Controls.Add(label_numOfRows);
            group_selection.Controls.Add(label_offset);
            group_selection.Controls.Add(button_minus);
            group_selection.Controls.Add(button_plus);
            group_selection.Controls.Add(button_load);
            group_selection.Controls.Add(textBox_offset);
            group_selection.Dock = System.Windows.Forms.DockStyle.Top;
            group_selection.Location = new System.Drawing.Point(6, 3);
            group_selection.Name = "group_selection";
            group_selection.Size = new System.Drawing.Size(279, 120);
            group_selection.TabIndex = 0;
            group_selection.TabStop = false;
            group_selection.Text = "Selection";
            // 
            // numericUpDown_rows
            // 
            numericUpDown_rows.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            numericUpDown_rows.Hexadecimal = true;
            numericUpDown_rows.Location = new System.Drawing.Point(55, 51);
            numericUpDown_rows.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_rows.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            numericUpDown_rows.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_rows.Name = "numericUpDown_rows";
            numericUpDown_rows.Size = new System.Drawing.Size(149, 23);
            numericUpDown_rows.TabIndex = 8;
            numericUpDown_rows.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label_numOfRows
            // 
            label_numOfRows.AutoSize = true;
            label_numOfRows.Location = new System.Drawing.Point(6, 53);
            label_numOfRows.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_numOfRows.Name = "label_numOfRows";
            label_numOfRows.Size = new System.Drawing.Size(38, 15);
            label_numOfRows.TabIndex = 7;
            label_numOfRows.Text = "Rows:";
            // 
            // label_offset
            // 
            label_offset.AutoSize = true;
            label_offset.Location = new System.Drawing.Point(6, 25);
            label_offset.Name = "label_offset";
            label_offset.Size = new System.Drawing.Size(42, 15);
            label_offset.TabIndex = 6;
            label_offset.Text = "Offset:";
            // 
            // button_minus
            // 
            button_minus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            button_minus.Location = new System.Drawing.Point(212, 20);
            button_minus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_minus.Name = "button_minus";
            button_minus.Size = new System.Drawing.Size(26, 25);
            button_minus.TabIndex = 5;
            button_minus.Text = "-";
            button_minus.UseVisualStyleBackColor = true;
            // 
            // button_plus
            // 
            button_plus.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            button_plus.Location = new System.Drawing.Point(246, 20);
            button_plus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_plus.Name = "button_plus";
            button_plus.Size = new System.Drawing.Size(26, 25);
            button_plus.TabIndex = 4;
            button_plus.Text = "+";
            button_plus.UseVisualStyleBackColor = true;
            // 
            // button_load
            // 
            button_load.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button_load.Location = new System.Drawing.Point(7, 89);
            button_load.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_load.Name = "button_load";
            button_load.Size = new System.Drawing.Size(265, 25);
            button_load.TabIndex = 2;
            button_load.Text = "Load";
            button_load.UseVisualStyleBackColor = true;
            // 
            // textBox_offset
            // 
            textBox_offset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_offset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_offset.DisplayBorder = true;
            textBox_offset.HexSanitized = false;
            textBox_offset.HexSanitizedMaxValue = -1;
            textBox_offset.Location = new System.Drawing.Point(55, 22);
            textBox_offset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_offset.MaxLength = 32767;
            textBox_offset.Multiline = false;
            textBox_offset.Name = "textBox_offset";
            textBox_offset.OnTextChanged = null;
            textBox_offset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_offset.PlaceholderText = "";
            textBox_offset.ReadOnly = false;
            textBox_offset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_offset.SelectionStart = 0;
            textBox_offset.Size = new System.Drawing.Size(149, 23);
            textBox_offset.TabIndex = 1;
            textBox_offset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_offset.ValueBox = true;
            textBox_offset.WordWrap = true;
            // 
            // statusStrip_main
            // 
            statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_tile, statusLabel_changes, spring, statusStrip_import, statusStrip_export, button_apply });
            statusStrip_main.Location = new System.Drawing.Point(0, 483);
            statusStrip_main.Name = "statusStrip_main";
            statusStrip_main.Size = new System.Drawing.Size(974, 22);
            statusStrip_main.TabIndex = 3;
            statusStrip_main.Text = "statusStrip1";
            // 
            // statusLabel_tile
            // 
            statusLabel_tile.AutoSize = false;
            statusLabel_tile.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            statusLabel_tile.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            statusLabel_tile.Name = "statusLabel_tile";
            statusLabel_tile.Size = new System.Drawing.Size(80, 17);
            statusLabel_tile.Text = "Tile:";
            statusLabel_tile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            spring.Size = new System.Drawing.Size(700, 17);
            spring.Spring = true;
            // 
            // statusStrip_import
            // 
            statusStrip_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusStrip_import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { statusStrip_importRaw, statusStrip_importTLP, statusStrip_importYY });
            statusStrip_import.Name = "statusStrip_import";
            statusStrip_import.Size = new System.Drawing.Size(56, 20);
            statusStrip_import.Text = "Import";
            // 
            // statusStrip_importRaw
            // 
            statusStrip_importRaw.Name = "statusStrip_importRaw";
            statusStrip_importRaw.Size = new System.Drawing.Size(154, 22);
            statusStrip_importRaw.Text = "Raw...";
            // 
            // statusStrip_importTLP
            // 
            statusStrip_importTLP.Name = "statusStrip_importTLP";
            statusStrip_importTLP.Size = new System.Drawing.Size(154, 22);
            statusStrip_importTLP.Text = "Tile Layer Pro...";
            // 
            // statusStrip_importYY
            // 
            statusStrip_importYY.Name = "statusStrip_importYY";
            statusStrip_importYY.Size = new System.Drawing.Size(154, 22);
            statusStrip_importYY.Text = "YY-CHR...";
            // 
            // statusStrip_export
            // 
            statusStrip_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusStrip_export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { statusStrip_exportRaw, statusStrip_exportTLP, statusStrip_exportYY });
            statusStrip_export.Name = "statusStrip_export";
            statusStrip_export.Size = new System.Drawing.Size(53, 20);
            statusStrip_export.Text = "Export";
            // 
            // statusStrip_exportRaw
            // 
            statusStrip_exportRaw.Name = "statusStrip_exportRaw";
            statusStrip_exportRaw.Size = new System.Drawing.Size(154, 22);
            statusStrip_exportRaw.Text = "Raw...";
            // 
            // statusStrip_exportTLP
            // 
            statusStrip_exportTLP.Name = "statusStrip_exportTLP";
            statusStrip_exportTLP.Size = new System.Drawing.Size(154, 22);
            statusStrip_exportTLP.Text = "Tile Layer Pro...";
            // 
            // statusStrip_exportYY
            // 
            statusStrip_exportYY.Name = "statusStrip_exportYY";
            statusStrip_exportYY.Size = new System.Drawing.Size(154, 22);
            statusStrip_exportYY.Text = "YY-CHR...";
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
            // 
            // groupBox_map
            // 
            groupBox_map.Controls.Add(panel_palView);
            groupBox_map.Controls.Add(toolStrip_palette);
            groupBox_map.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox_map.Location = new System.Drawing.Point(3, 3);
            groupBox_map.Name = "groupBox_map";
            groupBox_map.Size = new System.Drawing.Size(673, 477);
            groupBox_map.TabIndex = 1;
            groupBox_map.TabStop = false;
            groupBox_map.Text = "Palette";
            // 
            // panel_palView
            // 
            panel_palView.AutoScroll = true;
            panel_palView.Controls.Add(tileDisplay_pal);
            panel_palView.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_palView.Location = new System.Drawing.Point(3, 44);
            panel_palView.Name = "panel_palView";
            panel_palView.Size = new System.Drawing.Size(667, 430);
            panel_palView.TabIndex = 2;
            // 
            // tileDisplay_pal
            // 
            tileDisplay_pal.BackColor = System.Drawing.Color.FromArgb(32, 32, 32);
            tileDisplay_pal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tileDisplay_pal.GridCellHeight = 8;
            tileDisplay_pal.GridCellWidth = 8;
            tileDisplay_pal.Location = new System.Drawing.Point(0, 6);
            tileDisplay_pal.Name = "tileDisplay_pal";
            tileDisplay_pal.ShowGrid = false;
            tileDisplay_pal.ShowOamOrigin = false;
            tileDisplay_pal.Size = new System.Drawing.Size(0, 0);
            tileDisplay_pal.TabIndex = 0;
            tileDisplay_pal.TabStop = false;
            tileDisplay_pal.Tag = "unthemed";
            tileDisplay_pal.Text = "tileDisplay1";
            tileDisplay_pal.TileGridOrigin = new System.Drawing.Point(0, 0);
            tileDisplay_pal.TileImage = null;
            tileDisplay_pal.TileSize = 8;
            tileDisplay_pal.Zoom = 1;
            // 
            // toolStrip_palette
            // 
            toolStrip_palette.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip_palette.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { button_undo, button_redo, toolStripSeparator8, button_flipMapH, button_flipMapV, toolStripSeparator4, button_grid, toolStripSeparator5, button_mapZoomIn, button_mapZoomOut, label_mapZoom });
            toolStrip_palette.Location = new System.Drawing.Point(3, 19);
            toolStrip_palette.Name = "toolStrip_palette";
            toolStrip_palette.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            toolStrip_palette.Size = new System.Drawing.Size(667, 25);
            toolStrip_palette.TabIndex = 1;
            toolStrip_palette.Text = "toolStrip1";
            // 
            // button_undo
            // 
            button_undo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_undo.Enabled = false;
            button_undo.Image = Properties.Resources.toolbar_undo;
            button_undo.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_undo.Name = "button_undo";
            button_undo.Size = new System.Drawing.Size(32, 22);
            button_undo.Text = "Undo";
            // 
            // button_redo
            // 
            button_redo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_redo.Enabled = false;
            button_redo.Image = Properties.Resources.toolbar_redo;
            button_redo.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_redo.Name = "button_redo";
            button_redo.Size = new System.Drawing.Size(32, 22);
            button_redo.Text = "Redo";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // button_flipMapH
            // 
            button_flipMapH.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_flipMapH.Enabled = false;
            button_flipMapH.Image = Properties.Resources.shape_flip_horizontal;
            button_flipMapH.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_flipMapH.Name = "button_flipMapH";
            button_flipMapH.Size = new System.Drawing.Size(23, 22);
            button_flipMapH.Text = "Flip Horizontally (H, X)";
            // 
            // button_flipMapV
            // 
            button_flipMapV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_flipMapV.Enabled = false;
            button_flipMapV.Image = Properties.Resources.shape_flip_vertical;
            button_flipMapV.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_flipMapV.Name = "button_flipMapV";
            button_flipMapV.Size = new System.Drawing.Size(23, 22);
            button_flipMapV.Text = "Flip Vertically (V, Y)";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // button_grid
            // 
            button_grid.CheckOnClick = true;
            button_grid.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_grid.Image = (System.Drawing.Image)resources.GetObject("button_grid.Image");
            button_grid.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_grid.Name = "button_grid";
            button_grid.Size = new System.Drawing.Size(23, 22);
            button_grid.Text = "Grid";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // button_mapZoomIn
            // 
            button_mapZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_mapZoomIn.Image = Properties.Resources.zoom_in;
            button_mapZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_mapZoomIn.Name = "button_mapZoomIn";
            button_mapZoomIn.Size = new System.Drawing.Size(23, 22);
            button_mapZoomIn.Text = "Zoom In";
            // 
            // button_mapZoomOut
            // 
            button_mapZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            button_mapZoomOut.Image = Properties.Resources.zoom_out;
            button_mapZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            button_mapZoomOut.Name = "button_mapZoomOut";
            button_mapZoomOut.Size = new System.Drawing.Size(23, 22);
            button_mapZoomOut.Text = "Zoom Out";
            // 
            // label_mapZoom
            // 
            label_mapZoom.AutoSize = false;
            label_mapZoom.Name = "label_mapZoom";
            label_mapZoom.Size = new System.Drawing.Size(42, 22);
            label_mapZoom.Text = "1600%";
            label_mapZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormPaletteNew
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(974, 505);
            Controls.Add(panel_main);
            Controls.Add(statusStrip_main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormPaletteNew";
            Text = "Palette Editor";
            panel_main.Panel1.ResumeLayout(false);
            panel_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)panel_main).EndInit();
            panel_main.ResumeLayout(false);
            groupBox_color.ResumeLayout(false);
            groupBox_color.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_red).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_green).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_blue).EndInit();
            groupBox_currentColor.ResumeLayout(false);
            groupBox_currentColor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_chosenColor).EndInit();
            group_selection.ResumeLayout(false);
            group_selection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_rows).EndInit();
            statusStrip_main.ResumeLayout(false);
            statusStrip_main.PerformLayout();
            groupBox_map.ResumeLayout(false);
            groupBox_map.PerformLayout();
            panel_palView.ResumeLayout(false);
            toolStrip_palette.ResumeLayout(false);
            toolStrip_palette.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.SplitContainer panel_main;
        private System.Windows.Forms.GroupBox group_selection;
        private Theming.CustomControls.FlatTextBox textBox_offset;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_minus;
        private System.Windows.Forms.Button button_plus;
        private System.Windows.Forms.Label label_offset;
        private Theming.CustomControls.FlatNumericUpDown numericUpDown_rows;
        private System.Windows.Forms.Label label_numOfRows;
        private System.Windows.Forms.GroupBox groupBox_currentColor;
        private System.Windows.Forms.PictureBox pictureBox_chosenColor;
        private System.Windows.Forms.Label label_24bitVal;
        private System.Windows.Forms.Label label_15bit;
        private System.Windows.Forms.Label label_24bit;
        private System.Windows.Forms.Label label_15bitVal;
        private System.Windows.Forms.GroupBox groupBox_color;
        private System.Windows.Forms.Label label_hex_color;
        private Theming.CustomControls.FlatTextBox textBox_hex_color;
        private System.Windows.Forms.Label label_red;
        private System.Windows.Forms.Label label_green;
        private System.Windows.Forms.Label label_blue;
        private Theming.CustomControls.FlatNumericUpDown numericUpDown_red;
        private Theming.CustomControls.FlatNumericUpDown numericUpDown_green;
        private Theming.CustomControls.FlatNumericUpDown numericUpDown_blue;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_tile;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.ToolStripStatusLabel spring;
        private System.Windows.Forms.ToolStripDropDownButton button_apply;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_import;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_importRaw;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_importTLP;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_importYY;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_export;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_exportRaw;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_exportTLP;
        private System.Windows.Forms.ToolStripMenuItem statusStrip_exportYY;
        private Controls.ColorBar colorBar_red;
        private Controls.ColorBar colorBar_blue;
        private Controls.ColorBar colorBar_green;
        private System.Windows.Forms.GroupBox groupBox_map;
        private Controls.ExtendedPanel panel_palView;
        private Controls.TileDisplay tileDisplay_pal;
        private System.Windows.Forms.ToolStrip toolStrip_palette;
        private System.Windows.Forms.ToolStripSplitButton button_undo;
        private System.Windows.Forms.ToolStripSplitButton button_redo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton button_flipMapH;
        private System.Windows.Forms.ToolStripButton button_flipMapV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton button_grid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton button_mapZoomIn;
        private System.Windows.Forms.ToolStripButton button_mapZoomOut;
        private System.Windows.Forms.ToolStripLabel label_mapZoom;
    }
}