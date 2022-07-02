using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Award
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Award(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }
        public Award()
        {

        }

        public override string ToString()
        {
            return  $"ID:\t {Id}\n" +
                    $"Title:\t {Title}\n";
        }
    }
}