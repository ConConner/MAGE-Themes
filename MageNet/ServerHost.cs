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
        LogAction = logAction;
    }

    #region Properties
    Action<string> logAction = null;
    Action<string> LogAction
    {
        get
        {
            if (logAction != null) return logAction;
            else return (s) => { };
        }
        set => logAction = value;
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
            LogAction($"Server started. Listening on {address}:{port}");

            //Continously accept new connections
            while (true)
            {
                MageClient client = new MageClient(await listener.AcceptTcpClientAsync());
                LogAction($"Connected User {client.UID.ToString()}");
                clients.Add(client);

                //Send the current user List to every client
                SendUserList();

                HandleClient(client);
            }
        }
        catch (SocketException e)
        {
            LogAction($"SocketException: {e.Message}");
            LogAction($"Error Code: {e.ErrorCode}");
        }
        catch (Exception e)
        {
            LogAction($"Exception: {e.Message}");
        }
        finally
        {
            listener?.Stop();
            LogAction("Server stopped");
        }
    }

    /// <summary>
    /// Continuously handle incoming packets from a client
    /// </summary>
    /// <param name="client"></param>
    public async void HandleClient(MageClient client)
    {
        NetworkStream stream = client.ClientSocket.GetStream();

        //Buffer
        byte[] buffer = new byte[8192];
        int bytesRead;

        try
        {
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
            }
        }
        catch (Exception e)
        {
            LogAction($"Exception: {e.Message}");
        }
        finally
        {
            //Close things
            stream.Close();
            client.ClientSocket.Close();
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

    public void SendUserList()
    {
        PacketBuilder builder = new PacketBuilder();
        builder.AddPacket(PacketType.UserConnect, new UserList(clients));

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