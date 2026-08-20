using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Forms;

namespace ItineraryPlannerApp.Forms.CityForm
{
    public partial class CityDetailsEditor : UserControl
    {
        private readonly ItineraryPlannerService _service;
        private readonly HomeForm _homeForm;
        private City City = new City();
        private bool isEdit; 

        public CityDetailsEditor(ItineraryPlannerService service, HomeForm homeForm, City city)
        {
            _service = service;
            _homeForm = homeForm;
            City = city;
            InitializeComponent();

            isEdit = City is not null;
            if (City is not null)
            {
                CityNameBox.Text = City.CityName;
                DescriptionBox.Text = City.Description;
                CountryBox.Text = City.Country;
                // imgPath = City.ImagePath;
            }
            if (City.Slider is null) City.Slider = new MapSlider();
        }

        private void CityDetailsEditor_Load(object sender, EventArgs e)
        {
            // Is this creating a new city or saving the changes
            SaveButton.Text = (isEdit) ? "Save" : "Create";
        }

        private void CityNameBox_TextChanged(object sender, EventArgs e)
        {
            City.CityName = CityNameBox.Text;
        }

        private void DescriptionBox_TextChanged_1(object sender, EventArgs e)
        {
            City.Description = DescriptionBox.Text;
        }

        private void CountryBox_TextChanged(object sender, EventArgs e)
        {
            City.Country = CountryBox.Text;
        }

        private void ChangeMapButton_Click(object sender, EventArgs e)
        {
            using var mapEditor = new CityMapEditor(City.CityName, City.Slider);

            if (mapEditor.ShowDialog() == DialogResult.OK)
            {
                City.Slider = mapEditor.NewSlider;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string error = "";
            if (string.IsNullOrWhiteSpace(City.Country)
                || string.IsNullOrWhiteSpace(City.CityName)
                || string.IsNullOrWhiteSpace(City.Description))
            {
                error = error + "Please fill in all fields\n";
            }
            if (!City.Slider.IsValid)
            {
                error += "Please set up the map\n";
            }

            if (error == "")
            {
                bool result;
                if (isEdit)
                {
                    result = _service.UpdateCity(City);
                    if (result)
                    {
                        MessageBox.Show($"{City.CityName} has been edited!");
                        _homeForm.SpawnCityShowcase();
                    }
                    else
                        MessageBox.Show($"There is already a city created with name {City.CityName}");
                }
                else
                {
                    result = _service.AddCity(City);
                    if (result)
                    {
                        MessageBox.Show($"{City.CityName} has been edited!");
                        _homeForm.SpawnCityShowcase();
                    }
                    else
                        MessageBox.Show($"There is already a city created with name {City.CityName}");
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
                $"Your changes to {City.CityName} will not be saved..",
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
