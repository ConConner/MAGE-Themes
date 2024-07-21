using MageNet.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.IO;

public class PacketReader
{
    /// <summary>
    /// Reads a single packet
    /// </summary>
    /// <param name="ns"></param>
    /// <returns></returns>
    public static async Task<Packet> ReadSinglePacketFromStream(NetworkStream ns)
    {
        //Read and assemble Packet object
        byte[] header = new byte[5];
        int bytesRead = await ReadExactAsync(ns, header, header.Length);
        if (bytesRead == 0) return null;

        PacketType type = (PacketType)header[0];
        int length = BitConverter.ToInt32(header, 1);

        byte[] payload = new byte[length];
        bytesRead = await ReadExactAsync(ns, payload, length);
        if (bytesRead != length) throw new Exception("Packet was incomplete");

        return new Packet(type, payload);
    }

    public static async Task<int> ReadExactAsync(NetworkStream ns, byte[] buffer, int size)
    {
        int totalRead = 0;
        while (totalRead < size)
        {
            int bytesRead = await ns.ReadAsync(buffer, totalRead, size - totalRead);
            if (bytesRead == 0) break; // End of Stream
            totalRead += bytesRead;
        }
        return totalRead;
    }
}