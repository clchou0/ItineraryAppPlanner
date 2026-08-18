using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Repositories;
using ItineraryPlannerApp.Forms.CityForm;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Forms;
using ItineraryPlannerApp.Forms.ItineraryForm;

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
                .AddScoped<ItineraryRepository>()
                .AddScoped<TransitRouteRepository>()
                .AddScoped<ItineraryPlannerService>()
                .AddScoped<ItineraryPlannerLauncher>()
                .AddScoped<EmailService>()
                .AddScoped<PdfService>();

            var provider = services.BuildServiceProvider();
            var itineraryService = provider.GetRequiredService<ItineraryPlannerService>();
            var emailService = provider.GetRequiredService<EmailService>();
            var pdfService = provider.GetRequiredService<PdfService>();
            using (var scope = provider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ItineraryDbContext>();
                context.Database.Migrate();
                SeedData.Seed(context);
            }

            Application.Run(new MainForm(itineraryService, emailService, pdfService));
        }
    }
}