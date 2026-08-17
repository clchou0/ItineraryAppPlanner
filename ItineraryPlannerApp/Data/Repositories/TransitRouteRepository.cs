
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Data.Repositories
{
    public class TransitRouteRepository : Repository<TransitRoute>
    {
        public TransitRouteRepository(ItineraryDbContext context) : base(context)
        {
        }

        public List<TransitRoute> GetByCity(string cityName)
        {
            return _context.TransitRoutes
                .Include(r => r.Stops).Where(r => r.CityName == cityName).ToList();

            //foreach (var route in routes)
            //{
            //    route.Stops = route.Stops.OrderBy(s => s.StopOrder).ToList();
            //}
            //return routes;
        }

        public TransitRoute? GetByIdWithStops(int routeId)
        {
            return _context.TransitRoutes.Include(r => r.Stops).FirstOrDefault(r => r.Id == routeId);
        }
        
        public List<TransitRoute> GetAllWithStops()
        {
            return _context.TransitRoutes.Include(r => r.Stops).ToList();
        }
    }
}
