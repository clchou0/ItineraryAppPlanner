using BruTile.Wms;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Helpers;
using ItineraryPlannerApp.Models;
using System.Xml.Linq;
namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class AttractionDetailsEditor : UserControl
    {
        private readonly ItineraryPlannerService _service;
        private readonly UserToggleComponent _owner;
        public Attraction Attraction;
        private bool _isCreate;
        public AttractionDetailsEditor(ItineraryPlannerService service, UserToggleComponent owner, Attraction attraction, bool isCreate)
        {
            _isCreate = isCreate;
            Attraction = attraction;
            _service = service;
            _owner = owner;
            _owner.FindForm().Controls.Add(this);
            this.BringToFront();

            InitializeComponent();

            if (!isCreate)
            {
                DescriptionTextBox.Text = Attraction.Description;
                ShortDescTextBox.Text = Attraction.ShortDesctiption;
                NameTextBox.Text = Attraction.AttractionName;
                AreaTextBox.Text = Attraction.Area;
                PriceTextBox.Text = Attraction.EntryPrice;

                foreach (var access in Attraction.CloseStations)
                {
                    TransportMethodPanel.Controls.Add(new TransportRow(access, this));
                }
            }

            DescriptionTextBox.TextChanged += (e, c) => Attraction.Description = DescriptionTextBox.Text;
            ShortDescTextBox.TextChanged += (e, c) => Attraction.ShortDesctiption = ShortDescTextBox.Text;
            NameTextBox.TextChanged += (e, c) => Attraction.AttractionName = NameTextBox.Text;
            AreaTextBox.TextChanged += (e, c) => Attraction.Area = AreaTextBox.Text;
            PriceTextBox.TextChanged += (e, c) => Attraction.EntryPrice = PriceTextBox.Text;

            pictureBox1.Image = ImageHelper.LoadImage(attraction.ImagePath);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
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
                _owner.FindForm().Controls.Remove(this);
            }

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            string error = "";
            if (Attraction.CloseStations.Any(s => !s.IsValid))
                error += "One of the stations is not in valid format";
            string[] fields =
            [
                Attraction.AttractionName,
                Attraction.ImagePath,
                Attraction.Description,
                Attraction.ShortDesctiption,
                Attraction.Area,
                Attraction.EntryPrice
            ];
            if (fields.Any(s => string.IsNullOrEmpty(s)))
            {
                if (error != "") error += "\n";
                error += "One of the fields is not filled";
            }

            if (error == "")
            {
                if (_isCreate) _service.AddAttraction(Attraction);
                else _service.UpdateAttraction(Attraction);

                string mode = _isCreate ? "create" : "edited";
                MessageBox.Show($"{Attraction.AttractionName} has been {mode}");
                _owner.FindForm().Controls.Remove(this);
                _owner.ReloadAttractions();
            }
            else
            {
                MessageBox.Show(error);
            }
        }
    }
}
