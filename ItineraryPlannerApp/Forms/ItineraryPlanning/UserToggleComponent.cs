using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using System.ComponentModel;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning
{
    public partial class UserToggleComponent : UserControl
    {
        private readonly ItineraryPlannerService _service;
        private Dictionary<AppPage, Label> _labels = new Dictionary<AppPage, Label>();
       
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Attraction> AllAttractions { get; set; } = new List<Attraction>();

        
        public City City;
        public Itinerary Itinerary;
        private readonly HomeForm _homeForm;
        private AttractionList _attractionList;
        private CityMap _cityMap;

        public UserToggleComponent(ItineraryPlannerService service, City city, Itinerary? itinerary, HomeForm homeForm)
        {
            InitializeComponent();
            _service = service;
            City = city;
            _homeForm = homeForm;

            Itinerary = itinerary ?? new Itinerary();

            _labels[AppPage.CityMap] = CityMapTag;
            _labels[AppPage.AttractionList] = AttractionListTag;
            _labels[AppPage.ItineraryPlanner] = ItineraryPlannerTag;
            AllAttractions = _service.GetAttractionsByCity(City); 

            setupAttractions();
            setupMap();
            setupItinerary();

            TogglePage(AppPage.CityMap);
        }

        private void setupMap()
        {
            _cityMap = new CityMap(City.Slider, this);
        }
        private void setupAttractions()
        {
            _attractionList = new AttractionList(_service, City, this);
        }
        private void setupItinerary()
        {
            
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
            switch (page)
            {
                case AppPage.AttractionList: 
                    panel1.Controls.Add(_attractionList);
                    break;
                case AppPage.CityMap:
                    panel1.Controls.Add(_cityMap);
                    break;
                default: return;
            }
            
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
        public void ReloadAttractions()
        {
            AllAttractions = _service.GetAttractionsByCity(City);
            _attractionList.ReloadAttractionList();
        }
    }
    enum AppPage { CityMap, AttractionList, ItineraryPlanner };
}
