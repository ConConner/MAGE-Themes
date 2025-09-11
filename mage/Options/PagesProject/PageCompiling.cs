﻿using mage.Properties;
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

namespace mage.Options.Pages;

public partial class PageCompiling : UserControl, IReloadablePage
{
    bool init = false;

    public PageCompiling()
    {
        InitializeComponent();
    }
    public void LoadPage()
    {
        init = true;

        checkBox_enableCompilation.Checked = Version.ProjectConfig.EnableProjectCompilation;
        group_compilationSettings.Enabled = Version.ProjectConfig.EnableProjectCompilation;
        checkBox_abortTestOnError.Checked = Version.ProjectConfig.AbortTestingIfCompilationFailed;
        textBox_scriptPath.Text = Version.ProjectConfig.CompilationScriptPath;
        textBox_outputName.Text = Version.ProjectConfig.CompilationOutputRomName;

        init = false;
    }

    private void checkBox_enableCompilation_CheckedChanged(object sender, EventArgs e)
    {
        if (init) return;
        group_compilationSettings.Enabled = checkBox_enableCompilation.Checked;
        Version.ProjectConfig.EnableProjectCompilation = checkBox_enableCompilation.Checked;
    }

    private void textBox_scriptPath_TextChanged(object sender, EventArgs e)
    {
        if (init) return;
        Version.ProjectConfig.CompilationScriptPath = textBox_scriptPath.Text;
    }

    private void textBox_outputName_TextChanged(object sender, EventArgs e)
    {
        if (init) return;
        Version.ProjectConfig.CompilationOutputRomName = textBox_outputName.Text;
    }

    private void checkBox_abortTestOnError_CheckedChanged(object sender, EventArgs e)
    {
        if (init) return;
        Version.ProjectConfig.AbortTestingIfCompilationFailed = checkBox_abortTestOnError.Checked;
    }

    private void button_selectScriptPath_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new();
        dialog.Filter = "Scripts|*.bat;*.cmd;*.ps1;*.vbs;*.js|All Files|*.*";
        if (dialog.ShowDialog() != DialogResult.OK) return;

        textBox_scriptPath.Text = dialog.FileName;
    }
}
