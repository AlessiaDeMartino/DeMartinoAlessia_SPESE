using GestioneSpesa.Core.InterfaceRepositories;
using GestioneSpese.Core.Entita;

namespace GestioneSpesa.RepositoryMock
{
    public class RepositorySpesaMock : IRepositorySpesa
    {
        public bool Add(Spesa entity)
        {
            if (entity == null)
                return false;

            entity.Id = InMemoryStorage.spese.Max(b => b.Id) + 1;

            InMemoryStorage.spese.Add(entity);

            return true;
        }

        public bool Delete(Spesa entity)
        {
            throw new NotImplementedException();
        }

        public List<Spesa> GetAll(Func <Spesa, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.spese.Where(filter).ToList();
            else 
                return InMemoryStorage.spese.ToList();

        }     

        public Spesa GetById(int id)
        {
           return InMemoryStorage.spese.SingleOrDefault(s => s.Id == id);
        }

        public decimal GetPrice(List<Spesa> spesaCategoria)
        {
            decimal price = 0;
            foreach (var item in spesaCategoria)
                price += item.Importo;
            return price;
        }

        public Spesa GetSpeseNonApprovateId(List<Spesa> speseNonApprovate, int idSpesa)
        {
            foreach (var item in speseNonApprovate)
            {
                if (item.Id == idSpesa)
                {
                    return item;
                }
                else
                    return null;
            }
            return null;
        }

        public bool Update(Spesa entity)
        {
            var oldSpesa = GetById(entity.Id); //recupero dal db la spesa il cui id è quello della spesa modificata che sta arrivando in input al metodo update
            var index = InMemoryStorage.spese.IndexOf(oldSpesa); //in index trovo l'indice della spesa 
            if (index != -1) //se è diverso da -1, ovvero effettivamente c'è un indice per quell'oggetto nella lista di spese
            {
                InMemoryStorage.spese[index] = entity; //nella lista, all'indice trovato, metto l'oggetto modificato
              return true;
            }

            return false;
        }
    }
}