using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Actions.RoomEditor;

public enum ActionType : byte
{
    EditBlocks = 0,
    AddRemoveRoomObject = 1,
    EditRoomObjects = 2,
    FlipRoom = 3, // not sent over the network yet; Serialize/Deserialize throw

    // ... one per subclass, append-only, never reorder/renumber existing values
}
