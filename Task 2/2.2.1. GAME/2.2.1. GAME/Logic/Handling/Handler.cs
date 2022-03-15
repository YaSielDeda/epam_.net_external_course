using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._1._GAME.Logic.Handling
{
    public abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest();
    }
}
