using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Forms.Attraction
{
    // Customer / Staff side city visualizer, with attractions rendered
    public partial class CityMap : UserControl
    {
        City City;
        public CityMap(City city)
        {
            InitializeComponent();
            City = city;
        }
    }
}
