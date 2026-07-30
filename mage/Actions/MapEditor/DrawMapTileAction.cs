using mage.Editors.NewEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.MapEditor;

public class DrawMapTileAction : EditorGridAction
{
    private Minimap _map;
    private Dictionary<Point, FormMinimapNew.MapTile> _tiles;
    private string _actionText;

    public DrawMapTileAction(Minimap map, Dictionary<Point, FormMinimapNew.MapTile> tiles, string actionText)
    {
        _map = map;
        _tiles = tiles;
        _actionText = actionText;
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => _actionText;

    public override void Do()
    {
        foreach (var kvp in _tiles)
        {
            FormMinimapNew.MapTile oldTile = _map.GetSquare(kvp.Key);
            _map.SetSquare(kvp.Key, kvp.Value);
            _tiles[kvp.Key] = oldTile;
        }
    }

    public override void Undo()
    {
        Do();
    }
}
