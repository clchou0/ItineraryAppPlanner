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

        private ObservableCollection<TransportSegmentItem> _transportSegments = new();
        private ItineraryBlockItem? _editingTransport;

        private ItineraryBlockItem? _editingBlock;
        private bool _unsaved = false;

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

            SegmentList.ItemsSource = _transportSegments;

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
            _unsaved = true;
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

        private void AddSegment_Click(object sender, RoutedEventArgs e)
        {
            if (cbTrasportMode.SelectedItem is not ComboBoxItem modeItem)
            {
                MessageBox.Show("Please select a transport mode.");
                return;
            }

            string method = modeItem.Content.ToString() ?? "";
            string route = txtRoute.Text.Trim();
            string from = txtFrom.Text.Trim();
            string to = txtTo.Text.Trim();

            if(string.IsNullOrWhiteSpace(from) || string.IsNullOrWhiteSpace(to))
            {
                MessageBox.Show("Please enter From and To Station.");
                return;
            }

            _transportSegments.Add(new TransportSegmentItem
            {
                Method = method,
                Route = route,
                FromStation = from,
                ToStation = to
            });

            cbTrasportMode.SelectedIndex = -1;

            txtRoute.Clear();
            txtFrom.Clear();
            txtTo.Clear();
        } 

        private void DeleteSegment_Click(Object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;

            if (button.Tag is not TransportSegmentItem segment) return;

            _transportSegments.Remove(segment);
        }

        private void SaveTransport_Click(object sender, RoutedEventArgs e)
        {
            if (_transportSegments.Count == 0)
            {
                MessageBox.Show("No trasport added.");
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
                MessageBox.Show("Enter a time with a valid format.\nExample: 10:30.");
                return;
            }

            DateTime startTime = dpTransportDate.SelectedDate.Value.Date.Add(time);

            if (_editingTransport == null)
            {
                var block = new ItineraryBlockItem
                {
                    Id = 0,
                    Type = "Transport",
                    Title = "Transport",
                    StartTime = startTime,
                    Duration = 0,
                    Cost = 3.00m,
                    Segments = _transportSegments.ToList()

                };

                UpdateTransportDescription(block);
                Blocks.Add(block);
                MessageBox.Show("Transport added.");

            } else
            {
                _editingTransport.StartTime = startTime;
                _editingTransport.Segments = _transportSegments.ToList();
                UpdateTransportDescription(_editingTransport);
                MessageBox.Show("Transport edited.");
            }

            SortBlocksByTime();
            UpdateTotalCost();
            _unsaved = true;

            AddTransportView.Visibility = Visibility.Collapsed;
            ItineraryEditView.Visibility = Visibility.Visible;
        }

        private void UpdateTransportDescription(ItineraryBlockItem block)
        {
            block.Description = string.Join(" | ", block.Segments.Select(
                s => $"{s.Method}: " + $"{s.FromStation} -> {s.ToStation}"));
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

            _editingTransport = null;
            _transportSegments.Clear();

            dpTransportDate.DisplayDateStart = dpArriveDate.SelectedDate.Value;
            dpTransportDate.DisplayDateEnd = dpLeaveDate.SelectedDate.Value;
            dpTransportDate.SelectedDate = dpArriveDate.SelectedDate.Value;

            txtTransportTime.Text = "10:00";

            cbTrasportMode.SelectedIndex = -1;
            txtRoute.Clear();
            txtFrom.Clear();
            txtTo.Clear();
              
            ItineraryEditView.Visibility = Visibility.Collapsed;
            AddTransportView.Visibility = Visibility.Visible;
        }

        private void BackToEdit_Click(Object sender, RoutedEventArgs e)
        {
            _editingTransport = null;
            _transportSegments = null;
            cbTrasportMode.SelectedIndex = -1;

            txtRoute.Clear();
            txtFrom.Clear();
            txtTo.Clear();

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

            DateTime newArriveDate = dpArriveDate.SelectedDate.Value.Date;
            DateTime newLeaveDate = dpLeaveDate.SelectedDate.Value.Date;

            var invalidBlock = Blocks.FirstOrDefault
                (b => b.StartTime.Date < newArriveDate|| b.StartTime.Date > newLeaveDate);

            if (invalidBlock != null)
            {
                MessageBox.Show("The itinerary dates cannot be changed because there is scheduled outside the itinerary period.");
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

                _unsaved = false;
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

                    _unsaved = false;
                }
            }

            MessageBox.Show("Itinerary saved successfully.");

            UpdateEmptyState();
            ShowListView();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {
            _unsaved = true;
        }

        private void EditBlock_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;

            if (button.DataContext is not ItineraryBlockItem block) return;

            if (block.Type != "Attraction") return;

            _editingBlock = block;

            txtEditBlockTitle.Text = block.Title;
            dpEditBlockDate.SelectedDate = block.StartTime.Date;
            txtEditBlockTime.Text = block.StartTime.ToString("HH:mm");

            // only allow to pick dates during itinerary
            dpEditBlockDate.DisplayDateStart = dpArriveDate.SelectedDate;
            dpEditBlockDate.DisplayDateEnd = dpLeaveDate.SelectedDate;

            ItineraryEditView.Visibility = Visibility.Collapsed;
            EditBlockView.Visibility = Visibility.Visible;
        }

        private void SaveEdit_Click(object sender, RoutedEventArgs e)
        {
            if (_editingBlock == null) return;

            if (dpEditBlockDate.SelectedDate == null)
            {
                MessageBox.Show("Please select a date."); return;
            }

            if (!TimeSpan.TryParse(txtEditBlockTime.Text, out TimeSpan time))
            {
                MessageBox.Show("Invalid input. \n Example: 10:10");
                return;
            }

            DateTime selectedDate = dpEditBlockDate.SelectedDate.Value.Date;

            DateTime newStartTime = selectedDate + time;

            if ((dpArriveDate.SelectedDate != null && newStartTime.Date < dpArriveDate.SelectedDate.Value.Date)
                || dpLeaveDate.SelectedDate != null && newStartTime.Date > dpLeaveDate.SelectedDate.Value.Date)
            {
                MessageBox.Show("The attraction schedule should be during itinerary."); return;
            }

            _editingBlock.StartTime = newStartTime;
            SortBlocks();

            _editingBlock = null;

            BackToEditView();
        }

        private void CancelEdit_Click(Object sender,  RoutedEventArgs e)
        {
            _editingBlock = null;
            BackToEditView();
        }

        private void BackToEditView()
        {
            EditBlockView.Visibility = Visibility.Collapsed;
            ItineraryEditView.Visibility = Visibility.Visible;
        }

        private void CompleteButton_Click(object sender, EventArgs e)
        {
            if (_currentItineraryId == null || _unsaved == true)
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
