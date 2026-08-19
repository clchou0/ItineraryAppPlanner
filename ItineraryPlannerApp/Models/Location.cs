using Mapsui;
using Mapsui.Projections;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public class Location
    {
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;

        public Location() { }

        public Location(double latitude, double longitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public MPoint LatLngMPoint()
        {
            var (x, y) = SphericalMercator.FromLonLat(Longitude, Latitude);
            return new MPoint(x, y);
        }
    }
}
