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
    public bool TileTableEditorShowPalettePreview { get; set; } = false;
    public bool TileTableEditorCopyPalette { get; set; } = true;
}
