using ItineraryPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class AttractionList : UserControl
    {
        public City City;
        public AttractionList(City city)
        {
            City = city;
            InitializeComponent();
        }

        private void AttractionList_Load(object sender, EventArgs e)
        {

        }
    }
}
