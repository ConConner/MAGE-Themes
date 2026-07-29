using System;
using System.IO;

namespace mage.Actions.RoomEditor;

public static class ActionFactory
{
    public static Action Deserialize(ActionType type, BinaryReader reader)
    {
        Action action = type switch
        {
            ActionType.EditBlocks => new EditBlocks(),
            ActionType.AddRemoveRoomObject => new AddRemoveRoomObject(),
            ActionType.EditRoomObjects => new EditRoomObject(),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, "Action type is not supported over the network"),
        };

        action.Deserialize(reader);
        return action;
    }
}
