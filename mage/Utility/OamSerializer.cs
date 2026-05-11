using NCalc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static mage.OAM;

namespace mage.Utility;

public static class OamSerializer
{
    private static JsonSerializerOptions SerializerOptions { get; } = new()
    {
        IncludeFields = true,
        WriteIndented = true,
    };

    public static string Serialize(OAM oam) => JsonSerializer.Serialize(oam, SerializerOptions);

    public static OAM? Deserialize(string json)
    {
        try
        {
            OAM? result = JsonSerializer.Deserialize<OAM>(json, SerializerOptions);
            return result;
        }
        catch (Exception e)
        {
            MessageBox.Show("File did not contain OAM Data or it was corrupted.", "Invalid OAM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }

    public static string ToASM(OAM oam, string animationName = "oam")
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine(".align");
        sb.AppendLine($"OAM_{animationName}_Animation:");
        for (int i = 0; i < oam.NumFrames; i++)
        {
            Frame frame = oam.Frames[i];
            sb.AppendLine($"\t.dw @OAM_{animationName}_Frame{Hex.ToPrefixedPaddedString(i)}, {Hex.ToPrefixedPaddedString(frame.duration)}");
        }
        sb.AppendLine("\t.dw 0,0");

        sb.AppendLine();

        for (int i = 0; i < oam.NumFrames; i++)
        {
            Frame frame = oam.Frames[i];
            sb.AppendLine($"@OAM_{animationName}_Frame{Hex.ToPrefixedPaddedString(i)}:");
            sb.AppendLine($"\t.dh {Hex.ToPrefixedPaddedString(frame.numParts)}");

            foreach (Part p in frame.parts)
            {
                ushort[] attributes = p.GetAttributes();
                sb.AppendLine($"\t.dh {Hex.ToPrefixedPaddedString(attributes[0])},{Hex.ToPrefixedPaddedString(attributes[1])},{Hex.ToPrefixedPaddedString(attributes[2])}");
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }


    public static OAM? FromASM(string asmText)
    {
        var lines = new List<string>();
        foreach (var raw in asmText.Split('\n'))
        {
            string cleaned = CleanLine(raw);
            if (!string.IsNullOrWhiteSpace(cleaned))
                lines.Add(cleaned);
        }

        // Parse frame table
        var frameEntries = new List<(string label, int duration)>();

        var frameRe = new Regex(@"\.dw\s+(@?[A-Za-z_]\w+)\s*,\s*(0x[0-9A-Fa-f]+|\d+)");

        foreach (var line in lines)
        {
            var m = frameRe.Match(line);
            if (m.Success)
            {
                string label = m.Groups[1].Value;

                int duration = Hex.ToIntNcalc(m.Groups[2].Value);
                frameEntries.Add((label, duration));
            }
        }

        var frames = new List<Frame>();

        foreach (var (label, duration) in frameEntries)
        {
            int idx = lines.FindIndex(l => l.StartsWith(label + ":"));
            if (idx == -1)
                continue;

            int numParts = Hex.ToIntNcalc(lines[idx + 1].Replace(".dh", "").Trim());

            var parts = new List<Part>();
            for (int i = 0; i < numParts; i++)
            {
                var (y, x, t) = ParseDhTriplet(lines[idx + 2 + i]);
                parts.Add(DecodeOam(y, x, t));
            }

            frames.Add(new Frame
            {
                duration = duration,
                numParts = numParts,
                parts = parts
            });
        }

        return new OAM
        {
            NumFrames = frames.Count,
            Frames = frames
        };


    }

    private static Part DecodeOam(int y, int x, int tile)
    {
        int yPos = y & 0xFF;
        if (yPos >= 128)
            yPos -= 256;

        int shape = (y >> 14) & 0x3;

        int xPos = x & 0x1FF;
        if (xPos >= 256)
            xPos -= 512;

        int hflip = (x >> 12) & 1;
        int size = (x >> 14) & 0x3;

        int tileNum = tile & 0x3FF;
        int palRow = (tile >> 12) & 0xF;

        return new Part
        {
            xPos = xPos,
            yPos = yPos,
            shape = shape,
            size = size,
            flip = hflip,
            tileNum = tileNum,
            palRow = palRow
        };
    }

    private static string CleanLine(string line)
    {
        int commentIndex = line.IndexOf(';');
        if (commentIndex >= 0)
            line = line[..commentIndex];

        line = line.Replace("halfword", "dh")
                   .Replace("word", "dw")
                   .Trim();

        return line;
    }

    private static (int, int, int) ParseDhTriplet(string line)
    {
        line = line.Replace(".dh", "").Trim();
        var parts = line.Split(',');

        if (parts.Length != 3)
            throw new Exception($"Invalid .dh triplet: {line}");

        int a = Hex.ToIntNcalc(parts[0].Trim());
        int b = Hex.ToIntNcalc(parts[1].Trim());
        int c = Hex.ToIntNcalc(parts[2].Trim());

        return (a, b, c);
    }

}
