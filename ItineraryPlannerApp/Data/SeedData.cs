using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Data
{
    public static class SeedData
    {
        public static void Seed(ItineraryDbContext context)
        {
            
            if (!context.Users.Any())
            {
                var passwordService = new PasswordService();

                var user = new User
                {
                    Email = "jihye.lee-2@student.uts.edu.au",
                    DisplayName = "Jihye",
                    PasswordHash = passwordService.HashPassword("1234"),
                    Role = UserRole.User
                };
                context.Users.AddRange(user);
            }

            if (!context.Cities.Any())
            {
                var sydney = new City
                {
                    CityName = "Sydney",
                    Description = "sydney, Aus",
                    ImagePath = "Data/Images/syd-img1.jpg",
                    FlagPath = ""
                };

                context.Cities.Add(sydney);
            }


            try
            {
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException?.Message ?? ex.Message);
            }
        }
    }
}
