using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Repositories;
using ItineraryPlannerApp.Helpers;
using ItineraryPlannerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ItineraryPlannerApp.Forms
{
    public partial class HomeForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly User _user;

        public HomeForm(MainForm mainForm, User user)
        {
            InitializeComponent();

            this.Load += HomeFormLoad;

            _mainForm = mainForm;
            _user = user;


            welcomeLabel.Text = $"Welcome, {user.DisplayName}";
        }

        private async void HomeFormLoad(object sender, EventArgs e)
        {
            using var context = new ItineraryDbContext();

            City? sydney = await context.Cities.FirstOrDefaultAsync(
                c => c.CityName == "Sydney");

            if (sydney != null)
            {
                DisplayCity(sydney);
            }
        }

        private void DisplayCity(City city)
        {
            cityLabel.Text = city.CityName;

            cityImage.Image?.Dispose();
            cityImage.Image = ImageHelper.LoadImage(city.ImagePath);

            cityImage.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
        }
    }
}
