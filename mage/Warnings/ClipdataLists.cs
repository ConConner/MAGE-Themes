using System;
using System.Collections.Frozen;
using System.Collections.Generic;
using System.Text;

namespace mage.Warnings;

public static class ClipdataLists
{
    private static bool mf => Version.IsMF;

    // SOLID
    private static readonly FrozenSet<int> zmSolidClip =
        new[] { 0x10 }.ToFrozenSet();
    private static readonly FrozenSet<int> mfSolidClip =
        new[] { 0x10 }.ToFrozenSet();
    public static bool IsSolid(this Block b)
        => mf ? mfSolidClip.Contains(b.CLP) : zmSolidClip.Contains(b.CLP);

    // SLOPES
    private static readonly FrozenSet<int> slopeClip =
        new[] { 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 }.ToFrozenSet();
    public static bool IsSlope(this Block b) => slopeClip.Contains(b.CLP);

    private static readonly FrozenSet<int> slightSlopeClip =
        new[] { 0x13, 0x14, 0x15, 0x16 }.ToFrozenSet();
    public static bool IsSlightSlope(this Block b) => slightSlopeClip.Contains(b.CLP);

    private static readonly FrozenSet<int> leftFacingSlopeClip =
        new[] { 0x12, 0x15, 0x16 }.ToFrozenSet();
    public static bool IsLeftFacingSlope(this Block b) => leftFacingSlopeClip.Contains(b.CLP);
    public static bool IsRightFacingSlope(this Block b) => b.IsSlope() && !leftFacingSlopeClip.Contains(b.CLP);

    private static readonly FrozenSet<int> ceilingSlopeClip =
        new[] { 0x21, 0x22, 0x23, 0x24, 0x25, 0x26 }.ToFrozenSet();
    public static bool IsCeilingSlope(this Block b) => ceilingSlopeClip.Contains(b.CLP);
}
