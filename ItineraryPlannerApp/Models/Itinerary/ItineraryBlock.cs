using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public abstract class ItineraryBlock
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Itinerary Itinerary { get; set; }
        public int ItineraryId { get; set; }
    }
}
