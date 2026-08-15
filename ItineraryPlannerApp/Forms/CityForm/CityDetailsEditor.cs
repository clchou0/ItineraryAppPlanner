using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Forms;
using ItineraryPlannerApp.CityForms;

namespace ItineraryPlannerApp.Forms.CityForm
{
    public partial class CityDetailsEditor : UserControl
    {
        private readonly ItineraryPlannerService _service;
        private readonly HomeForm _homeForm;
        private City? City;
        private string name, description, country, imgPath = "";
        private MapSlider mapSlider;

        public CityDetailsEditor(ItineraryPlannerService service, HomeForm homeForm, City? city)
        {
            _service = service;
            _homeForm = homeForm;
            City = city;
            InitializeComponent();
            if (City is not null)
            {
                CityNameBox.Text = City.CityName;
                DescriptionBox.Text = City.Description;
                CountryBox.Text = City.Country;
                mapSlider = City.Slider;
                imgPath = City.ImagePath;
            }
            if (City is null || City.Slider is null) mapSlider = new MapSlider();
        }

        private void CityDetailsEditor_Load(object sender, EventArgs e)
        {
            // Is this creating a new city or saving the changes
            SaveButton.Text = (City is null) ? "Create" : "Save";
        }

        private void CityNameBox_TextChanged(object sender, EventArgs e)
        {
            name = CityNameBox.Text;
        }

        private void DescriptionBox_TextChanged_1(object sender, EventArgs e)
        {
            description = DescriptionBox.Text;
        }

        private void CountryBox_TextChanged(object sender, EventArgs e)
        {
            country = CountryBox.Text;
        }

        private void ChangeMapButton_Click(object sender, EventArgs e)
        {
            using var mapEditor = new CityMapEditor(name, mapSlider);

            if (mapEditor.ShowDialog() == DialogResult.OK)
            {
                mapSlider = mapEditor.NewSlider;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrWhiteSpace(country)
                || string.IsNullOrWhiteSpace(name)
                || string.IsNullOrWhiteSpace(description))
            {
                error = error + "Please fill in all fields\n";
            }
            if (!mapSlider.IsValid)
            {
                error += "Please set up the map\n";
            }

            if (error == "")
            {
                bool result;
                if (City is null)
                {
                    var newCity = new City
                    {
                        CityName = name,
                        Description = description,
                        Country = country,
                        ImagePath = "",
                        Slider = mapSlider
                    };

                    result = _service.AddCity(newCity);
                    // Create success!!
                    if (result)
                    {
                        MessageBox.Show($"{name} has been created!");
                        _homeForm.SpawnCityShowcase();
                    }
                    else
                    {
                        MessageBox.Show($"There is already a city created with name {name}");
                    }

                }
                else
                {
                    var updated = new City
                    {
                        Id = City.Id,
                        CityName = name,
                        Description = description,
                        Country = country,
                        Slider = mapSlider,
                        ImagePath = imgPath
                    };

                    result = _service.UpdateCity(City);
                    if (result)
                    {
                        MessageBox.Show($"{name} has been edited!");
                        _homeForm.SpawnCityShowcase();
                    }
                    else
                        MessageBox.Show($"There is already a city created with name {name}");
                }
            }
            else
            {
                MessageBox.Show(error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Your changes to {name} will not be saved..",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                // proceed
                _homeForm.SpawnCityShowcase();
            }
        }
    }
}
