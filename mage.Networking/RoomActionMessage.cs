namespace mage.Networking;

/// <summary>
/// Wire envelope for a single room-editor action. <see cref="Type"/> and
/// <see cref="Payload"/> are opaque to this library — the game project owns
/// the action-type enum and (de)serialization of the payload bytes.
/// </summary>
public sealed class RoomActionMessage
{
    public int RoomId;
    public uint SequenceNumber; // host-assigned, per-room, ignored when sent by a client
    public byte Type;
    public byte[] Payload = [];
    public bool IsUndo; // UI display only, not used for apply order

    public byte[] Serialize()
    {
        using MemoryStream ms = new();
        using (BinaryWriter writer = new(ms))
        {
            writer.Write(RoomId);
            writer.Write(SequenceNumber);
            writer.Write(Type);
            writer.Write(IsUndo);
            writer.Write(Payload.Length);
            writer.Write(Payload);
        }
        return ms.ToArray();
    }

    public static RoomActionMessage Deserialize(byte[] data)
    {
        using MemoryStream ms = new(data);
        using BinaryReader reader = new(ms);
        RoomActionMessage msg = new()
        {
            RoomId = reader.ReadInt32(),
            SequenceNumber = reader.ReadUInt32(),
            Type = reader.ReadByte(),
            IsUndo = reader.ReadBoolean(),
        };
        int payloadLength = reader.ReadInt32();
        msg.Payload = payloadLength > 0 ? reader.ReadBytes(payloadLength) : [];
        return msg;
    }
}
