namespace mage
{
    partial class FormAnimation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnimation));
            tabControl = new Theming.CustomControls.FlatTabControl();
            tabPage_tileset = new System.Windows.Forms.TabPage();
            label_tilesetGfx = new System.Windows.Forms.Label();
            comboBox_tilesetGfxNum = new Theming.CustomControls.FlatComboBox();
            label_tilesetSlot = new System.Windows.Forms.Label();
            comboBox_tilesetSlot = new Theming.CustomControls.FlatComboBox();
            label_tilesetNum = new System.Windows.Forms.Label();
            pictureBox_tileset = new System.Windows.Forms.PictureBox();
            comboBox_tilesetNum = new Theming.CustomControls.FlatComboBox();
            button_tilesetClose = new System.Windows.Forms.Button();
            button_tilesetApply = new System.Windows.Forms.Button();
            tabPage_graphics = new System.Windows.Forms.TabPage();
            gfxView_gfx = new GfxView();
            label_gfxPal = new System.Windows.Forms.Label();
            textBox_gfxPalOffset = new Theming.CustomControls.FlatTextBox();
            label_gfxView = new System.Windows.Forms.Label();
            comboBox_gfxView = new Theming.CustomControls.FlatComboBox();
            button_gfxEdit = new System.Windows.Forms.Button();
            textBox_gfxStates = new Theming.CustomControls.FlatTextBox();
            label_gfxStates = new System.Windows.Forms.Label();
            textBox_gfxDelay = new Theming.CustomControls.FlatTextBox();
            label_gfxDelay = new System.Windows.Forms.Label();
            label_gfxDirection = new System.Windows.Forms.Label();
            comboBox_gfxDirection = new Theming.CustomControls.FlatComboBox();
            label_gfxNum = new System.Windows.Forms.Label();
            comboBox_gfxNum = new Theming.CustomControls.FlatComboBox();
            button_gfxClose = new System.Windows.Forms.Button();
            button_gfxApply = new System.Windows.Forms.Button();
            tabPage_palette = new System.Windows.Forms.TabPage();
            button_palEdit = new System.Windows.Forms.Button();
            textBox_palStates = new Theming.CustomControls.FlatTextBox();
            label_palStates = new System.Windows.Forms.Label();
            textBox_palDelay = new Theming.CustomControls.FlatTextBox();
            label_palDelay = new System.Windows.Forms.Label();
            label_palDirection = new System.Windows.Forms.Label();
            comboBox_palDirection = new Theming.CustomControls.FlatComboBox();
            label_palNum = new System.Windows.Forms.Label();
            button_palClose = new System.Windows.Forms.Button();
            button_palApply = new System.Windows.Forms.Button();
            comboBox_palNum = new Theming.CustomControls.FlatComboBox();
            pictureBox_pal = new System.Windows.Forms.PictureBox();
            statusStrip = new System.Windows.Forms.StatusStrip();
            statusLabel_changes = new System.Windows.Forms.ToolStripStatusLabel();
            tabControl.SuspendLayout();
            tabPage_tileset.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_tileset).BeginInit();
            tabPage_graphics.SuspendLayout();
            tabPage_palette.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_pal).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.BorderColor = System.Drawing.Color.Empty;
            tabControl.Controls.Add(tabPage_tileset);
            tabControl.Controls.Add(tabPage_graphics);
            tabControl.Controls.Add(tabPage_palette);
            tabControl.Location = new System.Drawing.Point(14, 14);
            tabControl.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(337, 219);
            tabControl.TabIndex = 1;
            tabControl.SelectedIndexChanged += tabControl_SelectedIndexChanged;
            // 
            // tabPage_tileset
            // 
            tabPage_tileset.BackColor = System.Drawing.Color.Transparent;
            tabPage_tileset.Controls.Add(label_tilesetGfx);
            tabPage_tileset.Controls.Add(comboBox_tilesetGfxNum);
            tabPage_tileset.Controls.Add(label_tilesetSlot);
            tabPage_tileset.Controls.Add(comboBox_tilesetSlot);
            tabPage_tileset.Controls.Add(label_tilesetNum);
            tabPage_tileset.Controls.Add(pictureBox_tileset);
            tabPage_tileset.Controls.Add(comboBox_tilesetNum);
            tabPage_tileset.Controls.Add(button_tilesetClose);
            tabPage_tileset.Controls.Add(button_tilesetApply);
            tabPage_tileset.Location = new System.Drawing.Point(4, 25);
            tabPage_tileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_tileset.Name = "tabPage_tileset";
            tabPage_tileset.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_tileset.Size = new System.Drawing.Size(329, 190);
            tabPage_tileset.TabIndex = 0;
            tabPage_tileset.Text = "Tileset";
            // 
            // label_tilesetGfx
            // 
            label_tilesetGfx.AutoSize = true;
            label_tilesetGfx.Location = new System.Drawing.Point(10, 110);
            label_tilesetGfx.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tilesetGfx.Name = "label_tilesetGfx";
            label_tilesetGfx.Size = new System.Drawing.Size(56, 15);
            label_tilesetGfx.TabIndex = 15;
            label_tilesetGfx.Text = "Graphics:";
            // 
            // comboBox_tilesetGfxNum
            // 
            comboBox_tilesetGfxNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_tilesetGfxNum.FormattingEnabled = true;
            comboBox_tilesetGfxNum.Location = new System.Drawing.Point(78, 106);
            comboBox_tilesetGfxNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_tilesetGfxNum.Name = "comboBox_tilesetGfxNum";
            comboBox_tilesetGfxNum.Size = new System.Drawing.Size(58, 23);
            comboBox_tilesetGfxNum.TabIndex = 14;
            comboBox_tilesetGfxNum.SelectedIndexChanged += comboBox_tilesetGfxNum_SelectedIndexChanged;
            // 
            // label_tilesetSlot
            // 
            label_tilesetSlot.AutoSize = true;
            label_tilesetSlot.Location = new System.Drawing.Point(10, 78);
            label_tilesetSlot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tilesetSlot.Name = "label_tilesetSlot";
            label_tilesetSlot.Size = new System.Drawing.Size(30, 15);
            label_tilesetSlot.TabIndex = 12;
            label_tilesetSlot.Text = "Slot:";
            // 
            // comboBox_tilesetSlot
            // 
            comboBox_tilesetSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_tilesetSlot.FormattingEnabled = true;
            comboBox_tilesetSlot.Location = new System.Drawing.Point(78, 75);
            comboBox_tilesetSlot.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_tilesetSlot.Name = "comboBox_tilesetSlot";
            comboBox_tilesetSlot.Size = new System.Drawing.Size(58, 23);
            comboBox_tilesetSlot.TabIndex = 11;
            comboBox_tilesetSlot.SelectedIndexChanged += comboBox_tilesetSlot_SelectedIndexChanged;
            // 
            // label_tilesetNum
            // 
            label_tilesetNum.AutoSize = true;
            label_tilesetNum.Location = new System.Drawing.Point(10, 47);
            label_tilesetNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_tilesetNum.Name = "label_tilesetNum";
            label_tilesetNum.Size = new System.Drawing.Size(43, 15);
            label_tilesetNum.TabIndex = 10;
            label_tilesetNum.Text = "Tileset:";
            // 
            // pictureBox_tileset
            // 
            pictureBox_tileset.Location = new System.Drawing.Point(14, 14);
            pictureBox_tileset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_tileset.Name = "pictureBox_tileset";
            pictureBox_tileset.Size = new System.Drawing.Size(299, 18);
            pictureBox_tileset.TabIndex = 9;
            pictureBox_tileset.TabStop = false;
            // 
            // comboBox_tilesetNum
            // 
            comboBox_tilesetNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_tilesetNum.FormattingEnabled = true;
            comboBox_tilesetNum.Location = new System.Drawing.Point(78, 44);
            comboBox_tilesetNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_tilesetNum.Name = "comboBox_tilesetNum";
            comboBox_tilesetNum.Size = new System.Drawing.Size(58, 23);
            comboBox_tilesetNum.TabIndex = 8;
            comboBox_tilesetNum.SelectedIndexChanged += comboBox_tilesetNum_SelectedIndexChanged;
            // 
            // button_tilesetClose
            // 
            button_tilesetClose.Location = new System.Drawing.Point(168, 104);
            button_tilesetClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_tilesetClose.Name = "button_tilesetClose";
            button_tilesetClose.Size = new System.Drawing.Size(88, 27);
            button_tilesetClose.TabIndex = 7;
            button_tilesetClose.Text = "Close";
            button_tilesetClose.UseVisualStyleBackColor = true;
            button_tilesetClose.Click += button_tilesetClose_Click;
            // 
            // button_tilesetApply
            // 
            button_tilesetApply.Enabled = false;
            button_tilesetApply.Location = new System.Drawing.Point(168, 70);
            button_tilesetApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_tilesetApply.Name = "button_tilesetApply";
            button_tilesetApply.Size = new System.Drawing.Size(88, 27);
            button_tilesetApply.TabIndex = 6;
            button_tilesetApply.Text = "Apply";
            button_tilesetApply.UseVisualStyleBackColor = true;
            button_tilesetApply.Click += button_tilesetApply_Click;
            // 
            // tabPage_graphics
            // 
            tabPage_graphics.Controls.Add(gfxView_gfx);
            tabPage_graphics.Controls.Add(label_gfxPal);
            tabPage_graphics.Controls.Add(textBox_gfxPalOffset);
            tabPage_graphics.Controls.Add(label_gfxView);
            tabPage_graphics.Controls.Add(comboBox_gfxView);
            tabPage_graphics.Controls.Add(button_gfxEdit);
            tabPage_graphics.Controls.Add(textBox_gfxStates);
            tabPage_graphics.Controls.Add(label_gfxStates);
            tabPage_graphics.Controls.Add(textBox_gfxDelay);
            tabPage_graphics.Controls.Add(label_gfxDelay);
            tabPage_graphics.Controls.Add(label_gfxDirection);
            tabPage_graphics.Controls.Add(comboBox_gfxDirection);
            tabPage_graphics.Controls.Add(label_gfxNum);
            tabPage_graphics.Controls.Add(comboBox_gfxNum);
            tabPage_graphics.Controls.Add(button_gfxClose);
            tabPage_graphics.Controls.Add(button_gfxApply);
            tabPage_graphics.Location = new System.Drawing.Point(4, 25);
            tabPage_graphics.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_graphics.Name = "tabPage_graphics";
            tabPage_graphics.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_graphics.Size = new System.Drawing.Size(329, 190);
            tabPage_graphics.TabIndex = 1;
            tabPage_graphics.Text = "Graphics";
            // 
            // gfxView_gfx
            // 
            gfxView_gfx.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView_gfx.Location = new System.Drawing.Point(14, 14);
            gfxView_gfx.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            gfxView_gfx.Name = "gfxView_gfx";
            gfxView_gfx.Size = new System.Drawing.Size(75, 37);
            gfxView_gfx.TabIndex = 29;
            gfxView_gfx.TabStop = false;
            // 
            // label_gfxPal
            // 
            label_gfxPal.AutoSize = true;
            label_gfxPal.Location = new System.Drawing.Point(153, 42);
            label_gfxPal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_gfxPal.Name = "label_gfxPal";
            label_gfxPal.Size = new System.Drawing.Size(46, 15);
            label_gfxPal.TabIndex = 27;
            label_gfxPal.Text = "Palette:";
            // 
            // textBox_gfxPalOffset
            // 
            textBox_gfxPalOffset.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_gfxPalOffset.DisplayBorder = true;
            textBox_gfxPalOffset.Location = new System.Drawing.Point(210, 38);
            textBox_gfxPalOffset.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_gfxPalOffset.MaxLength = 32767;
            textBox_gfxPalOffset.Multiline = false;
            textBox_gfxPalOffset.Name = "textBox_gfxPalOffset";
            textBox_gfxPalOffset.OnTextChanged = null;
            textBox_gfxPalOffset.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_gfxPalOffset.PlaceholderText = "";
            textBox_gfxPalOffset.ReadOnly = false;
            textBox_gfxPalOffset.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_gfxPalOffset.SelectionStart = 0;
            textBox_gfxPalOffset.Size = new System.Drawing.Size(64, 23);
            textBox_gfxPalOffset.TabIndex = 25;
            textBox_gfxPalOffset.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_gfxPalOffset.ValueBox = true;
            textBox_gfxPalOffset.WordWrap = true;
            textBox_gfxPalOffset.TextChanged += textBox_gfxPalOffset_TextChanged;
            // 
            // label_gfxView
            // 
            label_gfxView.AutoSize = true;
            label_gfxView.Location = new System.Drawing.Point(153, 10);
            label_gfxView.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_gfxView.Name = "label_gfxView";
            label_gfxView.Size = new System.Drawing.Size(35, 15);
            label_gfxView.TabIndex = 24;
            label_gfxView.Text = "View:";
            // 
            // comboBox_gfxView
            // 
            comboBox_gfxView.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_gfxView.FormattingEnabled = true;
            comboBox_gfxView.Items.AddRange(new object[] { "2 x 2", "4 x 1" });
            comboBox_gfxView.Location = new System.Drawing.Point(210, 7);
            comboBox_gfxView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_gfxView.Name = "comboBox_gfxView";
            comboBox_gfxView.Size = new System.Drawing.Size(63, 23);
            comboBox_gfxView.TabIndex = 23;
            comboBox_gfxView.SelectedIndexChanged += comboBox_gfxView_SelectedIndexChanged;
            // 
            // button_gfxEdit
            // 
            button_gfxEdit.Location = new System.Drawing.Point(187, 84);
            button_gfxEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_gfxEdit.Name = "button_gfxEdit";
            button_gfxEdit.Size = new System.Drawing.Size(88, 27);
            button_gfxEdit.TabIndex = 22;
            button_gfxEdit.Text = "Edit";
            button_gfxEdit.UseVisualStyleBackColor = true;
            button_gfxEdit.Click += button_gfxEdit_Click;
            // 
            // textBox_gfxStates
            // 
            textBox_gfxStates.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_gfxStates.DisplayBorder = true;
            textBox_gfxStates.Location = new System.Drawing.Point(78, 155);
            textBox_gfxStates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_gfxStates.MaxLength = 32767;
            textBox_gfxStates.Multiline = false;
            textBox_gfxStates.Name = "textBox_gfxStates";
            textBox_gfxStates.OnTextChanged = null;
            textBox_gfxStates.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_gfxStates.PlaceholderText = "";
            textBox_gfxStates.ReadOnly = false;
            textBox_gfxStates.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_gfxStates.SelectionStart = 0;
            textBox_gfxStates.Size = new System.Drawing.Size(41, 23);
            textBox_gfxStates.TabIndex = 21;
            textBox_gfxStates.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_gfxStates.ValueBox = false;
            textBox_gfxStates.WordWrap = true;
            textBox_gfxStates.TextChanged += control_ValueChanged;
            // 
            // label_gfxStates
            // 
            label_gfxStates.AutoSize = true;
            label_gfxStates.Location = new System.Drawing.Point(10, 158);
            label_gfxStates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_gfxStates.Name = "label_gfxStates";
            label_gfxStates.Size = new System.Drawing.Size(41, 15);
            label_gfxStates.TabIndex = 20;
            label_gfxStates.Text = "States:";
            // 
            // textBox_gfxDelay
            // 
            textBox_gfxDelay.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_gfxDelay.DisplayBorder = true;
            textBox_gfxDelay.Location = new System.Drawing.Point(78, 125);
            textBox_gfxDelay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_gfxDelay.MaxLength = 32767;
            textBox_gfxDelay.Multiline = false;
            textBox_gfxDelay.Name = "textBox_gfxDelay";
            textBox_gfxDelay.OnTextChanged = null;
            textBox_gfxDelay.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_gfxDelay.PlaceholderText = "";
            textBox_gfxDelay.ReadOnly = false;
            textBox_gfxDelay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_gfxDelay.SelectionStart = 0;
            textBox_gfxDelay.Size = new System.Drawing.Size(41, 23);
            textBox_gfxDelay.TabIndex = 19;
            textBox_gfxDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_gfxDelay.ValueBox = false;
            textBox_gfxDelay.WordWrap = true;
            textBox_gfxDelay.TextChanged += control_ValueChanged;
            // 
            // label_gfxDelay
            // 
            label_gfxDelay.AutoSize = true;
            label_gfxDelay.Location = new System.Drawing.Point(10, 128);
            label_gfxDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_gfxDelay.Name = "label_gfxDelay";
            label_gfxDelay.Size = new System.Drawing.Size(39, 15);
            label_gfxDelay.TabIndex = 18;
            label_gfxDelay.Text = "Delay:";
            // 
            // label_gfxDirection
            // 
            label_gfxDirection.AutoSize = true;
            label_gfxDirection.Location = new System.Drawing.Point(10, 97);
            label_gfxDirection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_gfxDirection.Name = "label_gfxDirection";
            label_gfxDirection.Size = new System.Drawing.Size(58, 15);
            label_gfxDirection.TabIndex = 16;
            label_gfxDirection.Text = "Direction:";
            // 
            // comboBox_gfxDirection
            // 
            comboBox_gfxDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_gfxDirection.FormattingEnabled = true;
            comboBox_gfxDirection.Items.AddRange(new object[] { "None", "Normal", "Alternate" });
            comboBox_gfxDirection.Location = new System.Drawing.Point(78, 93);
            comboBox_gfxDirection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_gfxDirection.Name = "comboBox_gfxDirection";
            comboBox_gfxDirection.Size = new System.Drawing.Size(75, 23);
            comboBox_gfxDirection.TabIndex = 15;
            comboBox_gfxDirection.SelectedIndexChanged += control_ValueChanged;
            // 
            // label_gfxNum
            // 
            label_gfxNum.AutoSize = true;
            label_gfxNum.Location = new System.Drawing.Point(10, 66);
            label_gfxNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_gfxNum.Name = "label_gfxNum";
            label_gfxNum.Size = new System.Drawing.Size(56, 15);
            label_gfxNum.TabIndex = 13;
            label_gfxNum.Text = "Graphics:";
            // 
            // comboBox_gfxNum
            // 
            comboBox_gfxNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_gfxNum.FormattingEnabled = true;
            comboBox_gfxNum.Location = new System.Drawing.Point(78, 62);
            comboBox_gfxNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_gfxNum.Name = "comboBox_gfxNum";
            comboBox_gfxNum.Size = new System.Drawing.Size(52, 23);
            comboBox_gfxNum.TabIndex = 12;
            comboBox_gfxNum.SelectedIndexChanged += comboBox_gfxNum_SelectedIndexChanged;
            // 
            // button_gfxClose
            // 
            button_gfxClose.Location = new System.Drawing.Point(187, 151);
            button_gfxClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_gfxClose.Name = "button_gfxClose";
            button_gfxClose.Size = new System.Drawing.Size(88, 27);
            button_gfxClose.TabIndex = 8;
            button_gfxClose.Text = "Close";
            button_gfxClose.UseVisualStyleBackColor = true;
            button_gfxClose.Click += button_gfxClose_Click;
            // 
            // button_gfxApply
            // 
            button_gfxApply.Enabled = false;
            button_gfxApply.Location = new System.Drawing.Point(187, 118);
            button_gfxApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_gfxApply.Name = "button_gfxApply";
            button_gfxApply.Size = new System.Drawing.Size(88, 27);
            button_gfxApply.TabIndex = 7;
            button_gfxApply.Text = "Apply";
            button_gfxApply.UseVisualStyleBackColor = true;
            button_gfxApply.Click += button_gfxApply_Click;
            // 
            // tabPage_palette
            // 
            tabPage_palette.BackColor = System.Drawing.SystemColors.Control;
            tabPage_palette.Controls.Add(button_palEdit);
            tabPage_palette.Controls.Add(textBox_palStates);
            tabPage_palette.Controls.Add(label_palStates);
            tabPage_palette.Controls.Add(textBox_palDelay);
            tabPage_palette.Controls.Add(label_palDelay);
            tabPage_palette.Controls.Add(label_palDirection);
            tabPage_palette.Controls.Add(comboBox_palDirection);
            tabPage_palette.Controls.Add(label_palNum);
            tabPage_palette.Controls.Add(button_palClose);
            tabPage_palette.Controls.Add(button_palApply);
            tabPage_palette.Controls.Add(comboBox_palNum);
            tabPage_palette.Controls.Add(pictureBox_pal);
            tabPage_palette.Location = new System.Drawing.Point(4, 25);
            tabPage_palette.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tabPage_palette.Name = "tabPage_palette";
            tabPage_palette.Size = new System.Drawing.Size(329, 190);
            tabPage_palette.TabIndex = 2;
            tabPage_palette.Text = "Palette";
            // 
            // button_palEdit
            // 
            button_palEdit.Location = new System.Drawing.Point(184, 45);
            button_palEdit.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_palEdit.Name = "button_palEdit";
            button_palEdit.Size = new System.Drawing.Size(88, 27);
            button_palEdit.TabIndex = 28;
            button_palEdit.Text = "Edit";
            button_palEdit.UseVisualStyleBackColor = true;
            button_palEdit.Click += button_palEdit_Click;
            // 
            // textBox_palStates
            // 
            textBox_palStates.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_palStates.DisplayBorder = true;
            textBox_palStates.Location = new System.Drawing.Point(77, 137);
            textBox_palStates.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_palStates.MaxLength = 32767;
            textBox_palStates.Multiline = false;
            textBox_palStates.Name = "textBox_palStates";
            textBox_palStates.OnTextChanged = null;
            textBox_palStates.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_palStates.PlaceholderText = "";
            textBox_palStates.ReadOnly = false;
            textBox_palStates.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_palStates.SelectionStart = 0;
            textBox_palStates.Size = new System.Drawing.Size(41, 23);
            textBox_palStates.TabIndex = 27;
            textBox_palStates.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_palStates.ValueBox = false;
            textBox_palStates.WordWrap = true;
            textBox_palStates.TextChanged += control_ValueChanged;
            // 
            // label_palStates
            // 
            label_palStates.AutoSize = true;
            label_palStates.Location = new System.Drawing.Point(9, 141);
            label_palStates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_palStates.Name = "label_palStates";
            label_palStates.Size = new System.Drawing.Size(41, 15);
            label_palStates.TabIndex = 26;
            label_palStates.Text = "States:";
            // 
            // textBox_palDelay
            // 
            textBox_palDelay.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_palDelay.DisplayBorder = true;
            textBox_palDelay.Location = new System.Drawing.Point(77, 107);
            textBox_palDelay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_palDelay.MaxLength = 32767;
            textBox_palDelay.Multiline = false;
            textBox_palDelay.Name = "textBox_palDelay";
            textBox_palDelay.OnTextChanged = null;
            textBox_palDelay.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_palDelay.PlaceholderText = "";
            textBox_palDelay.ReadOnly = false;
            textBox_palDelay.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_palDelay.SelectionStart = 0;
            textBox_palDelay.Size = new System.Drawing.Size(41, 23);
            textBox_palDelay.TabIndex = 25;
            textBox_palDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_palDelay.ValueBox = false;
            textBox_palDelay.WordWrap = true;
            textBox_palDelay.TextChanged += control_ValueChanged;
            // 
            // label_palDelay
            // 
            label_palDelay.AutoSize = true;
            label_palDelay.Location = new System.Drawing.Point(9, 111);
            label_palDelay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_palDelay.Name = "label_palDelay";
            label_palDelay.Size = new System.Drawing.Size(39, 15);
            label_palDelay.TabIndex = 24;
            label_palDelay.Text = "Delay:";
            // 
            // label_palDirection
            // 
            label_palDirection.AutoSize = true;
            label_palDirection.Location = new System.Drawing.Point(9, 80);
            label_palDirection.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_palDirection.Name = "label_palDirection";
            label_palDirection.Size = new System.Drawing.Size(58, 15);
            label_palDirection.TabIndex = 23;
            label_palDirection.Text = "Direction:";
            // 
            // comboBox_palDirection
            // 
            comboBox_palDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_palDirection.FormattingEnabled = true;
            comboBox_palDirection.Items.AddRange(new object[] { "None", "Normal", "Alternate" });
            comboBox_palDirection.Location = new System.Drawing.Point(77, 76);
            comboBox_palDirection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_palDirection.Name = "comboBox_palDirection";
            comboBox_palDirection.Size = new System.Drawing.Size(75, 23);
            comboBox_palDirection.TabIndex = 22;
            comboBox_palDirection.SelectedIndexChanged += control_ValueChanged;
            // 
            // label_palNum
            // 
            label_palNum.AutoSize = true;
            label_palNum.Location = new System.Drawing.Point(10, 48);
            label_palNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label_palNum.Name = "label_palNum";
            label_palNum.Size = new System.Drawing.Size(46, 15);
            label_palNum.TabIndex = 14;
            label_palNum.Text = "Palette:";
            // 
            // button_palClose
            // 
            button_palClose.Location = new System.Drawing.Point(184, 134);
            button_palClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_palClose.Name = "button_palClose";
            button_palClose.Size = new System.Drawing.Size(88, 27);
            button_palClose.TabIndex = 13;
            button_palClose.Text = "Close";
            button_palClose.UseVisualStyleBackColor = true;
            button_palClose.Click += button_palClose_Click;
            // 
            // button_palApply
            // 
            button_palApply.Enabled = false;
            button_palApply.Location = new System.Drawing.Point(184, 100);
            button_palApply.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button_palApply.Name = "button_palApply";
            button_palApply.Size = new System.Drawing.Size(88, 27);
            button_palApply.TabIndex = 12;
            button_palApply.Text = "Apply";
            button_palApply.UseVisualStyleBackColor = true;
            button_palApply.Click += button_palApply_Click;
            // 
            // comboBox_palNum
            // 
            comboBox_palNum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox_palNum.FormattingEnabled = true;
            comboBox_palNum.Location = new System.Drawing.Point(77, 45);
            comboBox_palNum.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            comboBox_palNum.Name = "comboBox_palNum";
            comboBox_palNum.Size = new System.Drawing.Size(52, 23);
            comboBox_palNum.TabIndex = 11;
            comboBox_palNum.SelectedIndexChanged += comboBox_paletteNum_SelectedIndexChanged;
            // 
            // pictureBox_pal
            // 
            pictureBox_pal.Location = new System.Drawing.Point(14, 14);
            pictureBox_pal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox_pal.Name = "pictureBox_pal";
            pictureBox_pal.Size = new System.Drawing.Size(300, 20);
            pictureBox_pal.TabIndex = 10;
            pictureBox_pal.TabStop = false;
            // 
            // statusStrip
            // 
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { statusLabel_changes });
            statusStrip.Location = new System.Drawing.Point(0, 240);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            statusStrip.Size = new System.Drawing.Size(365, 22);
            statusStrip.TabIndex = 2;
            statusStrip.Text = "statusStrip1";
            // 
            // statusLabel_changes
            // 
            statusLabel_changes.Name = "statusLabel_changes";
            statusLabel_changes.Size = new System.Drawing.Size(12, 17);
            statusLabel_changes.Text = "-";
            // 
            // FormAnimation
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(365, 262);
            Controls.Add(statusStrip);
            Controls.Add(tabControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "FormAnimation";
            Text = "Animation Editor";
            tabControl.ResumeLayout(false);
            tabPage_tileset.ResumeLayout(false);
            tabPage_tileset.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_tileset).EndInit();
            tabPage_graphics.ResumeLayout(false);
            tabPage_graphics.PerformLayout();
            tabPage_palette.ResumeLayout(false);
            tabPage_palette.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox_pal).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private mage.Theming.CustomControls.FlatTabControl tabControl;
        private System.Windows.Forms.TabPage tabPage_tileset;
        private System.Windows.Forms.Button button_tilesetClose;
        private System.Windows.Forms.Button button_tilesetApply;
        private System.Windows.Forms.TabPage tabPage_graphics;
        private System.Windows.Forms.Button button_gfxClose;
        private System.Windows.Forms.Button button_gfxApply;
        private System.Windows.Forms.TabPage tabPage_palette;
        private mage.Theming.CustomControls.FlatComboBox comboBox_tilesetNum;
        private System.Windows.Forms.PictureBox pictureBox_tileset;
        private System.Windows.Forms.Label label_tilesetSlot;
        private mage.Theming.CustomControls.FlatComboBox comboBox_tilesetSlot;
        private System.Windows.Forms.Label label_tilesetNum;
        private System.Windows.Forms.PictureBox pictureBox_pal;
        private mage.Theming.CustomControls.FlatComboBox comboBox_palNum;
        private mage.Theming.CustomControls.FlatComboBox comboBox_tilesetGfxNum;
        private mage.Theming.CustomControls.FlatComboBox comboBox_gfxNum;
        private System.Windows.Forms.Label label_gfxNum;
        private mage.Theming.CustomControls.FlatComboBox comboBox_gfxDirection;
        private System.Windows.Forms.Label label_gfxDirection;
        private System.Windows.Forms.Button button_palClose;
        private System.Windows.Forms.Button button_palApply;
        private System.Windows.Forms.Label label_palNum;
        private mage.Theming.CustomControls.FlatTextBox textBox_gfxDelay;
        private System.Windows.Forms.Label label_gfxDelay;
        private mage.Theming.CustomControls.FlatTextBox textBox_gfxStates;
        private System.Windows.Forms.Label label_gfxStates;
        private mage.Theming.CustomControls.FlatTextBox textBox_palStates;
        private System.Windows.Forms.Label label_palStates;
        private mage.Theming.CustomControls.FlatTextBox textBox_palDelay;
        private System.Windows.Forms.Label label_palDelay;
        private System.Windows.Forms.Label label_palDirection;
        private mage.Theming.CustomControls.FlatComboBox comboBox_palDirection;
        private System.Windows.Forms.Label label_tilesetGfx;
        private System.Windows.Forms.Button button_gfxEdit;
        private System.Windows.Forms.Button button_palEdit;
        private mage.Theming.CustomControls.FlatComboBox comboBox_gfxView;
        private System.Windows.Forms.Label label_gfxView;
        private mage.Theming.CustomControls.FlatTextBox textBox_gfxPalOffset;
        private System.Windows.Forms.Label label_gfxPal;
        private GfxView gfxView_gfx;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel_changes;
    }
}