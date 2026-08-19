using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;
using System.Windows.Documents;
using NetTopologySuite.Algorithm;


namespace ItineraryPlannerApp.Data.Services
{
    public class PdfService
    {
        public byte[] GenerateItineraryPdf(Itinerary itinerary)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(40);

                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header().Text("Your Travel Itinerary").FontSize(24).Bold();

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);
                        column.Item().PaddingTop(5).Text($"City: {itinerary.City?.CityName}");
                        column.Item().Text($"Arrival: {itinerary.ArriveDate:dd/MM/yyyy}");
                        column.Item().Text($"Departure: {itinerary.LeaveDate:dd/MM/yyyy}");

                        column.Item().Element(container => ContentDaily(container, itinerary));
                    });

                    page.Footer().AlignCenter().Text("Travel Planner - PDF");
                });
            }).GeneratePdf();
        }

        public void ContentDaily(IContainer container, Itinerary itinerary)
        {
            var blocks = itinerary.ItineraryBlocks.OrderBy(b => b.StartTime).ToList();
            var groupBlocks = blocks.GroupBy(b => b.StartTime.Date).OrderBy(g => g.Key).ToList();

            container.Column(column =>
            {
                column.Spacing(15);

                column.Item().PaddingTop(10).Text("Schedule").FontSize(12).Bold();

                if (blocks.Count == 0)
                {
                    column.Item().PaddingVertical(20).Text("Nothing on the list.");

                    return;
                }

                // daily
                foreach (var dayGroup in groupBlocks)
                {
                    column.Item().PaddingTop(10).Background("#f4c542").Padding(10)
                    .Text(dayGroup.Key.ToString("dddd, dd MMMM yyyy")).FontSize(12).Bold();

                    foreach (var block in dayGroup.OrderBy(b => b.StartTime))
                    {
                        column.Item().Element(c => ComposeBlock(c, block));
                    }
                }

                column.Item().PaddingTop(10).BorderTop(1).BorderColor(Colors.Yellow.Lighten3);
                               
            });
        }

        private void ComposeBlock(IContainer container, ItineraryBlock block)
        {
            container.Border(1).BorderColor(Colors.Grey.Lighten3).Padding(15).Column(column =>
            {
                column.Spacing(5);

                // hourly
                column.Item().Text(block.StartTime.ToString("HH:mm")).FontSize(12).Bold()
                .FontColor(Colors.Grey.Lighten2);

                if (block is TransportBlock transport) 
                {
                    ComposeTransportBlock(column, transport);
                } 
                else if (block is VisitBlock visit)
                {
                    ComposeVisitBlock(column, visit);
                }
            });
        }

        private void ComposeTransportBlock(ColumnDescriptor column, TransportBlock transport)
        {
            column.Item().Text("Transport").FontSize(12).Bold();

            foreach (var note in transport.Notes)
            {
                string routeText = string.IsNullOrWhiteSpace(note.Route) ? note.Method.ToString()
                    : $"{note.Method} -> {note.Route}";

                column.Item().PaddingTop(4).Text(routeText).SemiBold();
                column.Item().Text($"{note.FromStation} -> {note.ToStation}");
            }

            if (transport.TotalDuration > 0)
            {
                column.Item().Text($"Duration: {transport.TotalDuration} min.").FontColor(Colors.Grey.Darken2);
            }
        }

        private void ComposeVisitBlock(ColumnDescriptor column, VisitBlock visit)
        {
            string attractionName = visit.Attraction?.AttractionName ?? "Attraction";
            string description = visit.Note ?? "";
            string entryPrice = visit.Attraction?.EntryPrice ?? "";
            string? imagePath = ImagePath(visit.Attraction?.ImagePath);

            column.Item().Text(attractionName).FontSize(12).Bold();

            if (imagePath != null && File.Exists(imagePath))
            {
                byte[] images = File.ReadAllBytes(imagePath);

                column.Item().PaddingTop(6).Height(140).Image(images).FitArea();
            }

            if (!string.IsNullOrWhiteSpace(visit.Note))
            {
                column.Item().Text(visit.Note).FontColor(Colors.Grey.Darken1);
            }

            if (!string.IsNullOrWhiteSpace(entryPrice))
            {
                column.Item().PaddingTop(6).Text($"Entry Cost: { entryPrice }").FontSize(9);
            }
        }

        private string? ImagePath(string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath)) return null;
            if (Path.IsPathRooted(imagePath)) return File.Exists(imagePath) ? imagePath : null;

            string relativePath = imagePath.Replace("/", Path.DirectorySeparatorChar.ToString())
                .Replace("\\", Path.DirectorySeparatorChar.ToString());

            string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

            return File.Exists(fullPath) ? fullPath : null;
        }

        //private decimal CalculateTotal(Itinerary itinerary)
        //{
        //    decimal total = 0;

        //    foreach (var block in itinerary.ItineraryBlocks)
        //    {
        //        if (block is TransportBlock)
        //        {
        //            total += 3.00m;
        //        }
        //    }
        //    return total;
        //}
    }
}
