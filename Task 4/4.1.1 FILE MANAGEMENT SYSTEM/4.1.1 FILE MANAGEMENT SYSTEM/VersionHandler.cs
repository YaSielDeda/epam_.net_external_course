using System;
using System.IO;
using System.Linq;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    public static class VersionHandler
    {
        private static string _pathToRollbackFile;
        private static string _pathToRootFolder;
        public static void Init(string pathToRollbackFile, string pathToRootFolder)
        {
            _pathToRollbackFile = pathToRollbackFile;
            _pathToRootFolder = pathToRootFolder;
        }
        public static void CommitChanges(DateTime dateTime, string pathToDir)
        {
            File.AppendAllText(_pathToRollbackFile, dateTime.ToString() + Environment.NewLine);
            GetDirectoryAndFilesInfo(new DirectoryInfo(pathToDir), 0);

            void GetDirectoryAndFilesInfo(DirectoryInfo directory, int level)
            {
                if (directory.FullName == _pathToRootFolder)
                    foreach (var file in directory.GetFiles())
                        File.AppendAllText(_pathToRollbackFile, $"{file.FullName}~ {File.ReadAllTextAsync(file.FullName).Result + Environment.NewLine}");

                var dirs = new DirectoryInfo(directory.FullName).GetDirectories();

                foreach (var dir in dirs)
                {
                    File.AppendAllText(_pathToRollbackFile, $"{new string(' ', level * 2)} {dir.FullName + Environment.NewLine}");
                    GetDirectoryAndFilesInfo(dir, level + 1);

                    foreach (var file in dir.GetFiles())
                    {
                        File.AppendAllText(_pathToRollbackFile, $"{new string(' ', (level + 1) * 2)} {file.FullName}~ {File.ReadAllTextAsync(file.FullName).Result + Environment.NewLine}");
                    }
                }
            }
        }

        public static void RollbackChanges(DateTime dateTime)
        {
            CleanDirectory();

            var rawStrings = File.ReadAllLines(_pathToRollbackFile);

            var changeLines = rawStrings.SkipWhile(str => DateTime.TryParse(str, out DateTime dt) == false || dt != dateTime)
                                        .Skip(1).TakeWhile(str => DateTime.TryParse(str, out DateTime dt) == false)
                                        .ToArray();

            foreach (var str in changeLines)
            {
                if (str.Contains(".txt"))
                {
                    var path = new string(str.TakeWhile(symbol => symbol != '~').ToArray()).Trim();

                    string text = new string(str.SkipWhile(symbol => symbol != '~').Skip(1)
                                                .TakeWhile(symbol => symbol != '\n').ToArray()).Trim();

                    File.WriteAllText(path, text);
                }
                else
                {
                    Directory.CreateDirectory(str.Trim());
                }
            }
        }

        private static void CleanDirectory()
        {
            var directoryInfo = new DirectoryInfo(_pathToRootFolder);
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static DateTime[] GetAvailableRollbackDates()
        {
            var rawStrings = File.ReadAllLines(_pathToRollbackFile);

            DateTime[] dates = Array.ConvertAll<string, DateTime>(
                rawStrings.Where(str => DateTime.TryParse(str, out DateTime dt)).ToArray(),
                dt => {
                    DateTime d = Convert.ToDateTime(dt);
                    return d;
                });

            return dates;
        }
    }
}
