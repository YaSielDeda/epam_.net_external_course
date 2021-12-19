using System;

namespace _1._1._8._NO_POSITIVE
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 10;
            int[,,] arr = new int[n, n, n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        arr[i, j, k] = random.Next(-100, 100);
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        if (arr[i, j, k] > 0)
                            arr[i, j, k] = 0;
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        Console.Write($"{arr[i, j, k]} ");
                    }
                }
            }
        }
    }
}
