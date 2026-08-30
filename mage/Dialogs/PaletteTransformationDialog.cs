using mage.Theming;
using mage.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace mage.Dialogs;

public partial class PaletteTransformationDialog : Form
{
    private bool locked = false;
    private ushort[,] _selectedColors;
    private ushort[,] _resultColors;

    public ushort[,] TransformedColors => _resultColors;
    private bool displayPreview
    {
        get => field;
        set
        {
            if (field == value) return;
            field = value;
            OnPreviewChanged();
        }
    } = true;

    private int _selectedWidth => _selectedColors.GetLength(0);
    private int _selectedHeight => _selectedColors.GetLength(1);

    public string ActionText { get; private set; } = "Color Shift";

    public event Action<ushort[,], bool>? PreviewChanged;

    private void OnPreviewChanged()
    {
        PreviewChanged?.Invoke(_resultColors, displayPreview);
    }



    public PaletteTransformationDialog(ushort[,] selectedColors)
    {
        InitializeComponent();
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        _selectedColors = selectedColors;
        _resultColors = (ushort[,])selectedColors.Clone();

        this.Shown += PaletteTransformationDialog_Shown;
    }

    private void PaletteTransformationDialog_Shown(object? sender, EventArgs e) => handleTabSwitch();



    private void genericTransformation(ushort[,] source, ushort[,] dest, Func<ushort, ushort> function)
    {
        for (int x = 0; x < _selectedWidth; x++)
            for (int y = 0; y < _selectedHeight; y++)
            {
                ushort old = source[x, y];
                ushort val = function(old);
                dest[x, y] = val;
            }
    }

    // Tabs
    private void handleTabSwitch()
    {
        TabPage selectedTab = tabControl.TabPages[tabControl.SelectedIndex];
        if (selectedTab.Name == "tab_gradient")
        {
            bool vertical = radio_gradientVertical.Checked;
            generateGradient(vertical);

        }
        else if (selectedTab.Name == "tab_hue")
        {
            doShiftTransform();
            ActionText = "Color Shift";
        }
    }
    private void tabControl_TabIndexChanged(object sender, EventArgs e) => handleTabSwitch();

    #region Gradient
    private void radio_gradientVertical_CheckedChanged(object sender, EventArgs e)
    {
        RadioButton? rb = sender as RadioButton;
        if (rb is null || !rb.Checked) return;

        generateGradient(radio_gradientVertical.Checked);
    }

    private void generateGradient(bool vertical)
    {
        if (vertical) verticalGradient();
        else horizontalGradient();
        OnPreviewChanged();
        ActionText = (vertical ? "Vertical" : "Horizontal") + " Gradient";
    }

    private void horizontalGradient()
    {
        for (int y = 0; y < _selectedHeight; y++)
        {
            ushort col1 = _selectedColors[0, y];
            ushort col2 = _selectedColors[_selectedWidth - 1, y];
            int steps = _selectedWidth;
            ushort[] gradient = PaletteColor.GenerateOklabGradient(col1, col2, steps);
            for (int i = 0; i < steps; i++) _resultColors[i, y] = gradient[i];
        }
    }

    private void verticalGradient()
    {
        for (int x = 0; x < _selectedWidth; x++)
        {
            ushort col1 = _selectedColors[x, 0];
            ushort col2 = _selectedColors[x, _selectedHeight - 1];
            int steps = _selectedHeight;
            ushort[] gradient = PaletteColor.GenerateOklabGradient(col1, col2, steps);
            for (int i = 0; i < steps; i++) _resultColors[x, i] = gradient[i];
        }
    }
    #endregion

    #region Hue
    public static ushort ShiftColorOklch(ushort color, float hueDegrees = 0f, float chromaShift = 0f, float lightnessShift = 0f)
    {
        if (hueDegrees == 0 && chromaShift == 0 && lightnessShift == 0) return color;

        PaletteColor.Oklab oklab = PaletteColor.ArgbToOklab(color);

        // 1. Shift Lightness
        oklab.L = (float)Math.Clamp(oklab.L + lightnessShift, 0.0, 1.0);

        // 2. Shift Hue and Chroma
        if (hueDegrees != 0 || chromaShift != 0)
        {
            double chroma = Math.Sqrt(oklab.a * oklab.a + oklab.b * oklab.b);
            double hue = Math.Atan2(oklab.b, oklab.a);

            // Apply shifts
            chroma = Math.Max(0.0, chroma + chromaShift);
            hue += hueDegrees * (Math.PI / 180.0);

            // Reconstruct rectangular coordinates
            oklab.a = (float)(chroma * Math.Cos(hue));
            oklab.b = (float)(chroma * Math.Sin(hue));
        }

        return PaletteColor.OklabToArgb(oklab);
    }

    private ushort applyColorShift(ushort color)
    {
        float hueDegrees = trackBar_hue.Value;
        float chromaShift = trackBar_chroma.Value / 250f;
        float lightnessShift = trackBar_lightness.Value / 100f;
        return ShiftColorOklch(color, hueDegrees, chromaShift, lightnessShift);
    }

    private void doShiftTransform()
    {
        genericTransformation(_selectedColors, _resultColors, applyColorShift);
        OnPreviewChanged();
    }

    private void trackBar_lightness_ValueChanged(object sender, EventArgs e)
    {
        if (locked) return;

        locked = true;
        doShiftTransform();

        num_hue.Value = trackBar_hue.Value;
        num_chroma.Value = trackBar_chroma.Value;
        num_lightness.Value = trackBar_lightness.Value;
        updateResetButtons();

        locked = false;
    }

    private void num_hue_ValueChanged(object sender, EventArgs e)
    {
        if (locked) return;

        locked = true;

        trackBar_hue.Value = (int)num_hue.Value;
        trackBar_chroma.Value = (int)num_chroma.Value;
        trackBar_lightness.Value = (int)num_lightness.Value;

        doShiftTransform();
        updateResetButtons();

        locked = false;
    }

    private void updateResetButtons()
    {
        button_resetHue.Enabled = num_hue.Value != 0;
        button_resetChroma.Enabled = num_chroma.Value != 0;
        button_resetLightness.Enabled = num_lightness.Value != 0;
    }

    private void button_resetHue_Click(object sender, EventArgs e) => num_hue.Value = 0;
    private void button_resetChroma_Click(object sender, EventArgs e) => num_chroma.Value = 0;
    private void button_resetLightness_Click(object sender, EventArgs e) => num_lightness.Value = 0;
    #endregion

    #region generic events
    private void checkBox_preview_CheckedChanged(object sender, EventArgs e) => displayPreview = checkBox_preview.Checked;

    private void button_apply_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.OK;
        Close();
    }

    private void button_cancel_Click(object sender, EventArgs e)
    {
        DialogResult = DialogResult.Cancel;
        Close();
    }
    #endregion

}
