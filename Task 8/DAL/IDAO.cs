using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8._1_THREE_LAYER.DAL
{
    public interface IDAO<T>
    {
        void Create(T item);
        bool DeleteByID(Guid id);
        bool Update(T t);
        List<T> GetAll();
        T GetByID(Guid id);
    }
}
