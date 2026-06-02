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
            RadioButton rdbAttaque1 = new RadioButton();
            
            Grid.SetRow(rdbAttaque1, 0);
            Grid.SetColumn(rdbAttaque1, 4);
            grdMatch.Children.Add(rdbAttaque1);

            if (_listeEnemis.Count > 1)
            {
                StackPanel stckEnemi2 = _listeEnemis[1].CombatCardDesign();
                Grid.SetRow(stckEnemi2, 1);
                Grid.SetColumn(stckEnemi2, 3);
                grdMatch.Children.Add(stckEnemi2);


                if(_listeEnemis.Count > 2)
                {
                    StackPanel stckEnemi3 = _listeEnemis[2].CombatCardDesign();
                    Grid.SetRow(stckEnemi3, 2);
                    Grid.SetColumn(stckEnemi3, 4);
                    grdMatch.Children.Add(stckEnemi3);


                    if (_listeEnemis.Count > 3)
                    {

                        StackPanel stckEnemi4 = _listeEnemis[3].CombatCardDesign();
                        Grid.SetRow(stckEnemi4, 3);
                        Grid.SetColumn(stckEnemi4, 3);
                        grdMatch.Children.Add(stckEnemi4);


                        if(_listeEnemis.Count > 4)
                        {
                            StackPanel stckEnemi5 = _listeEnemis[4].CombatCardDesign();
                            Grid.SetRow(stckEnemi5, 4);
                            Grid.SetColumn(stckEnemi5, 4);
                            grdMatch.Children.Add(stckEnemi5);
                        }
                    }
                }
            }

            StackPanel stckPerso1 = _listePersos[0].CombatCardDesign();
            Grid.SetRow(stckPerso1, 0);
            Grid.SetColumn(stckPerso1, 0);
            grdMatch.Children.Add(stckPerso1);

            if (_listePersos.Count > 1)
            {
                StackPanel stckPerso2 = _listePersos[1].CombatCardDesign();
                Grid.SetRow(stckPerso2, 1);
                Grid.SetColumn(stckPerso2, 1);
                grdMatch.Children.Add(stckPerso2);
                
                if (_listePersos.Count > 2)
                {
                
                    StackPanel stckPerso3 = _listePersos[2].CombatCardDesign();
                    Grid.SetRow(stckPerso3, 2);
                    Grid.SetColumn(stckPerso3, 0);
                    grdMatch.Children.Add(stckPerso3);

                    if (_listePersos.Count > 3)
                    {
                
                        StackPanel stckPerso4 = _listePersos[3].CombatCardDesign();
                        Grid.SetRow(stckPerso4, 3);
                        Grid.SetColumn(stckPerso4, 1);
                        grdMatch.Children.Add(stckPerso4);

                        if (_listePersos.Count > 4)
                        {
                            StackPanel stckPerso5 = _listePersos[4].CombatCardDesign();
                            Grid.SetRow(stckPerso5, 4);
                            Grid.SetColumn(stckPerso5, 0);
                            grdMatch.Children.Add(stckPerso5);
                        }
                    }
                }
            }
        }

        public void PrepNextTurn()
        {
            if(_turnSelector > _listePersos.Count - 1)
            {
                _turnSelector = 0;
                foreach(Personnage perso in _listeEnemis)
                {
                    //section de l'ia
                }
            }

            BtnAttaque1.Content = _listePersos[_turnSelector].ListeAttaque[0].Nom;
            BtnAttaque1.IsEnabled = true;
            BtnAttaque2.Content = _listePersos[_turnSelector].ListeAttaque[1].Nom;
            BtnAttaque2.IsEnabled = true;
            BtnAttaque3.Content = _listePersos[_turnSelector].ListeAttaque[2].Nom;
            BtnAttaque3.IsEnabled = true;
            


            //test
            _listePersos[_turnSelector].ListeModifiersActifs.Add(_mods[3]);

            Image imgJoueurActif = new Image();
            imgJoueurActif.Name = "imgJoueurActif";
            imgJoueurActif.Source = new BitmapImage(new Uri(_listePersos[_turnSelector].Img, UriKind.Relative));
            imgJoueurActif.Height = 50;
            imgJoueurActif.Width = 50;
            imgJoueurActif.VerticalAlignment = VerticalAlignment.Top; 
            imgJoueurActif.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(imgJoueurActif, 5);
            Grid.SetColumn(imgJoueurActif, 0);
            grdMatch.Children.Add(imgJoueurActif);

            if (_listePersos[_turnSelector].ListeModifiersActifs.Count > 0)
            {
                foreach(var mod in _listePersos[_turnSelector].ListeModifiersActifs)
                {
                    Image imgMod = new Image();
                    imgMod.Name = "imgMod";
                    imgMod.Source = new BitmapImage(new Uri(mod.Image, UriKind.Relative));
                    imgMod.Height = 50;
                    imgMod.Width = 50;
                    imgMod.HorizontalAlignment = HorizontalAlignment.Right;
                    imgMod.VerticalAlignment = VerticalAlignment.Bottom;
                    Grid.SetRow(imgMod, 5);
                    Grid.SetColumn(imgMod, 1);
                    grdMatch.Children.Add(imgMod);
                }
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
