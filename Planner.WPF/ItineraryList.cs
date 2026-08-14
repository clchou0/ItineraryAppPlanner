using System;
using System.Collections.Generic;
using System.Text;

namespace Planner.WPF
{
    public class ItineraryList
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string CityName { get; set; } = "";
        public DateTime ArriveDate { get; set; }
        public DateTime LeaveDate { get; set; }
        public double TotalPrice { get; set; }
        public List<ItineraryBlockItem> Blocks { get; set; } = new();
        public int BlockCount => Blocks.Count;
    }
}
