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

    private void PaletteTransformationDialog_Shown(object? sender, EventArgs e)
    {
        handleTabSwitch();
    }

    private void genericTransformation(Func<ushort, ushort> function)
    {
        for (int x = 0; x < _selectedWidth; x++)
            for (int y = 0; y < _selectedHeight; y++)
            {
                ushort old = _selectedColors[x, y];
                ushort val = function(old);
                _resultColors[x, y] = val;
            }
    }

    private void tabControl_TabIndexChanged(object sender, EventArgs e) => handleTabSwitch();

    // Tabs
    private void handleTabSwitch()
    {
        TabPage selectedTab = tabControl.TabPages[tabControl.TabIndex];
        if (selectedTab.Name == "tab_gradient")
        {
            generateGradient(radio_gradientVertical.Checked);
        }
    }

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
