using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Scheduling_App___Isaac_Heist
{
    public partial class MainScreen : Form
    {
        public static User LoggedInUser;
        public static BindingList<Customer> ListOfCustomers = new BindingList<Customer>();
        public static BindingList<Appointment> ListOfAppointments = new BindingList<Appointment>();
        public static Dictionary<int, Address> AddressDictionary = new Dictionary<int, Address>();
        public static Dictionary<int, City> CityDictionary = new Dictionary<int, City>();
        public static Dictionary<int, Country> CountryDictionary = new Dictionary<int, Country>();

        public MainScreen(User user)
        {
            InitializeComponent();
            LoggedInUser = user;
        }

        private void customersButton_Click(object sender, EventArgs e)
        {
            var customerRecords = new CustomerRecords(this);
            customerRecords.Show();
            Hide();
        }

        private void MainScreen_Load(object sender, EventArgs e)
        {
            loggedInLabel.Text = $"* User: {LoggedInUser.UserName} is logged in.";
            Database.getCustomers();
            Database.getAddresses();
            Database.getCities();
            Database.getCountries();
            Database.getAppointments();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void appointmentsButton_Click(object sender, EventArgs e)
        {
            var appointmentScreen = new AppointmentsForm(this);
            appointmentScreen.Show();
            Hide();
        }
    }
}
