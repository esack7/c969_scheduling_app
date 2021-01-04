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
            PreviousForm.Show();
            Close();
        }
    }
}
