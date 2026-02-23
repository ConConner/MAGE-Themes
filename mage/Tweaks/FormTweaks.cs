using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Tweaks;

public partial class FormTweaks : Form
{
    public FormTweaks()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        pnl_main.Panel2Collapsed = true;

        ImageList statusIcons = new ImageList();
        statusIcons.Images.Add("checked", Properties.Resources.accept);
        statusIcons.Images.Add("unchecked", Properties.Resources.transparent);

        lst_tweaks.SmallImageList = statusIcons;
        lst_tweaks.View = View.Details;

        PopulateTweaksList();
    }

    private void PopulateTweaksList()
    {
        lst_tweaks.Items.Clear();
        foreach (Tweak t in TweakManager.ProjectTweaks)
        {
            ListViewItem item = new ListViewItem(t.Name);
            item.ImageIndex = t.Applied ? 0 : 1;
            item.SubItems.Add(t.Author);

            lst_tweaks.Items.Add(item);
        }
    }

    private void lst_tweaks_Resize(object sender, EventArgs e)
    {
        ListView lv = sender as ListView;
        int authorFixedWidth = lv.Columns[1].Width;
        lv.Columns[0].Width = lv.ClientSize.Width - authorFixedWidth;
    }
}
