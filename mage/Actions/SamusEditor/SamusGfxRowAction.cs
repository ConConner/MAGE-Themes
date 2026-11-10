using System;
using System.Drawing;

namespace mage.Actions.SamusEditor;

/// <summary>
/// Replaces the tiles of a row of Samus graphics, used for changing the amount of tiles and importing
/// </summary>
public class SamusGfxRowAction : GenericEditorAction
{
    private readonly SamusGfx gfx;
    private readonly int row;
    private readonly int oldTiles, newTiles;
    private readonly byte[] oldData, newData;
    private readonly string actionText;

    public Action? DoUndoRun { get; set; } = null;

    public SamusGfxRowAction(SamusGfx gfx, int row, int tiles, byte[] data, string actionText = "Changed Tile Count")
    {
        this.gfx = gfx;
        this.row = row;
        oldTiles = gfx.RowTiles[row];
        oldData = gfx.Rows[row];
        newTiles = tiles;
        newData = data;
        this.actionText = actionText;
    }

    public override Rectangle AffectedRegion => Rectangle.Empty;

    public override string ActionText => actionText;

    public override void Do()
    {
        gfx.SetRow(row, newTiles, newData);
        DoUndoRun?.Invoke();
    }

    public override void Undo()
    {
        gfx.SetRow(row, oldTiles, oldData);
        DoUndoRun?.Invoke();
    }
}
