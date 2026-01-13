using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.GraphicsEditor;

public class EditPixelAction : GraphicsAction
{
    private int _palIndex;
    private Point _point;
    private GFX _gfx;

    public EditPixelAction(GFX graphics, Point point, int palIndex)
    {
        _gfx = graphics;
        _point = point;
        _palIndex = palIndex;
    }

    public override Rectangle AffectedRegion => new Rectangle(_point.X, _point.Y, 1, 1);

    public override string ActionText => "Draw";

    public override void Do()
    {
        int oldPalIndex = _gfx.GetPixel(_point);
        _gfx.SetPixel(_point, _palIndex);

        // Prepare for undo
        _palIndex = oldPalIndex;
    }

    public override void Undo()
    {
        Do();
    }
}
