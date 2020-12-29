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
    public partial class LogIn : Form
    {
        List<User> users;
        public LogIn()
        {
            InitializeComponent();
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            users = Database.getAllUsers();
            errorLabel.Text = "";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
                if(userName == "" || password == "")
                {
                    throw new LoginException("You need to have both a User Name and Password to login");
                }

                var signedInUser = users.Where(user => user.UserName == userName).ToList();
                if (signedInUser.Count < 1)
                {
                    throw new LoginException("The User Name you entered does not exist.");
                }

                if (signedInUser[0].Password != password)
                {
                    throw new LoginException("The password is incorrect");
                }

                MessageBox.Show("You have successfully logged in!", "Login Status", MessageBoxButtons.OK);
            }
            catch (LoginException error)
            {
                errorLabel.Text = error.Message;
            }
        }
    }
}
