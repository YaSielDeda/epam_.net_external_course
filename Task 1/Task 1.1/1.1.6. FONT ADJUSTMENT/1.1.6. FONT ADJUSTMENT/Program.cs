using System;
using System.Collections.Generic;

namespace _1._1._6._FONT_ADJUSTMENT
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> allParameters = new List<string> { "Bold", "Italic", "Underline" };
            List<string> choosenParameters = new List<string>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Choose parameter number:");
                for (int i = 0; i < allParameters.Count; i++)
                    Console.WriteLine($"\t{i + 1}: {allParameters[i]}");

                int paramNumber;
                int.TryParse(Console.ReadLine(), out paramNumber);

                if (paramNumber < 0 || paramNumber > allParameters.Count)
                {
                    Console.WriteLine("Illegal parameter number");
                    continue;
                }

                if (paramNumber == 0)
                    break;

                if (choosenParameters.Contains(allParameters[paramNumber - 1]))
                    choosenParameters.Remove(allParameters[paramNumber - 1]);
                else
                    choosenParameters.Add(allParameters[paramNumber - 1]);

                Console.Write("Choosen parameters: ");
                if (choosenParameters.Count == 0)
                    Console.WriteLine("None");
                else
                    for (int i = 0; i < choosenParameters.Count; i++)
                    {
                        Console.Write($"{choosenParameters[i]}");
                        if (i != choosenParameters.Count - 1)
                            Console.Write(", ");
                    }
                Console.WriteLine();
            }
        }
    }
}
