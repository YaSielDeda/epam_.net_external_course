using Dolgov_Task_1._2;
using System;
using System.Linq;

namespace _1._2._3._LOWERCASE
{
    class Program
    {
        //additional task
        static void Main(string[] args)
        {
            Console.Write("Input text: ");
            string text = Console.ReadLine();

            char[] separators = { ',', ';', ':', ' ', '.' };

            string[] spliitedText = text.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                ;

            int numberOfLowerCaseWords = spliitedText.Where(x => x[0].ToString() == x[0].ToString().ToLower()).Count();
            Console.WriteLine(numberOfLowerCaseWords);
        }
    }
}
