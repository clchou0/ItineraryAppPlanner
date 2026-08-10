using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Data.Repositories
{
    public class ItineraryRepository : Repository<Itinerary>
    {
        public ItineraryRepository(ItineraryDbContext context) : base(context) { }
    }
}
