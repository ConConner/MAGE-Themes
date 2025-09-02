using mage.Properties;
using mage.Theming;
using mage.Theming.CustomControls;
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

public partial class PageOverview : UserControl, IReloadablePage
{
    bool init = false;
    bool createdRoomCounts = false;

    public PageOverview()
    {
        InitializeComponent();
        FormMain.Instance.NewRomLoaded += NewRomLoaded;
    }
    public void LoadPage()
    {
        if (Version.project == Version.ProjectState.None)
        {
            Clear();
            return;
        }
        init = true;

        group_rooms.Visible = true;
        group_resources.Visible = true;

        label_createdValue.Text = $"{Version.DateCreated.ToString()} in {TransformVersionString(Version.VersionCreated)}";
        label_lastModifiedValue.Text = $"{Version.DateModified.ToString()} in {TransformVersionString(Version.VersionModified)}";

        // Add num of rooms per area
        if (!createdRoomCounts)
        {
            group_rooms.Controls.Clear();
            group_rooms.Height = 28;

            int textBoxWidth = 25;
            int distanceX = 31;
            int distanceY = 29;
            Point initialLocation = new Point(6, 28);

            for (int i = 0; i < Version.RoomsPerArea.Length; i++)
            {
                string areaName = Version.AreaNames[i];
                int numOfRooms = Version.RoomsPerArea[i];

                Font f = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);

                FlatTextBox textBox = new FlatTextBox()
                {
                    Width = textBoxWidth,
                    Location = new Point(initialLocation.X, initialLocation.Y + i * distanceY),
                    Text = Hex.ToString(numOfRooms),
                    ReadOnly = true,
                    Font = f
                };
                Label label = new Label()
                {
                    Text = $"rooms in {areaName}",
                    AutoSize = true,
                    Location = new Point(initialLocation.X + distanceX, initialLocation.Y + i * distanceY + 3),
                    Font = f,
                };
                group_rooms.Controls.Add(textBox);
                group_rooms.Controls.Add(label);
            }
            createdRoomCounts = true;
        }

        // Set Project resources
        textBox_tilesets.Text = Hex.ToString(Version.NumOfTilesets);
        textBox_animatedTilesets.Text = Hex.ToString(Version.NumOfAnimTilesets);
        textBox_animatedGraphics.Text = Hex.ToString(Version.NumOfAnimGfx);
        textBox_animatedPalettes.Text = Hex.ToString(Version.NumOfAnimPalettes);
        textBox_spritesets.Text = Hex.ToString(Version.NumOfSpritesets);

        ThemeSwitcher.ChangeTheme(group_rooms.Controls);

        init = false;
    }

    private void NewRomLoaded(object? sender, EventArgs e)
    {
        createdRoomCounts = false;
    }

    private string TransformVersionString(string version)
    {
        bool isMageThemes = version.Split('.').Length == 4;
        System.Version v = new System.Version(version);
        string MAGE = isMageThemes ? "MAGE Themes" : "MAGE";
        return $"{MAGE} {v.Major}.{v.Minor}.{v.Build}";
    }

    private void Clear()
    {
        label_createdValue.Text = "No .proj file found";
        label_lastModifiedValue.Text = string.Empty;

        textBox_tilesets.Text = string.Empty;
        textBox_animatedTilesets.Text = string.Empty;
        textBox_animatedGraphics.Text = string.Empty;
        textBox_animatedPalettes.Text = string.Empty;
        textBox_spritesets.Text = string.Empty;

        group_rooms.Visible = false;
        group_resources.Visible = false;
    }
}
