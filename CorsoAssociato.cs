using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioneStudenti
{
	public class CorsoAssociato
	{
		public int IDCorso { get; set; }
		public string Nome { get; set; }
		public int Cfu { get; set; }
		public string CodiceCorsoDiLaurea { get; set; }
		public CorsoDiLaurea CorsoDiLaurea { get; set; }

		//public CorsoAssociato()
		//{
		//}
	}
}