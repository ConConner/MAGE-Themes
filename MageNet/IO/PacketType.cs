using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.IO;

public enum PacketType : byte
{
    Ok,
    Error,
    Dummy,
    Username,
    UserList,
    Message,
    TileChange
}