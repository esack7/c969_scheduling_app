﻿using System;
using System.Globalization;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace C969___Scheduling_App___Isaac_Heist
{
    public partial class LogIn : Form
    {
        private List<User> users;
        private string culture;
        public LogIn()
        {
            InitializeComponent();
        }

        private void changeLoginToSpanish()
        {
            mainLabel.Text = "Iniciar sesión de Aplicación de Planificación de Clientes";
            userNameLabel.Text = "Nombre de Usario";
            passwordLabel.Text = "Contraseña";
            loginButton.Text = "Iniciar Sesión";
        }
        private void LogIn_Load(object sender, EventArgs e)
        {
            culture = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
            users = Database.getAllUsers();
            errorLabel.Text = "";
            if (culture == "es")
            {
                changeLoginToSpanish();
            }
            userNameTextBox.Text = "test"; //remove once development is done
            passwordTextBox.Text = "test"; //remove
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName = userNameTextBox.Text;
            string password = passwordTextBox.Text;

            try
            {
                if(userName == "" || password == "")
                {
                    if (culture == "es")
                    {
                        throw new LoginException("Debe tener un nombre de usuario y una contraseña para iniciar sesión");
                    }
                    
                    throw new LoginException("You need to have both a User Name and Password to login");
                }
                //Below Lambda expession used to determine if user name entered match one of the user names returned from the database.
                List<User> signedInUser = users.Where(user => user.UserName == userName).ToList();
                
                if (signedInUser.Count < 1)
                {
                    if (culture == "es")
                    {
                        throw new LoginException("El nombre de usuario que ingresó no existe.");
                    }
                    throw new LoginException("The User Name you entered does not exist.");
                }

                if (signedInUser[0].Password != password)
                {
                    if (culture == "es")
                    {
                        throw new LoginException("La contraseña es incorrecta");
                    }
                    throw new LoginException("The password is incorrect");
                }
                Logging.logActivity(signedInUser[0]);

                var customerRecords = new CustomerRecords(signedInUser[0]);
                customerRecords.Show();
                Hide();
            }
            catch (LoginException error)
            {
                errorLabel.Text = error.Message;
            }
        }
    }
}
