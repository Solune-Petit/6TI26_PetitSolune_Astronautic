using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeMartyr
{
    public class Modifiers
    {
		private string _nom;

		public string Nom
		{
			get { return _nom; }
		}

		private string _image;

		public string Image
		{
			get { return _image; }
		}

		private string _def;

		public string Def
		{
			get { return _def; }
		}

		private int _duree;

		public int Duree
		{
			get { return _duree; }
		}

		public Modifiers(string nom, string image, string def, int duree)
		{
			_nom = nom;
			_image = image;
			_def = def;
			_duree = duree;
		}
	}
}
