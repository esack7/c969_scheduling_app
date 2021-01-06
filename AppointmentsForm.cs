using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___Scheduling_App___Isaac_Heist
{
    public partial class AppointmentsForm : Form
    {
        private Form Main;
        private DateTime SelectedDate;
        private bool monthSelected = true;

        public AppointmentsForm(Form main)
        {
            InitializeComponent();
            mainLabel.Text = $"Appointments for { MainScreen.LoggedInUser.UserName }";
            Main = main;
            SelectedDate = DateTime.Now;
        }

        public void UpdateSelection()
        {
            if(monthSelected)
            {
                updateViewWithMonthlySelected();
            } 
            else
            {
                updateViewWithWeeklySelected();
            }
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

        private void AppointmentsForm_Load(object sender, EventArgs e)
        {
            updateViewWithMonthlySelected();
        }

        private DateTime findBeginningOfWeek(DateTime date)
        {
            var culture = Thread.CurrentThread.CurrentCulture;
            var difference = date.DayOfWeek - culture.DateTimeFormat.FirstDayOfWeek;
            if(difference < 0)
            {
                difference = difference + 7;
            }
            return date.AddDays(-difference).Date;
        }

        private DateTime findEndOfWeek(DateTime date)
        {
            return findBeginningOfWeek(date).AddDays(7).AddMilliseconds(-1);
        }

        private DateTime findBeginningOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        private DateTime findEndOfMonth(DateTime date)
        {
            return findBeginningOfMonth(date).AddMonths(1).AddMilliseconds(-1);
        }

        private BindingList<Appointment> getAppointmentsInTimePeriod(DateTime beginTime, DateTime endTime)
        {
            //used the following lambda in linq statement to recreate list of Appointments that fall within the begin and end time bounds.
            return new BindingList<Appointment>(MainScreen.ListOfAppointments.Where(appt => appt.Start >= beginTime && appt.End <= endTime).ToList());
        }

        private void monthRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(monthRadioButton.Checked == true)
            {
                monthSelected = true;
                updateViewWithMonthlySelected();
            }
        }

        private void weekRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if(weekRadioButton.Checked == true)
            {
                monthSelected = false;
                updateViewWithWeeklySelected();
            }
        }

        private void monthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            SelectedDate = monthCalendar.SelectionStart;

            if(monthRadioButton.Checked == true)
            {
                updateViewWithMonthlySelected();
            }
            else
            {
                updateViewWithWeeklySelected();
            }
        }

        private void updateViewWithMonthlySelected()
        {
            DateTime beginningOfMonth = findBeginningOfMonth(SelectedDate);
            DateTime endOfMonth = findEndOfMonth(SelectedDate);
            appointmentDataGridView.DataSource = getAppointmentsInTimePeriod(beginningOfMonth, endOfMonth);
        }

        private void updateViewWithWeeklySelected()
        {
            DateTime beginningOfWeek = findBeginningOfWeek(SelectedDate);
            DateTime endOfWeek = findEndOfWeek(SelectedDate);
            appointmentDataGridView.DataSource = getAppointmentsInTimePeriod(beginningOfWeek, endOfWeek);
        }
    }
}
