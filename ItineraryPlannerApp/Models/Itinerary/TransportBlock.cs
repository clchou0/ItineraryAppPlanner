using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public class TransportBlock: ItineraryBlock
    {
        public List<TransportNote> Notes { get; set; } = new List<TransportNote> ();
        public int TotalDuration {  get; set; }
    }
}
