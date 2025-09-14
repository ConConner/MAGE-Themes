using mage.Properties;
using mage.Theming;
using mage.Updates;
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

namespace mage.Options.Pages;

public partial class PageUpdates : UserControl, IReloadablePage
{
    public PageUpdates()
    {
        InitializeComponent();
        LoadPage();
    }
    public void LoadPage()
    {
        checkBox_auto_update.Checked = Program.Config.AutomaticallyCheckForUpdates;
        checkBox_notifyMajor.Checked = Program.Config.OnlyNotifyOnMajor;
        checkBox_notifyMajor.Enabled = Program.Config.AutomaticallyCheckForUpdates;
    }

    private void checkBox_auto_update_CheckedChanged(object sender, EventArgs e)
    {
        Program.Config.AutomaticallyCheckForUpdates = checkBox_auto_update.Checked;
        checkBox_notifyMajor.Enabled = Program.Config.AutomaticallyCheckForUpdates;
    }

    private void checkBox_notifyMajor_CheckedChanged(object sender, EventArgs e)
    {
        Program.Config.OnlyNotifyOnMajor = checkBox_notifyMajor.Checked;
    }

    private void button_checkNow_Click(object sender, EventArgs e)
    {
        _ = new UpdateChecker().CheckAsync(true);
    }
}
