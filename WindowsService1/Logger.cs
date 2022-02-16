using System;
using System.IO;
using System.Threading;

namespace FolderLoggerService
{
    public class Logger
    {
        private readonly FileSystemWatcher _watcher;
        private readonly object _locker = new object();
        private bool _isEnabled = true;
        public Logger()
        {
            _watcher = new FileSystemWatcher("C:\\Temp");
            _watcher.Deleted += (o,e)=> RecordEntry("deleted", e.FullPath);
            _watcher.Created += (o, e) => RecordEntry("created", e.FullPath);
            _watcher.Changed += (o, e) => RecordEntry("changed", e.FullPath);
            _watcher.Renamed += (o, e) => RecordEntry("renamed in " + e.FullPath, e.OldFullPath);
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
            while (_isEnabled)
                Thread.Sleep(1000);
        }
        public void Stop()
        {
            _watcher.EnableRaisingEvents = false;
            _isEnabled = false;
        }

        private void RecordEntry(string fileEvent, string filePath)
        {
            lock (_locker)
            {
                using (var writer = new StreamWriter("C:\\log.txt", true))
                {
                    writer.WriteLine($"{DateTime.Now:dd/MM/yyyy hh:mm:ss} file {filePath} {fileEvent}");
                    writer.Flush();
                }
            }
        }
    }
}
