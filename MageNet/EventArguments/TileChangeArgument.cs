using MageNet.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.EventArguments;

public class TileChangeArgument : EventArgs
{
    public TileChangeArgument() { }
    public TileChangeArgument(TileChange tileChange)
    {
        Change = tileChange;
    }

    public TileChange Change { get; set; }
}
