using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Data.Services;

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
                        },
                        new Attraction
                        {
                            AttractionName = "St Mary's Cathedral",
                            ImagePath = "images/attractions/st_marys_cathedral.jpg",

                            Location = new Location
                            {
                                Latitude = -33.8722,
                                Longitude = 151.2136
                            },

                            Description =
                                "A soaring example of English-style Gothic Revival architecture, St " +
                                "Mary's Cathedral has stood on this site since the earliest days of the " +
                                "colony and serves as the spiritual home of the Catholic Archdiocese of " +
                                "Sydney. Its twin spires and richly detailed stonework dominate the " +
                                "eastern edge of Hyde Park, and the crypt beneath houses one of the " +
                                "world's largest collections of terrazzo mosaic floors.",

                            ShortDesctiption =
                                "Gothic Revival cathedral overlooking Hyde Park.",

                            Area = "Sydney CBD",

                            EntryPrice =
                                "Free entry; crypt tour donations welcome",

                            Category = AttractionCategory.Landmark,

                            CloseStations = new List<TransitAccess>
                            {
                                new TransitAccess
                                {
                                    Type = TransportType.Train,
                                    StationName = "St James Station",
                                    MinuteWalk = 5
                                },
                                new TransitAccess
                                {
                                    Type = TransportType.Train,
                                    StationName = "Museum Station",
                                    MinuteWalk = 6
                                },
                                new TransitAccess
                                {
                                    Type = TransportType.Bus,
                                    StationName = "College Street Bus Stop",
                                    MinuteWalk = 3
                                }
                            },

                            City = sydney,
                            CityId = sydney.Id
                        },
                        new Attraction
                        {
                            AttractionName = "Sydney Fish Market",
                            ImagePath = "images/attractions/sydney_fish_market.jpg",

                            Location = new Location
                            {
                                Latitude = -33.8688,
                                Longitude = 151.1943
                            },

                            Description =
                                "One of the largest seafood markets in the Southern Hemisphere, the " +
                                "Sydney Fish Market is a working harbourside market where auctioneers, " +
                                "fishmongers, and sushi bars operate side by side. Visitors can watch " +
                                "the early-morning Dutch auction, pick up fresh seafood, or grab lunch " +
                                "at one of the many casual eateries overlooking Blackwattle Bay.",

                            ShortDesctiption =
                                "Bustling harbourside seafood market and eatery hub.",

                            Area = "Pyrmont",

                            EntryPrice =
                                "Free entry; seafood and meals priced individually",

                            Category = AttractionCategory.Landmark,

                            CloseStations = new List<TransitAccess>
                            {
                                new TransitAccess
                                {
                                    Type = TransportType.LightRail,
                                    StationName = "Fish Market Station",
                                    MinuteWalk = 2
                                },
                                new TransitAccess
                                {
                                    Type = TransportType.Bus,
                                    StationName = "Pyrmont Bridge Road Bus Stop",
                                    MinuteWalk = 5
                                }
                            },

                            City = sydney,
                            CityId = sydney.Id
                        },
                        new Attraction
                        {
                            AttractionName = "Three Sisters",
                            ImagePath = "images/attractions/three_sisters.jpg",

                            Location = new Location
                            {
                                Latitude = -33.7333,
                                Longitude = 150.3117
                            },

                            Description =
                                "Rising from the cliffs of the Jamison Valley, the Three Sisters are " +
                                "an iconic rock formation shaped by millions of years of erosion and " +
                                "steeped in Dreamtime significance for the local Gundungurra people. " +
                                "The Echo Point lookout offers sweeping views across the Blue " +
                                "Mountains, and nearby trails lead down into the valley via the " +
                                "Giant Stairway for a closer look at the formation.",

                            ShortDesctiption =
                                "Iconic sandstone rock formation in the Blue Mountains.",

                            Area = "Katoomba, Blue Mountains",

                            EntryPrice =
                                "Free entry to Echo Point lookout",

                            Category = AttractionCategory.Landmark,

                            CloseStations = new List<TransitAccess>
                            {
                                new TransitAccess
                                {
                                    Type = TransportType.Train,
                                    StationName = "Katoomba Station",
                                    MinuteWalk = 25
                                },
                                new TransitAccess
                                {
                                    Type = TransportType.Bus,
                                    StationName = "Echo Point Bus Stop",
                                    MinuteWalk = 2
                                }
                            },

                            City = sydney,
                            CityId = sydney.Id
                        },
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