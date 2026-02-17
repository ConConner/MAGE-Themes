using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Tweaks;

public static class TweakManager
{
    public static List<Tweak> IncludedTweaks { get; set; } = new();
    public static List<Tweak> ProjectTweaks { get; set; } = new();
}
