using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace mage
{
    /// <summary>
    /// The Samus animations and palettes known for the loaded game.
    /// Animations are stored as the location of their pointer in the game's animation pointer tables,
    /// so animations that get repointed can still be found.
    /// </summary>
    public static class SamusAnimationList
    {
        public record Animation(string Name, int PointerOffset)
        {
            public override string ToString() => Name;
        }

        public record Group(string Name, List<Animation> Animations)
        {
            public override string ToString() => Name;
        }

        public record PaletteRows(int Offset, int DstRow, int Rows);

        public record PalettePreset(string Name, List<PaletteRows> Rows)
        {
            public override string ToString() => Name;
        }

        private const string PaletteSection = "@Palettes";

        public static List<Group> Groups { get; } = new();
        public static List<PalettePreset> Palettes { get; } = new();

        private static string? loadedFor;

        public static void Load()
        {
            if (loadedFor == Version.GameCode) return;
            loadedFor = Version.GameCode;

            Groups.Clear();
            Palettes.Clear();

            string text = Version.IsMF ? Properties.Resources.MF_U_samusAnims : Properties.Resources.ZM_U_samusAnims;
            using StringReader sr = new StringReader(text);

            string? section = null;
            Group? group = null;
            string? line;
            while ((line = sr.ReadLine()) != null)
            {
                line = line.Trim();
                if (line.Length == 0) continue;

                if (line.StartsWith('[') && line.EndsWith(']'))
                {
                    section = line[1..^1];
                    group = null;
                    if (section == PaletteSection) continue;
                    group = new Group(section, new List<Animation>());
                    Groups.Add(group);
                    continue;
                }

                string[] items = line.Split(';');
                if (items.Length < 2) continue;

                if (section == PaletteSection)
                {
                    List<PaletteRows> rows = new();
                    foreach (string part in items[1].Split(','))
                    {
                        string[] values = part.Split(':');
                        rows.Add(new PaletteRows(ParseHex(values[0]), ParseHex(values[1]), ParseHex(values[2])));
                    }
                    Palettes.Add(new PalettePreset(items[0], rows));
                }
                else group?.Animations.Add(new Animation(items[0], ParseHex(items[1])));
            }
        }

        private static int ParseHex(string value) => int.Parse(value, NumberStyles.HexNumber);
    }
}
