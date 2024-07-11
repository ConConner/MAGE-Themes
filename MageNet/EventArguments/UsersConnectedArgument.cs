using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.EventArguments;

public class UsersConnectedArgument : EventArgs
{
    public UsersConnectedArgument() {}
    public UsersConnectedArgument(List<MageClient> clients, MageClient latestConnect)
    {
        ConnectedUsers = clients;
        LatestConnect = latestConnect;
    }
    public UsersConnectedArgument(List<MageClient> clients)
    {
        ConnectedUsers = clients;
        LatestConnect = clients.Last();
    }

    public List<MageClient> ConnectedUsers { get; set; } = new();
    public MageClient LatestConnect { get; set; } = null;
}
