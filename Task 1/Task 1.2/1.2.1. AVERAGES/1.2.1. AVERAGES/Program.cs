using Dolgov_Task_1._2;
using System;
using System.IO;
using System.Linq;

namespace _1._2._1._AVERAGES
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter sentence: ");
            string[] arrFromText = Console.ReadLine().Split();

            // Целочисленное среднее
            int average = arrFromText.Sum(x => x.Length) / arrFromText.Length;
            Console.WriteLine(average);
        }
    }
}
