using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeMartyr
{
    public class ListeGenerale
    {
		private List <Personnage> _listePerso;

		public List <Personnage> ListePerso
		{
			get { return _listePerso; }
			set { _listePerso = value; }
        }

		public ListeGenerale()
		{
			_listePerso = new List<Personnage>();
        }

    }
}
