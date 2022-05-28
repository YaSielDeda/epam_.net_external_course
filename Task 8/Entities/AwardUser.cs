using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class AwardUser
    {
        public Guid UserID { get; set; }
        public Guid AwardID { get; set; }
        public AwardUser()
        {

        }
    }
}
