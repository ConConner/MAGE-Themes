using MageNet.EventArguments;
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

    #region Client Handling

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
    private async void HandleClient(MageClient client)
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
                Packet packet = await PacketReader.ReadSinglePacketFromStream(stream);
                if (packet == null || packet.Length == 0) break;

                HandlePacket(client, packet);
            }
        }
        catch (Exception e)
        {
            ServerOutput($"[Server]: Exception: {e.Message}");
        }
        finally
        {
            //Close things
            stream.Close();
            clients.Remove(client);
            client.Disconnect();
        }
    }

    private void HandlePacket(MageClient origin, Packet packet)
    {
        MemoryStream ms = new MemoryStream(packet.Content);
        BinaryReader br = new BinaryReader(ms);
        ServerOutput($"[Server]: Received: {packet.Length} Bytes");
        switch (packet.Type)
        {
            case PacketType.UserList:

                break;

            case PacketType.RomChange:
            case PacketType.TileChange:
                PropagatePacketToClients(origin, packet);
                break;

            default:

                break;
        }
    }

    #endregion

    #region Packet Operations

    /// <summary>
    /// Propegates the Data to every other Client, except the one that it was send from
    /// </summary>
    /// <param name="data"></param>
    public void PropagatePacketToClients(MageClient origin, Packet p)
    {
        foreach (MageClient c in clients)
        {
            if (c.UID == origin?.UID) continue;
            SendPacketToClientAsync(c, p);
        }
    }

    /// <summary>
    /// Sends a packet to a client
    /// </summary>
    /// <param name="data"></param>
    public async void SendPacketToClientAsync(MageClient client, Packet packet)
    {
        NetworkStream stream = client.ClientSocket.GetStream();
        await stream.WriteAsync(packet.Serialize());
    }
    public void SendPacketToClient(MageClient client, Packet packet)
    {
        NetworkStream stream = client.ClientSocket.GetStream();
        stream.Write(packet.Serialize());
    }

    #endregion


    /// <summary>
    /// Starts listening for a Packet of the type Username and returns the Username as a string if received
    /// </summary>
    private async Task<string> GetClientUsername(MageClient client)
    {
        while (true)
        {
            Packet namePacket = await PacketReader.ReadSinglePacketFromStream(client.ClientSocket.GetStream());
            if (namePacket.Length == 0) throw new Exception($"Client {client.UID} closed the connection");

            //Check for proper type
            if (namePacket.Type != PacketType.Username) throw new Exception($"Client {client.UID} did not provide a Username as their first packet");

            //Read Packet content
            MemoryStream ms = new MemoryStream(namePacket.Content);
            MessagePacket mp = MessagePacket.Deserialize(ms);
            return mp.Message;
        }
    }

    public void SendUserList()
    {
        Packet p = new(PacketType.UserList, new UserList(clients));

        PropagatePacketToClients(null, p);
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