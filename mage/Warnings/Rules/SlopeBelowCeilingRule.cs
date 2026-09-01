using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Warnings.Rules;

public class SlopeBelowCeilingRule : IClipdataRule
{
    public string Name => "Slope below ceiling";
    public string Description => "A slope must not be placed directly below a solid block.";
    public int NeighborhoodRadius => 1;

    public ClipdataError? Check(TileContext ctx)
    {
        var self = ctx.Get(0, 0);
        if (self.CLP < 0x11 || self.CLP > 0x16) return null;

        var above = ctx.Get(0, -1);
        if (above.CLP == 0x10) return new ClipdataError(ctx.X, ctx.Y, this,
            Description);

        return null;
    }
}
