using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.EventArguments;

public class UsersConnectedArgument : EventArgs
{
    public List<MageClient> ConnectedUsers { get; set; }
    public MageClient LatestConnect { get; set; } = null;
}
