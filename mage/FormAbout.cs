using mage.Theming;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace mage
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            System.Version v = new System.Version(Program.Version);
            string vString = $"{v.Major}.{v.Minor}.{v.Build}";
            label_version.Text = $"Version \'Themes {vString}\'\r\n\r\nCreated by biospark\r\nand ConConner";
        }

        private void linkLabel_clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lbl = sender as LinkLabel;
            Process.Start(new ProcessStartInfo(lbl.Text) { UseShellExecute = true });
        }
    }
}
