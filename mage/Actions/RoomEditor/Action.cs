using System;
using System.IO;
using mage.Actions.RoomEditor;

namespace mage
{
    public abstract class Action
    {
        public bool combine;

        public abstract void Do(Room room);

        public abstract void Undo(Room room);

        public virtual bool TryCombine(Action a)
        {
            return false;
        }

        public abstract string ActionText { get; }

        public abstract ActionType Type { get; }

        public abstract void Serialize(BinaryWriter writer);
        public abstract void Deserialize(BinaryReader reader);
    }
}
