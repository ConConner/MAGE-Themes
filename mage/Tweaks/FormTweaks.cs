using mage.Theming;
using mage.Tweaks.ParameterControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.Json;
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

        DisplayTweakParameters(t);
    }

    private void DisplayTweakParameters(Tweak t)
    {
        pnl_parameters.SuspendLayout();

        pnl_parameters.Controls.Clear();
        foreach (TweakParameter p in t.Parameters)
        {
            Control? c = null;
            switch (p.Type)
            {
                case ParameterType.Value:
                    c = new TweakParameterValue(p);
                    break;
                case ParameterType.Selection:
                    c = new TweakParameterSelection(p);
                    break;
                case ParameterType.Toggle:
                    c = new TweakParameterToggle(p);
                    break;
            }

            c?.Dock = DockStyle.Top;
            pnl_parameters.Controls.Add(c);
            c?.BringToFront();
            if (c is null) continue;

            tlt_parameterTip.SetToolTip(c, p.Description);
        }
        pnl_parameters.ResumeLayout();
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
        bool itemSelected = e.Item != null && lst_tweaks.Items.Contains(e.Item);

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

    private void btn_delete_Click(object sender, EventArgs e)
    {
        if (selectedTweak is null) return;

        if (MessageBox.Show("Deleting a Tweak cannot be undone. If this Tweak is currently applied, it will be reverted first.", "Delete Tweak",
            MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
            != DialogResult.OK) return;

        if (selectedTweak.Applied) Revert(selectedTweak);
        TweakManager.ProjectTweaks.Remove(selectedTweak);
        lst_tweaks.Items.Remove(selectedItem);

        selectedItem = null;
        selectedTweak = null;
    }

    private void btn_import_Click(object sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog
        {
            Multiselect = true,
            Filter = "Tweak files (*.mtw)|*.mtw",
            Title = "Select Tweaks"
        };
        if (dialog.ShowDialog() != DialogResult.OK) return;

        foreach (string file in dialog.FileNames)
        {
            try { TweakManager.ProjectTweaks.Add(ImportTweak(file)); }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not import tweak from:\n{file}\n\n{ex.Message}");
                continue;
            }
        }
        PopulateTweaksList();
    }

    private Tweak ImportTweak(string filename)
    {
        string json = File.ReadAllText(filename);
        Tweak t = JsonSerializer.Deserialize<Tweak>(json);
        return t;
    }
}
