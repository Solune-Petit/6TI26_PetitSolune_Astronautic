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

        private ListeGenerale _Glist;

        public MenuJeu(Utilisateur user, Grid grdJeu, ListeGenerale Glist)
        {
            //assigner l'utilisateur connecté
            _user = user;
            _grdJeu = grdJeu;
            _Glist = Glist;
            InitializeComponent();
        }


        private void CheatBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Cheat code activé !");
        }

        private void MatchBtn_Click(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this) as Jeu;
            parent.RemoveChildrenAt(1, 1);
            PagePrep pagePrepMatch = new PagePrep(_user, _grdJeu, _Glist);
            Grid.SetRow(pagePrepMatch, 1);
            Grid.SetColumn(pagePrepMatch, 1);
            _grdJeu.Children.Add(pagePrepMatch);
        }

        private void InventaireBtn_Click(object sender, RoutedEventArgs e)
        {
            var parent = Window.GetWindow(this) as Jeu;
            parent.RemoveChildrenAt(1,1);
            PageInventaire pageInv = new PageInventaire(_user, _grdJeu);
            Grid.SetRow(pageInv, 1);
            Grid.SetColumn(pageInv, 1);
            //_grdJeu.ShowGridLines = true;
            _grdJeu.Children.Add(pageInv);
        }

        private void ShopBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
