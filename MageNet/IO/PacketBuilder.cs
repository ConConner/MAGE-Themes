using MageNet.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.IO;

public class PacketBuilder
{
    public MemoryStream Stream { get; }
    public PacketBuilder()
    {
        Stream = new MemoryStream();
    }

    public void WriteType(PacketType type)
    {
        Stream.WriteByte((byte)type);
    }

    public void AddPacket(PacketType type, IPacket packet)
    {
        WriteType(type);
        byte[] data = packet.Serialize();
        Stream.Write(BitConverter.GetBytes(data.Length));
        Stream.Write(data);
    }

    public byte[] GetPacketBytes()
    {
        return Stream.ToArray();
    }


    //Operators
    public static explicit operator byte[](PacketBuilder builder) => builder.GetPacketBytes();
}
