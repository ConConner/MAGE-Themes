using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.TileTableEditor;

public class FlipTileTableAction : EditorGridAction
{
    private Func<int, int, int> _getIndex;
    private ushort[] _tileTable;
    private Rectangle _region;
    private bool _isVertical;

    public FlipTileTableAction(ushort[] tileTable, Rectangle region, Func<int, int, int> getIndex, bool isVertical)
    {
        _tileTable = tileTable;
        _region = region;
        _getIndex = getIndex;
        _isVertical = isVertical;
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => "Flip " + (_isVertical ? "Vertical" : "Horizontal");

    private void flipH(ushort tile, ushort[,] flipped, int x, int y, int width)
    {
        tile = (ushort)(tile ^ 0x400);
        flipped[width - x - 1, y] = tile;
    }
    private void flipV(ushort tile, ushort[,] flipped, int x, int y, int height)
    {
        tile = (ushort)(tile ^ 0x800);
        flipped[x, height - y - 1] = tile;
    }

    public override void Do()
    {
        int xPos = _region.X;
        int yPos = _region.Y;
        int width = _region.Width;
        int height = _region.Height;

        ushort[,] flipped = new ushort[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int realPosX = xPos + x;
                int realPosY = yPos + y;
                int index = _getIndex(realPosX, realPosY);
                ushort tile = _tileTable[index];

                if (_isVertical) flipV(tile, flipped, x, y, height);
                else flipH(tile, flipped, x, y, width);
            }

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int realPosX = xPos + x;
                int realPosY = yPos + y;
                int index = _getIndex(realPosX, realPosY);
                ushort tile = flipped[x, y];
                _tileTable[index] = tile;
            }
    }

    public override void Undo()
    {
        Do();
    }
}
