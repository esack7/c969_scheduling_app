using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

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

        public static int addCustomer(string customerName, int addressID, string user)
        {
            DateTime now = DateTime.Now;
            var addedCustomer = new Customer(customerName, addressID, 1, now, user, now, user);

            dbConnect.Open();
            string query = $"INSERT INTO `customer` VALUES ({addedCustomer.CustomerId}, '{addedCustomer.CustomerName}', {addedCustomer.AddressId}, {addedCustomer.Active}, '{addedCustomer.CreateDate.ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{addedCustomer.CreatedBy}', '{addedCustomer.LastUpdate.ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{addedCustomer.LastUpdateBy}')";
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            cmd.ExecuteNonQuery();
            dbConnect.Close();

            CustomerRecords.ListOfCustomers.Add(addedCustomer);
            return addedCustomer.CustomerId;
        }

        public static void deleteCustomer(Customer customer)
        {
            dbConnect.Open();
            string query = $"DELETE FROM customer WHERE customerId={customer.CustomerId};";
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            cmd.ExecuteNonQuery();
            dbConnect.Close();
            CustomerRecords.ListOfCustomers.Remove(customer);
            deleteAddress(customer.AddressId);
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

        public static int addAddress(string address1, string address2, int cityId, string postalCode, string phone, string userName)
        {
            DateTime now = DateTime.Now;
            var addedAddress = new Address(address1, address2, cityId, postalCode, phone, now, userName, now, userName);

            dbConnect.Open();
            string query = $"INSERT INTO `address` VALUES ({addedAddress.AddressId}, '{addedAddress.AddressLine}', '{addedAddress.AddressLine2}', {addedAddress.CityId}, '{addedAddress.PostalCode}', '{addedAddress.Phone}', '{addedAddress.CreateDate.ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{addedAddress.CreatedBy}', '{addedAddress.LastUpdate.ToString("yy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo)}', '{addedAddress.LastUpdateBy}')";
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            cmd.ExecuteNonQuery();
            dbConnect.Close();

            CustomerRecords.AddressDictionary.Add(addedAddress.AddressId, addedAddress);
            return addedAddress.AddressId;
        }

        public static void deleteAddress(int addressID)
        {
            dbConnect.Open();
            string query = $"DELETE FROM address WHERE addressId={addressID};";
            MySqlCommand cmd = new MySqlCommand(query, dbConnect);
            cmd.ExecuteNonQuery();
            dbConnect.Close();
            CustomerRecords.AddressDictionary.Remove(addressID);
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
