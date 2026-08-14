using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using Topten.RichTextKit.Utils;

namespace ItineraryPlannerApp.Forms.CityForm
{
    public partial class CityDetailsEditor : Form
    {
        private readonly MainForm _mainForm;
        private City? City;
        private string name, description, country, imgPath = "";
        private MapSlider mapSlider = new MapSlider();
        public CityDetailsEditor(MainForm mainForm, City? city)
        {
            _mainForm = mainForm;
            City = city;
            InitializeComponent();
        }

        private void CityDetailsEditor_Load(object sender, EventArgs e)
        {
            SaveButton.Text = (City == null) ? "Create" : "Save";
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
            using var mapEditor = new CityMapEditor(name, mapSlider, City);

            if (mapEditor.ShowDialog() == DialogResult.OK)
            {
                mapSlider = mapEditor.NewSlider; // <-- reading it here
                LABEL.Text = mapSlider.ToString();
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
                    result = _mainForm.Service.AddCity(newCity);
                    MessageBox.Show($"{name} has been created!");
                }
                else
                {
                    City.CityName = name;
                    City.Description = description;
                    City.Country = country;
                    City.Slider = mapSlider;
                    City.ImagePath = imgPath;
                    result = _mainForm.Service.UpdateCity(City);
                    MessageBox.Show($"{name} has been edited!");
                }
                if (result)
                {
                    Application.Exit();
                }
            }
            else
            {
                MessageBox.Show(error);
            }
        }
    }
}
