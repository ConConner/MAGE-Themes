using mage.Theming;
using System;
using System.Windows.Forms;

namespace mage.Tools;

public partial class BackgroundPropertyDialog : Form
{
    public byte Value = 0;

    public BackgroundPropertyDialog()
    {
        InitializeComponent();

        //Theming
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        grp_zm.Enabled = !Version.IsMF;
        grp_fusion.Enabled = Version.IsMF;
        if (Version.IsMF) grp_fusion.SendToBack();

        DialogResult = DialogResult.Cancel;
    }

    private void returnValue(byte value)
    {
        DialogResult = DialogResult.OK;
        Value = value;
        Close();
    }

    private void buttonClicked(object sender, EventArgs e)
    {
        Button b = sender as Button;
        int val = Convert.ToInt32(b.Tag.ToString(), 10);
        returnValue((byte)val);
    }
}
