using MageNet.EventArguments;
using MageNet.IO;
using MageNet.Packets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MageNet;

public class ServerClient
{
    TcpClient client;
    NetworkStream clientStream => client.GetStream();
    string username;
    Action<string> clientOutput;

    public ServerClient(string username, Action<string> ClientOutput = null)
    {
        client = new TcpClient();
        this.username = username;
        if (ClientOutput == null) clientOutput = (s) => { Debug.WriteLine(s); };
        else clientOutput = ClientOutput;
    }

    #region Events
    public event EventHandler<UsersConnectedArgument> UserConnected;
    public event EventHandler<RomChangeArgument> RomChanged;
    public event EventHandler<TileChange> TileChanged;
    #endregion

    public void ConnectToServer(IPAddress address, int port)
    {
        if (client.Connected) throw new Exception("Client is already connected to a Server");

        client.Connect(address, port);

        //Send Username
        MessagePacket packet = new MessagePacket(username);
        Packet p = new Packet(PacketType.Username, packet);
        SendPacketToServerAsync(p);

        ListenToPackets();
    }

    private async void ListenToPackets()
    {
        NetworkStream stream = client.GetStream();

        try
        {
            while (true)
            {
                Packet packet = await PacketReader.ReadSinglePacketFromStream(stream);
                if (packet == null || packet.Length == 0) break;

                //Handle received data
                HandlePacket(packet);
            }
        }
        catch (Exception e)
        {
            clientOutput($"[{username}]: Exception: {e.Message}");
        }
        finally
        {
            //Close things
            stream.Close();
            Disconnect();
        }
    }

    private void HandlePacket(Packet packet)
    {
        MemoryStream ms = new MemoryStream(packet.Content);
        BinaryReader br = new BinaryReader(ms);

        switch (packet.Type)
        {
            case PacketType.UserList:
                UserList ul = UserList.Deserialize(ms);
                UsersConnectedArgument ucArgument = new UsersConnectedArgument()
                {
                    ConnectedUsers = ul.Clients,
                    LatestConnect = ul.Clients.Last()
                };
                UserConnected?.Invoke(this, ucArgument);
                break;

            case PacketType.RomChange:
                RomChange rc = RomChange.Deserialize(ms);
                RomChangeArgument rcArgument = new RomChangeArgument(rc);
                RomChanged?.Invoke(this, rcArgument);
                break;

            case PacketType.TileChange:
                TileChange tc = TileChange.Deserialize(ms);
                TileChanged?.Invoke(this, tc);
                break;

            default:
                clientOutput($"[{username}] Received {packet.Length + 5} bytes");
                break;
        }
    }




    public void Disconnect()
    {
        if (client.Connected) client.Close();
    }

    public async Task SendPacketToServerAsync(Packet p)
    {
        await clientStream.WriteAsync(p.Serialize());
    }
    public void SendPacketToServer(Packet p)
    {
        clientStream.Write(p.Serialize());
    }
}
