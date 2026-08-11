using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly MainForm _mainForm;
        public RegisterForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private async void createButton_Click(object sender, EventArgs e)
        {
            string name = nameText.Text.Trim();
            string email = emailText.Text.Trim();
            string pass = passText.Text.Trim();
            string pass2 = pass2Text.Text.Trim();

            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                errorLabel.Text = "Fields cannot be empty.";
                return;
            }



            if (pass.Length < 6)
            {
                errorLabel.Text = "Password must be at least 6 characters.";
                return;
            }
            else if (pass != pass2)
            {
                errorLabel.Text = "Passwords should be matched.";
                return;
            }

            bool validEmail(string email)
            {
                try
                {
                    var address = new MailAddress(email);
                    return address.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            if (!validEmail(email))
            {
                errorLabel.Text = "This email address is invalid.";
                return;
            }

            if (_mainForm.Service.GetUserByEmail(email) is not null)
            {
                errorLabel.Text = "This email is already registered.";
                return;
            }

            var user = new User
            {
                DisplayName = name,
                Email = email,
                PasswordHash = PasswordService.HashPassword(pass),
                Role = UserRole.User
            };

            _mainForm.Service.AddUser(user);

            MessageBox.Show("Account created successfully.");

            _mainForm.ShowPage(new LoginForm(_mainForm));
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
        }
    }
}
