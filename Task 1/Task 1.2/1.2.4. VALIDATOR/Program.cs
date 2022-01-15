using Dolgov_Task_1._2;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _1._2._4._VALIDATOR
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input text: ");
            string text = Console.ReadLine();

            string separators = @"([!?.])";

            string[] arrFromText = Regex.Split(text, separators);

            StringBuilder result = GetEverySenteceCapitalized(arrFromText);

            Console.WriteLine(result.ToString());
        }

        private static StringBuilder GetEverySenteceCapitalized(string[] arrFromText)
        {
            var res = new StringBuilder();

            for (int i = 0; i < arrFromText.Length; i++)
            {
                for (int j = 0; j < arrFromText[i].Length; j++)
                {
                    if (arrFromText[i][j] != ' ')
                    {
                        res.Append(arrFromText[i][j].ToString().ToUpper());
                        res.Append(arrFromText[i].Substring(j + 1));
                        break;
                    }
                    else
                        res.Append(arrFromText[i][j]);
                }
            }

            return res;
        }
    }
}
