using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.Core.InterfaceRepositories
{
    public interface IRepository <T>
    {
        List <T> GetAll (Func<T, bool> filter = null);
        T GetById (int id);
        bool Add (T entity);
        bool Update (T entity);
        bool Delete (T entity);
    }
}
