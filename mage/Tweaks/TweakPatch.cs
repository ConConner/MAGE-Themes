using System;
using System.Collections.Generic;
using System.Text;

namespace mage.Tweaks;

public class TweakPatch
{
    public string? Offset { get; set; }
    public List<string> Data { get; set; } = [];

    public int? OldOffset { get; set; }
    public List<string>? OldData { get; set; }

    public long ResolveOffset(IReadOnlyDictionary<string, long> parameters) => EvaluateExpression(Offset, parameters);
    public byte[] ResolveData(IReadOnlyDictionary<string, long> parameters) => ResolveByteList(Data, parameters);
    public byte[] ResolveOldData() => ResolveByteList(OldData, null);

    public void SetOldData(byte[] data)
    {
        OldData = new();
        foreach (var b in data) OldData.Add(Hex.ToString(b, 10));
    }

    private byte[] ResolveByteList(List<string> data, IReadOnlyDictionary<string, long> parameters)
    {
        var resultBytes = new List<byte>();

        foreach (var expression in data)
        {
            long value = EvaluateExpression(expression, parameters);
            resultBytes.Add((byte)(value & 0xFF));
        }

        return resultBytes.ToArray();
    }

    private static long EvaluateExpression(string? expression, IReadOnlyDictionary<string, long> parameters)
    {
        if (string.IsNullOrEmpty(expression))
            throw new InvalidOperationException("No expression defined");

        var expr = new NCalc.Expression(expression);
        expr.EvaluateParameter += (name, args) =>
        {
            if (parameters.TryGetValue(name, out var value))
                args.Result = value;
            else
                throw new ArgumentException($"Unknown parameter: {name}");
        };

        return Convert.ToInt64(expr.Evaluate());
    }
}
