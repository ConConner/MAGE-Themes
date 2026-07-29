using System.Net.Sockets;

namespace mage.Networking;

/// <summary>
/// Client side of the coworking session. Sends actions to the host without a
/// sequence number (host assigns it) and never applies its own action until
/// it comes back through <see cref="RoomActionReceived"/> — this guarantees
/// every peer applies actions in the same order.
/// </summary>
public sealed class CoworkingClient : IDisposable
{
    public event Action<RoomActionMessage>? RoomActionReceived;
    public event Action<List<PresenceEntry>>? PresenceReceived;
    public event Action? Disconnected;

    public Guid ClientId { get; } = Guid.NewGuid();

    private NetworkConnection? connection;

    public void Connect(string host, int port)
    {
        TcpClient tcpClient = new();
        tcpClient.Connect(host, port);
        connection = new NetworkConnection(tcpClient);
        connection.MessageReceived += OnMessageReceived;
        connection.Disconnected += () => Disconnected?.Invoke();
        connection.StartReceiving();
    }

    private void OnMessageReceived(MessageType type, byte[] payload)
    {
        switch (type)
        {
            case MessageType.RoomAction:
                RoomActionReceived?.Invoke(RoomActionMessage.Deserialize(payload));
                break;
            case MessageType.Presence:
                PresenceReceived?.Invoke(PresenceEntry.DeserializeList(payload));
                break;
        }
    }

    public void SendRoomAction(RoomActionMessage message)
    {
        connection?.Send(MessageType.RoomAction, message.Serialize());
    }

    public void SendPresence(string userName, int roomId)
    {
        connection?.Send(MessageType.Presence, PresenceEntry.SerializeList([new PresenceEntry { ClientId = ClientId, UserName = userName, RoomId = roomId }]));
    }

    public void Dispose()
    {
        connection?.Dispose();
    }
}
