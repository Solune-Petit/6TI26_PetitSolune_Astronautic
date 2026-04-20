using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
    /// Logique d'interaction pour MenuJeu.xaml
    /// </summary>
    public partial class MenuJeu : UserControl
    {
        private Utilisateur _user;

        private Grid _grdJeu;

        public MenuJeu(Utilisateur user, Grid grdJeu)
        {
            //assigner l'utilisateur connecté
            _user = user;
            _grdJeu = grdJeu;
            InitializeComponent();
        }


        private void CheatBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cheat code activé !");
        }

        private void MatchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void InventaireBtn_Click(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this) as Jeu;
            parent.RemoveChildrenAt(1,1);
            PageInventaire pageInv = new PageInventaire(_user, _grdJeu);
        }

        private void ShopBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
