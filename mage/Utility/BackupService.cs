using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace mage.Utility;

public class BackupService
{
    private readonly Timer _timer;

    public BackupService(double intervalMs)
    {
        _timer = new Timer(intervalMs);
        _timer.Elapsed += DoBackup;
        _timer.AutoReset = true;
    }

    public void Start() => _timer.Start();
    public void Stop() => _timer.Stop();

    private void DoBackup(object? sender, ElapsedEventArgs e)
    {
        if (FormMain.Instance == null) return;
        FormMain.Instance.CreateBackup();
    }
}
