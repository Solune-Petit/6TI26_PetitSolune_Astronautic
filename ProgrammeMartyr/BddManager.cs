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

        /// <summary>
        /// Retrieves all character records from the database.
        /// </summary>
        /// <remarks>The method establishes a new database connection for each call and retrieves all rows
        /// from the "personnage" table. The caller is responsible for handling any exceptions that may be thrown if the
        /// database connection fails or if an error occurs during data retrieval.</remarks>
        /// <returns>A <see cref="DataSet"/> containing the data for all characters. The DataSet will include a table named
        /// "personnage" with the retrieved records. The DataSet will be empty if no records are found.</returns>
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

        public DataSet ConnectUser(string mail, string mdp)
        {
            MySqlConnection connexion = new MySqlConnection(ConnexionBdd());
            string query = $"SELECT * FROM user WHERE UserMail = '{mail}' AND UserPassword = '{mdp}'";
            DataSet userData = new DataSet();
            try
            {
                connexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, connexion);
                da.Fill(userData, "user");
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return userData;
        }

        /// <summary>
        /// Retrieves the inventory data for the specified user from the database.
        /// </summary>
        /// <param name="userID">The unique identifier of the user whose inventory is to be downloaded. Must correspond to a valid user in
        /// the database.</param>
        /// <returns>A DataSet containing the inventory items for the specified user. The DataSet will contain a table named
        /// "inventaire". If the user has no items, the table will be empty.</returns>
        public DataSet DownloadInventaire(int userID)
        {
            MySqlConnection connexion = new MySqlConnection(ConnexionBdd());
            string query = $"select * from useritem where UserId = {userID}";
            DataSet Inventaire = new DataSet();
            try
            {
                connexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, connexion);
                da.Fill(Inventaire, "inventaire");
                connexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            return Inventaire;
        }

        public bool CreateUser(string mail, string password, string username)
        {
            MySqlConnection connexion = new MySqlConnection(ConnexionBdd());
            string query = $"INSERT INTO user (UserMail, UserPassword, UserName) VALUES ('{mail}', '{password}', '{username}')";
            try
            {
                connexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, connexion);
                cmd.ExecuteNonQuery();

                DataSet user = ConnectUser(mail, password);
                DataSet inventaire = null;

                query = $"INSERT INTO useritem (UserItemMoney, UserItemCrystal, UserItemUpgradeAbility, UserId) VALUES (0, 0, 0, {user.Tables[0].Rows[0]["UserID"]})";
                try
                {
                    cmd = new MySqlCommand(query, connexion);
                    cmd.ExecuteNonQuery();


                    try
                    {

                        query = $"SELECT * FROM useritem WHERE UserId = {user.Tables[0].Rows[0]["UserId"]}";
                        MySqlDataAdapter da = new MySqlDataAdapter(query, connexion);
                        da.Fill(inventaire, "inventaire");

                        try
                        {
                            query = $"INSERT INTO appartiens (ItemId, UserId) VALUES ({user.Tables[0].Rows[0]["UserId"]})";
                            cmd = new MySqlCommand(query, connexion);
                            cmd.ExecuteNonQuery();
                            connexion.Close();
                            
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            throw;

                        }

                        connexion.Close();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    throw;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;

            }
        }
    }
}
