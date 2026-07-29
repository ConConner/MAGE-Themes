using mage.Utility;
using System.Collections.Generic;
using System.IO;

namespace mage.Coworking
{
    public enum VanillaRom
    {
        MetroidZeroMissionUsa,
        MetroidFusionUsa,
    }

    /// <summary>
    /// Known-good checksums for the two ROMs MAGE supports, used to verify a
    /// user-supplied "vanilla" baseline before it's used for coworking ROM diffs.
    /// MAGE only supports US ROMs, so only the US release is listed.
    /// No-Intro CRC32 values, cross-checked against multiple independent sources.
    /// </summary>
    public static class VanillaRomCatalog
    {
        private static readonly Dictionary<VanillaRom, uint> KnownCrc32 = new()
        {
            [VanillaRom.MetroidZeroMissionUsa] = 0x5C61A844,
            [VanillaRom.MetroidFusionUsa] = 0x6C75479C,
        };

        public static string DisplayName(VanillaRom rom) => rom switch
        {
            VanillaRom.MetroidZeroMissionUsa => "Metroid: Zero Mission (USA)",
            VanillaRom.MetroidFusionUsa => "Metroid Fusion (USA)",
            _ => rom.ToString(),
        };

        public static uint ExpectedCrc32(VanillaRom rom) => KnownCrc32[rom];

        public static bool Verify(VanillaRom rom, string filePath, out uint actualCrc32)
        {
            using FileStream fs = File.OpenRead(filePath);
            actualCrc32 = Crc32.Compute(fs);
            return actualCrc32 == KnownCrc32[rom];
        }
    }
}
