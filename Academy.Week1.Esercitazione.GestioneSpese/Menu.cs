using GestioneSpesa.Core.BusinessLayer;
using GestioneSpesa.RepositoryMock;
using GestioneSpese.Core.Entita;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSpese
{
    //    L 'utente deve poter:
    //o Inserire nuove Spese
    //(all'inserimento, Approvato = false)
    //o Approvare una spesa
    //(modificare il campo Approvato su 'true')
    //o Visualizzare
    //- l'elenco delle Spese Approvate nell'ultimo mese
    //- L'elenco delle Spese di uno specifico Utente
    //- Il totale delle Spese per Categoria nell'ultimo mese
    //- le spese registrate ordinate dalla più recente alla meno recente

    internal class Menu
    {
        private static readonly IBusinessLayer mainBL = new MainBusinessLayer(new RepositoryCategoriaMock(), new RepositorySpesaMock(), new RepositoryUtenteMock());
        internal static void Start()
        {
            Console.WriteLine("Benvenuto in Gestione Spesa!");

            bool continua = true;

            while (continua)
            {
                int scelta = SchermoMenu();
                continua = AnalizzaScelta(scelta);
            }
        }

        private static int SchermoMenu()
        {
            Console.WriteLine("\n******************Menu*********************");
            Console.WriteLine("\n1. Inserire una nuova Spesa");
            Console.WriteLine("\n2. Approva Spesa");
            Console.WriteLine("\n3. Visualizzare l'elenco delle Spese Approvate nell'ultimo mese");
            Console.WriteLine("\n4. Visualizzare il totale delle Spese per Categoria nell'ultimo mese");
            Console.WriteLine("\n5. Visualizzare le spese registrate ordinate dalla più recente alla meno recente");
            Console.WriteLine("\n6. Visualizzare il totale delle Spese delle Categorie");
            Console.WriteLine("\n0. Exit");
            Console.WriteLine("\n********************************************");

            int scelta;
            Console.WriteLine("Inserisci la tua scelta: ");
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 0 && scelta <= 6))
            {
                Console.WriteLine("Scelta errata. Inserisci scelta corretta:");
            }
            return scelta;
        }

        private static bool AnalizzaScelta(int scelta)
        {
            switch (scelta)
            {
                case 1:
                    InserireSpesa();
                    break;
                case 2:
                    ApprovareSpesa();
                    break;
                case 3:
                    VisualizzaSpeseApprovateMeseScorso();
                    break;
                case 4:
                    VisualizzaTotaleSpeseCategoria();
                    break;
                case 5:
                    OrdinaSpesa();
                    break;
                case 6:
                    VisualizzaCosti();
                    break;
                case 0:
                    return false;
            }
            return true;
        }

        private static void VisualizzaCosti()
        {
            List<Spesa> speseCat = new List<Spesa>();
            List<Categoria> categorie = mainBL.GetAllCategories();
            if (categorie.Count == 0)
            {
                Console.WriteLine("Non sono state trovate categorie");
            }
            else
            {
                //TODO: SISTEMARE, non torna
                foreach (var item in categorie)
                speseCat=mainBL.GetSpesaByIdCategoria2(item.Id);
                decimal totPrice = mainBL.GetPrice(speseCat);
                Console.WriteLine($" \nPrezzo Totale: {totPrice}");
             

            }
            

        }

        private static void OrdinaSpesa()
        {
        
            List <Spesa> speseOrdinate= mainBL.GetOrdered();
            foreach (var item in speseOrdinate)
            {
                Console.WriteLine (item.ToString());
            }
        }

        private static void VisualizzaTotaleSpeseCategoria()
        {
            int idCat;
            do
            {
                Console.WriteLine("\nInserire L'ID della categoria della spesa: ");
            } while (!(int.TryParse(Console.ReadLine(), out idCat) && idCat >= 0));        ;
            List<Spesa> spesaCategoria = mainBL.GetSpesaByIdCat(idCat);
            if ( spesaCategoria.Count==0)
            {
                Console.WriteLine("\nNon è stata trovata una categoria corrispondende a quell'ID");
            }
            else
            {
                decimal totPrice = mainBL.GetPrice(spesaCategoria);                
                Console.WriteLine($" \nPer la categoria con Id: {idCat} - Prezzo Totale: {totPrice}");
            }
        }

        private static void VisualizzaSpeseApprovateMeseScorso()
        {
            //List<Spesa> speseApprovate = mainBL.GetSpeseApprovate();
            //if (speseApprovate.Count == 0)
            //{
            //    Console.WriteLine("Non esistono spese approvate!");
            //}
            //else
            //{
                List<Spesa> speseMeseScorso = mainBL.GetSpeseApprovateMeseScorso(/*speseApprovate*/);
                if (speseMeseScorso.Count == 0)
                {
                    Console.WriteLine("\nNon sono state trovare spese approvate del mese scorso");
                }
                else
                  foreach (var item in speseMeseScorso)
                  Console.WriteLine(item.ToString());
            //}
        }

        private static void ApprovareSpesa()
        {
            
            List<Spesa> speseNonApprovate = mainBL.GetSpeseNonApprovate();
            if (speseNonApprovate.Count==0)
            {
                Console.WriteLine("\nNon risultano spese da approvare");
            }
            else
            {
                foreach (var item in speseNonApprovate)
                Console.WriteLine(item.ToString());
                int idSpesa;
                do
                {
                    Console.WriteLine("\nInserire l'ID della spesa da approvare tra quelle presenti: ");
                } while (!(int.TryParse(Console.ReadLine(), out idSpesa) && idSpesa > 0));
                Spesa spesaDaApprovare = mainBL.GetSpesaById(speseNonApprovate,idSpesa);              
                if (spesaDaApprovare == null)
                {
                    Console.WriteLine("\nNon è stato inserito un ID tra quelli presenti nella lista!");
                }
                else
                {
                   spesaDaApprovare.Approvato = true;
                   bool isUp = mainBL.Update(spesaDaApprovare);
                    List<Spesa> speseNonApprovateNew = mainBL.GetSpeseNonApprovate();
                    foreach (var item in speseNonApprovateNew)
                        Console.WriteLine(item.ToString());

                    if (isUp)
                        Console.WriteLine("\nModifica effettuata");                      
                    
                    else Console.WriteLine("\nQualcosa è andato storto! :(");
                }
            }
        }

        private static void InserireSpesa()
        {          
            int id;
            Console.WriteLine("Inserire spesa!");
            do
            {
                Console.WriteLine("\nInserire L'ID della categoria della spesa: ");
            } while (!(int.TryParse(Console.ReadLine(), out id) && id >= 0));
            Categoria categoria = mainBL.GetCategoryById(id);
            if (categoria == null)
            {
                Console.WriteLine("\nNon è stata trovata una categoria corrispondende a quell'ID");
            }
            else
            {
                int idUt;
                do
                {
                    Console.WriteLine("\nInserire l'ID dell'utente: ");
                } while (!(int.TryParse(Console.ReadLine(), out idUt) && idUt >= 0));
                Utente utente = mainBL.GetUtenteById(idUt);
                if (utente == null)
                {
                    Console.WriteLine("\nNon è stato trovato un utente corrispondente all'ID inserito");
                }
                else
                {

                    DateTime dataSpesa;
                    do
                    {
                        Console.WriteLine("Inserire la data della spesa: ");
                    } while (!(DateTime.TryParse(Console.ReadLine(), out dataSpesa)));

                    Console.WriteLine("Inserire descrizione: ");
                    string descrizioneSpesa=Console.ReadLine();

                    decimal importo;
                    do
                    {
                        Console.WriteLine("Inserire l'importo: ");
                    } while (!(decimal.TryParse(Console.ReadLine(), out importo)));

                    Spesa spesa = new Spesa();
                    spesa.CategoriaId = id;
                    spesa.UtenteId = idUt;
                    spesa.Data=dataSpesa;
                    spesa.Descrizione=descrizioneSpesa;
                    spesa.Importo=importo;
                    spesa.Approvato = false;
                    bool isAdded = mainBL.AddSpesa(spesa);
                    if (isAdded)
                    {
                        Console.WriteLine("Aggiunto correnttamente!");
                        List<Spesa> spese = mainBL.GetAll();
                        {
                            foreach (Spesa s in spese)
                                Console.WriteLine(s.ToString());
                        }
                    }
                    else Console.WriteLine("Qualcosa è andato storto...");
                }
            }
        }
    }
}



