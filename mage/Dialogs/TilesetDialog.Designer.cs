namespace mage.Dialogs
{
    partial class TilesetDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TilesetDialog));
            pnl_flow = new System.Windows.Forms.FlowLayoutPanel();
            SuspendLayout();
            // 
            // pnl_flow
            // 
            pnl_flow.AutoScroll = true;
            pnl_flow.Dock = System.Windows.Forms.DockStyle.Fill;
            pnl_flow.Location = new System.Drawing.Point(0, 0);
            pnl_flow.Name = "pnl_flow";
            pnl_flow.Size = new System.Drawing.Size(836, 761);
            pnl_flow.TabIndex = 0;
            // 
            // TilesetDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(836, 761);
            Controls.Add(pnl_flow);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(307, 500);
            Name = "TilesetDialog";
            Text = "Select Tileset";
            Resize += TilesetDialog_Resize;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel pnl_flow;
    }
}