using System;
using System.Drawing;
using System.IO;

namespace mage
{
    public enum RoomObjectType : byte
    {
        Enemy = 0,
        Door = 1,
        Scroll = 2,

        // one per RoomObject subclass, append-only, never reorder/renumber existing values
    }

    public abstract class RoomObject
    {
        public abstract Rectangle DrawingBounds { get; }

        public abstract RoomObjectType ObjectType { get; }

        public abstract RoomObject Copy();

        public abstract void SetValue(RoomObject newObj);

        public abstract RoomObject Move(Point diff, int num);

        public abstract void Add(Point pos);

        public abstract void Serialize(BinaryWriter writer);

        public abstract void Deserialize(BinaryReader reader);

        public static RoomObject FromNetwork(RoomObjectType type, BinaryReader reader)
        {
            RoomObject obj = type switch
            {
                RoomObjectType.Enemy => new Enemy(),
                RoomObjectType.Door => new Door(),
                RoomObjectType.Scroll => new Scroll(),
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Unknown RoomObjectType"),
            };
            obj.Deserialize(reader);
            return obj;
        }
    }
}
