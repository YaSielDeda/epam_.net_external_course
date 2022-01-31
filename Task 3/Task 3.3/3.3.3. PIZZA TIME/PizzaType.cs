using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._3._PIZZA_TIME
{
    [Flags]
    public enum PizzaType
    {
        None = 0,
        Classic = 1,
        Diablo = 2,
        Sea = 4,
        Margarita = 8
    }
}
