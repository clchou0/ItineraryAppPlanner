using ItineraryPlannerApp.CityForms;
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
        private readonly ItineraryPlannerService _service;
        private readonly bool _isAdmin;
        public CityShowcase(ItineraryPlannerService service, bool isAdmin)
        {
            _service = service;
            _isAdmin = isAdmin;
            InitializeComponent();
            loadCities("");
        }

        private void loadCities(string filter)
        {
            var cities = _service.GetAllCities();
            filter = filter.Trim();
            if (!string.IsNullOrWhiteSpace(filter))
            {
                cities = cities.Where(c => c.Country.Contains(filter) || c.CityName.Contains(filter));
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
                var card = new CityCard(city, _isAdmin, this)
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

        }

        private void AddOrItButton_Click(object sender, EventArgs e)
        {

        }
    }
}
