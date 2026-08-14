using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models.Itinerary
{
    public class Itinerary
    {
        public int Id {  get; set; }
        public DateTime ArriveDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public List<ItineraryBlock> ItineraryBlocks {  get; set; } = new List<ItineraryBlock>();
        public double TotalEntryPrice { get; set; } = 0;
        public ItineraryStatus Status { get; set; } = ItineraryStatus.Draft;

        public City City {  get; set; }
        public int CityId {  get; set; }

        public User User;
        public int UserId { get; set; }
    }
}
