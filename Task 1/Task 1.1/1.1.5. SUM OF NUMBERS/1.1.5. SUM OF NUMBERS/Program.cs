using System;

namespace _1._1._5._SUM_OF_NUMBERS
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            for (int i = 3; i < 1000; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                    sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}
