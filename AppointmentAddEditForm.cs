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
        private int SelectedAppointmentID = -1;

        public AppointmentAddEditForm(Form prevForm, int appointmentId)
        {
            InitializeComponent();
            PreviousForm = prevForm;
            SelectedAppointmentID = appointmentId;
        }

        public AppointmentAddEditForm(Form prevForm)
        {
            InitializeComponent();
            PreviousForm = prevForm;
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

            if(SelectedAppointmentID >= 0)
            {
                Appointment appointment = MainScreen.ListOfAppointments.Where(appt => appt.AppointmentId == SelectedAppointmentID).Single();
                idTextBox.Text = appointment.AppointmentId.ToString();
                customerComboBox.Text = customerDictionary[appointment.CustomerId];
                typeComboBox.Text = appointment.Type;
                startDateTimePicker.Value = appointment.Start;
                endDateTimePicker.Value = appointment.End;
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
