using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgrammeMartyr
{
    /// <summary>
    /// Logique d'interaction pour Jeu.xaml
    /// </summary>
    public partial class Jeu : Window
    {
        private Utilisateur _user;

        private ListeGenerale _Glist;


        public Jeu(Utilisateur user, ListeGenerale Glist)
        {
            InitializeComponent();
            _user = user;
            _Glist = Glist;
            OuvrirePageMenu();
        }

        public void RemoveChildrenAt(int row, int column, bool removeAll = true)
        {
            // Faire une copie pour éviter InvalidOperationException lors de la suppression pendant l'itération
            var toRemove = GrdJeu
                .Children
                .OfType<UIElement>()
                .Where(el => Grid.GetRow(el) == row && Grid.GetColumn(el) == column)
                .ToList();

            if (!removeAll)
            {
                if (toRemove.Count > 0)
                    GrdJeu.Children.Remove(toRemove[0]);
            }
            else
            {
                foreach (var el in toRemove)
                    GrdJeu.Children.Remove(el);
            }
        }

        public void OuvrirePageMenu()
        {
            MenuJeu pageMenu = new MenuJeu(_user, GrdJeu, _Glist);
            //pageMenu.User = _user;
            Grid.SetColumn(pageMenu, 1);
            Grid.SetRow(pageMenu, 1);
            GrdJeu.Children.Add(pageMenu);
            TxtMoney.Text = _user.Inventaire.Items[0].ToString();
            TxtCrystal.Text = _user.Inventaire.Items[1].ToString();
            TxtUpgrade.Text = $"{_user.Inventaire.Items[2].ToString()} UP";
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuBtn_Click(Object sender, RoutedEventArgs e)
        {
            RemoveChildrenAt(1, 1);
            OuvrirePageMenu();
        }

        private void ColorModeBtn_Click(object sender, RoutedEventArgs e)
        {
            Jeu jeu = new Jeu(_user, _Glist);

            if (isDarkModeOn())
            {
                GrdJeu.Background = Brushes.Black;
            }
            else
            {
                GrdJeu.Background = Brushes.DarkGray;
            }
        }

        public bool isDarkModeOn()
        {
            if (GrdJeu.Background == Brushes.Black)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        

        private void ProfileBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
