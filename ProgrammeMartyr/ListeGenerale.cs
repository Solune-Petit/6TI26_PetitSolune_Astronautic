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

		private List<Modifiers> _modifiers;

		public List<Modifiers> Modifiers
		{
			get { return _modifiers; }
			set { _modifiers = value; }
		}


		public ListeGenerale()
		{
			_listePerso = new List<Personnage>();
			_modifiers = new List<Modifiers>();
        }

    }
}
