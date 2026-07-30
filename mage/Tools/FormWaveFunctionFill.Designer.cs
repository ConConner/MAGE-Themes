namespace mage
{
    partial class FormWaveFunctionFill
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
            label_info = new System.Windows.Forms.Label();
            label_status = new System.Windows.Forms.Label();
            button_generate = new System.Windows.Forms.Button();
            button_close = new System.Windows.Forms.Button();
            SuspendLayout();
            //
            // label_info
            //
            label_info.Location = new System.Drawing.Point(12, 9);
            label_info.Name = "label_info";
            label_info.Size = new System.Drawing.Size(360, 80);
            label_info.TabIndex = 0;
            label_info.Text = "Building tile corpus...";
            //
            // label_status
            //
            label_status.Location = new System.Drawing.Point(12, 92);
            label_status.Name = "label_status";
            label_status.Size = new System.Drawing.Size(360, 40);
            label_status.TabIndex = 1;
            label_status.Text = "";
            //
            // button_generate
            //
            button_generate.Location = new System.Drawing.Point(12, 138);
            button_generate.Name = "button_generate";
            button_generate.Size = new System.Drawing.Size(120, 23);
            button_generate.TabIndex = 2;
            button_generate.Text = "Generate Fill";
            button_generate.UseVisualStyleBackColor = true;
            button_generate.Click += button_generate_Click;
            //
            // button_close
            //
            button_close.Location = new System.Drawing.Point(297, 138);
            button_close.Name = "button_close";
            button_close.Size = new System.Drawing.Size(75, 23);
            button_close.TabIndex = 3;
            button_close.Text = "Close";
            button_close.UseVisualStyleBackColor = true;
            button_close.Click += button_close_Click;
            //
            // FormWaveFunctionFill
            //
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            ClientSize = new System.Drawing.Size(384, 173);
            Controls.Add(label_info);
            Controls.Add(label_status);
            Controls.Add(button_generate);
            Controls.Add(button_close);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormWaveFunctionFill";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Wave Function Fill";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.Button button_generate;
        private System.Windows.Forms.Button button_close;
    }
}
