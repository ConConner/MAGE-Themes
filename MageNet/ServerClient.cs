using MageNet.IO;
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
    PacketBuilder builder;
    Action<string> consoleWriteLine;

    public ServerClient(Action<string> ConsoleWriteLine = null)
    {
        client = new TcpClient();
        if (ConsoleWriteLine == null) consoleWriteLine = (s) => { Debug.WriteLine(s); };
        else consoleWriteLine = ConsoleWriteLine;
    }

    public void ConnectToServer(IPAddress address, int port)
    {
        if (client.Connected) return; //TODO: Error handling

        client.Connect(address, port);
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
                consoleWriteLine($"Received: {bytesRead} bytes");
            }
        }
        catch (Exception e)
        {
            consoleWriteLine($"Exception: {e.Message}");
        }
        finally
        {
            //Close things
            stream.Close();
            Disconnect();
        }
    }
}
