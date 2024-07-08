using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.IO;

public class PacketBuilder
{
    MemoryStream stream;
    public PacketBuilder()
    {
        stream = new MemoryStream();
    }

    public void WriteType(PacketType type)
    {
        stream.WriteByte((byte)type);
    }

    public void WriteMessage(string message)
    {
        WriteType(PacketType.Message);

        stream.Write(BitConverter.GetBytes(message.Length));
        stream.Write(Encoding.ASCII.GetBytes(message));
    }

    public byte[] GetPacketBytes()
    {
        return stream.ToArray();
    }

    public static explicit operator byte[](PacketBuilder builder) => builder.GetPacketBytes();
    public static explicit operator MemoryStream(PacketBuilder builder) => builder.stream;
}
