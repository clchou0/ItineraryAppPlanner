using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions;
using ItineraryPlannerApp.Data.Services;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning
{
    public partial class UserToggleComponent : UserControl
    {
        private readonly ItineraryPlannerService _service;
        private Dictionary<AppPage, Label> _labels = new Dictionary<AppPage, Label>();
        private Dictionary<AppPage, UserControl> _pages = new Dictionary<AppPage, UserControl>();
        public City City;
        public Itinerary Itinerary;
        private readonly HomeForm _homeForm;

        public UserToggleComponent(ItineraryPlannerService service, City city, Itinerary? itinerary, HomeForm homeForm)
        {
            InitializeComponent();
            _service = service;
            City = city;
            _homeForm = homeForm;

            // TODO: Change this to a blank itinerary
            Itinerary = itinerary ?? new Itinerary();

            _labels[AppPage.CityMap] = CityMapTag;
            _labels[AppPage.AttractionList] = AttractionListTag;
            _labels[AppPage.ItineraryPlanner] = ItineraryPlannerTag;
            _pages[AppPage.AttractionList] = new AttractionList(_service, city);

            _pages[AppPage.ItineraryPlanner] = new UserControl
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };
            _pages[AppPage.CityMap] = new UserControl
            {
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };

            TogglePage(AppPage.CityMap);
        }

        private void setupMap()
        {
            _pages[AppPage.CityMap] = new UserControl();
        }
        private void setupAttractions()
        {
            _pages[AppPage.AttractionList] = new UserControl();
        }
        private void setupItinerary()
        {
            _pages[AppPage.ItineraryPlanner] = new UserControl();
        }



        // MapPage, listPage and itineraryPage
        private void CityMapTag_Click(object sender, EventArgs e)
        {
            TogglePage(AppPage.CityMap);
        }

        private void AttractionListTag_Click(object sender, EventArgs e)
        {
            TogglePage(AppPage.AttractionList);
        }

        private void ItineraryPlannerTag_Click(object sender, EventArgs e)
        {
            TogglePage(AppPage.ItineraryPlanner);
        }
        private void TogglePage(AppPage page)
        {
            panel1.Controls.Clear();

            CityMapTag.BackColor = Color.White;
            AttractionListTag.BackColor = Color.White;
            ItineraryPlannerTag.BackColor = Color.White;


            _labels[page].BackColor = Color.Gray;
            // panel1.Controls.Add(new Label { Text = page.ToString() });
            panel1.Controls.Add(_pages[page]);
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Your changes to the itinerary will not be saved..",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.OK)
            {
                _homeForm.SpawnCityShowcase();
            }
        }
    }
    enum AppPage { CityMap, AttractionList, ItineraryPlanner };
}
