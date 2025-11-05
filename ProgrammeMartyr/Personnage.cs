using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammeMartyr
{
    internal class Personnage
    {
        // Attributs
        private string _nom, _role, _img;
        private uint _rarete, _niveauMax, _PvMax, _PvGame;
        double _niveauActuel;

        // Constructeur
        public Personnage(string nom, string role, uint rarete, uint niveauMax, uint PvMax, string img)
        {
            _nom = nom;
            _role = role;
            _rarete = rarete;
            _niveauMax = niveauMax;
            _PvMax = PvMax;
            _PvGame = PvMax;
            _niveauActuel = 0;
            _img = img;
        }

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
        public uint Rarete 
        {
            get { return _rarete; }
        }
        public uint NiveauMax
        {
            get { return _niveauMax; }
        }
        public uint PvMax 
        {
            get { return _PvMax; }
        }
        public uint PvGame 
        {
            get { return _PvGame; }
            set { _PvGame = value; }
        }
        public double NiveauActuel
        {
            get { return _niveauActuel; }
            set { _niveauActuel = value; }
        }

    }
}
