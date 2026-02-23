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
    Tweak selectedTweak;
    ListViewItem selectedItem;

    public FormTweaks()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        pnl_main.Panel2Collapsed = true;

        ImageList statusIcons = new ImageList();
        statusIcons.Images.Add("checked", Properties.Resources.accept);
        statusIcons.Images.Add("unchecked", Properties.Resources.transparent);
        statusIcons.ImageSize = new Size(16, 16);

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

    private void DisplayTweakProperties(Tweak t)
    {
        lbl_author.Text = t.Author;
        lbl_name.Text = t.Name;
        txb_description.Text = t.Description ?? "";

        bool hasParam = t.Parameters.Count > 0;
        lbl_parameters.Visible = hasParam;
        pnl_parameters.Visible = hasParam;
        sep_parameters.Visible = hasParam;
        pnl_parameters.Enabled = !t.Applied;

        btn_applyRevert.Text = t.Applied ? "Revert" : "Apply";
    }

    private void lst_tweaks_Resize(object sender, EventArgs e)
    {
        var lv = sender as ListView;
        if (lv?.Columns.Count < 2) return;

        lv.SuspendLayout();
        try
        {
            int fixedWidth = lv.Columns[1].Width;

            // Account for vertical scrollbar width (if items overflow) + 2px safety margin
            int availableWidth = lv.ClientSize.Width
                - fixedWidth;

            lv.Columns[0].Width = Math.Max(50, availableWidth);
        }
        finally
        {
            lv.ResumeLayout();
        }
    }

    private void lst_tweaks_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
        bool itemSelected = e.Item != null;

        pnl_main.Panel2Collapsed = !itemSelected;
        grp_properties.Enabled = itemSelected;

        if (!itemSelected) return;
        Tweak t = TweakManager.ProjectTweaks[e.ItemIndex];
        DisplayTweakProperties(t);
        selectedTweak = t;
        selectedItem = e.Item;
    }

    private void btn_applyRevert_Click(object sender, EventArgs e)
    {
        if (selectedTweak.Applied) Revert(selectedTweak);
        else Apply(selectedTweak);
        UpdateListItem(selectedItem, selectedTweak);
        DisplayTweakProperties(selectedTweak);
    }

    private void Apply(Tweak t)
    {
        try
        {
            if (!TweakValidation.Validate(t)) return;
            t.Apply(ROM.Stream);
        }
        catch (Exception e)
        {
            MessageBox.Show($"Could not apply Tweak.\n\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
    }
    private void Revert(Tweak t)
    {
        t.Revert(ROM.Stream);
    }

    private void UpdateListItem(ListViewItem item, Tweak tweak)
    {
        item.ImageIndex = tweak.Applied ? 0 : 1;
    }
}
