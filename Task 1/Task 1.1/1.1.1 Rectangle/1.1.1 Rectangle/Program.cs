using _1._1._1_Rectangle.Entities;
using System;

namespace _1._1._1_Rectangle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("a = ");
            int a;
            int.TryParse(Console.ReadLine(), out a);

            Console.Write("b = ");
            int b;
            int.TryParse(Console.ReadLine(), out b);

            try
            {
                Rectangle rectangle = new Rectangle(a, b);
                Console.Write($"Square = {rectangle.Square}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
