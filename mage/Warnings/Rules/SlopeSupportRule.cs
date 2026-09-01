using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Warnings.Rules;

public class SlopeSupportRule : IClipdataRule
{
    public string Name => "Slope lacking support";
    public string Description => "A slope must have supporting solid blocks at the beginning and end of the slope.";
    public int NeighborhoodRadius => 1;

    private readonly int[] LeftFacingSlopes = { 0x12, 0x15, 0x16 };

    private ClipdataError Error(TileContext ctx) => new(ctx.X, ctx.Y, this, Description);

    public ClipdataError? Check(TileContext ctx)
    {
        var self = ctx.Get(0, 0).CLP;
        if (self < 0x11 || self > 0x16) return null;

        bool leftFacing = LeftFacingSlopes.Contains(self);

        //Steep
        var left = ctx.Get(-1, leftFacing ? 0 : 1).CLP;
        var right = ctx.Get(1, leftFacing ? 1 : 0).CLP;

        if ((self == 0x13 || self == 0x15) && left != 0x10) return Error(ctx);
        if ((self == 0x14 || self == 0x16) && right != 0x10) return Error(ctx);

        if (self != 0x11 || self != 0x12) return null;
        if (left != 0x10 || right != 0x10) return Error(ctx);

        return null;
    }
}
