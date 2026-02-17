using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace mage.Tweaks;

public class Tweak
{
    public string Name { get; set; }
    public string Author { get; set; }
    public string Description { get; set; }

    [JsonIgnore]
    public bool Applied { get; private set; } = false;

    public List<TweakParameter> Parameters { get; set; } = [];
    public List<TweakPatch> Patches { get; set; } = [];

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

        byte[] expected = patch.OldData;
        int len = expected.Length;

        byte[] current = new byte[len];
        rom.CopyToArray(offset, current, 0, len);

        if (!expected.AsSpan().SequenceEqual(current))
            throw new InvalidOperationException(
                $"Cannot apply tweak '{Name}'. Tweak would overwrite unexpected data"
            );
    }

    private void PopulateOldValues(ByteStream rom, TweakPatch patch, int offset, int len)
    {
        byte[] old = new byte[len];
        rom.CopyToArray(offset, old, 0, len);
        patch.OldData = old;
    }

    public void Apply(ByteStream rom)
    {
        StopIfMissingParameters();

        var paramDict = Parameters.ToDictionary(p => p.Name, p => p.Value!.Value);

        foreach (var patch in Patches)
        {
            var offset = (int)patch.ResolveOffset(paramDict);
            var data = patch.ResolveData(paramDict);

            // Checking if overwriting should be done or saving old values
            if (patch.OldData == null || Parameters.Count != 0) PopulateOldValues(rom, patch, offset, data.Length);
            else CheckIfOverwritingCorrectVals(rom, patch, offset);

            patch.OldOffset = offset;

            // Write patch data
            rom.CopyFromArray(data, 0, offset, data.Length);
        }

        Applied = true;
    }

    public void Revert(ByteStream rom)
    {
        foreach (var patch in Patches)
            if (patch.OldData == null || patch.OldOffset == null) throw new InvalidOperationException(
                $"Cannot revert tweak '{Name}'. There is missing information on the old data"
            );

        foreach (var patch in Patches)
        {
            int offset = patch.OldOffset ?? 0;
            byte[] old = patch.OldData;
            rom.CopyFromArray(old, 0, offset, old.Length);
        }

        Applied = false;
    }
}
