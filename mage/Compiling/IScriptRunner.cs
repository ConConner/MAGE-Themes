using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mage.Compiling;

public interface IScriptRunner : IDisposable
{
    Task<ScriptResult> ExecuteAsync(string tempRomPath, CancellationToken ct = default);
    string Name { get; }
}
