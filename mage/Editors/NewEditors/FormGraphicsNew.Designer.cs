namespace mage.Editors.NewEditors
{
    partial class FormGraphicsNew
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGraphicsNew));
            groupBox_imageControl = new System.Windows.Forms.GroupBox();
            checkBox_compressed = new System.Windows.Forms.CheckBox();
            button_load = new System.Windows.Forms.Button();
            label_height = new System.Windows.Forms.Label();
            label_width = new System.Windows.Forms.Label();
            numericUpDown_height = new mage.Theming.CustomControls.FlatNumericUpDown();
            numericUpDown_width = new mage.Theming.CustomControls.FlatNumericUpDown();
            textBox_imageOffset = new mage.Theming.CustomControls.FlatTextBox();
            label_imageOffset = new System.Windows.Forms.Label();
            panel_input = new System.Windows.Forms.Panel();
            groupBox_paletteControl = new System.Windows.Forms.GroupBox();
            button_minus = new System.Windows.Forms.Button();
            button_plus = new System.Windows.Forms.Button();
            textBox_palOffset = new mage.Theming.CustomControls.FlatTextBox();
            label_paletteOffset = new System.Windows.Forms.Label();
            statusStrip_main = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            spring = new System.Windows.Forms.ToolStripStatusLabel();
            statusButton_import = new System.Windows.Forms.ToolStripDropDownButton();
            statusButton_export = new System.Windows.Forms.ToolStripDropDownButton();
            button_apply = new System.Windows.Forms.ToolStripDropDownButton();
            graphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            paletteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rawToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            rawToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            tileLayerProToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            yYCHRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            paletteToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            graphicsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            rawToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            imageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_pixelFormat = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_4bitIndexed = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_24bitRGB = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_32bitARGB = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palExport_raw = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palExport_tlp = new System.Windows.Forms.ToolStripMenuItem();
            menuItem_palExport_yychr = new System.Windows.Forms.ToolStripMenuItem();
            statusLabel_coor = new System.Windows.Forms.ToolStripStatusLabel();
            statusLabel_size = new System.Windows.Forms.ToolStripStatusLabel();
            groupBox_image = new System.Windows.Forms.GroupBox();
            panel_imageContainer = new System.Windows.Forms.Panel();
            panel_loadButtonContainer = new System.Windows.Forms.Panel();
            toolStrip_table = new System.Windows.Forms.ToolStrip();
            button_flipH = new System.Windows.Forms.ToolStripButton();
            button_flipV = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            button_grid = new System.Windows.Forms.ToolStripButton();
            toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.button_imageZoomIn = new System.Windows.Forms.ToolStripButton();
            this.button_imageZoomOut = new System.Windows.Forms.ToolStripButton();
            label_imageZoom = new System.Windows.Forms.ToolStripLabel();
            groupBox_imageControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_width).BeginInit();
            panel_input.SuspendLayout();
            groupBox_paletteControl.SuspendLayout();
            statusStrip_main.SuspendLayout();
            groupBox_image.SuspendLayout();
            panel_imageContainer.SuspendLayout();
            panel_loadButtonContainer.SuspendLayout();
            toolStrip_table.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox_imageControl
            // 
            groupBox_imageControl.Controls.Add(checkBox_compressed);
            groupBox_imageControl.Controls.Add(label_height);
            groupBox_imageControl.Controls.Add(label_width);
            groupBox_imageControl.Controls.Add(numericUpDown_height);
            groupBox_imageControl.Controls.Add(numericUpDown_width);
            groupBox_imageControl.Controls.Add(textBox_imageOffset);
            groupBox_imageControl.Controls.Add(label_imageOffset);
            groupBox_imageControl.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox_imageControl.Location = new System.Drawing.Point(6, 3);
            groupBox_imageControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_imageControl.Name = "groupBox_imageControl";
            groupBox_imageControl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_imageControl.Size = new System.Drawing.Size(170, 111);
            groupBox_imageControl.TabIndex = 2;
            groupBox_imageControl.TabStop = false;
            groupBox_imageControl.Text = "Image Control";
            // 
            // checkBox_compressed
            // 
            checkBox_compressed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            checkBox_compressed.Location = new System.Drawing.Point(7, 81);
            checkBox_compressed.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBox_compressed.Name = "checkBox_compressed";
            checkBox_compressed.Size = new System.Drawing.Size(153, 19);
            checkBox_compressed.TabIndex = 2;
            checkBox_compressed.Text = "Compressed Graphics:";
            checkBox_compressed.UseVisualStyleBackColor = true;
            // 
            // button_load
            // 
            button_load.Dock = System.Windows.Forms.DockStyle.Top;
            button_load.Location = new System.Drawing.Point(0, 6);
            button_load.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_load.Name = "button_load";
            button_load.Size = new System.Drawing.Size(170, 25);
            button_load.TabIndex = 1;
            button_load.Text = "Load";
            button_load.UseVisualStyleBackColor = true;
            button_load.Click += button_load_Click;
            // 
            // label_height
            // 
            label_height.AutoSize = true;
            label_height.Location = new System.Drawing.Point(102, 54);
            label_height.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_height.Name = "label_height";
            label_height.Size = new System.Drawing.Size(14, 15);
            label_height.TabIndex = 0;
            label_height.Text = "X";
            // 
            // label_width
            // 
            label_width.AutoSize = true;
            label_width.Location = new System.Drawing.Point(8, 54);
            label_width.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_width.Name = "label_width";
            label_width.Size = new System.Drawing.Size(30, 15);
            label_width.TabIndex = 0;
            label_width.Text = "Size:";
            // 
            // numericUpDown_height
            // 
            numericUpDown_height.Location = new System.Drawing.Point(124, 52);
            numericUpDown_height.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_height.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDown_height.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_height.Name = "numericUpDown_height";
            numericUpDown_height.Size = new System.Drawing.Size(36, 23);
            numericUpDown_height.TabIndex = 4;
            numericUpDown_height.Value = new decimal(new int[] { 32, 0, 0, 0 });
            // 
            // numericUpDown_width
            // 
            numericUpDown_width.Location = new System.Drawing.Point(58, 52);
            numericUpDown_width.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericUpDown_width.Maximum = new decimal(new int[] { 32, 0, 0, 0 });
            numericUpDown_width.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_width.Name = "numericUpDown_width";
            numericUpDown_width.Size = new System.Drawing.Size(36, 23);
            numericUpDown_width.TabIndex = 3;
            numericUpDown_width.Value = new decimal(new int[] { 32, 0, 0, 0 });
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
            textBox_imageOffset.Size = new System.Drawing.Size(102, 23);
            textBox_imageOffset.TabIndex = 0;
            textBox_imageOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_imageOffset.ValueBox = true;
            textBox_imageOffset.WordWrap = true;
            // 
            // label_imageOffset
            // 
            label_imageOffset.AutoSize = true;
            label_imageOffset.Location = new System.Drawing.Point(8, 25);
            label_imageOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_imageOffset.Name = "label_imageOffset";
            label_imageOffset.Size = new System.Drawing.Size(42, 15);
            label_imageOffset.TabIndex = 0;
            label_imageOffset.Text = "Offset:";
            // 
            // panel_input
            // 
            panel_input.Controls.Add(panel_loadButtonContainer);
            panel_input.Controls.Add(groupBox_paletteControl);
            panel_input.Controls.Add(groupBox_imageControl);
            panel_input.Dock = System.Windows.Forms.DockStyle.Left;
            panel_input.Location = new System.Drawing.Point(0, 0);
            panel_input.Name = "panel_input";
            panel_input.Padding = new System.Windows.Forms.Padding(6, 3, 3, 6);
            panel_input.Size = new System.Drawing.Size(179, 428);
            panel_input.TabIndex = 3;
            // 
            // groupBox_paletteControl
            // 
            groupBox_paletteControl.Controls.Add(button_minus);
            groupBox_paletteControl.Controls.Add(textBox_palOffset);
            groupBox_paletteControl.Controls.Add(label_paletteOffset);
            groupBox_paletteControl.Controls.Add(button_plus);
            groupBox_paletteControl.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox_paletteControl.Location = new System.Drawing.Point(6, 114);
            groupBox_paletteControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_paletteControl.Name = "groupBox_paletteControl";
            groupBox_paletteControl.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox_paletteControl.Size = new System.Drawing.Size(170, 88);
            groupBox_paletteControl.TabIndex = 4;
            groupBox_paletteControl.TabStop = false;
            groupBox_paletteControl.Text = "Palette Control";
            // 
            // button_minus
            // 
            button_minus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            button_minus.Location = new System.Drawing.Point(113, 51);
            button_minus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_minus.Name = "button_minus";
            button_minus.Size = new System.Drawing.Size(47, 23);
            button_minus.TabIndex = 3;
            button_minus.Text = "-";
            button_minus.UseVisualStyleBackColor = true;
            // 
            // button_plus
            // 
            button_plus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            button_plus.Location = new System.Drawing.Point(58, 51);
            button_plus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_plus.Name = "button_plus";
            button_plus.Size = new System.Drawing.Size(47, 23);
            button_plus.TabIndex = 2;
            button_plus.Text = "+";
            button_plus.UseVisualStyleBackColor = true;
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
            textBox_palOffset.Size = new System.Drawing.Size(102, 23);
            textBox_palOffset.TabIndex = 0;
            textBox_palOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_palOffset.ValueBox = true;
            textBox_palOffset.WordWrap = true;
            // 
            // label_paletteOffset
            // 
            label_paletteOffset.AutoSize = true;
            label_paletteOffset.Location = new System.Drawing.Point(8, 25);
            label_paletteOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_paletteOffset.Name = "label_paletteOffset";
            label_paletteOffset.Size = new System.Drawing.Size(42, 15);
            label_paletteOffset.TabIndex = 0;
            label_paletteOffset.Text = "Offset:";
            // 
            // statusStrip_main
            // 
            statusStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_coor, statusLabel_size, statusLabel_changes, spring, statusButton_import, statusButton_export, button_apply });
            statusStrip_main.Location = new System.Drawing.Point(0, 428);
            statusStrip_main.Name = "statusStrip_main";
            statusStrip_main.Size = new System.Drawing.Size(800, 22);
            statusStrip_main.TabIndex = 4;
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
            spring.Size = new System.Drawing.Size(483, 17);
            spring.Spring = true;
            // 
            // statusButton_import
            // 
            statusButton_import.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusButton_import.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { graphicsToolStripMenuItem, paletteToolStripMenuItem });
            statusButton_import.Image = (System.Drawing.Image)resources.GetObject("statusButton_import.Image");
            statusButton_import.ImageTransparentColor = System.Drawing.Color.Magenta;
            statusButton_import.Name = "statusButton_import";
            statusButton_import.ShowDropDownArrow = false;
            statusButton_import.Size = new System.Drawing.Size(47, 20);
            statusButton_import.Text = "Import";
            // 
            // statusButton_export
            // 
            statusButton_export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            statusButton_export.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { graphicsToolStripMenuItem1, paletteToolStripMenuItem1 });
            statusButton_export.Image = (System.Drawing.Image)resources.GetObject("statusButton_export.Image");
            statusButton_export.ImageTransparentColor = System.Drawing.Color.Magenta;
            statusButton_export.Name = "statusButton_export";
            statusButton_export.ShowDropDownArrow = false;
            statusButton_export.Size = new System.Drawing.Size(45, 20);
            statusButton_export.Text = "Export";
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
            // graphicsToolStripMenuItem
            // 
            graphicsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { rawToolStripMenuItem, imageToolStripMenuItem });
            graphicsToolStripMenuItem.Name = "graphicsToolStripMenuItem";
            graphicsToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            graphicsToolStripMenuItem.Text = "Graphics";
            // 
            // paletteToolStripMenuItem
            // 
            paletteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { rawToolStripMenuItem1, tileLayerProToolStripMenuItem, yYCHRToolStripMenuItem });
            paletteToolStripMenuItem.Name = "paletteToolStripMenuItem";
            paletteToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            paletteToolStripMenuItem.Text = "Palette";
            // 
            // rawToolStripMenuItem
            // 
            rawToolStripMenuItem.Name = "rawToolStripMenuItem";
            rawToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            rawToolStripMenuItem.Text = "Raw...";
            // 
            // imageToolStripMenuItem
            // 
            imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            imageToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            imageToolStripMenuItem.Text = "Image...";
            // 
            // rawToolStripMenuItem1
            // 
            rawToolStripMenuItem1.Name = "rawToolStripMenuItem1";
            rawToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            rawToolStripMenuItem1.Text = "Raw...";
            // 
            // tileLayerProToolStripMenuItem
            // 
            tileLayerProToolStripMenuItem.Name = "tileLayerProToolStripMenuItem";
            tileLayerProToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            tileLayerProToolStripMenuItem.Text = "Tile Layer Pro...";
            // 
            // yYCHRToolStripMenuItem
            // 
            yYCHRToolStripMenuItem.Name = "yYCHRToolStripMenuItem";
            yYCHRToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            yYCHRToolStripMenuItem.Text = "YY-CHR...";
            // 
            // paletteToolStripMenuItem1
            // 
            paletteToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { menuItem_palExport_raw, menuItem_palExport_tlp, menuItem_palExport_yychr });
            paletteToolStripMenuItem1.Name = "paletteToolStripMenuItem1";
            paletteToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            paletteToolStripMenuItem1.Text = "Palette";
            // 
            // graphicsToolStripMenuItem1
            // 
            graphicsToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { rawToolStripMenuItem2, toolStripSeparator2, imageToolStripMenuItem1, menuItem_pixelFormat });
            graphicsToolStripMenuItem1.Name = "graphicsToolStripMenuItem1";
            graphicsToolStripMenuItem1.Size = new System.Drawing.Size(120, 22);
            graphicsToolStripMenuItem1.Text = "Graphics";
            // 
            // rawToolStripMenuItem2
            // 
            rawToolStripMenuItem2.Name = "rawToolStripMenuItem2";
            rawToolStripMenuItem2.Size = new System.Drawing.Size(140, 22);
            rawToolStripMenuItem2.Text = "Raw...";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new System.Drawing.Size(137, 6);
            // 
            // imageToolStripMenuItem1
            // 
            imageToolStripMenuItem1.Name = "imageToolStripMenuItem1";
            imageToolStripMenuItem1.Size = new System.Drawing.Size(140, 22);
            imageToolStripMenuItem1.Text = "Image...";
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
            menuItem_4bitIndexed.Size = new System.Drawing.Size(180, 22);
            menuItem_4bitIndexed.Text = "4-bit Indexed";
            // 
            // menuItem_24bitRGB
            // 
            menuItem_24bitRGB.Checked = true;
            menuItem_24bitRGB.CheckState = System.Windows.Forms.CheckState.Checked;
            menuItem_24bitRGB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            menuItem_24bitRGB.Name = "menuItem_24bitRGB";
            menuItem_24bitRGB.Size = new System.Drawing.Size(180, 22);
            menuItem_24bitRGB.Text = "24-bit RGB";
            // 
            // menuItem_32bitARGB
            // 
            menuItem_32bitARGB.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            menuItem_32bitARGB.Name = "menuItem_32bitARGB";
            menuItem_32bitARGB.Size = new System.Drawing.Size(180, 22);
            menuItem_32bitARGB.Text = "32-bit ARGB";
            // 
            // menuItem_palExport_raw
            // 
            menuItem_palExport_raw.Name = "menuItem_palExport_raw";
            menuItem_palExport_raw.Size = new System.Drawing.Size(180, 22);
            menuItem_palExport_raw.Text = "Raw...";
            // 
            // menuItem_palExport_tlp
            // 
            menuItem_palExport_tlp.Name = "menuItem_palExport_tlp";
            menuItem_palExport_tlp.Size = new System.Drawing.Size(180, 22);
            menuItem_palExport_tlp.Text = "Tile Layer Pro...";
            // 
            // menuItem_palExport_yychr
            // 
            menuItem_palExport_yychr.Name = "menuItem_palExport_yychr";
            menuItem_palExport_yychr.Size = new System.Drawing.Size(180, 22);
            menuItem_palExport_yychr.Text = "YY-CHR...";
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
            // groupBox_image
            // 
            groupBox_image.Controls.Add(toolStrip_table);
            groupBox_image.Dock = System.Windows.Forms.DockStyle.Fill;
            groupBox_image.Location = new System.Drawing.Point(3, 3);
            groupBox_image.Name = "groupBox_image";
            groupBox_image.Size = new System.Drawing.Size(612, 419);
            groupBox_image.TabIndex = 5;
            groupBox_image.TabStop = false;
            groupBox_image.Text = "Image";
            // 
            // panel_imageContainer
            // 
            panel_imageContainer.Controls.Add(groupBox_image);
            panel_imageContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_imageContainer.Location = new System.Drawing.Point(179, 0);
            panel_imageContainer.Name = "panel_imageContainer";
            panel_imageContainer.Padding = new System.Windows.Forms.Padding(3, 3, 6, 6);
            panel_imageContainer.Size = new System.Drawing.Size(621, 428);
            panel_imageContainer.TabIndex = 6;
            // 
            // panel_loadButtonContainer
            // 
            panel_loadButtonContainer.Controls.Add(button_load);
            panel_loadButtonContainer.Dock = System.Windows.Forms.DockStyle.Top;
            panel_loadButtonContainer.Location = new System.Drawing.Point(6, 202);
            panel_loadButtonContainer.Name = "panel_loadButtonContainer";
            panel_loadButtonContainer.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            panel_loadButtonContainer.Size = new System.Drawing.Size(170, 37);
            panel_loadButtonContainer.TabIndex = 5;
            // 
            // toolStrip_table
            // 
            toolStrip_table.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip_table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { button_flipH, button_flipV, toolStripSeparator3, button_grid, toolStripSeparator4, this.button_imageZoomIn, this.button_imageZoomOut, label_imageZoom });
            toolStrip_table.Location = new System.Drawing.Point(3, 19);
            toolStrip_table.Name = "toolStrip_table";
            toolStrip_table.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            toolStrip_table.Size = new System.Drawing.Size(606, 25);
            toolStrip_table.TabIndex = 1;
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
            button_grid.Text = "Grid (G)";
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // button_imageZoomIn
            // 
            this.button_imageZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_imageZoomIn.Image = Properties.Resources.zoom_in;
            this.button_imageZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_imageZoomIn.Name = "button_imageZoomIn";
            this.button_imageZoomIn.Size = new System.Drawing.Size(23, 22);
            this.button_imageZoomIn.Text = "Zoom In";
            // 
            // button_imageZoomOut
            // 
            this.button_imageZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.button_imageZoomOut.Image = Properties.Resources.zoom_out;
            this.button_imageZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.button_imageZoomOut.Name = "button_imageZoomOut";
            this.button_imageZoomOut.Size = new System.Drawing.Size(23, 22);
            this.button_imageZoomOut.Text = "Zoom Out";
            // 
            // label_imageZoom
            // 
            label_imageZoom.AutoSize = false;
            label_imageZoom.Name = "label_imageZoom";
            label_imageZoom.Size = new System.Drawing.Size(42, 22);
            label_imageZoom.Text = "1600%";
            label_imageZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormGraphicsNew
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(panel_imageContainer);
            Controls.Add(panel_input);
            Controls.Add(statusStrip_main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormGraphicsNew";
            Text = "Graphics Editor";
            groupBox_imageControl.ResumeLayout(false);
            groupBox_imageControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_height).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_width).EndInit();
            panel_input.ResumeLayout(false);
            groupBox_paletteControl.ResumeLayout(false);
            groupBox_paletteControl.PerformLayout();
            statusStrip_main.ResumeLayout(false);
            statusStrip_main.PerformLayout();
            groupBox_image.ResumeLayout(false);
            groupBox_image.PerformLayout();
            panel_imageContainer.ResumeLayout(false);
            panel_loadButtonContainer.ResumeLayout(false);
            toolStrip_table.ResumeLayout(false);
            toolStrip_table.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox_imageControl;
        private System.Windows.Forms.CheckBox checkBox_compressed;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Label label_height;
        private System.Windows.Forms.Label label_width;
        private Theming.CustomControls.FlatNumericUpDown numericUpDown_height;
        private Theming.CustomControls.FlatNumericUpDown numericUpDown_width;
        private Theming.CustomControls.FlatTextBox textBox_imageOffset;
        private System.Windows.Forms.Label label_imageOffset;
        private System.Windows.Forms.Panel panel_input;
        private System.Windows.Forms.GroupBox groupBox_paletteControl;
        private System.Windows.Forms.Button button_minus;
        private System.Windows.Forms.Button button_plus;
        private Theming.CustomControls.FlatTextBox textBox_palOffset;
        private System.Windows.Forms.Label label_paletteOffset;
        private System.Windows.Forms.StatusStrip statusStrip_main;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
        private System.Windows.Forms.ToolStripStatusLabel spring;
        private System.Windows.Forms.ToolStripDropDownButton statusButton_import;
        private System.Windows.Forms.ToolStripMenuItem graphicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rawToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tileLayerProToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yYCHRToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton statusButton_export;
        private System.Windows.Forms.ToolStripMenuItem graphicsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rawToolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem paletteToolStripMenuItem1;
        private System.Windows.Forms.ToolStripDropDownButton button_apply;
        private System.Windows.Forms.ToolStripMenuItem menuItem_pixelFormat;
        private System.Windows.Forms.ToolStripMenuItem menuItem_4bitIndexed;
        private System.Windows.Forms.ToolStripMenuItem menuItem_24bitRGB;
        private System.Windows.Forms.ToolStripMenuItem menuItem_32bitARGB;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palExport_raw;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palExport_tlp;
        private System.Windows.Forms.ToolStripMenuItem menuItem_palExport_yychr;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_coor;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_size;
        private System.Windows.Forms.Panel panel_loadButtonContainer;
        private System.Windows.Forms.GroupBox groupBox_image;
        private System.Windows.Forms.Panel panel_imageContainer;
        private System.Windows.Forms.ToolStrip toolStrip_table;
        private System.Windows.Forms.ToolStripButton button_flipH;
        private System.Windows.Forms.ToolStripButton button_flipV;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton button_paletteIncrease;
        private System.Windows.Forms.ToolStripButton button_paletteDecrease;
        private System.Windows.Forms.ToolStripButton button_setPalette;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton button_grid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton button_tableZoomIn;
        private System.Windows.Forms.ToolStripButton button_tableZoomOut;
        private System.Windows.Forms.ToolStripLabel label_imageZoom;
    }
}