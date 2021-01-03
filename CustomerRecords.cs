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
        private Form Main;

        public CustomerRecords(Form main)
        {
            InitializeComponent();
            customerDataGridView.DataSource = MainScreen.ListOfCustomers;
            Main = main;
        }

        private void CustomerRecords_Load(object sender, EventArgs e)
        {
            mainLabel.Text = $"Customer Records for {MainScreen.LoggedInUser.UserName}:";
            // Using Lambda in Linq statement below to construct a new dictionary that holds "string" as a value rather than the City object
            Dictionary<int, string> cityNameDictionary = MainScreen.CityDictionary.ToDictionary(dict => dict.Key, dict => dict.Value.CityName);
            cityComboBox.DataSource = new BindingSource(cityNameDictionary, null);
            cityComboBox.DisplayMember = "Value";
            cityComboBox.ValueMember = "Key";
            cityComboBox.SelectedItem = null;
        }

        private void CustomerRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.Show();
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
            Customer selectedCustomer = MainScreen.ListOfCustomers.Where(customer => customer.CustomerId == selectedCustomerId).Single();
            int selectedAddressId = Convert.ToInt32(selectedCustomer.AddressId);
            int selectedCityId = MainScreen.AddressDictionary[selectedAddressId].CityId;
            int selectedCountryId = MainScreen.CityDictionary[selectedCityId].CountryId;
            nameTextBox.Text = selectedCustomer.CustomerName;
            idTextBox.Text = selectedCustomer.CustomerId.ToString();
            addressTextBox.Text = MainScreen.AddressDictionary[selectedAddressId].AddressLine;
            address2TextBox.Text = MainScreen.AddressDictionary[selectedAddressId].AddressLine2;
            zipTextBox.Text = MainScreen.AddressDictionary[selectedAddressId].PostalCode;
            phoneTextBox.Text = MainScreen.AddressDictionary[selectedAddressId].Phone;
            cityComboBox.Text = MainScreen.CityDictionary[selectedCityId].CityName;
            countryTextBox.Text = MainScreen.CountryDictionary[selectedCountryId].CountryName;
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
                int customerID;

                if (idTextBox.Text == "")
                {
                    int addressID = Database.addAddress(address1, address2, cityID, postalCode, phone, MainScreen.LoggedInUser.UserName);
                    customerID = Database.addCustomer(customerName, addressID, MainScreen.LoggedInUser.UserName);
                    idTextBox.Text = customerID.ToString();
                }
                else
                {
                    customerID = Convert.ToInt32(idTextBox.Text);
                    Customer currentCustomer = MainScreen.ListOfCustomers.Where(c => c.CustomerId == customerID).Single();
                    Address address = MainScreen.AddressDictionary[currentCustomer.AddressId];

                    Database.updateCustomer(currentCustomer, customerName, MainScreen.LoggedInUser.UserName);
                    Database.updateAddress(address, address1, address2, cityID, postalCode, phone, MainScreen.LoggedInUser.UserName);
                }
                                
                toggleActiveInputs(false);
                customerDataGridView.Rows.Cast<DataGridViewRow>().Where(row => Convert.ToInt32(row.Cells[0].Value) == customerID).Single().Selected = true;     
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
            customerDataGridView.ClearSelection();
            clearInputs();
            toggleActiveInputs(false);
        }

        private void cityComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedCityKey = cityComboBox.SelectedValue;
            int selectedCountryKey = MainScreen.CityDictionary[Convert.ToInt32(selectedCityKey)].CountryId;
            countryTextBox.Text = MainScreen.CountryDictionary[selectedCountryKey].CountryName;
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
                    Customer selectedCustomer = MainScreen.ListOfCustomers.Where(customer => customer.CustomerId == selectedCustomerId).Single();
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

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (customerDataGridView.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("You must select a customer to edit.");
                }
                toggleActiveInputs(true);
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

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
