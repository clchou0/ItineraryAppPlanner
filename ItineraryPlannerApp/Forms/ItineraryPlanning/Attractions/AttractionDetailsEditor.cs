using BruTile.Wms;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using System.Xml.Linq;
namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class AttractionDetailsEditor : UserControl
    {
        private readonly ItineraryPlannerService _service;
        private readonly Form _owner;
        public Attraction Attraction;
        private bool _isCreate;
        public AttractionDetailsEditor(ItineraryPlannerService service, Form owner, Attraction attraction, bool isCreate)
        {
            _isCreate = isCreate;
            _service = service;
            _owner = owner;
            Attraction = attraction ?? new Attraction();
            owner.Controls.Add(this);
            this.BringToFront();

            InitializeComponent();

            if (isCreate)
            {
                DescriptionTextBox.Text = Attraction.Description;
                ShortDescTextBox.Text = Attraction.ShortDesctiption;
                NameTextBox.Text = Attraction.AttractionName;
                AreaTextBox.Text = Attraction.Area;
                PriceTextBox.Text = Attraction.EntryPrice;

                foreach(var access in Attraction.CloseStations)
                {
                    TransportMethodPanel.Controls.Add(new TransportRow(access, this));
                }
            }

            
            DescriptionTextBox.TextChanged += (e, c) => Attraction.Description = DescriptionTextBox.Text;
            ShortDescTextBox.TextChanged += (e, c) => Attraction.ShortDesctiption = ShortDescTextBox.Text;
            NameTextBox.TextChanged += (e, c) => Attraction.AttractionName = NameTextBox.Text;
            AreaTextBox.TextChanged += (e, c) => Attraction.Area = AreaTextBox.Text;
            PriceTextBox.TextChanged += (e, c) => Attraction.EntryPrice = PriceTextBox.Text;
        }

        private void AddStationButton_Click(object sender, EventArgs e)
        {
            TransitAccess access = new TransitAccess { Attraction = Attraction };
            TransportMethodPanel.Controls.Add(new TransportRow(access, this));
            Attraction.CloseStations.Add(access);
        }
        public void RemoveTransport(TransportRow row)
        {
            TransportMethodPanel.Controls.Remove(row);
            Attraction.CloseStations.Remove(row.Access);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Your changes will not be saved..",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                _owner.Controls.Remove(this);
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (_isCreate) _service.AddAttraction(Attraction);
            else _service.UpdateAttraction(Attraction);
        }
    }
}
