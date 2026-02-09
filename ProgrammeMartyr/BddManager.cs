using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using ZstdSharp.Unsafe;
using Mysqlx.Connection;
using System.Windows;

namespace ProgrammeMartyr
{
    internal class BddManager
    {
        ///<summary>
        ///Déterminer la base de donnée accessible par le programme 
        ///</summary>
        ///<parametres>
        ///connexion : objet de connexion à la base de donnée MySQL
        ///</parametres>
        public string ConnexionBdd()
        {
            bool BddClasse = false;
            bool BddSolune = false;
            string connexionString;

            try
            {
                connexionString = "server=10.10.51.98;database=solune;port=3306;UserId=solune;password=root";
                BddClasse = true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }

            if (BddClasse == false)
            {
                try
                {
                    connexionString = "server=192.168.0.96;database=solune;port=3306;UserId=root;password=root";
                    BddSolune = true;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }

            if (BddClasse == false && BddSolune == false)
            {
                try
                {
                    connexionString = "server=localhost;database=astronautic;port=3306;UserId=root;password=root";
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    throw;
                }
            }
            return connexionString;
        }

        public DataSet DownloadCharacters()
        {
            MySqlConnection connexion = new MySqlConnection(ConnexionBdd());
            string query = "SELECT * FROM personnage";
            DataSet Persos = new DataSet();

            try
            {
                connexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, connexion);
                da.Fill(Persos, "personnage");
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return Persos;
        }
    }

}
