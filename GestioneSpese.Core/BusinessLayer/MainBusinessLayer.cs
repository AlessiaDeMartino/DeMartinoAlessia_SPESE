using GestioneSpesa.Core.InterfaceRepositories;
using GestioneSpese.Core.Entita;

namespace GestioneSpesa.Core.BusinessLayer
{
    public class MainBusinessLayer:IBusinessLayer
    {
        private readonly IRepositoryCategoria categoryMockRepo;
        private readonly IRepositorySpesa spesaMockRepo;
        private readonly IRepositoryUtente utenteMockRepo;
        public MainBusinessLayer(IRepositoryCategoria categoryMockRepository, IRepositorySpesa spesaMockRepository, IRepositoryUtente utenteMockRepository)
        {
            categoryMockRepo= categoryMockRepository;
            spesaMockRepo= spesaMockRepository;
            utenteMockRepo= utenteMockRepository;
        }

        public bool AddSpesa(Spesa spesa)
        {
            if (spesa == null)
                return false;
            
            return spesaMockRepo.Add(spesa);
        }

        public List<Spesa> GetAll()
        {
            return spesaMockRepo.GetAll();
        }

        public List<Categoria> GetAllCategories()
        {
            return categoryMockRepo.GetAll();
        }

        public Categoria GetCategoryById(int id)
        {
            return categoryMockRepo.GetById(id);
        }

        public List<Spesa> GetOrdered()
        {
            List<Spesa> speseTot = spesaMockRepo.GetAll().OrderByDescending(s=>s.Data).ToList();
            return speseTot;
            
        }

        public decimal GetPrice(List<Spesa> spesaCategoria)
        {
            decimal price = spesaMockRepo.GetPrice(spesaCategoria);
            return price;

        }

        public Spesa GetSpesaById(int idSpesa)
        {
            return spesaMockRepo.GetById(idSpesa);
            
        }

        public Spesa GetSpesaById(List<Spesa> speseNonApprovate, int idSpesa)
        {
            return spesaMockRepo.GetSpeseNonApprovateId(speseNonApprovate, idSpesa);

        }

       

        public List<Spesa> GetSpesaByIdCat(int idCat)
        {
            int LastMont = DateTime.Today.Month == 1 ? 12 : DateTime.Today.Month - 1;
            int LastYear = LastMont == 12 ? DateTime.Today.Year - 1 : DateTime.Today.Year;
            return spesaMockRepo.GetAll((e => e.Data.Month == LastMont && e.Data.Year == LastYear && e.CategoriaId == idCat));
        }

        public List<Spesa> GetSpesaByIdCategoria2(int idCategoria)
        {
            return spesaMockRepo.GetAll(e=> e.CategoriaId == idCategoria).ToList();

        }

        public List<Spesa> GetSpeseApprovate()
        {
            return spesaMockRepo.GetAll(x => x.Approvato == true);
        }

        public List<Spesa> GetSpeseApprovateMeseScorso(/*List<Spesa> speseApprovate*/)
        {
            int LastMont = DateTime.Today.Month == 1 ? 12 : DateTime.Today.Month - 1;
            int LastYear = LastMont == 12 ? DateTime.Today.Year - 1 : DateTime.Today.Year;            
            return spesaMockRepo.GetAll(e => e.Data.Month == LastMont && e.Data.Year == LastYear && e.Approvato==true);
        }

        public List<Spesa> GetSpeseNonApprovate()
        {
            return spesaMockRepo.GetAll(x=> x.Approvato==false);
        }

        public Utente GetUtenteById(int idUt)
        {
            return utenteMockRepo.GetById(idUt);
        }

        public bool Update(Spesa spesaDaApprovare)
        {
            if (spesaDaApprovare == null)
                return false;
            else
                return spesaMockRepo.Update(spesaDaApprovare);
        }
    }
 }

