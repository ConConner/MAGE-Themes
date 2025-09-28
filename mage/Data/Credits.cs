using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Data;

public enum CreditsEntryType : byte
{
    LineBreak = 5,
    TextBlue = 0,
    TextRed = 1,
    TextWhiteLarge = 2,
    TextWhiteSmall = 3,
    GraphicAllRights = 0xA,
    GraphicCopyright = 0xB,
    GraphicScenario = 0xC,
    GraphicReserved = 0xD,
    Stop = 6,
}

public class CreditsEntry
{
    public CreditsEntry(byte[] data)
    {
        if (data.Length != 36) throw new ArgumentException("Data for Credits Entry needs to be 36", nameof(data));
        Type = (CreditsEntryType)data[0];
        Text = Encoding.ASCII.GetString(data, 1, 35).Replace("\0", "");
    }
    public CreditsEntry(CreditsEntryType type, string text)
    {
        this.Type = type;
        this.Text = text;
    }
    public CreditsEntry()
    {
        this.Type = CreditsEntryType.LineBreak;
        this.Text = string.Empty;
    }

    public CreditsEntryType Type { get; set; }
    public string Text
    {
        get => _text;
        set
        {
            if (value == null) return;
            if (value.Length > 35) throw new ArgumentException("Text too long. Max is 35", nameof(Text));
            _text = value;
        }
    }
    private string _text;

    public byte[] Data
    {
        get
        {
            byte[] result = new byte[36];
            result[0] = (byte)Type;
            Array.Copy(Encoding.ASCII.GetBytes(Text), 0, result, 1, Text.Length);
            return result;
        }
    }
}

public class Credits
{
    public BindingList<CreditsEntry> Entries { get; set; }
    public int Length => Entries.Count * entryLength;

    private const int entryLength = 36;
    private int originalLength;
    private int offset;

    public Credits(ByteStream rom, int offset)
    {
        this.offset = offset;
        Entries = new();
        loadEntries(Entries, rom, offset);
        originalLength = Entries.Count * entryLength;
    }

    private void loadEntries(BindingList<CreditsEntry> entries, ByteStream rom, int offset)
    {
        try
        {
            bool reachedEnd = false;
            int i = 0;
            while (!reachedEnd)
            {
                int currentOffset = offset + i * entryLength;
                byte[] line = new byte[entryLength];

                rom.CopyToArray(currentOffset, line, 0, 36);
                CreditsEntry entry = new CreditsEntry(line);
                entries.Add(entry);

                if (entry.Type == CreditsEntryType.Stop)
                    reachedEnd = true;
                i++;
                if (entries.Count > 500) throw new Exception();
            }
        }
        catch
        {
            MessageBox.Show("Credits could not be loaded. Maybe the data is corrupt.", "Loading error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Entries.Clear();
        }
    }

    public void Write(ByteStream rom)
    {
        if (Entries.Count == 0) return;
        byte[] data = new byte[Length];
        for (int i = 0; i < Entries.Count; i++)
        {
            CreditsEntry entry = Entries[i];
            byte[] entryData = entry.Data;

            int currentOffset = i * entryLength;
            Array.Copy(entryData, 0, data, currentOffset, entryLength);
        }

        ByteStream dataStream = new(data);
        int offsetCopy = offset;
        rom.Write2(dataStream, originalLength, ref offsetCopy, true);
    }
}
