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
        public City City { get; }
        public bool IsAdmin { get; }

        public event EventHandler<City>? EditRequested;
        public event EventHandler<City>? DeleteRequested;
        public event EventHandler<City>? ViewRequested;

        public CityCard(City city, bool isAdmin)
        {
            InitializeComponent();

            City = city;
            IsAdmin = isAdmin;

            pictureBox1.Image = ImageHelper.LoadImage(city.ImagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            NameLabel.Text = city.CityName;
            CountryLabel.Text = city.Country;

            EditButton.Visible = isAdmin;
            DeleteButton.Visible = isAdmin;
        }

        public void CityCard_Load(Object sender, EventArgs e)
        {
          
        }
    }
    
}
