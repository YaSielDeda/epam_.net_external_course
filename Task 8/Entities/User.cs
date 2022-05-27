using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8._1_THREE_LAYER.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public List<Guid> AwardIDs { get; set; }
        public User(string name, DateTime dateTime)
        {
            Id = Guid.NewGuid();
            Name = name;
            DateOfBirth = dateTime;
            Age = DateTime.Now.Year - DateOfBirth.Year;
            AwardIDs = new List<Guid>();
        }
        public User()
        {

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