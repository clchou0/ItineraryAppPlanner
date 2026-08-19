using ItineraryPlannerApp.Forms.CityForm;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Forms;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models.Itinerary;
using ItineraryPlannerApp;
using Planner.WPF;
using ItineraryPlannerApp.Forms.ItineraryForm;
using ItineraryPlannerApp.Forms.ItineraryPlanning;

namespace ItineraryPlannerApp.Forms
{
    /// <summary>
    /// Where the app flow is located at: controls get in and out based on what is supposed to appear
    /// </summary>
    public partial class HomeForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly User _user;
        private readonly ItineraryPlannerLauncher _itineraryPlannerLauncher;
        private CityShowcase _cityShowcase;

        public HomeForm(MainForm mainForm, User user)
        {
            InitializeComponent();
            this.Load += HomeFormLoad;
            this.AutoScroll = false;

            _mainForm = mainForm;
            _user = user;
            welcomeLabel.Text = $"Welcome, {user.DisplayName}";
            welcomeLabel.Location = new Point(1148 - welcomeLabel.Width, welcomeLabel.Location.Y);
            buildItineraryToolStripMenuItem.Click += buildItineraryToolStripMenuItem_Click;
            itineraryHistoryToolStripMenuItem.Click += itineraryHistoryToolStripMenuItem_Click;

            _itineraryPlannerLauncher = new ItineraryPlannerLauncher(mainForm.Service);
            welcomeLabel.Text = $"Welcome, {user.DisplayName}";
        }

        // default load: 
        private void HomeFormLoad(object sender, EventArgs e)
        {
            _cityShowcase = new CityShowcase(this, _mainForm.Service, _user.Role == UserRole.Admin);
            panel1.Controls.Clear(); // clear out anything previously shown
            panel1.Controls.Add(_cityShowcase);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
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
        public void SpawnCityEditor(City? city)
        {
            var cityEditor = new CityDetailsEditor(_mainForm.Service, this, city);
            panel1.Controls.Clear();
            panel1.Controls.Add(cityEditor);
        }
        public void SpawnCityShowcase()
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(_cityShowcase);
        }
        public void OpenItineraryCreator(City city, Itinerary? itinerary)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(new UserToggleComponent(_mainForm.Service, city, _user.Role == UserRole.Admin, itinerary, this));
        }
    }
}
