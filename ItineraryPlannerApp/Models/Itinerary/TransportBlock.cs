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
    public class TransportNote
    {
        public int Id { get; set; }
        public TransportType Method {  get; set; }
        public string Route {  get; set; }
        public string FromStation {  get; set; }
        public string ToStation {  get; set; }

        public TransportBlock Block {  get; set; }
        public int BlockId { get; set; }
    }
}
