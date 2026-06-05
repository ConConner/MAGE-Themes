using mage.Theming;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace mage.Options.Pages;

[ToolboxItem(false)]
public partial class PageMusiclists : UserControl
{
    private string currentFilePath = "";

    public PageMusiclists()
    {
        InitializeComponent();

        txb_preview.ReadOnly = false;

        LoadMusicListNames();

        Disposed += PageMusiclists_Disposed;
    }

    private void LoadMusicListNames()
    {
        SaveCurrentMusicList();

        lst_muslists.Items.Clear();
        txb_preview.Text = "";

        textBox_path.Text = Muslist.MusiclistsPath;

        if (!Directory.Exists(Muslist.MusiclistsPath))
            return;

        int selectIndex = -1;
        int count = -1;

        foreach (string file in Directory.GetFiles(Muslist.MusiclistsPath, "*.txt"))
        {
            count++;

            string name = Path.GetFileName(file);
            lst_muslists.Items.Add(name);

            if (name == Muslist.MusiclistName)
                selectIndex = count;
        }

        lst_muslists.SelectedIndex = selectIndex;
    }

    private void btn_select_path_Click(object sender, EventArgs e)
    {
        SaveCurrentMusicList();

        FolderBrowserDialog dialog = new FolderBrowserDialog();

        if (dialog.ShowDialog() != DialogResult.OK)
            return;

        Muslist.MusiclistsPath = dialog.SelectedPath;
        textBox_path.Text = dialog.SelectedPath;

        currentFilePath = "";

        LoadMusicListNames();
    }

    private void lst_muslists_SelectedIndexChanged(object sender, EventArgs e)
    {
        SaveCurrentMusicList();

        int index = lst_muslists.SelectedIndex;

        if (index == -1)
        {
            Muslist.MusiclistName = "";
            currentFilePath = "";
            txb_preview.Text = "";
            return;
        }

        Muslist.MusiclistName = lst_muslists.Items[index].ToString();

        currentFilePath = Path.Combine(Muslist.MusiclistsPath, Muslist.MusiclistName);

        if (!File.Exists(currentFilePath))
        {
            txb_preview.Text = "";
            return;
        }

        txb_preview.Text = File.ReadAllText(currentFilePath);
    }

    private void SaveCurrentMusicList()
    {
        if (currentFilePath == "")
            return;

        if (!File.Exists(currentFilePath))
            return;

        File.WriteAllText(currentFilePath, txb_preview.Text);
    }

    private void PageMusiclists_Disposed(object sender, EventArgs e)
    {
        SaveCurrentMusicList();
    }
}