using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.Json.Serialization;

namespace mage.Theming;

public class ColorTheme
{
    const int disabledAlpha = 0x50;

    [JsonIgnore]
    public Color BackgroundColor => Colors["BackgroundColor"];
    [JsonIgnore]
    public Color TextColor => Colors["TextColor"];
    [JsonIgnore]
    public Color TextColorDisabled => Color.FromArgb(disabledAlpha, TextColor);
    [JsonIgnore]
    public Color TextColorHighlight => GetContrastingColor(AccentColor);
    [JsonIgnore]
    public Color PrimaryOutline => Colors["PrimaryOutline"];
    [JsonIgnore]
    public Color PrimaryOutlineDisabled => Color.FromArgb(disabledAlpha, PrimaryOutline);
    [JsonIgnore]
    public Color SecondaryOutline => Colors["SecondaryOutline"];
    [JsonIgnore]
    public Color AccentColor => Colors["AccentColor"];

    [JsonIgnore]
    public bool IsDarkTheme => BackgroundColor.GetRelativeLuminance() < 0.5;

    [JsonInclude]
    public Dictionary<string, Color> Colors { get; set; } = new Dictionary<string, Color>();

    public Color GetContrastingColor(Color color)
    {
        double contrast = 0;
        string contrastColorKey = "AccentColor";
        foreach (KeyValuePair<string, Color> p in Colors)
        {
            if (p.Value.Contrast(color) > contrast)
            {
                contrast = p.Value.Contrast(color);
                contrastColorKey = p.Key;
            }
        }
        return Colors[contrastColorKey];
    }
}
