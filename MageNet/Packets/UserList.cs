using MageNet.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;

namespace MageNet.Packets;

public class UserList : IPacketContent
{
    public List<MageClient> Clients { get; set; }

    public UserList(List<MageClient> clients)
    {
        Clients = clients;
    }
    public UserList() { }

    public static UserList Deserialize(Stream s)
    {
        string jsonString = MessagePacket.Deserialize(s).Message;

        UserList result = new UserList();
        result.Clients = JsonSerializer.Deserialize<List<MageClient>>(jsonString);
        return result;
    }

    public byte[] Serialize()
    {
        MessagePacket packet = new MessagePacket(JsonSerializer.Serialize(Clients));
        return packet.Serialize();
    }
}
