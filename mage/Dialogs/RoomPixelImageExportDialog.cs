using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Dialogs;

public struct RoomPixelImageExportDialogResult
{
    public RoomPixelImageExportDialogResult() { }

    public Color ColorBackground { get; set; } = Color.Black;
    public Color ColorSolid { get; set; } = Color.Gray;

    public Color ColorBlueHatch { get; set; } = Color.Blue;
    public Color ColorRedHatch { get; set; } = Color.Red;
    public Color ColorYellowHatch { get; set; } = Color.Yellow;
    public Color ColorGreenHatch { get; set; } = Color.Green;
    public Color ColorGrayHatch { get; set; } = Color.LightGray;

    public Color ColorShotBlock { get; set; } = Color.White;
    public Color ColorCrumbleBlock { get; set; } = Color.LightGray;
    public Color ColorBombBlock { get; set; } = Color.MediumPurple;
    public Color ColorMissileBlock { get; set; } = Color.IndianRed;
    public Color ColorSuperBlock { get; set; } = Color.LawnGreen;
    public Color ColorSpeedBlock { get; set; } = Color.GreenYellow;
    public Color ColorScrewBlock { get; set; } = Color.Gold;
    public Color ColorPowerBlock { get; set; } = Color.Purple;
}

public partial class RoomPixelImageExportDialog : Form
{
    public RoomPixelImageExportDialog()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);
    }
}
