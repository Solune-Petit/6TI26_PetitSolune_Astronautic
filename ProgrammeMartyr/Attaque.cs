using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Runtime.Serialization;

namespace ProgrammeMartyr
{
    public class Attaque
    {
		//AttaqueId, AttaqueNom, AttaquePuissance, AttaqueDescription, Role, ModifyersId

		private int _id;

		public int Id
		{
			get { return _id; }
		}

		private string _nom;

		public string Nom
		{
			get { return _nom; }
		}

		private int _puissance;

		public int Puissance
		{
			get { return _puissance; }
		}

		private string _description;

		public string Description
		{
			get { return _description; }
		}

		private int _role;

		public int Role
		{
			get { return _role; }
		}

		public int Cooldown { get; set; }

        private List<Modifiers> _listeModifier;

		public List<Modifiers> ListeModifier
		{
			get { return _listeModifier; }
		}

		public Attaque(int id, string nom, int puissance, string description, int role, List<Modifiers> listeModifier)
		{
			_id = id;
			_nom = nom;
			_puissance = puissance;
			_description = description;
			_role = role;
			_listeModifier = listeModifier;
        }

		public void AssignerModifier(Modifiers Modifier)
		{
			_listeModifier.Add(Modifier);
		}

		public void AssignAttaqueToPersonnage(ListeGenerale Glist)
		{
			BddManager bdd = new BddManager();
			DataSet dataPossede = bdd.DownloadPossede();

			foreach (DataRow row in dataPossede.Tables[0].Rows)
			{
				if(Convert.ToInt32(row["AttaqueId"]) == _id)
				{
					Glist.ListePerso[Convert.ToInt32(row["PersonnageId"])].ListeAttaque.Add(this);
                }
            }
        }
    }
}
