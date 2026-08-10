//using ItineraryPlannerApp.Data;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace ItineraryPlannerApp.Services
//{
//    public class CityService
//    {
//        private readonly ItineraryDbContext _context;

//        public CityService(ItineraryDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<City?> GetCityByNameAsync(string cityName)
//        {
//            return await _context.Cities.FirstOrDefaultAsync(c => c.CityName == cityName);
//        }

//        public async Task<List<City>> GetAllCitiesAsync()
//        {
//            return
//        }
//    }
//}
