using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8._1_THREE_LAYER.DAL;
using Entities;

namespace BLL
{
    public class AwardBLL : IBLL<Award>
    {
        private IDAO<Award> _awardDAO;
        public AwardBLL()
        {
            _awardDAO = new AwardJSON_DAO();
        }
        public void Create(Award item)
        {
            _awardDAO.Create(item);
        }
        public bool DeleteByID(Guid id) => _awardDAO.DeleteByID(id);
        public List<Award> GetAll() => _awardDAO.GetAll();
        public Award GetByID(Guid id) => _awardDAO.GetByID(id);

        public bool Update(Award t) => _awardDAO.Update(t);
    }
}
