using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_8._1_THREE_LAYER.Entities
{
    public class Award
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public List<Guid> UserIDs { get; private set; }
        public Award(string title)
        {
            Id = Guid.NewGuid();
            Title = title;
            UserIDs = new List<Guid>();
        }
    }
}