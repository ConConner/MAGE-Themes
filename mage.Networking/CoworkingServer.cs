using System.Collections.Concurrent;
using System.Net.Sockets;

namespace mage.Networking;

/// <summary>
/// Host-authoritative relay: assigns a monotonic per-room sequence number to
/// each incoming room action and echoes it back to every connected client
/// (including the sender). Dumb relay only — does not apply actions itself
/// beyond sequencing them; the host's own UI applies actions the same way
/// every other client does, by listening for its own echo.
/// </summary>
public sealed class CoworkingServer : IDisposable
{
    public event Action<NetworkConnection>? ClientConnected;
    public event Action<NetworkConnection>? ClientDisconnected;
    public event Action<Exception>? ListenError;

    private readonly List<NetworkConnection> clients = [];
    private readonly object clientsLock = new();
    private readonly ConcurrentDictionary<int, uint> roomSequences = new();
    private readonly ConcurrentDictionary<NetworkConnection, PresenceEntry> presence = new();

    private TcpListener? listener;
    private Thread? acceptThread;
    private volatile bool running;

    public void Start(int port)
    {
        listener = new TcpListener(System.Net.IPAddress.Any, port);
        listener.Start();
        running = true;
        acceptThread = new Thread(AcceptLoop) { IsBackground = true };
        acceptThread.Start();
    }

    private void AcceptLoop()
    {
        try
        {
            while (running)
            {
                TcpClient tcpClient = listener!.AcceptTcpClient();
                NetworkConnection connection = new(tcpClient);
                lock (clientsLock) { clients.Add(connection); }

                connection.MessageReceived += (type, payload) => OnMessageReceived(connection, type, payload);
                connection.Disconnected += () => OnClientDisconnected(connection);
                connection.StartReceiving();

                ClientConnected?.Invoke(connection);
            }
        }
        catch (Exception ex)
        {
            if (running) { ListenError?.Invoke(ex); }
        }
    }

    private void OnMessageReceived(NetworkConnection sender, MessageType type, byte[] payload)
    {
        switch (type)
        {
            case MessageType.RoomAction:
                RoomActionMessage msg = RoomActionMessage.Deserialize(payload);
                msg.SequenceNumber = roomSequences.AddOrUpdate(msg.RoomId, 1, (_, prev) => prev + 1);
                Broadcast(MessageType.RoomAction, msg.Serialize());
                break;

            case MessageType.Presence:
                List<PresenceEntry> update = PresenceEntry.DeserializeList(payload);
                if (update.Count > 0) { presence[sender] = update[0]; }
                BroadcastRoster();
                break;
        }
    }

    private void BroadcastRoster()
    {
        Broadcast(MessageType.Presence, PresenceEntry.SerializeList([.. presence.Values]));
    }

    private void Broadcast(MessageType type, byte[] payload)
    {
        List<NetworkConnection> snapshot;
        lock (clientsLock) { snapshot = [.. clients]; }

        foreach (NetworkConnection connection in snapshot)
        {
            try { connection.Send(type, payload); }
            catch { /* dead connection will surface via its own Disconnected event */ }
        }
    }

    private void OnClientDisconnected(NetworkConnection connection)
    {
        lock (clientsLock) { clients.Remove(connection); }
        presence.TryRemove(connection, out _);
        ClientDisconnected?.Invoke(connection);
        connection.Dispose();
        BroadcastRoster();
    }

    public void Dispose()
    {
        running = false;
        try { listener?.Stop(); } catch { /* already stopped */ }

        lock (clientsLock)
        {
            foreach (NetworkConnection connection in clients) { connection.Dispose(); }
            clients.Clear();
        }
    }
}
