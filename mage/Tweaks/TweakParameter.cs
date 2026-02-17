using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Tweaks;

public class TweakParameter
{
    public string Name { get; set; } = "New Tweak";
    public string? Description { get; set; }
    public long? Value { get; set; }
    public long? MinValue { get; set; }
    public long? MaxValue { get; set; }
}
