using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    public static class FileListener
    {
        private static string _pathToFolder;
        private static string _pathToLog;
        private static FileSystemWatcher _watcher;
        public static void Init(string pathToFolder, string pathToLog)
        {
            _pathToFolder = pathToFolder;
            _pathToLog = pathToLog;

            if (!Directory.Exists(pathToFolder))
                throw new DirectoryNotFoundException("Directory through this path doesn't found!");

            if (!File.Exists(pathToLog))
                throw new FileNotFoundException("Log file through this path doesn't found!");

            _watcher = new FileSystemWatcher(pathToFolder);

            _watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            _watcher.Changed += OnChanged;
            _watcher.Created += OnCreated;
            _watcher.Deleted += OnDeleted;
            _watcher.Renamed += OnRenamed;

            _watcher.Filter = "*.txt";
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            try
            {
                _watcher.EnableRaisingEvents = false;

                var currentDate = DateTime.Now;
                VersionHandler.CommitChanges(currentDate, _pathToFolder);

                File.AppendAllText(_pathToLog, $"Changed: {e.FullPath}" + Environment.NewLine);
            }
            finally
            {
                _watcher.EnableRaisingEvents = true;
            }
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            try
            {
                _watcher.EnableRaisingEvents = false;

                var currentDate = DateTime.Now;
                VersionHandler.CommitChanges(currentDate, _pathToFolder);

                File.AppendAllText(_pathToLog, $"Created: {e.FullPath}" + Environment.NewLine);
            }
            finally
            {
                _watcher.EnableRaisingEvents = true;
            }
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            try
            {
                _watcher.EnableRaisingEvents = false;

                var currentDate = DateTime.Now;
                VersionHandler.CommitChanges(currentDate, _pathToFolder);

                File.AppendAllText(_pathToLog, $"Deleted: {e.FullPath}" + Environment.NewLine);
            }
            finally
            {
                _watcher.EnableRaisingEvents = true;
            }
        }
            

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            try
            {
                _watcher.EnableRaisingEvents = false;

                var currentDate = DateTime.Now;
                VersionHandler.CommitChanges(currentDate, _pathToFolder);

                File.AppendAllText(_pathToLog, $"Renamed:" + Environment.NewLine +
                                               $"    Old: {e.OldFullPath}" + Environment.NewLine +
                                               $"    New: {e.FullPath}" + Environment.NewLine);
            }
            finally
            {
                _watcher.EnableRaisingEvents = true;
            }
        }
    }
}
