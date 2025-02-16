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
            tabPage_offset = new System.Windows.Forms.TabPage();
            group_table = new System.Windows.Forms.GroupBox();
            panel_tableView = new System.Windows.Forms.Panel();
            tableView = new Controls.TileDisplay();
            toolStrip_table = new System.Windows.Forms.ToolStrip();
            button_tableZoomIn = new System.Windows.Forms.ToolStripButton();
            button_tableZoomOut = new System.Windows.Forms.ToolStripButton();
            label_tableZoom = new System.Windows.Forms.ToolStripLabel();
            statusStrip_main = new System.Windows.Forms.StatusStrip();
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
            group_table.SuspendLayout();
            panel_tableView.SuspendLayout();
            toolStrip_table.SuspendLayout();
            SuspendLayout();
            // 
            // panel_gfxView
            // 
            panel_gfxView.AutoScroll = true;
            panel_gfxView.Controls.Add(gfxView);
            panel_gfxView.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_gfxView.Location = new System.Drawing.Point(3, 44);
            panel_gfxView.Name = "panel_gfxView";
            panel_gfxView.Size = new System.Drawing.Size(438, 400);
            panel_gfxView.TabIndex = 0;
            // 
            // gfxView
            // 
            gfxView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gfxView.Location = new System.Drawing.Point(0, 6);
            gfxView.Name = "gfxView";
            gfxView.ShowGrid = false;
            gfxView.Size = new System.Drawing.Size(202, 129);
            gfxView.TabIndex = 0;
            gfxView.TabStop = false;
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
            // 
            // panel_Main.Panel2
            // 
            panel_Main.Panel2.Controls.Add(group_table);
            panel_Main.Panel2.Padding = new System.Windows.Forms.Padding(3, 3, 6, 3);
            panel_Main.Size = new System.Drawing.Size(1278, 859);
            panel_Main.SplitterDistance = 453;
            panel_Main.TabIndex = 1;
            // 
            // panel_gfxAndPal
            // 
            panel_gfxAndPal.Dock = System.Windows.Forms.DockStyle.Fill;
            panel_gfxAndPal.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            panel_gfxAndPal.Location = new System.Drawing.Point(0, 132);
            panel_gfxAndPal.Name = "panel_gfxAndPal";
            panel_gfxAndPal.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // panel_gfxAndPal.Panel1
            // 
            panel_gfxAndPal.Panel1.Controls.Add(group_palette);
            panel_gfxAndPal.Panel1.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            // 
            // panel_gfxAndPal.Panel2
            // 
            panel_gfxAndPal.Panel2.Controls.Add(group_gfx);
            panel_gfxAndPal.Panel2.Padding = new System.Windows.Forms.Padding(6, 3, 3, 3);
            panel_gfxAndPal.Size = new System.Drawing.Size(453, 727);
            panel_gfxAndPal.SplitterDistance = 270;
            panel_gfxAndPal.TabIndex = 1;
            // 
            // group_palette
            // 
            group_palette.Controls.Add(paletteView);
            group_palette.Controls.Add(comboBox_palette);
            group_palette.Controls.Add(label_pal);
            group_palette.Dock = System.Windows.Forms.DockStyle.Fill;
            group_palette.Location = new System.Drawing.Point(6, 3);
            group_palette.Name = "group_palette";
            group_palette.Size = new System.Drawing.Size(444, 264);
            group_palette.TabIndex = 0;
            group_palette.TabStop = false;
            group_palette.Text = "Palette";
            // 
            // paletteView
            // 
            paletteView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            paletteView.Location = new System.Drawing.Point(8, 51);
            paletteView.Name = "paletteView";
            paletteView.ShowGrid = false;
            paletteView.Size = new System.Drawing.Size(75, 23);
            paletteView.TabIndex = 2;
            paletteView.TabStop = false;
            paletteView.Text = "tileDisplay1";
            paletteView.TileImage = null;
            paletteView.TileSize = 16;
            paletteView.Zoom = 0;
            // 
            // comboBox_palette
            // 
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
            group_gfx.Size = new System.Drawing.Size(444, 447);
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
            toolStrip_gfx.Size = new System.Drawing.Size(438, 25);
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
            panel_select.Size = new System.Drawing.Size(453, 132);
            panel_select.TabIndex = 3;
            // 
            // tab_select
            // 
            tab_select.BorderColor = System.Drawing.Color.Empty;
            tab_select.Controls.Add(tabPage_tileset);
            tab_select.Controls.Add(tabPage_background);
            tab_select.Controls.Add(tabPage_offset);
            tab_select.Dock = System.Windows.Forms.DockStyle.Left;
            tab_select.Location = new System.Drawing.Point(6, 3);
            tab_select.Name = "tab_select";
            tab_select.SelectedIndex = 0;
            tab_select.Size = new System.Drawing.Size(274, 126);
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
            tabPage_tileset.Size = new System.Drawing.Size(266, 97);
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
            tabPage_background.Location = new System.Drawing.Point(4, 25);
            tabPage_background.Name = "tabPage_background";
            tabPage_background.Size = new System.Drawing.Size(192, 71);
            tabPage_background.TabIndex = 1;
            tabPage_background.Text = "Background";
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
            group_table.Size = new System.Drawing.Size(812, 853);
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
            panel_tableView.Size = new System.Drawing.Size(806, 806);
            panel_tableView.TabIndex = 1;
            // 
            // tableView
            // 
            tableView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tableView.Location = new System.Drawing.Point(0, 6);
            tableView.Name = "tableView";
            tableView.ShowGrid = false;
            tableView.Size = new System.Drawing.Size(307, 176);
            tableView.TabIndex = 0;
            tableView.TabStop = false;
            tableView.Text = "tileDisplay1";
            tableView.TileImage = null;
            tableView.TileSize = 16;
            tableView.Zoom = 0;
            tableView.Scrolled += tableView_Scrolled;
            // 
            // toolStrip_table
            // 
            toolStrip_table.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            toolStrip_table.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { button_tableZoomIn, button_tableZoomOut, label_tableZoom });
            toolStrip_table.Location = new System.Drawing.Point(3, 19);
            toolStrip_table.Name = "toolStrip_table";
            toolStrip_table.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            toolStrip_table.Size = new System.Drawing.Size(806, 25);
            toolStrip_table.TabIndex = 0;
            toolStrip_table.Text = "toolStrip1";
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
            label_tableZoom.Name = "label_tableZoom";
            label_tableZoom.Size = new System.Drawing.Size(35, 22);
            label_tableZoom.Text = "100%";
            // 
            // statusStrip_main
            // 
            statusStrip_main.Location = new System.Drawing.Point(0, 859);
            statusStrip_main.Name = "statusStrip_main";
            statusStrip_main.Size = new System.Drawing.Size(1278, 22);
            statusStrip_main.TabIndex = 2;
            statusStrip_main.Text = "statusStrip1";
            // 
            // FormTileTableNew
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(1278, 881);
            Controls.Add(panel_Main);
            Controls.Add(statusStrip_main);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormTileTableNew";
            Text = "Tile Table Editor";
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
            group_table.ResumeLayout(false);
            group_table.PerformLayout();
            panel_tableView.ResumeLayout(false);
            toolStrip_table.ResumeLayout(false);
            toolStrip_table.PerformLayout();
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
    }
}