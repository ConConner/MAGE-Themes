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
}
