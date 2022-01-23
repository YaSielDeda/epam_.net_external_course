using Logging;
using Serilog;
using System;

namespace _3._1._1._WEAKEST_LINK
{
    class Program
    {
        static void Main()
        {
            Logger.InitializeConsoleLogger();

            Log.Information("Input N: ");
            int.TryParse(Console.ReadLine(), out int N);

            Log.Information("Enter which person number will be removed at every lap: ");
            int.TryParse(Console.ReadLine(), out int removableNumber);

            try
            {
                if (N == 0 || removableNumber == 0)
                    throw new ArgumentException("You have entered invalid data!");

                if (removableNumber > N)
                    throw new ArgumentException("Removable number can't be more than N!");

                int count = 1;

                while (N >= removableNumber - 1)
                {
                    Log.Information($"Round {count}. Man is removed, {N} remaining");
                    N--;
                    count++;
                }

                Log.Information("Game over. Impossible to remove more.");
            }
            catch (Exception ex)
            {
                Log.Fatal(messageTemplate: ex.Message);
            }
        }
    }
}
