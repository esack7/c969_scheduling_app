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
    public partial class AppointmentAddEditForm : Form
    {
        private Form PreviousForm;
        private string ControlType;

        public AppointmentAddEditForm(Form prevForm, string control)
        {
            InitializeComponent();
            PreviousForm = prevForm;
            ControlType = control;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {            
            Close();
        }

        private void AppointmentAddEditForm_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> customerDictionary = MainScreen.ListOfCustomers.ToDictionary(list => list.CustomerId, list => list.CustomerName);
            customerComboBox.DataSource = new BindingSource(customerDictionary, null);
            customerComboBox.DisplayMember = "Value";
            customerComboBox.ValueMember = "Key";
            customerComboBox.SelectedItem = null;

            typeComboBox.DataSource = new[] { "Scrum", "Presentation", "Lunch", "Interview", "Consultation" };
            typeComboBox.SelectedItem = null;

            if (ControlType == "Edit")
            {
                idTextBox.Text = "-1";
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int selectedCustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
            string selectedType = typeComboBox.SelectedValue.ToString();
            DateTime selectedStart = startDateTimePicker.Value;
            DateTime selectedEnd = endDateTimePicker.Value;
            //int ID;
            Database.addAppointment(selectedCustomerId, selectedType, selectedStart, selectedEnd);
            Close();
        }

        private void AppointmentAddEditForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreviousForm.Show();
        }
    }
}
