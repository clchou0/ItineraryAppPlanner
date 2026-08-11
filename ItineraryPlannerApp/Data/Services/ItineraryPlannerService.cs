using ItineraryPlannerApp.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Data.Services
{
    public class ItineraryPlannerService
    {
        private readonly CityRepository _cityRepository;
        private readonly AttractionRepository _attractionRepository;

        public ItineraryPlannerService(CityRepository cityRepository, AttractionRepository attractionRepository)
        {
            _cityRepository = cityRepository;
            _attractionRepository = attractionRepository;
        }

        // USER


        // CITY
        public City? GetCityById(int id)
        {
            return _cityRepository.GetById(id);
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
    }
}
