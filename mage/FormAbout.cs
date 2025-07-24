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

            label_version.Text = $"Version \"Themes {Program.Version}\"\r\n\r\nCreated by biospark\r\nand ConConner";
        }

        private void linkLabel_clicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel lbl = sender as LinkLabel;
            Process.Start(new ProcessStartInfo(lbl.Text) { UseShellExecute = true });
        }
    }
}
