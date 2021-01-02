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
    public partial class CustomerRecords : Form
    {
        private User User;
        public static BindingList<Customer> ListOfCustomers = new BindingList<Customer>();
        public static Dictionary<int, Address> AddressDictionary = new Dictionary<int, Address>();
        public static Dictionary<int, City> CityDictionary = new Dictionary<int, City>();
        public static Dictionary<int, Country> CountryDictionary = new Dictionary<int, Country>();

        public CustomerRecords(User user)
        {
            InitializeComponent();
            User = user;
            customerDataGridView.DataSource = ListOfCustomers;
        }

        private void CustomerRecords_Load(object sender, EventArgs e)
        {
            mainLabel.Text = $"Customer Records for {User.UserName}:";
            Database.getCustomers();
            Database.getAddresses();
            Database.getCities();
            Database.getCountries();
            // Using Lambda in Linq statement below to construct a new dictionary that holds "string" as a value rather than the City object
            Dictionary<int, string> cityNameDictionary = CityDictionary.ToDictionary(dict => dict.Key, dict => dict.Value.CityName);
            cityComboBox.DataSource = new BindingSource(cityNameDictionary, null);
            cityComboBox.DisplayMember = "Value";
            cityComboBox.ValueMember = "Key";
            cityComboBox.SelectedItem = null;
        }

        private void CustomerRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void customerDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            formatDataGridView();
        }

        private void formatDataGridView()
        {
            var dataGridView = customerDataGridView;
            dataGridView.AutoResizeColumns();
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ClearSelection();
        }

        private void customerDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedRow = customerDataGridView.SelectedRows[0];
            int selectedCustomerId = Convert.ToInt32(selectedRow.Cells[0].Value);
            Customer selectedCustomer = ListOfCustomers.Where(customer => customer.CustomerId == selectedCustomerId).Single();
            int selectedAddressId = Convert.ToInt32(selectedCustomer.AddressId);
            int selectedCityId = AddressDictionary[selectedAddressId].CityId;
            int selectedCountryId = CityDictionary[selectedCityId].CountryId;
            nameTextBox.Text = selectedCustomer.CustomerName;
            idTextBox.Text = selectedCustomer.CustomerId.ToString();
            addressTextBox.Text = AddressDictionary[selectedAddressId].AddressLine;
            address2TextBox.Text = AddressDictionary[selectedAddressId].AddressLine2;
            zipTextBox.Text = AddressDictionary[selectedAddressId].PostalCode;
            phoneTextBox.Text = AddressDictionary[selectedAddressId].Phone;
            cityComboBox.Text = CityDictionary[selectedCityId].CityName;
            countryTextBox.Text = CountryDictionary[selectedCountryId].CountryName;
        }
    }
}
