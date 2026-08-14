using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Data.Services;
using System;
using System.Collections.Generic;
using System.Text;
using ItineraryPlannerApp.Models.Itinerary;

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
                        Country = "Australia"
                    },

                    new City
                    {
                        CityName = "Seoul",
                        Description = "Seoul, South Korea",
                        ImagePath = "Data/Images/seo-img1.jpg",
                        Country = "Korea"
                    },
                    new City
                    {
                        CityName = "Shanghai",
                        Description = "Shanghai, China",
                        ImagePath = "Data/Images/sha-img1.jpg",
                        Country = "China"
                    }
                };

                context.Cities.AddRange(cities);
            }

            var transportBlocks = new List<TransportBlock>
            {
                new TransportBlock
                {
                    StartTime = new DateTime(2026, 8, 20, 9, 30, 0),
                    TotalDuration = 20,
                    Notes = new List<TransportNote>
                    {
                        new TransportNote
                        {
                            Method = TransportType.Train,
                            Route = "T2",
                            FromStation = "Central",
                            ToStation = "Circular Quay"
                        }
                    }
                },

                new TransportBlock
                {
                    StartTime = new DateTime(2026, 8, 20, 13, 30, 0),
                    TotalDuration = 15,
                    Notes = new List<TransportNote>
                    {
                        new TransportNote
                        {
                            Method = TransportType.LightRail,
                            Route = "L1",
                            FromStation = "Fish Market",
                            ToStation = "Central"
                        }
                    }
                },

                new TransportBlock
                {
                    StartTime = new DateTime(2026, 8, 21, 7, 0, 0),
                    TotalDuration = 10,
                    Notes = new List<TransportNote>
                    {
                        new TransportNote
                        {
                            Method = TransportType.Metro,
                            Route = "M1",
                            FromStation = "Central",
                            ToStation = "Martin Place"
                        }
                    }
                },

                new TransportBlock
                {
                    StartTime = new DateTime(2026, 8, 21, 18, 30, 0),
                    TotalDuration = 40,
                    Notes = new List<TransportNote>
                    {
                        new TransportNote
                        {
                            Method = TransportType.Train,
                            Route = "T4",
                            FromStation = "Town Hall",
                            ToStation = "Bondi Junction"
                        },

                        new TransportNote
                        {
                            Method = TransportType.Bus,
                            Route = "379",
                            FromStation = "Bondi Junction",
                            ToStation = "Bondi Beach"
                        }
                    }
                },

                new TransportBlock
                {
                    StartTime = new DateTime(2026, 8, 21, 10, 30, 0),
                    TotalDuration = 40,
                    Notes = new List<TransportNote>
                    {
                        new TransportNote
                        {
                            Method = TransportType.LightRail,
                            Route = "L1",
                            FromStation = "Fish Market",
                            ToStation = "Central"
                        },

                        new TransportNote
                        {
                            Method = TransportType.Train,
                            Route = "T2",
                            FromStation = "Central",
                            ToStation = "Circular Quay"
                        }
                    }
                }
            };

            if (!context.TransitRoutes.Any())
            {
                var l3 = new TransitRoute
                {
                    Type = TransportType.LightRail,
                    RouteName = "L3",
                    CityName = "Sydney",

                    Stops = new List<TransitStop>
                    {
                        new TransitStop
                        {
                            StopName = "Circular Quay",
                            StopOrder = 1
                        },
                        new TransitStop
                        {
                            StopName = "Bridge Street",
                            StopOrder = 2
                        },
                        new TransitStop
                        {
                            StopName = "Wynyard",
                            StopOrder = 3
                        },
                        new TransitStop
                        {
                            StopName = "QVB",
                            StopOrder = 4
                        },
                        new TransitStop
                        {
                            StopName = "Town Hall",
                            StopOrder = 5
                        },
                        new TransitStop
                        {
                            StopName = "Chinatown",
                            StopOrder = 6
                        },
                        new TransitStop
                        {
                            StopName = "Haymarket",
                            StopOrder = 7
                        },
                        new TransitStop
                        {
                            StopName = "Central Station",
                            StopOrder = 8
                        },
                        new TransitStop
                        {
                            StopName = "Surry Hills",
                            StopOrder = 9
                        }

                    }
                };

                context.TransitRoutes.Add(l3);
                context.SaveChanges();
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
