using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TotalCommander.Database
{

    public class DBConnection
    {


        public MySqlConnection Connection { get; private set; }

        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                return instance ?? (instance = new DBConnection());
            }
        }

        private DBConnection()
        {
            MySqlConnectionStringBuilder conStrBuilder = new MySqlConnectionStringBuilder
            {
                Server = "localhost",

                UserID = "root",

                Password = "",

                Database = "tc_changes"
            };

            Connection = new MySqlConnection(conStrBuilder.ToString());
        }

    }

}
