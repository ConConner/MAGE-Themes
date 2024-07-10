using MageNet.IO;
using MageNet.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MageNet;

public class ServerHost
{
    #region Fields
    List<MageClient> clients;
    TcpListener listener;
    IPAddress address;
    int port;
    #endregion

    public ServerHost(IPAddress address, int port, Action<string> logAction = null)
    {
        clients = new List<MageClient>();
        listener = new TcpListener(address, port);

        this.address = address;
        this.port = port;
        ServerOutput = logAction;
    }

    #region Properties
    Action<string> serverOutput;
    Action<string> ServerOutput
    {
        get
        {
            if (serverOutput != null) return serverOutput;
            else return (s) => { Debug.WriteLine(s); };
        }
        set => serverOutput = value;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Starts accepting clients on the TCPListener through the given address and port
    /// </summary>
    public async void AcceptClients()
    {
        try
        {
            listener.Start();
            ServerOutput($"Server started. Listening on {address}:{port}");

            //Continously accept new connections
            while (true)
            {
                MageClient client = new MageClient(await listener.AcceptTcpClientAsync());
                ServerOutput($"Connected User {client.UID.ToString()}");
                clients.Add(client);

                HandleClient(client);
            }
        }
        catch (SocketException e)
        {
            ServerOutput($"SocketException: {e.Message}");
            ServerOutput($"Error Code: {e.ErrorCode}");
        }
        catch (Exception e)
        {
            ServerOutput($"Exception: {e.Message}");
        }
        finally
        {
            listener?.Stop();
            ServerOutput("Server stopped");
        }
    }

    /// <summary>
    /// Continuously handle incoming packets from a client
    /// </summary>
    /// <param name="client"></param>
    public async void HandleClient(MageClient client)
    {
        NetworkStream stream = client.ClientSocket.GetStream();
        try
        {
            //Get the Username first
            client.Username = await GetClientUsername(client);
            ServerOutput($"[Server]: {client.UID} is now known as: {client.Username}");

            //Send the current user List to every client
            SendUserList();

            //Keep listening to packets
            while (true)
            {
                byte[] packet = await PacketReader.ReadPacketFromStream(stream);
                if (packet.Length == 0) break;

                ServerOutput($"[Server]: Received: {packet.Length} Bytes");
            }
        }
        catch (Exception e)
        {
            ServerOutput($"Exception: {e.Message}");
        }
        finally
        {
            //Close things
            stream.Close();
            client.Disconnect();
        }
    }

    /// <summary>
    /// Propegates the Data to every other Client, except the one that it was send from
    /// </summary>
    /// <param name="data"></param>
    public void PropagatePacketToClients(MageClient origin, byte[] data)
    {
        foreach (MageClient c in clients)
        {
            if (c.UID == origin?.UID) continue;
            SendPacketToClient(c, data);
        }
    }

    /// <summary>
    /// Sends a packet to a client
    /// </summary>
    /// <param name="data"></param>
    public void SendPacketToClient(MageClient client, byte[] data)
    {
        NetworkStream stream = client.ClientSocket.GetStream();
        stream.Write(data, 0, data.Length);
    }

    /// <summary>
    /// Starts listening for a Packet of the type Username and returns the Username as a string if received
    /// </summary>
    private async Task<string> GetClientUsername(MageClient client)
    {
        while (true)
        {
            byte[] namePacket = await PacketReader.ReadPacketFromStream(client.ClientSocket.GetStream());
            if (namePacket.Length == 0) throw new Exception($"Client {client.UID} closed the connection");

            //Check for proper type
            if (namePacket[0] != (byte)PacketType.Username) throw new Exception($"Client {client.UID} did not provide a Username as their first packet");

            //Read Packet content
            MessagePacket mp = (MessagePacket)new MessagePacket().Deserialize(namePacket[5..namePacket.Length]);
            return mp.Message;
        }
    }

    public void SendUserList()
    {
        PacketBuilder builder = new PacketBuilder();
        builder.AddPacket(PacketType.UserList, new UserList(clients));

        PropagatePacketToClients(null, builder.GetPacketBytes());
    }

    public void EndSession()
    {
        foreach (MageClient c in clients)
        {
            c.Disconnect();
        }
        listener.Stop();
    }
    #endregion
}