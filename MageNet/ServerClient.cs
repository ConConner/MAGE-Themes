using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MageNet;

public class ServerClient
{
    TcpClient client;
    PacketBuilder builder;

    public ServerClient()
    {
        client = new TcpClient();
    }

    public void ConnectToServer(IPAddress address, int port)
    {
        if (client.Connected) return; //TODO: Error handling

        client.Connect(address, port);
    }
    
    public void Disconnect()
    {
        if (client.Connected) client.Close();
    }

    public void SendPacket(byte[] payload)
    {
        client.Client.Send(payload);
    }
}
