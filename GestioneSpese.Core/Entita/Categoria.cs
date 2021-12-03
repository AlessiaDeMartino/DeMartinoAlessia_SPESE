using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese.Core.Entita
{
//    Id(int)
//- Nome(string)

    //si potrebbe fare una class padre che contiene ID e Name e categoria e utente figlie.
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
