using System;
using System.Linq;
using System.Text;

namespace _1._2._2._DOUBLER
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input string: ");
            string inputString = Console.ReadLine();

            Console.Write("Input doubler string: ");
            string doublerString = Console.ReadLine();

            foreach (char item in doublerString.Distinct())
            {
                if (inputString.Contains(item))
                    inputString = inputString.Replace(item.ToString(), item.ToString() + item.ToString());
            }

            Console.WriteLine($"Result: {inputString}");
        }
    }
}
