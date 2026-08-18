using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Repositories;
using ItineraryPlannerApp.Forms.CityForm;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Forms;
using Microsoft.Extensions.Logging;

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
                .AddDbContext<ItineraryDbContext>(options =>
                    options.UseSqlite("Data Source=itinerary.db")
                           .EnableSensitiveDataLogging()
                           .LogTo(Console.WriteLine, LogLevel.Information))
                .AddScoped<UserRepository>()
                .AddScoped<CityRepository>()
                .AddScoped<AttractionRepository>()
                .AddScoped<ItineraryRepository>()
                .AddScoped<ItineraryPlannerService>()
                .AddScoped<TransitRouteRepository>()
                .AddSingleton(new EmailService("leejihye2002@gmail.com", "qxdnyodzajridspp"));

            var provider = services.BuildServiceProvider();
            var itineraryService = provider.GetRequiredService<ItineraryPlannerService>();
            var emailService = provider.GetRequiredService<EmailService>();
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ItineraryDbContext>();
                context.Database.Migrate();
                SeedData.Seed(context);
            }
            Application.Run(new MainForm(itineraryService, emailService));
        }
    }
}