using mage.Properties;
using mage.Theming;
using mage.Theming.CustomControls;
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
}
