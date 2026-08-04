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
        public IEnumerable<Attraction> GetAll() { return _context.Attractions.ToList(); }
        public Attraction? GetById(int id)
        {
            return _context.Attractions
                .Include(a => a.City)
                .Include(a => a.CloseStations)
                .Include(a => a.Labels)
                .SingleOrDefault(a => a.Id == id); 
        }
        public void Delete(int id)
        {
            Attraction? attraction = this.GetById(id);
            if (attraction is not null) Remove(attraction);
        }
    }
}
