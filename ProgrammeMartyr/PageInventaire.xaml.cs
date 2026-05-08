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
    /// Logique d'interaction pour PageInventaire.xaml
    /// </summary>
    public partial class PageInventaire : UserControl
    {
        private Utilisateur _user;

        public PageInventaire(Utilisateur user, Grid grdJeu)
        {
            InitializeComponent();
            //récupérer l'utilisateur connecté pour lui afficher les bonnes infos (inventaire, personnages possédés, etc)
            var parent = Window.GetWindow(this) as Jeu;
            _user = user;


            AfficherPersos(user);
        }

        internal void AfficherPersos(Utilisateur user)
        {
            //récupérer la liste des personnages dans la classe Utilisateurs
            int i = 0; 
            int j = 0;

            foreach (Personnage persos in user.PersosPossede)
            {
                StackPanel card = persos.GenInfoCardDesign();
                card.HorizontalAlignment = HorizontalAlignment.Left;
                card.VerticalAlignment = VerticalAlignment.Top;
                Grid.SetRow(card, j);
                Grid.SetColumn(card, i);
                gridPersos.Children.Add(card);
                i++;
                    if (i == 10)
                    {
                        i = 0;
                        j++;
                }
            }
        }
    }
}
