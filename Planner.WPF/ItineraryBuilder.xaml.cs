using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Planner.WPF
{
    /// <summary>
    /// Interaction logic for ItineraryBuilder.xaml
    /// </summary>
    public partial class ItineraryBuilder : Window
    {
        private readonly int _userId;
        private int _cityId;
        private int? _currentItineraryId;
        private readonly Func<ItineraryEditData, int> _saveItinerary;
        private readonly Action<int> _completeItinerary;
        private readonly Action<int> _deleteItinerary;
        public ObservableCollection<ItineraryList> Itineraries { get; set; }
        public ObservableCollection<ItineraryBlockItem> Blocks { get; set; } = new();
        public List<string> Cities { get; set; }
        public List<TransitRouteItem> TransitRoutes { get; set; }
        public ItineraryBuilder(
            int userId, List<ItineraryList> itineraries, 
            List<string> cities, 
            List<TransitRouteItem> routes, 
            Func<ItineraryEditData, int> saveItinerary, 
            Action<int> completeItinerary, 
            Action<int> deleteItinerary)
        {
            InitializeComponent();

            _userId = userId;

            Itineraries = new ObservableCollection<ItineraryList>(itineraries);

            Cities = cities;

            TransitRoutes = routes;

            _saveItinerary = saveItinerary;
            _completeItinerary = completeItinerary;
            _deleteItinerary = deleteItinerary;

            DataContext = this;

            dpArriveDate.DisplayDateStart = DateTime.Today;
            dpLeaveDate.DisplayDateStart = DateTime.Today;

            UpdateEmptyState();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            ShowEditView();

            _currentItineraryId = null;

            Blocks.Clear();

            txtEditTitle.Text = "New Itinerary";

            cbCity.SelectedItem = Cities.FirstOrDefault(c => c == "Sydney");

            dpArriveDate.SelectedDate = DateTime.Today.AddDays(1);
            dpLeaveDate.SelectedDate = DateTime.Today.AddDays(4);

            txtTotalCost.Text = "Total Entry Cost: $0.00";

        }

        private void EditItinerary_Click(object sender, RoutedEventArgs s)
        {
            if (sender is not Button button) return;
            if (button.Tag is not int itineraryId) return;

            var selected = Itineraries.FirstOrDefault(i => i.Id == itineraryId);

            if (selected == null) return;

            _currentItineraryId = selected.Id;

            cbCity.Visibility = Visibility.Collapsed;

            txtEditTitle.Text = $"Edit {selected.CityName} Itinerary";

            txtSelectedCity.Visibility = Visibility.Visible;
            txtSelectedCity.Text = selected.CityName;

            dpArriveDate.SelectedDate = selected.ArriveDate;
            dpLeaveDate.SelectedDate = selected.LeaveDate;

            Blocks.Clear();

            foreach (var block in selected.Blocks.OrderBy(b => b.StartTime))
            {
                Blocks.Add(block);
            }
            UpdateTotalCost();
            ShowEditView();
        }
        private void DeleteItinerary_Click(object sender, RoutedEventArgs s)
        {
            if (sender is Button button && button.Tag is int itineraryId)
            {
                var itinerary = Itineraries.FirstOrDefault(i => i.Id == itineraryId);

                if (itinerary != null)
                {
                    var result =
                        MessageBox.Show("Are you sure you want to delete the selected itinerary?", "Delete Itinerary",
                        MessageBoxButton.YesNo);

                    if (result != MessageBoxResult.Yes) return;

                    Itineraries.Remove(itinerary);
                } else { return; }
            } else { return; }

            _deleteItinerary(itineraryId);

            UpdateEmptyState();
        }

        private void DeleteBlock_Click(object sender, RoutedEventArgs s)
        {
            if (sender is not Button button) return;
            if (button.Tag is not ItineraryBlockItem block) return;

            Blocks.Remove(block);
            UpdateTotalCost();
        }

        private void UpdateEmptyState()
        {
            if (Itineraries.Count == 0)
            {
                emptyPanel.Visibility = Visibility.Visible;
                itineraryList.Visibility = Visibility.Collapsed;
            }
            else
            {
                emptyPanel.Visibility = Visibility.Collapsed;
                itineraryList.Visibility = Visibility.Visible;
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ShowEditView()
        {
            ItineraryListView.Visibility = Visibility.Collapsed;
            ItineraryEditView.Visibility = Visibility.Visible;
        }

        private void ShowListView()
        {
            ItineraryListView.Visibility = Visibility.Visible;
            ItineraryEditView.Visibility = Visibility.Collapsed;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Blocks.Clear();
            _currentItineraryId = null;
            ShowListView();
        }


        private void AddAttraction_Click(object sender, RoutedEventArgs e)
        {
            // will be added.
            var block = new ItineraryBlockItem
            {
                
            };
            Blocks.Add(block);

            SortBlocks();
            UpdateTotalCost();
        }

        private void Route_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (cbRoute.SelectedItem is not TransitRouteItem route) return;

            var stops = route.Stops.OrderBy(s => s.StopOrder).ToList();

            cbFromStop.ItemsSource = stops;
            cbToStop.ItemsSource = stops;
        }

        private void SaveTransport_Click(object sender, RoutedEventArgs e)
        {
            if (cbRoute.SelectedItem is not TransitRouteItem route)
            {
                MessageBox.Show("Please select a route.");
                return;
            }

            if (cbFromStop.SelectedItem is not TransitStopItem from)
            {
                MessageBox.Show("Please select a starting stop.");
                return;
            }

            if (cbToStop.SelectedItem is not TransitStopItem to)
            {
                MessageBox.Show("Please select a destination.");
                return;
            }

            if (from.Id == to.Id)
            {
                MessageBox.Show("From and To cannot be the same.");
                return;
            }

            if (dpTransportDate.SelectedDate == null)
            {
                MessageBox.Show("Please select a date.");
                return;
            }

            if (!TimeSpan.TryParse(
                txtTransportTime.Text, out var time))
            {
                MessageBox.Show("Enter a time such as 10:30.");
            }

            DateTime startTime = dpTransportDate.SelectedDate.Value.Date.Add(time);

            var block = new ItineraryBlockItem
            {
                Id = 0,
                Type = "Transport",

                TransportMethod = route.Type,
                Route = route.RouteName,
                FromStation = from.StopName,
                ToStation = to.StopName,

                Title = $"{route.RouteName} {route.Type}",

                Description = $"{from.StopName} -> {to.StopName}",

                StartTime = startTime,

                Duration = 0,
                Cost = 3.00m
            };

            Blocks.Add(block);
            MessageBox.Show("Transport added.");

            SortBlocksByTime();
            UpdateTotalCost();

            AddTransportView.Visibility = Visibility.Collapsed;
            ItineraryEditView.Visibility = Visibility.Visible;
        }

        private void SortBlocksByTime()
        {
            var sorted = Blocks.OrderBy(b => b.StartTime).ToList();

            Blocks.Clear();

            foreach (var block in sorted)
            {
                Blocks.Add(block);
            }
        }

        private void AddTransport_Click(Object sender, RoutedEventArgs e)
        {
            if (dpArriveDate.SelectedDate == null || dpLeaveDate.SelectedDate == null)
            {
                MessageBox.Show("Please select itinerary dates first.");
                return;
            }

            dpTransportDate.DisplayDateStart = dpArriveDate.SelectedDate.Value;
            dpTransportDate.DisplayDateEnd = dpLeaveDate.SelectedDate.Value;

            if (cbCity.SelectedItem == null && _currentItineraryId == null)
            {
                MessageBox.Show("City not found.");
                return;
            }
            string cityName;

            if (_currentItineraryId == null)
            {
                cityName = cbCity.SelectedItem?.ToString() ?? "";
            }
            else
            {
                var existing = Itineraries.FirstOrDefault(i => i.Id == _currentItineraryId);

                if (existing == null) return;

                cityName = existing.CityName;
            }

            var routes = TransitRoutes.Where(r => r.CityName == cityName).ToList();
            cbRoute.ItemsSource = routes;
              
            ItineraryEditView.Visibility = Visibility.Collapsed;
            AddTransportView.Visibility = Visibility.Visible;
        }

        private void BackToEdit_Click(Object sender, RoutedEventArgs e)
        {
            ItineraryEditView.Visibility = Visibility.Visible;
            AddTransportView.Visibility = Visibility.Collapsed;
        }

        private void UpdateTotalCost()
        {
            decimal total = Blocks.Sum(b => b.Cost);
            txtTotalCost.Text = $"${total:F2}";
        }

        private void SortBlocks()
        {
            var sorted = Blocks.OrderBy(b => b.StartTime).ToList();

            Blocks.Clear();

            foreach (var block in sorted)
            {
                Blocks.Add(block);
            }
        }

        private void SaveItinerary_Click(Object sender, RoutedEventArgs e)
        {
            string cityName;

            if (_currentItineraryId == null)
            {
                // NEW
                if (cbCity.SelectedItem == null)
                {
                    MessageBox.Show("Please select a city.");
                    return;
                }

                cityName = cbCity.SelectedItem.ToString();
            }

            else
            {
                // EDIT
                var existing = Itineraries.FirstOrDefault(i => i.Id == _currentItineraryId.Value);

                if (existing == null)
                {
                    MessageBox.Show("Itinerary not found.");
                    return;
                }
                cityName = existing.CityName;
            }

            if (dpArriveDate.SelectedDate == null || dpLeaveDate.SelectedDate == null) 
            { 
                MessageBox.Show("Please select both dates.");
                return; 
            }
            if (dpArriveDate.SelectedDate.Value > dpLeaveDate.SelectedDate.Value)
            {
                MessageBox.Show("Leave date cannot be before arrive date.");
                return;
            }
                var data = new ItineraryEditData
            {
                ItineraryId = _currentItineraryId,
                UserId = _userId,
                CityName = cityName,
                ArriveDate = dpArriveDate.SelectedDate.Value,
                LeaveDate = dpLeaveDate.SelectedDate.Value,
                Blocks = Blocks.ToList()
            };

            int savedId = _saveItinerary(data);

            if (savedId == 0)
            {
                return;
            }

            if (_currentItineraryId == null)
            {
                // NEW
                var newItem = new ItineraryList
                {
                    Id = savedId,
                    UserId = _userId,
                    CityName = data.CityName,
                    ArriveDate = data.ArriveDate,
                    LeaveDate = data.LeaveDate,
                    TotalPrice = 0,
                    Blocks = data.Blocks
                };
                Itineraries.Add(newItem);
            }

            else
            {
                // EDIT
                var existing = Itineraries.FirstOrDefault(i => i.Id == savedId);

                if (existing != null)
                {
                    int index = Itineraries.IndexOf(existing);

                    var updatedItem = new ItineraryList
                    {
                        Id = existing.Id,
                        UserId = existing.UserId,
                        CityName = existing.CityName,
                        ArriveDate = data.ArriveDate,
                        LeaveDate = data.LeaveDate,
                        TotalPrice = existing.TotalPrice,
                        Blocks = data.Blocks
                    };
                    Itineraries[index] = updatedItem;
                }
            }

            MessageBox.Show("Itinerary saved successfully.");

            UpdateEmptyState();
            ShowListView();
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if (_currentItineraryId == null)
            {
                MessageBox.Show("Please save the itinerary before completing it.");
                return;
            }

            var result = MessageBox.Show("Complete this itinerary plan?", "Move to My Itineraries", MessageBoxButton.YesNo);

            if (result != MessageBoxResult.Yes) return;

            _completeItinerary(_currentItineraryId.Value);

            var item = Itineraries.FirstOrDefault(i => i.Id == _currentItineraryId.Value);

            if (item != null)
            {
                Itineraries.Remove(item);
            }

            MessageBox.Show("Now you can find this plan in My Itineraries.");

            _currentItineraryId = null;

            UpdateEmptyState();
            ShowListView();
        }
    }
}
