using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.VisualBasic.ApplicationServices;
using Planner.WPF;
using System;
using System.Collections.Generic;
using System.Text;
using User = ItineraryPlannerApp.Models.User;

namespace ItineraryPlannerApp.Forms.ItineraryForm
{
    public class ItineraryPlannerLauncher
    {
        private readonly ItineraryPlannerService _service;
        private readonly EmailService _emailService;
        private readonly PdfService _pdfService;

        public ItineraryPlannerLauncher(ItineraryPlannerService service, EmailService emailService, PdfService pdfService)
        {
            _service = service;
            _emailService = emailService;
            _pdfService = pdfService;
        }

        public void SpawnItineraryPlanner(User user)
        {
            var dbItineraries = _service.GetItinerariesByUserId(user.Id).Where(i => i.Status == ItineraryStatus.Draft);

            var itineraries = ConvertItineraries(dbItineraries);

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

            var window = new ItineraryBuilder(user.Id, itineraries, cities, routes, 
                SaveItinerary, id => CompleteItinerary(id, user.Id), id => DeleteItinerary(id, user.Id));

            window.ShowDialog();
        }

        public void SpawnMyItineraries(User user)
        {
            var completed = _service.GetCompletedItineraries(user.Id);

            var completedItems = ConvertItineraries(completed);
            
            var window = new myItineraries(completedItems, id => DraftItinerary(id, user.Id), 
                id => DeleteItinerary(id, user.Id), id => ExportItineraryPdf(id, user));

            window.ShowDialog();
        }

        private ItineraryBlockItem ConvertBlock(int itineraryId, ItineraryBlock block)
        {
            if (block is TransportBlock transport)
            {
                var segments = transport.Notes.Select(note => new TransportSegmentItem
                {
                    Method = note.Method.ToString(),
                    Route = note.Route,
                    FromStation =note.FromStation,
                    ToStation = note.ToStation
                }).ToList();

                return new ItineraryBlockItem
                {
                    Id = block.Id,
                    ItineraryId = itineraryId,

                    Type = "Transport",
                    Title = "Transport",
                    Description = string.Join(
                        " | ", segments.Select(s => $"{s.Method}: {s.FromStation} -> {s.ToStation}")),
                    StartTime = block.StartTime,
                    Duration = transport.TotalDuration,

                    Cost = 3.00m,
                    Segments = segments
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
                    StartTime = block.StartTime
                };
            }

            return new ItineraryBlockItem
            {
                Id = block.Id,
                ItineraryId = itineraryId,
                StartTime = block.StartTime
            };
        }

        private List<ItineraryList> ConvertItineraries(IEnumerable<Itinerary> dbitineraries)
        {
            return dbitineraries.Select(i => new ItineraryList
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
        }

        private int SaveItinerary(ItineraryEditData data)
        {
            var test = data.Blocks.Where(b => b.Type == "Transport").ToList();

            string tt = string.Join("\n", test.Select(t => $"{t.Id}, {t.Segments.Count()}"));
            MessageBox.Show(string.IsNullOrEmpty(tt) ? "No transport blocks received." : tt);

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
                    TotalEntryPrice = 0,
                    Status = ItineraryStatus.Draft
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
                if (blockItem.Id == 0)
                {
                    AddBlock(existing, blockItem);
                }
                else
                {
                    UpdateExistingBlock(existing, blockItem);
                }


            } 
            _service.UpdateItinerary(existing);

            return existing.Id;
        }

        private void UpdateExistingBlock(Itinerary itinerary, ItineraryBlockItem blockItem)
        {
            var existingBlock = itinerary.ItineraryBlocks.FirstOrDefault(b => b.Id == blockItem.Id);

            if (existingBlock == null) return;

            // ATTRACTION
            if (existingBlock is VisitBlock visit && blockItem.Type == "Attraction")
            {
                visit.StartTime = blockItem.StartTime;
                return;
            }

            // TRANSPORT
            if (existingBlock is TransportBlock transport && blockItem.Type == "Transport")
            {
                transport.StartTime = blockItem.StartTime;
                transport.TotalDuration = blockItem.Duration;

                transport.Notes.Clear();

                foreach (var segment in blockItem.Segments)
                {
                    if (!Enum.TryParse<TransportType>(segment.Method, true, out var method)) continue;

                    transport.Notes.Add(new TransportNote
                    {
                        Method = method,
                        Route = segment.Route ?? "",
                        FromStation = segment.FromStation ?? "",
                        ToStation = segment.ToStation ?? ""
                    });
                }
            }
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

                foreach (var segment in blockItem.Segments) 
                {
                    if (!Enum.TryParse<TransportType>(segment.Method, true, out var method))
                    {
                        MessageBox.Show($"Invalid type. {segment.Method}");
                        return;
                    }
                    transportBlock.Notes.Add(new TransportNote
                    {
                        Method = method,
                        Route = segment.Route ?? "",
                        FromStation = segment.FromStation ?? "",
                        ToStation = segment.ToStation ?? ""
                    });
                };

                itinerary.ItineraryBlocks.Add(transportBlock);
            
            }
        }

        private void DeleteItinerary(int itineraryId, int userId)
        {
            _service.DeleteItinerary(itineraryId, userId);
        }

        private void CompleteItinerary(int itineraryId, int userId)
        {
            _service.CompleteItinerary(itineraryId, userId);
        }

        private bool DraftItinerary(int itineraryId, int userId)
        {
            return _service.DraftItinerary(itineraryId, userId);
        }

        private async Task ExportItineraryPdf(int itineraryId, User user)
        {
            var itinerary = _service.GetItineraryById(itineraryId, user.Id);

            if (itinerary == null)
            {
                throw new Exception("Itinerary not found.");
            }

            byte[] pdfBytes = _pdfService.GenerateItineraryPdf(itinerary);

            await _emailService.SendPdfAsync(user.Email, user.DisplayName, itinerary, pdfBytes);
        }
    }
}
