using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.PaletteEditor;

internal class EditPaletteAreaAction : EditorGridAction
{
    private string _actionText;
    private Palette _palette;
    private ushort[,] _colors;
    private Point _location;
    private Rectangle _area;

    public EditPaletteAreaAction(Palette palette, Point location, ushort[,] colors, string actionText = "Draw")
    {
        _palette = palette;
        _location = location;
        _colors = colors;
        _actionText = actionText;

        _area = new Rectangle(location.X, location.Y, colors.GetLength(0), colors.GetLength(1));
    }

    public EditPaletteAreaAction(Palette palette, Rectangle area, ushort color, string actionText = "Fill")
    {
        _palette = palette;
        _area = area;
        _location = area.Location;
        _actionText = actionText;
        _colors = new ushort[area.Width, area.Height];

        for (int x = 0; x < area.Width; x++)
            for (int y = 0; y < area.Height; y++)
                _colors[x, y] = color;
    }

    public override Rectangle AffectedRegion => _area;

    public override string ActionText => _actionText;

    public override void Do()
    {
        for (int c = 0; c < _area.Width; c++)
        {
            for (int r = 0; r < _area.Height; r++)
            {
                ushort old = _palette.GetARGB(_location.Y + r, _location.X + c);
                _palette.SetARGB(_location.Y + r, _location.X + c, _colors[c, r]);
                _colors[c, r] = old;
            }
        }
    }

    public override void Undo()
    {
        Do();
    }

    public ushort[,] GetOldColors() => _colors;
}
