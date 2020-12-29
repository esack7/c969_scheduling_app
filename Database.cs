using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___Scheduling_App___Isaac_Heist
{
    class Database
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;
        private static MySqlConnection dbConnect = new MySqlConnection(connectionString);

        public static List<User> getAllUsers()
        {

        }
    }
}
