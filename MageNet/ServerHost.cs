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
    List<MageClient> clients;
    TcpListener listener;
    IPAddress address;
    int port;
    Action<byte[]> handlePacket;

    public ServerHost(IPAddress address, int port, Action<byte[]> handlePacket)
    {
        clients = new List<MageClient>();
        listener = new TcpListener(address, port);

        this.address = address;
        this.port = port;
        this.handlePacket = handlePacket;
    }

    public async void AcceptClients()
    {
        listener.Start();
        Debug.WriteLine($"Server started. Listening on {address}:{port}");

        while (true)
        {
            //Accept a new connection
            MageClient client = new MageClient(await listener.AcceptTcpClientAsync());
            Debug.WriteLine($"Connected User {client.UID.ToString()}");
            clients.Add(client);

            HandleClient(client);
        }
    }

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
                //Handle received data
                Debug.WriteLine($"Received: {bytesRead} bytes");
                handlePacket(buffer);
            }
        }
        finally
        {
            //Close things
            stream.Close();
            client.ClientSocket.Close();
        }
    }
}