namespace mage
{
    partial class FormGraphics
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphics));
            groupBox_imageControl = new System.Windows.Forms.GroupBox();
            checkBox_compressed = new System.Windows.Forms.CheckBox();
            button_imageGo = new System.Windows.Forms.Button();
            label_height = new System.Windows.Forms.Label();
            label_width = new System.Windows.Forms.Label();
            numericUpDown_height = new Theming.CustomControls.FlatNumericUpDown();
            numericUpDown_width = new Theming.CustomControls.FlatNumericUpDown();
            textBox_imageOffset = new Theming.CustomControls.FlatTextBox();
            label_imageOffset = new System.Windows.Forms.Label();
            groupBox_image = new System.Windows.Forms.GroupBox();
            panel_gfx = new mage.Controls.ExtendedPanel();
            gfxView_gfx = new GfxView();
            textBox_palOffset = new Theming.CustomControls.FlatTextBox();
            label_paletteOffset = new System.Windows.Forms.Label();
            groupBox_paletteControl = new System.Windows.Forms.GroupBox();
            button_editPal = new System.Windows.Forms.Button();
            button_minus = new System.Windows.Forms.Button();
            button_plus = new System.Windows.Forms.Button();
            button_paletteGo = new System.Windows.Forms.Button();
            pictureBox_palette = new System.Windows.Forms.PictureBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_coor = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_size = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_spring = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_zoomLevel = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_zoom = new System.Windows.Forms.ToolStripDropDownButton();
            toolStrip_zoom1600 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom800 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom400 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom200 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom100 = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip = new System.Windows.Forms.MenuStrip();
            menuStrip_gfx = new System.Windows.Forms.ToolStripMenuItem();
            importToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_gfxImportRaw = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_gfxImportImg = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_gfxExport = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_gfxExportRaw = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            menuItem_gfxExportImg = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_pixelFormat = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_4bitIndexed = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_24bitRGB = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_32bitARGB = new System.Windows.Forms.ToolStripMenuItem();
            menuStrip_palette = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palImport = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palImport_raw = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palImport_tlp = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palImport_yychr = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palExport = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palExport_raw = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palExport_tlp = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palExport_yychr = new System.Windows.Forms.ToolStripMenuItem();
            groupBox_imageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_width).BeginInit();
            groupBox_image.SuspendLayout();
            panel_gfx.SuspendLayout();
            groupBox_paletteControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_palette).BeginInit();
            statusStrip.SuspendLayout();
            menuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_imageControl
            // 
            groupBox_imageControl.Controls.Add(checkBox_compressed);
            groupBox_imageControl.Controls.Add(button_imageGo);
            groupBox_imageControl.Controls.Add(label_height);
            groupBox_imageControl.Controls.Add(label_width);
            groupBox_imageControl.Controls.Add(numericUpDown_height);
            groupBox_imageControl.Controls.Add(numericUpDown_width);
            groupBox_imageControl.Controls.Add(textBox_imageOffset);
            groupBox_imageControl.Controls.Add(label_imageOffset);
            groupBox_imageControl.Location = new System.Drawing.Point(14, 31);
            groupBox_imageControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_imageControl.Name = "groupBox_imageControl";
            groupBox_imageControl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_imageControl.Size = new System.Drawing.Size(315, 84);
            groupBox_imageControl.TabIndex = 0;
            groupBox_imageControl.TabStop = false;
            groupBox_imageControl.Text = "Image Control";
            // 
            // checkBox_compressed
            // 
            checkBox_compressed.AutoSize = true;
            checkBox_compressed.Location = new System.Drawing.Point(210, 24);
            checkBox_compressed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_compressed.Name = "checkBox_compressed";
            checkBox_compressed.Size = new System.Drawing.Size(92, 19);
            checkBox_compressed.TabIndex = 2;
            checkBox_compressed.Text = "Compressed";
            checkBox_compressed.UseVisualStyleBackColor = true;
            checkBox_compressed.CheckedChanged += checkBox_compressed_CheckedChanged;
            // 
            // button_imageGo
            // 
            button_imageGo.Location = new System.Drawing.Point(135, 21);
            button_imageGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_imageGo.Name = "button_imageGo";
            button_imageGo.Size = new System.Drawing.Size(58, 25);
            button_imageGo.TabIndex = 1;
            button_imageGo.Text = "Go";
            button_imageGo.UseVisualStyleBackColor = true;
            button_imageGo.Click += button_imageGo_Click;
            // 
            // label_height
            // 
            label_height.AutoSize = true;
            label_height.Location = new System.Drawing.Point(132, 54);
            label_height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_height.Name = "label_height";
            label_height.Size = new System.Drawing.Size(46, 15);
            label_height.TabIndex = 0;
            label_height.Text = "Height:";
            // 
            // label_width
            // 
            label_width.AutoSize = true;
            label_width.Location = new System.Drawing.Point(7, 54);
            label_width.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_width.Name = "label_width";
            label_width.Size = new System.Drawing.Size(42, 15);
            label_width.TabIndex = 0;
            label_width.Text = "Width:";
            // 
            // numericUpDown_height
            // 
            numericUpDown_height.Location = new System.Drawing.Point(183, 52);
            numericUpDown_height.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_height.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDown_height.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_height.Name = "numericUpDown_height";
            numericUpDown_height.Size = new System.Drawing.Size(52, 23);
            numericUpDown_height.TabIndex = 4;
            numericUpDown_height.Value = new decimal(new int[] { 4, 0, 0, 0 });
            numericUpDown_height.ValueChanged += numericUpDown_height_ValueChanged;
            // 
            // numericUpDown_width
            // 
            numericUpDown_width.Location = new System.Drawing.Point(58, 52);
            numericUpDown_width.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_width.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDown_width.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_width.Name = "numericUpDown_width";
            numericUpDown_width.Size = new System.Drawing.Size(52, 23);
            numericUpDown_width.TabIndex = 3;
            numericUpDown_width.Value = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDown_width.ValueChanged += numericUpDown_width_ValueChanged;
            // 
            // textBox_imageOffset
            // 
            textBox_imageOffset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_imageOffset.DisplayBorder = true;
            textBox_imageOffset.Location = new System.Drawing.Point(58, 22);
            textBox_imageOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_imageOffset.MaxLength = 32767;
            textBox_imageOffset.Multiline = false;
            textBox_imageOffset.Name = "textBox_imageOffset";
            textBox_imageOffset.OnTextChanged = null;
            textBox_imageOffset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_imageOffset.PlaceholderText = "";
            textBox_imageOffset.ReadOnly = false;
            textBox_imageOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_imageOffset.SelectionStart = 0;
            textBox_imageOffset.Size = new System.Drawing.Size(70, 23);
            textBox_imageOffset.TabIndex = 0;
            textBox_imageOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_imageOffset.ValueBox = true;
            textBox_imageOffset.WordWrap = true;
            // 
            // label_imageOffset
            // 
            label_imageOffset.AutoSize = true;
            label_imageOffset.Location = new System.Drawing.Point(7, 25);
            label_imageOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_imageOffset.Name = "label_imageOffset";
            label_imageOffset.Size = new System.Drawing.Size(42, 15);
            label_imageOffset.TabIndex = 0;
            label_imageOffset.Text = "Offset:";
            // 
            // groupBox_image
            // 
            groupBox_image.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox_image.Controls.Add(panel_gfx);
            groupBox_image.Location = new System.Drawing.Point(14, 122);
            groupBox_image.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_image.Name = "groupBox_image";
            groupBox_image.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_image.Size = new System.Drawing.Size(656, 233);
            groupBox_image.TabIndex = 0;
            groupBox_image.TabStop = false;
            groupBox_image.Text = "Image";
            // 
            // panel_gfx
            // 
            panel_gfx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel_gfx.AutoScroll = true;
            panel_gfx.Controls.Add(gfxView_gfx);
            panel_gfx.Location = new System.Drawing.Point(7, 22);
            panel_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_gfx.Name = "panel_gfx";
            panel_gfx.Size = new System.Drawing.Size(640, 204);
            panel_gfx.TabIndex = 0;
            // 
            // gfxView_gfx
            // 
            gfxView_gfx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_gfx.Location = new System.Drawing.Point(0, 0);
            gfxView_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_gfx.Name = "gfxView_gfx";
            gfxView_gfx.Size = new System.Drawing.Size(621, 185);
            gfxView_gfx.TabIndex = 0;
            gfxView_gfx.TabStop = false;
            gfxView_gfx.MouseMove += gfxView_gfx_MouseMove;
            // 
            // textBox_palOffset
            // 
            textBox_palOffset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_palOffset.DisplayBorder = true;
            textBox_palOffset.Location = new System.Drawing.Point(58, 22);
            textBox_palOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_palOffset.MaxLength = 32767;
            textBox_palOffset.Multiline = false;
            textBox_palOffset.Name = "textBox_palOffset";
            textBox_palOffset.OnTextChanged = null;
            textBox_palOffset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_palOffset.PlaceholderText = "";
            textBox_palOffset.ReadOnly = false;
            textBox_palOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_palOffset.SelectionStart = 0;
            textBox_palOffset.Size = new System.Drawing.Size(70, 23);
            textBox_palOffset.TabIndex = 0;
            textBox_palOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_palOffset.ValueBox = true;
            textBox_palOffset.WordWrap = true;
            // 
            // label_paletteOffset
            // 
            label_paletteOffset.AutoSize = true;
            label_paletteOffset.Location = new System.Drawing.Point(7, 25);
            label_paletteOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_paletteOffset.Name = "label_paletteOffset";
            label_paletteOffset.Size = new System.Drawing.Size(42, 15);
            label_paletteOffset.TabIndex = 0;
            label_paletteOffset.Text = "Offset:";
            // 
            // groupBox_paletteControl
            // 
            groupBox_paletteControl.Controls.Add(button_editPal);
            groupBox_paletteControl.Controls.Add(button_minus);
            groupBox_paletteControl.Controls.Add(button_plus);
            groupBox_paletteControl.Controls.Add(button_paletteGo);
            groupBox_paletteControl.Controls.Add(pictureBox_palette);
            groupBox_paletteControl.Controls.Add(textBox_palOffset);
            groupBox_paletteControl.Controls.Add(label_paletteOffset);
            groupBox_paletteControl.Location = new System.Drawing.Point(336, 31);
            groupBox_paletteControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_paletteControl.Name = "groupBox_paletteControl";
            groupBox_paletteControl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_paletteControl.Size = new System.Drawing.Size(332, 84);
            groupBox_paletteControl.TabIndex = 1;
            groupBox_paletteControl.TabStop = false;
            groupBox_paletteControl.Text = "Palette Control";
            // 
            // button_editPal
            // 
            button_editPal.Location = new System.Drawing.Point(273, 21);
            button_editPal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_editPal.Name = "button_editPal";
            button_editPal.Size = new System.Drawing.Size(52, 25);
            button_editPal.TabIndex = 4;
            button_editPal.Text = "Edit";
            button_editPal.UseVisualStyleBackColor = true;
            button_editPal.Click += button_editPal_Click;
            // 
            // button_minus
            // 
            button_minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button_minus.Location = new System.Drawing.Point(233, 21);
            button_minus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_minus.Name = "button_minus";
            button_minus.Size = new System.Drawing.Size(26, 25);
            button_minus.TabIndex = 3;
            button_minus.Text = "-";
            button_minus.UseVisualStyleBackColor = true;
            button_minus.Click += button_minus_Click;
            // 
            // button_plus
            // 
            button_plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button_plus.Location = new System.Drawing.Point(201, 21);
            button_plus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_plus.Name = "button_plus";
            button_plus.Size = new System.Drawing.Size(26, 25);
            button_plus.TabIndex = 2;
            button_plus.Text = "+";
            button_plus.UseVisualStyleBackColor = true;
            button_plus.Click += button_plus_Click;
            // 
            // button_paletteGo
            // 
            button_paletteGo.Location = new System.Drawing.Point(135, 21);
            button_paletteGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_paletteGo.Name = "button_paletteGo";
            button_paletteGo.Size = new System.Drawing.Size(58, 25);
            button_paletteGo.TabIndex = 1;
            button_paletteGo.Text = "Go";
            button_paletteGo.UseVisualStyleBackColor = true;
            button_paletteGo.Click += button_paletteGo_Click;
            // 
            // pictureBox_palette
            // 
            pictureBox_palette.Location = new System.Drawing.Point(7, 54);
            pictureBox_palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_palette.Name = "pictureBox_palette";
            pictureBox_palette.Size = new System.Drawing.Size(318, 21);
            pictureBox_palette.TabIndex = 4;
            pictureBox_palette.TabStop = false;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_coor, statusLabel_size, statusLabel_changes, statusStrip_spring, statusLabel_zoomLevel, statusStrip_zoom });
            statusStrip.Location = new System.Drawing.Point(0, 362);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(684, 22);
            statusStrip.TabIndex = 0;
            statusStrip.Text = "statusStrip";
            // 
            // statusLabel_coor
            // 
            statusLabel_coor.AutoSize = false;
            statusLabel_coor.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            statusLabel_coor.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            statusLabel_coor.Name = "statusLabel_coor";
            statusLabel_coor.Size = new System.Drawing.Size(70, 17);
            statusLabel_coor.Text = "(0, 0)";
            statusLabel_coor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel_size
            // 
            statusLabel_size.AutoSize = false;
            statusLabel_size.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            statusLabel_size.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            statusLabel_size.Name = "statusLabel_size";
            statusLabel_size.Size = new System.Drawing.Size(70, 17);
            statusLabel_size.Text = "0 x 0";
            statusLabel_size.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 17);
            statusLabel_changes.Text = "-";
            // 
            // statusStrip_spring
            // 
            statusStrip_spring.Name = "statusStrip_spring";
            statusStrip_spring.Size = new System.Drawing.Size(451, 17);
            statusStrip_spring.Spring = true;
            // 
            // statusLabel_zoomLevel
            // 
            statusLabel_zoomLevel.Name = "statusLabel_zoomLevel";
            statusLabel_zoomLevel.Size = new System.Drawing.Size(35, 17);
            statusLabel_zoomLevel.Text = "100%";
            // 
            // statusStrip_zoom
            // 
            statusStrip_zoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            statusStrip_zoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            statusStrip_zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStrip_zoom1600, toolStrip_zoom800, toolStrip_zoom400, toolStrip_zoom200, toolStrip_zoom100 });
            statusStrip_zoom.Image = Properties.Resources.toolbar_zoom;
            statusStrip_zoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            statusStrip_zoom.Name = "statusStrip_zoom";
            statusStrip_zoom.Size = new System.Drawing.Size(29, 20);
            statusStrip_zoom.Text = "Zoom";
            // 
            // toolStrip_zoom1600
            // 
            toolStrip_zoom1600.Name = "toolStrip_zoom1600";
            toolStrip_zoom1600.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoom1600.Text = "1600%";
            toolStrip_zoom1600.Click += toolStrip_zoom1600_Click;
            // 
            // toolStrip_zoom800
            // 
            toolStrip_zoom800.Name = "toolStrip_zoom800";
            toolStrip_zoom800.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoom800.Text = "800%";
            toolStrip_zoom800.Click += toolStrip_zoom800_Click;
            // 
            // toolStrip_zoom400
            // 
            toolStrip_zoom400.Name = "toolStrip_zoom400";
            toolStrip_zoom400.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoom400.Text = "400%";
            toolStrip_zoom400.Click += toolStrip_zoom400_Click;
            // 
            // toolStrip_zoom200
            // 
            toolStrip_zoom200.Name = "toolStrip_zoom200";
            toolStrip_zoom200.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoom200.Text = "200%";
            toolStrip_zoom200.Click += toolStrip_zoom200_Click;
            // 
            // toolStrip_zoom100
            // 
            toolStrip_zoom100.Name = "toolStrip_zoom100";
            toolStrip_zoom100.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoom100.Text = "100%";
            toolStrip_zoom100.Click += toolStrip_zoom100_Click;
            // 
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { menuStrip_gfx, menuStrip_palette });
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            menuStrip.Size = new System.Drawing.Size(684, 24);
            menuStrip.TabIndex = 0;
            // 
            // menuStrip_gfx
            // 
            menuStrip_gfx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { importToolStripMenuItem, menuItem_gfxExport });
            menuStrip_gfx.Name = "menuStrip_gfx";
            menuStrip_gfx.Size = new System.Drawing.Size(65, 20);
            menuStrip_gfx.Text = "Graphics";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem_gfxImportRaw, menuItem_gfxImportImg });
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            importToolStripMenuItem.Text = "Import";
            // 
            // menuItem_gfxImportRaw
            // 
            menuItem_gfxImportRaw.Name = "menuItem_gfxImportRaw";
            menuItem_gfxImportRaw.Size = new System.Drawing.Size(116, 22);
            menuItem_gfxImportRaw.Text = "Raw...";
            menuItem_gfxImportRaw.Click += menuItem_gfxImportRaw_Click;
            // 
            // menuItem_gfxImportImg
            // 
            menuItem_gfxImportImg.Name = "menuItem_gfxImportImg";
            menuItem_gfxImportImg.Size = new System.Drawing.Size(116, 22);
            menuItem_gfxImportImg.Text = "Image...";
            menuItem_gfxImportImg.Click += menuItem_gfxImportImg_Click;
            // 
            // menuItem_gfxExport
            // 
            menuItem_gfxExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem_gfxExportRaw, toolStripSeparator1, menuItem_gfxExportImg, menuItem_pixelFormat });
            menuItem_gfxExport.Name = "menuItem_gfxExport";
            menuItem_gfxExport.Size = new System.Drawing.Size(110, 22);
            menuItem_gfxExport.Text = "Export";
            // 
            // menuItem_gfxExportRaw
            // 
            menuItem_gfxExportRaw.Name = "menuItem_gfxExportRaw";
            menuItem_gfxExportRaw.Size = new System.Drawing.Size(140, 22);
            menuItem_gfxExportRaw.Text = "Raw...";
            menuItem_gfxExportRaw.Click += menuItem_gfxExportRaw_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new System.Drawing.Size(137, 6);
            // 
            // menuItem_gfxExportImg
            // 
            menuItem_gfxExportImg.Name = "menuItem_gfxExportImg";
            menuItem_gfxExportImg.Size = new System.Drawing.Size(140, 22);
            menuItem_gfxExportImg.Text = "Image...";
            menuItem_gfxExportImg.Click += menuItem_gfxExportImg_Click;
            // 
            // menuItem_pixelFormat
            // 
            menuItem_pixelFormat.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem_4bitIndexed, menuItem_24bitRGB, menuItem_32bitARGB });
            menuItem_pixelFormat.Name = "menuItem_pixelFormat";
            menuItem_pixelFormat.Size = new System.Drawing.Size(140, 22);
            menuItem_pixelFormat.Text = "Pixel Format";
            // 
            // menuItem_4bitIndexed
            // 
            menuItem_4bitIndexed.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            menuItem_4bitIndexed.Name = "menuItem_4bitIndexed";
            menuItem_4bitIndexed.Size = new System.Drawing.Size(144, 22);
            menuItem_4bitIndexed.Text = "4-bit Indexed";
            menuItem_4bitIndexed.Click += menuItem_pixelFormat_Click;
            // 
            // menuItem_24bitRGB
            // 
            menuItem_24bitRGB.Checked = true;
            menuItem_24bitRGB.CheckState = System.Windows.Forms.CheckState.Checked;
            menuItem_24bitRGB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            menuItem_24bitRGB.Name = "menuItem_24bitRGB";
            menuItem_24bitRGB.Size = new System.Drawing.Size(144, 22);
            menuItem_24bitRGB.Text = "24-bit RGB";
            menuItem_24bitRGB.Click += menuItem_pixelFormat_Click;
            // 
            // menuItem_32bitARGB
            // 
            menuItem_32bitARGB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            menuItem_32bitARGB.Name = "menuItem_32bitARGB";
            menuItem_32bitARGB.Size = new System.Drawing.Size(144, 22);
            menuItem_32bitARGB.Text = "32-bit ARGB";
            menuItem_32bitARGB.Click += menuItem_pixelFormat_Click;
            // 
            // menuStrip_palette
            // 
            menuStrip_palette.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem_palImport, menuItem_palExport });
            menuStrip_palette.Name = "menuStrip_palette";
            menuStrip_palette.Size = new System.Drawing.Size(55, 20);
            menuStrip_palette.Text = "Palette";
            // 
            // menuItem_palImport
            // 
            menuItem_palImport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem_palImport_raw, menuItem_palImport_tlp, menuItem_palImport_yychr });
            menuItem_palImport.Name = "menuItem_palImport";
            menuItem_palImport.Size = new System.Drawing.Size(110, 22);
            menuItem_palImport.Text = "Import";
            // 
            // menuItem_palImport_raw
            // 
            menuItem_palImport_raw.Name = "menuItem_palImport_raw";
            menuItem_palImport_raw.Size = new System.Drawing.Size(153, 22);
            menuItem_palImport_raw.Text = "Raw...";
            menuItem_palImport_raw.Click += menuItem_palImport_raw_Click;
            // 
            // menuItem_palImport_tlp
            // 
            menuItem_palImport_tlp.Name = "menuItem_palImport_tlp";
            menuItem_palImport_tlp.Size = new System.Drawing.Size(153, 22);
            menuItem_palImport_tlp.Text = "Tile Layer Pro...";
            menuItem_palImport_tlp.Click += menuItem_palImport_tlp_Click;
            // 
            // menuItem_palImport_yychr
            // 
            menuItem_palImport_yychr.Name = "menuItem_palImport_yychr";
            menuItem_palImport_yychr.Size = new System.Drawing.Size(153, 22);
            menuItem_palImport_yychr.Text = "YY-CHR...";
            menuItem_palImport_yychr.Click += menuItem_palImport_yychr_Click;
            // 
            // menuItem_palExport
            // 
            menuItem_palExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem_palExport_raw, menuItem_palExport_tlp, menuItem_palExport_yychr });
            menuItem_palExport.Name = "menuItem_palExport";
            menuItem_palExport.Size = new System.Drawing.Size(110, 22);
            menuItem_palExport.Text = "Export";
            // 
            // menuItem_palExport_raw
            // 
            menuItem_palExport_raw.Name = "menuItem_palExport_raw";
            menuItem_palExport_raw.Size = new System.Drawing.Size(153, 22);
            menuItem_palExport_raw.Text = "Raw...";
            menuItem_palExport_raw.Click += menuItem_palExport_raw_Click;
            // 
            // menuItem_palExport_tlp
            // 
            menuItem_palExport_tlp.Name = "menuItem_palExport_tlp";
            menuItem_palExport_tlp.Size = new System.Drawing.Size(153, 22);
            menuItem_palExport_tlp.Text = "Tile Layer Pro...";
            menuItem_palExport_tlp.Click += menuItem_palExport_tlp_Click;
            // 
            // menuItem_palExport_yychr
            // 
            menuItem_palExport_yychr.Name = "menuItem_palExport_yychr";
            menuItem_palExport_yychr.Size = new System.Drawing.Size(153, 22);
            menuItem_palExport_yychr.Text = "YY-CHR...";
            menuItem_palExport_yychr.Click += menuItem_palExport_yychr_Click;
            // 
            // FormGraphics
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(684, 384);
            Controls.Add(statusStrip);
            Controls.Add(menuStrip);
            Controls.Add(groupBox_paletteControl);
            Controls.Add(groupBox_image);
            Controls.Add(groupBox_imageControl);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(613, 390);
            Name = "FormGraphics";
            Text = "Graphics Editor";
            groupBox_imageControl.ResumeLayout(false);
            groupBox_imageControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_width).EndInit();
            groupBox_image.ResumeLayout(false);
            panel_gfx.ResumeLayout(false);
            groupBox_paletteControl.ResumeLayout(false);
            groupBox_paletteControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_palette).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_imageControl;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Label label_width;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_height;
        private mage.Theming.CustomControls.FlatNumericUpDown numericUpDown_width;
        private mage.Theming.CustomControls.FlatTextBox textBox_palOffset;
        private System.Windows.Forms.Label label_paletteOffset;
        private mage.Theming.CustomControls.FlatTextBox textBox_imageOffset;
        private System.Windows.Forms.Label label_imageOffset;
        private System.Windows.Forms.GroupBox groupBox_image;
        private System.Windows.Forms.GroupBox groupBox_paletteControl;
        private System.Windows.Forms.PictureBox pictureBox_palette;
        private System.Windows.Forms.Button button_imageGo;
        private System.Windows.Forms.Button button_paletteGo;
        private System.Windows.Forms.Panel panel_gfx;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_coor;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_zoom;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom1600;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom400;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom800;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom200;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom100;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_zoomLevel;
        private System.Windows.Forms.CheckBox checkBox_compressed;
        private System.Windows.Forms.Button button_minus;
        private System.Windows.Forms.Button button_plus;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip_spring;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_gfx;
        private System.Windows.Forms.ToolStripMenuItem menuStrip_palette;
        private System.Windows.Forms.ToolStripMenuItem menuItem_gfxExport;
        private System.Windows.Forms.ToolStripMenuItem importToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem_gfxExportImg;
        private System.Windows.Forms.ToolStripMenuItem menuItem_gfxExportRaw;
        private System.Windows.Forms.ToolStripMenuItem menuItem_gfxImportImg;
        private System.Windows.Forms.ToolStripMenuItem menuItem_gfxImportRaw;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palExport;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palImport;
        private System.Windows.Forms.Button button_editPal;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_size;
        private GfxView gfxView_gfx;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_pixelFormat;
        private System.Windows.Forms.ToolStripMenuItem menuItem_4bitIndexed;
        private System.Windows.Forms.ToolStripMenuItem menuItem_24bitRGB;
        private System.Windows.Forms.ToolStripMenuItem menuItem_32bitARGB;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palImport_raw;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palImport_tlp;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palImport_yychr;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palExport_raw;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palExport_tlp;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palExport_yychr;
    }
}