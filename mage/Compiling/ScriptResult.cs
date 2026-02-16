using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Compiling;

public sealed class ScriptResult
{
    public bool Success { get; init; }
    public string? OutputRomPath { get; init; }
    public int ExitCode { get; init; }
    public string? Error { get; init; }
}
