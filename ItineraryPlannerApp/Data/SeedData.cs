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

                var users = new List<User>
                    {
                    new User
                    {
                        Email = "jihye.lee-2@student.uts.edu.au",
                        DisplayName = "Jihye",
                        PasswordHash = passwordService.HashPassword("1234"),
                        Role = UserRole.User
                    }
                };
                context.Users.AddRange(users);
            }

            if (!context.Cities.Any())
            {
                var cities = new List<City>
                {
                    new City
                    {
                        CityName = "Sydney",
                        Description = "Sydney, NSW, Australia",
                        ImagePath = "Data/Images/syd-img1.jpg",
                        FlagPath = ""
                    },

                    new City
                    {
                        CityName = "Seoul",
                        Description = "Seoul, South Korea",
                        ImagePath = "Data/Images/seo-img1.jpg",
                        FlagPath = ""
                    },
                    new City
                    {
                        CityName = "Shanghai",
                        Description = "Shanghai, China",
                        ImagePath = "Data/Images/sha-img1.jpg",
                        FlagPath = ""
                    }
                };

                context.Cities.AddRange(cities);
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
