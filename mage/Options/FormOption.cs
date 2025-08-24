using mage.Options.Pages;
using mage.Theming;
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
    private struct OptionsPage
    {
        public string Name;
        public UserControl Page;
    }

    private List<OptionsPage> Pages = new List<OptionsPage>()
    {
        new() { Name = "Appearance", Page = new PageAppearance() },
        new() { Name = "Soundpacks", Page = new PageSoundpacks() },
    };

    SplitterPanel PanelContent => panel_main.Panel2;
    private int selectedPage = -1;
    private int SelectedPage
    {
        get => selectedPage;
        set
        {
            if (selectedPage == value) return;
            selectedPage = value;

            if (value == -1) return;
            OptionsPage currentPage = Pages[value];
            PanelContent.Controls.Clear();

            PanelContent.Controls.Add(currentPage.Page);
            currentPage.Page.Dock = DockStyle.Fill;

            if (listBox_pages.SelectedIndex != value) listBox_pages.SelectedIndex = value;
        }
    }

    private int GetPageIndex(string pagename) => Pages.FindIndex(p => p.Name == pagename);

    public FormOption(string pageName = "")
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        // Populate List
        foreach (OptionsPage page in Pages)
        {
            listBox_pages.Items.Add(page.Name);
        }
        SelectedPage = GetPageIndex(pageName);
    }

    private void listBox_Pages_SelectedIndexChanged(object sender, EventArgs e) => SelectedPage = listBox_pages.SelectedIndex;
}
