using System;

namespace _1._1._10._2D_ARRAY
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[,] arr = new int[n, n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = random.Next(-100, 100);
                }
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if ((i + j) % 2 == 0)
                        sum += arr[i, j];
                }
            }

            Console.WriteLine($"sum = {sum}");
        }
    }
}
