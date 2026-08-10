using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Repositories;
using ItineraryPlannerApp.Forms.CityForm;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ItineraryPlannerApp.Data.Services;

namespace ItineraryPlannerApp
{
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection()
                .AddDbContext<ItineraryDbContext>(options => options.UseSqlite("Data Source=itinerary.db")) // or your provider
                .AddScoped<CityRepository>()
                .AddScoped<AttractionRepository>()
                .AddScoped<ItineraryPlannerService>();

            var provider = services.BuildServiceProvider();
            var itineraryService = provider.GetRequiredService<ItineraryPlannerService>();
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ItineraryDbContext>();
                context.Database.Migrate();
            }
            Application.Run(new CityDetailsEditor(itineraryService, null));
        }
    }
}