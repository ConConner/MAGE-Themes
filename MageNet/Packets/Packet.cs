using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class Packet
{
    public PacketType Type { get; set; }
    public int Length { get; set; }
    public byte[] Content { get; set; }

    public Packet(PacketType type, IPacketContent content) : this(type, content.Serialize())
    {
    }

    public Packet(PacketType type, byte[] content)
    {
        Type = type;
        Length = content.Length;
        Content = content;
    }


    public byte[] Serialize()
    {
        MemoryStream ms = new MemoryStream();
        ms.WriteByte((byte)Type);
        ms.Write(BitConverter.GetBytes(Length));
        ms.Write(Content);

        return ms.ToArray();
    }

    public byte this[int index]
    {
        get => Content[index];
        set => Content[index] = value;
    }
}
