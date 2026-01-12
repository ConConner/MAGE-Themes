using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.GraphicsEditor;

internal class FillAreaAction : GraphicsAction
{
    private GFX _gfx;
    private Dictionary<Point, int> _pixels;

    public FillAreaAction(GFX gfx, Dictionary<Point, int> pixels)
    {
        _gfx = gfx;
        _pixels = pixels;
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => "Fill";

    public override void Do()
    {
        foreach (var kvp in _pixels)
        {
            int oldPalIndx = _gfx.GetPixel(kvp.Key.X, kvp.Key.Y);
            _gfx.SetPixel(kvp.Key.X, kvp.Key.Y, kvp.Value);
            _pixels[kvp.Key] = oldPalIndx;
        }
    }

    public override void Undo()
    {
        Do();
    }
}
