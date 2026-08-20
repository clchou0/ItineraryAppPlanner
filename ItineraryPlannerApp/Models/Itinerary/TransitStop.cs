using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public class TransitStop
    {
        public int Id { get; set; }
        public string StopName { get; set; } = "";
        public int StopOrder { get; set; }
        public int TransitRouteId { get; set; }
        public TransitRoute TransitRoute { get; set; } = new TransitRoute();
    }
}
