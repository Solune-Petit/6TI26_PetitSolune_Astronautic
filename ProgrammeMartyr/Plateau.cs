using ProgrammeMartyr;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ProgrammeMartyr
{
    internal class Plateau
    {

        private string _bkGround;

        public string bkGround
        {
            get { return _bkGround; }
        }
        private string _personnageJoue;

        public string personnagejoue
        {
            get { return _personnageJoue; }
            set { _personnageJoue = value; }
        }

        private string _animation;

        public string animation
        {
            get { return _animation; }
            set { _animation = value; }
        }

        private double _nombrePersonnagesDessus;

        public double nombrePersonnagesDessus
        {
            get { return _nombrePersonnagesDessus; }
            set { _nombrePersonnagesDessus = value; }
        }


        public Plateau(string bkGround, string personnageJoue, string animation, double nombrePersonnagesdessus)
        {
            _bkGround = bkGround;
            _personnageJoue = personnageJoue;
            _animation = animation;
            _nombrePersonnagesDessus = nombrePersonnagesdessus;
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
            pagePrincipale.plateau.Children.Add(texte1);

            //deuxième ligne 
            TextBlock texte2 = new TextBlock();
            texte2.Text = "Allié N°1";
            Grid.SetColumn(texte2, 0);
            Grid.SetRow(texte2, 1);
            pagePrincipale.plateau.Children.Add(texte2);


            TextBlock texte3 = new TextBlock();
            Grid.SetColumn(texte3, 4);
            Grid.SetRow(texte3, 1);
            texte3.Text = "Ennemi N°1";
            texte3.TextAlignment = TextAlignment.Right;
            pagePrincipale.plateau.Children.Add(texte3);

            //troisième ligne 
            TextBlock texte4 = new TextBlock();
            texte4.Text = "Allié N°2";
            Grid.SetColumn(texte4, 0);
            Grid.SetRow(texte4, 2);
            pagePrincipale.plateau.Children.Add(texte4);


            TextBlock texte5 = new TextBlock();
            Grid.SetColumn(texte5, 4);
            Grid.SetRow(texte5, 2);
            texte5.Text = "Ennemi N°2";
            texte5.TextAlignment = TextAlignment.Right;
            pagePrincipale.plateau.Children.Add(texte5);


            TextBlock texte6 = new TextBlock();
            texte6.Text = "Allié N°3";
            Grid.SetColumn(texte6, 1);
            Grid.SetRow(texte6, 2);
            pagePrincipale.plateau.Children.Add(texte6);


            TextBlock texte7 = new TextBlock();
            Grid.SetColumn(texte7, 3);
            Grid.SetRow(texte7, 2);
            texte7.Text = "Ennemi N°3";
            texte7.TextAlignment = TextAlignment.Right;
            pagePrincipale.plateau.Children.Add(texte7);

            //quatrième ligne 
            TextBlock texte8 = new TextBlock();
            texte8.Text = "Allié N°4";
            Grid.SetColumn(texte8, 0);
            Grid.SetRow(texte8, 3);
            pagePrincipale.plateau.Children.Add(texte8);


            TextBlock texte9 = new TextBlock();
            Grid.SetColumn(texte9, 1);
            Grid.SetRow(texte9, 3);
            texte9.Text = "Allié N°5";
            pagePrincipale.plateau.Children.Add(texte9);


            TextBlock texte10 = new TextBlock();
            texte10.Text = "Ennemi N°4";
            Grid.SetColumn(texte10, 4);
            Grid.SetRow(texte10, 3);
            texte10.TextAlignment = TextAlignment.Right;
            pagePrincipale.plateau.Children.Add(texte10);


            TextBlock texte11 = new TextBlock();
            Grid.SetColumn(texte11, 3);
            Grid.SetRow(texte11, 3);
            texte11.Text = "Ennemi N°5";
            texte11.TextAlignment = TextAlignment.Right;
            pagePrincipale.plateau.Children.Add(texte11);

            //cinquième ligne 
            TextBlock texte12 = new TextBlock();
            texte12.Text = "Buffs et DeBuffs";
            Grid.SetColumn(texte12, 0);
            Grid.SetRow(texte12, 4);
            pagePrincipale.plateau.Children.Add(texte12);


            TextBlock texte13 = new TextBlock();
            texte13.Text = "Attaque";
            Grid.SetColumn(texte13, 4);
            Grid.SetRow(texte13, 4);
            texte13.FontFamily = new FontFamily("arial");
            texte13.FontWeight = FontWeights.UltraBold;
            texte13.Foreground = Brushes.Black;
            texte13.TextAlignment = TextAlignment.Right;
            pagePrincipale.plateau.Children.Add(texte13);
        }
    }
}

