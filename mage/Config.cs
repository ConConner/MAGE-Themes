using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage;

/// <summary>
/// Application wide Config file
/// </summary>
public class Config
{
    #region Tile Table Editor
    public bool TileTableEditorShowPalettePreview { get; set; } = false;
    public bool TileTableEditorCopyPalette { get; set; } = true;
    #endregion

    #region OAM Editor
    public bool OamEditorViewOrigin { get; set; } = true;
    public bool OamEditorViewPartOutlines { get; set; } = true;
    public bool OamEditorViewPalette { get; set; } = true;
    public bool OamEditorViewVram { get; set; } = false;
    public int OamEditorGfxZoom { get; set; } = 2;
    public int OamEditorOamZoom { get; set; } = 2;
    #endregion
}
