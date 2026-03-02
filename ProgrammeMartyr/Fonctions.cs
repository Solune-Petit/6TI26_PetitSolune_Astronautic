using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProgrammeMartyr
{
    internal class Fonctions
    {

        /// <summary>
        /// Cette fonction permet d'ouvrir la fenêtre de détails d'un personnage, qui affiche les informations du personnage sous forme de cartes.
        /// </summary>
        /// <param name="grdMain">Le grid principal de la fenêtre</param>
        /// <param name="persos">La liste des personnages à afficher dans la fenêtre de détails</param>
        public void OuvrirFenetreDetails(Grid grdMain, List<Personnage> persos)
        {
            grdMain.Children.Clear();
            grdMain.RowDefinitions.Clear();
            grdMain.ColumnDefinitions.Clear();


            //definition des colonnes
            ColumnDefinition[] colDef = new ColumnDefinition[10];
            for (int i = 0; i < 4; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }

            //definition des lignes
            RowDefinition[] rowDef = new RowDefinition[10];
            for (int i = 0; i < 4; i++)
            {
                rowDef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowDef[i]);
            }

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
        /// Cette fonction permet d'ouvrir la fenêtre de menu qui s'affiche au début du programme et qui permet de choisir entre
        /// la fenêtre de dev, la fenêtre de log-in et la fenêtre de création de compte
        /// </summary>
        /// <param name="grdMain"></param>
        public void OuvrirFenetreMenu(Grid grdMain, ListeGenerale listeG)
        {
            grdMain.Children.Clear();
            grdMain.RowDefinitions.Clear();
            grdMain.ColumnDefinitions.Clear();
            //definition des colonnes
            ColumnDefinition[] colDef = new ColumnDefinition[3];
            for (int i = 0; i < 3; i++)
            {
                colDef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }
            //definition des lignes
            RowDefinition rowDef = new RowDefinition();
            grdMain.RowDefinitions.Add(rowDef);

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
            btnDev.Click += (s, e) => OuvrirFenetreDev(grdMain, listeG);

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
        }

        /// <summary>
        /// Cette fonction permet d'ouvrir la fenêtre de dev qui est une fenêtre de test pour les différentes fonctionnalités du programme comme
        /// les disignes des cartes, les différentes listes, etc.
        /// C'est une fenêtre qui est en cours de développement et qui n'est pas encore terminée. Elle n'est pas destinée à être utilisée par les utilisateurs finaux
        /// </summary>
        /// <param name="grdMain"></param>
        public void OuvrirFenetreDev(Grid grdMain, ListeGenerale listeG)
        {
            grdMain.Children.Clear();
            grdMain.RowDefinitions.Clear();
            grdMain.ColumnDefinitions.Clear();

            //deffinition des colonnes et lighes en 5X5
            ColumnDefinition[] colDef = new ColumnDefinition[5];
            for (int i = 0; i < 5; i++)
            {
                colDef[i] = new ColumnDefinition();
                colDef[i].Width = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
                grdMain.ColumnDefinitions.Add(colDef[i]);
            }
            RowDefinition[] rowDef = new RowDefinition[5];
            for (int i = 0; i < 5; i++)
            {
                rowDef[i] = new RowDefinition();
                rowDef[i].Height = new System.Windows.GridLength(1, System.Windows.GridUnitType.Star);
                grdMain.RowDefinitions.Add(rowDef[i]);
            }

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
        }
    }
}
