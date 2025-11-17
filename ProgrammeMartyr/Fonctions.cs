using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        
    }
}
