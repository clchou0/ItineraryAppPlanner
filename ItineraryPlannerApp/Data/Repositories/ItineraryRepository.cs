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
        public IEnumerable<Itinerary> GetAll() { return _context.Itineraries.ToList(); }
        public Itinerary? GetById(int id)
        {
            return _context.Itineraries
                .Include(i => i.City)
                .Include(i => i.ItineraryBlocks)
                    .ThenInclude(b => (b as VisitBlock)!.Attraction)
                .Include(i => i.ItineraryBlocks)
                    .ThenInclude(b => (b as TransportBlock)!.Notes)
                .SingleOrDefault(i => i.Id == id);
        }
        public void Delete(int id)
        {
            Itinerary? itinerary = this.GetById(id);
            if (itinerary is not null) Remove(itinerary);
        }
    }
}
