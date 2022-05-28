using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities
{
    public class Award
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Award(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
        }

        public override string ToString()
        {
            return  $"ID:\t {Id}\n" +
                    $"Title:\t {Title}\n";
        }
    }
}