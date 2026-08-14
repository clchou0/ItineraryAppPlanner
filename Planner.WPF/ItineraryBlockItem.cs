using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.WPF
{
    public class ItineraryBlockItem
    {
        public int Id { get; set; }
        public int ItineraryId { get; set; }
        public string Type { get; set; } = "";
        public int? AttractionId { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime StartTime { get; set; }
        public int Duration { get; set; }
        public decimal Cost { get; set; }
        public string TransportMethod { get; set; } = "";
        public string Route { get; set; } = "";
        public string FromStation { get; set; } = "";
        public string ToStation { get; set; } = "";

    }
}
