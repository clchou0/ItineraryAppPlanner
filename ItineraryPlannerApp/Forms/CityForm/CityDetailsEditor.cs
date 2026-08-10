using ItineraryPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace ItineraryPlannerApp.Forms.CityForm
{
    public partial class CityDetailsEditor : Form
    {
        private City? City;
        private string name, description, country;
        private MapSlider mapSlider = new MapSlider();
        public CityDetailsEditor(City? city)
        {
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
                // Valid save
            }
            else
            {
                MessageBox.Show(error);
            }
        }
    }
}
