using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Theming
{
    public static class ColorOperations
    {
        public static string ToHexString(this Color c) => $"#{c.R:X2}{c.G:X2}{c.B:X2}";

        public static float GetValue(this Color c)
        {
            int max = Math.Max(c.R, Math.Max(c.G, c.B));
            return max / 255f;
        }

        public static double GetRelativeLuminance(this Color c)
        {
            double r = c.R / 255.0;
            double g = c.G / 255.0;
            double b = c.B / 255.0;

            // Calculate gamma-corrected RGB values
            double gammaR = (r <= 0.03928) ? r / 12.92 : Math.Pow((r + 0.055) / 1.055, 2.4);
            double gammaG = (g <= 0.03928) ? g / 12.92 : Math.Pow((g + 0.055) / 1.055, 2.4);
            double gammaB = (b <= 0.03928) ? b / 12.92 : Math.Pow((b + 0.055) / 1.055, 2.4);

            // Calculate relative luminance
            double luminance = 0.2126 * gammaR + 0.7152 * gammaG + 0.0722 * gammaB;
            return luminance;
        }

        public static double Contrast(this Color c1, Color c2)
        {
            double luminance1 = c1.GetRelativeLuminance();
            double luminance2 = c2.GetRelativeLuminance();

            // The contrast ratio formula: (L1 + 0.05) / (L2 + 0.05), where L1 is the lighter color's luminance
            double contrastRatio = (Math.Max(luminance1, luminance2) + 0.05) / (Math.Min(luminance1, luminance2) + 0.05);

            return contrastRatio;
        }

        public static Color HslToRgb(double h, double s, double l)
        {
            double r, g, b;
            if (Math.Abs(s) < 1e-6)
                r = g = b = l;
            else
            {
                double q = l < 0.5 ? l * (1 + s) : l + s - l * s;
                double p = 2 * l - q;
                r = HueToRgb(p, q, h + 120);
                g = HueToRgb(p, q, h);
                b = HueToRgb(p, q, h - 120);
            }
            return Color.FromArgb(
                (int)(r * 255),
                (int)(g * 255),
                (int)(b * 255));
        }

        public static double HueToRgb(double p, double q, double t)
        {
            if (t < 0) t += 360;
            if (t > 360) t -= 360;
            if (t < 60) return p + (q - p) * t / 60;
            if (t < 180) return q;
            if (t < 240) return p + (q - p) * (240 - t) / 60;
            return p;
        }

        public static (double h, double s, double l) RgbToHsl(Color c)
        {
            double r = c.R / 255.0, g = c.G / 255.0, b = c.B / 255.0;
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double h = 0, s, l = (max + min) / 2;
            if (Math.Abs(max - min) < 1e-6) { s = 0; }
            else
            {
                double d = max - min;
                s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
                if (max == r) h = (g - b) / d + (g < b ? 6 : 0);
                else if (max == g) h = (b - r) / d + 2;
                else h = (r - g) / d + 4;
                h *= 60;
            }
            return (h, s, l);
        }

        public static Color ShiftHue(Color c, float delta)
        {
            (double h, double s, double l) = RgbToHsl(c);
            h = (h + delta) % 360; if (h < 0) h += 360;
            return HslToRgb(h, s, l);
        }

        public static Color ShiftLightness(Color c, float delta)   // delta in [-1,1]
        {
            (double h, double s, double l) = RgbToHsl(c);
            l = Math.Clamp(l + delta, 0, 1);
            return HslToRgb(h, s, l);
        }
    }
}
