using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Data
{
    public class ItineraryDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<City> Cities => Set<City>();
        public DbSet<Attraction> Attractions => Set<Attraction>();

        public DbSet<Itinerary> Itineraries => Set<Itinerary>();
        public DbSet<ItineraryBlock> ItineraryBlocks => Set<ItineraryBlock>();
        public DbSet<VisitBlock> VisitBlocks => Set<VisitBlock>();
        public DbSet<TransportBlock> TransportBlocks => Set<TransportBlock>();
        public DbSet<TransportNote> TransportNotes => Set<TransportNote>();

        //public ItineraryDbContext() : base(CreateOptions()) { }
        //protected static DbContextOptions<ItineraryDbContext> CreateOptions() 
        //{ 
        //    return new DbContextOptionsBuilder<ItineraryDbContext>().UseSqlite("Data Source=itinerary.db").Options;
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=itinerary.db");
        }
    }
}
