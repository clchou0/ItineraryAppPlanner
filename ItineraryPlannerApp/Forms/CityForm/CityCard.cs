using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItineraryPlannerApp.Helpers;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Forms.CityForm
{
    public partial class CityCard : UserControl
    {
        public City City;
        public bool IsAdmin;
        private readonly HomeForm _homeForm;

        public CityCard(City city, bool isAdmin, HomeForm homeForm)
        {
            InitializeComponent();

            City = city;
            IsAdmin = isAdmin;
            _homeForm = homeForm;

            pictureBox1.Image = ImageHelper.LoadImage(city.ImagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            NameLabel.Text = city.CityName;
            CountryLabel.Text = city.Country;

            // Editing function enabling
            EditButton.Visible = isAdmin;
        }
        private void CityCard_Load(Object sender, EventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            _homeForm.SpawnCityEditor(City);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void ProceedButton_Click(object sender, EventArgs e)
        {
            _homeForm.OpenItineraryCreator(City, null);
        }
    }

}
