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
            InitializeComponent();

            Personnage[] persos = new Personnage[10];
            Fonctions func = new Fonctions();

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


            //definition des colonnes
            ColumnDefinition[] colDef = new ColumnDefinition[10];
            for (int i = 0; i < 4; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }

            //definition des lignes
            RowDefinition[] rowDef = new RowDefinition[10];
            for (int i = 0; i < 4; i++)
            {
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }

            int temp = 0;
            int temp2 = 0;
            //ajout des cartes de personnages
            foreach (Personnage perso in persos)
            {
                if (perso != null)
                {
                    StackPanel card = perso.CardDesign();
                    Grid.SetColumn(card, temp);
                    Grid.SetRow(card, temp2);
                    grdMain.Children.Add(card);
                }
                temp++;
                if (temp > 3)
                {
                    temp = 0;
                    temp2++;
                }
            }
        }
    }
}