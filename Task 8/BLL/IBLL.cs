using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public interface IBLL<T>
    {
        void Create(T item);
        void DeleteByID(Guid id);
        List<T> GetAll();
    }
}
