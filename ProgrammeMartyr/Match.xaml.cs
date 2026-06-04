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

        private Utilisateur _user;

        private bool[] isCharacterAlive;

        private bool _isPlayerTurn;

        private RadioButton rdbAttaque1;
        private RadioButton rdbAttaque2;
        private RadioButton rdbAttaque3;
        private RadioButton rdbAttaque4;
        private RadioButton rdbAttaque5;

        public Match(List<Personnage> listeEnemis, List<Personnage> listePersos, ListeGenerale Glist, Utilisateur user)
        {
            InitializeComponent();
            GetPersos(listeEnemis, listePersos);
            _listG = Glist;
            _user = user;
            BtnAttaque1.Click += new RoutedEventHandler(BtnAttaque1_Click);
            BtnAttaque2.Click += new RoutedEventHandler(BtnAttaque2_Click);
            BtnAttaque3.Click += new RoutedEventHandler(BtnAttaque3_Click);
            PrepBoard();
            GetMods();
            PrepNextTurn();
        }

        private void GetPersos(List<Personnage> listeEnemis, List<Personnage> listePersos)
        {
            _listeEnemis = new List<Personnage>();
            foreach (var ennemi in listeEnemis)
            {
                string[] img = ennemi.Img.ToString().Split('/');
                Personnage ennemiCopy = new Personnage(ennemi.Nom, ennemi.Role, ennemi.Rarete, ennemi.NiveauMax, ennemi.PvMax, img[2], ennemi.Id);
                ennemiCopy.ListeAttaque = ennemi.ListeAttaque;
                _listeEnemis.Add(ennemiCopy);
            }

            _listePersos = new List<Personnage>();
            foreach(var perso in listePersos)
            {
                string[] img = perso.Img.ToString().Split('/');
                Personnage persoCopy = new Personnage(perso.Nom, perso.Role, perso.Rarete, perso.NiveauMax, perso.PvMax, img[2], perso.Id);
                persoCopy.ListeAttaque = perso.ListeAttaque;
                _listePersos.Add(persoCopy);
            }
        }

        public void PrepBoard()
        {
            //Affichage des ennemis
            if (_listeEnemis[0].PvGame > 0)
            {
                StackPanel stckEnemi1 = _listeEnemis[0].CombatCardDesign();
                Grid.SetRow(stckEnemi1, 0);
                Grid.SetColumn(stckEnemi1, 4);
                grdMatch.Children.Add(stckEnemi1);
                rdbAttaque1 = new RadioButton();
                
                Grid.SetRow(rdbAttaque1, 0);
                Grid.SetColumn(rdbAttaque1, 4);
                grdMatch.Children.Add(rdbAttaque1);
            }

            if (_listeEnemis.Count > 1)
            {
                if (_listeEnemis[1].PvGame > 0)
                {
                    StackPanel stckEnemi2 = _listeEnemis[1].CombatCardDesign();
                    Grid.SetRow(stckEnemi2, 1);
                    Grid.SetColumn(stckEnemi2, 3);
                    grdMatch.Children.Add(stckEnemi2);
                    rdbAttaque2 = new RadioButton();
                    Grid.SetRow(rdbAttaque2, 1);
                    Grid.SetColumn(rdbAttaque2, 3);
                    grdMatch.Children.Add(rdbAttaque2);
                }

                if (_listeEnemis.Count > 2)
                {
                    if (_listeEnemis[2].PvGame > 0)
                    {
                        StackPanel stckEnemi3 = _listeEnemis[2].CombatCardDesign();
                        Grid.SetRow(stckEnemi3, 2);
                        Grid.SetColumn(stckEnemi3, 4);
                        grdMatch.Children.Add(stckEnemi3);

                        rdbAttaque3 = new RadioButton();
                        Grid.SetRow(rdbAttaque3, 2);
                        Grid.SetColumn(rdbAttaque3, 4);
                        grdMatch.Children.Add(rdbAttaque3);
                    }

                    if (_listeEnemis.Count > 3)
                    {
                        if (_listeEnemis[3].PvGame > 0)
                        {
                            StackPanel stckEnemi4 = _listeEnemis[3].CombatCardDesign();
                            Grid.SetRow(stckEnemi4, 3);
                            Grid.SetColumn(stckEnemi4, 3);
                            grdMatch.Children.Add(stckEnemi4);

                            rdbAttaque4 = new RadioButton();
                            Grid.SetRow(rdbAttaque4, 3);
                            Grid.SetColumn(rdbAttaque4, 3);
                            grdMatch.Children.Add(rdbAttaque4);
                        }

                        if (_listeEnemis.Count > 4)
                        {
                            if (_listeEnemis[4].PvGame > 0)
                            {
                                StackPanel stckEnemi5 = _listeEnemis[4].CombatCardDesign();
                                Grid.SetRow(stckEnemi5, 4);
                                Grid.SetColumn(stckEnemi5, 4);
                                grdMatch.Children.Add(stckEnemi5);

                                rdbAttaque5 = new RadioButton();
                                Grid.SetRow(rdbAttaque5, 4);
                                Grid.SetColumn(rdbAttaque5, 4);
                                grdMatch.Children.Add(rdbAttaque5);
                            }
                        }
                    }
                }
            }

            rdbAttaque1.IsChecked = false;
            if (_listeEnemis.Count > 1)
            {
                rdbAttaque2.IsChecked = false;
                if (_listeEnemis.Count > 2)
                {
                    rdbAttaque3.IsChecked = false;
                    if (_listeEnemis.Count > 3)
                    {
                        rdbAttaque4.IsChecked = false;
                        if (_listeEnemis.Count > 4)
                        {
                            rdbAttaque5.IsChecked = false;
                        }
                    }
                }
            }


            //Affichage des personnages
            isCharacterAlive = new bool[_listePersos.Count];
            foreach (var perso in _listePersos)
            {
                if (perso.PvGame > 0)
                {
                    isCharacterAlive[_listePersos.IndexOf(perso)] = true;
                }
                else
                {
                    isCharacterAlive[_listePersos.IndexOf(perso)] = false;
                }
            }


            if (_listePersos[0].PvGame <= 0)
            {
                TextBlock txtDefaite = new TextBlock();
                txtDefaite.Text = "Ce personnage est vaincu !";
                txtDefaite.FontSize = 16;
                txtDefaite.TextAlignment = System.Windows.TextAlignment.Center;
                Grid.SetRow(txtDefaite, 0);
                Grid.SetColumn(txtDefaite, 0);
                grdMatch.Children.Add(txtDefaite);
            }
            else
            {
                StackPanel stckPerso1 = _listePersos[0].CombatCardDesign();
                Grid.SetRow(stckPerso1, 0);
                Grid.SetColumn(stckPerso1, 0);
                grdMatch.Children.Add(stckPerso1);
            }

            if (_listePersos.Count > 1)
            {
                if (_listePersos[1].PvGame <= 0)
                {
                    TextBlock txtDefaite = new TextBlock();
                    txtDefaite.Text = "Ce personnage est vaincu !";
                    txtDefaite.FontSize = 16;
                    txtDefaite.TextAlignment = System.Windows.TextAlignment.Center;
                    Grid.SetRow(txtDefaite, 1);
                    Grid.SetColumn(txtDefaite, 1);
                    grdMatch.Children.Add(txtDefaite);
                }
                else
                {
                    StackPanel stckPerso2 = _listePersos[1].CombatCardDesign();
                    Grid.SetRow(stckPerso2, 1);
                    Grid.SetColumn(stckPerso2, 1);
                    grdMatch.Children.Add(stckPerso2);
                } 
                if (_listePersos.Count > 2)
                {
                    if (_listePersos[2].PvGame <= 0)
                    {
                        TextBlock txtDefaite = new TextBlock();
                        txtDefaite.Text = "Ce personnage est vaincu !";
                        txtDefaite.FontSize = 16;
                        txtDefaite.TextAlignment = System.Windows.TextAlignment.Center;
                        Grid.SetRow(txtDefaite, 2);
                        Grid.SetColumn(txtDefaite, 0);
                        grdMatch.Children.Add(txtDefaite);
                    }
                    else
                    {
                        StackPanel stckPerso3 = _listePersos[2].CombatCardDesign();
                        Grid.SetRow(stckPerso3, 2);
                        Grid.SetColumn(stckPerso3, 0);
                        grdMatch.Children.Add(stckPerso3);
                    }
                    if (_listePersos.Count > 3)
                    {
                        if (_listePersos[3].PvGame <= 0)
                        {
                            TextBlock txtDefaite = new TextBlock();
                            txtDefaite.Text = "Ce personnage est vaincu !";
                            txtDefaite.FontSize = 16;
                            txtDefaite.TextAlignment = System.Windows.TextAlignment.Center;
                            Grid.SetRow(txtDefaite, 3);
                            Grid.SetColumn(txtDefaite, 1);
                            grdMatch.Children.Add(txtDefaite);
                        }
                        else
                        {
                            StackPanel stckPerso4 = _listePersos[3].CombatCardDesign();
                            Grid.SetRow(stckPerso4, 3);
                            Grid.SetColumn(stckPerso4, 1);
                            grdMatch.Children.Add(stckPerso4);
                        }
                        if (_listePersos.Count > 4)
                        {
                            if (_listePersos[4].PvGame <= 0)
                            {
                                TextBlock txtDefaite = new TextBlock();
                                txtDefaite.Text = "Ce personnage est vaincu !";
                                txtDefaite.FontSize = 16;
                                txtDefaite.TextAlignment = System.Windows.TextAlignment.Center;
                                Grid.SetRow(txtDefaite, 4);
                                Grid.SetColumn(txtDefaite, 0);
                                grdMatch.Children.Add(txtDefaite);
                            }
                            else
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
        }

        public void PrepNextTurn()
        {
            _isPlayerTurn = true;
            if(_turnSelector > _listePersos.Count - 1)
            {
                _isPlayerTurn = false;
                foreach (Personnage perso in _listeEnemis)
                {
                    //section de l'ia
                    Random rand = new Random();
                    int target;
                    do
                    {
                        target = rand.Next(0, _listePersos.Count);
                    } while (isCharacterAlive[target] == false);

                    int attaqueIndex;
                    do
                    {
                        attaqueIndex = rand.Next(0, 3);
                    } while (perso.ListeAttaque[attaqueIndex].Cooldown != 0);

                    TourJoue(attaqueIndex, _listePersos[target], perso);
                }
                _isPlayerTurn = true;
                _turnSelector = 0;
            }


            ClearGridExceptLastRow();
            PrepBoard();

            BtnAttaque1.Content = $"{_listePersos[_turnSelector].ListeAttaque[0].Nom}\n{_listePersos[_turnSelector].ListeAttaque[0].Puissance} degats";
            BtnAttaque1.IsEnabled = true;
            BtnAttaque2.Content = $"{_listePersos[_turnSelector].ListeAttaque[1].Nom}\n{_listePersos[_turnSelector].ListeAttaque[1].Puissance} degats";
            BtnAttaque2.IsEnabled = true;
            BtnAttaque3.Content = $"{_listePersos[_turnSelector].ListeAttaque[2].Nom}\n{_listePersos[_turnSelector].ListeAttaque[2].Puissance} degats";
            BtnAttaque3.IsEnabled = true;

            if (_listePersos[_turnSelector].ListeAttaque[1].Cooldown != 0)
            {
                BtnAttaque2.IsEnabled = false;
            }

            if(_listePersos[_turnSelector].ListeAttaque[2].Cooldown != 0)
            {
                BtnAttaque3.IsEnabled = false;
            }

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

        /// <summary>
        /// Clears all children from the grid except those that are placed in the last row (by Grid.Row).
        /// If the grid has no RowDefinitions, all children are removed.
        /// </summary>
        public void ClearGridExceptLastRow()
        {
            if (grdMatch == null) return;

            int lastRowIndex = grdMatch.RowDefinitions.Count - 1;

            // If there are no row definitions, clear everything.
            if (lastRowIndex < 0)
            {
                grdMatch.Children.Clear();
                return;
            }

            // Collect elements to keep (those in the last row).
            var keep = new System.Collections.Generic.HashSet<System.Windows.UIElement>();
            foreach (var child in grdMatch.Children.OfType<System.Windows.UIElement>())
            {
                if (System.Windows.Controls.Grid.GetRow(child) == lastRowIndex)
                {
                    keep.Add(child);
                }
            }

            // Remove all children that are not in the keep set (iterate backwards to remove safely).
            for (int i = grdMatch.Children.Count - 1; i >= 0; i--)
            {
                var child = grdMatch.Children[i] as System.Windows.UIElement;
                if (child != null && !keep.Contains(child))
                {
                    grdMatch.Children.RemoveAt(i);
                }
            }
        }

        public void CooldownUpdate()
        {
            foreach (var perso in _listePersos)
            {
                foreach (var attaque in perso.ListeAttaque)
                {
                    if (attaque.Cooldown > 0)
                    {
                        attaque.Cooldown--;
                    }
                }
            }
        }

        public bool CheckEndGame(out Image imgFin)
        {
            bool allEnemisDefeated = true;
            foreach (var ennemi in _listeEnemis)
            {
                if (ennemi.PvGame > 0)
                {
                    allEnemisDefeated = false;
                }
            }

            bool allPersosDefeated = true;
            foreach (var perso in _listePersos)
            {
                if (perso.PvGame > 0)
                {
                    allPersosDefeated = false;
                }
            }
            imgFin = new Image();
            if (allEnemisDefeated)
            {
                imgFin.Source = new BitmapImage(new Uri("Images/victoire.png", UriKind.Relative));
                return true;

            }
            else if (allPersosDefeated)
            {
                imgFin.Source = new BitmapImage(new Uri("Images/defaite.png", UriKind.Relative));
                return true;
            }
            else
            {
                return false;
            }
        }

        public void GiveReward()
        {
            int nbrMoney = 0;
            int nbrCrystal = 0;
            int nbrUpgrade = 0;

            foreach (var ennemi in _listeEnemis)
            {
                nbrMoney += 10 * ennemi.Rarete;
                Random rand = new Random();
                if(rand.Next(0, 2) == 1)
                {
                    nbrCrystal += 1;
                }
                if(rand.Next(0,10) == 1)
                {
                    nbrUpgrade += 1;
                }
            }

            _user.Inventaire.Items[0] += nbrMoney;
            _user.Inventaire.Items[1] += nbrCrystal;
            _user.Inventaire.Items[2] += nbrUpgrade;

            BddManager bdd = new BddManager();
            bdd.UpdateInventaire(_user.Id, _user.Inventaire.Items[0], _user.Inventaire.Items[1], _user.Inventaire.Items[2]);
        }

        public void GetMods()
        {
            foreach (var mod in _listG.Modifiers)
            {
                _mods.Add(mod);
            }
        }

        private void TourJoue(int attaque, Personnage ennemiChoisi, Personnage attaquant)
        {
            CooldownUpdate();
            
            ennemiChoisi.PvGame -= attaquant.ListeAttaque[attaque].Puissance;

            if(attaque > 0)
            {
                attaquant.ListeAttaque[attaque].Cooldown = attaquant.ListeAttaque[attaque].Role * 2;
            }

            _turnSelector++;

            if (!CheckEndGame(out Image imgFin))
            {
                if (_isPlayerTurn)
                {
                    PrepNextTurn();
                }
            }
            else
            {
                GiveReward();
                //Retour au menu
                MessageBox.Show("Le match est terminé ! Vous allez être redirigé vers le menu.");
                var parent = Window.GetWindow(this) as Jeu;
                parent.RemoveChildrenAt(1, 1);
                parent.OuvrirePageMenu();
            }
        }

        private int checkTarget()
        {
            int ennemiChoisi = -1;
            if (rdbAttaque1.IsChecked == true)
            {
                ennemiChoisi = 0;
            }
            else
            {
                if (_listeEnemis.Count > 1)
                {
                    if (rdbAttaque2.IsChecked == true)
                    {
                        ennemiChoisi = 1;
                    }
                    else
                    {
                        if (_listeEnemis.Count > 2)
                        {
                            if (rdbAttaque3.IsChecked == true)
                            {
                                ennemiChoisi = 2;
                            }
                            else
                            {
                                if (_listeEnemis.Count > 3)
                                {
                                    if (rdbAttaque4.IsChecked == true)
                                    {
                                        ennemiChoisi = 3;
                                    }
                                    else
                                    {
                                        if (_listeEnemis.Count > 4)
                                        {
                                            if (rdbAttaque5.IsChecked == true)
                                            {
                                                ennemiChoisi = 4;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return ennemiChoisi;
        }

        private void BtnAttaque1_Click(object sender, RoutedEventArgs e)
        {
            int ennemiChoisi = checkTarget();

            if (ennemiChoisi == -1)
            {
                MessageBox.Show("Veuillez sélectionner un ennemi à attaquer.");
                return;
            }
            else
            {
                int attaqueIndex = 0;
                TourJoue(attaqueIndex, _listeEnemis[ennemiChoisi], _listePersos[_turnSelector]);
            }
        }

        private void BtnAttaque2_Click(object sender, RoutedEventArgs e)
        {
            int ennemiChoisi = checkTarget();

            if (ennemiChoisi == -1)
            {
                MessageBox.Show("Veuillez sélectionner un ennemi à attaquer.");
                return;
            }
            else
            {
                int attaqueIndex = 1;
                TourJoue(attaqueIndex, _listeEnemis[ennemiChoisi], _listePersos[_turnSelector]);
            }
        }

        private void BtnAttaque3_Click(object sender, RoutedEventArgs e)
        {
            int ennemiChoisi = checkTarget();

            if (ennemiChoisi == -1)
            {
                MessageBox.Show("Veuillez sélectionner un ennemi à attaquer.");
                return;
            }
            else
            {
                int attaqueIndex = 2;
                TourJoue(attaqueIndex, _listeEnemis[ennemiChoisi], _listePersos[_turnSelector]);
            }
        }

    }
}
