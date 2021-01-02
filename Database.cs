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
            List<User> listOfUsers = new List<User>();
            string query = "SELECT * FROM user";

            dbConnect.Open();
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int userID = Convert.ToInt32(dataReader[0]);
                string userName = dataReader[1].ToString();
                string password = dataReader[2].ToString();
                int active = Convert.ToInt32(dataReader[3]);
                DateTime createDate = Convert.ToDateTime(dataReader[4]);
                string createdBy = dataReader[5].ToString();
                DateTime lastUpdate = Convert.ToDateTime(dataReader[6]);
                string lastUpdateBy = dataReader[7].ToString();

                listOfUsers.Add(new User(userID, userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy));
            }

            dbConnect.Close();

            return listOfUsers;
        }

        public static void getCustomers()
        {
            string query = "select * from customer";

            dbConnect.Open();
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int customerID = Convert.ToInt32(dataReader[0]);
                string customerName = dataReader[1].ToString();
                int addressID = Convert.ToInt32(dataReader[2]);
                int active = Convert.ToInt32(dataReader[3]);
                DateTime createDate = Convert.ToDateTime(dataReader[4]);
                string createdBy = dataReader[5].ToString();
                DateTime lastUpdate = Convert.ToDateTime(dataReader[6]);
                string lastUpdateBy = dataReader[7].ToString();

                CustomerRecords.ListOfCustomers.Add(new Customer(customerID, customerName, addressID, active, createDate, createdBy, lastUpdate, lastUpdateBy));
            }

            dbConnect.Close();
        }

        public static void getAddresses()
        {
            string query = "select * from address";

            dbConnect.Open();
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int addressID = Convert.ToInt32(dataReader[0]);
                string address1 = dataReader[1].ToString();
                string address2 = dataReader[2].ToString();
                int cityID = Convert.ToInt32(dataReader[3]);
                string postalCode = dataReader[4].ToString();
                string phone = dataReader[5].ToString();
                DateTime createDate = Convert.ToDateTime(dataReader[6]);
                string createdBy = dataReader[7].ToString();
                DateTime lastUpdate = Convert.ToDateTime(dataReader[8]);
                string lastUpdateBy = dataReader[9].ToString();

                CustomerRecords.AddressDictionary.Add(addressID, new Address(addressID, address1, address2, cityID, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy));
            }
            dbConnect.Close();
        }

        public static void getCities()
        {
            string query = "select * from city";

            dbConnect.Open();
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int cityID = Convert.ToInt32(dataReader[0]);
                string city = dataReader[1].ToString();
                int countryID = Convert.ToInt32(dataReader[2]);
                DateTime createDate = Convert.ToDateTime(dataReader[3]);
                string createdBy = dataReader[4].ToString();
                DateTime lastUpdate = Convert.ToDateTime(dataReader[5]);
                string lastUpdateBy = dataReader[6].ToString();

                CustomerRecords.CityDictionary.Add(cityID, new City(cityID, city, countryID, createDate, createdBy, lastUpdate, lastUpdateBy));
            }
            dbConnect.Close();
        }

        public static void getCountries()
        {
            string query = "select * from country";

            dbConnect.Open();
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int countryID = Convert.ToInt32(dataReader[0]);
                string country = dataReader[1].ToString();
                DateTime createDate = Convert.ToDateTime(dataReader[2]);
                string createdBy = dataReader[3].ToString();
                DateTime lastUpdate = Convert.ToDateTime(dataReader[4]);
                string lastUpdateBy = dataReader[5].ToString();

                CustomerRecords.CountryDictionary.Add(countryID, new Country(countryID, country, createDate, createdBy, lastUpdate, lastUpdateBy));
            }
            dbConnect.Close();
        }
    }
}
