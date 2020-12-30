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

        public CustomerRecords(User user)
        {
            InitializeComponent();
            User = user;
            customerDataGridView.DataSource = ListOfCustomers;
        }

        private void CustomerRecords_Load(object sender, EventArgs e)
        {
            mainLabel.Text = $"Customer Records for {User.UserName}:";
            Database.getCustomerByUserName(User.UserName);
        }

        private void CustomerRecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
