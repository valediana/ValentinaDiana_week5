using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioneStudenti
{
	public class CorsoDiLaurea
	{
		public string Codice { get; set; }
		public string Nome { get; set; }
		public int AnniCorso { get; set; } = 3;
		public int CfuTotali { get; set; }
		public List<Studente> ElencoStudenti { get; set; } = new List<Studente>();
		public List<CorsoAssociato> ElencoMaterie { get; set; } = new List<CorsoAssociato>();
		//public CorsoDiLaurea()
		//{
		//}
	}
}