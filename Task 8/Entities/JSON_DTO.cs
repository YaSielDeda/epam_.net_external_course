using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace Entities
{
    public class JSON_DTO
    {
        public List<User> Users;
        public List<Award> Awards;
        public List<AwardUser> AwardIDUserID;
        public JSON_DTO(List<User> users, List<Award> awards, List<AwardUser> AwardIDUserID)
        {
            Users = users;
            Awards = awards;
            this.AwardIDUserID = AwardIDUserID;
        }
        public JSON_DTO()
        {
            
        }
    }
}
