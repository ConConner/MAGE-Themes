using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.PaletteEditor;

internal class EditPalettePixelAction : EditorGridAction
{
    private Palette _palette;
    private ushort _color;
    private Point _location;

    public EditPalettePixelAction(Palette palette, Point location, ushort color)
    {
        _palette = palette;
        _location = location;
        _color = color;
    }

    public override Rectangle AffectedRegion => new(_location, new(1, 1));

    public override string ActionText => "Draw";

    public override void Do()
    {
        ushort old = _palette.GetARGB(_location.Y, _location.X);
        _palette.SetARGB(_location.Y, _location.X, _color);

        _color = old;
    }

    public override void Undo()
    {
        Do();
    }
}
