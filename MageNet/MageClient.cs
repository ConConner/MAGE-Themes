using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MageNet;

public class MageClient
{
    [JsonInclude]
    public string Username { get; set; }
    [JsonInclude]
    public Guid UID { get; set; }

    [JsonIgnore]
    public TcpClient ClientSocket { get; set; }

    [JsonConstructor]
    public MageClient() { }
    public MageClient(TcpClient client)
    {
        ClientSocket = client;
        UID = Guid.NewGuid();
    }

    public void Disconnect()
    {
        ClientSocket?.Close();
    }
}
