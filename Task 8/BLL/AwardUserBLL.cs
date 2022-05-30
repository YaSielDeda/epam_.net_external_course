using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8._1_THREE_LAYER.DAL;

namespace BLL
{
    public class AwardUserBLL : IBLL<AwardUser>
    {
        private IDAO<AwardUser> _awardUserDAO;
        public AwardUserBLL()
        {
            _awardUserDAO = new UserIDAwardID_JSON_DAO();
        }
        public void Create(AwardUser item)
        {
            _awardUserDAO.Create(item);
        }

        public void DeleteByID(Guid id)
        {
            _awardUserDAO.DeleteByID(id);
        }

        public List<AwardUser> GetAll() => _awardUserDAO.GetAll();
        //TODO
        public AwardUser GetByID(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
