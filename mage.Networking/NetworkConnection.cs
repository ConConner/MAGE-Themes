using System.Net.Sockets;

namespace mage.Networking;

/// <summary>
/// Wraps a single TCP socket with length-prefixed message framing.
/// MessageReceived/Disconnected fire on a background read thread — callers
/// (the WinForms UI) must marshal back to the UI thread themselves.
/// </summary>
public sealed class NetworkConnection : IDisposable
{
    public event Action<MessageType, byte[]>? MessageReceived;
    public event Action? Disconnected;

    private readonly TcpClient client;
    private readonly NetworkStream stream;
    private readonly object writeLock = new();
    private Thread? readThread;
    private volatile bool running;

    public NetworkConnection(TcpClient client)
    {
        this.client = client;
        client.NoDelay = true;
        stream = client.GetStream();
    }

    public void StartReceiving()
    {
        running = true;
        readThread = new Thread(ReadLoop) { IsBackground = true };
        readThread.Start();
    }

    public void Send(MessageType type, byte[] payload)
    {
        lock (writeLock)
        {
            using BinaryWriter writer = new(stream, System.Text.Encoding.UTF8, leaveOpen: true);
            writer.Write(payload.Length);
            writer.Write((byte)type);
            if (payload.Length > 0) { writer.Write(payload); }
            writer.Flush();
        }
    }

    private void ReadLoop()
    {
        try
        {
            using BinaryReader reader = new(stream, System.Text.Encoding.UTF8, leaveOpen: true);
            while (running)
            {
                int length = reader.ReadInt32();
                MessageType type = (MessageType)reader.ReadByte();
                byte[] payload = length > 0 ? reader.ReadBytes(length) : [];
                if (payload.Length != length)
                {
                    // stream closed mid-frame
                    break;
                }
                MessageReceived?.Invoke(type, payload);
            }
        }
        catch
        {
            // connection dropped or was closed locally
        }
        finally
        {
            running = false;
            Disconnected?.Invoke();
        }
    }

    public void Dispose()
    {
        running = false;
        try { client.Close(); } catch { /* already closed */ }
    }
}
