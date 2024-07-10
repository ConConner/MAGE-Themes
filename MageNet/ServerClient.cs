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

    public void ConnectToServer(IPAddress address, int port)
    {
        if (client.Connected) return; //TODO: Error handling

        client.Connect(address, port);

        //Send Username
        MessagePacket packet = new MessagePacket() { Message = username };
        PacketBuilder pb = new PacketBuilder();
        pb.AddPacket(PacketType.Username, packet);
        SendPacket(pb.GetPacketBytes());

        HandlePackets();
    }
    
    public void Disconnect()
    {
        if (client.Connected) client.Close();
    }

    public void SendPacket(byte[] payload)
    {
        client.Client.Send(payload);
    }

    private async void HandlePackets()
    {
        NetworkStream stream = client.GetStream();

        //Buffer
        byte[] buffer = new byte[8192];
        int bytesRead;

        try
        {
            while ((bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
            {
                //Handle received data
                clientOutput($"[Client]: Received: {bytesRead} bytes");
            }
        }
        catch (Exception e)
        {
            clientOutput($"Exception: {e.Message}");
        }
        finally
        {
            //Close things
            stream.Close();
            Disconnect();
        }
    }
}
