using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public class VisitBlock: ItineraryBlock
    {
        public int Id;
        public Attraction Attraction { get; set; }
        public int AttractionId {  get; set; }
        public string Note { get; set; }
    }
}
