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
    /// Logique d'interaction pour Match.xaml
    /// </summary>
    public partial class Match : UserControl
    {
        private List<Modifiers> mods = new List<Modifiers>();

        private List<Personnage> _listePersos;

        private List<Personnage> _listeEnemis;

        private List<ListeGenerale> _listG;

        public Match(List<Personnage> listePersos, List<Personnage> listeEnemis, ListeGenerale Glist)
        {
            InitializeComponent();

        }

        public void GetMods()
        {
            BddManager bdd = new BddManager();
            List<Modifiers> modifiers = bdd.DownloadModifiers();
            mods = modifiers;
        }
    }
}
