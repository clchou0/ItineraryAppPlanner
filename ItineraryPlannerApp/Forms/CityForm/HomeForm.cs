using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Repositories;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Forms.CityForm;
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
            this.AutoScroll = false;

            _mainForm = mainForm;
            _user = user;

            welcomeLabel.Text = $"Welcome, {user.DisplayName}";
        }

        private void HomeFormLoad(object sender, EventArgs e)
        {
            var cities = _mainForm.Service.GetAllCities();

            foreach (City city in cities)
            {
                var card = new CityCard(city, _user.Role == UserRole.Admin);
                int margin = Math.Max(0, (panel1.ClientSize.Width - card.Width) / 2);
                card.Margin = new Padding(margin, 10, margin, 10);
                panel1.Controls.Add(card);
            }
        }
        private void CityCard_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is City city)
            {
                MessageBox.Show($"Selected city: {city.CityName}");
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }
    }
}
