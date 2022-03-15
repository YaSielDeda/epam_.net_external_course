using System;
using System.Text;
using SelfMadeLibrary;

namespace _2._1._1._CUSTOM_STRING
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomString csString1 = new CustomString("new string more than 16 symbols");

            string str = "new string more than 16 symbols";

            char[] charArr = "new string more than 16 symbols".ToCharArray();

            CustomString csString2 = new CustomString("new string more than 16 symbols");

            CustomString csString3 = new CustomString("w string more t");

            Console.WriteLine($"Content: {csString1} {Environment.NewLine}" +
                              $"Capacity: {csString1.Capacity} {Environment.NewLine}" +
                              $"Length: {csString1.Length} {Environment.NewLine}" +
                              $"Literal №4 = {csString1[4]} {Environment.NewLine}" +
                              $"Equals to str = {csString1.Equals(str)} {Environment.NewLine}" +
                              $"Equals to charArr = {csString1.Equals(charArr)} {Environment.NewLine}" +
                              $"Equals to csString2 = {csString1.Equals(csString2)} {Environment.NewLine}" +
                              $"Contains char 'n' = {csString1.Contains('n')} {Environment.NewLine}" +
                              $"Contains substring 'w string more t' = {csString1.Contains("w string more t")} {Environment.NewLine}" +
                              $"Contains csString3 = {csString1.Contains(csString3)} {Environment.NewLine}");

            CustomString csArr = new CustomString(new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j' });

            CustomString csString = new CustomString("    abcdefghj         ");

            csString = csString.Trim();
            
            Console.WriteLine($"Content: {csString} {Environment.NewLine}" +
                              $"Capacity: {csString.Capacity} {Environment.NewLine}" +
                              $"Length: {csString.Length}");

            Console.WriteLine(csString.Clear());

            Console.WriteLine($"Content: {csString} {Environment.NewLine}" +
                              $"Capacity: {csString.Capacity} {Environment.NewLine}" +
                              $"Length: {csString.Length} {Environment.NewLine}");
        }
    }
}
