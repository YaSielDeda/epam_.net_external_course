using _3._3._3._PIZZA_TIME.Entities;
using System;

namespace _3._3._3._PIZZA_TIME
{
    class Program
    {
        static void Main(string[] args)
        {
            var order1 = new Order(new Client("Vasia"), PizzaType.Diablo);

            var order2 = new Order(new Client("Lena"), PizzaType.Classic);

            var order3 = new Order(new Client("Boris"), PizzaType.Margarita);

            Pizzeria pizzeria = new Pizzeria();

            pizzeria.Subscribe(order1);
            pizzeria.Subscribe(order2);
            pizzeria.Subscribe(order3);

            pizzeria.Baking();
        }
    }
}
