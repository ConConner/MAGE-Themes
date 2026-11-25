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
    private bool scriptFinished = false;

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
        using var scriptRunner = new ScriptExecutor(scriptPath, null, logFromAnyThread);

        ScriptResult result;
        try
        {
            result = await scriptRunner.ExecuteAsync(tempRomPath, cts.Token);
        }
        catch (OperationCanceledException)
        {
            return; // user cancelled / closed the window, nothing left to update
        }

        scriptFinished = true;

        // The window may have been closed while the script was finishing
        if (IsDisposed) return;

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
            if (Version.ProjectConfig.CompilationIgnoreErrors) btn_launchAnyways_Click(null, null);
        }
    }

    private void log(string message)
    {
        if (IsDisposed) return;
        txb_output.AppendText(message + Environment.NewLine);
    }

    /// <summary>
    /// Called from process output threads. Posts to the UI thread without blocking
    /// and ignores lines that arrive after the window has been closed.
    /// </summary>
    private void logFromAnyThread(string message)
    {
        if (IsDisposed || !IsHandleCreated) return;
        try
        {
            BeginInvoke(() => log(message));
        }
        catch (ObjectDisposedException) { }
        catch (InvalidOperationException) { } // handle destroyed between the check and the call
    }

    private void Cancel()
    {
        cts.Cancel();
        DialogResult = DialogResult.Cancel;
    }

    private void btn_launchAnyways_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        NewOutputPath = null;
        Close();
    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
        Cancel();
        Close();
    }

    private void FormScriptOutput_Shown(object sender, EventArgs e) => RunScript();

    private void FormScriptOutput_FormClosing(object sender, FormClosingEventArgs e)
    {
        // Only abort a script that is still running. Once it has finished, the
        // DialogResult set by RunScript (OK) must not be overwritten with Cancel.
        if (!scriptFinished) Cancel();
    }
}
