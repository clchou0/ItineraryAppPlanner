using ItineraryPlannerApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;

namespace ItineraryPlannerApp.Data.Services
{
    public class ItineraryPlannerService
    {
        private readonly UserRepository _userRepository;
        private readonly CityRepository _cityRepository;
        private readonly AttractionRepository _attractionRepository;
        private readonly ItineraryRepository _itineraryRepository;
        private readonly TransitRouteRepository _transitRouteRepository;

        public ItineraryPlannerService(UserRepository userRepository, CityRepository cityRepository, AttractionRepository attractionRepository, ItineraryRepository itineraryRepository, TransitRouteRepository transitRouteRepository)
        {
            _userRepository = userRepository;
            _cityRepository = cityRepository;
            _attractionRepository = attractionRepository;
            _itineraryRepository = itineraryRepository;
            _transitRouteRepository = transitRouteRepository;
        }

        // USER
        public User? GetUserByEmail(string email)
        {
            return _userRepository.GetAll().Where(u => u.Email == email).FirstOrDefault();
        }
        public User GetUserById(int id)
        {
            return _userRepository.GetById(id);
        }
        public void AddUser(User user)
        {
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        // CITY
        public City? GetCityById(int id)
        {
            return _cityRepository.GetById(id);
        }
        public IEnumerable<City> GetAllCities()
        {
            return _cityRepository.GetAll();
        }
        public City? GetCityByName(string cityName)
        {
            return _cityRepository.GetAll().FirstOrDefault(c => c.CityName == cityName);
        }
        public bool AddCity(City city)
        {
            if (_cityRepository.GetAll().Any(c => c.CityName.ToLower() == city.CityName.ToLower()))
            {
                return false;
            }
            _cityRepository.Add(city);
            return true;
        }
        public bool UpdateCity(City city)
        {
            // Duplicate name
            if (_cityRepository.GetAll().Any(c => c.CityName.ToLower() == city.CityName.ToLower()
                && c.Id != city.Id))
            {
                return false;
            }
            _cityRepository.Update(city);
            return true;
        }
        public void RemoveCity(City city)
        {
            _cityRepository.Remove(city);
        }

        // ATTRACTION
        public List<Attraction> GetAttractionByCity(int cityId)
        {
            return _attractionRepository.GetAll().Where(a => a.CityId == cityId).ToList();
        }

        // ITINERARY
        public void AddItinerary(Itinerary itinerary)
        {
            _itineraryRepository.Add(itinerary);
        }

        public void UpdateItinerary(Itinerary itinerary)
        {
            _itineraryRepository.Update(itinerary);
        }

        public List<Itinerary> GetItinerariesByUserId(int userId)
        {
            return _itineraryRepository.GetByUserId(userId);
        }

        public Itinerary? GetItineraryById(int id,  int userId)
        {
            var itinerary = _itineraryRepository.GetById(id);

            if (itinerary == null || itinerary.UserId != userId)
            {
                return null;
            }
            return itinerary;
        }

        public void RemoveItineraryBlocks(IEnumerable<ItineraryBlock> blocks)
        {
            _itineraryRepository.RemoveBlocks(blocks);
        }

        public void DeleteItinerary(int itineraryId, int userId)
        {
            var itinerary = _itineraryRepository.GetById(itineraryId);

            if (itinerary == null || itinerary.UserId != userId) return;

            _itineraryRepository.Delete(itineraryId);  
        }

        // TRANSPORT
        public List<TransitRoute> GetTransitRoutes(string cityName)
        {
            return _transitRouteRepository.GetByCity(cityName);
        }

        public TransitRoute? GetTransitRouteById(int routeId)
        {
            return _transitRouteRepository.GetByIdWithStops(routeId);
        }

        public List<TransitRoute> GetAllTransitRoutes()
        {
            return _transitRouteRepository.GetAllWithStops();
        }
    }
}
