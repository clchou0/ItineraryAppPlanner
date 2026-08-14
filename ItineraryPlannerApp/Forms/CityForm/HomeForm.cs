using ItineraryPlannerApp.Forms.CityForm;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Forms;
using ItineraryPlannerApp.Data.Services;

namespace ItineraryPlannerApp.CityForms
{
    /// <summary>
    /// Where the app flow is located at: controls get in and out based on what is supposed to appear
    /// </summary>
    public partial class HomeForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly User _user;

        public HomeForm(MainForm mainForm, User user)
        {
            InitializeComponent();
            _mainForm = mainForm;
            this.Load += HomeFormLoad;
            this.AutoScroll = false;

            _user = user;
            welcomeLabel.Text = $"Welcome, {user.DisplayName}";
            welcomeLabel.Location = new Point(1148 - welcomeLabel.Width, welcomeLabel.Location.Y);
        }

        // default load: 
        private void HomeFormLoad(object sender, EventArgs e)
        {
            var cityShowcase = new CityShowcase(_mainForm.Service, _user.Role == UserRole.Admin);
            panel1.Controls.Clear(); // clear out anything previously shown
            panel1.Controls.Add(cityShowcase);
        }
        private void CityCard_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is City city)
            {
                MessageBox.Show($"Selected city: {city.CityName}");
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
        }
    }
}
