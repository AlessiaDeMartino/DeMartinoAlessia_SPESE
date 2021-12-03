using GestioneSpesa.Core.InterfaceRepositories;
using GestioneSpese.Core.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.RepositoryMock
{
    public class RepositoryCategoriaMock : IRepositoryCategoria
    {
        public bool Add(Categoria entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Categoria entity)
        {
            throw new NotImplementedException();
        }

       
        public List<Categoria> GetAll(Func<Categoria, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.categorie.Where(filter).ToList();
            else
                return InMemoryStorage.categorie.ToList();
        }

        public Categoria GetById(int id)
        {
            return InMemoryStorage.categorie.SingleOrDefault(b => b.Id == id);

        }

        public bool Update(Categoria entity)
        {
            throw new NotImplementedException();
        }
    }
}
