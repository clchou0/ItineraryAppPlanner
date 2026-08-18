using System;
using System.Collections.Generic;
using System.Text;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;
using System.Windows.Documents;


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
                    column.Item().PaddingTop(10).Background("#F4C542").Padding(10)
                    .Text(dayGroup.Key.ToString("dddd, dd MMMM yyyy")).FontSize(12).Bold();

                    foreach (var block in dayGroup.OrderBy(b => b.StartTime))
                    {
                        column.Item().Element(c => ComposeBlock(c, block));
                    }
                }

                decimal total = CalculateTotal(itinerary);

                column.Item().PaddingTop(10).BorderTop(1).BorderColor(Colors.Yellow.Lighten1)
                .PaddingTop(15).AlignRight().Text($"Total Cost: ${total:F2}").SemiBold();
                               
            });
        }

        private void ComposeBlock(IContainer container, ItineraryBlock block)
        {
            container.Border(1).BorderColor(Colors.Grey.Lighten3).Padding(15).Column(column =>
            {
                column.Spacing(5);

                // hourly
                column.Item().Text(block.StartTime.ToString("HH:mm")).FontSize(12).Bold()
                .FontColor(Colors.Grey.Lighten3);

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
            var note = transport.Notes.FirstOrDefault();

            column.Item().Text($"{note?.Route ?? "Transport"} {note?.Method.ToString() ?? ""}").Bold();

            if (note != null)
            {
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

            column.Item().Text(attractionName).FontSize(12).Bold();

            if (!string.IsNullOrWhiteSpace(visit.Note))
            {
                column.Item().Text(visit.Note).FontColor(Colors.Grey.Darken1);
            }
        }

        private decimal CalculateTotal(Itinerary itinerary)
        {
            decimal total = 0;

            foreach (var block in itinerary.ItineraryBlocks)
            {
                if (block is TransportBlock)
                {
                    total += 3.00m;
                }
            }
            return total;
        }
    }
}
