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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgrammeMartyr
{
    /// <summary>
    /// Logique d'interaction pour MenuJeu.xaml
    /// </summary>
    public partial class MenuJeu : UserControl
    {
        public MenuJeu(Utilisateur user)
        {
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
            PageInventaire pageInv = new PageInventaire(user);
        }

        private void ShopBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
