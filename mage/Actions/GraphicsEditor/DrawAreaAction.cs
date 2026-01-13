using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.GraphicsEditor;

public class DrawAreaAction : GraphicsAction
{
    private Rectangle _area;
    private GFX _gfx;
    private int[,] _data;

    public DrawAreaAction(GFX gfx, Rectangle area, int palIndex)
    {
        _area = area;
        _gfx = gfx;
        _data = new int[area.Width, area.Height];

        // Initialize _data with the color to be drawn
        for (int y = 0; y < area.Height; y++)
        {
            for (int x = 0; x < area.Width; x++)
            {
                _data[x, y] = palIndex;
            }
        }
    }

    public DrawAreaAction(GFX gfx, Point point, int[,] data)
    {
        _area = new Rectangle(point.X, point.Y, data.GetLength(0), data.GetLength(1));
        _gfx = gfx;
        _data = data;
    }


    public override Rectangle AffectedRegion => _area;

    public override string ActionText => $"Rectangle [{_area.Width}, {_area.Height}]";

    public override void Do()
    {
        for (int y = 0; y < _area.Height; y++)
        {
            for (int x = 0; x < _area.Width; x++)
            {
                int oldValue = _gfx.GetPixel(new Point(_area.X + x, _area.Y + y));
                _gfx.SetPixel(new Point(_area.X + x, _area.Y + y), _data[x, y]);
                _data[x, y] = oldValue;
            }
        }
    }

    public override void Undo()
    {
        Do();
    }
}
