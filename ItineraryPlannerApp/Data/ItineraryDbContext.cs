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
        public DbSet<TransitRoute> TransitRoutes => Set<TransitRoute>();
        public DbSet<TransitStop> TransitStops => Set<TransitStop>();
        public string DbPath { get; }

        public ItineraryDbContext(DbContextOptions<ItineraryDbContext> options) : base(options)
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && !dir.GetFiles("*.csproj").Any())
                dir = dir.Parent;
            DbPath = dir != null ? System.IO.Path.Join(dir.FullName, "Itinerary.db") : string.Empty;
        }
        public ItineraryDbContext() : this(new DbContextOptionsBuilder<ItineraryDbContext>().Options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Only fall back to SQLite if no provider has already been configured —
            // e.g. by the options-based constructor used in tests (InMemory provider).
            // Without this check, both providers get registered and EF Core throws at runtime.
            if (!optionsBuilder.IsConfigured)
            {
                object value = optionsBuilder.UseSqlite($"Data Source={DbPath}");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<City>().ToTable("Cities")
                .OwnsOne(c => c.Slider);

            modelBuilder.Entity<Attraction>()
                .HasOne(a => a.City)
                .WithMany()
                .HasForeignKey(a => a.CityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Attraction>()
                .OwnsOne(a => a.Location);

            modelBuilder.Entity<AttractionLabel>()
                .HasKey(l => new { l.AttractionId, l.Category });

            modelBuilder.Entity<AttractionLabel>()
                .HasOne(l => l.Attraction)
                .WithMany()
                .HasForeignKey(l => l.AttractionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransitAccess>()
                .HasOne(a => a.Attraction)
                .WithMany(a => a.CloseStations)
                .HasForeignKey(a => a.AttractionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Itinerary>().ToTable("Itineraries");
            modelBuilder.Entity<Itinerary>()
                .HasMany(i => i.ItineraryBlocks)
                .WithOne(b => b.Itinerary)
                .HasForeignKey(b => b.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TransportBlock>().ToTable("TransportBlocks");
            
            modelBuilder.Entity<VisitBlock>().ToTable("VisitBlocks");
            modelBuilder.Entity<VisitBlock>()
                .HasOne(v => v.Attraction)
                .WithMany()
                .HasForeignKey(v => v.AttractionId);

            modelBuilder.Entity<TransportNote>().ToTable("TransportNotes");
            modelBuilder.Entity<TransportNote>()
                .HasOne(n => n.Block)
                .WithMany(b => b.Notes)
                .HasForeignKey(n => n.BlockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
