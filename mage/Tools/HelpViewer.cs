using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Tools;

public partial class HelpViewer : Form
{
    //private static string MageAssemblyPath = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);
    //public static string MageDocPath = Path.Combine(MageAssemblyPath, "doc.html");
    //public static string MageTechnicalPath = Path.Combine(MageAssemblyPath, "technical.html");

    //private string initialPath = "";

    //public HelpViewer(string path) : this()
    //{
    //    initialPath = path;
    //}

    public HelpViewer()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        //// Initialize WebView2
        //webview.EnsureCoreWebView2Async();
        //webview.CoreWebView2InitializationCompleted += Webview_CoreWebView2InitializationCompleted;
        //webview.NavigationCompleted += Webview_NavigationCompleted;
    }

    //private void Webview_CoreWebView2InitializationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2InitializationCompletedEventArgs e)
    //{
    //    if (e.IsSuccess)
    //    {
    //        webview.CoreWebView2.Settings.IsStatusBarEnabled = false;
    //        webview.CoreWebView2.Settings.AreDevToolsEnabled = false;
    //        webview.CoreWebView2.Settings.IsZoomControlEnabled = false;
    //        OpenFileOrURL(initialPath != "" ? initialPath : MageDocPath);
    //    }
    //    else
    //    {
    //        MessageBox.Show("Failed to initialize WebView2: " + e.InitializationException.Message);
    //    }
    //}
    //
    //private async void Webview_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
    //{
    //    if (!e.IsSuccess) return;
    //}


    //public bool Navigate(string path)
    //{
    //    if (webview == null || webview.CoreWebView2 == null) return false;
    //    webview.CoreWebView2.Navigate(path);
    //    return true;
    //}

    //public bool OpenFileOrURL(string path)
    //{
    //    if (webview == null || webview.CoreWebView2 == null) return false;
    //
    //    // Check if the path is a URL or a local file
    //    bool isFile = (Uri.IsWellFormedUriString(path, UriKind.Absolute) && File.Exists(path));
    //    path = "file:///" + path;
    //
    //    webview.CoreWebView2.Navigate(path);
    //    return true;
    //}

    //private void mAGEHelpToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    OpenFileOrURL(MageDocPath);
    //}

    //private void technicalInformationToolStripMenuItem_Click(object sender, EventArgs e)
    //{
    //    OpenFileOrURL(MageTechnicalPath);
    //}
}
