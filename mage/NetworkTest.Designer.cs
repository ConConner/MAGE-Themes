namespace mage
{
    partial class NetworkTest
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
            btn_start_server = new System.Windows.Forms.Button();
            btn_connect = new System.Windows.Forms.Button();
            btn_test_packet = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_start_server
            // 
            btn_start_server.Location = new System.Drawing.Point(12, 12);
            btn_start_server.Name = "btn_start_server";
            btn_start_server.Size = new System.Drawing.Size(231, 23);
            btn_start_server.TabIndex = 0;
            btn_start_server.Text = "Start Server";
            btn_start_server.UseVisualStyleBackColor = true;
            btn_start_server.Click += btn_start_server_Click;
            // 
            // btn_connect
            // 
            btn_connect.Location = new System.Drawing.Point(12, 41);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new System.Drawing.Size(231, 23);
            btn_connect.TabIndex = 1;
            btn_connect.Text = "Connect to Server";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // btn_test_packet
            // 
            btn_test_packet.Location = new System.Drawing.Point(12, 70);
            btn_test_packet.Name = "btn_test_packet";
            btn_test_packet.Size = new System.Drawing.Size(231, 23);
            btn_test_packet.TabIndex = 2;
            btn_test_packet.Text = "Send test packet";
            btn_test_packet.UseVisualStyleBackColor = true;
            btn_test_packet.Click += btn_test_packet_Click;
            // 
            // NetworkTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(255, 210);
            Controls.Add(btn_test_packet);
            Controls.Add(btn_connect);
            Controls.Add(btn_start_server);
            Name = "NetworkTest";
            Text = "Network";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_start_server;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_test_packet;
    }
}