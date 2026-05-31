using System;
using System.Collections.Generic;
using System.Data;
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
        private List<Modifiers> _mods = new List<Modifiers>();

        private List<Personnage> _listePersos;

        private List<Personnage> _listeEnemis;

        private ListeGenerale _listG;

        private int _turnSelector = 0;

        private List<Attaque> _listeAttaquesPersoEnCours;
        public Match(List<Personnage> listeEnemis, List<Personnage> listePersos, ListeGenerale Glist)
        {
            InitializeComponent();
            _listePersos = listePersos;
            _listeEnemis = listeEnemis;
            _listG = Glist;
            PrepBoard();
            GetMods();
            PrepNextTurn();
        }

        public void PrepBoard()
        {
            stckEnemi1 = _listeEnemis[0].CombatCardDesign();
            stckEnemi2 = _listeEnemis[1].CombatCardDesign();
            stckEnemi3 = _listeEnemis[2].CombatCardDesign();
            stckEnemi4 = _listeEnemis[3].CombatCardDesign();
            stckEnemi5 = _listeEnemis[4].CombatCardDesign();

            stckPerso1 = _listePersos[0].CombatCardDesign();
            stckPerso2 = _listePersos[1].CombatCardDesign();
            stckPerso3 = _listePersos[2].CombatCardDesign();
            stckPerso4 = _listePersos[3].CombatCardDesign();
            stckPerso5 = _listePersos[4].CombatCardDesign();
        }

        public void PrepNextTurn()
        {
            if(_turnSelector > _listePersos.Count - 1)
            {
                _turnSelector = 0;
                foreach(Personnage perso in _listeEnemis)
                {

                }
            }
            
            switch (_turnSelector)
            {
                case 0:
                    //tour du personnage 1
                    BtnAttaque1.Content = _listePersos[0].ListeAttaque[0].Nom;
                    BtnAttaque2.Content = _listePersos[0].ListeAttaque[1].Nom;
                    BtnAttaque3.Content = _listePersos[0].ListeAttaque[2].Nom;

                    if (_listePersos[0].ListeAttaque[1].Cooldown != 0)
                    {
                        _listePersos[0].ListeAttaque[1].Cooldown--;
                        BtnAttaque2.IsEnabled = false;
                    }
                    if (_listePersos[0].ListeAttaque[2].Cooldown != 0)
                    {
                        _listePersos[0].ListeAttaque[2].Cooldown--;
                        BtnAttaque3.IsEnabled = false;
                    }


                    break;
                case 1:
                    
                    break;
                default:
                    _turnSelector = 0;
                    PrepNextTurn();
                    break;
            }
        }

        private void BtnAttaque_Click(object sender, RoutedEventArgs e)
        {
            
            _turnSelector++;
        }

        public void GetMods()
        {
            foreach (var mod in _listG.Modifiers)
            {
                _mods.Add(mod);
            }
        }
    }
}
