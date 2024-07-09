using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class MessagePacket : IPacket
{
    public string Message { get; set; } = "";

    public IPacket Deserialize(byte[] data)
    {
        return new MessagePacket()
        {
            Message = Encoding.UTF8.GetString(data)
        };
    }

    public byte[] Serialize()
    {
        return Encoding.UTF8.GetBytes(Message);
    }
}
