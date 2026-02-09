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
        //public void StoquerPersonnage(out string[,] laListe)
        //{
            
        //}

        //appeler la fenêtre qui affiches les détails des personnages
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
    }
}
