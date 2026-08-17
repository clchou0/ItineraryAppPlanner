using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public class Attraction
    {
        public int Id { get; set; }
        public string AttractionName { get; set; } = string.Empty;
        public string ImagePath { get; set; } = string.Empty;
        public Location Location { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ShortDesctiption { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string EntryPrice { get; set; } = string.Empty;
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
