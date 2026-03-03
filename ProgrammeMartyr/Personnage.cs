using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ProgrammeMartyr
{
    internal class Personnage
    {
        // Attributs
        private string _nom, _role, _img;
        private int _rarete, _niveauMax, _PvMax, _PvGame;
        double _niveauActuel;


        // Propriétés
        public string Nom
        {
            get { return _nom; }
        }
        public string Role
        {
            get { return _role; }
        }
        public string Img
        {
            get { return _img; }
        }
        public int Rarete
        {
            get { return _rarete; }
        }
        public int NiveauMax
        {
            get { return _niveauMax; }
        }
        public int PvMax
        {
            get { return _PvMax; }
        }
        public int PvGame
        {
            get { return _PvGame; }
            set { _PvGame = value; }
        }
        public double NiveauActuel
        {
            get { return _niveauActuel; }
            set { _niveauActuel = value; }
        }

        // Constructeur
        public Personnage(string nom, string role, int rarete, int niveauMax, int PvMax, string img)
        {
            _nom = nom;
            _role = role;
            _rarete = rarete;
            _niveauMax = niveauMax;
            _PvMax = PvMax;
            _PvGame = PvMax;
            _niveauActuel = 0;
            _img = $"images/personnages/{img}";
        }

        // Méthodes



        //<summary>
        //Logique pour afficher les infos du personnage sous forme de carte
        ///Retourne un StackPanel contenant l'image, le nom, le niveau/niveau max, etc.
        //</summary>
        public StackPanel GenInfoCardDesign()
        {
            //création du panel de la carte avec 2 colonnes
            StackPanel cardPanel = new StackPanel();
            cardPanel.Width = 150;
            cardPanel.Height = 600;


            //ajout de l'image
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(_img, UriKind.RelativeOrAbsolute);
            img.EndInit();
            Image ppPerso = new Image();
            ppPerso.Source = img;
            ppPerso.Height = 100;
            cardPanel.Children.Add(ppPerso);

            //ajouter le nom
            TextBlock txtNom = new TextBlock();
            txtNom.Text = _nom;
            txtNom.FontSize = 16;
            txtNom.TextAlignment = System.Windows.TextAlignment.Center;
            cardPanel.Children.Add(txtNom);


            //ajotuer le role
            TextBlock txtRole = new TextBlock();
            txtRole.Text = $"Genre : {_role}";
            txtRole.FontSize = 16;
            txtRole.TextAlignment = System.Windows.TextAlignment.Center;
            cardPanel.Children.Add(txtRole);

            //ajouter le niveau/niveau max
            TextBlock txtNiveau = new TextBlock();
            txtNiveau.Text = $"Niveau : {_niveauActuel}/{_niveauMax}";
            txtNiveau.FontSize = 16;
            txtNiveau.TextAlignment = System.Windows.TextAlignment.Center;
            cardPanel.Children.Add(txtNiveau);

            //ajouter la rarete
            TextBlock txtRarity = new TextBlock();
            txtRarity.Text = $"Rareté : ";
            for (int i = 0; i < _rarete; i++)
            {
                txtRarity.Text += "★";
            }
            for (int i = _rarete; i < 5; i++)
            {
                txtRarity.Text += "☆";
            }
            txtRarity.FontSize = 16;
            txtRarity.TextAlignment = System.Windows.TextAlignment.Center;
            cardPanel.Children.Add(txtRarity);

            //ajouter les PV/PV max
            TextBlock txtPv = new TextBlock();
            txtPv.Text = $"PV : {_PvGame}/{_PvMax}";
            txtPv.FontSize = 16;
            txtPv.TextAlignment = System.Windows.TextAlignment.Center;
            cardPanel.Children.Add(txtPv);

            return cardPanel;
        }


        //<summary>
        ///Logique pour afficher les infos du personnage dans le combat
        ///Retourne un StackPanel contenant l'image, la vie/vie max
        //</summary>
        public StackPanel CombatCardDesign()
        {
            //création du panel de la carte avec 2 colonnes
            StackPanel cardPanel = new StackPanel();
            cardPanel.Width = 150;
            cardPanel.Height = 200;

            //ajout de l'image
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(_img, UriKind.RelativeOrAbsolute);
            img.EndInit();
            Image ppPerso = new Image();
            ppPerso.Source = img;
            ppPerso.Height = 100;
            cardPanel.Children.Add(ppPerso);

            //ajouter les PV/PV max
            TextBlock txtPv = new TextBlock();
            txtPv.Text = $"PV : {_PvGame}/{_PvMax}";
            txtPv.FontSize = 16;
            txtPv.TextAlignment = System.Windows.TextAlignment.Center;
            cardPanel.Children.Add(txtPv);

            return cardPanel;
        }
    }
}
