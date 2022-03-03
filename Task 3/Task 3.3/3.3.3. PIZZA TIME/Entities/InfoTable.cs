using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._3._PIZZA_TIME.Entities
{
    public class InfoTable
    {
        public void OrderIsDoneNotification(Client client, PizzaType pizza)
        {
            Console.WriteLine($"{client.Name}, your {pizza} is ready!");
        }
    }
}
