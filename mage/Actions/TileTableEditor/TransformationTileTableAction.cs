using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace mage.Actions.TileTableEditor;

public class TransformationTileTableAction : EditorGridAction
{
    private Func<ushort, ushort> _transformation;
    private Func<int, int, int> _getIndex;
    private ushort[] _tileTable;
    private Rectangle _region;
    private string _actionText;

    private Dictionary<int, ushort> _oldTiles = new();

    public TransformationTileTableAction(Func<ushort, ushort> transformation, Func<int, int, int> getIndex, ushort[] tileTable, Rectangle region, string actionText)
    {
        _transformation = transformation;
        _getIndex = getIndex;
        _tileTable = tileTable;
        _region = region;
        _actionText = actionText;
    }

    public override Rectangle AffectedRegion => throw new NotImplementedException();

    public override string ActionText => _actionText;

    public override void Do()
    {
        for (int x = _region.Left; x < _region.Right; x++)
            for (int y = _region.Top; y < _region.Bottom; y++)
            {
                int index = _getIndex(x, y);
                ushort tile = _tileTable[index];
                _oldTiles.Add(index, tile);

                ushort newTile = _transformation(tile);
                _tileTable[index] = newTile;
            }
    }

    public override void Undo()
    {
        foreach (var kvp in _oldTiles)
        {
            _tileTable[kvp.Key] = kvp.Value;
        }
        _oldTiles.Clear();
    }
}
