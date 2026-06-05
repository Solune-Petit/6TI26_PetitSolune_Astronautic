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

		private int _id;

		public int Id
		{
			get { return _id; }
			set { _id = value; }
		}


		public Modifiers(string nom, string image, string def, int duree, int id)
		{
			_nom = nom;
			_image = $"images/buff-debuff/{image}.png";
			_def = def;
			_duree = duree;
			_id = id;
		}
	}
}
