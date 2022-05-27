using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8._1_THREE_LAYER.Entities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //User user1 = new User("Vasya", new DateTime(1998, 4, 24));
            //User user2 = new User("Petya", new DateTime(2000, 5, 12));
            User user3 = new User("Vanya", new DateTime(1995, 6, 3));

            //Award award1 = new Award("Binary search expert");
            //Award award2 = new Award("Dynamic programming expert");

            IBLL<User> temp = new UserBLL();

            temp.Create(user3);
            temp.DeleteByID(new Guid("9ad3569f-21f7-4ed1-997e-e7c07f9cbff4"));

            var users = temp.GetAll();

            foreach (var user in users)
            {
                Console.WriteLine(user);
            }
            Console.ReadLine();
        }
    }
}
