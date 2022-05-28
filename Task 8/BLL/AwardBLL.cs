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
        private IDAO<Award> _AwardDAO;
        public AwardBLL()
        {
            _AwardDAO = new AwardJSON_DAO();
        }
        public void Create(Award item)
        {
            _AwardDAO.Create(item);
        }
        public void DeleteByID(Guid id)
        {
            _AwardDAO.DeleteByID(id);
        }
        public List<Award> GetAll() => _AwardDAO.GetAll();
    }
}
