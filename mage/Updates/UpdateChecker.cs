using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Updates;

public sealed class UpdateChecker
{
    private static readonly HttpClient _http = new() { DefaultRequestHeaders = { { "User-Agen", "MageThemes" } } };
    private const string Repo = "ConConner/MAGE-Themes";
    private StringCollection ignoredVersions = Properties.Settings.Default.updateCheckIgnoreVersions;

    public async Task CheckAsync(bool ignoreIgnoredVersions = false)
    {
        if (ignoredVersions == null)
        {
            ignoredVersions = new StringCollection();
            Properties.Settings.Default.updateCheckIgnoreVersions = ignoredVersions;
        }

        try
        {
            _http.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; MageThemes/1.0)");
            var json = await _http.GetStringAsync($"https://api.github.com/repos/{Repo}/releases/latest");
            using var doc = JsonDocument.Parse(json);
            var tag = doc.RootElement.GetProperty("tag_name").GetString().TrimStart('v');
            var url = doc.RootElement.GetProperty("assets")[0].GetProperty("browser_download_url").GetString();

            if (new System.Version(tag) > new System.Version(Program.Version) && (!ignoredVersions.Contains(tag) || ignoreIgnoredVersions))
                _ = Task.Run(() => new FormUpdateAvailable(tag, url, ignoreIgnoredVersions).ShowDialog());
            else if (ignoreIgnoredVersions)
            {
                MessageBox.Show("No new version found.");
            }
        }
        catch (Exception ex) 
        {
            Debugger.Break();
            Debug.WriteLine(ex);
        }
    }
}
