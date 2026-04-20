using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ZstdSharp.Unsafe;

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
            string connexionString = "";

            try
            {
                connexionString = "server=10.10.51.98;database=solune;port=3306;UserId=solune;password=root";
                MySqlConnection testConnexion = new MySqlConnection(connexionString);
                testConnexion.Open();
                testConnexion.Close();
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

            if (connexionString == "")
            {
                Application.Current.Shutdown();
                throw new Exception("Aucune base de donnée accessible. Veuillez vérifier votre connexion internet ou contacter l'administrateur du programme.");
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

        public bool UserExist(string mail)
        {
            MySqlConnection connexion = new MySqlConnection(ConnexionBdd());
            string query = $"SELECT * FROM user WHERE UserMail = '{mail}'";
            DataSet userData = new DataSet();
            try
            {
                connexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, connexion);
                da.Fill(userData, "user");
                connexion.Close();
                return userData.Tables[0].Rows.Count > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
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

        public bool CreateUser(string mail, string password, string username, ListeGenerale GList, out Utilisateur user)
        {
            bool successfullAction;
            user = null;

            //Ajout d'un nouvel utilisateur dans la base de donnée
            MySqlConnection connexion = new MySqlConnection(ConnexionBdd());
            string query = $"INSERT INTO user (UserMail, UserPassword, UserName) VALUES ('{mail}', '{password}', '{username}')";
            try
            {
                connexion.Open();
                MySqlCommand cmd = new MySqlCommand(query, connexion);
                cmd.ExecuteNonQuery();
                connexion.Close();
                successfullAction = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;

            }

            //récupération de l'utilisateur nouvellement créé
            if (successfullAction)
            {
                ConnectUser(mail, password, GList, out user);

                successfullAction = assignUser(mail, password, connexion, GList, out user);

                //Création des liens entre l'utilisateur et les items de départ
                if (successfullAction)
                {
                    successfullAction = false;
                    query = $"INSERT INTO useritem (UserItemMoney, UserItemCrystal, UserItemUpgradeAbility, UserId, UserItemPersonnagesId) VALUES (0, 0, 0, {user.Id}, 11)"; 

                    try
                    {
                        connexion.Open();
                        MySqlCommand cmd = new MySqlCommand(query, connexion);
                        cmd.ExecuteNonQuery();
                        successfullAction = true;
                        connexion.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;

                    }
                }

            }
            return successfullAction;
        }

        public bool ConnectUser(string mail, string password, ListeGenerale listeG, out Utilisateur user)
        {
            user = null;

            MySqlConnection connexion = new MySqlConnection(ConnexionBdd());
            string query = $"SELECT * FROM user WHERE UserMail = '{mail}' AND UserPassword = '{password}'";
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

            if (userData.Tables[0].Rows.Count > 0)
            {
                assignUser(mail, password, connexion, listeG, out user);
                return true;
            }
            else
            {
                MessageBox.Show("Identifiants incorrects. Veuillez réessayer.");
                return false;
            }
        }

        public bool assignUser(string mail, string password, MySqlConnection connexion, ListeGenerale GList, out Utilisateur user)
        {
            bool successfullAction = false;

            string query = $"SELECT * FROM user WHERE UserMail = '{mail}' AND UserPassword = '{password}'";

            user = null;
            try
            {
                connexion.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(query, connexion);
                DataSet userData = new DataSet();
                da.Fill(userData, "user");
                connexion.Close();
                if (userData.Tables[0].Rows.Count > 0)
                {
                    user = new Utilisateur(userData.Tables[0].Rows[0]["UserName"].ToString(), userData.Tables[0].Rows[0]["UserMail"].ToString(), userData.Tables[0].Rows[0]["UserPassword"].ToString(), int.Parse(userData.Tables[0].Rows[0]["UserId"].ToString()), GList);
                    successfullAction = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

            return successfullAction;

        }
    }
}
