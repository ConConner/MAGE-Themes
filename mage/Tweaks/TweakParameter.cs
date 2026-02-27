using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace mage.Tweaks;

public class TweakParameter
{
    public string Name { get; set; } = "new_parameter";
    public string? DisplayName { get; set; }
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
