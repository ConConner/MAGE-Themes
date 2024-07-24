using MageNet;
using MageNet.EventArguments;
using MageNet.Packets;
using MageNet.Util;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace mage.Networking;

public static class Session
{
    #region Properties
    public static System.Version MageNetVersion { get; } = MageNet.Meta.MageNetVersion;
    public static CollaborationProfile Profile { get; set; } = new CollaborationProfile();
    public static ServerHost SessionServer { get; set; } = null;
    public static ServerClient SessionClient { get; set; } = null;
    public static bool IsHost { get; set; } = false;
    public static bool SelfHosting { get; set; } = false;
    public static bool InSession { get; set; } = false;
    public static string Username { get; set; }

    /// <summary>
    /// List of all Clients connected to the server. Including the own client
    /// </summary>
    public static List<MageClient> ConnectedUsers
    {
        get => connectedUsers;
        set
        {
            connectedUsers = value;
            UserListChanged?.Invoke(null, new UsersConnectedArgument(value));
        }
    }
    private static List<MageClient> connectedUsers;

    /// <summary>
    /// The IP address of the current machine
    /// </summary>
    public static IPAddress InternalIP { get; set; }
    public static int HostPort { get; set; }
    #endregion

    #region Events
    public static event EventHandler ConnectedToServer;
    public static event EventHandler<UsersConnectedArgument> UserListChanged;
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
        BindEvents();

        SessionClient.ConnectToServer(address, port);

        InSession = true;
        ConnectedToServer?.Invoke(null, new EventArgs());
    }

    public static void EndSession()
    {
        SessionServer?.EndSession();
        SessionClient?.Disconnect();
        InSession = false;
        IsHost = false;
        SelfHosting = false;
    }

    public static void BindEvents()
    {
        SessionClient.UserConnected += SessionClient_UserConnected;
        SessionClient.RomChanged += SessionClient_RomChanged;
    }

    #region Event Handling
    private static void SessionClient_UserConnected(object sender, UsersConnectedArgument e)
    {
        Debug.WriteLine("[Client]: Connected Users");
        foreach (MageClient c in e.ConnectedUsers)
        {
            Debug.WriteLine(c.Username);
        }
        ConnectedUsers = e.ConnectedUsers;
    }

    private static void SessionClient_RomChanged(object sender, RomChangeArgument e)
    {
        int offset = e.Change.Offset;
        byte[] data = e.Change.Data;

        ROM.Stream.Seek(offset);
        for (int i = 0; i < data.Length; i++)
        {
            ROM.Stream.Write8(data[i]);
        }
    }
    #endregion

    #endregion
}
