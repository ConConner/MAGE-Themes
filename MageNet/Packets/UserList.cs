using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;

namespace MageNet.Packets;

public class UserList : IPacket
{
    public List<Guid> ClientUIDs { get; set; }

    public UserList(List<MageClient> clients)
    {
        ClientUIDs = new();
        foreach (MageClient client in clients) ClientUIDs.Add(client.UID);
    }
    public UserList() { }

    public IPacket Deserialize(byte[] data)
    {
        UserList result = new UserList();
        MessagePacket message = new MessagePacket();
        message = (MessagePacket)message.Deserialize(data);

        result.ClientUIDs = JsonSerializer.Deserialize<List<Guid>>(message.Message);
        return result;
    }

    public byte[] Serialize()
    {
        MessagePacket packet = new MessagePacket();
        packet.Message = JsonSerializer.Serialize(ClientUIDs);
        return packet.Serialize();
    }
}
