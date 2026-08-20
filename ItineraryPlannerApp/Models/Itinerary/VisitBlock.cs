using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public class VisitBlock: ItineraryBlock
    {
        public Attraction Attraction { get; set; } = new Attraction();
        public int AttractionId {  get; set; }
        public string Note { get; set; } = string.Empty;
    }
}
