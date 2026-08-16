using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Planner.WPF;
using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Forms.ItineraryForm
{
    public class ItineraryPlannerLauncher
    {
        private readonly ItineraryPlannerService _service;

        public ItineraryPlannerLauncher(ItineraryPlannerService service)
        {
            _service = service;
        }

        public void SpawnItineraryPlanner(User user)
        {
            var dbItineraries = _service.GetItinerariesByUserId(user.Id);

            var itineraries = dbItineraries.Select(i => new ItineraryList
            {
                Id = i.Id,
                UserId = i.UserId,
                CityName = i.City.CityName,
                ArriveDate = i.ArriveDate,
                LeaveDate = i.LeaveDate,
                TotalPrice = i.TotalEntryPrice,

                Blocks = i.ItineraryBlocks.Select(b => ConvertBlock(i.Id, b))
                .OrderBy(b => b.StartTime).ToList()

            }).ToList();

            var cities = _service.GetAllCities().Select(c => c.CityName).ToList();

            var routes = _service.GetAllTransitRoutes()
                .Select(r => new TransitRouteItem
                {
                    Id = r.Id,
                    CityName = r.CityName,
                    RouteName = r.RouteName,
                    Type = r.Type.ToString(),

                    Stops = r.Stops.OrderBy(s => s.StopOrder).Select(s => new TransitStopItem
                    {
                        Id = s.Id,
                        StopName = s.StopName,
                        StopOrder = s.StopOrder
                    }).ToList()
                }).ToList();

            var window = new ItineraryBuilder(user.Id, itineraries, cities, routes, SaveItinerary, id => DeleteItinerary(id, user.Id));

            window.ShowDialog();
        }

        private ItineraryBlockItem ConvertBlock(int itineraryId, ItineraryBlock block)
        {
            if (block is TransportBlock transport)
            {
                var note = transport.Notes.FirstOrDefault();

                return new ItineraryBlockItem
                {
                    Id = block.Id,
                    ItineraryId = itineraryId,

                    Type = "Transport",

                    TransportMethod = note?.Method.ToString() ?? "",
                    Route = note?.Route ?? "",
                    FromStation = note?.FromStation ?? "",
                    ToStation = note?.ToStation ?? "",
                    Title = $"{note?.Route} {note?.Method}",
                    Description = $"{note?.FromStation} -> {note?.ToStation}",
                    StartTime = block.StartTime,
                    Duration = transport.TotalDuration,

                    Cost = 3.00m
                };
            }

            if (block is VisitBlock visit)
            {
                return new ItineraryBlockItem
                {
                    Id = block.Id,
                    ItineraryId = itineraryId,

                    Type = "Attraction",

                    AttractionId = visit.AttractionId,
                    Title = "Attraction",
                    Description = visit.Note ?? "",
                    StartTime = block.StartTime,
                    Cost = 0
                };
            }

            return new ItineraryBlockItem
            {
                Id = block.Id,
                ItineraryId = itineraryId,
                StartTime = block.StartTime
            };
        }

        private int SaveItinerary(ItineraryEditData data)
        {
            var city = _service.GetCityByName(data.CityName ?? "");

            if (city == null)
            {
                MessageBox.Show($"City not found {data.CityName}");

                return 0;
            }

            if (data.ItineraryId == null)
            {
                var itinerary = new Itinerary
                {
                    UserId = data.UserId,
                    CityId = city.Id,
                    ArriveDate = data.ArriveDate,
                    LeaveDate = data.LeaveDate,
                    TotalEntryPrice = 0
                };

                foreach (var blockItem in data.Blocks)
                {

                    AddBlock(itinerary, blockItem);
                }

                _service.AddItinerary(itinerary);

                MessageBox.Show($"Saved Successfully.\n {itinerary.Id}");

                return itinerary.Id;
            }

            var existing = _service.GetItineraryById(data.ItineraryId.Value, data.UserId);

            if (existing == null)
            {
                MessageBox.Show("Itinerary not found.");
                return 0;
            }

            existing.ArriveDate = data.ArriveDate;
            existing.LeaveDate = data.LeaveDate;

            var blockIds = data.Blocks.Where(b => b.Id != 0).Select(b => b.Id).ToList();

            var deletedBlocks = existing.ItineraryBlocks.Where(b => !blockIds.Contains(b.Id)).ToList();

            if (deletedBlocks.Count > 0) 
            {
                _service.RemoveItineraryBlocks(deletedBlocks);
            }

            foreach (var blockItem in data.Blocks)
            {
                if (blockItem.Id != 0) continue;

                AddBlock(existing, blockItem);
            }
            _service.UpdateItinerary(existing);

            return existing.Id;
        }

        private void AddBlock(Itinerary itinerary, ItineraryBlockItem blockItem)
        {
            if (blockItem.Type == "Attraction")
            {
                if (blockItem.AttractionId == null) return;

                var visitBlock = new VisitBlock
                {
                    StartTime = blockItem.StartTime,
                    AttractionId = blockItem.AttractionId!.Value,
                    Note = blockItem.Description
                };
                itinerary.ItineraryBlocks.Add(visitBlock);
                return;
            }

            if (blockItem.Type == "Transport")
            {
                var transportBlock = new TransportBlock
                {
                    StartTime = blockItem.StartTime,
                    TotalDuration = blockItem.Duration
                };

                if (Enum.TryParse<TransportType>(blockItem.TransportMethod, out var transportType))
                {
                    transportBlock.Notes.Add(new TransportNote
                    {
                        Method = transportType,
                        Route = blockItem.Route,
                        FromStation = blockItem.FromStation,
                        ToStation = blockItem.ToStation
                    });
                }
                itinerary.ItineraryBlocks.Add(transportBlock);
            }
        }

        private void DeleteItinerary(int itineraryId, int userId)
        {
            _service.DeleteItinerary(itineraryId, userId);
        }
    }
}
