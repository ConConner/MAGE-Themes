using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class RomChange : IPacketContent
{
    public int Offset
    {
        get => offset;
        set
        {
            if (value > 33_554_431) throw new ArgumentException("Offset may not be bigger than 33,554,431");
            offset = value;
        }
    }
    private int offset;

    public byte Length
    {
        get => length;
        set
        {
            if (value > 127) throw new ArgumentException("Length may not be bigger than 127");
            length = value;
        }
    }
    private byte length;

    public byte[] Data
    {
        get => data;
        set
        {
            Length = (byte)value.Length;
            data = value;
        }
    }
    private byte[] data = new byte[0];


    public RomChange() { }
    public RomChange(int offset, byte[] data)
    {
        Offset = offset;
        Data = data;
    }
    public RomChange(int offset, byte data)
    {
        Offset = offset;
        Data = new byte[] { data };
    }


    public static RomChange Deserialize(Stream s)
    {
        RomChange r = new RomChange();

        byte offset1 = (byte)s.ReadByte();
        byte offset2 = (byte)s.ReadByte();
        byte offset3 = (byte)s.ReadByte();
        byte offset4length = (byte)s.ReadByte();

        r.Offset = (offset1 | offset2 << 8 | offset3 << 16 | (offset4length & 1) << 24);
        r.Length = (byte)(offset4length >> 1);

        r.Data = new byte[r.Length];
        for (int i = 0; i < r.Length; i++)
        {
            r.Data[i] = (byte)s.ReadByte();
        }

        return r;
    }

    public byte[] Serialize()
    {
        MemoryStream ms = new MemoryStream();

        ms.WriteByte((byte)(Offset & 0xFF));
        ms.WriteByte((byte)(Offset >> 8 & 0xFF));
        ms.WriteByte((byte)(Offset >> 16 & 0xFF));
        ms.WriteByte((byte)((Offset >> 24 & 0xFF) | (Length << 1)));

        for (int i = 0; i < Length; i++)
        {
            ms.WriteByte(Data[i]);
        }

        return ms.ToArray();
    }
}
