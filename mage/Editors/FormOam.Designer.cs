namespace mage
{
    partial class FormOam
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOam));
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
            panel_gfx = new System.Windows.Forms.Panel();
            gfxView_gfx = new GfxView();
            statusStrip_gfx = new System.Windows.Forms.StatusStrip();
            statusLabel_coor = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_size = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_spring = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip_zoom = new System.Windows.Forms.ToolStripDropDownButton();
            toolStrip_zoom1600 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom800 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom400 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom200 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoom100 = new System.Windows.Forms.ToolStripMenuItem();
            textBox_palOffset = new Theming.CustomControls.FlatTextBox();
            label_paletteOffset = new System.Windows.Forms.Label();
            groupBox_paletteControl = new System.Windows.Forms.GroupBox();
            button_editPal = new System.Windows.Forms.Button();
            button_minus = new System.Windows.Forms.Button();
            button_plus = new System.Windows.Forms.Button();
            button_paletteGo = new System.Windows.Forms.Button();
            pictureBox_palette = new System.Windows.Forms.PictureBox();
            menuStrip = new System.Windows.Forms.MenuStrip();
            groupBox_oam = new System.Windows.Forms.GroupBox();
            button_playAnimation = new System.Windows.Forms.Button();
            textBox_duration = new Theming.CustomControls.FlatTextBox();
            label_frameDuration = new System.Windows.Forms.Label();
            comboBox_Frame = new Theming.CustomControls.FlatComboBox();
            label_OAMFrame = new System.Windows.Forms.Label();
            button_oamGo = new System.Windows.Forms.Button();
            textBox_oamOffset = new Theming.CustomControls.FlatTextBox();
            label_OAMOffset = new System.Windows.Forms.Label();
            groupBox_part = new System.Windows.Forms.GroupBox();
            groupBox_oamDisplay = new System.Windows.Forms.GroupBox();
            panel_oam = new System.Windows.Forms.Panel();
            oamView_oam = new OamView();
            statusStrip_oam = new System.Windows.Forms.StatusStrip();
            toolStrip_coorOam = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip_sizeOam = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip_springOam = new System.Windows.Forms.ToolStripStatusLabel();
            toolStrip_oamView = new System.Windows.Forms.ToolStripDropDownButton();
            toolStrip_origin = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_partOutline = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoomOam = new System.Windows.Forms.ToolStripDropDownButton();
            toolStrip_zoomOam1600 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoomOam800 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoomOam400 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoomOam200 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip_zoomOam100 = new System.Windows.Forms.ToolStripMenuItem();
            splitContainer_main = new System.Windows.Forms.SplitContainer();
            statusStrip_main = new System.Windows.Forms.StatusStrip();
            groupBox_imageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_width).BeginInit();
            groupBox_image.SuspendLayout();
            panel_gfx.SuspendLayout();
            statusStrip_gfx.SuspendLayout();
            groupBox_paletteControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_palette).BeginInit();
            groupBox_oam.SuspendLayout();
            groupBox_oamDisplay.SuspendLayout();
            panel_oam.SuspendLayout();
            statusStrip_oam.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_main).BeginInit();
            splitContainer_main.Panel1.SuspendLayout();
            splitContainer_main.Panel2.SuspendLayout();
            splitContainer_main.SuspendLayout();
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
            groupBox_imageControl.Location = new System.Drawing.Point(13, 3);
            groupBox_imageControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_imageControl.Name = "groupBox_imageControl";
            groupBox_imageControl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_imageControl.Size = new System.Drawing.Size(331, 84);
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
            textBox_imageOffset.ReadOnly = false;
            textBox_imageOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_imageOffset.SelectionStart = 0;
            textBox_imageOffset.Size = new System.Drawing.Size(70, 23);
            textBox_imageOffset.TabIndex = 0;
            textBox_imageOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            groupBox_image.Controls.Add(statusStrip_gfx);
            groupBox_image.Location = new System.Drawing.Point(13, 98);
            groupBox_image.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_image.Name = "groupBox_image";
            groupBox_image.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_image.Size = new System.Drawing.Size(671, 207);
            groupBox_image.TabIndex = 0;
            groupBox_image.TabStop = false;
            groupBox_image.Text = "Graphics";
            // 
            // panel_gfx
            // 
            panel_gfx.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel_gfx.AutoScroll = true;
            panel_gfx.Controls.Add(gfxView_gfx);
            panel_gfx.Location = new System.Drawing.Point(7, 22);
            panel_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_gfx.Name = "panel_gfx";
            panel_gfx.Size = new System.Drawing.Size(655, 157);
            panel_gfx.TabIndex = 0;
            // 
            // gfxView_gfx
            // 
            gfxView_gfx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_gfx.Location = new System.Drawing.Point(0, 0);
            gfxView_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_gfx.Name = "gfxView_gfx";
            gfxView_gfx.Size = new System.Drawing.Size(275, 114);
            gfxView_gfx.TabIndex = 0;
            gfxView_gfx.TabStop = false;
            gfxView_gfx.MouseMove += gfxView_gfx_MouseMove;
            // 
            // statusStrip_gfx
            // 
            statusStrip_gfx.ImageScalingSize = new System.Drawing.Size(40, 40);
            statusStrip_gfx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_coor, statusLabel_size, statusStrip_spring, statusStrip_zoom });
            statusStrip_gfx.Location = new System.Drawing.Point(4, 182);
            statusStrip_gfx.Name = "statusStrip_gfx";
            statusStrip_gfx.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip_gfx.Size = new System.Drawing.Size(663, 22);
            statusStrip_gfx.SizingGrip = false;
            statusStrip_gfx.TabIndex = 0;
            statusStrip_gfx.Text = "statusStrip";
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
            // statusStrip_spring
            // 
            statusStrip_spring.Name = "statusStrip_spring";
            statusStrip_spring.Size = new System.Drawing.Size(442, 17);
            statusStrip_spring.Spring = true;
            // 
            // statusStrip_zoom
            // 
            statusStrip_zoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            statusStrip_zoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStrip_zoom1600, toolStrip_zoom800, toolStrip_zoom400, toolStrip_zoom200, toolStrip_zoom100 });
            statusStrip_zoom.Image = Properties.Resources.toolbar_zoom;
            statusStrip_zoom.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            statusStrip_zoom.Name = "statusStrip_zoom";
            statusStrip_zoom.Size = new System.Drawing.Size(64, 20);
            statusStrip_zoom.Text = "100%";
            statusStrip_zoom.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
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
            // textBox_palOffset
            // 
            textBox_palOffset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_palOffset.DisplayBorder = true;
            textBox_palOffset.Location = new System.Drawing.Point(57, 22);
            textBox_palOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_palOffset.MaxLength = 32767;
            textBox_palOffset.Multiline = false;
            textBox_palOffset.Name = "textBox_palOffset";
            textBox_palOffset.OnTextChanged = null;
            textBox_palOffset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_palOffset.ReadOnly = false;
            textBox_palOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_palOffset.SelectionStart = 0;
            textBox_palOffset.Size = new System.Drawing.Size(70, 23);
            textBox_palOffset.TabIndex = 0;
            textBox_palOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
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
            groupBox_paletteControl.Location = new System.Drawing.Point(352, 3);
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
            button_editPal.Location = new System.Drawing.Point(269, 20);
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
            button_minus.Location = new System.Drawing.Point(235, 21);
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
            // menuStrip
            // 
            menuStrip.ImageScalingSize = new System.Drawing.Size(40, 40);
            menuStrip.Location = new System.Drawing.Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            menuStrip.Size = new System.Drawing.Size(697, 24);
            menuStrip.TabIndex = 0;
            // 
            // groupBox_oam
            // 
            groupBox_oam.Controls.Add(button_playAnimation);
            groupBox_oam.Controls.Add(textBox_duration);
            groupBox_oam.Controls.Add(label_frameDuration);
            groupBox_oam.Controls.Add(comboBox_Frame);
            groupBox_oam.Controls.Add(label_OAMFrame);
            groupBox_oam.Controls.Add(button_oamGo);
            groupBox_oam.Controls.Add(textBox_oamOffset);
            groupBox_oam.Controls.Add(label_OAMOffset);
            groupBox_oam.Location = new System.Drawing.Point(13, 3);
            groupBox_oam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_oam.Name = "groupBox_oam";
            groupBox_oam.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_oam.Size = new System.Drawing.Size(215, 115);
            groupBox_oam.TabIndex = 2;
            groupBox_oam.TabStop = false;
            groupBox_oam.Text = "OAM Control";
            // 
            // button_playAnimation
            // 
            button_playAnimation.Image = Properties.Resources.toolbar_test;
            button_playAnimation.Location = new System.Drawing.Point(149, 49);
            button_playAnimation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_playAnimation.Name = "button_playAnimation";
            button_playAnimation.Size = new System.Drawing.Size(58, 25);
            button_playAnimation.TabIndex = 7;
            button_playAnimation.UseVisualStyleBackColor = true;
            button_playAnimation.Click += button_playAnimation_Click;
            // 
            // textBox_duration
            // 
            textBox_duration.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_duration.DisplayBorder = true;
            textBox_duration.Location = new System.Drawing.Point(71, 80);
            textBox_duration.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_duration.MaxLength = 32767;
            textBox_duration.Multiline = false;
            textBox_duration.Name = "textBox_duration";
            textBox_duration.OnTextChanged = null;
            textBox_duration.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_duration.ReadOnly = false;
            textBox_duration.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_duration.SelectionStart = 0;
            textBox_duration.Size = new System.Drawing.Size(70, 23);
            textBox_duration.TabIndex = 6;
            textBox_duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_duration.WordWrap = true;
            // 
            // label_frameDuration
            // 
            label_frameDuration.AutoSize = true;
            label_frameDuration.Location = new System.Drawing.Point(8, 83);
            label_frameDuration.Name = "label_frameDuration";
            label_frameDuration.Size = new System.Drawing.Size(56, 15);
            label_frameDuration.TabIndex = 5;
            label_frameDuration.Text = "Duration:";
            // 
            // comboBox_Frame
            // 
            comboBox_Frame.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_Frame.FormattingEnabled = true;
            comboBox_Frame.Location = new System.Drawing.Point(71, 51);
            comboBox_Frame.Name = "comboBox_Frame";
            comboBox_Frame.Size = new System.Drawing.Size(70, 23);
            comboBox_Frame.TabIndex = 4;
            comboBox_Frame.SelectedIndexChanged += comboBox_Frame_SelectedIndexChanged;
            // 
            // label_OAMFrame
            // 
            label_OAMFrame.AutoSize = true;
            label_OAMFrame.Location = new System.Drawing.Point(8, 54);
            label_OAMFrame.Name = "label_OAMFrame";
            label_OAMFrame.Size = new System.Drawing.Size(43, 15);
            label_OAMFrame.TabIndex = 3;
            label_OAMFrame.Text = "Frame:";
            // 
            // button_oamGo
            // 
            button_oamGo.Location = new System.Drawing.Point(149, 20);
            button_oamGo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_oamGo.Name = "button_oamGo";
            button_oamGo.Size = new System.Drawing.Size(58, 25);
            button_oamGo.TabIndex = 1;
            button_oamGo.Text = "Go";
            button_oamGo.UseVisualStyleBackColor = true;
            button_oamGo.Click += button_oamGo_Click;
            // 
            // textBox_oamOffset
            // 
            textBox_oamOffset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_oamOffset.DisplayBorder = true;
            textBox_oamOffset.Location = new System.Drawing.Point(71, 22);
            textBox_oamOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_oamOffset.MaxLength = 32767;
            textBox_oamOffset.Multiline = false;
            textBox_oamOffset.Name = "textBox_oamOffset";
            textBox_oamOffset.OnTextChanged = null;
            textBox_oamOffset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_oamOffset.ReadOnly = false;
            textBox_oamOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_oamOffset.SelectionStart = 0;
            textBox_oamOffset.Size = new System.Drawing.Size(70, 23);
            textBox_oamOffset.TabIndex = 0;
            textBox_oamOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_oamOffset.WordWrap = true;
            // 
            // label_OAMOffset
            // 
            label_OAMOffset.AutoSize = true;
            label_OAMOffset.Location = new System.Drawing.Point(8, 25);
            label_OAMOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_OAMOffset.Name = "label_OAMOffset";
            label_OAMOffset.Size = new System.Drawing.Size(42, 15);
            label_OAMOffset.TabIndex = 0;
            label_OAMOffset.Text = "Offset:";
            // 
            // groupBox_part
            // 
            groupBox_part.Location = new System.Drawing.Point(13, 124);
            groupBox_part.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_part.Name = "groupBox_part";
            groupBox_part.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_part.Size = new System.Drawing.Size(215, 272);
            groupBox_part.TabIndex = 5;
            groupBox_part.TabStop = false;
            groupBox_part.Text = "Part Details";
            // 
            // groupBox_oamDisplay
            // 
            groupBox_oamDisplay.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox_oamDisplay.Controls.Add(panel_oam);
            groupBox_oamDisplay.Controls.Add(statusStrip_oam);
            groupBox_oamDisplay.Location = new System.Drawing.Point(236, 3);
            groupBox_oamDisplay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_oamDisplay.Name = "groupBox_oamDisplay";
            groupBox_oamDisplay.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_oamDisplay.Size = new System.Drawing.Size(448, 393);
            groupBox_oamDisplay.TabIndex = 1;
            groupBox_oamDisplay.TabStop = false;
            groupBox_oamDisplay.Text = "OAM Frame";
            // 
            // panel_oam
            // 
            panel_oam.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel_oam.AutoScroll = true;
            panel_oam.Controls.Add(oamView_oam);
            panel_oam.Location = new System.Drawing.Point(8, 22);
            panel_oam.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panel_oam.Name = "panel_oam";
            panel_oam.Size = new System.Drawing.Size(431, 343);
            panel_oam.TabIndex = 0;
            // 
            // oamView_oam
            // 
            oamView_oam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            oamView_oam.DisplayOrigin = true;
            oamView_oam.Location = new System.Drawing.Point(0, 0);
            oamView_oam.Name = "oamView_oam";
            oamView_oam.OamImage = null;
            oamView_oam.Size = new System.Drawing.Size(208, 93);
            oamView_oam.TabIndex = 1;
            oamView_oam.TabStop = false;
            oamView_oam.Text = "oamView1";
            oamView_oam.Zoom = 0;
            // 
            // statusStrip_oam
            // 
            statusStrip_oam.ImageScalingSize = new System.Drawing.Size(40, 40);
            statusStrip_oam.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStrip_coorOam, toolStrip_sizeOam, toolStrip_springOam, toolStrip_oamView, toolStrip_zoomOam });
            statusStrip_oam.Location = new System.Drawing.Point(4, 368);
            statusStrip_oam.Name = "statusStrip_oam";
            statusStrip_oam.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip_oam.Size = new System.Drawing.Size(440, 22);
            statusStrip_oam.SizingGrip = false;
            statusStrip_oam.TabIndex = 1;
            statusStrip_oam.Text = "statusStrip";
            // 
            // toolStrip_coorOam
            // 
            toolStrip_coorOam.AutoSize = false;
            toolStrip_coorOam.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            toolStrip_coorOam.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            toolStrip_coorOam.Name = "toolStrip_coorOam";
            toolStrip_coorOam.Size = new System.Drawing.Size(70, 17);
            toolStrip_coorOam.Text = "(0, 0)";
            toolStrip_coorOam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip_sizeOam
            // 
            toolStrip_sizeOam.AutoSize = false;
            toolStrip_sizeOam.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            toolStrip_sizeOam.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            toolStrip_sizeOam.Name = "toolStrip_sizeOam";
            toolStrip_sizeOam.Size = new System.Drawing.Size(70, 17);
            toolStrip_sizeOam.Text = "0 x 0";
            toolStrip_sizeOam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStrip_springOam
            // 
            toolStrip_springOam.Name = "toolStrip_springOam";
            toolStrip_springOam.Size = new System.Drawing.Size(143, 17);
            toolStrip_springOam.Spring = true;
            // 
            // toolStrip_oamView
            // 
            toolStrip_oamView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            toolStrip_oamView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStrip_origin, toolStrip_partOutline });
            toolStrip_oamView.Image = (System.Drawing.Image)resources.GetObject("toolStrip_oamView.Image");
            toolStrip_oamView.ImageTransparentColor = System.Drawing.Color.Magenta;
            toolStrip_oamView.Name = "toolStrip_oamView";
            toolStrip_oamView.Size = new System.Drawing.Size(45, 20);
            toolStrip_oamView.Text = "View";
            // 
            // toolStrip_origin
            // 
            toolStrip_origin.Checked = true;
            toolStrip_origin.CheckState = System.Windows.Forms.CheckState.Checked;
            toolStrip_origin.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStrip_origin.Name = "toolStrip_origin";
            toolStrip_origin.Size = new System.Drawing.Size(180, 22);
            toolStrip_origin.Text = "Origin";
            toolStrip_origin.Click += toolStrip_origin_Click;
            // 
            // toolStrip_partOutline
            // 
            toolStrip_partOutline.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStrip_partOutline.Name = "toolStrip_partOutline";
            toolStrip_partOutline.Size = new System.Drawing.Size(180, 22);
            toolStrip_partOutline.Text = "Part outline";
            toolStrip_partOutline.Click += toolStrip_partOutline_Click;
            // 
            // toolStrip_zoomOam
            // 
            toolStrip_zoomOam.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            toolStrip_zoomOam.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { toolStrip_zoomOam1600, toolStrip_zoomOam800, toolStrip_zoomOam400, toolStrip_zoomOam200, toolStrip_zoomOam100 });
            toolStrip_zoomOam.Image = Properties.Resources.toolbar_zoom;
            toolStrip_zoomOam.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            toolStrip_zoomOam.Name = "toolStrip_zoomOam";
            toolStrip_zoomOam.Size = new System.Drawing.Size(64, 20);
            toolStrip_zoomOam.Text = "100%";
            toolStrip_zoomOam.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // toolStrip_zoomOam1600
            // 
            toolStrip_zoomOam1600.Name = "toolStrip_zoomOam1600";
            toolStrip_zoomOam1600.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoomOam1600.Text = "1600%";
            toolStrip_zoomOam1600.Click += toolStrip_zoomOam1600_Click;
            // 
            // toolStrip_zoomOam800
            // 
            toolStrip_zoomOam800.Name = "toolStrip_zoomOam800";
            toolStrip_zoomOam800.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoomOam800.Text = "800%";
            toolStrip_zoomOam800.Click += toolStrip_zoomOam800_Click;
            // 
            // toolStrip_zoomOam400
            // 
            toolStrip_zoomOam400.Name = "toolStrip_zoomOam400";
            toolStrip_zoomOam400.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoomOam400.Text = "400%";
            toolStrip_zoomOam400.Click += toolStrip_zoomOam400_Click;
            // 
            // toolStrip_zoomOam200
            // 
            toolStrip_zoomOam200.Name = "toolStrip_zoomOam200";
            toolStrip_zoomOam200.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoomOam200.Text = "200%";
            toolStrip_zoomOam200.Click += toolStrip_zoomOam200_Click;
            // 
            // toolStrip_zoomOam100
            // 
            toolStrip_zoomOam100.Name = "toolStrip_zoomOam100";
            toolStrip_zoomOam100.Size = new System.Drawing.Size(108, 22);
            toolStrip_zoomOam100.Text = "100%";
            toolStrip_zoomOam100.Click += toolStrip_zoomOam100_Click;
            // 
            // splitContainer_main
            // 
            splitContainer_main.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainer_main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            splitContainer_main.Location = new System.Drawing.Point(0, 24);
            splitContainer_main.Name = "splitContainer_main";
            splitContainer_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_main.Panel1
            // 
            splitContainer_main.Panel1.Controls.Add(groupBox_imageControl);
            splitContainer_main.Panel1.Controls.Add(groupBox_image);
            splitContainer_main.Panel1.Controls.Add(groupBox_paletteControl);
            // 
            // splitContainer_main.Panel2
            // 
            splitContainer_main.Panel2.Controls.Add(statusStrip_main);
            splitContainer_main.Panel2.Controls.Add(groupBox_part);
            splitContainer_main.Panel2.Controls.Add(groupBox_oamDisplay);
            splitContainer_main.Panel2.Controls.Add(groupBox_oam);
            splitContainer_main.Size = new System.Drawing.Size(697, 739);
            splitContainer_main.SplitterDistance = 308;
            splitContainer_main.TabIndex = 6;
            // 
            // statusStrip_main
            // 
            statusStrip_main.Location = new System.Drawing.Point(0, 405);
            statusStrip_main.Name = "statusStrip_main";
            statusStrip_main.Size = new System.Drawing.Size(697, 22);
            statusStrip_main.TabIndex = 6;
            statusStrip_main.Text = "statusStrip1";
            // 
            // FormOam
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(697, 763);
            Controls.Add(splitContainer_main);
            Controls.Add(menuStrip);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(713, 802);
            Name = "FormOam";
            Text = "OAM Viewer";
            groupBox_imageControl.ResumeLayout(false);
            groupBox_imageControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_width).EndInit();
            groupBox_image.ResumeLayout(false);
            groupBox_image.PerformLayout();
            panel_gfx.ResumeLayout(false);
            statusStrip_gfx.ResumeLayout(false);
            statusStrip_gfx.PerformLayout();
            groupBox_paletteControl.ResumeLayout(false);
            groupBox_paletteControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_palette).EndInit();
            groupBox_oam.ResumeLayout(false);
            groupBox_oam.PerformLayout();
            groupBox_oamDisplay.ResumeLayout(false);
            groupBox_oamDisplay.PerformLayout();
            panel_oam.ResumeLayout(false);
            statusStrip_oam.ResumeLayout(false);
            statusStrip_oam.PerformLayout();
            splitContainer_main.Panel1.ResumeLayout(false);
            splitContainer_main.Panel2.ResumeLayout(false);
            splitContainer_main.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_main).EndInit();
            splitContainer_main.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip statusStrip_gfx;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_coor;
        private System.Windows.Forms.ToolStripDropDownButton statusStrip_zoom;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom1600;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom400;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom800;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom200;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoom100;
        private System.Windows.Forms.CheckBox checkBox_compressed;
        private System.Windows.Forms.Button button_minus;
        private System.Windows.Forms.Button button_plus;
        private System.Windows.Forms.ToolStripStatusLabel statusStrip_spring;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button button_editPal;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_size;
        private GfxView gfxView_gfx;
        private System.Windows.Forms.GroupBox groupBox_oam;
        private mage.Theming.CustomControls.FlatComboBox comboBox_Frame;
        private System.Windows.Forms.Label label_OAMFrame;
        private System.Windows.Forms.Button button_oamGo;
        private Theming.CustomControls.FlatTextBox textBox_oamOffset;
        private System.Windows.Forms.Label label_OAMOffset;
        private System.Windows.Forms.GroupBox groupBox_part;
        private System.Windows.Forms.GroupBox groupBox_oamDisplay;
        private System.Windows.Forms.Panel panel_oam;
        private OamView oamView_oam;
        private System.Windows.Forms.SplitContainer splitContainer_main;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.Label label_frameDuration;
        private Theming.CustomControls.FlatTextBox textBox_duration;
        private System.Windows.Forms.StatusStrip statusStrip_oam;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_coorOam;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_sizeOam;
        private System.Windows.Forms.ToolStripStatusLabel toolStrip_springOam;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_zoomOam;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoomOam1600;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoomOam800;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoomOam400;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoomOam200;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_zoomOam100;
        private System.Windows.Forms.Button button_playAnimation;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_oamView;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_origin;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_partOutline;
    }
}