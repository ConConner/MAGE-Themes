namespace mage.Networking;

public enum MessageType : byte
{
    Handshake = 0,
    RoomAction = 1,
    Disconnect = 2,
    Presence = 3,
}
