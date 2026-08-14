using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.WPF
{
    public class ItineraryEditData
    {
        public int? ItineraryId { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string? CityName { get; set; } = "";
        public DateTime ArriveDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public List<ItineraryBlockItem> Blocks { get; set; } = new();
        public List<TransitRouteItem> TransitRoutes { get; set; } = new();
        //public double TotalPrice { get; set; }
    }

    public class TransitStopItem 
    {
        public int Id { get; set; }
        public string StopName { get; set; } = "";
        public int StopOrder { get; set; }
    }

    public class TransitRouteItem
    {
        public int Id { get; set; }
        public string CityName { get; set; } = "";
        public string RouteName { get; set; } = "";
        public string Type { get; set; } = "";
        public List<TransitStopItem> Stops { get; set; } = new();
    }
}
