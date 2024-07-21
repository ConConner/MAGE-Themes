using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public interface IPacketContent
{
    public byte[] Serialize();
}
