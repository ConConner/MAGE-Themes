using mage.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mage.Actions.RoomEditor;

public class FlipRoom : RoomAction
{
    Rectangle Region;
    bool FlipHorizontal;
    bool FlipVertical;

    public FlipRoom(Room room, bool horizontal, bool vertical)
    {
        FlipHorizontal = horizontal;
        FlipVertical = vertical;
        Region = new(0, 0, room.Width, room.Height);
    }

    public override Rectangle AffectedRegion => Region;

    public override string ActionText => $"Flip Room{(FlipHorizontal ? " horizontal" : "")}{(FlipVertical ? " vertical" : "")}";

    public override void Do(Room room)
    {
        Flip.FlipRoom(room, FlipHorizontal, FlipVertical);
    }

    public override void Undo(Room room)
    {
        Flip.FlipRoom(room, FlipHorizontal, FlipVertical);
    }

    public override ActionType Type => ActionType.FlipRoom;

    // Not yet synced over the network — coworking sessions don't route flips.
    public override void Serialize(BinaryWriter writer) => throw new NotSupportedException("FlipRoom is not networked yet.");

    public override void Deserialize(BinaryReader reader) => throw new NotSupportedException("FlipRoom is not networked yet.");
}
