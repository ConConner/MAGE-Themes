namespace mage.Networking;

/// <summary>One peer's current location, for the "who's editing what" roster.</summary>
public sealed class PresenceEntry
{
    public Guid ClientId;   // locally generated per session, used to filter "me" out of the roster - never compare by UserName, peers can share a display name
    public string UserName = "";
    public int RoomId; // -1 = not currently in a room

    public static byte[] SerializeList(IReadOnlyCollection<PresenceEntry> entries)
    {
        using MemoryStream ms = new();
        using (BinaryWriter writer = new(ms, System.Text.Encoding.UTF8, leaveOpen: true))
        {
            writer.Write(entries.Count);
            foreach (PresenceEntry entry in entries)
            {
                writer.Write(entry.ClientId.ToByteArray());
                writer.Write(entry.UserName);
                writer.Write(entry.RoomId);
            }
        }
        return ms.ToArray();
    }

    public static List<PresenceEntry> DeserializeList(byte[] data)
    {
        using MemoryStream ms = new(data);
        using BinaryReader reader = new(ms);
        int count = reader.ReadInt32();
        List<PresenceEntry> entries = new(count);
        for (int i = 0; i < count; i++)
        {
            entries.Add(new PresenceEntry
            {
                ClientId = new Guid(reader.ReadBytes(16)),
                UserName = reader.ReadString(),
                RoomId = reader.ReadInt32(),
            });
        }
        return entries;
    }
}
