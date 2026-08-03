using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;

namespace ItineraryPlannerApp.Data
{
    public class ItineraryPlannerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Attraction> Attractions { get; set; }
        public DbSet<TransitAccess> Accessibilities { get; set; }
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<VisitBlock> VisitBlocks { get; set; }
        public DbSet<TransportBlock> TransportBlocks { get; set; }
        public DbSet<TransportNote> TransportNotes { get; set; }
        public string DbPath { get; }

        public ItineraryPlannerContext(DbContextOptions<ItineraryPlannerContext> options) : base(options)
        {
            var dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null && !dir.GetFiles("*.csproj").Any())
                dir = dir.Parent;
            DbPath = dir != null ? System.IO.Path.Join(dir.FullName, "Itinerary.db") : string.Empty;
        }
        public ItineraryPlannerContext() : this(new DbContextOptionsBuilder<ItineraryPlannerContext>().Options) { }
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
            modelBuilder.Entity<City>().ToTable("Cities");

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
                .WithMany()
                .HasForeignKey(a => a.AttractionId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Itinerary>().ToTable("Itineraries");
            modelBuilder.Entity<Itinerary>()
                .HasMany(i => i.ItineraryBlocks)
                .WithOne(b => b.Itinerary)
                .HasForeignKey(b => b.ItineraryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<VisitBlock>()
                .HasOne(v => v.Attraction)
                .WithMany()
                .HasForeignKey(v => v.AttractionId);

            modelBuilder.Entity<TransportNote>()
                .HasOne(n => n.Block)
                .WithMany()
                .HasForeignKey(n => n.BlockId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
