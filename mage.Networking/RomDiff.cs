namespace mage.Networking;

/// <summary>One contiguous run of changed bytes: [Offset, Offset + Data.Length) in the target buffer.</summary>
public sealed class RomDiffRecord
{
    public uint Offset;
    public byte[] Data = [];
}

/// <summary>
/// Generic binary diff/patch, generic over any two same-purpose byte buffers -
/// no knowledge of ROMs or games. Used to sync a coworking peer's edited ROM
/// from a shared vanilla baseline without ever transferring the (copyrighted)
/// baseline itself: only the bytes that differ cross the network.
/// Record-at-a-time read/write so a producer can stream records as it scans
/// instead of materializing the whole diff before sending.
/// </summary>
public static class RomDiff
{
    /// <summary>
    /// Yields one record per maximal run of differing bytes. Assumes `modified`
    /// is not shorter than `baseline` (true for MAGE's ROMs, which only grow).
    /// </summary>
    public static IEnumerable<RomDiffRecord> Generate(byte[] baseline, byte[] modified)
    {
        int shared = Math.Min(baseline.Length, modified.Length);
        int i = 0;
        while (i < shared)
        {
            if (baseline[i] == modified[i]) { i++; continue; }

            int start = i;
            while (i < shared && baseline[i] != modified[i]) { i++; }

            byte[] data = new byte[i - start];
            Array.Copy(modified, start, data, 0, data.Length);
            yield return new RomDiffRecord { Offset = (uint)start, Data = data };
        }

        if (modified.Length > baseline.Length)
        {
            int start = baseline.Length;
            byte[] data = new byte[modified.Length - start];
            Array.Copy(modified, start, data, 0, data.Length);
            yield return new RomDiffRecord { Offset = (uint)start, Data = data };
        }
    }

    /// <summary>Applies records on top of a copy of `baseline`, growing the buffer if a record extends past its end.</summary>
    public static byte[] Apply(byte[] baseline, IEnumerable<RomDiffRecord> records)
    {
        byte[] result = (byte[])baseline.Clone();
        foreach (RomDiffRecord record in records)
        {
            int end = (int)record.Offset + record.Data.Length;
            if (end > result.Length) { Array.Resize(ref result, end); }
            Array.Copy(record.Data, 0, result, (int)record.Offset, record.Data.Length);
        }
        return result;
    }

    public static void WriteRecord(BinaryWriter writer, RomDiffRecord record)
    {
        writer.Write(true); // more records follow
        writer.Write(record.Offset);
        writer.Write(record.Data.Length);
        writer.Write(record.Data);
    }

    public static void WriteEnd(BinaryWriter writer) => writer.Write(false);

    /// <summary>Reads one record, or null at the end marker. Caller drives the read loop.</summary>
    public static RomDiffRecord? ReadRecord(BinaryReader reader)
    {
        if (!reader.ReadBoolean()) { return null; }

        uint offset = reader.ReadUInt32();
        int length = reader.ReadInt32();
        return new RomDiffRecord { Offset = offset, Data = reader.ReadBytes(length) };
    }
}
