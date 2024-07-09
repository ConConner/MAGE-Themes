namespace mage.Networking
{
    partial class FormCollabSession
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCollabSession));
            btn_host = new System.Windows.Forms.Button();
            grp_host = new System.Windows.Forms.GroupBox();
            txb_host_name = new Theming.CustomControls.FlatTextBox();
            lbl_host_name = new System.Windows.Forms.Label();
            txb_host_port = new Theming.CustomControls.FlatTextBox();
            lbl_host_port = new System.Windows.Forms.Label();
            grp_join = new System.Windows.Forms.GroupBox();
            txb_join_name = new Theming.CustomControls.FlatTextBox();
            lbl_join_name = new System.Windows.Forms.Label();
            txb_join_port = new Theming.CustomControls.FlatTextBox();
            lbl_join_port = new System.Windows.Forms.Label();
            txb_join_ip = new Theming.CustomControls.FlatTextBox();
            lbl_join_ip = new System.Windows.Forms.Label();
            btn_join_session = new System.Windows.Forms.Button();
            grp_users = new System.Windows.Forms.GroupBox();
            grp_host.SuspendLayout();
            grp_join.SuspendLayout();
            SuspendLayout();
            // 
            // btn_host
            // 
            btn_host.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_host.Location = new System.Drawing.Point(7, 22);
            btn_host.Name = "btn_host";
            btn_host.Size = new System.Drawing.Size(206, 23);
            btn_host.TabIndex = 0;
            btn_host.Text = "Host a collaboration session";
            btn_host.UseVisualStyleBackColor = true;
            btn_host.Click += btn_host_Click;
            // 
            // grp_host
            // 
            grp_host.Controls.Add(txb_host_name);
            grp_host.Controls.Add(lbl_host_name);
            grp_host.Controls.Add(txb_host_port);
            grp_host.Controls.Add(lbl_host_port);
            grp_host.Controls.Add(btn_host);
            grp_host.Location = new System.Drawing.Point(12, 12);
            grp_host.Name = "grp_host";
            grp_host.Size = new System.Drawing.Size(219, 113);
            grp_host.TabIndex = 1;
            grp_host.TabStop = false;
            grp_host.Text = "Host";
            // 
            // txb_host_name
            // 
            txb_host_name.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_host_name.BorderColor = System.Drawing.Color.Black;
            txb_host_name.DisplayBorder = true;
            txb_host_name.Location = new System.Drawing.Point(55, 51);
            txb_host_name.MaxLength = 32767;
            txb_host_name.Multiline = false;
            txb_host_name.Name = "txb_host_name";
            txb_host_name.OnTextChanged = null;
            txb_host_name.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_host_name.ReadOnly = false;
            txb_host_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_host_name.SelectionStart = 0;
            txb_host_name.Size = new System.Drawing.Size(158, 23);
            txb_host_name.TabIndex = 4;
            txb_host_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_host_name.WordWrap = true;
            // 
            // lbl_host_name
            // 
            lbl_host_name.AutoSize = true;
            lbl_host_name.Location = new System.Drawing.Point(7, 54);
            lbl_host_name.Name = "lbl_host_name";
            lbl_host_name.Size = new System.Drawing.Size(42, 15);
            lbl_host_name.TabIndex = 3;
            lbl_host_name.Text = "Name:";
            // 
            // txb_host_port
            // 
            txb_host_port.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_host_port.BorderColor = System.Drawing.Color.Black;
            txb_host_port.DisplayBorder = true;
            txb_host_port.Location = new System.Drawing.Point(55, 80);
            txb_host_port.MaxLength = 32767;
            txb_host_port.Multiline = false;
            txb_host_port.Name = "txb_host_port";
            txb_host_port.OnTextChanged = null;
            txb_host_port.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_host_port.ReadOnly = false;
            txb_host_port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_host_port.SelectionStart = 0;
            txb_host_port.Size = new System.Drawing.Size(158, 23);
            txb_host_port.TabIndex = 2;
            txb_host_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_host_port.WordWrap = true;
            // 
            // lbl_host_port
            // 
            lbl_host_port.AutoSize = true;
            lbl_host_port.Location = new System.Drawing.Point(6, 83);
            lbl_host_port.Name = "lbl_host_port";
            lbl_host_port.Size = new System.Drawing.Size(32, 15);
            lbl_host_port.TabIndex = 1;
            lbl_host_port.Text = "Port:";
            // 
            // grp_join
            // 
            grp_join.Controls.Add(txb_join_name);
            grp_join.Controls.Add(lbl_join_name);
            grp_join.Controls.Add(txb_join_port);
            grp_join.Controls.Add(lbl_join_port);
            grp_join.Controls.Add(txb_join_ip);
            grp_join.Controls.Add(lbl_join_ip);
            grp_join.Controls.Add(btn_join_session);
            grp_join.Location = new System.Drawing.Point(12, 131);
            grp_join.Name = "grp_join";
            grp_join.Size = new System.Drawing.Size(219, 172);
            grp_join.TabIndex = 2;
            grp_join.TabStop = false;
            grp_join.Text = "Join";
            // 
            // txb_join_name
            // 
            txb_join_name.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_join_name.BorderColor = System.Drawing.Color.Black;
            txb_join_name.DisplayBorder = true;
            txb_join_name.Location = new System.Drawing.Point(55, 51);
            txb_join_name.MaxLength = 32767;
            txb_join_name.Multiline = false;
            txb_join_name.Name = "txb_join_name";
            txb_join_name.OnTextChanged = null;
            txb_join_name.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_join_name.ReadOnly = false;
            txb_join_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_join_name.SelectionStart = 0;
            txb_join_name.Size = new System.Drawing.Size(158, 23);
            txb_join_name.TabIndex = 7;
            txb_join_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_join_name.WordWrap = true;
            // 
            // lbl_join_name
            // 
            lbl_join_name.AutoSize = true;
            lbl_join_name.Location = new System.Drawing.Point(7, 54);
            lbl_join_name.Name = "lbl_join_name";
            lbl_join_name.Size = new System.Drawing.Size(42, 15);
            lbl_join_name.TabIndex = 6;
            lbl_join_name.Text = "Name:";
            // 
            // txb_join_port
            // 
            txb_join_port.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_join_port.BorderColor = System.Drawing.Color.Black;
            txb_join_port.DisplayBorder = true;
            txb_join_port.Location = new System.Drawing.Point(55, 109);
            txb_join_port.MaxLength = 32767;
            txb_join_port.Multiline = false;
            txb_join_port.Name = "txb_join_port";
            txb_join_port.OnTextChanged = null;
            txb_join_port.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_join_port.ReadOnly = false;
            txb_join_port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_join_port.SelectionStart = 0;
            txb_join_port.Size = new System.Drawing.Size(158, 23);
            txb_join_port.TabIndex = 5;
            txb_join_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_join_port.WordWrap = true;
            // 
            // lbl_join_port
            // 
            lbl_join_port.AutoSize = true;
            lbl_join_port.Location = new System.Drawing.Point(7, 112);
            lbl_join_port.Name = "lbl_join_port";
            lbl_join_port.Size = new System.Drawing.Size(32, 15);
            lbl_join_port.TabIndex = 4;
            lbl_join_port.Tag = "";
            lbl_join_port.Text = "Port:";
            // 
            // txb_join_ip
            // 
            txb_join_ip.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_join_ip.BorderColor = System.Drawing.Color.Black;
            txb_join_ip.DisplayBorder = true;
            txb_join_ip.Location = new System.Drawing.Point(55, 80);
            txb_join_ip.MaxLength = 32767;
            txb_join_ip.Multiline = false;
            txb_join_ip.Name = "txb_join_ip";
            txb_join_ip.OnTextChanged = null;
            txb_join_ip.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            txb_join_ip.ReadOnly = false;
            txb_join_ip.ScrollBars = System.Windows.Forms.ScrollBars.None;
            txb_join_ip.SelectionStart = 0;
            txb_join_ip.Size = new System.Drawing.Size(158, 23);
            txb_join_ip.TabIndex = 3;
            txb_join_ip.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            txb_join_ip.WordWrap = true;
            // 
            // lbl_join_ip
            // 
            lbl_join_ip.AutoSize = true;
            lbl_join_ip.Location = new System.Drawing.Point(7, 83);
            lbl_join_ip.Name = "lbl_join_ip";
            lbl_join_ip.Size = new System.Drawing.Size(20, 15);
            lbl_join_ip.TabIndex = 2;
            lbl_join_ip.Text = "IP:";
            // 
            // btn_join_session
            // 
            btn_join_session.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_join_session.Location = new System.Drawing.Point(7, 22);
            btn_join_session.Name = "btn_join_session";
            btn_join_session.Size = new System.Drawing.Size(206, 23);
            btn_join_session.TabIndex = 0;
            btn_join_session.Text = "Join a collaboration session";
            btn_join_session.UseVisualStyleBackColor = true;
            btn_join_session.Click += btn_join_session_Click;
            // 
            // grp_users
            // 
            grp_users.Enabled = false;
            grp_users.Location = new System.Drawing.Point(237, 12);
            grp_users.Name = "grp_users";
            grp_users.Size = new System.Drawing.Size(219, 291);
            grp_users.TabIndex = 3;
            grp_users.TabStop = false;
            grp_users.Text = "Users";
            // 
            // FormCollabSession
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(468, 315);
            Controls.Add(grp_users);
            Controls.Add(grp_join);
            Controls.Add(grp_host);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormCollabSession";
            Text = "Collaboration Session";
            grp_host.ResumeLayout(false);
            grp_host.PerformLayout();
            grp_join.ResumeLayout(false);
            grp_join.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_host;
        private System.Windows.Forms.GroupBox grp_host;
        private System.Windows.Forms.Label lbl_host_port;
        private System.Windows.Forms.GroupBox grp_join;
        private System.Windows.Forms.Label lbl_join_port;
        private System.Windows.Forms.Label lbl_join_ip;
        private System.Windows.Forms.Button btn_join_session;
        private System.Windows.Forms.GroupBox grp_users;
        private System.Windows.Forms.Label lbl_host_name;
        private System.Windows.Forms.Label lbl_join_name;
        private Theming.CustomControls.FlatTextBox txb_host_port;
        private Theming.CustomControls.FlatTextBox txb_join_port;
        private Theming.CustomControls.FlatTextBox txb_join_ip;
        private Theming.CustomControls.FlatTextBox txb_host_name;
        private Theming.CustomControls.FlatTextBox txb_join_name;
    }
}