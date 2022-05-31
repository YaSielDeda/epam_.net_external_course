using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public User(string name, DateTime dateTime)
        {
            checkFuture(dateTime);

            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateTime;
            Age = DateTime.Now.Year - DateOfBirth.Year;
        }

        private static void checkFuture(DateTime dateTime)
        {
            if (dateTime > DateTime.Now)
                throw new Exception("Are you from future?");
        }

        public User()
        {

        }
        public void UpdateDateOfBirth(DateTime dateTime)
        {
            checkFuture(dateTime);
            DateOfBirth = dateTime;
            Age = DateTime.Now.Year - DateOfBirth.Year;
        }
        public override string ToString()
        {
            return  $"ID:\t{Id}\n" +
                    $"Name:\t{Name}\n" +
                    $"Date:\t{DateOfBirth}\n" +
                    $"Age:\t{Age}\n";
        }
    }
}