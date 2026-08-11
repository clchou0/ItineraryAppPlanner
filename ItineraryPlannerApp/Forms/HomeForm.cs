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

        private void HomeFormLoad(object sender, EventArgs e)
        {
            var cities = _mainForm.Service.GetAllCities();

            foreach (City city in cities)
            {
                Panel cityCard = DisplayCity(city);
                panel1.Controls.Add(cityCard);

                int margin = Math.Max(0, (panel1.ClientSize.Width - cityCard.Width) / 2);

                cityCard.Margin = new Padding(margin, 10, 0, 20);
            }
        }

        private Panel DisplayCity(City city)
        {
            Panel card = new Panel
            {
                Width = 1280,
                Height = 400,
                Margin = new Padding(10, 10, 10, 20), Cursor = Cursors.Hand, Tag = city
            };

            PictureBox pic = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = ImageHelper.LoadImage(city.ImagePath),
                Cursor = Cursors.Hand,
                Tag = city
            };

            Label cityName = new Label
            {
                Text = city.CityName,
                AutoSize = false,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Tag = city
            };

            card.Controls.Add(pic);
            pic.Controls.Add(cityName);

            cityName.BringToFront();

            card.Click += CityCard_Click;
            pic.Click += CityCard_Click;
            cityName.Click += CityCard_Click;

            return card;
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
    }
}
