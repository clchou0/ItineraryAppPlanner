using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms
{
    public partial class LoginForm : Form
    {
        private readonly MainForm _mainForm;
        public LoginForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void emailLabel_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void passwordTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private async void loginButton_Click(object sender, EventArgs e)
        {
            errorLabel.Text = string.Empty;

            string email = emailTxt.Text.Trim().ToLower();
            string password = passwordTxt.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                errorLabel.Text = "Please enter email and password to login.";
                return;
            }

            await using var context = new ItineraryDbContext();

            var user = await context.Users.FirstOrDefaultAsync(user => user.Email == email);

            if (user == null) 
            {
                errorLabel.Text = "Incorrect email or password.";
                return;
            }

            var passwordService = new PasswordService();

            bool passwordCorrect = passwordService.VerifyPassword(password, user.PasswordHash);

            if (!passwordCorrect)
            {
                errorLabel.Text = "Incorrect email or password.";
                return;
            }
            Hide();

            //if (user.Role == Models.UserRole.Admin)
            //{
            //    //using var adminForm = new AdminForm(user);
            //    //adminForm.ShowDialog();
            //}
            //else
            //{
            _mainForm.ShowPage(new HomeForm(_mainForm, user));
            //}

            Show();
            passwordTxt.Clear();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new RegisterForm(_mainForm));
        }
    }
}
