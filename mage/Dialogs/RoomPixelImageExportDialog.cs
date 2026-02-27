using mage.Theming;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Dialogs;

public struct PixelImageColors
{
    public PixelImageColors() { }

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
    public PixelImageColors Colors { get; set; }

    public RoomPixelImageExportDialog()
    {
        InitializeComponent();

        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        Colors = Program.Config.PixelImageColors;
        UpdatePanels();
    }

    private void btn_ok_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Colors = UpdateColors();
        Program.Config.PixelImageColors = Colors;
        Close();
    }

    private void btn_cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }

    private void UpdatePanels()
    {
        pnl_colBackground.BackColor = Colors.ColorBackground;
        pnl_colSolid.BackColor = Colors.ColorSolid;
        pnl_colGrayHatch.BackColor = Colors.ColorGrayHatch;
        pnl_colBlueHatch.BackColor = Colors.ColorBlueHatch;
        pnl_colRedHatch.BackColor = Colors.ColorRedHatch;
        pnl_colGreenHatch.BackColor = Colors.ColorGreenHatch;
        pnl_colYellowHatch.BackColor = Colors.ColorYellowHatch;
        pnl_colShot.BackColor = Colors.ColorShotBlock;
        pnl_colBombs.BackColor = Colors.ColorBombBlock;
        pnl_colPowerBombs.BackColor = Colors.ColorPowerBlock;
        pnl_colMissile.BackColor = Colors.ColorMissileBlock;
        pnl_colSuper.BackColor = Colors.ColorSuperBlock;
        pnl_colSpeed.BackColor = Colors.ColorSpeedBlock;
        pnl_colScrew.BackColor = Colors.ColorScrewBlock;
        pnl_colCrumble.BackColor = Colors.ColorCrumbleBlock;
    }

    private PixelImageColors UpdateColors()
    {
        return new()
        {
            ColorBackground = pnl_colBackground.BackColor,
            ColorSolid = pnl_colSolid.BackColor,
            ColorGrayHatch = pnl_colGrayHatch.BackColor,
            ColorBlueHatch = pnl_colBlueHatch.BackColor,
            ColorRedHatch = pnl_colRedHatch.BackColor,
            ColorGreenHatch = pnl_colGreenHatch.BackColor,
            ColorYellowHatch = pnl_colYellowHatch.BackColor,
            ColorShotBlock = pnl_colShot.BackColor,
            ColorBombBlock = pnl_colBombs.BackColor,
            ColorPowerBlock = pnl_colPowerBombs.BackColor,
            ColorMissileBlock = pnl_colMissile.BackColor,
            ColorSuperBlock = pnl_colSuper.BackColor,
            ColorSpeedBlock = pnl_colSpeed.BackColor,
            ColorScrewBlock = pnl_colScrew.BackColor,
            ColorCrumbleBlock = pnl_colCrumble.BackColor,
        };
    }

    private void pnl_color_Click(object sender, EventArgs e)
    {
        if (sender is not Panel p) return;

        ColorDialog dialog = new ColorDialog();
        dialog.Color = p.BackColor;
        dialog.FullOpen = true;
        dialog.SolidColorOnly = true;

        if (dialog.ShowDialog() != DialogResult.OK) return;

        p.BackColor = dialog.Color;
    }

    private void btn_reset_Click(object sender, EventArgs e)
    {
        Colors = new();
        UpdatePanels();
    }
}
