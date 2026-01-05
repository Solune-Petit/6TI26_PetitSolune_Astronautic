using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProgrammeMartyr
{
    internal class Fonctions
    {
        public void CreerPersonnage(out string[,] laListe)
        {
            string[] typePersos = { "Attaquant", "Support", "Healer", "Tank" };

            laListe = new string[10, 6]
            {
                {"Mastu", typePersos[0], "1", "50", "100", "Mastu.jpg"},
                {"Charles Leclerc", typePersos[1], "2", "250", "40", "Charles_Leclerc.jpg"},
                {"Amixem", typePersos[2], "3", "500", "30", "Amixem.jpg"},
                {"Teddy Rinner", typePersos[3], "4",  "1000", "20", "Teddy_riner.jpg"},
                {"Supper Konar", typePersos[0], "5", "2500", "10", "Super_konar.jpg"},
                {"Michou", typePersos[0], "1", "100", "50", "Michou.jpg"},
                {"Obelgix", typePersos[3], "2", "250", "40", "Obelgix.jpg"},
                {"Pikachu", typePersos[2], "3", "500", "30", "Pikachu.jpg"},
                {"Frères Lebruns", typePersos[1], "4", "1000", "20", "Freres_lebruns.jpg"},
                {"MrBeast", typePersos[2], "5", "2500", "10", "Mrbeast.jpg"}
            };
        }

        //appeler la fenêtre qui affiches les détails des personnages
        public void OuvrirFenetreDetails(Grid grdMain, Personnage[] persos)
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
        public void ouvrirfenetrePlateau(Grid grdMain)
        {
            ColumnDefinition[] coldef = new ColumnDefinition[5];
            for (int i = 0; i < 5; i++)
            {
                coldef[i] = new ColumnDefinition();
                grdMain.ColumnDefinitions.Add(coldef[i]);
            }
            RowDefinition[] rowdef = new RowDefinition[5];
            for (int i = 0; i < 5; i++)
            {
                rowdef[i] = new RowDefinition();
                grdMain.RowDefinitions.Add(rowdef[i]);
            }
        }
    }
}
