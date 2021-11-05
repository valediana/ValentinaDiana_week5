using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestioneStudenti
{

	public class Esame
	{
		
		public int CodiceCorsoAssociato { get; set; }
		public CorsoAssociato CorsoAssociato { get; set; }
		public bool Passato { get; set; } = false; //valore di default
	}
}