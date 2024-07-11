using MageNet.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.EventArguments;

public class RomChangeArgument : EventArgs
{
    public RomChangeArgument() { }
    public RomChangeArgument(RomChange change)
    {
        Change = change;
    }

    public RomChange Change { get; set; }
}
