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
			set { _nom = value; }
		}

		private string _image;

		public string Image
		{
			get { return _image; }
			set { _image = value; }
		}

		private string _def;

		public string Def
		{
			get { return _def; }
			set { _def = value; }
		}

		private string _effect;

		public string Effect
		{
			get { return _effect; }
			set { _effect = value; }
		}

		public Modifiers(string nom, string image, string def, string effect)
		{
			_nom = nom;
			_image = image;
			_def = def;
			_effect = effect;
        }
    }
}
