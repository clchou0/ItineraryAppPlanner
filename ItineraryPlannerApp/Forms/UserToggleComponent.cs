using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms
{
    public partial class UserToggleComponent : UserControl
    {
        private Dictionary<AppPage, Label> _labels = new Dictionary<AppPage, Label>();
        private Dictionary<AppPage, UserControl> _pages = new Dictionary<AppPage, UserControl>();
        public City City;
        public Itinerary Itinerary;

        public UserToggleComponent(City city, Itinerary? itinerary)
        {
            InitializeComponent();
            City = city;

            // TODO: Change this to a blank itinerary
            Itinerary = itinerary ?? new Itinerary();

            _labels[AppPage.CityMap] = CityMapTag;
            _labels[AppPage.AttractionList] = AttractionListTag;
            _labels[AppPage.ItineraryPlanner] = ItineraryPlannerTag;

        }

        private void setupMap()
        {
            _pages[AppPage.CityMap] = new UserControl();
        }
        private void setupAttractions()
        {
            _pages[AppPage.AttractionList] = new UserControl();
        }
        private void setupItinerary()
        {
            _pages[AppPage.ItineraryPlanner] = new UserControl();
        }
        


        // MapPage, listPage and itineraryPage
        private void CityMapTag_Click(object sender, EventArgs e)
        {
            TogglePage(AppPage.CityMap);
        }

        private void AttractionListTag_Click(object sender, EventArgs e)
        {
            TogglePage(AppPage.AttractionList);
        }

        private void ItineraryPlannerTag_Click(object sender, EventArgs e)
        {
            TogglePage(AppPage.ItineraryPlanner);
        }
        private void TogglePage(AppPage page)
        {
            panel1.Controls.Clear();

            CityMapTag.BackColor = Color.White;
            AttractionListTag.BackColor = Color.White;
            ItineraryPlannerTag.BackColor = Color.White;
            
            
            _labels[page].BackColor = Color.Gray;
            panel1.Controls.Add(new Label { Text = page.ToString() });
            // panel1.Controls.Add(_pages[page]);
        }
    }
    enum AppPage { CityMap, AttractionList, ItineraryPlanner };
}
