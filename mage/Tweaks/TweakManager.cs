using mage.Bookmarks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace mage.Tweaks;

public static class TweakManager
{
    public static List<Tweak> OnlineTweaks { get; set; } = new();
    public static List<Tweak> ProjectTweaks { get; set; } = new();


    // Serializing
    private static JsonSerializerOptions JsonOptions = new JsonSerializerOptions()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
    };
    private static JsonSerializerOptions JsonOptionsIndented = new JsonSerializerOptions()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        AllowTrailingCommas = true,
    };

    public static string Serialize(List<Tweak> tweaks, bool writeIndented = true)
    {
        JsonSerializerOptions options = writeIndented ? JsonOptionsIndented : JsonOptions;
        return JsonSerializer.Serialize(tweaks, options);
    }

    public static List<Tweak> Deserialize(string json) => JsonSerializer.Deserialize<List<Tweak>>(json, JsonOptions);
}
