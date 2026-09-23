using System;
using System.Drawing;

namespace mage.Actions.RoomEditor;

/// <summary>
/// Moves the tiles of one RLE background inside a region onto another RLE background.
/// Empty tiles (0) in the source are skipped, so they don't erase tiles already on the destination.
/// </summary>
public class MoveBlocksToLayer : RoomAction
{
    private readonly Rectangle _region;  // in blocks
    private readonly int _srcBg;
    private readonly int _dstBg;

    private readonly ushort[,] _srcBefore;
    private readonly ushort[,] _dstBefore;
    private readonly ushort[,] _srcAfter;
    private readonly ushort[,] _dstAfter;

    public MoveBlocksToLayer(Room room, Rectangle region, int srcBg, int dstBg)
    {
        _srcBg = srcBg;
        _dstBg = dstBg;

        Backgrounds backgrounds = room.backgrounds;
        _region = Rectangle.Intersect(region, new Rectangle(0, 0, backgrounds.width, backgrounds.height));

        ushort[,] src = backgrounds[srcBg].blocks;
        ushort[,] dst = backgrounds[dstBg].blocks;

        _srcBefore = new ushort[_region.Width, _region.Height];
        _dstBefore = new ushort[_region.Width, _region.Height];
        _srcAfter = new ushort[_region.Width, _region.Height];
        _dstAfter = new ushort[_region.Width, _region.Height];

        for (int y = 0; y < _region.Height; y++)
        {
            for (int x = 0; x < _region.Width; x++)
            {
                ushort s = src[_region.X + x, _region.Y + y];
                ushort d = dst[_region.X + x, _region.Y + y];
                _srcBefore[x, y] = s;
                _dstBefore[x, y] = d;

                bool move = s != 0;
                _srcAfter[x, y] = move ? (ushort)0 : s;
                _dstAfter[x, y] = move ? s : d;
            }
        }
    }

    public override Rectangle AffectedRegion =>
        new Rectangle(_region.X * 16, _region.Y * 16, _region.Width * 16, _region.Height * 16);

    public override string ActionText => $"Swap BG{_srcBg} & BG{_dstBg}";

    public override void Do(Room room)
    {
        Apply(room, _srcAfter, _dstAfter);
    }

    public override void Undo(Room room)
    {
        Apply(room, _srcBefore, _dstBefore);
    }

    private void Apply(Room room, ushort[,] srcValues, ushort[,] dstValues)
    {
        BG src = room.backgrounds[_srcBg];
        BG dst = room.backgrounds[_dstBg];

        for (int y = 0; y < _region.Height; y++)
        {
            for (int x = 0; x < _region.Width; x++)
            {
                src.blocks[_region.X + x, _region.Y + y] = srcValues[x, y];
                dst.blocks[_region.X + x, _region.Y + y] = dstValues[x, y];
            }
        }

        src.Edited = true;
        dst.Edited = true;
    }
}
