using System;
using System.IO;
using mage.Networking;

namespace mage.Actions.RoomEditor;

/// <summary>
/// Bridges the room-editor Action system to the mage.Networking transport.
/// Host runs a CoworkingServer plus a loopback CoworkingClient, so the host's
/// own UI goes through the exact same echo-wait path as every other peer.
/// All events fire on a background thread — callers must marshal to the UI
/// thread themselves (e.g. via Control.BeginInvoke).
/// </summary>
public sealed class RoomCoworkingSession : IDisposable
{
    public event Action<int, Action, bool>? ActionReceived;
    public event Action<System.Collections.Generic.List<PresenceEntry>>? PresenceReceived;
    public event System.Action? PeerDisconnected;

    public bool IsHost { get; }
    public Guid ClientId => client.ClientId;

    private readonly CoworkingServer? server;
    private readonly CoworkingClient client;

    private RoomCoworkingSession(bool isHost, CoworkingServer? server)
    {
        IsHost = isHost;
        this.server = server;
        client = new CoworkingClient();
        client.RoomActionReceived += OnRoomActionReceived;
        client.PresenceReceived += roster => PresenceReceived?.Invoke(roster);
        client.Disconnected += () => PeerDisconnected?.Invoke();
    }

    public static RoomCoworkingSession Host(int port)
    {
        CoworkingServer server = new();
        server.Start(port);

        RoomCoworkingSession session = new(true, server);
        session.client.Connect("127.0.0.1", port);
        return session;
    }

    public static RoomCoworkingSession Join(string hostAddress, int port)
    {
        RoomCoworkingSession session = new(false, null);
        session.client.Connect(hostAddress, port);
        return session;
    }

    public static int MakeRoomId(byte areaId, byte roomId) => (areaId << 8) | roomId;

    public void SendPresence(string userName, int roomId) => client.SendPresence(userName, roomId);

    public void SendAction(int roomId, Action action, bool isUndo)
    {
        using MemoryStream ms = new();
        using (BinaryWriter writer = new(ms, System.Text.Encoding.UTF8, leaveOpen: true)) { action.Serialize(writer); }

        RoomActionMessage msg = new()
        {
            RoomId = roomId,
            Type = (byte)action.Type,
            Payload = ms.ToArray(),
            IsUndo = isUndo,
        };
        client.SendRoomAction(msg);
    }

    private void OnRoomActionReceived(RoomActionMessage msg)
    {
        using MemoryStream ms = new(msg.Payload);
        using BinaryReader reader = new(ms);
        Action action = ActionFactory.Deserialize((ActionType)msg.Type, reader);
        ActionReceived?.Invoke(msg.RoomId, action, msg.IsUndo);
    }

    public void Dispose()
    {
        client.Dispose();
        server?.Dispose();
    }
}
