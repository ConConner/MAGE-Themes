using System;
using System.Drawing;

namespace mage.Utility;

/// <summary>Conversions between 24-bit <see cref="Color"/> and the 15-bit (5/5/5, bit-15 opaque flag) format used by <see cref="Palette"/>.</summary>
public static class PaletteColor
{
    public static Color Rgb5ToColor(int r, int g, int b) => Color.FromArgb(r * 8, g * 8, b * 8);

    public static void ColorToRgb5(Color c, out int r, out int g, out int b)
    {
        r = c.R / 8;
        g = c.G / 8;
        b = c.B / 8;
    }

    public static ushort Rgb5ToArgb(int r, int g, int b, bool transparent = false)
    {
        ushort argb = (ushort)((r << 10) | (g << 5) | b);
        if (!transparent) argb |= 0x8000;
        return argb;
    }

    public static void ArgbToRgb5(ushort val, out int r, out int g, out int b)
    {
        b = val & 0x1F;
        g = (val >> 5) & 0x1F;
        r = (val >> 10) & 0x1F;
    }

    public static Color ArgbToColor(ushort val)
    {
        ArgbToRgb5(val, out int r, out int g, out int b);
        return Rgb5ToColor(r, g, b);
    }

    public struct Oklab
    {
        public float L, a, b;
        public Oklab(float l, float a, float b) { L = l; this.a = a; this.b = b; }
    }

    public static ushort[] GenerateOklabGradient(ushort startColor, ushort endColor, int steps)
    {
        if (steps < 1) return Array.Empty<ushort>();
        if (steps == 1) return new[] { startColor };

        ushort[] gradient = new ushort[steps];

        // Convert both ends to Oklab
        PaletteColor.Oklab start = PaletteColor.ArgbToOklab(startColor);
        PaletteColor.Oklab end = PaletteColor.ArgbToOklab(endColor);

        for (int i = 0; i < steps; i++)
        {
            float t = (float)i / (steps - 1);

            // Linear interpolation (Lerp) for L, a, and b channels
            float L = start.L + (end.L - start.L) * t;
            float a = start.a + (end.a - start.a) * t;
            float b = start.b + (end.b - start.b) * t;

            // Convert back to 15-bit ushort
            gradient[i] = PaletteColor.OklabToArgb(new PaletteColor.Oklab(L, a, b));
        }

        return gradient;
    }

    // Convert 15-bit ushort Argb to Oklab color space
    public static Oklab ArgbToOklab(ushort val)
    {
        Color c = ArgbToColor(val);

        // Convert to linear sRGB
        float r = SrgbToLinear(c.R / 255f);
        float g = SrgbToLinear(c.G / 255f);
        float b = SrgbToLinear(c.B / 255f);

        // Linear sRGB to LMS
        float l = 0.4122214708f * r + 0.5363325363f * g + 0.0514459929f * b;
        float m = 0.2119034982f * r + 0.6806995451f * g + 0.1073969566f * b;
        float s = 0.0883024619f * r + 0.2817188376f * g + 0.6299787005f * b;

        // Non-linear transformation (Cube root)
        float l_ = (float)Math.Cbrt(l);
        float m_ = (float)Math.Cbrt(m);
        float s_ = (float)Math.Cbrt(s);

        // LMS to Oklab
        return new Oklab(
            0.2104542553f * l_ + 0.7936177850f * m_ - 0.0040720468f * s_,
            1.9779984951f * l_ - 2.4285922050f * m_ + 0.4505937099f * s_,
            0.0259040371f * l_ + 0.7827717662f * m_ - 0.8086757660f * s_
        );
    }

    // Convert Oklab color space back to 15-bit ushort Argb
    public static ushort OklabToArgb(Oklab ok)
    {
        // Oklab to LMS
        float l_ = ok.L + 0.3963377774f * ok.a + 0.2158037573f * ok.b;
        float m_ = ok.L - 0.1055613458f * ok.a - 0.0638541728f * ok.b;
        float s_ = ok.L - 0.0894841775f * ok.a - 1.2914855480f * ok.b;

        // Undo non-linear transformation (Cube)
        float l = l_ * l_ * l_;
        float m = m_ * m_ * m_;
        float s = s_ * s_ * s_;

        // LMS to Linear sRGB
        float r = 4.0767416621f * l - 3.3077115913f * m + 0.2309699292f * s;
        float g = -1.2684380046f * l + 2.6097574011f * m - 0.3413193965f * s;
        float b = -0.0041960863f * l - 0.7034186147f * m + 1.7076147010f * s;

        // Convert back to standard sRGB (0-255)
        int R = (int)Math.Clamp(Math.Round(LinearToSrgb(r) * 255f), 0, 255);
        int G = (int)Math.Clamp(Math.Round(LinearToSrgb(g) * 255f), 0, 255);
        int B = (int)Math.Clamp(Math.Round(LinearToSrgb(b) * 255f), 0, 255);

        // Utilize your existing conversion methods to get the 15-bit output
        ColorToRgb5(Color.FromArgb(R, G, B), out int r5, out int g5, out int b5);
        return Rgb5ToArgb(r5, g5, b5);
    }

    // Gamma correction helpers
    private static float SrgbToLinear(float x)
    {
        return x >= 0.04045f ? (float)Math.Pow((x + 0.055f) / 1.055f, 2.4f) : x / 12.92f;
    }

    private static float LinearToSrgb(float x)
    {
        return x >= 0.0031308f ? 1.055f * (float)Math.Pow(x, 1.0f / 2.4f) - 0.055f : 12.92f * x;
    }
}
