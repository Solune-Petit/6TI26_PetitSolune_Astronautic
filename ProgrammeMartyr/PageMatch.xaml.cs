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
    /// Interaction logic for PageMatch.xaml
    /// </summary>
    public partial class PageMatch : UserControl
    {

        private List<Personnage> _listeEnemis;

        public List<Personnage> ListeEnemis
        {
            get { return _listeEnemis; }
            set { _listeEnemis = value; }
        }

        private List<Personnage> _deckJoueur;

        public List<Personnage> DeckJoueur
        {
            get { return _deckJoueur; }
            set { _deckJoueur = value; }
        }


        public PageMatch(List<Personnage> listeEnemis, List<Personnage>listeDeck)
        {
            InitializeComponent();
            _deckJoueur = listeDeck;
            _listeEnemis = listeEnemis;

            //mettre le code que tu veux utiliser au lancement de la page
        }

        //mets tes fonctions pour le bon fonctionnement du match en dessous
    }
}
