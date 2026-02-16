using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace mage.Compiling;

internal class ScriptExecutor : IScriptRunner
{
    private static readonly Regex AbsolutePathPattern = new(
        @"^[A-Za-z]:\\[^\x00-\x1F""<>|]+$",
        RegexOptions.Compiled
    );
    private readonly string executable;
    private readonly string? arguments;
    private readonly Action<string> logLine;
    private Process? process;
    private string workingDirectory;

    public string Name => $"External: {executable}";

    public ScriptExecutor(string executable, string? arguments, Action<string> logLine)
    {
        workingDirectory = Path.GetDirectoryName(executable) ?? Environment.CurrentDirectory;

        // Check if powershell
        if (executable.EndsWith(".ps1", StringComparison.OrdinalIgnoreCase))
        {
            var scriptPath = executable;
            this.executable = "powershell";
            this.arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{scriptPath}\" {arguments}";
        }
        else
        {
            this.executable = executable;
            this.arguments = arguments;
        }

        this.logLine = logLine;
    }

    public async Task<ScriptResult> ExecuteAsync(string tempRomPath, CancellationToken ct = default)
    {
        var stdoutLines = new List<string>();
        var stderrLines = new List<string>();

        var args = string.IsNullOrEmpty(arguments)
            ? $"\"{tempRomPath}\""
            : $"{arguments} \"{tempRomPath}\"";

        var psi = new ProcessStartInfo
        {
            FileName = executable,
            Arguments = args,
            UseShellExecute = false,
            WorkingDirectory = workingDirectory,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
        };

        process = new Process { StartInfo = psi, EnableRaisingEvents = true };
        var tcs = new TaskCompletionSource<int>(
            TaskCreationOptions.RunContinuationsAsynchronously
        );

        process.OutputDataReceived += (_, e) =>
        {
            if (e.Data is null) return;
            stdoutLines.Add(e.Data);
            logLine($"> {e.Data}");
        };

        process.ErrorDataReceived += (_, e) =>
        {
            if (e.Data is null) return;
            stdoutLines.Add(e.Data);
            logLine($"[error] {e.Data}");
        };

        process.Exited += (_, _) =>
            tcs.TrySetResult(process.ExitCode);

        ct.Register(() =>
        {
            try { if (!process.HasExited) process.Kill(entireProcessTree: true); }
            catch { }
            tcs.TrySetCanceled(ct);
        });

        process.Start();
        process.BeginOutputReadLine();
        process.BeginErrorReadLine();
        int exitCode = await tcs.Task;

        // Parse ROM Path
        string? romPath = ParseOutputRomPath(stdoutLines);

        if (exitCode != 0)
        {
            return new ScriptResult
            {
                Success = false,
                ExitCode = exitCode,
                Error = string.Join(Environment.NewLine, stderrLines)
            };
        }

        if (romPath is null || !File.Exists(romPath))
        {
            return new ScriptResult
            {
                Success = false,
                ExitCode = exitCode,
                Error = romPath is null
                    ? "Script produced no valid absolute path on stdout."
                    : $"Declared output path does not exist: {romPath}",
            };
        }

        if (!romPath.EndsWith(".gba", StringComparison.OrdinalIgnoreCase))
        {
            string actualExtension = Path.GetExtension(romPath);
            return new ScriptResult()
            {
                Success = false,
                ExitCode = exitCode,
                Error = $"Declared output path is not a .gba file: Expected .gba got {actualExtension}"
            };
        }

        return new ScriptResult
        {
            Success = true,
            ExitCode = 0,
            OutputRomPath = romPath
        };
    }

    private static string? ParseOutputRomPath(List<string> lines)
    {
        for (int i = lines.Count - 1; i >= 0; i--)
        {
            var trimmed = lines[i].Trim();
            if (trimmed.Length == 0) continue;
            if (AbsolutePathPattern.IsMatch(trimmed))
                return trimmed;
            // Stop searching after the first non-empty, non-path line from the bottom.
            break;
        }
        return null;
    }

    public void Dispose()
    {
        process?.Dispose();
        process = null;
    }
}
