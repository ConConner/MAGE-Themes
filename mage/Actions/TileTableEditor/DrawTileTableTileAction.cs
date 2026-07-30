using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.TileTableEditor;

public class DrawTileTableTileAction : EditorGridAction
{
    private ushort[] _tiletable;
    private Dictionary<int, ushort> _tiles;

    public DrawTileTableTileAction(ushort[] tiletable, Dictionary<int, ushort> tiles)
    {
        _tiletable = tiletable;
        _tiles = tiles;
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => "Draw";

    public override void Do()
    {
        foreach (var kvp in _tiles)
        {
            ushort oldTile = _tiletable[kvp.Key];
            _tiletable[kvp.Key] = kvp.Value;
            _tiles[kvp.Key] = oldTile;
        }
    }

    public override void Undo()
    {
        Do();
    }
}
