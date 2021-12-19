using System;

namespace _1._1._7._ARRAY_PROCESSING
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100;
            Random rand = new Random();
            int[] arr = new int[n];

            for (int i = 0; i < n; i++)
            {
                arr[i] = rand.Next(0, 1000);
            }

            int min = arr[0];
            int max = arr[0];
            int temp;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[i] > arr[j])
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }

                if (min > arr[i])
                    min = arr[i];
                if (max < arr[i])
                    max = arr[i];
            }

            Console.WriteLine($"min = {min}");
            Console.WriteLine($"max = {max}");
            Console.WriteLine("Sorted array:");
            foreach (var item in arr)
            {
                Console.Write($"{item} ");
            }
        }
    }
}
