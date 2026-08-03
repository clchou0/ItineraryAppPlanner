using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace ItineraryPlannerApp.Data
{
    internal class ItineraryPlannerContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<VisitBlock> VisitBlocks { get; set; }
        public DbSet<TransportBlock> TransportBlocks { get; set; }
        public DbSet<TransportNote> TransportNotes { get; set; }
    }
}
