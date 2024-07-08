using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class TileChange
{
    public byte Area { get; set; }
    public byte Room { get; set; }
    public ushort X { get; set; }
    public ushort Y { get; set; }
    public ushort TileID { get; set; }
}
