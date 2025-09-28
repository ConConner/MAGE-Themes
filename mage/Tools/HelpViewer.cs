using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace mage.Tools;

public partial class HelpViewer : Form
{
    private static class DocFiles
    {
        public static string HelpDoc => "doc.html";
        public static string TechnicalDoc => "technical.html";
        public static string LegacyDoc => "legacy.html";
    }

    WebBrowser Browser;
	private string _pendingFragment;

    public HelpViewer(string page = null, string fragment = null)
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        Browser = new WebBrowser() { Dock = DockStyle.Fill };
        Browser.Navigating += Browser_Navigating;
        Browser.DocumentCompleted += Browser_DocumentCompleted;

		LoadPage(page ?? DocFiles.HelpDoc, fragment);
        group_help.Controls.Add(Browser);
    }

    private void Browser_Navigating(object? sender, WebBrowserNavigatingEventArgs e)
    {
		string url = e.Url.ToString();

		if (url.StartsWith("about:blank")) return;

        if (url.StartsWith("http://") || url.StartsWith("https://"))
        {
            e.Cancel = true;
            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(url)
            {
                UseShellExecute = true
            });
            return;
        }

        if (url.Contains(".html"))
		{
			e.Cancel = true;
			var parts = url.Split('#');
			string docName = Path.GetFileName(parts[0]).Replace("about:", "");
			string fragment = parts.Length > 1 ? parts[1] : null;

			LoadPage(docName, fragment);
		}
    }

    private void LoadPage(string page, string fragment = null)
    {
        string html = LoadHtml(page)
            .Replace("</head>", GetCustomCSS(ThemeSwitcher.ProjectTheme) + "</head>");

		_pendingFragment = fragment;
		Browser.DocumentText = html;
	}

	private void Browser_DocumentCompleted(object? sender, WebBrowserDocumentCompletedEventArgs e)
    {
		if (string.IsNullOrEmpty(_pendingFragment)) return;

		Browser.Document?.Window?.ScrollTo(0, GetElementTop(_pendingFragment));
		_pendingFragment = null;
    }

	private int GetElementTop(string elementId)
	{
		var element = Browser.Document?.GetElementById(elementId);
		return element?.OffsetRectangle.Top ?? 0;
	}

	private static string LoadHtml(string file)
    {
        return FormMain.LoadAssemblyResourceAsString($"mage.Docs.{file}")!;
    }

    private string GetCustomCSS(ColorTheme theme)
    {
        Color background2 = ColorOperations.ShiftLightness(theme.BackgroundColor, -0.02f);

        Color accent2color = ColorOperations.ShiftHue(theme.AccentColor, 30f);
        Color accent2colorDark = ControlPaint.Dark(accent2color, 0.40f);

        return $@"
		<style>
			body {{
				color: {theme.TextColor.ToHexString()};
				background-color: {theme.BackgroundColor.ToHexString()};
				display:block;
				border:0;
				margin:16px;
				padding:0px;
				font-family:verdana, sans-serif;
			}}
			.content {{
				background-color:{background2.ToHexString()};
				padding:10px;
				padding-top:16px;
				width:94%;
				margin-left:auto;
				margin-right:auto;
			}}
			a {{
				color: {theme.AccentColor.ToHexString()}
			}}

			h2 {{
				background-color:{ControlPaint.Dark(theme.AccentColor, 0.40f).ToHexString()};
				border-top:3px solid {theme.AccentColor.ToHexString()};
				margin-top:40px;
				padding:8px;
		
			}}
			h3 {{
				background-color:{accent2colorDark.ToHexString()};
				border-top:1px solid {accent2color.ToHexString()};
				margin-top:40px;
				margin-left:0px;
				padding:4px;
			}}

			table, th, td {{
				background-color: {theme.BackgroundColor.ToHexString()};
				border:1px solid {ControlPaint.Dark(theme.TextColor, 0.10f).ToHexString()};
				padding:0.2em;
			}}

			th {{
				background-color:{ControlPaint.Dark(theme.BackgroundColor, 0.10f).ToHexString()};
				padding-left:1em;
				padding-right:1em;
			}}
		</style>";
    }

    private void mAGEHelpToolStripMenuItem_Click(object sender, EventArgs e) => LoadPage(DocFiles.HelpDoc);

    private void technicalInformationToolStripMenuItem_Click(object sender, EventArgs e) => LoadPage(DocFiles.TechnicalDoc);

    private void legacyEditorsToolStripMenuItem_Click(object sender, EventArgs e) => LoadPage(DocFiles.LegacyDoc);
}
