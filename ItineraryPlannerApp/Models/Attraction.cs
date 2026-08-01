using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public class Attraction
    {
        public int Id {  get; set; }
        public string AttractionName { get; set; }
        public string ImagePath {  get; set; }
        public Location Location { get; set; }
        public string Description {  get; set; }
        public double EntryPrice {  get; set; }
        public List<AttractionCategory> Labels { get; set; } = new List<AttractionCategory>(); 
        public List<Accessibility> CloseStations { get; set; } = new List<Accessibility>();

        public City City { get; set; }
        public int CityId { get; set; }
    }
}
