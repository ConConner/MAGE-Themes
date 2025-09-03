using mage.Theming.CustomControls; 

namespace mage.Options.Pages
{
    partial class PageLabels
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.group_areanames = new System.Windows.Forms.GroupBox();
            this.textBox_area1 = new FlatTextBox();
            this.textBox_area2 = new FlatTextBox();
            this.textBox_area3 = new FlatTextBox();
            this.textBox_area4 = new FlatTextBox();
            this.textBox_area5 = new FlatTextBox();
            this.textBox_area6 = new FlatTextBox();
            this.textBox_area7 = new FlatTextBox();
            this.textBox_area8 = new FlatTextBox();
            this.textBox_area9 = new FlatTextBox();
            this.textBox_area10 = new FlatTextBox();

            var label_area1 = new System.Windows.Forms.Label();
            var label_area2 = new System.Windows.Forms.Label();
            var label_area3 = new System.Windows.Forms.Label();
            var label_area4 = new System.Windows.Forms.Label();
            var label_area5 = new System.Windows.Forms.Label();
            var label_area6 = new System.Windows.Forms.Label();
            var label_area7 = new System.Windows.Forms.Label();
            var label_area8 = new System.Windows.Forms.Label();
            var label_area9 = new System.Windows.Forms.Label();
            var label_area10 = new System.Windows.Forms.Label();

            this.SuspendLayout();

            // 
            // group_areanames
            // 
            this.group_areanames.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.group_areanames.Location = new System.Drawing.Point(6, 6);
            this.group_areanames.Name = "group_areanames";
            this.group_areanames.Size = new System.Drawing.Size(480, 320);
            this.group_areanames.TabIndex = 0;
            this.group_areanames.TabStop = false;
            this.group_areanames.Text = "Area Names";

            // Helpers
            void SetupTextBox(FlatTextBox tb, int index)
            {
                tb.BorderColor = System.Drawing.Color.Black;
                tb.DisplayBorder = true;
                tb.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                tb.Location = new System.Drawing.Point(6, 28 + index * 29);
                tb.Name = $"textBox_area{index + 1}";
                tb.ReadOnly = false;
                tb.Size = new System.Drawing.Size(150, 23);
                tb.TabIndex = index;
                tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
                tb.ValueBox = false;
                tb.WordWrap = true;
            }

            void SetupLabel(System.Windows.Forms.Label lbl, int index)
            {
                lbl.AutoSize = true;
                lbl.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
                lbl.Location = new System.Drawing.Point(165, 31 + index * 29);
                lbl.Name = $"label_area{index + 1}";
                lbl.Size = new System.Drawing.Size(60, 15);
                lbl.TabIndex = index + 20;
                // Default text
                lbl.Text = $"Area {index + 1}";
            }

            // Set up TextBoxes
            SetupTextBox(this.textBox_area1, 0);
            SetupTextBox(this.textBox_area2, 1);
            SetupTextBox(this.textBox_area3, 2);
            SetupTextBox(this.textBox_area4, 3);
            SetupTextBox(this.textBox_area5, 4);
            SetupTextBox(this.textBox_area6, 5);
            SetupTextBox(this.textBox_area7, 6);
            SetupTextBox(this.textBox_area8, 7);
            SetupTextBox(this.textBox_area9, 8);
            SetupTextBox(this.textBox_area10, 9);

            // Labels
            SetupLabel(label_area1, 0);
            SetupLabel(label_area2, 1);
            SetupLabel(label_area3, 2);
            SetupLabel(label_area4, 3);
            SetupLabel(label_area5, 4);
            SetupLabel(label_area6, 5);
            SetupLabel(label_area7, 6);

            // Override text 
            label_area8.Text = "Debug 1";
            label_area9.Text = "Debug 2";
            label_area10.Text = "Debug 3";

            SetupLabel(label_area8, 7);
            SetupLabel(label_area9, 8);
            SetupLabel(label_area10, 9);

            this.group_areanames.Controls.Add(this.textBox_area1);
            this.group_areanames.Controls.Add(label_area1);
            this.group_areanames.Controls.Add(this.textBox_area2);
            this.group_areanames.Controls.Add(label_area2);
            this.group_areanames.Controls.Add(this.textBox_area3);
            this.group_areanames.Controls.Add(label_area3);
            this.group_areanames.Controls.Add(this.textBox_area4);
            this.group_areanames.Controls.Add(label_area4);
            this.group_areanames.Controls.Add(this.textBox_area5);
            this.group_areanames.Controls.Add(label_area5);
            this.group_areanames.Controls.Add(this.textBox_area6);
            this.group_areanames.Controls.Add(label_area6);
            this.group_areanames.Controls.Add(this.textBox_area7);
            this.group_areanames.Controls.Add(label_area7);
            this.group_areanames.Controls.Add(this.textBox_area8);
            this.group_areanames.Controls.Add(label_area8);
            this.group_areanames.Controls.Add(this.textBox_area9);
            this.group_areanames.Controls.Add(label_area9);
            this.group_areanames.Controls.Add(this.textBox_area10);
            this.group_areanames.Controls.Add(label_area10);

            // 
            // PageLabels
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.Controls.Add(this.group_areanames);
            this.Name = "PageLabels";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Size = new System.Drawing.Size(500, 360);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox group_areanames;
        private FlatTextBox textBox_area1;
        private FlatTextBox textBox_area2;
        private FlatTextBox textBox_area3;
        private FlatTextBox textBox_area4;
        private FlatTextBox textBox_area5;
        private FlatTextBox textBox_area6;
        private FlatTextBox textBox_area7;
        private FlatTextBox textBox_area8;
        private FlatTextBox textBox_area9;
        private FlatTextBox textBox_area10;
    }
}
