using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public class TransitRoute
    {
        public int Id { get; set; }
        public TransportType Type { get; set; }
        public string RouteName { get; set; } = "";
        public string CityName { get; set; } = "";
        public List<TransitStop> Stops { get; set; } = new List<TransitStop>();
    }
}
