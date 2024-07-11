using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Util;

public static class StreamExtensions
{
    public static void WriteShort(this Stream stream, ushort value)
    {
        stream.WriteByte((byte)(value));
        stream.WriteByte((byte)(value >> 8));
    }

    public static ushort ReadShort(this Stream stream)
    {
        byte low = (byte)stream.ReadByte();
        byte high = (byte)stream.ReadByte();
        return (ushort)(high << 8 | low);
    }

    public static byte[] ReadNumberOfBytes(this Stream s, int count)
    {
        byte[] buffer = new byte[count];
        s.Read(buffer, 0, count);
        return buffer;
    }
}
