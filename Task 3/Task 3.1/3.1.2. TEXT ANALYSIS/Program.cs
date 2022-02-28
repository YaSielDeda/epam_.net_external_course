using Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._1._2._TEXT_ANALYSIS
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input text and then press Enter:");

            try
            {
                char[] separators = { ',', ';', ':', ' ', '.', '-', '!', '?', '(', ')', '\\', '/' };

                bool isValid = false;
                List<string> arr;

                do
                {
                    arr = new(Console.ReadLine().ToLower().Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries));

                    if (arr.Count == 0)
                    {
                        Console.WriteLine("You need to type some words");
                    }
                    else
                    {
                        isValid = true;
                    }

                } while (!isValid);

                Dictionary<string, int> WordCount = new();

                foreach (var word in arr.Distinct())
                    WordCount.Add(word, arr.Where(x => x == word).Count());

                var sortedDictionary = from entry in WordCount 
                                       orderby entry.Value descending select entry;

                bool hasManyRecurringWords = false;

                foreach (var pair in sortedDictionary)
                {
                    if (pair.Value >= 4)
                    {
                        Console.WriteLine($"{pair.Key} - {pair.Value} times");
                        hasManyRecurringWords = true;
                    }
                    else
                        Console.WriteLine($"{pair.Key} - {pair.Value} times");
                }

                if(hasManyRecurringWords)
                    Console.WriteLine("Not bad, but better try to replace some of recurring words with synonims");
                else
                    Console.WriteLine($"Nice, your text looks clean from recurring words!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
    }
}
