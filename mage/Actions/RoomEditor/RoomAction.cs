using System;
using System.Drawing;

namespace mage.Actions.RoomEditor
{
    public abstract class RoomAction : Action
    {
        public abstract Rectangle AffectedRegion { get; }

    }
}
