using ItineraryPlannerApp.Forms.CityForm;
using ItineraryPlannerApp.Forms.ItineraryForm;
using ItineraryPlannerApp.Helpers;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;
using Planner.WPF;

namespace ItineraryPlannerApp.Forms
{
    public partial class HomeForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly User _user;
        private string _selectedCity = "";
        private readonly ItineraryPlannerLauncher _itineraryPlannerLauncher;

        public HomeForm()
        {
            InitializeComponent();


            buildItineraryToolStripMenuItem.Click += buildItineraryToolStripMenuItem_Click;
            itineraryHistoryToolStripMenuItem.Click += itineraryHistoryToolStripMenuItem_Click;

        }
        public HomeForm(MainForm mainForm, User user) : this()
        {
            this.Load += HomeFormLoad;
            this.AutoScroll = false;

            _mainForm = mainForm;
            _user = user;
            _itineraryPlannerLauncher = new ItineraryPlannerLauncher(mainForm.Service);

            welcomeLabel.Text = $"Welcome, {user.DisplayName}";
        }

        private void HomeFormLoad(object sender, EventArgs e)
        {
            var cities = _mainForm.Service.GetAllCities();

            foreach (City city in cities)
            {
                var card = new CityCard(city, _user.Role == UserRole.Admin);
                int margin = Math.Max(0, (panel1.ClientSize.Width - card.Width) / 2);
                card.Margin = new Padding(margin, 10, margin, 10);
                panel1.Controls.Add(card);
            }
        }
        private void logoutButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MenuButton, new Point(0, MenuButton.Height));
        }

        private void buildItineraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _itineraryPlannerLauncher.SpawnItineraryPlanner(_user);
        }

        private void itineraryHistoryToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            var window = new ItineraryHistory();
            window.Show();
        }
    }
}
