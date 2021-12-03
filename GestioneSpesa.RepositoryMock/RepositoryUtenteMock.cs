using GestioneSpesa.Core.InterfaceRepositories;
using GestioneSpese.Core.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.RepositoryMock
{
    public class RepositoryUtenteMock : IRepositoryUtente
    {
        public bool Add(Utente entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Utente entity)
        {
            throw new NotImplementedException();
        }

       

        public List<Utente> GetAll(Func<Utente, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Utente GetById(int id)
        {
            return InMemoryStorage.utenti.SingleOrDefault(b => b.Id == id);
        }

        public bool Update(Utente entity)
        {
            throw new NotImplementedException();
        }
    }
}
