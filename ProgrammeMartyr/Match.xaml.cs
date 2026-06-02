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

            StackPanel stckEnemi1 = _listeEnemis[0].CombatCardDesign();
            Grid.SetRow(stckEnemi1, 0);
            Grid.SetColumn(stckEnemi1, 4);
            grdMatch.Children.Add(stckEnemi1);
            bool fin = false;

            if(_listeEnemis.Count == 1)
            {
                fin = true;
            }

            if (_listeEnemis.Count < 3 && _listeEnemis.Count > 1 && !fin)
            {
                StackPanel stckEnemi2 = _listeEnemis[1].CombatCardDesign();
                Grid.SetRow(stckEnemi2, 1);
                Grid.SetColumn(stckEnemi2, 3);
                grdMatch.Children.Add(stckEnemi2);
                fin = true;
            }
            if(_listeEnemis.Count < 4 && !fin)
            {
                StackPanel stckEnemi2 = _listeEnemis[1].CombatCardDesign();
                Grid.SetRow(stckEnemi2, 1);
                Grid.SetColumn(stckEnemi2, 3);
                grdMatch.Children.Add(stckEnemi2);

                StackPanel stckEnemi3 = _listeEnemis[2].CombatCardDesign();
                Grid.SetRow(stckEnemi3, 2);
                Grid.SetColumn(stckEnemi3, 4);
                grdMatch.Children.Add(stckEnemi3);
                fin = true;
            }
            if(_listeEnemis.Count < 5 && !fin)
            {
                StackPanel stckEnemi2 = _listeEnemis[1].CombatCardDesign();
                Grid.SetRow(stckEnemi2, 1);
                Grid.SetColumn(stckEnemi2, 3);
                grdMatch.Children.Add(stckEnemi2);

                StackPanel stckEnemi3 = _listeEnemis[2].CombatCardDesign();
                Grid.SetRow(stckEnemi3, 2);
                Grid.SetColumn(stckEnemi3, 4);
                grdMatch.Children.Add(stckEnemi3);

                StackPanel stckEnemi4 = _listeEnemis[3].CombatCardDesign();
                Grid.SetRow(stckEnemi4, 3);
                Grid.SetColumn(stckEnemi4, 3);
                grdMatch.Children.Add(stckEnemi4);
                fin = true;
            }
            if(_listeEnemis.Count < 6 && !fin)
            {
                StackPanel stckEnemi2 = _listeEnemis[1].CombatCardDesign();
                Grid.SetRow(stckEnemi2, 1);
                Grid.SetColumn(stckEnemi2, 3);
                grdMatch.Children.Add(stckEnemi2);

                StackPanel stckEnemi3 = _listeEnemis[2].CombatCardDesign();
                Grid.SetRow(stckEnemi3, 2);
                Grid.SetColumn(stckEnemi3, 4);
                grdMatch.Children.Add(stckEnemi3);

                StackPanel stckEnemi4 = _listeEnemis[3].CombatCardDesign();
                Grid.SetRow(stckEnemi4, 3);
                Grid.SetColumn(stckEnemi4, 3);
                grdMatch.Children.Add(stckEnemi4);
                StackPanel stckEnemi5 = _listeEnemis[4].CombatCardDesign();
                Grid.SetRow(stckEnemi5, 4);
                Grid.SetColumn(stckEnemi5, 4);
                grdMatch.Children.Add(stckEnemi5);
                fin = true;
            }

            StackPanel stckPerso1 = _listePersos[0].CombatCardDesign();
            Grid.SetRow(stckPerso1, 0);
            Grid.SetColumn(stckPerso1, 0);
            grdMatch.Children.Add(stckPerso1);

            fin = false;
            if(_listePersos.Count == 1)
            {
                fin = true;
            }

            if (_listePersos.Count < 3 && _listePersos.Count > 1 && !fin)
            {
                StackPanel stckPerso2 = _listePersos[1].CombatCardDesign();
                Grid.SetRow(stckPerso2, 1);
                Grid.SetColumn(stckPerso2, 1);
                grdMatch.Children.Add(stckPerso2);
                fin = true;
            }
            if (_listePersos.Count < 4 && !fin)
            {
                StackPanel stckPerso2 = _listePersos[1].CombatCardDesign();
                Grid.SetRow(stckPerso2, 1);
                Grid.SetColumn(stckPerso2, 1);
                grdMatch.Children.Add(stckPerso2);

                StackPanel stckPerso3 = _listePersos[2].CombatCardDesign();
                Grid.SetRow(stckPerso3, 2);
                Grid.SetColumn(stckPerso3, 0);
                grdMatch.Children.Add(stckPerso3);

                fin = true;
            }
            if (_listePersos.Count < 5 && !fin)
            {
                StackPanel stckPerso2 = _listePersos[1].CombatCardDesign();
                Grid.SetRow(stckPerso2, 1);
                Grid.SetColumn(stckPerso2, 1);
                grdMatch.Children.Add(stckPerso2);

                StackPanel stckPerso3 = _listePersos[2].CombatCardDesign();
                Grid.SetRow(stckPerso3, 2);
                Grid.SetColumn(stckPerso3, 0);
                grdMatch.Children.Add(stckPerso3);

                StackPanel stckPerso4 = _listePersos[3].CombatCardDesign();
                Grid.SetRow(stckPerso4, 3);
                Grid.SetColumn(stckPerso4, 1);
                grdMatch.Children.Add(stckPerso4);

                fin = true;
            }
            if (_listePersos.Count < 6 && !fin)
            {
                StackPanel stckPerso2 = _listePersos[1].CombatCardDesign();
                Grid.SetRow(stckPerso2, 1);
                Grid.SetColumn(stckPerso2, 1);
                grdMatch.Children.Add(stckPerso2);

                StackPanel stckPerso3 = _listePersos[2].CombatCardDesign();
                Grid.SetRow(stckPerso3, 2);
                Grid.SetColumn(stckPerso3, 0);
                grdMatch.Children.Add(stckPerso3);

                StackPanel stckPerso4 = _listePersos[3].CombatCardDesign();
                Grid.SetRow(stckPerso4, 3);
                Grid.SetColumn(stckPerso4, 1);
                grdMatch.Children.Add(stckPerso4);

                StackPanel stckPerso5 = _listePersos[4].CombatCardDesign();
                Grid.SetRow(stckPerso5, 4);
                Grid.SetColumn(stckPerso5, 0);
                grdMatch.Children.Add(stckPerso5);

                fin = true;
            }


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

            BtnAttaque1.Content = _listePersos[_turnSelector].ListeAttaque[0].Nom;
            BtnAttaque1.IsEnabled = true;
            BtnAttaque2.Content = _listePersos[_turnSelector].ListeAttaque[1].Nom;
            BtnAttaque2.IsEnabled = true;
            BtnAttaque3.Content = _listePersos[_turnSelector].ListeAttaque[2].Nom;
            BtnAttaque3.IsEnabled = true;
            
            switch (_turnSelector)
            {
                case 0:
                    //tour du personnage 1

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
