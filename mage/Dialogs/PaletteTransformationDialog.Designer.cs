namespace mage.Dialogs
{
    partial class PaletteTransformationDialog
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
            tabControl = new mage.Theming.CustomControls.FlatTabControl();
            tab_hue = new System.Windows.Forms.TabPage();
            button_resetLightness = new System.Windows.Forms.Button();
            button_resetChroma = new System.Windows.Forms.Button();
            button_resetHue = new System.Windows.Forms.Button();
            num_lightness = new mage.Theming.CustomControls.FlatNumericUpDown();
            num_chroma = new mage.Theming.CustomControls.FlatNumericUpDown();
            num_hue = new mage.Theming.CustomControls.FlatNumericUpDown();
            lbl_lightness = new System.Windows.Forms.Label();
            lbl_chroma = new System.Windows.Forms.Label();
            trackBar_lightness = new mage.Theming.CustomControls.FlatTrackBar();
            trackBar_chroma = new mage.Theming.CustomControls.FlatTrackBar();
            lbl_hue = new System.Windows.Forms.Label();
            trackBar_hue = new mage.Theming.CustomControls.FlatTrackBar();
            tab_gradient = new System.Windows.Forms.TabPage();
            radio_gradientVertical = new System.Windows.Forms.RadioButton();
            radio_gradientHorizontal = new System.Windows.Forms.RadioButton();
            tab_inversion = new System.Windows.Forms.TabPage();
            check_inversionPreserveLightness = new System.Windows.Forms.CheckBox();
            pnl_inversionChannels = new System.Windows.Forms.Panel();
            check_invertR = new System.Windows.Forms.CheckBox();
            check_invertB = new System.Windows.Forms.CheckBox();
            check_invertG = new System.Windows.Forms.CheckBox();
            tab_swap = new System.Windows.Forms.TabPage();
            lbl_swapBChannel = new System.Windows.Forms.Label();
            lbl_swapGChannel = new System.Windows.Forms.Label();
            lbl_swapB = new System.Windows.Forms.Label();
            lbl_swapG = new System.Windows.Forms.Label();
            lbl_swapRChannel = new System.Windows.Forms.Label();
            lbl_swapR = new System.Windows.Forms.Label();
            cbb_swapB = new mage.Theming.CustomControls.FlatComboBox();
            cbb_swapG = new mage.Theming.CustomControls.FlatComboBox();
            cbb_swapR = new mage.Theming.CustomControls.FlatComboBox();
            tab_posterize = new System.Windows.Forms.TabPage();
            button_posterizeReset = new System.Windows.Forms.Button();
            num_posterize = new mage.Theming.CustomControls.FlatNumericUpDown();
            lbl_posterize = new System.Windows.Forms.Label();
            trackBar_posterize = new mage.Theming.CustomControls.FlatTrackBar();
            tab_tint = new System.Windows.Forms.TabPage();
            radio_tintBlendOklab = new System.Windows.Forms.RadioButton();
            radio_tintBlendRgb = new System.Windows.Forms.RadioButton();
            lbl_tintMode = new System.Windows.Forms.Label();
            button_tintBlendReset = new System.Windows.Forms.Button();
            num_tintBlend = new mage.Theming.CustomControls.FlatNumericUpDown();
            trackBar_tintBlend = new mage.Theming.CustomControls.FlatTrackBar();
            lbl_tintBlend = new System.Windows.Forms.Label();
            pnl_colorPicker = new System.Windows.Forms.Panel();
            lbl_tintColor = new System.Windows.Forms.Label();
            button_apply = new System.Windows.Forms.Button();
            button_cancel = new System.Windows.Forms.Button();
            pnl_generic = new System.Windows.Forms.Panel();
            checkBox_preview = new System.Windows.Forms.CheckBox();
            tabControl.SuspendLayout();
            tab_hue.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_lightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_chroma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_hue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_lightness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_chroma).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_hue).BeginInit();
            tab_gradient.SuspendLayout();
            tab_inversion.SuspendLayout();
            pnl_inversionChannels.SuspendLayout();
            tab_swap.SuspendLayout();
            tab_posterize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_posterize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_posterize).BeginInit();
            tab_tint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)num_tintBlend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_tintBlend).BeginInit();
            pnl_generic.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.BorderColor = System.Drawing.Color.Empty;
            tabControl.Controls.Add(tab_hue);
            tabControl.Controls.Add(tab_gradient);
            tabControl.Controls.Add(tab_inversion);
            tabControl.Controls.Add(tab_swap);
            tabControl.Controls.Add(tab_posterize);
            tabControl.Controls.Add(tab_tint);
            tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            tabControl.Location = new System.Drawing.Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new System.Drawing.Size(362, 121);
            tabControl.TabIndex = 0;
            tabControl.SelectedIndexChanged += tabControl_TabIndexChanged;
            // 
            // tab_hue
            // 
            tab_hue.Controls.Add(button_resetLightness);
            tab_hue.Controls.Add(button_resetChroma);
            tab_hue.Controls.Add(button_resetHue);
            tab_hue.Controls.Add(num_lightness);
            tab_hue.Controls.Add(num_chroma);
            tab_hue.Controls.Add(num_hue);
            tab_hue.Controls.Add(lbl_lightness);
            tab_hue.Controls.Add(lbl_chroma);
            tab_hue.Controls.Add(trackBar_lightness);
            tab_hue.Controls.Add(trackBar_chroma);
            tab_hue.Controls.Add(lbl_hue);
            tab_hue.Controls.Add(trackBar_hue);
            tab_hue.Location = new System.Drawing.Point(4, 25);
            tab_hue.Name = "tab_hue";
            tab_hue.Padding = new System.Windows.Forms.Padding(3);
            tab_hue.Size = new System.Drawing.Size(354, 92);
            tab_hue.TabIndex = 1;
            tab_hue.Text = "Shift";
            tab_hue.UseVisualStyleBackColor = true;
            // 
            // button_resetLightness
            // 
            button_resetLightness.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_resetLightness.Enabled = false;
            button_resetLightness.Image = Properties.Resources.toolbar_undo;
            button_resetLightness.Location = new System.Drawing.Point(324, 61);
            button_resetLightness.Name = "button_resetLightness";
            button_resetLightness.Size = new System.Drawing.Size(23, 23);
            button_resetLightness.TabIndex = 11;
            button_resetLightness.UseVisualStyleBackColor = true;
            button_resetLightness.Click += button_resetLightness_Click;
            // 
            // button_resetChroma
            // 
            button_resetChroma.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_resetChroma.Enabled = false;
            button_resetChroma.Image = Properties.Resources.toolbar_undo;
            button_resetChroma.Location = new System.Drawing.Point(324, 32);
            button_resetChroma.Name = "button_resetChroma";
            button_resetChroma.Size = new System.Drawing.Size(23, 23);
            button_resetChroma.TabIndex = 10;
            button_resetChroma.UseVisualStyleBackColor = true;
            button_resetChroma.Click += button_resetChroma_Click;
            // 
            // button_resetHue
            // 
            button_resetHue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_resetHue.Enabled = false;
            button_resetHue.Image = Properties.Resources.toolbar_undo;
            button_resetHue.Location = new System.Drawing.Point(324, 3);
            button_resetHue.Name = "button_resetHue";
            button_resetHue.Size = new System.Drawing.Size(23, 23);
            button_resetHue.TabIndex = 9;
            button_resetHue.UseVisualStyleBackColor = true;
            button_resetHue.Click += button_resetHue_Click;
            // 
            // num_lightness
            // 
            num_lightness.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_lightness.Location = new System.Drawing.Point(272, 61);
            num_lightness.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            num_lightness.Name = "num_lightness";
            num_lightness.Size = new System.Drawing.Size(46, 23);
            num_lightness.TabIndex = 8;
            num_lightness.ValueChanged += num_hue_ValueChanged;
            // 
            // num_chroma
            // 
            num_chroma.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_chroma.Location = new System.Drawing.Point(272, 32);
            num_chroma.Minimum = new decimal(new int[] { 100, 0, 0, int.MinValue });
            num_chroma.Name = "num_chroma";
            num_chroma.Size = new System.Drawing.Size(46, 23);
            num_chroma.TabIndex = 7;
            num_chroma.ValueChanged += num_hue_ValueChanged;
            // 
            // num_hue
            // 
            num_hue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_hue.Location = new System.Drawing.Point(272, 3);
            num_hue.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            num_hue.Minimum = new decimal(new int[] { 180, 0, 0, int.MinValue });
            num_hue.Name = "num_hue";
            num_hue.Size = new System.Drawing.Size(46, 23);
            num_hue.TabIndex = 6;
            num_hue.ValueChanged += num_hue_ValueChanged;
            // 
            // lbl_lightness
            // 
            lbl_lightness.AutoSize = true;
            lbl_lightness.Location = new System.Drawing.Point(8, 63);
            lbl_lightness.Name = "lbl_lightness";
            lbl_lightness.Size = new System.Drawing.Size(60, 15);
            lbl_lightness.TabIndex = 5;
            lbl_lightness.Text = "Lightness:";
            // 
            // lbl_chroma
            // 
            lbl_chroma.AutoSize = true;
            lbl_chroma.Location = new System.Drawing.Point(8, 34);
            lbl_chroma.Name = "lbl_chroma";
            lbl_chroma.Size = new System.Drawing.Size(53, 15);
            lbl_chroma.TabIndex = 4;
            lbl_chroma.Text = "Chroma:";
            // 
            // trackBar_lightness
            // 
            trackBar_lightness.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar_lightness.BorderColor = System.Drawing.Color.DimGray;
            trackBar_lightness.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_lightness.Location = new System.Drawing.Point(74, 59);
            trackBar_lightness.Maximum = 100;
            trackBar_lightness.Minimum = -100;
            trackBar_lightness.Name = "trackBar_lightness";
            trackBar_lightness.Size = new System.Drawing.Size(192, 23);
            trackBar_lightness.TabIndex = 3;
            trackBar_lightness.ThumbColor = System.Drawing.Color.White;
            trackBar_lightness.ThumbWidth = 10;
            trackBar_lightness.TrackColor = System.Drawing.Color.Gray;
            trackBar_lightness.TrackHeight = 4;
            trackBar_lightness.ValueChanged += trackBar_lightness_ValueChanged;
            // 
            // trackBar_chroma
            // 
            trackBar_chroma.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar_chroma.BorderColor = System.Drawing.Color.DimGray;
            trackBar_chroma.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_chroma.Location = new System.Drawing.Point(74, 30);
            trackBar_chroma.Maximum = 100;
            trackBar_chroma.Minimum = -100;
            trackBar_chroma.Name = "trackBar_chroma";
            trackBar_chroma.Size = new System.Drawing.Size(192, 23);
            trackBar_chroma.TabIndex = 2;
            trackBar_chroma.ThumbColor = System.Drawing.Color.White;
            trackBar_chroma.ThumbWidth = 10;
            trackBar_chroma.TrackColor = System.Drawing.Color.Gray;
            trackBar_chroma.TrackHeight = 4;
            trackBar_chroma.ValueChanged += trackBar_lightness_ValueChanged;
            // 
            // lbl_hue
            // 
            lbl_hue.AutoSize = true;
            lbl_hue.Location = new System.Drawing.Point(8, 5);
            lbl_hue.Name = "lbl_hue";
            lbl_hue.Size = new System.Drawing.Size(32, 15);
            lbl_hue.TabIndex = 1;
            lbl_hue.Text = "Hue:";
            // 
            // trackBar_hue
            // 
            trackBar_hue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar_hue.BorderColor = System.Drawing.Color.DimGray;
            trackBar_hue.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_hue.Location = new System.Drawing.Point(74, 1);
            trackBar_hue.Maximum = 180;
            trackBar_hue.Minimum = -180;
            trackBar_hue.Name = "trackBar_hue";
            trackBar_hue.Size = new System.Drawing.Size(192, 23);
            trackBar_hue.TabIndex = 0;
            trackBar_hue.ThumbColor = System.Drawing.Color.White;
            trackBar_hue.ThumbWidth = 10;
            trackBar_hue.TrackColor = System.Drawing.Color.Gray;
            trackBar_hue.TrackHeight = 4;
            trackBar_hue.ValueChanged += trackBar_lightness_ValueChanged;
            // 
            // tab_gradient
            // 
            tab_gradient.Controls.Add(radio_gradientVertical);
            tab_gradient.Controls.Add(radio_gradientHorizontal);
            tab_gradient.Location = new System.Drawing.Point(4, 25);
            tab_gradient.Name = "tab_gradient";
            tab_gradient.Padding = new System.Windows.Forms.Padding(3);
            tab_gradient.Size = new System.Drawing.Size(192, 71);
            tab_gradient.TabIndex = 0;
            tab_gradient.Text = "Gradient";
            tab_gradient.UseVisualStyleBackColor = true;
            // 
            // radio_gradientVertical
            // 
            radio_gradientVertical.AutoSize = true;
            radio_gradientVertical.Location = new System.Drawing.Point(8, 31);
            radio_gradientVertical.Name = "radio_gradientVertical";
            radio_gradientVertical.Size = new System.Drawing.Size(63, 19);
            radio_gradientVertical.TabIndex = 1;
            radio_gradientVertical.Text = "Vertical";
            radio_gradientVertical.UseVisualStyleBackColor = true;
            radio_gradientVertical.CheckedChanged += radio_gradientVertical_CheckedChanged;
            // 
            // radio_gradientHorizontal
            // 
            radio_gradientHorizontal.AutoSize = true;
            radio_gradientHorizontal.Checked = true;
            radio_gradientHorizontal.Location = new System.Drawing.Point(8, 6);
            radio_gradientHorizontal.Name = "radio_gradientHorizontal";
            radio_gradientHorizontal.Size = new System.Drawing.Size(80, 19);
            radio_gradientHorizontal.TabIndex = 0;
            radio_gradientHorizontal.TabStop = true;
            radio_gradientHorizontal.Text = "Horizontal";
            radio_gradientHorizontal.UseVisualStyleBackColor = true;
            radio_gradientHorizontal.CheckedChanged += radio_gradientVertical_CheckedChanged;
            // 
            // tab_inversion
            // 
            tab_inversion.Controls.Add(check_inversionPreserveLightness);
            tab_inversion.Controls.Add(pnl_inversionChannels);
            tab_inversion.Location = new System.Drawing.Point(4, 25);
            tab_inversion.Name = "tab_inversion";
            tab_inversion.Size = new System.Drawing.Size(192, 71);
            tab_inversion.TabIndex = 2;
            tab_inversion.Text = "Invert";
            // 
            // check_inversionPreserveLightness
            // 
            check_inversionPreserveLightness.AutoSize = true;
            check_inversionPreserveLightness.Location = new System.Drawing.Point(122, 6);
            check_inversionPreserveLightness.Name = "check_inversionPreserveLightness";
            check_inversionPreserveLightness.Size = new System.Drawing.Size(123, 19);
            check_inversionPreserveLightness.TabIndex = 4;
            check_inversionPreserveLightness.Text = "Preserve Lightness";
            check_inversionPreserveLightness.UseVisualStyleBackColor = true;
            check_inversionPreserveLightness.CheckedChanged += check_invertR_CheckedChanged;
            // 
            // pnl_inversionChannels
            // 
            pnl_inversionChannels.Controls.Add(check_invertR);
            pnl_inversionChannels.Controls.Add(check_invertB);
            pnl_inversionChannels.Controls.Add(check_invertG);
            pnl_inversionChannels.Location = new System.Drawing.Point(3, 3);
            pnl_inversionChannels.Name = "pnl_inversionChannels";
            pnl_inversionChannels.Size = new System.Drawing.Size(113, 86);
            pnl_inversionChannels.TabIndex = 3;
            // 
            // check_invertR
            // 
            check_invertR.AutoSize = true;
            check_invertR.Checked = true;
            check_invertR.CheckState = System.Windows.Forms.CheckState.Checked;
            check_invertR.Location = new System.Drawing.Point(5, 3);
            check_invertR.Name = "check_invertR";
            check_invertR.Size = new System.Drawing.Size(93, 19);
            check_invertR.TabIndex = 0;
            check_invertR.Text = "Red Channel";
            check_invertR.UseVisualStyleBackColor = true;
            check_invertR.CheckedChanged += check_invertR_CheckedChanged;
            // 
            // check_invertB
            // 
            check_invertB.AutoSize = true;
            check_invertB.Checked = true;
            check_invertB.CheckState = System.Windows.Forms.CheckState.Checked;
            check_invertB.Location = new System.Drawing.Point(5, 53);
            check_invertB.Name = "check_invertB";
            check_invertB.Size = new System.Drawing.Size(96, 19);
            check_invertB.TabIndex = 2;
            check_invertB.Text = "Blue Channel";
            check_invertB.UseVisualStyleBackColor = true;
            check_invertB.CheckedChanged += check_invertR_CheckedChanged;
            // 
            // check_invertG
            // 
            check_invertG.AutoSize = true;
            check_invertG.Checked = true;
            check_invertG.CheckState = System.Windows.Forms.CheckState.Checked;
            check_invertG.Location = new System.Drawing.Point(5, 28);
            check_invertG.Name = "check_invertG";
            check_invertG.Size = new System.Drawing.Size(104, 19);
            check_invertG.TabIndex = 1;
            check_invertG.Text = "Green Channel";
            check_invertG.UseVisualStyleBackColor = true;
            check_invertG.CheckedChanged += check_invertR_CheckedChanged;
            // 
            // tab_swap
            // 
            tab_swap.Controls.Add(lbl_swapBChannel);
            tab_swap.Controls.Add(lbl_swapGChannel);
            tab_swap.Controls.Add(lbl_swapB);
            tab_swap.Controls.Add(lbl_swapG);
            tab_swap.Controls.Add(lbl_swapRChannel);
            tab_swap.Controls.Add(lbl_swapR);
            tab_swap.Controls.Add(cbb_swapB);
            tab_swap.Controls.Add(cbb_swapG);
            tab_swap.Controls.Add(cbb_swapR);
            tab_swap.Location = new System.Drawing.Point(4, 25);
            tab_swap.Name = "tab_swap";
            tab_swap.Size = new System.Drawing.Size(192, 71);
            tab_swap.TabIndex = 3;
            tab_swap.Text = "Swap";
            // 
            // lbl_swapBChannel
            // 
            lbl_swapBChannel.AutoSize = true;
            lbl_swapBChannel.Location = new System.Drawing.Point(235, 64);
            lbl_swapBChannel.Name = "lbl_swapBChannel";
            lbl_swapBChannel.Size = new System.Drawing.Size(54, 15);
            lbl_swapBChannel.TabIndex = 8;
            lbl_swapBChannel.Text = "Channel.";
            // 
            // lbl_swapGChannel
            // 
            lbl_swapGChannel.AutoSize = true;
            lbl_swapGChannel.Location = new System.Drawing.Point(235, 35);
            lbl_swapGChannel.Name = "lbl_swapGChannel";
            lbl_swapGChannel.Size = new System.Drawing.Size(54, 15);
            lbl_swapGChannel.TabIndex = 7;
            lbl_swapGChannel.Text = "Channel.";
            // 
            // lbl_swapB
            // 
            lbl_swapB.AutoSize = true;
            lbl_swapB.Location = new System.Drawing.Point(8, 64);
            lbl_swapB.Name = "lbl_swapB";
            lbl_swapB.Size = new System.Drawing.Size(134, 15);
            lbl_swapB.TabIndex = 6;
            lbl_swapB.Text = "Swap Blue Channel with";
            // 
            // lbl_swapG
            // 
            lbl_swapG.AutoSize = true;
            lbl_swapG.Location = new System.Drawing.Point(8, 35);
            lbl_swapG.Name = "lbl_swapG";
            lbl_swapG.Size = new System.Drawing.Size(142, 15);
            lbl_swapG.TabIndex = 5;
            lbl_swapG.Text = "Swap Green Channel with";
            // 
            // lbl_swapRChannel
            // 
            lbl_swapRChannel.AutoSize = true;
            lbl_swapRChannel.Location = new System.Drawing.Point(235, 6);
            lbl_swapRChannel.Name = "lbl_swapRChannel";
            lbl_swapRChannel.Size = new System.Drawing.Size(54, 15);
            lbl_swapRChannel.TabIndex = 4;
            lbl_swapRChannel.Text = "Channel.";
            // 
            // lbl_swapR
            // 
            lbl_swapR.AutoSize = true;
            lbl_swapR.Location = new System.Drawing.Point(8, 6);
            lbl_swapR.Name = "lbl_swapR";
            lbl_swapR.Size = new System.Drawing.Size(131, 15);
            lbl_swapR.TabIndex = 3;
            lbl_swapR.Text = "Swap Red Channel with";
            // 
            // cbb_swapB
            // 
            cbb_swapB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbb_swapB.FormattingEnabled = true;
            cbb_swapB.Location = new System.Drawing.Point(156, 61);
            cbb_swapB.Name = "cbb_swapB";
            cbb_swapB.Size = new System.Drawing.Size(73, 23);
            cbb_swapB.TabIndex = 2;
            cbb_swapB.SelectedIndexChanged += cbb_swapR_SelectedIndexChanged;
            // 
            // cbb_swapG
            // 
            cbb_swapG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbb_swapG.FormattingEnabled = true;
            cbb_swapG.Location = new System.Drawing.Point(156, 32);
            cbb_swapG.Name = "cbb_swapG";
            cbb_swapG.Size = new System.Drawing.Size(73, 23);
            cbb_swapG.TabIndex = 1;
            cbb_swapG.SelectedIndexChanged += cbb_swapR_SelectedIndexChanged;
            // 
            // cbb_swapR
            // 
            cbb_swapR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbb_swapR.FormattingEnabled = true;
            cbb_swapR.Location = new System.Drawing.Point(156, 3);
            cbb_swapR.Name = "cbb_swapR";
            cbb_swapR.Size = new System.Drawing.Size(73, 23);
            cbb_swapR.TabIndex = 0;
            cbb_swapR.SelectedIndexChanged += cbb_swapR_SelectedIndexChanged;
            // 
            // tab_posterize
            // 
            tab_posterize.Controls.Add(button_posterizeReset);
            tab_posterize.Controls.Add(num_posterize);
            tab_posterize.Controls.Add(lbl_posterize);
            tab_posterize.Controls.Add(trackBar_posterize);
            tab_posterize.Location = new System.Drawing.Point(4, 25);
            tab_posterize.Name = "tab_posterize";
            tab_posterize.Size = new System.Drawing.Size(354, 92);
            tab_posterize.TabIndex = 4;
            tab_posterize.Text = "Posterize";
            // 
            // button_posterizeReset
            // 
            button_posterizeReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_posterizeReset.Enabled = false;
            button_posterizeReset.Image = Properties.Resources.toolbar_undo;
            button_posterizeReset.Location = new System.Drawing.Point(323, 24);
            button_posterizeReset.Name = "button_posterizeReset";
            button_posterizeReset.Size = new System.Drawing.Size(23, 23);
            button_posterizeReset.TabIndex = 10;
            button_posterizeReset.UseVisualStyleBackColor = true;
            button_posterizeReset.Click += button_posterizeReset_Click;
            // 
            // num_posterize
            // 
            num_posterize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_posterize.Location = new System.Drawing.Point(279, 24);
            num_posterize.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            num_posterize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            num_posterize.Name = "num_posterize";
            num_posterize.Size = new System.Drawing.Size(38, 23);
            num_posterize.TabIndex = 3;
            num_posterize.Value = new decimal(new int[] { 5, 0, 0, 0 });
            num_posterize.ValueChanged += num_posterize_ValueChanged;
            // 
            // lbl_posterize
            // 
            lbl_posterize.AutoSize = true;
            lbl_posterize.Location = new System.Drawing.Point(8, 6);
            lbl_posterize.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            lbl_posterize.Name = "lbl_posterize";
            lbl_posterize.Size = new System.Drawing.Size(96, 15);
            lbl_posterize.TabIndex = 2;
            lbl_posterize.Text = "Bits per Channel:";
            // 
            // trackBar_posterize
            // 
            trackBar_posterize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar_posterize.BorderColor = System.Drawing.Color.DimGray;
            trackBar_posterize.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_posterize.Location = new System.Drawing.Point(8, 22);
            trackBar_posterize.Maximum = 5;
            trackBar_posterize.Minimum = 1;
            trackBar_posterize.Name = "trackBar_posterize";
            trackBar_posterize.Size = new System.Drawing.Size(265, 23);
            trackBar_posterize.TabIndex = 1;
            trackBar_posterize.ThumbColor = System.Drawing.Color.White;
            trackBar_posterize.ThumbWidth = 10;
            trackBar_posterize.TrackColor = System.Drawing.Color.Gray;
            trackBar_posterize.TrackHeight = 4;
            trackBar_posterize.Value = 5;
            trackBar_posterize.ValueChanged += trackBar_posterize_ValueChanged;
            // 
            // tab_tint
            // 
            tab_tint.Controls.Add(radio_tintBlendOklab);
            tab_tint.Controls.Add(radio_tintBlendRgb);
            tab_tint.Controls.Add(lbl_tintMode);
            tab_tint.Controls.Add(button_tintBlendReset);
            tab_tint.Controls.Add(num_tintBlend);
            tab_tint.Controls.Add(trackBar_tintBlend);
            tab_tint.Controls.Add(lbl_tintBlend);
            tab_tint.Controls.Add(pnl_colorPicker);
            tab_tint.Controls.Add(lbl_tintColor);
            tab_tint.Location = new System.Drawing.Point(4, 25);
            tab_tint.Name = "tab_tint";
            tab_tint.Size = new System.Drawing.Size(354, 92);
            tab_tint.TabIndex = 5;
            tab_tint.Text = "Tint";
            // 
            // radio_tintBlendOklab
            // 
            radio_tintBlendOklab.AutoSize = true;
            radio_tintBlendOklab.Checked = true;
            radio_tintBlendOklab.Location = new System.Drawing.Point(199, 59);
            radio_tintBlendOklab.Name = "radio_tintBlendOklab";
            radio_tintBlendOklab.Size = new System.Drawing.Size(121, 19);
            radio_tintBlendOklab.TabIndex = 15;
            radio_tintBlendOklab.TabStop = true;
            radio_tintBlendOklab.Text = "OKLAB Perceptual";
            radio_tintBlendOklab.UseVisualStyleBackColor = true;
            radio_tintBlendOklab.CheckedChanged += radio_tintBlendRgb_CheckedChanged;
            // 
            // radio_tintBlendRgb
            // 
            radio_tintBlendRgb.AutoSize = true;
            radio_tintBlendRgb.Location = new System.Drawing.Point(102, 59);
            radio_tintBlendRgb.Name = "radio_tintBlendRgb";
            radio_tintBlendRgb.Size = new System.Drawing.Size(91, 19);
            radio_tintBlendRgb.TabIndex = 14;
            radio_tintBlendRgb.Text = "RGB Linearly";
            radio_tintBlendRgb.UseVisualStyleBackColor = true;
            radio_tintBlendRgb.CheckedChanged += radio_tintBlendRgb_CheckedChanged;
            // 
            // lbl_tintMode
            // 
            lbl_tintMode.AutoSize = true;
            lbl_tintMode.Location = new System.Drawing.Point(8, 61);
            lbl_tintMode.Name = "lbl_tintMode";
            lbl_tintMode.Size = new System.Drawing.Size(74, 15);
            lbl_tintMode.TabIndex = 13;
            lbl_tintMode.Text = "Blend Mode:";
            // 
            // button_tintBlendReset
            // 
            button_tintBlendReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_tintBlendReset.Enabled = false;
            button_tintBlendReset.Image = Properties.Resources.toolbar_undo;
            button_tintBlendReset.Location = new System.Drawing.Point(323, 30);
            button_tintBlendReset.Name = "button_tintBlendReset";
            button_tintBlendReset.Size = new System.Drawing.Size(23, 23);
            button_tintBlendReset.TabIndex = 12;
            button_tintBlendReset.UseVisualStyleBackColor = true;
            button_tintBlendReset.Click += button_tintBlendReset_Click;
            // 
            // num_tintBlend
            // 
            num_tintBlend.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            num_tintBlend.Location = new System.Drawing.Point(279, 30);
            num_tintBlend.Name = "num_tintBlend";
            num_tintBlend.Size = new System.Drawing.Size(38, 23);
            num_tintBlend.TabIndex = 11;
            num_tintBlend.Value = new decimal(new int[] { 50, 0, 0, 0 });
            num_tintBlend.ValueChanged += num_tintBlend_ValueChanged;
            // 
            // trackBar_tintBlend
            // 
            trackBar_tintBlend.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBar_tintBlend.BorderColor = System.Drawing.Color.DimGray;
            trackBar_tintBlend.FillColor = System.Drawing.Color.DodgerBlue;
            trackBar_tintBlend.Location = new System.Drawing.Point(102, 28);
            trackBar_tintBlend.Maximum = 100;
            trackBar_tintBlend.Name = "trackBar_tintBlend";
            trackBar_tintBlend.Size = new System.Drawing.Size(171, 23);
            trackBar_tintBlend.TabIndex = 3;
            trackBar_tintBlend.ThumbColor = System.Drawing.Color.White;
            trackBar_tintBlend.ThumbWidth = 10;
            trackBar_tintBlend.TrackColor = System.Drawing.Color.Gray;
            trackBar_tintBlend.TrackHeight = 4;
            trackBar_tintBlend.Value = 50;
            trackBar_tintBlend.ValueChanged += trackBar_tintBlend_ValueChanged;
            // 
            // lbl_tintBlend
            // 
            lbl_tintBlend.AutoSize = true;
            lbl_tintBlend.Location = new System.Drawing.Point(8, 34);
            lbl_tintBlend.Name = "lbl_tintBlend";
            lbl_tintBlend.Size = new System.Drawing.Size(88, 15);
            lbl_tintBlend.TabIndex = 2;
            lbl_tintBlend.Text = "Blend Strength:";
            // 
            // pnl_colorPicker
            // 
            pnl_colorPicker.Cursor = System.Windows.Forms.Cursors.Hand;
            pnl_colorPicker.Location = new System.Drawing.Point(102, 3);
            pnl_colorPicker.Name = "pnl_colorPicker";
            pnl_colorPicker.Size = new System.Drawing.Size(23, 23);
            pnl_colorPicker.TabIndex = 1;
            pnl_colorPicker.Tag = "unthemed";
            pnl_colorPicker.Click += pnl_colorPicker_Click;
            // 
            // lbl_tintColor
            // 
            lbl_tintColor.AutoSize = true;
            lbl_tintColor.Location = new System.Drawing.Point(8, 7);
            lbl_tintColor.Name = "lbl_tintColor";
            lbl_tintColor.Size = new System.Drawing.Size(39, 15);
            lbl_tintColor.TabIndex = 0;
            lbl_tintColor.Text = "Color:";
            // 
            // button_apply
            // 
            button_apply.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_apply.Location = new System.Drawing.Point(283, 6);
            button_apply.Name = "button_apply";
            button_apply.Size = new System.Drawing.Size(75, 23);
            button_apply.TabIndex = 1;
            button_apply.Text = "Apply";
            button_apply.UseVisualStyleBackColor = true;
            button_apply.Click += button_apply_Click;
            // 
            // button_cancel
            // 
            button_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            button_cancel.Location = new System.Drawing.Point(202, 6);
            button_cancel.Name = "button_cancel";
            button_cancel.Size = new System.Drawing.Size(75, 23);
            button_cancel.TabIndex = 2;
            button_cancel.Text = "Cancel";
            button_cancel.UseVisualStyleBackColor = true;
            button_cancel.Click += button_cancel_Click;
            // 
            // pnl_generic
            // 
            pnl_generic.Controls.Add(checkBox_preview);
            pnl_generic.Controls.Add(button_cancel);
            pnl_generic.Controls.Add(button_apply);
            pnl_generic.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnl_generic.Location = new System.Drawing.Point(0, 121);
            pnl_generic.Name = "pnl_generic";
            pnl_generic.Size = new System.Drawing.Size(362, 35);
            pnl_generic.TabIndex = 3;
            // 
            // checkBox_preview
            // 
            checkBox_preview.AutoSize = true;
            checkBox_preview.Checked = true;
            checkBox_preview.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBox_preview.Location = new System.Drawing.Point(12, 9);
            checkBox_preview.Name = "checkBox_preview";
            checkBox_preview.Size = new System.Drawing.Size(67, 19);
            checkBox_preview.TabIndex = 3;
            checkBox_preview.Text = "Preview";
            checkBox_preview.UseVisualStyleBackColor = true;
            checkBox_preview.CheckedChanged += checkBox_preview_CheckedChanged;
            // 
            // PaletteTransformationDialog
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(362, 156);
            Controls.Add(tabControl);
            Controls.Add(pnl_generic);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PaletteTransformationDialog";
            Text = "Transform Selection";
            tabControl.ResumeLayout(false);
            tab_hue.ResumeLayout(false);
            tab_hue.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_lightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_chroma).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_hue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_lightness).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_chroma).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_hue).EndInit();
            tab_gradient.ResumeLayout(false);
            tab_gradient.PerformLayout();
            tab_inversion.ResumeLayout(false);
            tab_inversion.PerformLayout();
            pnl_inversionChannels.ResumeLayout(false);
            pnl_inversionChannels.PerformLayout();
            tab_swap.ResumeLayout(false);
            tab_swap.PerformLayout();
            tab_posterize.ResumeLayout(false);
            tab_posterize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_posterize).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_posterize).EndInit();
            tab_tint.ResumeLayout(false);
            tab_tint.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)num_tintBlend).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_tintBlend).EndInit();
            pnl_generic.ResumeLayout(false);
            pnl_generic.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Theming.CustomControls.FlatTabControl tabControl;
        private System.Windows.Forms.TabPage tab_gradient;
        private System.Windows.Forms.TabPage tab_hue;
        private System.Windows.Forms.Button button_apply;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Panel pnl_generic;
        private System.Windows.Forms.CheckBox checkBox_preview;
        private System.Windows.Forms.RadioButton radio_gradientVertical;
        private System.Windows.Forms.RadioButton radio_gradientHorizontal;
        private mage.Theming.CustomControls.FlatTrackBar trackBar_hue;
        private System.Windows.Forms.Label lbl_lightness;
        private System.Windows.Forms.Label lbl_chroma;
        private mage.Theming.CustomControls.FlatTrackBar trackBar_lightness;
        private mage.Theming.CustomControls.FlatTrackBar trackBar_chroma;
        private System.Windows.Forms.Label lbl_hue;
        private Theming.CustomControls.FlatNumericUpDown num_lightness;
        private Theming.CustomControls.FlatNumericUpDown num_chroma;
        private Theming.CustomControls.FlatNumericUpDown num_hue;
        private System.Windows.Forms.Button button_resetHue;
        private System.Windows.Forms.Button button_resetLightness;
        private System.Windows.Forms.Button button_resetChroma;
        private System.Windows.Forms.TabPage tab_inversion;
        private System.Windows.Forms.TabPage tab_swap;
        private System.Windows.Forms.TabPage tab_posterize;
        private System.Windows.Forms.TabPage tab_tint;
        private System.Windows.Forms.CheckBox check_invertB;
        private System.Windows.Forms.CheckBox check_invertG;
        private System.Windows.Forms.CheckBox check_invertR;
        private System.Windows.Forms.CheckBox check_inversionPreserveLightness;
        private System.Windows.Forms.Panel pnl_inversionChannels;
        private Theming.CustomControls.FlatComboBox cbb_swapR;
        private System.Windows.Forms.Label lbl_swapBChannel;
        private System.Windows.Forms.Label lbl_swapGChannel;
        private System.Windows.Forms.Label lbl_swapB;
        private System.Windows.Forms.Label lbl_swapG;
        private System.Windows.Forms.Label lbl_swapRChannel;
        private System.Windows.Forms.Label lbl_swapR;
        private Theming.CustomControls.FlatComboBox cbb_swapB;
        private Theming.CustomControls.FlatComboBox cbb_swapG;
        private Theming.CustomControls.FlatTrackBar trackBar_posterize;
        private System.Windows.Forms.Button button_posterizeReset;
        private Theming.CustomControls.FlatNumericUpDown num_posterize;
        private System.Windows.Forms.Label lbl_posterize;
        private System.Windows.Forms.Label lbl_tintColor;
        private System.Windows.Forms.Panel pnl_colorPicker;
        private System.Windows.Forms.Label lbl_tintBlend;
        private System.Windows.Forms.RadioButton radio_tintBlendOklab;
        private System.Windows.Forms.RadioButton radio_tintBlendRgb;
        private System.Windows.Forms.Label lbl_tintMode;
        private System.Windows.Forms.Button button_tintBlendReset;
        private Theming.CustomControls.FlatNumericUpDown num_tintBlend;
        private Theming.CustomControls.FlatTrackBar trackBar_tintBlend;
    }
}