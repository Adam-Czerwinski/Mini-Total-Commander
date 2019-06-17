using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Database;
using MySql.Data.MySqlClient;

namespace TCAdmin
{
    class Model
    {

        public Change[] LoadData()
        {
            MySqlConnection connection = DBConnection.Instance.Connection;

            string GET_DATA = "select id_changes, name, source, destination, time_ from changes, users where user_ = id_users;";

            List<Change> changes = new List<Change>();

            try
            {
                using (MySqlCommand comm = new MySqlCommand(GET_DATA, connection))
                {
                    connection.Open();

                    MySqlDataReader reader = comm.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetValue(0));
                        Console.WriteLine(reader.GetValue(1));
                        Console.WriteLine(reader.GetValue(2));
                        Console.WriteLine(reader.GetValue(3));
                        Console.WriteLine(reader.GetValue(4));
                        changes.Add(new Change(int.Parse(reader.GetValue(0).ToString()), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString()));
                    }


                    reader.Close();
                    connection.Close();

                    return changes.ToArray();
                }
            }
            catch (Exception) { return changes.ToArray(); }
        }
    }
}
