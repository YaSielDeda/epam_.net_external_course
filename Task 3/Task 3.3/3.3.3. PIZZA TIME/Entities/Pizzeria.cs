using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _3._3._3._PIZZA_TIME.Entities
{
    public class Pizzeria
    {
        public event Action PizzaStatus = delegate { };
        public void Subscribe(Order order) => PizzaStatus += order.OrderIsDone;
        public void Unsubscribe(Order order) => PizzaStatus -= order.OrderIsDone;
        public void Baking()
        {
            Console.WriteLine("Orders is accepted! Baking pizzas...");

            Thread.Sleep(3000);
            PizzaStatus();
        }
    }
}
