using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows.Forms;

namespace mage.Tweaks;

public class Tweak
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string? Description { get; set; }

    public string[]? Tags { get; set; }

    public bool Applied { get; set; } = false;

    public List<TweakParameter> Parameters { get; set; } = [];
    public List<TweakPatch> Patches { get; set; } = [];

    [JsonIgnore]
    public bool HasDynamicPatchLocation
    {
        get
        {
            foreach (var patch in Patches)
                try { Hex.ToInt(patch.Offset); }
                catch { return true; }
            return false;
        }
    }

    private void StopIfMissingParameters()
    {
        var missingParams = Parameters
            .Where(p => p.Value == null)
            .Select(p => p.Name)
            .ToList();

        if (missingParams.Any())
        {
            throw new InvalidOperationException(
                $"Cannot apply tweak '{Name}'. Missing values for: {string.Join(", ", missingParams)}"
            );
        }
    }

    private void CheckIfOverwritingCorrectVals(ByteStream rom, TweakPatch patch, int offset)
    {
        if (patch.OldData == null) return;

        byte[] expected = patch.ResolveOldData();
        int len = expected.Length;

        byte[] current = new byte[len];
        rom.CopyToArray(offset, current, 0, len);

        if (!expected.AsSpan().SequenceEqual(current))
            throw new InvalidOperationException(
                $"Cannot apply tweak '{Name}'. Tweak would overwrite unexpected data"
            );
    }

    public void Apply(ByteStream rom)
    {
        StopIfMissingParameters();

        var paramDict = Parameters.ToDictionary(p => p.Name, p => p.Value!.Value);

        Dictionary<int, byte[]> Backup = new();

        try
        {
            foreach (var patch in Patches)
            {
                var offset = (int)patch.ResolveOffset(paramDict);
                var data = patch.ResolveData(paramDict);

                // Add to backup, in case something fails
                byte[] old = new byte[data.Length];
                rom.CopyToArray(offset, old, 0, old.Length);
                patch.OldOffset = offset;

                // Checking if overwriting should be done or saving old values
                if (patch.OldData == null || HasDynamicPatchLocation) patch.SetOldData(old);
                else CheckIfOverwritingCorrectVals(rom, patch, offset);

                // Write patch data
                rom.CopyFromArray(data, 0, offset, data.Length);
            }
        }
        catch (Exception e)
        {
            MessageBox.Show($"Tweak could not be appplied.\n\n{e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            foreach (var kvp in Backup)
                rom.CopyFromArray(kvp.Value, 0, kvp.Key, kvp.Value.Length);
            Applied = false;
            return;
        }

        Applied = true;
    }

    public void Revert(ByteStream rom)
    {
        foreach (var patch in Patches)
            if (patch.OldData == null || patch.OldOffset == null) throw new InvalidOperationException(
                $"Cannot revert tweak '{Name}'. No old data available."
            );

        foreach (var patch in Patches)
        {
            int offset = patch.OldOffset ?? 0;
            byte[] old = patch.ResolveOldData();
            rom.CopyFromArray(old, 0, offset, old.Length);
        }

        Applied = false;
    }
}
