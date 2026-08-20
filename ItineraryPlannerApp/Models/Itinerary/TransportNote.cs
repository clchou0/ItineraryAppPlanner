using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public class TransportNote
    {
        public int Id { get; set; }
        public TransportType Method { get; set; }
        public string Route { get; set; } = string.Empty;
        public string FromStation { get; set; } = string.Empty;
        public string ToStation { get; set; } = string.Empty;

        public TransportBlock Block { get; set; } = new TransportBlock();
        public int BlockId { get; set; }
    }
}
