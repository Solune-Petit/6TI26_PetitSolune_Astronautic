using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProgrammeMartyr
{
    internal class Fonctions
    {
        /// <summary>
        /// Cette fonction permet d'ouvrir la fenêtre de menu qui s'affiche au début du programme et qui permet de choisir entre
        /// la fenêtre de dev, la fenêtre de log-in et la fenêtre de création de compte
        /// </summary>
        /// <param name="grdMain"></param>
        public void OuvrirFenetreMenu(Grid grdMain, ListeGenerale listeG)
        {
            NettoyerGrid(grdMain, 1, 3);

            //bouton pour accéder au mode DEV
            Button btnDev = new Button();
            btnDev.Content = "Section Dev";
            btnDev.Foreground = new SolidColorBrush(Colors.White);
            btnDev.Background = new SolidColorBrush(Colors.Red);
            btnDev.Height = 100;
            btnDev.Width = 300;
            btnDev.FontSize = 24;
            btnDev.FontWeight = System.Windows.FontWeights.Bold;
            btnDev.BorderThickness = new System.Windows.Thickness(3);
            btnDev.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnDev.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            btnDev.Click += (s, e) => OuvrirFenetreDev(grdMain, listeG);
            Grid.SetColumn(btnDev, 0);
            Grid.SetRow(btnDev, 0);
            grdMain.Children.Add(btnDev);

            //bouton pour accéder à la page de log-in
            Button btnLogin = new Button();
            btnLogin.Content = "Log-in";
            btnLogin.Foreground = new SolidColorBrush(Colors.White);
            btnLogin.Background = new SolidColorBrush(Colors.Blue);
            btnLogin.Height = 100;
            btnLogin.Width = 300;
            btnLogin.FontSize = 24;
            btnLogin.FontWeight = System.Windows.FontWeights.Bold;
            btnLogin.BorderThickness = new System.Windows.Thickness(3);
            btnLogin.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnLogin.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(btnLogin, 1);
            Grid.SetRow(btnLogin, 0);
            grdMain.Children.Add(btnLogin);
            btnLogin.Click += (s, e) => OuvrirFenetreLogin(grdMain);

            //bouton pour accéder à la page de création de compte
            Button btnCreate = new Button();
            btnCreate.Content = "Créer un compte";
            btnCreate.Foreground = new SolidColorBrush(Colors.White);
            btnCreate.Background = new SolidColorBrush(Colors.Green);
            btnCreate.Height = 100;
            btnCreate.Width = 300;
            btnCreate.FontSize = 24;
            btnCreate.FontWeight = System.Windows.FontWeights.Bold;
            btnCreate.BorderThickness = new System.Windows.Thickness(3);
            btnCreate.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnCreate.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(btnCreate, 2);
            Grid.SetRow(btnCreate, 0);
            grdMain.Children.Add(btnCreate);
            btnCreate.Click += (s, e) => OuvrirFenetreCreateAccount(grdMain);
        }

        /// <summary>
        /// Cette fonction permet de nettoyer un grid en supprimant tous les éléments qu'il contient et en redéfinissant
        /// le nombre de lignes et de colonnes du grid.
        /// </summary>
        /// <param name="grdMain"></param>
        /// <param name="nbLignes"></param>
        /// <param name="nbCollones"></param>
        public void NettoyerGrid(Grid grdMain, int nbLignes, int nbCollones)
        {
            grdMain.Children.Clear();
            grdMain.RowDefinitions.Clear();
            grdMain.ColumnDefinitions.Clear();

            //definition des colonnes
            ColumnDefinition[] colDef = new ColumnDefinition[nbCollones];
            for (int i = 0; i < nbCollones; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }

            //definition des lignes
            RowDefinition[] rowDef = new RowDefinition[nbLignes];
            for (int i = 0; i < nbLignes; i++)
            {
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }
        }

        /// <summary>
        /// Cette fonction permet d'ouvrir la fenêtre de détails d'un personnage, qui affiche les informations du personnage sous forme de cartes.
        /// </summary>
        /// <param name="grdMain">Le grid principal de la fenêtre</param>
        /// <param name="persos">La liste des personnages à afficher dans la fenêtre de détails</param>
        public void OuvrirFenetreDetails(Grid grdMain, List<Personnage> persos)
        {
            NettoyerGrid(grdMain, 10, 10);

            //ajout des cartes de personnages
            int temp = 0;
            int temp2 = 0;
            foreach (Personnage perso in persos)
            {
                if (perso != null)
                {
                    StackPanel card = perso.GenInfoCardDesign();
                    Grid.SetColumn(card, temp);
                    Grid.SetRow(card, temp2);
                    grdMain.Children.Add(card);
                }
                temp++;
                if (temp > 3)
                {
                    temp = 0;
                    temp2++;
                }
            }
        }

        /// <summary>
        /// Cette fonction permet d'ouvrir la fenêtre de dev qui est une fenêtre de test pour les différentes fonctionnalités du programme comme
        /// les disignes des cartes, les différentes listes, etc.
        /// C'est une fenêtre qui est en cours de développement et qui n'est pas encore terminée. Elle n'est pas destinée à être utilisée par les utilisateurs finaux
        /// </summary>
        /// <param name="grdMain"></param>
        /// <param name="listeG"></param>
        public void OuvrirFenetreDev(Grid grdMain, ListeGenerale listeG)
        {
            NettoyerGrid(grdMain, 5, 5);

            //ajout d'un bouton pour revenir au menu
            Button btnMenu = new Button();
            btnMenu.Content = "Retour au menu";
            btnMenu.Foreground = new SolidColorBrush(Colors.White);
            btnMenu.Background = new SolidColorBrush(Colors.Gray);
            btnMenu.Height = 50;
            btnMenu.Width = 200;
            btnMenu.FontSize = 16;
            btnMenu.FontWeight = System.Windows.FontWeights.Bold;
            btnMenu.BorderThickness = new System.Windows.Thickness(3);
            btnMenu.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnMenu.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(btnMenu, 0);
            Grid.SetRow(btnMenu, 0);
            grdMain.Children.Add(btnMenu);
            btnMenu.Click += (s, e) => OuvrirFenetreMenu(grdMain, listeG);


            //ajout d'une combo box pour selectionner un personnage et afficher ses informations
            ComboBox cbPersonnages = new ComboBox();
            for (int i = 0; i < listeG.ListePerso.Count; i++)
            {
                cbPersonnages.Items.Add(listeG.ListePerso[i].Nom);
            }
            cbPersonnages.HorizontalContentAlignment = System.Windows.HorizontalAlignment.Center;
            cbPersonnages.VerticalContentAlignment = System.Windows.VerticalAlignment.Center;
            cbPersonnages.Width = 200;
            cbPersonnages.Height = 30;
            cbPersonnages.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            cbPersonnages.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(cbPersonnages, 1);
            Grid.SetRow(cbPersonnages, 0);
            grdMain.Children.Add(cbPersonnages);

            cbPersonnages.SelectionChanged += (s, e) =>
            {
                StackPanel card = null;
                grdMain.Children.Remove(card);
                int index = cbPersonnages.SelectedIndex;
                if (index >= 0)
                {
                    Personnage perso = listeG.ListePerso[index];
                    card = perso.GenInfoCardDesign();
                    card.Background = new SolidColorBrush(Colors.LightGray);
                    // centrer la carte dans la cellule
                    Grid.SetColumn(card, 1);
                    Grid.SetRow(card, 1);
                    Grid.SetRowSpan(card, 2);
                    grdMain.Children.Add(card);
                }
            };

            ///ajouter les autres choses voulues sur le menu dev en dessous
        }

        ///<summary>
        ///Cette fonction permet d'ouvrir la fenêtre de log-in qui permet aux utilisateurs de se connecter à leur 
        ///compte pour accéder à leurs personnages, leurs parties, etc.
        ///</summary>
        ///<param name="grdMain"></param>
        public void OuvrirFenetreLogin(Grid grdMain)
        {
            NettoyerGrid(grdMain, 4, 3);

            Button btnRetour = new Button();
            btnRetour.Content = "Retour au menu";
            btnRetour.Foreground = new SolidColorBrush(Colors.White);
            btnRetour.Background = new SolidColorBrush(Colors.Gray);
            btnRetour.Height = 50;
            btnRetour.Width = 200;
            btnRetour.FontSize = 16;
            btnRetour.FontWeight = System.Windows.FontWeights.Bold;
            btnRetour.BorderThickness = new System.Windows.Thickness(3);
            btnRetour.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnRetour.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(btnRetour, 0);
            Grid.SetRow(btnRetour, 0);
            grdMain.Children.Add(btnRetour);
            btnRetour.Click += (s, e) => OuvrirFenetreMenu(grdMain, new ListeGenerale());

            TextBlock tblMail = new TextBlock();
            tblMail.Text = "Adresse mail :";
            tblMail.FontSize = 16;
            tblMail.FontWeight = System.Windows.FontWeights.Bold;
            tblMail.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            tblMail.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(tblMail, 0);
            Grid.SetRow(tblMail, 1);
            grdMain.Children.Add(tblMail);

            TextBox txtMail = new TextBox();
            txtMail.Width = 300;
            txtMail.Height = 20;
            Grid.SetColumn(txtMail, 1);
            Grid.SetRow(txtMail, 1);
            grdMain.Children.Add(txtMail);

            TextBlock tblPassword = new TextBlock();
            tblPassword.Text = "Mot de passe :";
            tblPassword.FontSize = 16;
            tblPassword.FontWeight = System.Windows.FontWeights.Bold;
            tblPassword.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            tblPassword.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(tblPassword, 0);
            Grid.SetRow(tblPassword, 2);
            grdMain.Children.Add(tblPassword);

            TextBox txtPassword = new TextBox();
            txtPassword.Width = 300;
            txtPassword.Height = 20;
            Grid.SetColumn(txtPassword, 1);
            Grid.SetRow(txtPassword, 2);
            grdMain.Children.Add(txtPassword);

            Button btnSubmit = new Button();
            btnSubmit.Content = "Se connecter";
            btnSubmit.Foreground = new SolidColorBrush(Colors.White);
            btnSubmit.Background = new SolidColorBrush(Colors.Red);
            btnSubmit.Height = 30;
            btnSubmit.Width = 150;
            btnSubmit.FontSize = 16;
            btnSubmit.FontWeight = System.Windows.FontWeights.Bold;
            btnSubmit.BorderThickness = new System.Windows.Thickness(3);
            btnSubmit.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnSubmit.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(btnSubmit, 1);
            Grid.SetRow(btnSubmit, 3);
            grdMain.Children.Add(btnSubmit);
            btnSubmit.Click += (s, e) =>
            {
                string mail = txtMail.Text;
                string password = txtPassword.Text;
                BddManager bdd = new BddManager();
                if (bdd.ConnectUser(txtMail.Text, txtPassword.Text))
                {
                    OuvrirFenetreJeu(grdMain);
                }
            };
        }

        /// <summary>
        /// Ouvrir la fenêtre pour créer un compte
        /// </summary>
        /// <param name="grdMain"></param>
        public void OuvrirFenetreCreateAccount(Grid grdMain)
        {
            NettoyerGrid(grdMain, 5, 3);

            Button btnRetour = new Button();
            btnRetour.Content = "Retour au menu";
            btnRetour.Foreground = new SolidColorBrush(Colors.White);
            btnRetour.Background = new SolidColorBrush(Colors.Gray);
            btnRetour.Height = 50;
            btnRetour.Width = 200;
            btnRetour.FontSize = 16;
            btnRetour.FontWeight = System.Windows.FontWeights.Bold;
            btnRetour.BorderThickness = new System.Windows.Thickness(3);
            btnRetour.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnRetour.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(btnRetour, 0);
            Grid.SetRow(btnRetour, 0);
            grdMain.Children.Add(btnRetour);
            btnRetour.Click += (s, e) => OuvrirFenetreMenu(grdMain, new ListeGenerale());

            TextBlock tblMail = new TextBlock();
            tblMail.Text = "Adresse mail :";
            tblMail.FontSize = 16;
            tblMail.FontWeight = System.Windows.FontWeights.Bold;
            tblMail.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            tblMail.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(tblMail, 0);
            Grid.SetRow(tblMail, 1);
            grdMain.Children.Add(tblMail);

            TextBox txtMail = new TextBox();
            txtMail.Width = 300;
            txtMail.Height = 20;
            Grid.SetColumn(txtMail, 1);
            Grid.SetRow(txtMail, 1);
            grdMain.Children.Add(txtMail);

            TextBlock tblPassword = new TextBlock();
            tblPassword.Text = "Mot de passe :";
            tblPassword.FontSize = 16;
            tblPassword.FontWeight = System.Windows.FontWeights.Bold;
            tblPassword.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            tblPassword.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(tblPassword, 0);
            Grid.SetRow(tblPassword, 2);
            grdMain.Children.Add(tblPassword);

            TextBox txtPassword = new TextBox();
            txtPassword.Width = 300;
            txtPassword.Height = 20;
            Grid.SetColumn(txtPassword, 1);
            Grid.SetRow(txtPassword, 2);
            grdMain.Children.Add(txtPassword);

            TextBox txtNom = new TextBox();
            txtNom.Width = 300;
            txtNom.Height = 20;
            Grid.SetColumn(txtNom, 1);
            Grid.SetRow(txtNom, 3);
            grdMain.Children.Add(txtNom);

            TextBlock tblNom = new TextBlock();
            tblNom.Text = "Nom d'utilisateur :";
            tblNom.FontSize = 16;
            tblNom.FontWeight = System.Windows.FontWeights.Bold;
            tblNom.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
            tblNom.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(tblNom, 0);
            Grid.SetRow(tblNom, 3);
            grdMain.Children.Add(tblNom);

            Button btnSubmit = new Button();
            btnSubmit.Content = "Créer un compte";
            btnSubmit.Foreground = new SolidColorBrush(Colors.White);
            btnSubmit.Background = new SolidColorBrush(Colors.Red);
            btnSubmit.Height = 30;
            btnSubmit.Width = 150;
            btnSubmit.FontSize = 16;
            btnSubmit.FontWeight = System.Windows.FontWeights.Bold;
            btnSubmit.BorderThickness = new System.Windows.Thickness(3);
            btnSubmit.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            btnSubmit.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            Grid.SetColumn(btnSubmit, 1);
            Grid.SetRow(btnSubmit, 4);
            grdMain.Children.Add(btnSubmit);
            btnSubmit.Click += (s, e) =>
            {
                string mail = txtMail.Text;
                string password = txtPassword.Text;
                string name = txtNom.Text;
                BddManager bdd = new BddManager();
                bool success = bdd.CreateUser(mail, password, name, out DataSet userData);
                if (success)
                {
                    Utilisateur utilisateur = new Utilisateur(userData.Tables[0].Rows[0]["UserName"].ToString(), userData.Tables[0].Rows[0]["UserMail"].ToString(), userData.Tables[0].Rows[0]["UserPassword"].ToString(), int.Parse(userData.Tables[0].Rows[0]["UserId"].ToString()));

                    OuvrirFenetreJeu(grdMain);
                }
                else
                {
                    MessageBox.Show("Adresse mail ou mot de passe incorrect.");
                }
            };
        }


        public void OuvrirFenetreJeu(Grid grdMain)
        {
            NettoyerGrid(grdMain, 10, 10);
            //ajouter les éléments de la fenêtre de jeu ici
        }
        public void plateau(MainWindow plateau)
        {
            MainWindow pagePrincipale = (MainWindow)App.Current.MainWindow;

            //primère ligne 
            TextBlock texte1 = new TextBlock();
            texte1.TextAlignment = TextAlignment.Center;
            texte1.Text = "timer (reste à le créer plus tard)";
            texte1.FontSize = 15;
            texte1.FontFamily = new FontFamily("arial");
            texte1.FontWeight = FontWeights.UltraBold;
            texte1.Foreground = Brushes.Black;
            Grid.SetColumn(texte1, 0);
            Grid.SetRow(texte1, 0);
            Grid.SetColumnSpan(texte1, 1);
            Grid.SetColumnSpan(texte1, 5);
            pagePrincipale.grdMain.Children.Add(texte1);

            //deuxième ligne 
            TextBlock texte2 = new TextBlock();
            texte2.Text = "Allié N°1";
            Grid.SetColumn(texte2, 0);
            Grid.SetRow(texte2, 1);
            pagePrincipale.grdMain.Children.Add(texte2);


            TextBlock texte3 = new TextBlock();
            Grid.SetColumn(texte3, 4);
            Grid.SetRow(texte3, 1);
            texte3.Text = "Ennemi N°1";
            texte3.TextAlignment = TextAlignment.Right;
            pagePrincipale.grdMain.Children.Add(texte3);

            //troisième ligne 
            TextBlock texte4 = new TextBlock();
            texte4.Text = "Allié N°2";
            Grid.SetColumn(texte4, 0);
            Grid.SetRow(texte4, 2);
            pagePrincipale.grdMain.Children.Add(texte4);


            TextBlock texte5 = new TextBlock();
            Grid.SetColumn(texte5, 4);
            Grid.SetRow(texte5, 2);
            texte5.Text = "Ennemi N°2";
            texte5.TextAlignment = TextAlignment.Right;
            pagePrincipale.grdMain.Children.Add(texte5);


            TextBlock texte6 = new TextBlock();
            texte6.Text = "Allié N°3";
            Grid.SetColumn(texte6, 1);
            Grid.SetRow(texte6, 2);
            pagePrincipale.grdMain.Children.Add(texte6);


            TextBlock texte7 = new TextBlock();
            Grid.SetColumn(texte7, 3);
            Grid.SetRow(texte7, 2);
            texte7.Text = "Ennemi N°3";
            texte7.TextAlignment = TextAlignment.Right;
            pagePrincipale.grdMain.Children.Add(texte7);

            //quatrième ligne 
            TextBlock texte8 = new TextBlock();
            texte8.Text = "Allié N°4";
            Grid.SetColumn(texte8, 0);
            Grid.SetRow(texte8, 3);
            pagePrincipale.grdMain.Children.Add(texte8);


            TextBlock texte9 = new TextBlock();
            Grid.SetColumn(texte9, 1);
            Grid.SetRow(texte9, 3);
            texte9.Text = "Allié N°5";
            pagePrincipale.grdMain.Children.Add(texte9);


            TextBlock texte10 = new TextBlock();
            texte10.Text = "Ennemi N°4";
            Grid.SetColumn(texte10, 4);
            Grid.SetRow(texte10, 3);
            texte10.TextAlignment = TextAlignment.Right;
            pagePrincipale.grdMain.Children.Add(texte10);


            TextBlock texte11 = new TextBlock();
            Grid.SetColumn(texte11, 3);
            Grid.SetRow(texte11, 3);
            texte11.Text = "Ennemi N°5";
            texte11.TextAlignment = TextAlignment.Right;
            pagePrincipale.grdMain.Children.Add(texte11);

            //cinquième ligne 
            TextBlock texte12 = new TextBlock();
            texte12.Text = "Buffs et DeBuffs";
            Grid.SetColumn(texte12, 0);
            Grid.SetRow(texte12, 4);
            pagePrincipale.grdMain.Children.Add(texte12);


            TextBlock texte13 = new TextBlock();
            texte13.Text = "Attaque";
            Grid.SetColumn(texte13, 4);
            Grid.SetRow(texte13, 4);
            texte13.FontFamily = new FontFamily("arial");
            texte13.FontWeight = FontWeights.UltraBold;
            texte13.Foreground = Brushes.Black;
            texte13.TextAlignment = TextAlignment.Right;
            pagePrincipale.grdMain.Children.Add(texte13);
        }
    }
}
