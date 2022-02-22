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

            if (mode == ModeType.Watch)
            {
                try
                {
                    FileWatcher.Init(pathToFolder, pathToLogFile);

                    TypeConsoleColoredMessage("Listening directory...", ConsoleColor.Green);
                    Console.WriteLine("Press any key to close programm.");
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    TypeConsoleColoredMessage(ex.Message, ConsoleColor.Red);
                }
            }
            else if (mode == ModeType.Rollback)
            {

            }
        }

        private static ModeType ChooseMode()
        {
            do
            {
                Console.WriteLine($"Mode: {Environment.NewLine}1. Watch {Environment.NewLine}2. Rollback");

                if (int.TryParse(Console.ReadLine(), out int mode) && mode == 1 || mode == 2)
                {
                    switch (mode)
                    {
                        case 1:
                            return ModeType.Watch;
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
