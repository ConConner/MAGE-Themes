using MageNet.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class MessagePacket : IPacket
{
    public string Message { get; set; } = "";

    public MessagePacket(string message) { Message = message; }

    public static MessagePacket Deserialize(Stream s)
    {
        BinaryReader br = new BinaryReader(s);
        int messageLength = br.ReadInt32();
        byte[] messageContent = s.ReadNumberOfBytes(messageLength);

        return new MessagePacket(Encoding.UTF8.GetString(messageContent));
    }

    public byte[] Serialize()
    {
        MemoryStream s = new MemoryStream();

        //Write Data
        s.Write(BitConverter.GetBytes(Message.Length));    //Length
        s.Write(Encoding.UTF8.GetBytes(Message));          //Content

        return s.ToArray();
    }
}
