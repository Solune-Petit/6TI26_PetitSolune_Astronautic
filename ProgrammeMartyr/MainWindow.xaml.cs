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

            Personnage[] persos = new Personnage[10];
            Fonctions func = new Fonctions();

            //création de la liste des personnages
            func.CreerPersonnage(out string[,] listePersos);

            //initialisation des personnages
            for (int i = 0; i < 10; i++)
                {
                    persos[i] = new Personnage(
                        listePersos[i, 0],
                        listePersos[i, 1],
                        int.Parse(listePersos[i, 2]),
                        int.Parse(listePersos[i, 3]),
                        int.Parse(listePersos[i, 4]),
                        listePersos[i, 5]
                        );
                }
            ///////////////////////////////////////////////

        }
    }
}