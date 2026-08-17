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
        public IEnumerable<Attraction> GetAll() { return _context.Attractions.Include(a => a.CloseStations).ToList(); }
        public Attraction? GetById(int id) 
        { 
            return _context.Attractions.Include(a => a.CloseStations).SingleOrDefault(a => a.Id == id); 
        }
        public void Update(Attraction attraction)
        {
            _context.Attractions.Update(attraction);
            _context.SaveChanges();
        }
    }
}
