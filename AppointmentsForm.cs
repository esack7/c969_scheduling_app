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
    public partial class AppointmentsForm : Form
    {
        private Form Main;
        public AppointmentsForm(Form main)
        {
            InitializeComponent();
            appointmentDataGridView.DataSource = MainScreen.ListOfAppointments;
            mainLabel.Text = $"Appointments for { MainScreen.LoggedInUser.UserName }";
            Main = main;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AppointmentsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main.Show();
        }

        private void formatDataGridView()
        {
            var dataGridView = appointmentDataGridView;
            dataGridView.AutoResizeColumns();
            dataGridView.RowHeadersVisible = false;
            dataGridView.ReadOnly = true;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.MultiSelect = false;
            dataGridView.ClearSelection();
        }

        private void appointmentDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            formatDataGridView();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addForm = new AppointmentAddEditForm(this);
            addForm.Show();
            appointmentDataGridView.ClearSelection();
            Hide();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (appointmentDataGridView.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("You must select an appointment to edit.");
                }
                var selectedRow = appointmentDataGridView.SelectedRows[0];
                int selectedAppointmentId = Convert.ToInt32(selectedRow.Cells[0].Value);
                var editForm = new AppointmentAddEditForm(this, selectedAppointmentId);
                editForm.Show();
                appointmentDataGridView.ClearSelection();
                Hide();
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (appointmentDataGridView.SelectedRows.Count < 1)
                {
                    throw new ApplicationException("You must select an appointment to delete.");
                }
                DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete the selected appointment?", "Application Instruction", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    var selectedRow = appointmentDataGridView.SelectedRows[0];
                    int selectedAppointmentId = Convert.ToInt32(selectedRow.Cells[0].Value);
                    Appointment selectedAppointment = MainScreen.ListOfAppointments.Where(appt => appt.AppointmentId == selectedAppointmentId).Single();
                    Database.deleteAppointment(selectedAppointment);
                }
                else
                {
                    appointmentDataGridView.ClearSelection();
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
