using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public interface IPacket
{
    public byte[] Serialize();
    public IPacket Deserialize(byte[] data);
}
