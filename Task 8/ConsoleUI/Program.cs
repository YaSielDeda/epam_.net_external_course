using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            IBLL<Award> temp = new AwardBLL();

            var awards = temp.GetAll();

            foreach (var user in awards)
            {
                Console.WriteLine(user);
            }
            Console.ReadLine();
        }
    }
}
