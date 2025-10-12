using mage.Properties;
using mage.Theming;
using mage.Theming.CustomControls;
using mage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace mage.Options.Pages;

public partial class PageBackups : UserControl, IReloadablePage
{
    bool init = false;
    bool createdRoomCounts = false;

    public PageBackups()
    {
        InitializeComponent();

        char s = Path.DirectorySeparatorChar;
        checkBox_moveBackups.Text = $"Save Backups in a Backups{s} directory";
    }

    public void LoadPage()
    {
        init = true;

        checkBox_moveBackups.Checked = Version.ProjectConfig.BackupsMoveIntoSeperateDirectory;
        textBox_backupFormat.Text = Version.ProjectConfig.BackupDateFormatString;
        checkBox_periodical.Checked = Version.ProjectConfig.BackupsCreatePeriodically;

        int selectedIndex = -1;
        switch (Version.ProjectConfig.BackupsAutoCreationInterval)
        {
            case 1: selectedIndex = 0; break;
            case 5: selectedIndex = 1; break;
            case 10: selectedIndex = 2; break;
            case 20: selectedIndex = 3; break;
            case 30: selectedIndex = 4; break;
            case 60: selectedIndex = 5; break;
            default: selectedIndex = -1; break;
        }
        comboBox_interval.SelectedIndex = selectedIndex;
        comboBox_interval.Enabled = label_interval.Enabled = checkBox_periodical.Checked;

        init = false;
    }

    private bool validateDateTimeFormatString(string format)
    {
        DateTime time = DateTime.Now;
        try
        {
            _ = time.ToString(format);
            return true;
        }
        catch
        {
            return false;
        }
    }

    private void textBox_backupFormat_TextChanged(object sender, EventArgs e)
    {
        if (init)
        {
            textBox_backupFormat.BorderColor = ThemeSwitcher.ProjectTheme.PrimaryOutline;
            return;
        }

        string text = textBox_backupFormat.Text;
        if (!validateDateTimeFormatString(text))
        {
            textBox_backupFormat.BorderColor = Color.Red;
            return;
        }

        textBox_backupFormat.BorderColor = ThemeSwitcher.ProjectTheme.AccentColor;
        Version.ProjectConfig.BackupDateFormatString = text;
    }

    private void checkBox_moveBackups_CheckedChanged(object sender, EventArgs e)
    {
        if (init) return;
        Version.ProjectConfig.BackupsMoveIntoSeperateDirectory = checkBox_moveBackups.Checked;
    }

    private void checkBox_periodical_CheckedChanged(object sender, EventArgs e)
    {
        if (init) return;

        bool enabled = checkBox_periodical.Checked;
        comboBox_interval.Enabled = label_interval.Enabled = enabled;
        Version.ProjectConfig.BackupsCreatePeriodically = enabled;

        Version.BackupService?.Stop();
        if (enabled)
        {
            Version.BackupService = BackupService.FromMinutes(Version.ProjectConfig.BackupsAutoCreationInterval);
            Version.BackupService.Start();
        }
    }

    private void comboBox_interval_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (init) return;

        // Get interval
        int interval = 0;
        switch (comboBox_interval.SelectedIndex)
        {
            case 0: interval = 1; break;
            case 1: interval = 5; break;
            case 2: interval = 10; break;
            case 3: interval = 20; break;
            case 4: interval = 30; break;
            case 5: interval = 60; break;
            default: interval = 30; break;
        }
        Version.ProjectConfig.BackupsAutoCreationInterval = interval;

        // Update BackupService if enabled
        if (!Version.ProjectConfig.BackupsCreatePeriodically) return;

        Version.BackupService?.Stop();
        Version.BackupService = BackupService.FromMinutes(interval);
        Version.BackupService.Start();
    }
}
