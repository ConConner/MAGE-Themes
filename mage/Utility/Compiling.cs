using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mage.Utility;

public static class Compiling
{
    public static (int ExitCode, string Error) Compile(string romPath, string scriptPath, string outputName)
    {
        (int, string) output = new();
        ProcessStartInfo psi = new()
        {
            FileName = scriptPath,
            Arguments = $"\"{romPath}\" \"{outputName}\"",
            UseShellExecute = true,
            RedirectStandardError = true,
            CreateNoWindow = false
        };

        using (var proc = Process.Start(psi))
        {
            proc.WaitForExit();
            output.Item1 = proc.ExitCode;
            output.Item2 = proc.StandardError.ReadToEnd();
        }
        return output;
    }
}
