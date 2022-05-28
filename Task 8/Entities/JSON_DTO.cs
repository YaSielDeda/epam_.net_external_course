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
        public JSON_DTO(List<User> users, List<Award> awards)
        {
            Users = users;
            Awards = awards;
        }
        public JSON_DTO()
        {
            
        }
    }
}
