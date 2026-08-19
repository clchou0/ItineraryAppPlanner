using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class AttractionDetailsView : UserControl
    {
        private readonly ItineraryPlannerService _service;
        private readonly UserToggleComponent _owner;
        public Attraction Attraction;
        public AttractionDetailsView(UserToggleComponent owner, Attraction attraction)
        {
            _owner = owner;
            Attraction = attraction;
            _owner.FindForm().Controls.Add(this);
            this.BringToFront();

            InitializeComponent();

            DescriptionLabel.Text = Attraction.Description;
            NameLabel.Text = Attraction.AttractionName;
            AreaLabel.Text = Attraction.Area;
            PriceLabel.Text = Attraction.EntryPrice;
            tableLayoutPanel1.Controls.Clear();

            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            const int rowHeight = 4;
            const int col1X = 0, col2X = 30, col3X = 100; // hand-tuned column starts
            int y = 0;

            foreach (var stop in Attraction.CloseStations)
            {
                tableLayoutPanel1.Controls.Add(new Label { Text = stop.Type.ToString(), Location = new Point(col1X, y), AutoSize = true });
                tableLayoutPanel1.Controls.Add(new Label { Text = stop.StationName, Location = new Point(col2X, y), AutoSize = true });
                tableLayoutPanel1.Controls.Add(new Label { Text = $"{stop.MinuteWalk} min", Location = new Point(col3X, y), AutoSize = true });
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
           _owner.FindForm().Controls.Remove(this);
        }
    }
}
