using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    // Station that is close to said attraction
    public class TransitAccess
    {
        public int Id { get; set; }
        public TransportType Type { get; set; }
        public string StationName { get; set; } = string.Empty;
        public int MinuteWalk { get; set; }

        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; } = new Attraction();
        public bool IsValid
        {
            get
            {
                return Type != TransportType.None
                    && !string.IsNullOrEmpty(StationName)
                    && MinuteWalk > 0 && MinuteWalk < 20;
            }
        }
    }
}
