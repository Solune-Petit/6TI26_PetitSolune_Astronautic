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
        public PageInventaire(Utilisateur user)
        {
            InitializeComponent();
            AfficherPersos(user);
        }

        public void AfficherPersos(Utilisateur user)
        {
            //récupérer la liste des personnages dans la classe Utilisateurs

            foreach (Personnage persos in user.PersosPossede)
            {
                StackPanel card = persos.GenInfoCardDesign();
                stkListePersos.Children.Add(card);
            }
        }
    }
}
