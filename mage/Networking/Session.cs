using MageNet;
using MageNet.Util;
using System;
using System.Collections.Generic;
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

    public static IPAddress InternalIP { get; set; }
    public static int HostPort { get; set; }
    #endregion

    public static void CreateSession(int port)
    {
        HostPort = port;
        InternalIP = Address.GetLocalIPAddress();
        SessionServer = new ServerHost(InternalIP, HostPort);

        InSession = true;
        IsHost = true;

        SessionServer.AcceptClients();
    }

    public static void JoinSession()
    {
        SessionClient = new ServerClient();
        SessionClient.ConnectToServer(InternalIP, HostPort);
    }

    public static void JoinSession(IPAddress address, int port)
    {
        SessionClient = new ServerClient();
        SessionClient.ConnectToServer(address, port);
    }

    public static void EndSession()
    {
        SessionServer?.EndSession();
        SessionClient?.Disconnect();
        InSession = false;
        IsHost = false;
        SelfHosting = false;
    }
}
