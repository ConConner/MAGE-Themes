namespace mage.Dialogs
{
    partial class TransparencyDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransparencyDialog));
            lbl_bg0Position = new System.Windows.Forms.Label();
            lbl_colorIntensities = new System.Windows.Forms.Label();
            btn_overBG1_overSprite = new System.Windows.Forms.Button();
            btn_overBG2_overSprite = new System.Windows.Forms.Button();
            btn_overBG2_underSprite = new System.Windows.Forms.Button();
            btn_overBG3_underSprite = new System.Windows.Forms.Button();
            button0 = new System.Windows.Forms.Button();
            lbl_eva = new System.Windows.Forms.Label();
            lbl_layersbeneath = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button4 = new System.Windows.Forms.Button();
            button5 = new System.Windows.Forms.Button();
            button6 = new System.Windows.Forms.Button();
            button7 = new System.Windows.Forms.Button();
            button8 = new System.Windows.Forms.Button();
            button9 = new System.Windows.Forms.Button();
            button10 = new System.Windows.Forms.Button();
            btn_apply = new System.Windows.Forms.Button();
            textBox_Value_Dialog = new mage.Theming.CustomControls.FlatTextBox();
            SuspendLayout();
            // 
            // lbl_bg0Position
            // 
            lbl_bg0Position.AutoSize = true;
            lbl_bg0Position.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lbl_bg0Position.Location = new System.Drawing.Point(12, 24);
            lbl_bg0Position.Name = "lbl_bg0Position";
            lbl_bg0Position.Size = new System.Drawing.Size(124, 15);
            lbl_bg0Position.TabIndex = 0;
            lbl_bg0Position.Text = "BG0 Position (Z-Axis)";
            lbl_bg0Position.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_colorIntensities
            // 
            lbl_colorIntensities.AutoSize = true;
            lbl_colorIntensities.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lbl_colorIntensities.Location = new System.Drawing.Point(137, 166);
            lbl_colorIntensities.Name = "lbl_colorIntensities";
            lbl_colorIntensities.Size = new System.Drawing.Size(88, 15);
            lbl_colorIntensities.TabIndex = 1;
            lbl_colorIntensities.Text = "Color Intensity";
            lbl_colorIntensities.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btn_overBG1_overSprite
            // 
            btn_overBG1_overSprite.Location = new System.Drawing.Point(12, 47);
            btn_overBG1_overSprite.Name = "btn_overBG1_overSprite";
            btn_overBG1_overSprite.Size = new System.Drawing.Size(352, 23);
            btn_overBG1_overSprite.TabIndex = 3;
            btn_overBG1_overSprite.Tag = "0";
            btn_overBG1_overSprite.Text = "Over BG1, Over Sprites                                                                                            None";
            btn_overBG1_overSprite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_overBG1_overSprite.UseVisualStyleBackColor = false;
            btn_overBG1_overSprite.Click += buttonPositionClicked;
            // 
            // btn_overBG2_overSprite
            // 
            btn_overBG2_overSprite.Location = new System.Drawing.Point(12, 76);
            btn_overBG2_overSprite.Name = "btn_overBG2_overSprite";
            btn_overBG2_overSprite.Size = new System.Drawing.Size(352, 23);
            btn_overBG2_overSprite.TabIndex = 4;
            btn_overBG2_overSprite.Tag = "1";
            btn_overBG2_overSprite.Text = "Over BG2 Over Sprites";
            btn_overBG2_overSprite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_overBG2_overSprite.UseVisualStyleBackColor = true;
            btn_overBG2_overSprite.Click += buttonPositionClicked;
            // 
            // btn_overBG2_underSprite
            // 
            btn_overBG2_underSprite.Location = new System.Drawing.Point(12, 105);
            btn_overBG2_underSprite.Name = "btn_overBG2_underSprite";
            btn_overBG2_underSprite.Size = new System.Drawing.Size(352, 23);
            btn_overBG2_underSprite.TabIndex = 5;
            btn_overBG2_underSprite.Tag = "2";
            btn_overBG2_underSprite.Text = "Over BG2 Under Sprites";
            btn_overBG2_underSprite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_overBG2_underSprite.UseVisualStyleBackColor = true;
            btn_overBG2_underSprite.Click += buttonPositionClicked;
            // 
            // btn_overBG3_underSprite
            // 
            btn_overBG3_underSprite.Location = new System.Drawing.Point(12, 134);
            btn_overBG3_underSprite.Name = "btn_overBG3_underSprite";
            btn_overBG3_underSprite.Size = new System.Drawing.Size(352, 23);
            btn_overBG3_underSprite.TabIndex = 2;
            btn_overBG3_underSprite.Tag = "3";
            btn_overBG3_underSprite.Text = "Over BG3 Under Sprites";
            btn_overBG3_underSprite.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn_overBG3_underSprite.UseVisualStyleBackColor = true;
            btn_overBG3_underSprite.Click += buttonPositionClicked;
            // 
            // button0
            // 
            button0.Location = new System.Drawing.Point(12, 213);
            button0.Name = "button0";
            button0.Size = new System.Drawing.Size(352, 23);
            button0.TabIndex = 6;
            button0.Tag = "0";
            button0.Text = "EVA = 16                                                        EVB = 0";
            button0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button0.UseVisualStyleBackColor = true;
            button0.Click += buttonTransparencyClicked;
            // 
            // lbl_eva
            // 
            lbl_eva.AutoSize = true;
            lbl_eva.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lbl_eva.Location = new System.Drawing.Point(12, 195);
            lbl_eva.Name = "lbl_eva";
            lbl_eva.Size = new System.Drawing.Size(31, 15);
            lbl_eva.TabIndex = 13;
            lbl_eva.Text = "BG0";
            // 
            // lbl_layersbeneath
            // 
            lbl_layersbeneath.AutoSize = true;
            lbl_layersbeneath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline);
            lbl_layersbeneath.Location = new System.Drawing.Point(245, 195);
            lbl_layersbeneath.Name = "lbl_layersbeneath";
            lbl_layersbeneath.Size = new System.Drawing.Size(119, 15);
            lbl_layersbeneath.TabIndex = 14;
            lbl_layersbeneath.Text = "Layers Beneath BG0";
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(12, 242);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(352, 23);
            button1.TabIndex = 15;
            button1.Tag = "1";
            button1.Text = "EVA = 16                                                        EVB = 7";
            button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonTransparencyClicked;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(12, 271);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(352, 23);
            button2.TabIndex = 16;
            button2.Tag = "2";
            button2.Text = "EVA = 16                                                        EVB = 10";
            button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonTransparencyClicked;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(12, 300);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(352, 23);
            button3.TabIndex = 17;
            button3.Tag = "3";
            button3.Text = "EVA = 16                                                        EVB = 13";
            button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonTransparencyClicked;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(12, 329);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(352, 23);
            button4.TabIndex = 18;
            button4.Tag = "4";
            button4.Text = "EVA = 16                                                        EVB = 16\r\n";
            button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            button4.Click += buttonTransparencyClicked;
            // 
            // button5
            // 
            button5.Location = new System.Drawing.Point(12, 358);
            button5.Name = "button5";
            button5.Size = new System.Drawing.Size(352, 23);
            button5.TabIndex = 19;
            button5.Tag = "5";
            button5.Text = "EVA = 0                                                          EVB = 16";
            button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button5.UseVisualStyleBackColor = true;
            button5.Click += buttonTransparencyClicked;
            // 
            // button6
            // 
            button6.Location = new System.Drawing.Point(12, 387);
            button6.Name = "button6";
            button6.Size = new System.Drawing.Size(352, 23);
            button6.TabIndex = 20;
            button6.Tag = "6";
            button6.Text = "EVA = 3                                                         EVB = 13";
            button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button6.UseVisualStyleBackColor = true;
            button6.Click += buttonTransparencyClicked;
            // 
            // button7
            // 
            button7.Location = new System.Drawing.Point(12, 416);
            button7.Name = "button7";
            button7.Size = new System.Drawing.Size(352, 23);
            button7.TabIndex = 21;
            button7.Tag = "7";
            button7.Text = "EVA = 6                                                          EVB = 10";
            button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button7.UseVisualStyleBackColor = true;
            button7.Click += buttonTransparencyClicked;
            // 
            // button8
            // 
            button8.Location = new System.Drawing.Point(12, 445);
            button8.Name = "button8";
            button8.Size = new System.Drawing.Size(352, 23);
            button8.TabIndex = 22;
            button8.Tag = "8";
            button8.Text = "EVA = 9                                                        EVB = 7";
            button8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button8.UseVisualStyleBackColor = true;
            button8.Click += buttonTransparencyClicked;
            // 
            // button9
            // 
            button9.Location = new System.Drawing.Point(12, 474);
            button9.Name = "button9";
            button9.Size = new System.Drawing.Size(352, 23);
            button9.TabIndex = 23;
            button9.Tag = "9";
            button9.Text = "EVA = 11                                                        EVB = 5";
            button9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button9.UseVisualStyleBackColor = true;
            button9.Click += buttonTransparencyClicked;
            // 
            // button10
            // 
            button10.Location = new System.Drawing.Point(12, 503);
            button10.Name = "button10";
            button10.Size = new System.Drawing.Size(352, 23);
            button10.TabIndex = 24;
            button10.Tag = "10";
            button10.Text = "EVA = 13                                                        EVB = 3";
            button10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button10.UseVisualStyleBackColor = true;
            button10.Click += buttonTransparencyClicked;
            // 
            // btn_apply
            // 
            btn_apply.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            btn_apply.Location = new System.Drawing.Point(276, 12);
            btn_apply.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            btn_apply.Name = "btn_apply";
            btn_apply.Size = new System.Drawing.Size(88, 23);
            btn_apply.TabIndex = 25;
            btn_apply.Tag = "0";
            btn_apply.Text = "Apply";
            btn_apply.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            btn_apply.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            btn_apply.UseVisualStyleBackColor = true;
            btn_apply.Click += returnCombined;
            // 
            // textBox_Value_Dialog
            // 
            textBox_Value_Dialog.BorderColor = System.Drawing.Color.FromArgb(188, 188, 188);
            textBox_Value_Dialog.DisplayBorder = true;
            textBox_Value_Dialog.HexSanitized = true;
            textBox_Value_Dialog.HexSanitizedMaxValue = 255;
            textBox_Value_Dialog.Location = new System.Drawing.Point(234, 12);
            textBox_Value_Dialog.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBox_Value_Dialog.MaxLength = 2;
            textBox_Value_Dialog.Multiline = false;
            textBox_Value_Dialog.Name = "textBox_Value_Dialog";
            textBox_Value_Dialog.OnTextChanged = null;
            textBox_Value_Dialog.Padding = new System.Windows.Forms.Padding(4, 3, 1, 2);
            textBox_Value_Dialog.PlaceholderText = "";
            textBox_Value_Dialog.ReadOnly = false;
            textBox_Value_Dialog.ScrollBars = System.Windows.Forms.ScrollBars.None;
            textBox_Value_Dialog.SelectionStart = 0;
            textBox_Value_Dialog.Size = new System.Drawing.Size(35, 23);
            textBox_Value_Dialog.TabIndex = 26;
            textBox_Value_Dialog.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            textBox_Value_Dialog.ValueBox = false;
            textBox_Value_Dialog.WordWrap = true;
            textBox_Value_Dialog.TextChanged += textChanged;
            // 
            // TransparencyDialog
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(376, 534);
            Controls.Add(btn_apply);
            Controls.Add(button10);
            Controls.Add(button9);
            Controls.Add(button8);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(lbl_layersbeneath);
            Controls.Add(lbl_eva);
            Controls.Add(button0);
            Controls.Add(btn_overBG2_underSprite);
            Controls.Add(btn_overBG2_overSprite);
            Controls.Add(btn_overBG1_overSprite);
            Controls.Add(btn_overBG3_underSprite);
            Controls.Add(lbl_colorIntensities);
            Controls.Add(lbl_bg0Position);
            Controls.Add(textBox_Value_Dialog);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "TransparencyDialog";
            Text = "Transparency";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lbl_bg0Position;
        private System.Windows.Forms.Label lbl_colorIntensities;
        private System.Windows.Forms.Button btn_overBG3_underSprite;
        private System.Windows.Forms.Button btn_overBG1_overSprite;
        private System.Windows.Forms.Button btn_overBG2_overSprite;
        private System.Windows.Forms.Button btn_overBG2_underSprite;
        private System.Windows.Forms.Button button0;
        private System.Windows.Forms.Label lbl_eva;
        private System.Windows.Forms.Label lbl_layersbeneath;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button btn_apply;
        private Theming.CustomControls.FlatTextBox textBox_Value_Dialog;
    }
}