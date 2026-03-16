using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeMartyr
{
    internal class Utilisateur
    {
		private string _nom;

		private string _mail;

		private string _mdp;

		private List <Personnage> _persosPossede;

		private Inventaire _inventaire;

		private int _id;

		public int Id
		{
			get { return _id; }
        }

        public Inventaire Inventaire
		{
			get { return _inventaire; }
			set { _inventaire = value; }
		}

		public List <Personnage> PersosPossede
		{
			get { return _persosPossede; }
			set { _persosPossede = value; }
		}

		public string Mdp
		{
			get { return _mdp; }
		}

		public string Mail
		{
			get { return _mail; }
		}

		public string Nom
		{
			get { return _nom; }
		}

		public Utilisateur(string nom, string mail, string mdp, int id)
		{
			_nom = nom;
			_mail = mail;
			_mdp = mdp;
			_id = id;
            _persosPossede = new List<Personnage>();
			_inventaire = new Inventaire();
        }

		public void RecupererDonnees()
		{
			BddManager bdd = new BddManager();

			DataSet temp = bdd.DownloadInventaire(_id);

			Console.WriteLine("Récupération de l'inventaire de l'utilisateur " + _nom + " :");
        }
    }
}
