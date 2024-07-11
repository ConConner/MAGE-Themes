using MageNet;
using MageNet.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace mage.Networking;

public static class Session
{
    #region Properties
    public static ServerHost SessionServer { get; set; } = null;
    public static ServerClient SessionClient { get; set; } = null;
    public static bool IsHost { get; set; } = false;
    public static bool SelfHosting { get; set; } = false;
    public static bool InSession { get; set; } = false;
    public static string Username { get; set; }

    public static IPAddress InternalIP { get; set; }
    public static int HostPort { get; set; }
    #endregion

    #region Events
    public static event EventHandler ConnectedToServer;
    #endregion

    #region Methods
    public static void CreateSession(int port)
    {
        HostPort = port;
        InternalIP = Address.GetLocalIPAddress();
        SessionServer = new ServerHost(InternalIP, HostPort);

        InSession = true;
        IsHost = true;

        SessionServer.AcceptClients();
    }

    public static void JoinSession(string username)
    {
        JoinSession(username, InternalIP, HostPort);
    }

    public static void JoinSession(string username, IPAddress address, int port)
    {
        SessionClient = new ServerClient(username);
        SessionClient.UserConnected += SessionClient_UserConnected;

        SessionClient.ConnectToServer(address, port);

        InSession = true;
    }

    #region Event Handling
    private static void SessionClient_UserConnected(object sender, MageNet.EventArguments.UsersConnectedArgument e)
    {
        Debug.WriteLine("[Client]: Connected Users");
        foreach (MageClient c in e.ConnectedUsers)
        {
            Debug.WriteLine(c.Username);
        }
    }
    #endregion

    public static void EndSession()
    {
        SessionServer?.EndSession();
        SessionClient?.Disconnect();
        InSession = false;
        IsHost = false;
        SelfHosting = false;
    }
    #endregion
}
