using ItineraryPlannerApp.Data.Services;
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
        private readonly ItineraryPlannerService _service;
        public AttractionList(ItineraryPlannerService service, City city)
        {
            _service = service;
            City = city;
            InitializeComponent();
        }

        private void AttractionList_Load(object sender, EventArgs e)
        {
            var attractions = _service.GetAttractionsByCity(City);
            foreach (var attraction in attractions) 
            {
                flowLayoutPanel1.Controls.Add(new AttractionRow(_service, attraction, true));
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var editor = new AttractionDetailsEditor(_service, this.FindForm(), new Attraction { City = City }, true);
            editor.BringToFront();
            editor.Dock = DockStyle.Fill;
        }
    }
}
