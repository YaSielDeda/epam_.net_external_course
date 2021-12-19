using System;

namespace _1._1._9._NON_NEGATIVE_SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            int[] arr = new int[n];
            Random random = new Random();

            for (int i = 0; i < n; i++)
            {
                arr[i] = random.Next(-100, 100);
            }

            int sum = 0;

            foreach (var item in arr)
            {
                if (item > 0)
                    sum += item;
            }

            Console.WriteLine($"sum = {sum}");
        }
    }
}
