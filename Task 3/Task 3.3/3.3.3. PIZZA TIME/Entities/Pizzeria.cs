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
        private InfoTable _infoTable;
        public Pizzeria()
        {
            _infoTable = new InfoTable();
        }
        public event Action<Client, PizzaType> PizzaStatus = delegate { };
        private void Unsubscribe() => PizzaStatus -= _infoTable.OrderIsDoneNotification;
        async public Task MakeOrder(PizzaType pizza, Client client)
        {
            Console.WriteLine($"{client.Name} order is accepted!");

            PizzaStatus += _infoTable.OrderIsDoneNotification;

            await Task.Run(() => Baking(client, pizza));
        }
        private void Baking(Client client, PizzaType pizza)
        {
            Thread.Sleep(3000);
            
            PizzaStatus(client, pizza);

            Unsubscribe();
        }
    }
}
