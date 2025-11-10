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

public partial class PageDecomp : UserControl, IReloadablePage
{
    bool init = false;

    public PageDecomp()
    {
        InitializeComponent();
    }

    public void LoadPage()
    {
        init = true;
        textBox_path.Text = Version.ProjectConfig.DecompPath;
        init = false;
    }

    private void button_select_Click(object sender, EventArgs e)
    {
        FolderBrowserDialog fbd = new();
        DialogResult dr = fbd.ShowDialog();
        if (dr != DialogResult.OK) return;

        textBox_path.Text = fbd.SelectedPath;
    }

    private void textBox_path_TextChanged(object sender, EventArgs e)
    {
        if (init) return;
        Version.ProjectConfig.DecompPath = textBox_path.Text;

        FormMain.Instance.UpdateSaveDecompButton();
    }
}
