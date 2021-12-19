using System;

namespace _1._1._3._ANOTHER_TRIANGLE
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("N = ");
            int n;
            int.TryParse(Console.ReadLine(), out n);

            for (int i = 1; i < n * 2; i += 2)
                Console.WriteLine(new string(' ', n - i / 2) + new string('*', i));            
        }
    }
}
