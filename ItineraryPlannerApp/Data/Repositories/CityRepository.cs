using ItineraryPlannerApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace ItineraryPlannerApp.Data.Repositories
{
    public class CityRepository: Repository<City>
    {
        public CityRepository(ItineraryDbContext context) : base(context) { }
    }
}
