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
    }
}
