using mage.Theming;
using NCalc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Tweaks.ParameterControls
{
    public partial class TweakParameterSelection : UserControl
    {
        private TweakParameter Parameter;
        private List<int> Values;

        public TweakParameterSelection(TweakParameter param)
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            Parameter = param;

            if (param.Options is null || param.Options.Length % 2 != 0 || param.Options.Length < 2) Invalid();

            LoadCombobox();

            cbb_value.SelectedIndex = Values.IndexOf((int)(param.Value ?? -1));
            lbl_name.Text = param.DisplayName ?? param.Name;
        }

        private void LoadCombobox()
        {
            Values = new();

            cbb_value.Items.Clear();
            for (int i = 0; i < Parameter.Options.Length; i += 2)
            {
                string key = Parameter.Options[i];
                int val = evaluate(Parameter.Options[i + 1]);
                cbb_value.Items.Add(key);
                Values.Add(val);
            }
        }


        private void Invalid()
        {
            MessageBox.Show($"Could not load Parameter {lbl_name.Text}. Options are malformed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Dispose();
        }

        private static int evaluate(string expression)
        {
            Expression ex = new Expression(expression);
            return Convert.ToInt32(ex.Evaluate());
        }

        private void cbb_value_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbb_value.SelectedIndex == -1)
            {
                Parameter.Value = null;
                return;
            }
            Parameter.Value = Values[cbb_value.SelectedIndex];
        }
    }
}
