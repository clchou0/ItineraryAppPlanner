using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace ItineraryPlannerApp.Forms.CityForm
{
    /// <summary>
    /// Panel component to show all the cities
    /// </summary>
    public partial class CityShowcase : UserControl
    {
        private readonly HomeForm _homeForm;
        private readonly ItineraryPlannerService _service;
        private readonly bool _isAdmin;
        private readonly IEnumerable<City> _cities;
        public CityShowcase(HomeForm homeForm, ItineraryPlannerService service, bool isAdmin)
        {
            _homeForm = homeForm;
            _service = service;
            _isAdmin = isAdmin;
            InitializeComponent();
            _cities = _service.GetAllCities();
            loadCities("");
            // if (!isAdmin) AddOrItButton.Text = "Past Itineraries"
        }

        private void loadCities(string filter)
        {
            var cities = _cities;
            filter = filter.Trim().ToLower();
            // Check filter content
            if (!string.IsNullOrWhiteSpace(filter))
            {
                cities = cities.Where(c => c.Country.ToLower().Contains(filter) || c.CityName.ToLower().Contains(filter));
            }

            cardContainer.Controls.Clear();
            cardContainer.RowStyles.Clear();
            cardContainer.RowCount = 0;

            cardContainer.ColumnCount = 2;
            cardContainer.ColumnStyles.Clear();
            cardContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            cardContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));

            int row = 0, col = 0;
            foreach (City city in cities)
            {
                var card = new CityCard(city, _isAdmin, _homeForm)
                {
                    Anchor = AnchorStyles.None, // centers within its cell
                    Margin = new Padding(10)
                };

                if (col == 0)
                {
                    cardContainer.RowCount = row + 1;
                    cardContainer.RowStyles.Add(new RowStyle(SizeType.AutoSize));
                }
                cardContainer.Controls.Add(card, col, row);
                col++;
                if (col == 2) { col = 0; row++; }
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            loadCities(SearchTextBox.Text);
        }

        // Maybe would be "past itineraries" text
        private void AddOrItButton_Click(object sender, EventArgs e)
        {
            _homeForm.SpawnCityEditor(null);
        }
        // City proceed button tapped, goes to the 3-split page
        public void HandleProceed(City city)
        {

        }
    }
}
