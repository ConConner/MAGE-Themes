using mage.Options.Pages;
using mage.Theming;
using mage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Options;

public partial class FormOption : Form
{
    private List<OptionsPage> Pages;

    SplitterPanel PanelContent => panel_main.Panel2;
    private int selectedPage = -1;
    private int SelectedPage
    {
        get => selectedPage;
        set
        {
            if (selectedPage == value) return;

            // "close" old page
            ClosePage(selectedPage);

            selectedPage = value;

            if (value == -1) return;
            OptionsPage currentPage = Pages[value];

            PanelContent.Controls.Clear();
            PanelContent.Controls.Add(currentPage.Page);
            PanelContent.Controls.Add(panel_requiresRom);
            if (currentPage.CustomStatusStrip == null) PanelContent.Controls.Add(statusStrip);
            else PanelContent.Controls.Add(currentPage.CustomStatusStrip);
            currentPage.Page.Dock = DockStyle.Fill;
            panel_requiresRom.Dock = DockStyle.Top;
            currentPage.Page.BringToFront();

            currentPage.Page.SuspendDrawing();
            ThemeSwitcher.ChangeTheme(Controls);
            ThemeSwitcher.InjectPaintOverrides(Controls);
            currentPage.Page.ResumeDrawing();

            bool enabled = !currentPage.RequiresROM || ROM.Stream != null;
            currentPage.Page.Enabled = enabled;
            panel_requiresRom.Visible = !enabled;

            if (currentPage.Page is IReloadablePage reloadablePage) reloadablePage.LoadPage();

            if (listBox_pages.SelectedIndex != value) listBox_pages.SelectedIndex = value;
        }
    }

    private int GetPageIndex(string pagename) => Pages.FindIndex(p => p.Name == pagename);

    public FormOption(string optionTitle, List<OptionsPage> pages, string pageName = "")
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        Pages = pages;
        Text = optionTitle;

        // Populate List
        foreach (OptionsPage page in Pages)
        {
            if (page.RequiresProject && Version.project == Version.ProjectState.None) continue;
            listBox_pages.Items.Add(page.Name);
        }
        SelectedPage = GetPageIndex(pageName);
    }

    private void listBox_Pages_SelectedIndexChanged(object sender, EventArgs e) => SelectedPage = listBox_pages.SelectedIndex;

    private void ClosePage(int pageId)
    {
        if (pageId < 0 || pageId >= Pages.Count) return;
        OptionsPage oldPage = Pages[pageId];
        if (oldPage.Page is IClosablePage closablePage) closablePage.ClosedPage();
    }

    private void FormOption_FormClosing(object sender, FormClosingEventArgs e)
    {
        ClosePage(selectedPage);
    }
}
