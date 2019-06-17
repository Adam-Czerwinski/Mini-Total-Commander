using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalCommander.Database
{
    public class Querys
    {

        /// <summary>
        /// Wyszukuje Id obecnego usera w bazie, jeśli user nie znajduje się w bazie to go dodaje.
        /// </summary>
        /// <returns>Id_user</returns>
        private static int GetIdUser()
        {
            MySqlConnection connection = DBConnection.Instance.Connection;

            string GET_USER = "select id_users from users where name = '" + Environment.UserName + "';";

            int id = -1;

            try
            {
                using (MySqlCommand comm = new MySqlCommand(GET_USER, connection))
                {
                    connection.Open();

                    MySqlDataReader reader = comm.ExecuteReader();
                    if (reader.Read())
                        id = int.Parse(reader.GetValue(0).ToString());

                    reader.Close();
                    connection.Close();

                    if(id == -1)
                    {
                        AddUser();
                        id = GetIdUser();
                    }

                    return id;
                }
            }
            catch (Exception) { return id; }
        }

        private static void AddUser()
        {
            MySqlConnection connection = DBConnection.Instance.Connection;

            string ADD_USER = "insert into users values ( null, '" + Environment.UserName + "');";

            try
            {
                using (MySqlCommand comm = new MySqlCommand(ADD_USER, connection))
                {
                    connection.Open();

                    comm.ExecuteReader();
                    
                    connection.Close();
                    
                }
            }
            catch (Exception) {  }
        }

        /// <summary>
        /// Dodaje zmiane do bazy
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        public static void AddChange(string source, string destination)
        {
            MySqlConnection connection = DBConnection.Instance.Connection;
            
            string ADD_CHANGE = "insert into changes values ( null, " + GetIdUser() + ", '" + source.Replace("\\", "\\\\") + " ', '" + destination.Replace("\\", "\\\\") + " ', now());";

            try
            {
                using (MySqlCommand comm = new MySqlCommand(ADD_CHANGE, connection))
                {
                    connection.Open();

                    comm.ExecuteReader();

                    connection.Close();
                }
            }
            catch (Exception) {  }
        }
    }
}
