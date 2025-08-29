using mage.Options.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mage.Options;

public static class PageLists
{
    public static List<OptionsPage> ApplicationOptionPages = new()
    {
        new() { Name = "Appearance", Page = new PageAppearance(), RequiresROM = false },
        new() { Name = "Default View", Page = new PageDefaults(), RequiresROM = true },
        new() { Name = "Tools", Page = new PageRom(), RequiresROM=false },
        new() { Name = "Soundpacks", Page = new PageSoundpacks(), RequiresROM = false },
        new() { Name = "Advanced", Page = new PageAdvanced(), RequiresROM=false },
    };

    public static List<OptionsPage> ProjectOptionsPages = new()
    {
        new() { Name = "Overview", Page = new PageOverview(), RequiresROM = true},
    };
}
