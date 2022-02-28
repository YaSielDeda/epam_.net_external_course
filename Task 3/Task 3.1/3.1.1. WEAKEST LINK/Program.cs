using Logging;
using Serilog;
using System;

namespace _3._1._1._WEAKEST_LINK
{
    class Program
    {
        static void Main()
        {
            bool isValidationCorrect = false;

            int N = 0;
            int removableNumber = 0;

            do
            {
                Console.Write($"Input N: ");
                N = InputValidation();

                Console.Write($"Input removable number: ");
                removableNumber = InputValidation();

                if (removableNumber > N)
                {
                    Console.WriteLine("Removable number can't be more than N!");
                }
                else
                {
                    isValidationCorrect = true;
                }

            } while (!isValidationCorrect);

            int count = 1;

            while (N >= removableNumber - 1)
            {
                Console.WriteLine($"Round {count}. Man is removed, {N} remaining");
                N--;
                count++;
            }

            Console.WriteLine("Game over. Impossible to remove more.");
        }

        private static int InputValidation()
        {
            bool isValid = false;
            int number = 0;

            do
            {
                isValid = int.TryParse(Console.ReadLine(), out number) && number != 0;

                if (!isValid)
                    Console.WriteLine("You have entered invalid data!");

            } while (!isValid);

            return number;
        }
    }
}
