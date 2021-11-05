using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioneStudenti
{

	public class EsamiManager
	{
		public static List<CorsoAssociato> elencoMaterie = new List<CorsoAssociato>();
		public static List<CorsoDiLaurea> elencoCorsiLaurea = new List<CorsoDiLaurea>();
		public static List<Studente> listaStudenti = new List<Studente>();
		public static List<Esame> esamiPassati = new List<Esame>();

		private static void AggiungiEsame()
        {
			Esame esame = new Esame()
			{
				CodiceCorsoAssociato = 1,
				Passato=true

			};
			Esame esame1 = new Esame()
			{
				CodiceCorsoAssociato = 2,
				Passato = true
			};
			
			esamiPassati.Add(esame);
			esamiPassati.Add(esame1);

        }
		public static void AggiungiStudente()
		{
			Studente studente = new Studente()
			{
				Matricola = 1234,
				Nome = "Anna",
				Cognome = "Rossi",
				AnnoNascita = 1999,
				CFUAccumulati = 30,
				CodiceCorsoLaurea = "LM-22",
				ElencoEsami = esamiPassati

			};
			Studente studente2 = new Studente()
			{
				Matricola = 5555,
				Nome = "Carlo",
				Cognome = "Verdi",
				AnnoNascita = 1997,
				CFUAccumulati = 30,
				CodiceCorsoLaurea = "LM-22",
				ElencoEsami = esamiPassati

			};
			listaStudenti.Add(studente);
			listaStudenti.Add(studente2);
		}
		public static void AggiungiMaterie()
        {
			CorsoAssociato Analisi1 = new CorsoAssociato()
			{
				IDCorso=1,
				Nome="Analisi1",
				Cfu=10,
				CodiceCorsoDiLaurea="LM-22"
			};
			CorsoAssociato Fisica1 = new CorsoAssociato()
			{
				IDCorso = 2,
				Nome = "Fisica1",
				Cfu = 10,
				CodiceCorsoDiLaurea = "LM-22"
			};
			CorsoAssociato Fisica2 = new CorsoAssociato()
			{
				IDCorso = 3,
				Nome = "Fisica2",
				Cfu = 10,
				CodiceCorsoDiLaurea = "LM-22"
			};
			CorsoAssociato Chimica = new CorsoAssociato()
			{
				IDCorso = 1,
				Nome = "Chimica",
				Cfu = 10,
				CodiceCorsoDiLaurea = "LM-22"
			};
			elencoMaterie.Add(Analisi1);
			elencoMaterie.Add(Chimica);
			elencoMaterie.Add(Fisica1);
			elencoMaterie.Add(Fisica2);
		}
		public static void AggiungiCorsoLaurea()
		{
			CorsoDiLaurea Ingegneria = new CorsoDiLaurea()
			{
				Codice = "LM-22",
				CfuTotali = 40,
				AnniCorso = 3,
				ElencoMaterie = elencoMaterie,
				ElencoStudenti = listaStudenti
			};
			elencoCorsiLaurea.Add(Ingegneria);
		}

		public static Studente GetStudenteByMatricola(int code)
        {
			Studente found = new Studente();
			foreach(Studente s in listaStudenti)
            {
				if(s.Matricola==code)
				{
					found = s;
				}
            }
			
			return found;
        }

        internal static bool CercaInEsamiPassati(int idCorso)
        {
			bool corsoAggiunto = false;
            foreach(var c in esamiPassati)
            {
				if(c.CodiceCorsoAssociato==idCorso)
				{ 
					Console.WriteLine("Questo esame è già stato sostenuto");
				}
                else
                {
					esamiPassati.Add(c);
					corsoAggiunto = true;
					
                }
            }
			return corsoAggiunto;
        }

        public static CorsoDiLaurea GetLaureaByCodice(string codice)
        {
			//restituisce corso laurea se esiste
			CorsoDiLaurea cdL = new CorsoDiLaurea();
			foreach(var item in elencoCorsiLaurea)
            {
				if(item.Codice==codice)
                {
					cdL = item;
                }
            }
			return cdL;
        }

        public static bool ControllaCoppiaCorsoLaureaMateria(CorsoDiLaurea corsoLaureaScelto, int idCorso)
        {
			//controlla corrispo.materia-cdl
			bool trovato = false;
			foreach(var item in corsoLaureaScelto.ElencoMaterie)
            {
				if (item.IDCorso==idCorso)
                {
					trovato = true;
                }
            }
			return trovato;
			
        }

       

        internal static void PrenotaEsame()
        {
			//elencoMaterie
			
          
        }

        internal static bool controllaCfu(Studente studente, int idCorso, CorsoDiLaurea corsoDiLaurea)
        {
			bool puoiPrenotare=false;
			int cfuAcquisiti = studente.CFUAccumulati;
			int cfuDaOttenere = corsoDiLaurea.CfuTotali;
			int cfuMancanti = cfuDaOttenere - cfuAcquisiti;
			//ciclo dovrebbe interrompersi se cfu materia sono compatibili con cfu tot da conseguire
			foreach (var materia in elencoMaterie)
			{
				int creditiEsame = materia.Cfu;
				if (creditiEsame <= cfuMancanti)
				{
					puoiPrenotare = true;
				}
				else
				{
					puoiPrenotare = false;
					Console.WriteLine("Non puoi prenotarti!");
				}

			
			}
			return puoiPrenotare;
        }

        public static bool FlagLaurea(Studente studente)
        {
			//controlla se stud ha raggiunto cfu tot per laurea
			bool flag = false;
			foreach(var item in elencoCorsiLaurea)
			{
                if (item.CfuTotali == studente.CFUAccumulati)
                {
					flag = true;
                }
			}
			return flag;
        }

      

        internal static void VerbalizzaEsame(int codiceEsame)
        {
			Esame esameVerb = new Esame();
			esameVerb.CodiceCorsoAssociato = codiceEsame;
			esameVerb.Passato = true;
			esamiPassati.Add(esameVerb);

			Console.WriteLine($"Hai verbalizzato l'esame con codice {esameVerb.CodiceCorsoAssociato}");
			
			
        }
    }
}