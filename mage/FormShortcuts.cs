using mage.Theming;
using System;
using System.Windows.Forms;

namespace mage
{
    public partial class FormShortcuts : Form
    {
        // fields
        private bool isMF;
        private FormMain main;

        // constructor
        public FormShortcuts(FormMain main)
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(this.Controls, this);
            ThemeSwitcher.InjectPaintOverrides(this.Controls);

            this.main = main;
            Initialize();
        }

        private void Initialize()
        {
            isMF = Version.IsMF;

            if (isMF)
            {
                groupBox_super.Enabled = false;
                button_lava_weak.Enabled = false;
                label_lava_weak.Enabled = false;
                button_lava_strong.Enabled = false;
                label_lava_strong.Enabled = false;
                button_acid.Enabled = false;
                label_acid.Enabled = false;
                button_crumble_slow.Enabled = false;
                label_crumble_slow.Enabled = false;

                numericUpDown_slot.Enabled = true;
                label_door_slot.Enabled = true;

                //Change hatch labels
                label_gray_hatch.Text = "Gray [Lv.0]";
                label_blue_hatch.Text = "Blue [Lv.1]";
                label_green_hatch.Text = "Green [Lv.2]";
                label_yellow_hatch.Text = "Yellow [Lv.3]";
                label_red_hatch.Text = "Red [Lv.4]";
            }
        }

        private void button_air_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0;
        }

        private void button_solid_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x10;
        }

        #region energy tanks
        private void button_energy_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x63; }
            else { main.Clipdata = 0x5C; }
        }

        private void button_energy_hidden_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x65; }
            else { main.Clipdata = 0x6C; }
        }

        private void button_energy_water_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x67; }
            else { main.Clipdata = 0x7C; }
        }
        #endregion

        #region missiles
        private void button_missile_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x62; }
            else { main.Clipdata = 0x5D; }
        }

        private void button_missile_hidden_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x64; }
            else { main.Clipdata = 0x6D; }
        }

        private void button_missile_water_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x66; }
            else { main.Clipdata = 0x7D; }
        }

        private void button_missile_block_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5E; }
            else { main.Clipdata = 0x68; }
        }

        private void button_missile_block_never_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x54; }
            else { main.Clipdata = 0x58; }
        }
        #endregion

        #region super missiles
        private void button_super_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x5E;
        }

        private void button_super_hidden_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x6E;
        }

        private void button_super_water_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x7E;
        }

        private void button_super_block_no_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x69;
        }

        private void button_super_block_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x59;
        }
        #endregion

        #region power bombs
        private void button_power_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x68; }
            else { main.Clipdata = 0x5F; }
        }

        private void button_power_hidden_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x69; }
            else { main.Clipdata = 0x6F; }
        }

        private void button_power_water_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6A; }
            else { main.Clipdata = 0x7F; }
        }

        private void button_power_block_never_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x57; }
            else { main.Clipdata = 0x5B; }
        }
        #endregion

        #region liquids
        private void button_water_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x1B;
        }

        private void button_lava_weak_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0xA0;
        }

        private void button_lava_strong_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0xA1;
        }

        private void button_acid_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0xA2;
        }
        #endregion

        #region transitions
        private void button_trans_door_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x20;
        }

        private void button_trans_up_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x27;
        }

        private void button_trans_down_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x28;
        }
        #endregion

        #region slopes
        private void button_slope45_pos_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x11;
        }

        private void button_slope45_neg_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x12;
        }

        private void button_slope27_Lpos_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x13;
        }

        private void button_slope27_Upos_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x14;
        }

        private void button_slope27_Uneg_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x15;
        }

        private void button_slope27_Lneg_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x16;
        }
        #endregion

        #region ground
        private void button_dusty_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x1D;
        }

        private void button_dusty_very_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x2D;
        }

        private void button_wet_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x1C;
        }

        private void button_bubbly_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x2C;
        }
        #endregion

        #region breakable
        private void button_bomb_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x56; }
            else { main.Clipdata = 0x67; }
        }

        private void button_bomb_never_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x55; }
            else { main.Clipdata = 0x57; }
        }

        private void button_speed_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6B; }
            else { main.Clipdata = 0x6A; }
        }

        private void button_speed_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x58; }
            else { main.Clipdata = 0x5A; }
        }

        private void button_screw_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x59; }
            else { main.Clipdata = 0x6B; }
        }

        private void button_crumble_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5A; }
            else { main.Clipdata = 0x56; }
        }

        private void button_crumble_slow_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x66;
        }
        #endregion

        #region shot
        private void button_shot_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x53; }
            else { main.Clipdata = 0x62; }
        }

        private void button_shot_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5B; }
            else { main.Clipdata = 0x55; }
        }

        private void button_shot_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x52;
        }

        private void button_shot_TL_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5C; }
            else { main.Clipdata = 0x53; }
        }

        private void button_shot_TR_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x5D; }
            else { main.Clipdata = 0x54; }
        }

        private void button_shot_BL_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6C; }
            else { main.Clipdata = 0x63; }
        }

        private void button_shot_BR_no_Click(object sender, EventArgs e)
        {
            if (isMF) { main.Clipdata = 0x6D; }
            else { main.Clipdata = 0x64; }
        }

        private void button_shot_TL_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x50;
        }

        private void button_shot_TR_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x51;
        }

        private void button_shot_BL_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x60;
        }

        private void button_shot_BR_never_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x61;
        }
        #endregion

        #region hatches
        private void button_gray_hatch_Click(object sender, EventArgs e)
        {
            if (isMF) main.Clipdata = (ushort)(0x30 + numericUpDown_slot.Value - 1);
            else main.Clipdata = 0x30;
        }

        private void button_blue_hatch_Click(object sender, EventArgs e)
        {
            if (isMF) main.Clipdata = (ushort)(0x36 + numericUpDown_slot.Value - 1);
            else main.Clipdata = 0x36;
        }

        private void button_red_hatch_Click(object sender, EventArgs e)
        {
            ushort val = (ushort)numericUpDown_slot.Value;
            bool jump = val > 3;

            if (isMF) main.Clipdata = (ushort)(0x3C + val - 1 + (jump ? 0x10 - 0x3 : 0));
            else main.Clipdata = 0x40;
        }

        private void button_green_hatch_Click(object sender, EventArgs e)
        {
            if (isMF) main.Clipdata = (ushort)(0x40 + numericUpDown_slot.Value - 1);
            else main.Clipdata = 0x46;
        }

        private void button_yellow_hatch_Click(object sender, EventArgs e)
        {
            if (isMF) main.Clipdata = (ushort)(0x46 + numericUpDown_slot.Value - 1);
            else main.Clipdata = 0x4C;
        }
        #endregion

        #region elevators
        private void button_elevator_up_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x29;
        }

        private void button_elevator_down_Click(object sender, EventArgs e)
        {
            main.Clipdata = 0x2A;
        }
        #endregion
    }
}
