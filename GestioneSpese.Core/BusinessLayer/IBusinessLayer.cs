using GestioneSpese.Core.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.Core.BusinessLayer
{
    public interface IBusinessLayer
    {
        Categoria GetCategoryById(int id);
        Utente GetUtenteById(int idUt);
        bool AddSpesa(Spesa spesa);
        List<Spesa> GetAll();
        List<Spesa> GetSpeseNonApprovate();   
        Spesa GetSpesaById(List<Spesa> speseNonApprovate, int idSpesa);
        bool Update(Spesa spesaDaApprovare);
        //List<Spesa> GetSpeseApprovate();
        List<Spesa> GetSpeseApprovateMeseScorso(/*List<Spesa> speseApprovate*/);
        List<Spesa> GetSpesaByIdCat(int idCat);
        decimal GetPrice(List<Spesa> spesaCategoria);
        List<Spesa> GetOrdered();
        List<Spesa> GetSpesaByIdCategoria2(int idCategoria);
        List<Categoria> GetAllCategories();
    }
}
