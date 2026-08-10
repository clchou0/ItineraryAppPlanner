using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public class City
    {
        public int Id {  get; set; }
        public string CityName { get; set; }
        public string Description {  get; set; }
        public string ImagePath { get; set; }
        public string Country { get; set; }
        public MapSlider Slider { get; set; }

        // public List<Attraction> Attractions { get; set; } = new List<Attraction>();

    }
}
