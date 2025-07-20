using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Updates
{
    public partial class FormUpdateAvailable : Form
    {
        string VersionTag;
        string DownloadURL;

        public FormUpdateAvailable(string version_tag, string version_url, bool hideSkip = false)
        {
            InitializeComponent();

            ThemeSwitcher.ChangeTheme(Controls, this);
            ThemeSwitcher.InjectPaintOverrides(Controls);

            label_mageVersion.Text = $"MAGE Themes {version_tag}";
            this.VersionTag = version_tag;
            this.DownloadURL = version_url;

            textBox_description.Text = $"Version {version_tag} of MAGE Themes is now available to download. " +
                $"\r\nView the release page to find a list of all new changes and bug fixes." +
                $"\r\n\r\nDo you want to download the newest version?";

            button_skip.Visible = !hideSkip;
        }

        private void button_dismiss_Click(object sender, EventArgs e) => Close();

        private void button_skip_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.updateCheckIgnoreVersions.Add(VersionTag);
            Properties.Settings.Default.Save();
            Close();
        }

        private void button_download_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
            new System.Diagnostics.ProcessStartInfo
            {
                FileName = DownloadURL,
                UseShellExecute = true
            });
            Close();
        }

        private void button_viewPage_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(
            new System.Diagnostics.ProcessStartInfo
            {
                FileName = "https://github.com/ConConner/MAGE-Themes/releases/latest",
                UseShellExecute = true
            });
            Close();
        }
    }
}
