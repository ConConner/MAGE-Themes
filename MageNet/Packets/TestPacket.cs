using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Packets;

public class TestPacket : IPacket
{
    int length;
    public TestPacket(int Length)
    {
        length = Length;
    }

    public IPacket Deserialize(byte[] data)
    {
        return new TestPacket(data.Length);
    }

    public byte[] Serialize()
    {
        return new byte[length];
    }
}
