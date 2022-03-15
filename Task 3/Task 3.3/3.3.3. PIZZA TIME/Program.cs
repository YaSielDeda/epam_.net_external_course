using _3._3._3._PIZZA_TIME.Entities;
using System;

namespace _3._3._3._PIZZA_TIME
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var vasya = new Client("Vasia");

            var lena = new Client("Lena");

            var boris = new Client("Boris");

            Pizzeria pizzeria = new Pizzeria();

            Console.WriteLine("Pizzeria is open and waiting for orders!");

            Thread.Sleep(1700);

            await pizzeria.MakeOrder(PizzaType.Diablo, vasya);

            Thread.Sleep(1500);

            await pizzeria.MakeOrder(PizzaType.Classic, lena);

            Thread.Sleep(3000);

            await pizzeria.MakeOrder(PizzaType.Margarita, boris);
        }
    }
}
