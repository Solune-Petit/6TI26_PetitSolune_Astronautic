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
        public Jeu()
        {
            InitializeComponent();
            OuvrirePageMenu();
        }

        public void OuvrirePageMenu()
        {
            MenuJeu pageMenu = new MenuJeu();
            Grid.SetColumn(pageMenu, 1);
            Grid.SetRow(pageMenu, 1);
            GrdJeu.Children.Add(pageMenu);
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void MenuBtn_Click(Object sender, RoutedEventArgs e)
        {
            OuvrirePageMenu();
        }

        private void ColorModeBtn_Click(object sender, RoutedEventArgs e)
        {
            Jeu jeu = new Jeu();

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
