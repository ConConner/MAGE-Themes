namespace mage.Compiling
{
    partial class FormScriptOutput
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
            txb_output = new System.Windows.Forms.RichTextBox();
            pnl_error = new System.Windows.Forms.Panel();
            btn_launchAnyways = new System.Windows.Forms.Button();
            lbl_error = new System.Windows.Forms.Label();
            btn_cancel = new System.Windows.Forms.Button();
            pnl_error.SuspendLayout();
            SuspendLayout();
            // 
            // txb_output
            // 
            txb_output.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txb_output.Font = new System.Drawing.Font("Noto Mono", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txb_output.Location = new System.Drawing.Point(12, 12);
            txb_output.Name = "txb_output";
            txb_output.Size = new System.Drawing.Size(712, 374);
            txb_output.TabIndex = 0;
            txb_output.Text = "";
            // 
            // pnl_error
            // 
            pnl_error.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnl_error.Controls.Add(btn_launchAnyways);
            pnl_error.Controls.Add(lbl_error);
            pnl_error.Location = new System.Drawing.Point(12, 392);
            pnl_error.Name = "pnl_error";
            pnl_error.Size = new System.Drawing.Size(627, 30);
            pnl_error.TabIndex = 1;
            pnl_error.Visible = false;
            // 
            // btn_launchAnyways
            // 
            btn_launchAnyways.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_launchAnyways.Location = new System.Drawing.Point(452, 3);
            btn_launchAnyways.Name = "btn_launchAnyways";
            btn_launchAnyways.Size = new System.Drawing.Size(175, 23);
            btn_launchAnyways.TabIndex = 1;
            btn_launchAnyways.Text = "Continue with original ROM";
            btn_launchAnyways.UseVisualStyleBackColor = true;
            btn_launchAnyways.Click += btn_launchAnyways_Click;
            // 
            // lbl_error
            // 
            lbl_error.AutoSize = true;
            lbl_error.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lbl_error.Location = new System.Drawing.Point(3, 5);
            lbl_error.Name = "lbl_error";
            lbl_error.Size = new System.Drawing.Size(155, 21);
            lbl_error.TabIndex = 0;
            lbl_error.Text = "Compilation Failed";
            // 
            // btn_cancel
            // 
            btn_cancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btn_cancel.Location = new System.Drawing.Point(645, 395);
            btn_cancel.Name = "btn_cancel";
            btn_cancel.Size = new System.Drawing.Size(79, 23);
            btn_cancel.TabIndex = 2;
            btn_cancel.Text = "Cancel";
            btn_cancel.UseVisualStyleBackColor = true;
            btn_cancel.Click += btn_cancel_Click;
            // 
            // FormScriptOutput
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(736, 434);
            Controls.Add(btn_cancel);
            Controls.Add(pnl_error);
            Controls.Add(txb_output);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Name = "FormScriptOutput";
            Text = "Script Output";
            Shown += FormScriptOutput_Shown;
            pnl_error.ResumeLayout(false);
            pnl_error.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.RichTextBox txb_output;
        private System.Windows.Forms.Panel pnl_error;
        private System.Windows.Forms.Button btn_launchAnyways;
        private System.Windows.Forms.Label lbl_error;
        private System.Windows.Forms.Button btn_cancel;
    }
}