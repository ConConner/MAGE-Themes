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
    public partial class TweakParameterValue : UserControl
    {
        private TweakParameter Parameter;

        public TweakParameterValue(TweakParameter param)
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            Parameter = param;
            if (param.Value == null) txb_value.Text = "";
            else txb_value.Text = Hex.ToString((int)param.Value);

            lbl_name.Text = param.DisplayName ?? param.Name;
        }

        private void txb_value_TextChanged(object sender, EventArgs e)
        {
            txb_value.ForeColor = ThemeSwitcher.ProjectTheme.TextColor;
            if (txb_value.Text == String.Empty)
            {
                Parameter.Value = null;
                return;
            }

            try
            {
                Parameter.Value = Hex.ToInt(txb_value.Text);
            }
            catch
            {
                txb_value.ForeColor = Color.Red;
                Parameter.Value = null;
            }
        }
    }
}
