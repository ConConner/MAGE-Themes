using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Tweaks.ParameterControls
{
    public partial class TweakParameterToggle : UserControl
    {
        private TweakParameter Parameter;

        public TweakParameterToggle(TweakParameter param)
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            Parameter = param;
            bool check = (Parameter.Value ?? 0) > 0;

            chb_value.Checked = check;
            chb_value.Text = param.DisplayName ?? param.Name;
        }

        private void chb_value_CheckedChanged(object sender, EventArgs e)
        {
            Parameter.Value = chb_value.Checked ? 1 : 0;
        }
    }
}
