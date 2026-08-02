using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.GraphicsEditor;

public class FlipGraphicsAction : EditorGridAction
{
    private GFX _gfx;
    private Rectangle _region;
    private bool _isVertical;

    public FlipGraphicsAction(GFX gfx, Rectangle region, bool isVertical)
    {
        _gfx = gfx;
        _region = region;
        _isVertical = isVertical;
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => "Flip " + (_isVertical ? "Vertical" : "Horizontal");

    public override void Do()
    {
        int xPos = _region.X;
        int yPos = _region.Y;
        int width = _region.Width;
        int height = _region.Height;

        int[,] flipped = new int[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int realPosX = xPos + x;
                int realPosY = yPos + y;
                int pixel = _gfx.GetPixel(realPosX, realPosY);

                if (_isVertical) flipped[x, height - y - 1] = pixel;
                else flipped[width - x - 1, y] = pixel;
            }

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
            {
                int realPosX = xPos + x;
                int realPosY = yPos + y;
                int pixel = flipped[x, y];
                _gfx.SetPixel(realPosX, realPosY, pixel);
            }
    }

    public override void Undo()
    {
        Do();
    }
}
