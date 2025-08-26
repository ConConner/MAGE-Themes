using mage.Properties;
using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Options.Pages;

public partial class PageRom : UserControl, IReloadablePage
{
    FormMain Parent;
    bool init = false;
    private int selectedIndex;
    private int SelectedIndex
    {
        get => selectedIndex;
        set
        {
            selectedIndex = value;
            button_remove.Enabled = value != -1;
            if (value == -1)
            {
                Program.Config.SelectedEmulatorPath = string.Empty;
                SetCurrentEmulatorLabel("---");
                return;
            }
            else Program.Config.SelectedEmulatorPath = Program.Config.EmulatorPaths[value];
            SetCurrentEmulatorLabel(Program.Config.SelectedEmulatorPath);
        }
    }


    public PageRom()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        LoadPage();
    }
    public void LoadPage()
    {
        listBox_emulators.Items.Clear();
        foreach (string emulator in Program.Config.EmulatorPaths)
        {
            listBox_emulators.Items.Add(Path.GetFileName(emulator));
        }
        if (Program.Config.SelectedEmulatorPath != string.Empty)
        {
            int index = listBox_emulators.Items.IndexOf(Path.GetFileName(Program.Config.SelectedEmulatorPath));
            listBox_emulators.SelectedIndex = index;
        }
        else SetCurrentEmulatorLabel("---");
    }

    private void SetCurrentEmulatorLabel(string path)
    {
        label_currentEmulator.Text = $"Current Emulator path: {path}";
    }

    private void button_add_Click(object sender, EventArgs e)
    {
        var ofd = new OpenFileDialog();
        ofd.Filter = "GBA emulator (*.exe)|*.exe|All files (*.*)|*.*";
        if (ofd.ShowDialog() != DialogResult.OK) return;
        string name = Path.GetFileName(ofd.FileName);

        if (Program.Config.EmulatorPaths.Contains(name))
        {
            int index = listBox_emulators.Items.IndexOf(name);
            listBox_emulators.SelectedIndex = index;
            return;
        }
        listBox_emulators.Items.Add(name);
        Program.Config.EmulatorPaths.Add(ofd.FileName);
        SelectedIndex = listBox_emulators.Items.Count - 1;
    }

    private void listBox_emulators_SelectedIndexChanged(object sender, EventArgs e) => SelectedIndex = listBox_emulators.SelectedIndex;

    private void button_remove_Click(object sender, EventArgs e)
    {
        Program.Config.EmulatorPaths.RemoveAt(SelectedIndex);
        listBox_emulators.Items.RemoveAt(SelectedIndex);
        SelectedIndex = -1;
    }

}
