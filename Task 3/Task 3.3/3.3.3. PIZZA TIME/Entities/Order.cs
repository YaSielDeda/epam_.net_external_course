using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._3._PIZZA_TIME.Entities
{
    public class Order
    {
        public PizzaType PizzaType { get; set; }
        public Client Client { get; set; }
        public Order(Client client, PizzaType pizzaType)
        {
            Client = client;
            PizzaType = pizzaType;
        }
        public void OrderIsDone()
        {
            Console.WriteLine($"{PizzaType} for {Client.Name} is done!");
        }
    }
}
