using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class AttractionRow : UserControl
    {
        public Attraction Attraction;
        private readonly ItineraryPlannerService _service;
        public bool IsAdmin;
        private readonly UserToggleComponent _component;
        public AttractionRow(ItineraryPlannerService service, Attraction attraction, bool isAdmin, UserToggleComponent component)
        {
            _service = service;
            Attraction = attraction;
            IsAdmin = isAdmin;

            InitializeComponent();

            NameLabel.Text = Attraction.AttractionName;
            AreaLabel.Text = $"Area: {Attraction.Area}";
            DescriptionText.Text = Attraction.ShortDesctiption;
            TransportLabel.Text = $"Access: {Attraction.TransportMethods}";

            if (isAdmin)
            {
                AddButton.Visible = false;
                AddButton.Enabled = false;
            }
            else
            {
                EditButton.Visible = false;
                EditButton.Enabled = false;
                AddButton.Visible = true;
                AddButton.Enabled = true;
            }

            _component = component;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!IsAdmin) return;
            var editor = new AttractionDetailsEditor(_service, _component, Attraction, false);
            editor.BringToFront();
            editor.Dock = DockStyle.Fill;

        }
        private void DetailsButton_Click(object sender, EventArgs e)
        {
            var view = new AttractionDetailsView(_component, Attraction);
            view.BringToFront();
            view.Dock = DockStyle.Fill;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }
    }
}
