using ItineraryPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Data.Repositories
{
    public class AttractionRepository: Repository<Attraction>
    {
        public AttractionRepository(ItineraryDbContext context) : base(context) { }
    }
}
