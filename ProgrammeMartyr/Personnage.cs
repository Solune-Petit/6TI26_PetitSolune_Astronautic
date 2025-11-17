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
        public StackPanel CardDesign()
        {
            // Logique pour concevoir la carte du personnage
            StackPanel cardPanel = new StackPanel();
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(_img, UriKind.RelativeOrAbsolute);
            img.EndInit();
            Image ppPerso = new Image();
            ppPerso.Source = img;
            cardPanel.Children.Add(ppPerso);
            //ajotuer d'autres éléments comme le nom, le rôle, etc.
            return cardPanel;
        }
    }
}
