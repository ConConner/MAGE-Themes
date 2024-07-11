using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageNet;

public static class Config
{
    public static int MaximumPacketSize { get; set; } = 8192;
    public static bool AllowMinorRollForward { get; set; } = false;
}
