using mage.Properties;
using mage.Theming;
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

public partial class PageAdvanced : UserControl, IReloadablePage
{
    public PageAdvanced()
    {
        InitializeComponent();

        checkBox_experimental.Checked = Program.ExperimentalFeaturesEnabled;
        checkBox_legacyEditors.Checked = Program.LegacyEditors;

        LoadPage();
    }
    public void LoadPage()
    { }

    private void checkBox_experimental_CheckedChanged(object sender, EventArgs e)
    {
        Program.ExperimentalFeaturesEnabled = checkBox_experimental.Checked;
    }

    private void checkBox_legacyEditors_CheckedChanged(object sender, EventArgs e)
    {
        Program.LegacyEditors = checkBox_legacyEditors.Checked;
    }
}
