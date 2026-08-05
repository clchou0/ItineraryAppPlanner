using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    // Associative entity between label and Attraction
    public class AttractionLabel
    {
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
        public AttractionCategory Category { get; set; }
    }
}
