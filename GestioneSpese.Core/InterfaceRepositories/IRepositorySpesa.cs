using GestioneSpese.Core.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.Core.InterfaceRepositories
{
    public interface IRepositorySpesa : IRepository<Spesa>
    {
        decimal GetPrice(List<Spesa> spesaCategoria);
        Spesa GetSpeseNonApprovateId(List<Spesa> speseNonApprovate, int idSpesa);
    }
}
