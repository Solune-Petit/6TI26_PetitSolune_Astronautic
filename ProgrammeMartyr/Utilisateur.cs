using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeMartyr
{
    public class Utilisateur
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

		public Utilisateur(string nom, string mail, string mdp, int id, ListeGenerale Glist)
		{
			_nom = nom;
			_mail = mail;
			_mdp = mdp;
			_id = id;
            _persosPossede = new List<Personnage>();
			_inventaire = new Inventaire(new int[3]);
			RecupererDonnees(Glist);
        }

		public void RecupererDonnees(ListeGenerale GList)
		{
			BddManager bdd = new BddManager();

			bdd.CreateInventaire(_id, GList.ListePerso[0]);
            DataSet temp = bdd.DownloadInventaire(_id);

			ConvertPersoIds(temp, GList);

            Console.WriteLine("Récupération de l'inventaire de l'utilisateur " + _nom + " :");
        }

		public void ConvertPersoIds(DataSet temp, ListeGenerale GList)
		{
            //Récupérer les id des personnages possédés par l'utilisateur dans inventaire->UserItemPersonnagesId en séparant les id par des virgules et les convertir en int pour les stocker dans une liste d'entiers
			string[] ids = temp.Tables[0].Rows[0]["UserItemPersonnagesId"].ToString().Split(',');

			foreach (string id in ids)
			{
				if (int.TryParse(id, out int persoId))
				{
                    //déterminer le personnage correspondant à l'id dans la liste générale des personnages
					Personnage perso = GList.ListePerso.FirstOrDefault(p => p.Id == persoId);
					if (perso != null)
					{
						_persosPossede.Add(perso);
                    }
                }
            }
        }
    }
}
