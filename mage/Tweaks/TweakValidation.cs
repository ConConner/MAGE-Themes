using NCalc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace mage.Tweaks;

public static class TweakValidation
{
    private static void ShowValidationError(string message)
    {
        MessageBox.Show(message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static bool Validate(Tweak tweak)
    {
        foreach (var param in tweak.Parameters)
            if (!ValidateParameter(param)) return false;

        return true;
    }

    private static bool ValidateParameter(TweakParameter param)
    {
        if (param.Type != ParameterType.Value && !InOptions(param.Value, param.Options))
        {
            ShowValidationError($"Current Value {param.Value} is not allowed as defined by the options.");
            return false;
        }

        if (param.Type == ParameterType.Value)
        {
            if (param.Options is not null && param.Options!.Length > 2)
            {
                ShowValidationError($"Parameter of type Value only takes two options: Min Value, Max Value. Supplied: {param.Options.Length}");
                return false;
            }

            try
            {
                var optVals = parseValueOptions(param.Options);
                if (param.Value is not null)
                {
                    if (optVals.min is not null && param.Value < optVals.min) throw new Exception("Value cannot be smaller than Min Value");
                    if (optVals.max is not null && param.Value > optVals.max) throw new Exception("Value cannot be larger than Max Value");
                }
            }
            catch (Exception e)
            {
                ShowValidationError(e.Message);
                return false;
            }
        }

        if (param.Type == ParameterType.Toggle)
        {
            if (param.Options is null || param.Options.Length != 2)
            {
                ShowValidationError($"Parameter of type Toggle requires exactly two options: Toggle Off, Toggle On. Supplied: {param.Options.Length}");
                return false;
            }
        }

        if (param.Type == ParameterType.Selection)
        {
            if (param.Options is null || param.Options.Length % 2 != 0)
            {
                ShowValidationError($"Parameter of type Selection requires options in the following format: Select1, Value1, Select2, Value2...");
                return false;
            }
            for (int i = 1; i < param.Options.Length; i += 2)
            {
                try { evaluate(param.Options[i]); }
                catch
                {
                    ShowValidationError($"Option Value[{i}] is not a number");
                    return false;
                }
            }
        }

        return true;
    }

    private static (int? min, int? max) parseValueOptions(string[]? options)
    {
        if (options is null) return (null, null);

        int? min = null;
        int? max = null;
        if (options.Length >= 1)
            try { min = evaluate(options[0]); }
            catch { throw new Exception("Min Value is not a number"); }
        if (options.Length == 2)
            try { max = evaluate(options[1]); }
            catch { throw new Exception("Max Value is not a number"); }
        return (min, max);
    }

    private static bool InOptions(long? val, string[]? options)
    {
        if (val is null || options is null) return true;

        foreach (var opt in options)
            try { if (evaluate(opt) == val) return true; }
            catch { continue; }

        return false;
    }

    private static int evaluate(string expression)
    {
        Expression ex = new Expression(expression);
        return Convert.ToInt32(ex.Evaluate());
    }
}
