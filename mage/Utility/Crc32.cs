using System.IO;

namespace mage.Utility
{
    /// <summary>Standard CRC-32 (IEEE 802.3 / zlib / PKZIP polynomial) - what No-Intro/Redump checksums use.</summary>
    public static class Crc32
    {
        private static readonly uint[] Table = BuildTable();

        private static uint[] BuildTable()
        {
            uint[] table = new uint[256];
            for (uint i = 0; i < 256; i++)
            {
                uint c = i;
                for (int k = 0; k < 8; k++)
                {
                    c = (c & 1) != 0 ? 0xEDB88320 ^ (c >> 1) : c >> 1;
                }
                table[i] = c;
            }
            return table;
        }

        public static uint Compute(Stream stream)
        {
            uint crc = 0xFFFFFFFF;
            byte[] buffer = new byte[81920];
            int read;
            while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
            {
                for (int i = 0; i < read; i++)
                {
                    crc = Table[(crc ^ buffer[i]) & 0xFF] ^ (crc >> 8);
                }
            }
            return crc ^ 0xFFFFFFFF;
        }

        public static uint Compute(byte[] data)
        {
            using MemoryStream ms = new(data);
            return Compute(ms);
        }
    }
}
