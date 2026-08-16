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

        public List<Itinerary> GetByUserId(int userId)
        {
            var itineraries = _context.Itineraries
                .Include(i => i.City).Include(i => i.ItineraryBlocks)
                .Where(i => i.UserId == userId).ToList();

            var itineraryIds = itineraries.Select(i => i.Id).ToList();

            _context.TransportBlocks.Include(t => t.Notes).Where(t => itineraryIds.Contains(t.ItineraryId)).Load();

            return itineraries;
        }
        public List<Itinerary> GetDraftById(int id)
        {
            return _context.Itineraries
                .Include(i => i.ItineraryBlocks)
                .Where(i => i.Id == id && i.Status == ItineraryStatus.Draft)
                .OrderByDescending(i => i.ArriveDate).ToList();
        }

        public void RemoveBlocks(IEnumerable<ItineraryBlock> blocks)
        {
            _context.ItineraryBlocks.RemoveRange(blocks);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Itinerary? itinerary = this.GetById(id);
            if (itinerary is not null) Remove(itinerary);
        }
    }
}
