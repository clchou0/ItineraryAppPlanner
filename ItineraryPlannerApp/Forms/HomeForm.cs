using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;
using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Repositories;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Helpers;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models.Itinerary;
using Microsoft.EntityFrameworkCore;
using Planner.WPF;

namespace ItineraryPlannerApp.Forms
{
    public partial class HomeForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly User _user;
        private string _selectedCity = "";

        public HomeForm()
        {
            InitializeComponent();


            buildItineraryToolStripMenuItem.Click += buildItineraryToolStripMenuItem_Click;
            itineraryHistoryToolStripMenuItem.Click += itineraryHistoryToolStripMenuItem_Click;

        }
        public HomeForm(MainForm mainForm, User user) : this()
        {

            this.Load += HomeFormLoad;

            _mainForm = mainForm;
            _user = user;

            welcomeLabel.Text = $"Welcome, {user.DisplayName}";
        }

        private void HomeFormLoad(object sender, EventArgs e)
        {
            var cities = _mainForm.Service.GetAllCities();

            foreach (City city in cities)
            {
                Panel cityCard = DisplayCity(city);
                panel1.Controls.Add(cityCard);

                int margin = Math.Max(0, (panel1.ClientSize.Width - cityCard.Width) / 2);

                cityCard.Margin = new Padding(margin, 10, 0, 20);
            }
        }

        private Panel DisplayCity(City city)
        {
            Panel card = new Panel
            {
                Width = 1280,
                Height = 400,
                Margin = new Padding(10, 10, 10, 20),
                Cursor = Cursors.Hand,
                Tag = city
            };

            PictureBox pic = new PictureBox
            {
                Dock = DockStyle.Fill,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = ImageHelper.LoadImage(city.ImagePath),
                Cursor = Cursors.Hand,
                Tag = city
            };

            Label cityName = new Label
            {
                Text = city.CityName,
                AutoSize = false,
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                Dock = DockStyle.Bottom,
                Height = 100,
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand,
                Tag = city
            };

            card.Controls.Add(pic);
            pic.Controls.Add(cityName);

            cityName.BringToFront();

            card.Click += CityCard_Click;
            pic.Click += CityCard_Click;
            cityName.Click += CityCard_Click;

            return card;
        }

        private void CityCard_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is City city)
            {
                MessageBox.Show($"Selected city: {city.CityName}");

                string _selectedCity = city.CityName;
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            _mainForm.ShowPage(new LoginForm(_mainForm));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(MenuButton, new Point(0, MenuButton.Height));
        }

        private void buildItineraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var dbitineraries = _mainForm.Service.GetItinerariesByUserId(_user.Id);

            var itineraries = dbitineraries
                .Select(i => new ItineraryList
                {
                    Id = i.Id,
                    UserId = i.UserId,
                    CityName = i.City.CityName,
                    ArriveDate = i.ArriveDate,
                    LeaveDate = i.LeaveDate,
                    TotalPrice = i.TotalEntryPrice,

                    Blocks = i.ItineraryBlocks.Select(b =>
                    {
                        if (b is TransportBlock transport)
                        {
                            var note = transport.Notes.FirstOrDefault();

                            return new ItineraryBlockItem
                            {

                                Id = b.Id,
                                ItineraryId = i.Id,

                                Type = "Transport",

                                TransportMethod = note?.Method.ToString() ?? "",
                                Route = note?.Route ?? "",
                                FromStation = note?.FromStation ?? "",
                                ToStation = note?.ToStation ?? "",
                                Title = $"{note?.Route} {note?.Method}",
                                Description = $"{note?.FromStation} -> {note?.ToStation}",
                                StartTime = b.StartTime,
                                Duration = transport.TotalDuration,
                                Cost = 3.00m
                            };
                        }

                        if (b is VisitBlock visit)
                        {
                            return new ItineraryBlockItem
                            {
                                Id = b.Id,
                                ItineraryId = i.Id,

                                Type = "Attraction",

                                AttractionId = visit.AttractionId,

                                Title = "Attraction",

                                Description = visit.Note ?? "",
                                StartTime = b.StartTime,
                                Cost = 0
                            };
                        }

                        return new ItineraryBlockItem
                        {
                            Id = b.Id,
                            ItineraryId = i.Id,
                            StartTime = b.StartTime
                        };
                    }).OrderBy(b => b.StartTime).ToList()
                }).ToList();

            var transportBlocks = dbitineraries.SelectMany(i => i.ItineraryBlocks).OfType<TransportBlock>().ToList();

            var cities = _mainForm.Service.GetAllCities().Select(c => c.CityName).ToList();

            var routes = _mainForm.Service.GetAllTransitRoutes()
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

            var editData = new ItineraryEditData
            {
                UserId = _user.Id,
                TransitRoutes = routes
            };

            var window = new ItineraryBuilder(_user.Id, itineraries, cities, routes, SaveItineraryFromWpf, DeleteItineraryFromWpf);

            window.ShowDialog();
        }

        private int SaveItineraryFromWpf(ItineraryEditData data)
        {
            var city = _mainForm.Service.GetCityByName(data.CityName);

            if (city == null)
            {
                MessageBox.Show($"City not found {data.CityName}");

                return 0;
            }

            Itinerary itinerary;

            if (data.ItineraryId == null)
            {
                itinerary = new Itinerary
                {
                    UserId = data.UserId,
                    CityId = city.Id,
                    ArriveDate = data.ArriveDate,
                    LeaveDate = data.LeaveDate,
                    TotalEntryPrice = 0
                };

                foreach (var blockItem in data.Blocks)
                {
                    if (blockItem.Type == "Attraction")
                    {
                        var visitBlock = new VisitBlock
                        {
                            StartTime = blockItem.StartTime,
                            AttractionId = blockItem.AttractionId!.Value,
                            Note = blockItem.Description
                        };
                        itinerary.ItineraryBlocks.Add(visitBlock);
                    }
                    else if (blockItem.Type == "Transport")
                    {
                        var transportBlock = new TransportBlock
                        {
                            StartTime = blockItem.StartTime,
                            TotalDuration = blockItem.Duration
                        };

                        itinerary.ItineraryBlocks.Add(transportBlock);

                    }
                }

                _mainForm.Service.AddItinerary(itinerary);

                MessageBox.Show($"Saved Successfully.\n {itinerary.Id}");

                return itinerary.Id;
            }

            else
            {
                var existing = _mainForm.Service.GetItineraryById(data.ItineraryId.Value, data.UserId);

                if (existing == null)
                {
                    MessageBox.Show("Itinerary not found.");
                    return 0;
                }

                existing.CityId = city.Id;
                existing.ArriveDate = data.ArriveDate;
                existing.LeaveDate = data.LeaveDate;
                
                foreach (var blockItem in data.Blocks)
                {
                    if (blockItem.Id != 0) continue;

                    if (blockItem.Type == "Attraction")
                    {
                        var visitBlock = new VisitBlock
                        {
                            StartTime = blockItem.StartTime,
                            AttractionId = blockItem.AttractionId!.Value,
                            Note = blockItem.Description
                        };
                        existing.ItineraryBlocks.Add(visitBlock);
                    }
                    else if (blockItem.Type == "Transport")
                    {
                        var transportBlock = new TransportBlock
                        {
                            StartTime = blockItem.StartTime,
                            TotalDuration = blockItem.Duration
                        };

                        transportBlock.Notes.Add(
                            new TransportNote
                            {
                                Method = Enum.Parse<TransportType>(blockItem.TransportMethod),
                                Route = blockItem.Route,
                                FromStation = blockItem.FromStation,
                                ToStation = blockItem.ToStation
                            });

                        existing.ItineraryBlocks.Add(transportBlock);
                    }
                }

                _mainForm.Service.UpdateItinerary(existing);

                return existing.Id;
            }

        }

        private void DeleteItineraryFromWpf(int itineraryId)
        {
            _mainForm.Service.DeleteItinerary(itineraryId, _user.Id);
        }

        private void itineraryHistoryToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            var window = new ItineraryHistory();
            window.Show();
        }
    }
}
