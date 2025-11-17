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
            ColumnDefinition[] coldef = new ColumnDefinition[5];
            for (int i = 0; i < 5; i++)
            {
                coldef[i] = new ColumnDefinition();
                plateau.ColumnDefinitions.Add(coldef[i]);
            }
            RowDefinition[] rowdef = new RowDefinition[5];
            for (int i = 0; i < 5; i++)
            {
                rowdef[i] = new RowDefinition();
                plateau.RowDefinitions.Add(rowdef[i]);
            }
            //primère ligne 
            TextBlock texte1 = new TextBlock();
            texte1.TextAlignment = TextAlignment.Center;
            texte1.Text = "timer (reste à le créer plus tard)";
            texte1.FontSize = 15;
            texte1.FontFamily = new FontFamily("arial");
            texte1.FontWeight = FontWeights.UltraBold;
            texte1.Foreground = Brushes.Black;
            Grid.SetColumn(texte1, 0);
            Grid.SetRow(texte1, 0);
            Grid.SetColumnSpan(texte1, 1);
            Grid.SetColumnSpan(texte1, 5);
            plateau.Children.Add(texte1);

            //deuxième ligne 
            TextBlock texte2 = new TextBlock();
            texte2.Text = "Allié N°1";
            Grid.SetColumn(texte2, 0);
            Grid.SetRow(texte2, 1);
            plateau.Children.Add(texte2);


            TextBlock texte3 = new TextBlock();
            Grid.SetColumn(texte3, 4);
            Grid.SetRow(texte3, 1);
            texte3.Text = "Ennemi N°1";
            texte3.TextAlignment = TextAlignment.Right;
            plateau.Children.Add(texte3);

            //troisième ligne 
            TextBlock texte4 = new TextBlock();
            texte4.Text = "Allié N°2";
            Grid.SetColumn(texte4, 0);
            Grid.SetRow(texte4, 2);
            plateau.Children.Add(texte4);


            TextBlock texte5 = new TextBlock();
            Grid.SetColumn(texte5, 4);
            Grid.SetRow(texte5, 2);
            texte5.Text = "Ennemi N°2";
            texte5.TextAlignment = TextAlignment.Right;
            plateau.Children.Add(texte5);


            TextBlock texte6 = new TextBlock();
            texte6.Text = "Allié N°3";
            Grid.SetColumn(texte6, 1);
            Grid.SetRow(texte6, 2);
            plateau.Children.Add(texte6);


            TextBlock texte7 = new TextBlock();
            Grid.SetColumn(texte7, 3);
            Grid.SetRow(texte7, 2);
            texte7.Text = "Ennemi N°3";
            texte7.TextAlignment = TextAlignment.Right;
            plateau.Children.Add(texte7);

            //quatrième ligne 
            TextBlock texte8 = new TextBlock();
            texte8.Text = "Allié N°4";
            Grid.SetColumn(texte8, 0);
            Grid.SetRow(texte8, 3);
            plateau.Children.Add(texte8);


            TextBlock texte9 = new TextBlock();
            Grid.SetColumn(texte9, 1);
            Grid.SetRow(texte9, 3);
            texte9.Text = "Allié N°5";
            plateau.Children.Add(texte9);


            TextBlock texte10 = new TextBlock();
            texte10.Text = "Ennemi N°4";
            Grid.SetColumn(texte10, 4);
            Grid.SetRow(texte10, 3);
            texte10.TextAlignment = TextAlignment.Right;
            plateau.Children.Add(texte10);
            

            TextBlock texte11 = new TextBlock();
            Grid.SetColumn(texte11, 3);
            Grid.SetRow(texte11, 3);
            texte11.Text = "Ennemi N°5";
            texte11.TextAlignment = TextAlignment.Right;
            plateau.Children.Add(texte11);

            //cinquième ligne 
            TextBlock texte12 = new TextBlock();
            texte12.Text = "Buffs et DeBuffs";
            Grid.SetColumn(texte12, 0);
            Grid.SetRow(texte12, 4);
            plateau.Children.Add(texte12);


            TextBlock texte13 = new TextBlock();
            texte13.Text = "Attaque";
            Grid.SetColumn(texte13, 4);
            Grid.SetRow(texte13, 4);
            texte13.TextAlignment = TextAlignment.Right;
            plateau.Children.Add(texte13);
        }
    }
}