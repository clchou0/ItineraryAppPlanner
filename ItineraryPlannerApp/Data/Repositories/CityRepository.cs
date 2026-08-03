using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Data.Repositories
{
    public class CityRepository: Repository<City>
    {
        public CityRepository(ItineraryPlannerContext context) : base(context) { }
        public IEnumerable<City> GetAll() { return _context.Cities.ToList(); }
        public City? GetById(int id) { return _context.Cities.SingleOrDefault(c => c.Id == id); }
        public void Delete(int id)
        {
            City? city = this.GetById(id);
            if (city is not null) Remove(city);
        }
    }
}
