using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
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
<<<<<<< HEAD
        private readonly bool _isAdmin;
        private readonly ItineraryPlannerService _service;
        private List<Attraction> _allAttractions;
        private readonly UserToggleComponent _component;
        public AttractionList(ItineraryPlannerService service, City city, bool isAdmin, UserToggleComponent component)
=======
        private readonly User _user;
        private readonly ItineraryPlannerService _service;
        private List<Attraction> _allAttractions;
        private readonly UserToggleComponent _component;
        public AttractionList(ItineraryPlannerService service, City city, User user, UserToggleComponent component)
>>>>>>> main
        {
            _service = service;
            City = city;
            _user = user;
            _component = component;
            
            InitializeComponent();
            ReloadAttractionList();
        }

        private void AttractionList_Load(object sender, EventArgs e)
        {
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var editor = new AttractionDetailsEditor(_service, _component, new Attraction { City = City }, _isAdmin);
            editor.BringToFront();
            editor.Dock = DockStyle.Fill;
        }
        public void ReloadAttractionList()
        {
            flowLayoutPanel2.Controls.Clear();
            
            foreach (var attraction in _component.AllAttractions)
            {
<<<<<<< HEAD
                flowLayoutPanel2.Controls.Add(new AttractionRow(_service, attraction, _isAdmin, _component));
=======
                var row = new AttractionRow(_service, attraction, true, _component);
                row.AddToItineraryRequested += AddAttractionToItinerary;

                flowLayoutPanel2.Controls.Add(row);
>>>>>>> main
            }
        }

        private void AddAttractionToItinerary(Attraction attraction)
        {
            var itineraries = _service.GetItinerariesByUserId(_user.Id)
                .Where(i => i.Status== ItineraryStatus.Draft && i.CityId == attraction.City.Id).ToList();

            if (itineraries.Count == 0) 
            {
                MessageBox.Show("No draft itineraries saved.\n Would you like to make make a new Itinerary first?");
                return;
            }

            if (itineraries.Count == 1)
            {
                AddVisitBlock(itineraries[0], attraction);
                return;
            }

            if (itineraries.Count > 1)
            {
                MessageBox.Show($"{itineraries.Count} draft itinerary. Choose the itinerary you want to add to.");
                return;
            }
        }

        private void AddVisitBlock(Itinerary itinerary, Attraction attraction)
        {
            bool duplicate = itinerary.ItineraryBlocks.OfType<VisitBlock>()
                .Any(v => v.AttractionId == attraction.Id);

            if (duplicate)
            {
                MessageBox.Show("This attraction is already in the itinerary.");
                return;
            }

            var visitBlock = new VisitBlock
            {
                AttractionId = attraction.Id,
                ItineraryId = itinerary.Id,
                StartTime = itinerary.ArriveDate.Date.AddHours(9),
                Note = attraction.ShortDesctiption ?? ""
            };

            itinerary.ItineraryBlocks.Add(visitBlock);
            _service.UpdateItinerary(itinerary);

            MessageBox.Show("Attraction added.");
        }
    }
}
