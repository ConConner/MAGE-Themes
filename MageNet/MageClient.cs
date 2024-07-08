using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MageNet;

public class MageClient
{
    public Guid UID { get; set; }
    public TcpClient ClientSocket { get; set; }

    public MageClient(TcpClient client)
    {
        ClientSocket = client;
        UID = Guid.NewGuid();
    }
}
