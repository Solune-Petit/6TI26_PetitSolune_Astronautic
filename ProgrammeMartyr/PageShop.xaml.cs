using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
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
    /// Interaction logic for PageShop.xaml
    /// </summary>
    public partial class PageShop : UserControl
    {
        private List<Personnage> _listePersos, _listePersos1, _listePersos2, _listePersos3;

        private Utilisateur _user;

        private Grid _GrdJeu;

        private ListeGenerale _glist;

        public PageShop(ListeGenerale Glist, Utilisateur user, Grid grdJeu)
        {
            _glist = Glist;
            _listePersos = Glist.ListePerso;
            _GrdJeu = grdJeu;
            _user = user;
            InitializeComponent();
            btnShop1.Click += new RoutedEventHandler(btnShop1_Click);
            btnShop2.Click += new RoutedEventHandler(btnShop2_Click);
            btnShop3.Click += new RoutedEventHandler(btnShop3_Click);

            _listePersos1 = new List<Personnage>();
            _listePersos2 = new List<Personnage>();
            _listePersos3 = new List<Personnage>();
            foreach (Personnage perso in _listePersos)
            {
                if (perso.Rarete == 1 || perso.Rarete == 2 || perso.Rarete == 3)
                {
                    _listePersos1.Add(perso);
                }
                if (perso.Rarete == 4 || perso.Rarete == 2 || perso.Rarete == 3)
                {
                    _listePersos2.Add(perso);
                }
                if (perso.Rarete == 5 || perso.Rarete == 2 || perso.Rarete == 3)
                {
                    _listePersos3.Add(perso);
                }
            }

            ShowShop1();
            ShowShop2();
            ShowShop3();
        }

        private StackPanel ItemCard(string img, int chance)
        {
            StackPanel card = new StackPanel();
            card.Height = 125;
            card.Width = 100;
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(img, UriKind.Relative));
            image.Height = 100;
            image.Width = 100;
            card.Children.Add(image);
            TextBlock txtChance = new TextBlock();
            txtChance.Text = $"Chance: {chance}%";
            txtChance.HorizontalAlignment = HorizontalAlignment.Center;
            card.Children.Add(txtChance);
            return card;
        }

        private void ShopAction(int shop)
        {
            Random rand = new Random();
            int chance = rand.Next(1, 101);
            if (chance > 0 && chance < 60)
            {
                chance = 1;

            }
            else if (chance >= 60 && chance < 90)
            {
                chance = 2;
            }
            else if (chance >= 90 && chance < 100)
            {
                chance = 3;
            }

            List<Personnage> temp;
            temp = new List<Personnage>();
            switch (shop)
            {
                case 1:
                    foreach (Personnage perso in _listePersos1)
                    {
                        if (chance == perso.Rarete)
                        {
                            temp.Add(perso);
                        }
                    }
                    break;
                case 2:
                    chance++;
                    foreach (Personnage perso in _listePersos2)
                    {
                        if (perso.Rarete == chance)
                        {
                            temp.Add(perso);
                        }
                    }
                    break;
                case 3:
                    chance += 2;
                    foreach (Personnage perso in _listePersos3)
                    {
                        if (perso.Rarete == chance)
                        {
                            temp.Add(perso);
                        }
                    }
                    break;
            }

            int gain = rand.Next(temp.Count);
            bool persoPossede = false;

            foreach (Personnage perso in _user.PersosPossede)
            {
                if (perso.Id == temp[gain].Id)
                {
                    persoPossede = true;
                }
            }

            BddManager bdd = new BddManager();

            if (!persoPossede)
            {
                _user.PersosPossede.Add(temp[gain]);
                bdd.AddPersoToUser(_user, _user.PersosPossede);
            }
            else
            {
                _user.Inventaire.Items[2] += 1;
                bdd.UpdateInventaire(_user.Id, _user.Inventaire.Items[0], _user.Inventaire.Items[1], _user.Inventaire.Items[2]);
            }

            Jeu jeu = new Jeu(_user, _glist);
            jeu.Show();

        }

        private void ShowShop1()
        {
            StackPanel card;
            foreach (Personnage perso in _listePersos1)
            {
                if (perso.Rarete == 1 || perso.Rarete == 2 || perso.Rarete == 3)
                {
                    int chance;
                    if (perso.Rarete == 1)
                    {
                        chance = 60;
                    }
                    else if (perso.Rarete == 2)
                    {
                        chance = 30;
                    }
                    else
                    {
                        chance = 10;
                    }
                    card = ItemCard(perso.Img, chance);
                    stkShop1.Children.Add(card);
                }
            }
            card = ItemCard("Images/credit.PNG", 60);
            stkShop1.Children.Add(card);
        }

        private void ShowShop2()
        {
            StackPanel card;
            foreach (Personnage perso in _listePersos2)
            {
                if (perso.Rarete == 4 || perso.Rarete == 2 || perso.Rarete == 3)
                {
                    int chance;
                    if (perso.Rarete == 2)
                    {
                        chance = 60;
                    }
                    else if (perso.Rarete == 3)
                    {
                        chance = 30;
                    }
                    else
                    {
                        chance = 10;
                    }
                    card = ItemCard(perso.Img, chance);
                    card.HorizontalAlignment = HorizontalAlignment.Left;
                    card.VerticalAlignment = VerticalAlignment.Top;
                    stkShop2.Children.Add(card);
                }
            }
            card = ItemCard("Images/credit.PNG", 60);
            stkShop2.Children.Add(card);
        }

        private void ShowShop3()
        {
            StackPanel card;
            foreach (Personnage perso in _listePersos3)
            {
                if (perso.Rarete == 4 || perso.Rarete == 5 || perso.Rarete == 3)
                {
                    int chance;
                    if (perso.Rarete == 3)
                    {
                        chance = 60;
                    }
                    else if (perso.Rarete == 4)
                    {
                        chance = 30;
                    }
                    else
                    {
                        chance = 10;
                    }
                    card = ItemCard(perso.Img, chance);
                    card.HorizontalAlignment = HorizontalAlignment.Left;
                    card.VerticalAlignment = VerticalAlignment.Top;
                    stkShop3.Children.Add(card);
                }
            }
            card = ItemCard("Images/credit.PNG", 60);
            stkShop3.Children.Add(card);
        }

        private void btnShop1_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Inventaire.Items[0] < 100)
            {
                MessageBox.Show("Vous n'avez pas assez de crédits !");
                return;
            }
            else
            {
                _user.Inventaire.Items[0] -= 100;
                ShopAction(1);
            }
        }

        private void btnShop2_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Inventaire.Items[0] < 250)
            {
                MessageBox.Show("Vous n'avez pas assez de crédits !");
                return;
            }
            else
            {
                _user.Inventaire.Items[0] -= 250;
                ShopAction(2);
            }
        }

        private void btnShop3_Click(object sender, RoutedEventArgs e)
        {
            if (_user.Inventaire.Items[0] < 500)
            {
                MessageBox.Show("Vous n'avez pas assez de crédits !");
                return;
            }
            else
            {
                _user.Inventaire.Items[0] -= 500;
                ShopAction(3);
            }
        }
    }
}
