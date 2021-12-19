using System;

namespace _1._1._4._X_MAS_TREE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N = ");
            int n;
            int.TryParse(Console.ReadLine(), out n);

            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j < i * 2; j += 2)
                    Console.WriteLine(new string(' ', n - j / 2) + new string('*', j));
            }
        }
    }
}
