using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Utility;

public static class MathFunctions
{
    public static int FloorTo(int value, int step) =>
        (int)Math.Floor(value / (double)step) * step;

    public static int CeilTo(int value, int step) =>
        (int)Math.Ceiling(value / (double)step) * step;
}
