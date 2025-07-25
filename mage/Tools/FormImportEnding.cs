﻿using mage.Theming;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace mage
{
    public partial class FormImportEnding : Form
    {
        // fields
        private Ending ending;
        private Quantize quantize;

        private ByteStream romStream;

        // constructor
        public FormImportEnding()
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            this.romStream = ROM.Stream;

            int total;
            if (Version.IsMF) { total = 5; }
            else { total = 8; }

            for (int i = 0; i < total; i++)
            {
                comboBox_number.Items.Add(i + 1);
            }

            comboBox_number.SelectedIndex = 0;
        }

        private void comboBox_number_SelectedIndexChanged(object sender, EventArgs e)
        {
            int number = comboBox_number.SelectedIndex;
            ending = new Ending(romStream, number);
            pictureBox_ending.Image = ending.img;
            label_stats.Text = ending.Requirements;
        }

        private void button_open_Click(object sender, EventArgs e)
        {
            // load image
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Bitmaps (*.png, *.bmp, *.gif, *.jpeg, *.jpg, *.tif, *.tiff)|*.png;*.bmp;*.gif;*.jpeg;*.jpg;*.tif;*.tiff";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = Draw.BitmapFromFile(fd.FileName);

                // check dimensions
                if (image.Width != 240 || image.Height != 416)
                {
                    MessageBox.Show("Invalid dimensions. Image must be 240 x 416", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    image.Dispose();
                    return;
                }

                try
                {
                    quantize = new Quantize(image, 16);
                }
                catch (FormatException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                groupBox_convert.Enabled = true;
                statusLabel.Text = "Image opened (awaiting conversion)";
            }
        }

        private void button_go_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Converting...";
            Refresh();
            quantize.Kmeans();
            pictureBox_ending.Image = quantize.DrawImage();

            button_apply.Enabled = true;
            statusLabel.Text = "Image converted (unsaved)";
        }

        private void button_apply_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "Saving...";
            Refresh();
            ending.SaveEnding(quantize);
            statusLabel.Text = "Image saved";
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
