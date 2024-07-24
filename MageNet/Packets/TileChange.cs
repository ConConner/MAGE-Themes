using MageNet.Data;
using MageNet.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class TileChange : IPacketContent
{
    public byte Area { get; set; }
    public byte Room { get; set; }
    public List<BlockChange> Blocks { get; set; }

    public TileChange() { }
    public TileChange(byte area, byte room, List<BlockChange> blocks)
    {
        Area = area;
        Room = room;
        Blocks = blocks;
    }

    public static TileChange Deserialize(MemoryStream ms)
    {
        TileChange tc = new TileChange();

        tc.Area = (byte)ms.ReadByte();
        tc.Room = (byte)ms.ReadByte();
        ushort length = ms.ReadShort();

        tc.Blocks = new();
        for (int i = 0; i < length; i++)
        {
            BlockChange b = new BlockChange();
            b.Location = new Point(ms.ReadByte(), ms.ReadByte());
            b.BG0 = ms.ReadShort();
            b.BG1 = ms.ReadShort();
            b.BG2 = ms.ReadShort();
            b.Clip = ms.ReadShort();

            tc.Blocks.Add(b);
        }

        return tc;
    }
    public byte[] Serialize()
    {
        MemoryStream ms = new MemoryStream();

        ms.WriteByte(Area);
        ms.WriteByte(Room);
        ms.WriteShort((ushort)Blocks.Count);
        //Writing each block
        foreach (BlockChange b in Blocks)
        {
            ms.WriteByte((byte)b.Location.X);
            ms.WriteByte((byte)b.Location.Y);

            ms.WriteShort(b.BG0);
            ms.WriteShort(b.BG1);
            ms.WriteShort(b.BG2);
            ms.WriteShort(b.Clip);
        }

        return ms.ToArray();
    }
}
