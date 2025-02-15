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
            tile_gfxView = new Controls.TileDisplay();
            panel_gfxView.SuspendLayout();
            SuspendLayout();
            // 
            // panel_gfxView
            // 
            panel_gfxView.AutoScroll = true;
            panel_gfxView.Controls.Add(tile_gfxView);
            panel_gfxView.Location = new System.Drawing.Point(12, 133);
            panel_gfxView.Name = "panel_gfxView";
            panel_gfxView.Size = new System.Drawing.Size(633, 420);
            panel_gfxView.TabIndex = 0;
            // 
            // tile_gfxView
            // 
            tile_gfxView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            tile_gfxView.Location = new System.Drawing.Point(0, 0);
            tile_gfxView.Name = "tile_gfxView";
            tile_gfxView.ShowGrid = false;
            tile_gfxView.Size = new System.Drawing.Size(202, 129);
            tile_gfxView.TabIndex = 0;
            tile_gfxView.TabStop = false;
            tile_gfxView.Text = "tileDisplay1";
            tile_gfxView.TileImage = null;
            tile_gfxView.TileSize = 8;
            tile_gfxView.Zoom = 0;
            tile_gfxView.TileMouseDown += tile_gfxView_TileMouseDown;
            tile_gfxView.TileMouseMove += tile_gfxView_TileMouseMove;
            // 
            // FormTileTableNew
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(901, 770);
            Controls.Add(panel_gfxView);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormTileTableNew";
            Text = "Tile Table Editor";
            panel_gfxView.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel_gfxView;
        private Controls.TileDisplay tile_gfxView;
    }
}