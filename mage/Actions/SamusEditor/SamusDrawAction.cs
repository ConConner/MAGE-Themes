using System;
using System.Collections.Generic;
using System.Drawing;

namespace mage.Actions.SamusEditor;

/// <summary>
/// A stroke of pixels drawn onto Samus graphics. Pixels are applied while drawing, so the action is only added afterwards.
/// </summary>
public class SamusDrawAction : GenericEditorAction
{
    private readonly record struct PixelKey(SamusGfx Gfx, int Row, int X, int Y);

    private readonly Dictionary<PixelKey, (int oldIndex, int newIndex)> pixels = new();

    public int Count => pixels.Count;

    public override Rectangle AffectedRegion => Rectangle.Empty;

    public override string ActionText => "Draw";

    /// <summary>
    /// Sets a pixel and remembers its original value
    /// </summary>
    /// <returns>If the pixel changed</returns>
    public bool SetPixel(SamusGfx gfx, int row, int x, int y, int palIndex)
    {
        int old = gfx.GetPixel(row, x, y);
        if (old < 0 || old == palIndex) return false;

        PixelKey key = new(gfx, row, x, y);
        if (pixels.TryGetValue(key, out var entry)) pixels[key] = (entry.oldIndex, palIndex);
        else pixels[key] = (old, palIndex);

        gfx.SetPixel(row, x, y, palIndex);
        return true;
    }

    public override void Do()
    {
        foreach (var kvp in pixels) kvp.Key.Gfx.SetPixel(kvp.Key.Row, kvp.Key.X, kvp.Key.Y, kvp.Value.newIndex);
    }

    public override void Undo()
    {
        foreach (var kvp in pixels) kvp.Key.Gfx.SetPixel(kvp.Key.Row, kvp.Key.X, kvp.Key.Y, kvp.Value.oldIndex);
    }
}
