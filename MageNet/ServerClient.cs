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
    #endregion

    public void ConnectToServer(IPAddress address, int port)
    {
        if (client.Connected) throw new Exception("Client is already connected to a Server");

        client.Connect(address, port);

        //Send Username
        MessagePacket packet = new MessagePacket(username);
        PacketBuilder pb = new PacketBuilder();
        pb.AddPacket(PacketType.Username, packet);
        SendPacket(pb.GetPacketBytes());

        ListenToPackets();
    }
    
    public void Disconnect()
    {
        if (client.Connected) client.Close();
    }

    public void SendPacket(byte[] payload)
    {
        client.Client.Send(payload);
    }

    private async void ListenToPackets()
    {
        NetworkStream stream = client.GetStream();

        try
        {
            while (true)
            {
                byte[] packet = await PacketReader.ReadPacketFromStream(stream);
                if (packet.Length == 0) break;

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

    private void HandlePacket(byte[] packet)
    {
        MemoryStream ms = new MemoryStream(packet);
        BinaryReader br = new BinaryReader(ms);

        switch (ms.ReadByte())
        {
            case (byte)PacketType.UserList:
                ms.Seek(5, SeekOrigin.Begin); //Skip packet length, since its irrelevant

                UserList ul = UserList.Deserialize(ms);
                UsersConnectedArgument ucArgument = new UsersConnectedArgument()
                {
                    ConnectedUsers = ul.Clients,
                    LatestConnect = ul.Clients.Last()
                };
                UserConnected?.Invoke(this, ucArgument);
                break;

            case (byte)PacketType.RomChange:
                ms.Seek(5, SeekOrigin.Begin);

                RomChange rc = RomChange.Deserialize(ms);
                RomChangeArgument rcArgument = new RomChangeArgument(rc);
                RomChanged?.Invoke(this, rcArgument);
                break;

            default:
                clientOutput($"[{username}]: Received: {packet.Length} bytes");
                break;
        }
    }
}
