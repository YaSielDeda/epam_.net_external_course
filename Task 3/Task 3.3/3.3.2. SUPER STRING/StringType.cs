using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3._3._2._SUPER_STRING
{
    [Flags]
    public enum StringType
    {
        None = 0,
        Russian = 1,
        English = 2,
        Number = 4,
        Mixed = 8
    }
}
