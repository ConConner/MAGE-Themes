using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet.Data;

public struct BlockChange
{
    public Point Location { get; set; }
    public ushort BG0 { get; set; }
    public ushort BG1 { get; set; }
    public ushort BG2 { get; set; }
    public ushort Clip { get; set; }
}
