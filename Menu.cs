using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioneStudenti
{
    public class Menu
    {
        public static void Start()
        {
            EsamiManager.AggiungiMaterie();
            EsamiManager.AggiungiCorsoLaurea();
            EsamiManager.AggiungiStudente();
            bool exit = true;

            do
            {

                Console.WriteLine("Ciao! Scegli un'opzione: " +
                    "\n1- Prenota un esame" +
                    "\n2- Verbalizza un esame" +
                    "\nQ- Uscire" +
                    "\n");

                char choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        PrenotaEsame();
                        break;
                    case '2':
                        VerbalizzaEsame();
                        break;
                    case 'Q':
                        exit = false;
                        break;
                }
            } while (exit);
        }




        private static void PrenotaEsame()
        {
            //chiedo matricola
            int matricola = GetCorsoAssociato("matricola");

            Studente studente = EsamiManager.GetStudenteByMatricola(matricola);
            Console.WriteLine($"Hai selezionato: {studente.Matricola} {studente.Nome} {studente.Cognome} iscritto in {studente.CorsoDiLaurea}");


            if (studente != null)
            {
                //chiedo a studente corso di laurea
                string codice = GetData("codice corso di laurea");
                CorsoDiLaurea corsoLaureaScelto = EsamiManager.GetLaureaByCodice(codice);
                //chiedo codice corso associato(1 2...)
                int idCorso = GetCorsoAssociato("codice corso");
                //controllo se corso esiste in cdl
                bool corrispondenza = EsamiManager.ControllaCoppiaCorsoLaureaMateria(corsoLaureaScelto, idCorso);
                //controllo se può fare domanda laurea
                bool laurea = EsamiManager.FlagLaurea(studente);
                //controllo se cfu corso superano cfu totali da conseguire
                bool controllaCfu = EsamiManager.controllaCfu(studente,idCorso, corsoLaureaScelto);
                bool corsoSelezionato = EsamiManager.CercaInEsamiPassati(idCorso);
                if(corrispondenza == true && laurea == false && controllaCfu == true && corsoSelezionato==true)
                {
                    EsamiManager.PrenotaEsame();
                    //non implementato
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto");
                }
            }
            else
            {
                Console.WriteLine("Non c'è uno studente con questa matricola\n");
            }
        }

        private static void VerbalizzaEsame()
        {
            //chiedo matricola
            int matricola = GetCorsoAssociato("matricola");

            Studente studente = EsamiManager.GetStudenteByMatricola(matricola);


            if (studente != null)
            {
                //chiedo a studente corso
                string codice = GetData("codice corso di laurea");
                CorsoDiLaurea corsoLaureaScelto = EsamiManager.GetLaureaByCodice(codice);
                int idCorso = GetCorsoAssociato("codice dell'esame che vuoi verbalizzare");
                bool corrispondenza = EsamiManager.ControllaCoppiaCorsoLaureaMateria(corsoLaureaScelto, idCorso);
                //controllo se corso e studente corrispondono
                //controllo laurea
                bool laurea = EsamiManager.FlagLaurea(studente);
                //controlla se cfu esame non superano cfu tot
                bool controllaCfu = EsamiManager.controllaCfu(studente,idCorso, corsoLaureaScelto);
                bool corsoSelezionato = EsamiManager.CercaInEsamiPassati(idCorso);
                //qui dovrei controllare se esame da verbal. è in esami passati e
                //poi settare eventualmente laurea=true
                if (corrispondenza == true && laurea == false && controllaCfu == true && corsoSelezionato==true)
                {
                    EsamiManager.VerbalizzaEsame(idCorso);
                }
                else
                {
                    Console.WriteLine("Qualcosa è andato storto");
                }
            }
            else
            {
                Console.WriteLine("Non c'è uno studente con questa matricola\n");
            }
        }

        private static string GetData(string value)
        {
            string info;
            do
            {
                Console.Write($"Inserisci il tuo {value}: ");
                info = Console.ReadLine();
            } while (string.IsNullOrEmpty(info));

            return info;
        }
        private static int GetCorsoAssociato(string value)
        {
            int info;
            do
            {
                //correggi qui:prende in ingresso interi vari
                Console.Write($"Inserisci {value}");

            } while (!(int.TryParse(Console.ReadLine(), out info)));

            return info;
        }

    }
}
