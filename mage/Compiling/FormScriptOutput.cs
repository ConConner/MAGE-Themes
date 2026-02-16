using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace mage.Compiling;

public partial class FormScriptOutput : Form
{
    public string? NewOutputPath { get; private set; } = null;

    private CancellationTokenSource cts = new CancellationTokenSource();
    private string scriptPath;
    private string tempRomPath;

    public FormScriptOutput(string scriptPath, string tempRomPath)
    {
        InitializeComponent();

        // Theme Switching
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        this.scriptPath = scriptPath;
        this.tempRomPath = tempRomPath;
    }

    public async void RunScript()
    {
        var scriptRunner = new ScriptExecutor(scriptPath, null, line => Invoke(() => log(line)));
        var result = await scriptRunner.ExecuteAsync(tempRomPath, cts.Token);

        if (result.Success)
        {
            DialogResult = DialogResult.OK;
            NewOutputPath = result.OutputRomPath;
            Close();
        }
        else
        {
            log($"[FAIL] exit {result.ExitCode}: {result.Error}");
            pnl_error.Visible = true;
        }
    }

    private void log(string message)
    {
        txb_output.AppendText(message + Environment.NewLine);
    }

    private void btn_launchAnyways_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        NewOutputPath = null;
        Close();
    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
        cts.Cancel();
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void FormScriptOutput_Shown(object sender, EventArgs e) => RunScript();
}
