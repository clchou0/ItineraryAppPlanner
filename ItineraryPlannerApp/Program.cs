using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Repositories;
using ItineraryPlannerApp.Forms.CityForm;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Forms;

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
                .AddDbContext<ItineraryDbContext>()
                .AddScoped<UserRepository>()
                .AddScoped<CityRepository>()
                .AddScoped<AttractionRepository>()
                .AddScoped<ItineraryPlannerService>();

            var provider = services.BuildServiceProvider();
            var itineraryService = provider.GetRequiredService<ItineraryPlannerService>();
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ItineraryDbContext>();
                context.Database.Migrate();
                SeedData.Seed(context);
            }
            Application.Run(new MainForm(itineraryService));
        }
    }
}