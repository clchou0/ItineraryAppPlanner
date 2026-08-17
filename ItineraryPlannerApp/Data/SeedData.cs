using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Data
{
    public static class SeedData
    {
        public static void Seed(ItineraryDbContext context)
        {
            try
            {
                // --- Users ---
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
                            DisplayName = "Admin",
                            PasswordHash = PasswordService.HashPassword("111111"),
                            Role = UserRole.Admin
                        }
                    };

                    context.Users.AddRange(users);
                    context.SaveChanges();
                }

                // --- Cities ---
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
                            Slider = new MapSlider(
                                151.877940271153,
                                -32.8606138422146,
                                149.813655361048,
                                -34.7385257910314,
                                150.785905011104,
                                -33.7946395144834
                            )
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
                    context.SaveChanges();
                }

                // Always re-fetch from the DB
                var sydney = context.Cities
                    .FirstOrDefault(c => c.CityName == "Sydney");
                // --- Attractions ---
                if (sydney is not null && !context.Attractions.Any())
                {
                    var attractions = new List<Attraction>
                    {
                        new Attraction
                        {
                            AttractionName = "Sydney Opera House",
                            ImagePath = "images/attractions/sydney_opera_house.jpg",

                            Location = new Location
                            {
                                Latitude = -33.8568,
                                Longitude = 151.2153
                            },

                            Description =
                                "An architectural icon of the 20th century, the Sydney Opera House " +
                                "sits on Bennelong Point overlooking Sydney Harbour. Its sail-shaped " +
                                "shells house multiple performance venues hosting opera, ballet, theatre, " +
                                "and concerts throughout the year, and the surrounding forecourt and " +
                                "steps are a popular gathering spot with sweeping harbour views.",

                            ShortDesctiption =
                                "Iconic performing arts venue on Sydney Harbour.",

                            Area = "Sydney CBD",

                            EntryPrice =
                                "Free to visit grounds; guided tours from $43",

                            Category = AttractionCategory.Landmark,

                            CloseStations = new List<TransitAccess>
                            {
                                new TransitAccess
                                {
                                    Type = TransportType.Train,
                                    StationName = "Circular Quay Station",
                                    MinuteWalk = 8
                                },
                                new TransitAccess
                                {
                                    Type = TransportType.Ferry,
                                    StationName = "Circular Quay Wharf",
                                    MinuteWalk = 6
                                },
                                new TransitAccess
                                {
                                    Type = TransportType.Bus,
                                    StationName = "Circular Quay Bus Stop",
                                    MinuteWalk = 7
                                }
                            },
                            
                            City = sydney,
                            CityId = sydney.Id
                        }
                    };

                    context.Attractions.AddRange(attractions);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.InnerException?.Message ?? ex.Message,
                    "Database Error"
                );
            }
        }
    }
}