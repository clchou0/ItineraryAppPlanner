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
    /// Interaction logic for myItineraries.xaml
    /// </summary>
    public partial class myItineraries : Window
    {
        public ObservableCollection<ItineraryList> Itineraries { get; set; }

        private readonly Func<int, bool> _moveToBuilder;
        private int? _selectedItineraryId;
        private readonly Action<int> _deleteItinerary;
        public myItineraries(List<ItineraryList> itineraries, Func<int, bool> moveToBuilder, Action<int> deleteItinerary)
        {
            InitializeComponent();

            Itineraries = new ObservableCollection<ItineraryList> (itineraries);

            _moveToBuilder = moveToBuilder;
            _deleteItinerary = deleteItinerary;

            DataContext = this;
        }

        private void ViewDetails_Click(object sender, RoutedEventArgs e)
        {
            if (sender is not Button button) return;
            if (button.Tag is not int itineraryId) return;

            var selected = Itineraries.FirstOrDefault(i => i.Id == itineraryId);

            if (selected == null) return;

            _selectedItineraryId = selected.Id;

            txtDetailTitle.Text = $"{selected.CityName} Itinerary";
            txtDetailDates.Text = $"From: {selected.ArriveDate:dd MMM yyyy} - To: {selected.LeaveDate:dd MMM yyyy}";

            detailBlocks.ItemsSource = selected.Blocks.OrderBy(b => b.StartTime).ToList();

            decimal total = selected.Blocks.Sum(b => b.Cost);

            txtTotalCost.Text = $"Total Cost: ${total:F2}";

            ItineraryListView.Visibility = Visibility.Collapsed;
            ItineraryDetailsView.Visibility = Visibility.Visible;
        }

        private void MoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedItineraryId == null)
            {
                MessageBox.Show("Unknown Activity");
                return;
            }

            var result = MessageBox.Show("Move this itinerary back to the Builder?", "Draft", MessageBoxButton.YesNo);
            if (result != MessageBoxResult.Yes) return;

            bool moved = _moveToBuilder(_selectedItineraryId.Value);
            if (!moved)
            {
                MessageBox.Show("Failed to move itinerary. Please try again later.");
                return;
            }

            var itinerary = Itineraries.FirstOrDefault(i => i.Id == _selectedItineraryId.Value);

            if (itinerary != null)
            {
                Itineraries.Remove(itinerary);
            }
            _selectedItineraryId = null;

            MessageBox.Show("Now you can find this itinerary on Itinerary Builder.");

            BackToList();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            BackToList();
        }

        private void BackToList()
        {
            ItineraryDetailsView.Visibility = Visibility.Collapsed;
            ItineraryListView.Visibility = Visibility.Visible;
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
                }
                else { return; }
            }
            else { return; }

            _deleteItinerary(itineraryId);

        }
        private void ExportPdf_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("PDF sent to your email.");
        }
    }
}
