using ItineraryPlannerApp.Data;
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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            using var context = new ItineraryDbContext();

            context.Database.EnsureCreated();
            SeedData.Seed(context);

            Application.Run(new MainForm());
        }
    }
}