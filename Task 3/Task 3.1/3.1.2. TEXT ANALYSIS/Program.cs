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
            Logger.InitializeConsoleLogger();

            Log.Information("Input text and then press Enter:");

            try
            {
                char[] separators = { ',', ';', ':', ' ', '.', '-', '!', '?', '(', ')', '\\', '/' };
                List<string> arr = new(Console.ReadLine().ToLower().Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries));

                if (arr.Count == 0)
                    throw new ArgumentNullException();

                List<KeyValuePair<int, string>> keyWordValueTimes = new();

                foreach (var word in arr.Distinct())
                    keyWordValueTimes.Add(new KeyValuePair<int, string>(arr.Where(x => x == word).Count(), word));

                var sortedDictionary = from entry in keyWordValueTimes 
                                       orderby entry.Key descending select entry;

                bool hasManyRecurringWords = false;

                foreach (var pair in sortedDictionary)
                {
                    if (pair.Key >= 4)
                    {
                        Log.Warning($"{pair.Key} times - {pair.Value}");
                        hasManyRecurringWords = true;
                    }
                    else
                        Log.Information($"{pair.Key} times - {pair.Value}");
                }

                if(hasManyRecurringWords)
                    Log.Information("Not bad, but better try to replace some of recurring words with synonims");
                else
                    Log.Information($"Nice, your text looks clean from recurring words!");
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }   
        }
    }
}
