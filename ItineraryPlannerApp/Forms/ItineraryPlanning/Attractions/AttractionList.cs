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
        private List<Attraction> _allAttractions;
        private readonly UserToggleComponent _component;
        public AttractionList(ItineraryPlannerService service, City city, UserToggleComponent component)
        {
            _service = service;
            City = city;
            _component = component;
            
            InitializeComponent();
            ReloadAttractionList();
        }

        private void AttractionList_Load(object sender, EventArgs e)
        {
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var editor = new AttractionDetailsEditor(_service, _component, new Attraction { City = City }, true);
            editor.BringToFront();
            editor.Dock = DockStyle.Fill;
        }
        public void ReloadAttractionList()
        {
            flowLayoutPanel2.Controls.Clear();
            
            foreach (var attraction in _component.AllAttractions)
            {
                flowLayoutPanel2.Controls.Add(new AttractionRow(_service, attraction, true, _component));
            }
        }
    }
}
