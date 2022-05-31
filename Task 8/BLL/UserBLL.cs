using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8._1_THREE_LAYER.DAL;
using Entities;

namespace BLL
{
    public class UserBLL : IBLL<User>
    {
        private IDAO<User> _userDAO;
        public UserBLL()
        {
            _userDAO = new UserJSON_DAO();
        }
        public void Create(User item)
        {
            _userDAO.Create(item);
        }
        public bool DeleteByID(Guid id) => _userDAO.DeleteByID(id);
        public List<User> GetAll() => _userDAO.GetAll();
        public User GetByID(Guid id) => _userDAO.GetByID(id);
        public bool Update(User t) => _userDAO.Update(t);
    }
}
