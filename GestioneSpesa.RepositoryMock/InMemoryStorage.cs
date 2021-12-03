using GestioneSpese.Core.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpesa.RepositoryMock
{
    public class InMemoryStorage
    {
        public static List<Spesa> spese { get; set; } = new List<Spesa>()
        {
            new Spesa(){Id=1, CategoriaId=1, Approvato=true, Data=new DateTime(2021,11,29), Descrizione="bolletta Iren", Importo=110, UtenteId=1},
            new Spesa(){Id=2, CategoriaId=2, Approvato=true, Data=new DateTime(2021,1,12), Descrizione="spesa", Importo=80, UtenteId=2},
            new Spesa(){Id=3, CategoriaId=1, Approvato=true, Data=new DateTime(2021,2,12), Descrizione="bolletta Iren", Importo=89, UtenteId=3},
            new Spesa(){Id=4, CategoriaId=3, Approvato=true, Data=new DateTime(2021,4,11), Descrizione="bolletta Acqua", Importo=200, UtenteId=2},
            new Spesa(){Id=5, CategoriaId=2, Approvato=false, Data=new DateTime(2021,8,8), Descrizione="trucchi", Importo=60, UtenteId=3},
            new Spesa(){Id=6, CategoriaId=1, Approvato=false, Data=new DateTime(2021,7,23), Descrizione="gas", Importo=80, UtenteId=1},
            new Spesa(){Id=7, CategoriaId=2, Approvato=true, Data=new DateTime(2021,11,8), Descrizione="spesa", Importo=100, UtenteId=4},
            new Spesa(){Id=8, CategoriaId=1, Approvato=false, Data=new DateTime(2021,11,23), Descrizione="gas", Importo=80, UtenteId=1},

         };

        public static List<Utente> utenti { get; set; } = new List<Utente>()
        {
            new Utente(){Id=1, Nome="Alessia", Cognome="Serra"},
            new Utente(){Id=2, Nome="Viviana", Cognome="Godel"},
            new Utente(){Id=3, Nome="Barbara", Cognome="Franchi"},
            new Utente(){Id=4, Nome="Giuseppe", Cognome="Giganti"},

        };

        public static List<Categoria> categorie { get; set; } = new List<Categoria>()
        {
            new Categoria(){Id=1, Nome="Elettricita"},
            new Categoria(){Id=2, Nome ="Spesa"},
            new Categoria(){Id=3,Nome="Acqua"},
        };
    }
}
