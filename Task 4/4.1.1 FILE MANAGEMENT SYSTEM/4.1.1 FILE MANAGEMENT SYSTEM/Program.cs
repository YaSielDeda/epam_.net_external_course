using System;
using System.IO;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    class Program
    {
        static void Main(string[] args)
        {
            ModeType mode = ChooseMode();

            string pathToFolder = Environment.CurrentDirectory + @"\TestFolder";

            string pathToLogFile = Environment.CurrentDirectory + @"\Logger.txt";

            string pathToRollbackFile = Environment.CurrentDirectory + @"\Versions.txt";

            if (mode == ModeType.Listen)
            {
                try
                {
                    FileListener.Init(pathToFolder, pathToLogFile);
                    VersionHandler.Init(pathToRollbackFile, pathToFolder);

                    TypeConsoleColoredMessage("Listening directory...", ConsoleColor.Green);
                    Console.WriteLine("Press enter to close programm.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    TypeConsoleColoredMessage(ex.Message, ConsoleColor.Red);
                }
            }
            else if (mode == ModeType.Rollback)
            {
                VersionHandler.Init(pathToRollbackFile, pathToFolder);

                var dates = VersionHandler.GetAvailableRollbackDates();

                int number = ChooseNumberOfDates(dates);

                try
                {
                    VersionHandler.RollbackChanges(dates[number]);
                    TypeConsoleColoredMessage("Files is successfully restored", ConsoleColor.Green);
                }
                catch (Exception ex)
                {
                    TypeConsoleColoredMessage(ex.Message, ConsoleColor.Green);
                }
            }
        }

        private static int ChooseNumberOfDates(DateTime[] dates)
        {
            Console.WriteLine("Choose number of date to rollback");
            for (int i = 1; i <= dates.Length; i++)
            {
                Console.WriteLine($"{i - 1} {dates[i - 1]}");
            }

            int number;
            bool exit;

            do
            {
                int.TryParse(Console.ReadLine(), out number);

                if (number >= 1 && number <= dates.Length)
                {
                    exit = true;
                }
                else
                {
                    TypeConsoleColoredMessage($"Enter number from 1 to {dates.Length - 1}", ConsoleColor.Red);
                    exit = false;
                }

            } while (!exit);
            return number;
        }

        private static ModeType ChooseMode()
        {
            do
            {
                Console.WriteLine($"Mode: {Environment.NewLine}1. Listen {Environment.NewLine}2. Rollback");

                if (int.TryParse(Console.ReadLine(), out int mode) && mode == 1 || mode == 2)
                {
                    switch (mode)
                    {
                        case 1:
                            return ModeType.Listen;
                        case 2:
                            return ModeType.Rollback;
                        default:
                            break;
                    }
                }

                Console.Clear();
                TypeConsoleColoredMessage("Enter 1 or 2!", ConsoleColor.Red);

            } while (true);
        }

        private static void TypeConsoleColoredMessage(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
