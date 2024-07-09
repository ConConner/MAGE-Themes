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
            lbl_host_port = new System.Windows.Forms.Label();
            num_host_port = new System.Windows.Forms.NumericUpDown();
            lbl_ip = new System.Windows.Forms.Label();
            txb_ip = new System.Windows.Forms.TextBox();
            lbl_port = new System.Windows.Forms.Label();
            num_port = new System.Windows.Forms.NumericUpDown();
            lbl_host_ip = new System.Windows.Forms.Label();
            console = new System.Windows.Forms.RichTextBox();
            lbl_console = new System.Windows.Forms.Label();
            txb_command = new System.Windows.Forms.TextBox();
            btn_command_send = new System.Windows.Forms.Button();
            txb_host_ip = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)num_host_port).BeginInit();
            ((System.ComponentModel.ISupportInitialize)num_port).BeginInit();
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
            btn_connect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            btn_connect.Location = new System.Drawing.Point(12, 117);
            btn_connect.Name = "btn_connect";
            btn_connect.Size = new System.Drawing.Size(231, 23);
            btn_connect.TabIndex = 1;
            btn_connect.Text = "Connect to Server";
            btn_connect.UseVisualStyleBackColor = true;
            btn_connect.Click += btn_connect_Click;
            // 
            // btn_test_packet
            // 
            btn_test_packet.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btn_test_packet.Location = new System.Drawing.Point(12, 242);
            btn_test_packet.Name = "btn_test_packet";
            btn_test_packet.Size = new System.Drawing.Size(231, 23);
            btn_test_packet.TabIndex = 2;
            btn_test_packet.Text = "Send test packet";
            btn_test_packet.UseVisualStyleBackColor = true;
            btn_test_packet.Click += btn_test_packet_Click;
            // 
            // lbl_host_port
            // 
            lbl_host_port.AutoSize = true;
            lbl_host_port.Location = new System.Drawing.Point(12, 43);
            lbl_host_port.Name = "lbl_host_port";
            lbl_host_port.Size = new System.Drawing.Size(32, 15);
            lbl_host_port.TabIndex = 3;
            lbl_host_port.Text = "Port:";
            // 
            // num_host_port
            // 
            num_host_port.Location = new System.Drawing.Point(47, 41);
            num_host_port.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            num_host_port.Name = "num_host_port";
            num_host_port.Size = new System.Drawing.Size(196, 23);
            num_host_port.TabIndex = 4;
            num_host_port.Value = new decimal(new int[] { 1234, 0, 0, 0 });
            // 
            // lbl_ip
            // 
            lbl_ip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lbl_ip.AutoSize = true;
            lbl_ip.Location = new System.Drawing.Point(12, 149);
            lbl_ip.Name = "lbl_ip";
            lbl_ip.Size = new System.Drawing.Size(20, 15);
            lbl_ip.TabIndex = 5;
            lbl_ip.Text = "IP:";
            // 
            // txb_ip
            // 
            txb_ip.Anchor = System.Windows.Forms.AnchorStyles.Left;
            txb_ip.Location = new System.Drawing.Point(47, 146);
            txb_ip.Name = "txb_ip";
            txb_ip.Size = new System.Drawing.Size(196, 23);
            txb_ip.TabIndex = 6;
            // 
            // lbl_port
            // 
            lbl_port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            lbl_port.AutoSize = true;
            lbl_port.Location = new System.Drawing.Point(12, 181);
            lbl_port.Name = "lbl_port";
            lbl_port.Size = new System.Drawing.Size(32, 15);
            lbl_port.TabIndex = 7;
            lbl_port.Text = "Port:";
            // 
            // num_port
            // 
            num_port.Anchor = System.Windows.Forms.AnchorStyles.Left;
            num_port.Location = new System.Drawing.Point(47, 179);
            num_port.Maximum = new decimal(new int[] { 99999999, 0, 0, 0 });
            num_port.Name = "num_port";
            num_port.Size = new System.Drawing.Size(196, 23);
            num_port.TabIndex = 8;
            num_port.Value = new decimal(new int[] { 1234, 0, 0, 0 });
            // 
            // lbl_host_ip
            // 
            lbl_host_ip.AutoSize = true;
            lbl_host_ip.Location = new System.Drawing.Point(12, 73);
            lbl_host_ip.Name = "lbl_host_ip";
            lbl_host_ip.Size = new System.Drawing.Size(20, 15);
            lbl_host_ip.TabIndex = 9;
            lbl_host_ip.Text = "IP:";
            // 
            // console
            // 
            console.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            console.Location = new System.Drawing.Point(249, 40);
            console.Name = "console";
            console.Size = new System.Drawing.Size(444, 189);
            console.TabIndex = 10;
            console.Text = "";
            // 
            // lbl_console
            // 
            lbl_console.AutoSize = true;
            lbl_console.Location = new System.Drawing.Point(249, 16);
            lbl_console.Name = "lbl_console";
            lbl_console.Size = new System.Drawing.Size(53, 15);
            lbl_console.TabIndex = 11;
            lbl_console.Text = "Console:";
            // 
            // txb_command
            // 
            txb_command.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_command.Location = new System.Drawing.Point(249, 243);
            txb_command.Name = "txb_command";
            txb_command.PlaceholderText = "Send Command...";
            txb_command.Size = new System.Drawing.Size(363, 23);
            txb_command.TabIndex = 12;
            // 
            // btn_command_send
            // 
            btn_command_send.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btn_command_send.Location = new System.Drawing.Point(618, 243);
            btn_command_send.Name = "btn_command_send";
            btn_command_send.Size = new System.Drawing.Size(75, 23);
            btn_command_send.TabIndex = 13;
            btn_command_send.Text = "Send";
            btn_command_send.UseVisualStyleBackColor = true;
            // 
            // txb_host_ip
            // 
            txb_host_ip.Location = new System.Drawing.Point(47, 70);
            txb_host_ip.Name = "txb_host_ip";
            txb_host_ip.Size = new System.Drawing.Size(196, 23);
            txb_host_ip.TabIndex = 14;
            // 
            // NetworkTest
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(705, 277);
            Controls.Add(txb_host_ip);
            Controls.Add(btn_command_send);
            Controls.Add(txb_command);
            Controls.Add(lbl_console);
            Controls.Add(console);
            Controls.Add(lbl_host_ip);
            Controls.Add(num_port);
            Controls.Add(lbl_port);
            Controls.Add(txb_ip);
            Controls.Add(lbl_ip);
            Controls.Add(num_host_port);
            Controls.Add(lbl_host_port);
            Controls.Add(btn_test_packet);
            Controls.Add(btn_connect);
            Controls.Add(btn_start_server);
            Name = "NetworkTest";
            Text = "Network";
            ((System.ComponentModel.ISupportInitialize)num_host_port).EndInit();
            ((System.ComponentModel.ISupportInitialize)num_port).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_start_server;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.Button btn_test_packet;
        private System.Windows.Forms.Label lbl_host_port;
        private System.Windows.Forms.NumericUpDown num_host_port;
        private System.Windows.Forms.Label lbl_ip;
        private System.Windows.Forms.TextBox txb_ip;
        private System.Windows.Forms.Label lbl_port;
        private System.Windows.Forms.NumericUpDown num_port;
        private System.Windows.Forms.Label lbl_host_ip;
        private System.Windows.Forms.RichTextBox console;
        private System.Windows.Forms.Label lbl_console;
        private System.Windows.Forms.TextBox txb_command;
        private System.Windows.Forms.Button btn_command_send;
        private System.Windows.Forms.TextBox txb_host_ip;
    }
}