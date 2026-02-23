using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace mage.Tweaks;

public class TweakParameter
{
    public string Name { get; set; } = "New Tweak";
    public string? Description { get; set; }
    public long? Value { get; set; }

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public ParameterType Type { get; set; } = ParameterType.Value;
    public string[]? Options { get; set; }
}

public enum ParameterType
{
    Value,
    Toggle,
    Selection,
}
