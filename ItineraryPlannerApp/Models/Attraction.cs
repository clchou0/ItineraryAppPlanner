using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string AttractionName { get; set; }
        public string ImagePath { get; set; }
        public Location Location { get; set; }
        public string Description { get; set; }
        public string ShortDesctiption { get; set; }
        public string Area { get; set; }
        public double EntryPrice { get; set; }
        public AttractionCategory Category { get; set; }
        public List<TransitAccess> CloseStations { get; set; } = new List<TransitAccess>();

        public City City { get; set; }
        public int CityId { get; set; }

        public string TransportMethods
        {
            get
            {
                string methods = "";
                foreach (TransportType type in Enum.GetValues<TransportType>())
                {
                    if (CloseStations.Any(c => c.Type == type))
                    {
                        if (!String.IsNullOrEmpty(methods))
                        {
                            methods += ", ";
                        }
                        methods += type.ToString();
                    }
                }

                return methods;
            }
        }
    }
}
