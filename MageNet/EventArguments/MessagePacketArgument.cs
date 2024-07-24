using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.EventArguments;

public class MessagePacketArgument : EventArgs
{
    public MessagePacketArgument() { }
    public MessagePacketArgument(string message)
    {
        Message = message;
    }

    public string Message { get; set; }
}
