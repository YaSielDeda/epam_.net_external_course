using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4._1._1_FILE_MANAGEMENT_SYSTEM
{
    [Flags]
    public enum ModeType
    {
        None = 0,
        Listen = 1,
        Rollback = 2
    }
}
