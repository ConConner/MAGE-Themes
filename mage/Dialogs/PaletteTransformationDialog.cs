using mage.Editors.NewEditors;
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

    private Color targetTint
    {
        get => field;
        set
        {
            if (field == value) return;
            field = value;
            pnl_colorPicker.BackColor = value;
        }
    }

    public string ActionText { get; private set; } = "Color Shift";

    public event Action<ushort[,], bool>? PreviewChanged;

    private void OnPreviewChanged()
    {
        PreviewChanged?.Invoke(_resultColors, displayPreview);
    }



    public PaletteTransformationDialog(ushort[,] selectedColors, Color targetTint)
    {
        InitializeComponent();
        ThemeSwitcher.ChangeTheme(Controls, this);
        ThemeSwitcher.InjectPaintOverrides(Controls);

        _selectedColors = selectedColors;
        _resultColors = (ushort[,])selectedColors.Clone();
        this.targetTint = targetTint;

        populateComboboxes();
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

        if (selectedTab.Name == "tab_gradient") generateGradient(radio_gradientVertical.Checked);
        else if (selectedTab.Name == "tab_hue") doShiftTransform();
        else if (selectedTab.Name == "tab_inversion") doInvertTransform();
        else if (selectedTab.Name == "tab_swap") doSwapTransform();
        else if (selectedTab.Name == "tab_posterize") doPosterizeTransform();
        else if (selectedTab.Name == "tab_tint") doConfigurableTint();
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
        ActionText = "Color Shift";
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

    #region Inversion
    private ushort configurableInvert(ushort color, bool invR, bool invG, bool invB, bool preserveLightness)
    {
        if (preserveLightness)
        {
            // Use your Oklab helpers to invert color (a, b) but keep lightness (L)
            var ok = PaletteColor.ArgbToOklab(color);
            ok.a = -ok.a;
            ok.b = -ok.b;
            return PaletteColor.OklabToArgb(ok);
        }

        PaletteColor.ArgbToRgb5(color, out int r, out int g, out int b);

        if (invR) r = 31 - r;
        if (invG) g = 31 - g;
        if (invB) b = 31 - b;

        return PaletteColor.Rgb5ToArgb(r, g, b, transparent: (color & 0x8000) == 0);
    }

    private ushort applyConfigurableInvert(ushort color)
    {
        bool invR = check_invertR.Checked;
        bool invG = check_invertG.Checked;
        bool invB = check_invertB.Checked;
        bool preserve = check_inversionPreserveLightness.Checked;
        return configurableInvert(color, invR, invG, invB, preserve);
    }

    private void doInvertTransform()
    {
        ActionText = "Invert Channels";
        genericTransformation(_selectedColors, _resultColors, applyConfigurableInvert);
        OnPreviewChanged();
    }

    private void check_invertR_CheckedChanged(object sender, EventArgs e)
    {
        doInvertTransform();
        pnl_inversionChannels.Enabled = !check_inversionPreserveLightness.Checked;
    }
    #endregion

    #region Channel Swap
    private void populateComboboxes()
    {
        cbb_swapR.DataSource = Enum.GetValues<Channel>();
        cbb_swapG.DataSource = Enum.GetValues<Channel>();
        cbb_swapB.DataSource = Enum.GetValues<Channel>();

        locked = true;
        cbb_swapR.SelectedItem = Channel.Blue;
        cbb_swapG.SelectedItem = Channel.Green;
        cbb_swapB.SelectedItem = Channel.Red;
        locked = false;
    }

    private enum Channel { Red, Green, Blue }

    private ushort configurableSwap(ushort color, Channel outR, Channel outG, Channel outB)
    {
        PaletteColor.ArgbToRgb5(color, out int r, out int g, out int b);

        // Helper to fetch the requested channel value
        int getChannel(Channel c) => c == Channel.Red ? r : (c == Channel.Green ? g : b);

        int newR = getChannel(outR);
        int newG = getChannel(outG);
        int newB = getChannel(outB);

        return PaletteColor.Rgb5ToArgb(newR, newG, newB, transparent: (color & 0x8000) == 0);
    }

    private ushort applyConfigurableSwap(ushort color)
    {
        if (cbb_swapR.SelectedItem is not Channel outR) return 0;
        if (cbb_swapG.SelectedItem is not Channel outG) return 0;
        if (cbb_swapB.SelectedItem is not Channel outB) return 0;
        return configurableSwap(color, outR, outG, outB);
    }

    private void doSwapTransform()
    {
        ActionText = "Swap Color Channels";
        genericTransformation(_selectedColors, _resultColors, applyConfigurableSwap);
        OnPreviewChanged();
    }

    private void cbb_swapR_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (locked) return;
        doSwapTransform();
    }
    #endregion

    #region Posterization
    private ushort configurablePosterize(ushort color, int bitsToKeep)
    {
        if (bitsToKeep >= 5) return color;

        int shift = 5 - bitsToKeep; // How many bottom bits to zero out

        PaletteColor.ArgbToRgb5(color, out int r, out int g, out int b);

        // Shift down to lose data, then shift back up
        r = (r >> shift) << shift;
        g = (g >> shift) << shift;
        b = (b >> shift) << shift;

        return PaletteColor.Rgb5ToArgb(r, g, b, transparent: (color & 0x8000) == 0);
    }

    private ushort applyConfigurablePosterize(ushort color)
    {
        int bitsToKeep = trackBar_posterize.Value;
        return configurablePosterize(color, bitsToKeep);
    }

    private void doPosterizeTransform()
    {
        ActionText = "Posterize";
        genericTransformation(_selectedColors, _resultColors, applyConfigurablePosterize);
        OnPreviewChanged();
    }

    private void trackBar_posterize_ValueChanged(object sender, EventArgs e)
    {
        if (locked) return;
        locked = true;
        num_posterize.Value = trackBar_posterize.Value;
        locked = false;
        updatePosterizeResetButton();
        doPosterizeTransform();
    }

    private void num_posterize_ValueChanged(object sender, EventArgs e)
    {
        if (locked) return;
        locked = true;
        trackBar_posterize.Value = (int)num_posterize.Value;
        locked = false;
        updateResetButtons();
        doPosterizeTransform();
    }

    private void button_posterizeReset_Click(object sender, EventArgs e) => num_posterize.Value = 5;
    private void updatePosterizeResetButton() => button_posterizeReset.Enabled = num_posterize.Value != 5;
    #endregion

    #region Tinting
    private ushort ConfigurableTint(ushort color, Color targetTint, float blendStrength, bool useOklab)
    {
        if (blendStrength <= 0f) return color;

        // Convert target tint down to Rgb5, then back up to ensure it fits the color space limits
        PaletteColor.ColorToRgb5(targetTint, out int tr, out int tg, out int tb);
        ushort tintArgb = PaletteColor.Rgb5ToArgb(tr, tg, tb);

        if (useOklab)
        {
            var okBase = PaletteColor.ArgbToOklab(color);
            var okTint = PaletteColor.ArgbToOklab(tintArgb);

            // Lerp in Oklab space for natural, non-muddy color blending
            return PaletteColor.OklabToArgb(new PaletteColor.Oklab(
                okBase.L + (okTint.L - okBase.L) * blendStrength,
                okBase.a + (okTint.a - okBase.a) * blendStrength,
                okBase.b + (okTint.b - okBase.b) * blendStrength
            ));
        }
        else
        {
            // Simple RGB lerping
            PaletteColor.ArgbToRgb5(color, out int r, out int g, out int b);

            int newR = (int)(r + (tr - r) * blendStrength);
            int newG = (int)(g + (tg - g) * blendStrength);
            int newB = (int)(b + (tb - b) * blendStrength);

            return PaletteColor.Rgb5ToArgb(newR, newG, newB, transparent: (color & 0x8000) == 0);
        }
    }

    private ushort applyConfigurableTint(ushort color)
    {
        float blendStrength = trackBar_tintBlend.Value / 100f;
        bool useOklab = radio_tintBlendOklab.Checked;
        return ConfigurableTint(color, targetTint, blendStrength, useOklab);
    }

    private void doConfigurableTint()
    {
        ActionText = "Tint";
        genericTransformation(_selectedColors, _resultColors, applyConfigurableTint);
        OnPreviewChanged();
    }

    private void pnl_colorPicker_Click(object sender, EventArgs e)
    {
        using FormColorPicker picker = new(PaletteColor.ColorToArgb(targetTint));
        if (picker.ShowDialog() != DialogResult.OK) return;

        targetTint = PaletteColor.ArgbToColor(picker.SelectedArgb);
        doConfigurableTint();
    }

    private void trackBar_tintBlend_ValueChanged(object sender, EventArgs e)
    {
        if (locked) return;
        locked = true;
        num_tintBlend.Value = trackBar_tintBlend.Value;
        locked = false;
        doConfigurableTint();
        updateTintBlendResetButton();
    }

    private void num_tintBlend_ValueChanged(object sender, EventArgs e)
    {
        if (locked) return;
        locked = true;
        trackBar_tintBlend.Value = (int)num_tintBlend.Value;
        locked = false;
        doConfigurableTint();
        updateTintBlendResetButton();
    }


    private void radio_tintBlendRgb_CheckedChanged(object sender, EventArgs e)
    {
        if (sender is not RadioButton rb) return;
        if (!rb.Checked) return;
        doConfigurableTint();
    }

    private void button_tintBlendReset_Click(object sender, EventArgs e) => num_tintBlend.Value = 50;
    private void updateTintBlendResetButton() => button_tintBlendReset.Enabled = trackBar_tintBlend.Value != 50;
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
