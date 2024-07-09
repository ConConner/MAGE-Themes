using MageNet.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class TileChange : IPacket
{
    public byte Area { get; set; }
    public byte Room { get; set; }
    public ushort X { get; set; }
    public ushort Y { get; set; }
    public ushort TileID { get; set; }

    public IPacket Deserialize(byte[] data)
    {
        MemoryStream stream = new MemoryStream(data);
        return new TileChange()
        {
            Area = (byte)stream.ReadByte(),
            Room = (byte)stream.ReadByte(),
            X = stream.ReadShort(),
            Y = stream.ReadShort(),
            TileID = stream.ReadShort(),
        };
    }
    public byte[] Serialize()
    {
        MemoryStream ms = new MemoryStream();
        ms.WriteByte(Area);
        ms.WriteByte(Room);
        ms.WriteShort(X);
        ms.WriteShort(Y);
        ms.WriteShort(TileID);
        return ms.ToArray();
    }
}
