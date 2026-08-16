using ItineraryPlannerApp.Data.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms.Login
{
    public partial class PasswordForm : Form
    {
        private readonly MainForm _mainForm;

        private string _resetCode = "";
        private string _resetEmail = "";
        public PasswordForm(MainForm mainForm)
        {
            InitializeComponent();

            _mainForm = mainForm;

            panelSendCode.Visible = true;
            panelResetPassword.Visible = false;
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            string email = emailTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                errorLabel1.Text = "Please enter your email.";
                return;
            }

            var user = _mainForm.Service.GetUserByEmail(email);

            if (user == null)
            {
                errorLabel1.Text = "Invalid email.";
                return;
            }

            _resetEmail = email;

            Random random = new Random();

            _resetCode = random.Next(1000, 9999).ToString();
            SendButton.Enabled = false;
            SendButton.Text = "Code Sent";

            try
            {
                await _mainForm.EmailService.SendResetCodeAsync(email, _resetCode);

                MessageBox.Show("Code sent successfully.");
            }

            catch (Exception ex)
            {
                errorLabel1.Text = "Failed to send reset email.\n" + ex.Message;
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                SendButton.Enabled = true;
                SendButton.Text = "Send Code";
            }
        }

        private async void verifyButton_Click(object sender, EventArgs e)
        {
            string code = codeTxt.Text.Trim();

            if (code != _resetCode)
            {
                errorLabel1.Text = "Not correct validation code.";
                return;
            }

            if (string.IsNullOrWhiteSpace(code))
            {
                errorLabel1.Text = "Enter the verification code.";
                return;
            }

            panelResetPassword.Visible = true;
            errorLabel1.Text = "";
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            string newPass = textPass1.Text;
            string confirmPass = textPass2.Text;

            if (string.IsNullOrWhiteSpace(newPass) || string.IsNullOrWhiteSpace(confirmPass))
            {
                errorLabel2.Text = "Fields cannot be empty.";
                return;
            }

            if (newPass.Length < 6)
            {
                errorLabel2.Text = "Password must be at least 6 characters.";
                return;
            }

            if (newPass != confirmPass)
            {
                errorLabel2.Text = "Passwords should be matched.";
                return;
            }

            var user = _mainForm.Service.GetUserByEmail(_resetEmail);

            if (user == null)
            {
                errorLabel2.Text = "Invalid activity.";
                return;
            }

            user.PasswordHash = PasswordService.HashPassword(newPass);
            _mainForm.Service.UpdateUser(user);

            MessageBox.Show("Password reset successfully.");
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
        }
    }
}
