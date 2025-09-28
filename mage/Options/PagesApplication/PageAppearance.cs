﻿using mage.Theming;
using mage.Theming.CustomControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Options.Pages;

[ToolboxItem(false)]
public partial class PageAppearance : UserControl, IReloadablePage
{
    bool init = false;
    ColorTheme selectedTheme;
    private FormMain parent = FormMain.Instance;

    public StatusStrip CustomStrip;

    public PageAppearance()
    {
        InitializeComponent();

        flatTextBox_accent.TextChanged += ColorValueChanged;
        flatTextBox_background.TextChanged += ColorValueChanged;
        flatTextBox_text.TextChanged += ColorValueChanged;
        flatTextBox_secondary.TextChanged += ColorValueChanged;
        flatTextBox_primary.TextChanged += ColorValueChanged;

        // This code is so bad, I hate myself for not planning ahead.
        CustomStrip = statusStrip;
        Controls.Remove(statusStrip);

        LoadPage();
    }

    public void LoadPage()
    {
        ThemeSwitcher.ChangeTheme(Controls);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        loadAllThemes();
    }

    private void loadAllThemes()
    {
        init = true;
        comboBox_theme.Items.Clear();
        foreach (KeyValuePair<string, ColorTheme> pair in ThemeSwitcher.Themes)
        {
            comboBox_theme.Items.Add(pair.Key);
        }

        init = false;

        comboBox_theme.SelectedIndex = comboBox_theme.Items.IndexOf(ThemeSwitcher.ProjectThemeName);
    }

    private void comboBox_theme_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (init) return;
        string key = comboBox_theme.Items[comboBox_theme.SelectedIndex].ToString();
        ThemeSwitcher.ProjectThemeName = key;
        selectedTheme = ThemeSwitcher.ProjectTheme;

        //Load name
        flatTextBox_name.Text = key;

        //Load color values
        flatTextBox_text.Text = ColorOperations.ToHexString(selectedTheme.TextColor);
        flatTextBox_background.Text = ColorOperations.ToHexString(selectedTheme.BackgroundColor);
        flatTextBox_primary.Text = ColorOperations.ToHexString(selectedTheme.PrimaryOutline);
        flatTextBox_secondary.Text = ColorOperations.ToHexString(selectedTheme.SecondaryOutline);
        flatTextBox_accent.Text = ColorOperations.ToHexString(selectedTheme.AccentColor);

        button_apply.Enabled = false;
        UpdateColorPreview();


        //Prevent Mage Old from getting deleted
        if (key == ThemeSwitcher.StandardThemeName || key == ThemeSwitcher.StandardDarkThemeName)
        {
            btn_remove.Enabled = false;
            flatTextBox_name.Enabled = false;
            groupBox_colors.Enabled = false;
            return;
        }
        else
        {
            btn_remove.Enabled = true;
            flatTextBox_name.Enabled = true;
            groupBox_colors.Enabled = true;
        }
    }

    private void UpdateColorPreview()
    {
        foreach (Control c in panel_main.Controls)
        {
            if (!(c is Panel)) continue;
            Panel p = c as Panel;

            string key = p.Tag.ToString();
            p.BackColor = ThemeSwitcher.ProjectTheme.Colors[key];
        }
    }

    private void ColorValueChanged(object sender, EventArgs e)
    {
        FlatTextBox box = sender as FlatTextBox;
        Panel associate = this.Controls.Find(box.Tag.ToString(), true)[0] as Panel;

        //Do a Regex check if value is actually a hex number
        string text = box.Text;
        text = Regex.Match(text, @"[0-9a-fA-F]+").Value;
        if (text.Length != 6) return; //if 6 numbers are not given
        text = text.Insert(0, "#");

        associate.BackColor = ColorTranslator.FromHtml(text);
        button_apply.Enabled = true;
    }

    private void button_apply_Click(object sender, EventArgs e)
    {
        string currentName = comboBox_theme.Text;
        string newName = flatTextBox_name.Text;

        //Check if name is empty or contains only spaces
        if (newName.Trim().Length == 0 || newName.Length == 0)
        {
            MessageBox.Show($"Name cannot be empty!", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        //Check if new name already exists
        if (ThemeSwitcher.Themes.ContainsKey(newName) && newName != currentName)
        {
            MessageBox.Show($"\"{newName}\" is already used!", "Invalid name", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        foreach (Control c in panel_main.Controls)
        {
            if (!(c is Panel)) continue;
            Panel p = c as Panel;

            string key = p.Tag.ToString();
            selectedTheme.Colors[key] = p.BackColor;
        }

        ThemeSwitcher.ProjectThemeName = comboBox_theme.Items[comboBox_theme.SelectedIndex].ToString();
        UpdateColorPreview();
        button_apply.Enabled = false;

        //if name is different then currently, change name
        if (newName != currentName)
        {
            ThemeSwitcher.Themes.Add(newName, selectedTheme);
            ThemeSwitcher.Themes.Remove(currentName);
            comboBox_theme.Items[comboBox_theme.SelectedIndex] = newName;
            parent.PopulateThemeList(null, null);
        }
    }

    private void btn_remove_Click(object sender, EventArgs e)
    {
        string key = comboBox_theme.Items[comboBox_theme.SelectedIndex].ToString();
        ThemeSwitcher.Themes.Remove(key);
        int lastIndex = comboBox_theme.SelectedIndex;
        comboBox_theme.Items.RemoveAt(comboBox_theme.SelectedIndex);
        comboBox_theme.SelectedIndex = lastIndex != 0 ? lastIndex - 1 : 0;
        parent.PopulateThemeList(null, null);
    }

    private void btn_add_Click(object sender, EventArgs e)
    {
        //Finding an unused name
        string name = "New Theme";
        int i = 1;
        while (comboBox_theme.Items.Contains(name))
        {
            name = $"New Theme {i}";
            i++;
        }
        //Very inefficient way of creating a clone of the standard theme but I cant be bothered to implement a proper deep clone function now
        ColorTheme newStandardTheme = ThemeSwitcher.Deserialize<ColorTheme>(ThemeSwitcher.Serialize(ThemeSwitcher.StandardTheme));
        ThemeSwitcher.Themes.Add(name, newStandardTheme);

        comboBox_theme.Items.Add(name);
        comboBox_theme.SelectedIndex = comboBox_theme.Items.IndexOf(name);
        parent.PopulateThemeList(null, null);
    }

    private void menuItem_export_Click(object sender, EventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "MAGE Theme File (*.mtf)|*.mtf";
        dialog.FileName = comboBox_theme.Text;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            //convert key pair to json object
            KeyValuePair<string, ColorTheme> theme = new KeyValuePair<string, ColorTheme>(comboBox_theme.Text, selectedTheme);
            string data = ThemeSwitcher.Serialize(theme);
            File.WriteAllText(dialog.FileName, data);
        }
    }

    private void menuItem_import_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "MAGE Theme File (*.mtf)|*mtf";
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            string data = File.ReadAllText(dialog.FileName);
            ImportNewTheme(data);
        }
    }

    private void importAll_Click(object sender, EventArgs e)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = "Zip Archive (*.zip)|*zip";
        if (dialog.ShowDialog() != DialogResult.OK) return;

        //opening the zip archive
        using (ZipArchive zip = ZipFile.Open(dialog.FileName, ZipArchiveMode.Read))
        {
            //looping through every entry
            foreach (ZipArchiveEntry entry in zip.Entries)
            {
                if (Path.GetExtension(entry.Name) != ".mtf") continue;

                var reader = new StreamReader(entry.Open());
                string data = reader.ReadToEnd();

                ImportNewTheme(data);

                reader.Dispose();
            }
        }
    }

    private void exportAll_Click(object sender, EventArgs e)
    {
        SaveFileDialog dialog = new SaveFileDialog();
        dialog.Filter = "Zip Archive (*.zip)|*zip";
        if (dialog.ShowDialog() != DialogResult.OK) return;

        //creating a new zip
        using (var stream = new MemoryStream())
        {
            using (var archive = new ZipArchive(stream, ZipArchiveMode.Create, true))
            {
                foreach (KeyValuePair<string, ColorTheme> pair in ThemeSwitcher.Themes)
                {
                    //Checking if standard theme
                    if (pair.Key == ThemeSwitcher.StandardThemeName || pair.Key == ThemeSwitcher.StandardDarkThemeName) continue;

                    string data = ThemeSwitcher.Serialize(pair);

                    //Writing the theme to an entry in the zip
                    var themeFile = archive.CreateEntry(pair.Key + ".mtf");
                    using (var entryStream = themeFile.Open()) using (var writer = new StreamWriter(entryStream))
                    {
                        writer.Write(data);
                    }
                }
            }

            //writing zip to file
            using (var fileStream = new FileStream(dialog.FileName, FileMode.Create))
            {
                stream.Seek(0, SeekOrigin.Begin);
                stream.CopyTo(fileStream);
            }
        }
    }

    /// <summary>
    /// Imports a theme from a file string
    /// </summary>
    /// <param name="data"></param>
    private void ImportNewTheme(string data)
    {
        KeyValuePair<string, ColorTheme> pair = ThemeSwitcher.Deserialize<KeyValuePair<string, ColorTheme>>(data);

        //Checking if name is correct
        string name = pair.Key;
        if (ThemeSwitcher.Themes.ContainsKey(name))
        {
            if (MessageBox.Show($"The name \"{name}\" is already used!\n\nDo still want to import the theme?\nThe name will be changed.", "Invalid name", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                != DialogResult.Yes) return;

            //Change name
            name = "New Theme";
            int i = 1;
            while (comboBox_theme.Items.Contains(name))
            {
                name = $"New Theme {i}";
                i++;
            }
        }

        //Adding theme to dictionary
        ThemeSwitcher.Themes.Add(name, pair.Value);
        comboBox_theme.Items.Add(name);
        comboBox_theme.SelectedIndex = comboBox_theme.Items.IndexOf(name);
        parent.PopulateThemeList(null, null);
    }

    private void flatTextBox_name_TextChanged(object sender, EventArgs e)
    {
        button_apply.Enabled = true;
    }

    private static Color GBAtoRGB(ushort color)
    {
        byte red = (byte)((color >> 10 & 0b11111) << 3);
        byte green = (byte)((color >> 5 & 0b11111) << 3);
        byte blue = (byte)((color & 0b11111) << 3);

        return Color.FromArgb(red, green, blue);
    }

    private static ushort RGBtoGBA(Color color)
    {
        byte red = (byte)(color.R >> 3);
        byte green = (byte)(color.G >> 3);
        byte blue = (byte)(color.B >> 3);

        return (ushort)(red << 10 | green << 5 | blue);
    }

    private void pnl_color_Click(object sender, EventArgs e)
    {
        ColorDialog dialog = new ColorDialog();
        if (dialog.ShowDialog() != DialogResult.OK) return;

        //Set new background color
        Color c = dialog.Color;
        ushort gbaColor = RGBtoGBA(c);
        parent.Bg3Color = gbaColor;

        //Set new color on Panel
        pnl_color.BackColor = GBAtoRGB(gbaColor);

        if (parent.Room == null) return;
        parent.ReloadRoom(false);
    }
}
