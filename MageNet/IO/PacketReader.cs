using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.IO;

public class PacketReader : BinaryReader
{
    public Stream Stream { get; private set; }
    public PacketReader(Stream ns) : base(ns)
    {
        this.Stream = ns;
    }

    public static async Task<byte[]> ReadPacketFromStream(NetworkStream ns)
    {
        byte[] buffer = new byte[8192];
        int bytesRead;

        bytesRead = await ns.ReadAsync(buffer);
        return buffer[0..bytesRead];
    }
}
