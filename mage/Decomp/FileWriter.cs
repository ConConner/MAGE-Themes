using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mage.Decomp;

public static class FileWriter
{
    public static void WriteToFile(string filePath, string content)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        File.WriteAllText(filePath, content);
    }

    public static void WriteToFile(string filePath, ByteStream content)
    {
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        BinaryWriter bw = new BinaryWriter(File.Open(filePath, FileMode.Create));
        bw.Write(content.Data, 0, content.Length);
        bw.Close();
    }
}
