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

        private void clearInputs()
        {
            nameTextBox.Text = "";
            idTextBox.Text = "";
            addressTextBox.Text = "";
            address2TextBox.Text = "";
            zipTextBox.Text = "";
            phoneTextBox.Text = "";
            cityComboBox.Text = "";
            countryTextBox.Text = "";
        }

        private void toggleActiveInputs(bool active)
        {
            nameTextBox.Enabled = active;
            addressTextBox.Enabled = active;
            address2TextBox.Enabled = active;
            cityComboBox.Enabled = active;
            zipTextBox.Enabled = active;
            phoneTextBox.Enabled = active;
            saveButton.Visible = active;
            cancelButton.Visible = active;
            addButton.Visible = !active;
            editButton.Visible = !active;
            deleteButton.Visible = !active;
            backButton.Visible = !active;
            customerDataGridView.Enabled = !active;
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

        private void addButton_Click(object sender, EventArgs e)
        {
            customerDataGridView.ClearSelection();
            clearInputs();
            toggleActiveInputs(true);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (cityComboBox.SelectedItem == null)
                {
                    throw new ApplicationException("You must select a city.");
                }
                string customerName = nameTextBox.Text;
                string address1 = addressTextBox.Text;
                string address2 = address2TextBox.Text;
                string postalCode = zipTextBox.Text;
                string phone = phoneTextBox.Text;
                int cityID = Convert.ToInt32(cityComboBox.SelectedValue);

                int addressID = Database.addAddress(address1, address2, cityID, postalCode, phone, User.UserName);
                int customerID = Database.addCustomer(customerName, addressID, User.UserName);

                clearInputs();
                toggleActiveInputs(false);
                //var addedRow = customerDataGridView.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToInt32(row.Cells[0].Value) == customerID).Single();
                //addedRow.Selected = true;           
            }
            catch (ApplicationException error)
            {
                MessageBox.Show(error.Message, "Instructions", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            clearInputs();
            toggleActiveInputs(false);
        }

        private void cityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedCityKey = cityComboBox.SelectedValue;
            int selectedCountryKey = CityDictionary[Convert.ToInt32(selectedCityKey)].CountryId;
            countryTextBox.Text = CountryDictionary[selectedCountryKey].CountryName;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(customerDataGridView.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("You must select a customer to delete.");
                }
                DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete the selected customer?", "Application Instruction", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    var selectedRow = customerDataGridView.SelectedRows[0];
                    int selectedCustomerId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    Customer selectedCustomer = ListOfCustomers.Where(customer => customer.CustomerId == selectedCustomerId).Single();
                    Database.deleteCustomer(selectedCustomer);
                    clearInputs();
                } 
                else
                {
                    customerDataGridView.ClearSelection();
                    clearInputs();
                }
            }
            catch (ApplicationException error)
            {
                MessageBox.Show(error.Message, "Instructions", MessageBoxButtons.OK);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }
}
