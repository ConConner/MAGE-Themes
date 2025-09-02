using mage;
using mage.Properties;
using mage.Theming;
using mage.Theming.CustomControls;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace mage.Options.Pages;

public partial class PageLabels : UserControl, IReloadablePage
{
    private bool isLoading = false;

    public PageLabels()
    {
        InitializeComponent();
        FormMain.Instance.NewRomLoaded += NewRomLoaded;

        // Attach TextChanged handlers to update Version.CustomAreaNames when edited
        textBox_area1.TextChanged += AreaName_TextChanged;
        textBox_area2.TextChanged += AreaName_TextChanged;
        textBox_area3.TextChanged += AreaName_TextChanged;
        textBox_area4.TextChanged += AreaName_TextChanged;
        textBox_area5.TextChanged += AreaName_TextChanged;
        textBox_area6.TextChanged += AreaName_TextChanged;
        textBox_area7.TextChanged += AreaName_TextChanged;
        textBox_area8.TextChanged += AreaName_TextChanged;
        textBox_area9.TextChanged += AreaName_TextChanged;
        textBox_area10.TextChanged += AreaName_TextChanged;
    }

    public void LoadPage()
    {
        if (Version.project == Version.ProjectState.None)
        {
            Clear();
            return;
        }

        isLoading = true;

        group_areanames.Visible = true;

        textBox_area1.Text = Version.CustomAreaNames.Length > 0 ? Version.CustomAreaNames[0] : string.Empty;
        textBox_area2.Text = Version.CustomAreaNames.Length > 1 ? Version.CustomAreaNames[1] : string.Empty;
        textBox_area3.Text = Version.CustomAreaNames.Length > 2 ? Version.CustomAreaNames[2] : string.Empty;
        textBox_area4.Text = Version.CustomAreaNames.Length > 3 ? Version.CustomAreaNames[3] : string.Empty;
        textBox_area5.Text = Version.CustomAreaNames.Length > 4 ? Version.CustomAreaNames[4] : string.Empty;
        textBox_area6.Text = Version.CustomAreaNames.Length > 5 ? Version.CustomAreaNames[5] : string.Empty;
        textBox_area7.Text = Version.CustomAreaNames.Length > 6 ? Version.CustomAreaNames[6] : string.Empty;

        if (Version.IsMF)
        {
            textBox_area8.Visible = true;
            textBox_area9.Visible = true;
            textBox_area10.Visible = true;

            textBox_area8.Text = Version.CustomAreaNames.Length > 7 ? Version.CustomAreaNames[7] : string.Empty;
            textBox_area9.Text = Version.CustomAreaNames.Length > 8 ? Version.CustomAreaNames[8] : string.Empty;
            textBox_area10.Text = Version.CustomAreaNames.Length > 9 ? Version.CustomAreaNames[9] : string.Empty;

            ShowDebugLabels(true);
        }
        else
        {
            textBox_area8.Visible = false;
            textBox_area9.Visible = false;
            textBox_area10.Visible = false;

            ShowDebugLabels(false);
        }

        ThemeSwitcher.ChangeTheme(group_areanames.Controls);

        isLoading = false;
    }

    private void ShowDebugLabels(bool show)
    {
        // Assuming labels are named label_area8, label_area9, label_area10 and are accessible:
        foreach (Control ctrl in group_areanames.Controls)
        {
            if (ctrl is Label lbl)
            {
                if (lbl.Name == "label_area8" || lbl.Name == "label_area9" || lbl.Name == "label_area10")
                {
                    lbl.Visible = show;
                }
            }
        }
    }

    private void NewRomLoaded(object? sender, EventArgs e)
    {
        Clear();
    }

    private void Clear()
    {
        group_areanames.Visible = false;

        textBox_area1.Text = string.Empty;
        textBox_area2.Text = string.Empty;
        textBox_area3.Text = string.Empty;
        textBox_area4.Text = string.Empty;
        textBox_area5.Text = string.Empty;
        textBox_area6.Text = string.Empty;
        textBox_area7.Text = string.Empty;

        textBox_area8.Text = string.Empty;
        textBox_area9.Text = string.Empty;
        textBox_area10.Text = string.Empty;

        textBox_area8.Visible = false;
        textBox_area9.Visible = false;
        textBox_area10.Visible = false;

        ShowDebugLabels(false);
    }

    private void AreaName_TextChanged(object? sender, EventArgs e)
{
    if (isLoading)
        return;

    var areaNames = new List<string>
    {
        textBox_area1.Text,
        textBox_area2.Text,
        textBox_area3.Text,
        textBox_area4.Text,
        textBox_area5.Text,
        textBox_area6.Text,
        textBox_area7.Text
    };

    if (Version.IsMF)
    {
        areaNames.Add(textBox_area8.Text);
        areaNames.Add(textBox_area9.Text);
        areaNames.Add(textBox_area10.Text);
    }

    Version.CustomAreaNames = areaNames.ToArray();

    // ✅ Save the project if one exists
    if (Version.project != Version.ProjectState.None)
    {
        // Save using the same ROM/project filename
        // You likely need to pass the correct filename from somewhere
        // For this example, let’s assume FormMain.Instance.ProjectFilename exists
        string? filename = FormMain.Instance?.filename;

        if (!string.IsNullOrEmpty(filename))
        {
            Version.SaveProject(filename);
        }
    }
}
}
