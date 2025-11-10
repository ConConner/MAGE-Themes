namespace mage.Options.Pages
{
    partial class PageDecomp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageDecomp));
            label_info = new System.Windows.Forms.Label();
            textBox_path = new mage.Theming.CustomControls.FlatTextBox();
            button_select = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // label_info
            // 
            label_info.Location = new System.Drawing.Point(9, 9);
            label_info.Margin = new System.Windows.Forms.Padding(3);
            label_info.Name = "label_info";
            label_info.Size = new System.Drawing.Size(417, 66);
            label_info.TabIndex = 0;
            label_info.Text = resources.GetString("label_info.Text");
            // 
            // textBox_path
            // 
            textBox_path.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBox_path.BorderColor = System.Drawing.Color.Black;
            textBox_path.DisplayBorder = true;
            textBox_path.Location = new System.Drawing.Point(9, 110);
            textBox_path.MaxLength = 32767;
            textBox_path.Multiline = false;
            textBox_path.Name = "textBox_path";
            textBox_path.OnTextChanged = null;
            textBox_path.Padding = new System.Windows.Forms.Padding(3, 3, 1, 2);
            textBox_path.PlaceholderText = "";
            textBox_path.ReadOnly = false;
            textBox_path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_path.SelectionStart = 0;
            textBox_path.Size = new System.Drawing.Size(417, 23);
            textBox_path.TabIndex = 1;
            textBox_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_path.ValueBox = false;
            textBox_path.WordWrap = true;
            textBox_path.TextChanged += textBox_path_TextChanged;
            // 
            // button_select
            // 
            button_select.Image = Properties.Resources.toolbar_open;
            button_select.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button_select.Location = new System.Drawing.Point(9, 81);
            button_select.Name = "button_select";
            button_select.Size = new System.Drawing.Size(149, 23);
            button_select.TabIndex = 2;
            button_select.Text = "Select Decompilation";
            button_select.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            button_select.UseVisualStyleBackColor = true;
            button_select.Click += button_select_Click;
            // 
            // PageDecomp
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            AutoScroll = true;
            Controls.Add(button_select);
            Controls.Add(textBox_path);
            Controls.Add(label_info);
            Name = "PageDecomp";
            Padding = new System.Windows.Forms.Padding(6);
            Size = new System.Drawing.Size(435, 349);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label_info;
        private Theming.CustomControls.FlatTextBox textBox_path;
        private System.Windows.Forms.Button button_select;
    }
}
