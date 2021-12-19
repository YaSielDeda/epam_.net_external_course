using System;

namespace _1._1._2._TRIANGLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N = ");
            int n;
            int.TryParse(Console.ReadLine(), out n);

            for (int i = 0; i <= n; i++)
                Console.WriteLine(new string('*', i));
        }
    }
}
