using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Misc;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgrammeMartyr
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //infos pratiques :
            //
            //pour ouvrir la page qui affiches tous les personnages, décommentez la ligne ci-dessous
            //func.OuvrirFenetreDetails(grdMain, persos);

            //////////////////////////////////////////////
            ///ne pas retirer ce qui est en dessous///

            InitializeComponent();

            grdMain.Background = new SolidColorBrush(Colors.DarkGray);

            //connexion aux fichiers
            Fonctions func = new Fonctions();                   //Fichier des différentes fonctions du code
            BddManager bdd = new BddManager();                  //Fichier de connexion/manipulation de la base de donnée
            DataSet listePersos = bdd.DownloadCharacters();    //variable qui contient les personnages
            ListeGenerale GList = new ListeGenerale();          //Fichier de stockage de toutes les listes (personnages, attaques, etc)
            Personnage perso;                                   //Fichier de stockage d'un personnage
            DataSet listeMods = bdd.DownloadModifiers();        //variable qui contient les modifiers
            DataSet listeAttaques = bdd.DownloadAttacks();    //variable qui contient les attaques


            //stoquage des personnages
            for (int i = 0; i < int.Parse(listePersos.Tables["personnage"].Rows.Count.ToString()); i++)
            {
                perso = new Personnage(listePersos.Tables["personnage"].Rows[i]["PersonnageNom"].ToString(), listePersos.Tables["personnage"].Rows[i]["PersonnageType"].ToString(), int.Parse(listePersos.Tables["personnage"].Rows[i]["PersonnageRarete"].ToString()), int.Parse(listePersos.Tables["personnage"].Rows[i]["PersonnageLvlMax"].ToString()), int.Parse(listePersos.Tables["personnage"].Rows[i]["PersonnagePvMax"].ToString()), listePersos.Tables["personnage"].Rows[i]["PersonnageImg"].ToString(), int.Parse(listePersos.Tables["personnage"].Rows[i]["PersonnageId"].ToString()));
                GList.ListePerso.Add(perso);
            }

            for (int i = 0; i < int.Parse(listeMods.Tables["modifyer"].Rows.Count.ToString()); i++)
            {
                Modifiers mod = new Modifiers(listeMods.Tables["modifyer"].Rows[i]["ModifyerNom"].ToString(), listeMods.Tables["modifyer"].Rows[i]["ModifyerNom"].ToString().ToLower(), listeMods.Tables["modifyer"].Rows[i]["ModifyerDescription"].ToString(), int.Parse(listeMods.Tables["modifyer"].Rows[i]["ModifyerDuree"].ToString()), int.Parse(listeMods.Tables["modifyer"].Rows[i]["ModifyerId"].ToString()));
                GList.Modifiers.Add(mod);
            }

            for (int i = 0; i < int.Parse(listeAttaques.Tables["attaque"].Rows.Count.ToString()); i++)
            {
                List<Modifiers> listModAttaque = new List<Modifiers>();
                for (int j = 0; j < int.Parse(listeAttaques.Tables["attaque"].Rows[i]["ModifyersId"].ToString()); j++)
                {
                    for (int k = 0; k < GList.Modifiers.Count; k++)
                    {
                        if (GList.Modifiers[k].Id == (int)listeAttaques.Tables["attaque"].Rows[i]["ModifyersId"])
                        {
                            listModAttaque.Add(GList.Modifiers[k]);
                        }
                    }
                }
                Attaque att = new Attaque(int.Parse(listeAttaques.Tables["attaque"].Rows[i]["AttaqueId"].ToString()), listeAttaques.Tables["attaque"].Rows[i]["AttaqueNom"].ToString(), int.Parse(listeAttaques.Tables["attaque"].Rows[i]["AttaquePuissance"].ToString()), listeAttaques.Tables["attaque"].Rows[i]["AttaqueDescription"].ToString(), int.Parse(listeAttaques.Tables["attaque"].Rows[i]["Role"].ToString()), listModAttaque, GList, out int[] attaquePerso);
                GList.ListeAttaque.Add(att);
                GList.ListePerso[attaquePerso[0]].ListeAttaque.Add(att);
            }


            func.OuvrirFenetreMenu(grdMain, GList);
        }
    }
}