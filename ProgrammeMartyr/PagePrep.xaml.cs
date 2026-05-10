using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for PagePrep.xaml
    /// </summary>
    public partial class PagePrep : UserControl
    {

        private List<Personnage> _listeEnemis;

        public List<Personnage> ListeEnemis
        {
            get { return _listeEnemis; }
        }

        private List<Personnage> _listPerso;

        public List<Personnage> ListPerso
        {
            get { return _listPerso; }
            set { _listPerso = value; }
        }


        private Grid _grdJeu;

        private ListeGenerale _Glist;

        public PagePrep(Utilisateur user, Grid grdJeu, ListeGenerale Glist)
        {
            InitializeComponent();
            ChoisirEnemis(Glist);
            _Glist = Glist;
            _grdJeu = grdJeu;
            RemplireCmb(user);
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {

            //fixer la verification des choix

            List<string> listChoix = new List<string>();
            _listPerso = new List<Personnage>();

            for (int i = 0; i < 5; i++)
            {
                if (i == 0 && CmbPerso1.SelectedIndex != -1)
                {
                    listChoix.Add(CmbPerso1.SelectedIndex.ToString());
                }
                else if (i == 1 && CmbPerso2.SelectedIndex != -1)
                {
                    listChoix.Add(CmbPerso2.SelectedIndex.ToString());
                }
                else if (i == 2 && CmbPerso3.SelectedIndex != -1)
                {
                    listChoix.Add(CmbPerso3.SelectedIndex.ToString());
                }
                else if (i == 3 && CmbPerso4.SelectedIndex != -1)
                {
                    listChoix.Add(CmbPerso4.SelectedIndex.ToString());
                }
                else if (i == 4 && CmbPerso5.SelectedIndex != -1)
                {
                    listChoix.Add(CmbPerso5.SelectedIndex.ToString());
                }
            }

            //vérifier les doublons
            bool doublon = false;

            for (int i = 0; i < listChoix.Count; i++)
            {
                for(int j = i; j < listChoix.Count; j++)
                {
                    if (listChoix[i] == listChoix[j] && i != j)
                    {
                        doublon = true;
                    }
                }
            }



            if (!doublon)
            {
                //convertir les donnees en Personnage perso pour les envoyer a la page match
                for(int i = 0; i < listChoix.Count; i++)
                {
                    for(int j = 0; j < _Glist.ListePerso.Count; j++)
                    {
                        if(listChoix[i] == _Glist.ListePerso[j].Nom)
                        {
                            _listPerso.Add(_Glist.ListePerso[j]);
                        }
                    }
                }

                var parent = Window.GetWindow(this) as Jeu;
                parent.RemoveChildrenAt(1, 1);
                PageMatch pageMatch = new PageMatch(_listeEnemis, _listPerso);
                Grid.SetColumn(pageMatch, 1);
                Grid.SetRow(pageMatch, 1);
                _grdJeu.Children.Add(pageMatch);
            }
            else
            {
                MessageBox.Show("Vous ne pouvez pas choisir le même personnage plusieurs fois !");
            }
        }

        public void RemplireCmb(Utilisateur user)
        {
            foreach (Personnage persos in user.PersosPossede)
            {
                CmbPerso1.Items.Add(persos.Nom);
                CmbPerso2.Items.Add(persos.Nom);
                CmbPerso3.Items.Add(persos.Nom);
                CmbPerso4.Items.Add(persos.Nom);
                CmbPerso5.Items.Add(persos.Nom);

            }
        }

        public void ChoisirEnemis(ListeGenerale Glist)
        {
            _listeEnemis = new List<Personnage>();
            Random rand = new Random();
            int nbrEnemis = rand.Next(1, 6);
            for (int i = 0; i < nbrEnemis; i++)
            {
                int enemi = rand.Next(0, Glist.ListePerso.Count);
                _listeEnemis.Add(Glist.ListePerso[enemi]);
                TextBlock Perso = new TextBlock();
                Perso.Text = Glist.ListePerso[enemi].Nom;
                Grid.SetRow(Perso, i+2);
                Grid.SetColumn(Perso, 0);
                grdPrep.Children.Add(Perso);
            }
        }
    }
}
