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
                    page.Margin(40);

                    page.Header().Text("Your Travel Itinerary").FontSize(24).Bold();

                    page.Content().Column(column =>
                    {
                        column.Spacing(10);
                        column.Item().Text($"City: {itinerary.City?.CityName}");
                        column.Item().Text($"Arrival: {itinerary.ArriveDate:dd/MM/yyyy}");
                        column.Item().Text($"Departure: {itinerary.LeaveDate:dd/MM/yyyy}");
                    });

                    page.Footer().AlignCenter().Text("Travel Planner - PDF");
                });
            }).GeneratePdf();
        }
    }
}
