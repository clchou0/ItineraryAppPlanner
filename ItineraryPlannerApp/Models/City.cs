using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public class City
    {
        public int Id {  get; set; }
        public string CityName { get; set; } = string.Empty;
        public string Description {  get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public MapSlider Slider { get; set; } = new MapSlider();

        // public List<Attraction> Attractions { get; set; } = new List<Attraction>();

    }
}
