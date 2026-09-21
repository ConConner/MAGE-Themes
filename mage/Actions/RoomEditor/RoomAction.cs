using System;
using System.Drawing;

namespace mage
{
    public abstract class RoomAction
    {
        public abstract Rectangle AffectedRegion { get; }

        public bool combine;

        public abstract void Do(Room room);

        public abstract void Undo(Room room);

        public virtual bool TryCombine(RoomAction a)
        {
            return false;
        }

        public abstract string ActionText { get; }


    }
}
