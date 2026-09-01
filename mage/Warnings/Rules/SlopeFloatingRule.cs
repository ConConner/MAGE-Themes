using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Warnings.Rules;

public class SlopeFloatingRule : IClipdataRule
{
    public string Name => "Slope floating";
    public string Description => "A slope must not be placed without a solid block below it.";
    public int NeighborhoodRadius => 1;

    public ClipdataError? Check(TileContext ctx)
    {
        var self = ctx.Get(0, 0);
        if (self.CLP < 0x11 || self.CLP > 0x16) return null;

        var below = ctx.Get(0, 1);
        if (below.CLP != 0x10) return new ClipdataError(ctx.X, ctx.Y, this,
            Description);

        return null;
    }
}
