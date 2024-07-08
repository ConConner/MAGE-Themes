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

    public string ReadMessage()
    {
        byte[] msgBuffer;

        var length = ReadInt32();
        msgBuffer = new byte[length];

        Stream.Read(msgBuffer, 0, length);

        var msg = Encoding.ASCII.GetString(msgBuffer);
        return msg;
    }
}
