using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioneStudenti
{
	public class Studente
	{
		public int Matricola { get; set; }
		public string Nome { get; set; }
		public string Cognome { get; set; }
		public int AnnoNascita { get; set;}
		public bool RichiestaLaurea { get; set; }
		public int CFUAccumulati { get; set; }
		public string CodiceCorsoLaurea { get; set; }
		public CorsoDiLaurea CorsoDiLaurea { get; set; }
		public List<Esame> ElencoEsami { get; set; } = new List<Esame>();


		//public Studente()
		//{
		//}
	}
}