using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Services;
using Microsoft.EntityFrameworkCore;

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
            
            var user = _mainForm.Service.GetUserByEmail(email);
            if (user is null) 
            {
                errorLabel.Text = "No user registered with this email";
                return;
            }

            if (!PasswordService.VerifyPassword(password, user.PasswordHash))
            {
                errorLabel.Text = "Incorrect email or password.";
                return;
            }

            Hide();

            _mainForm.ShowPage(new HomeForm(_mainForm, user));

            Show();
            passwordTxt.Clear();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new RegisterForm(_mainForm));
        }
    }
}
