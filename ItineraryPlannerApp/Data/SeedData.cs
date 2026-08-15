using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Data.Services;
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
               var users = new List<User>
               {
                    new User
                    {
                        Email = "jihye.lee-2@student.uts.edu.au",
                        DisplayName = "Jihye",
                        PasswordHash = PasswordService.HashPassword("1234"),
                        Role = UserRole.User
                    },
                    new User
                    {
                        Email = "a@b.",
                        DisplayName = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAdmin",
                        PasswordHash = PasswordService.HashPassword("111111"),
                        Role = UserRole.Admin
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
                        Country = "Australia",
                        Slider = new MapSlider()
                    },

                    new City
                    {
                        CityName = "Seoul",
                        Description = "Seoul, South Korea",
                        ImagePath = "Data/Images/seo-img1.jpg",
                        Country = "Korea",
                        Slider = new MapSlider()
                    },
                    new City
                    {
                        CityName = "Shanghai",
                        Description = "Shanghai, China",
                        ImagePath = "Data/Images/sha-img1.jpg",
                        Country = "China",
                        Slider = new MapSlider()
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
