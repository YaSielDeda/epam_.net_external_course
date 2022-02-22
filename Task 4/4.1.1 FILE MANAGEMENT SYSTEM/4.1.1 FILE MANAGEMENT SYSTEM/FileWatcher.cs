using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    public static class FileWatcher
    {
        private static string _pathToFolder;
        private static string _pathToLog;
        private static FileSystemWatcher watcher;

        public static void Init(string pathToFolder, string pathToLog)
        {
            _pathToFolder = pathToFolder;
            _pathToLog = pathToLog;

            if (!Directory.Exists(pathToFolder))
                throw new DirectoryNotFoundException("Directory through this path doesn't found!");

            if (!File.Exists(pathToLog))
                throw new FileNotFoundException("Log file through this path doesn't found!");

            watcher = new FileSystemWatcher(pathToFolder);

            watcher.NotifyFilter = NotifyFilters.Attributes
                                 | NotifyFilters.CreationTime
                                 | NotifyFilters.DirectoryName
                                 | NotifyFilters.FileName
                                 | NotifyFilters.LastAccess
                                 | NotifyFilters.LastWrite
                                 | NotifyFilters.Security
                                 | NotifyFilters.Size;

            watcher.Changed += OnChanged;
            watcher.Created += OnCreated;
            watcher.Deleted += OnDeleted;
            watcher.Renamed += OnRenamed;
            watcher.Error += OnError;

            watcher.Filter = "*.txt";
            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;
        }
        private static void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed)
            {
                return;
            }

            File.AppendAllText(_pathToLog, $"Changed: {e.FullPath}" + Environment.NewLine);
        }

        private static void OnCreated(object sender, FileSystemEventArgs e)
        {
            File.AppendAllText(_pathToLog, $"Created: {e.FullPath}" + Environment.NewLine);
        }

        private static void OnDeleted(object sender, FileSystemEventArgs e)
        {
            File.AppendAllText(_pathToLog, $"Deleted: {e.FullPath}" + Environment.NewLine);
        }
            

        private static void OnRenamed(object sender, RenamedEventArgs e)
        {
            File.AppendAllText(_pathToLog, $"Renamed:" + Environment.NewLine +
                                           $"    Old: {e.OldFullPath}" + Environment.NewLine +
                                           $"    New: {e.FullPath}" + Environment.NewLine);
        }

        private static void OnError(object sender, ErrorEventArgs e) =>
            PrintException(e.GetException());

        private static void PrintException(Exception? ex)
        {
            if (ex != null)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine("Stacktrace:");
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine();

                PrintException(ex.InnerException);
            }
        }
    }
}
