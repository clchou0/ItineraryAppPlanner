using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class TransportRow : UserControl
    {
        public TransitAccess Access;
        private readonly AttractionDetailsEditor _editor;
        public TransportRow(TransitAccess access, AttractionDetailsEditor editor)
        {
            _editor = editor;
            InitializeComponent();
            var visibleTypes = Enum.GetValues<TransportType>()
                .Where(t => t != TransportType.Car && t != TransportType.Cab && t != TransportType.Walk);
            TypeComboBox.DataSource = visibleTypes.ToList();
            TypeComboBox.Format += (s, e) =>
            {
                e.Value = e.Value switch
                {
                    TransportType.None => "-Station Type-",
                    TransportType.Train => "Train",
                    TransportType.Ferry => "Ferry",
                    TransportType.Metro => "Metro",
                    TransportType.Bus => "Bus",
                    TransportType.LightRail => "Light Rail",
                    _ => ""
                };
            };
            TypeComboBox.SelectedItem = access.Type;
            StationTextBox.Text = access.StationName;
            walkUpDown.Value = access.MinuteWalk;
            TypeComboBox.SelectedIndexChanged += (s, e) => access.Type = (TransportType)TypeComboBox.SelectedItem!;
            StationTextBox.TextChanged += (s, e) => access.StationName = StationTextBox.Text.Trim();
            walkUpDown.ValueChanged += (s, e) => access.MinuteWalk = (int)walkUpDown.Value;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                $"Are you sure to delete this transport method?",
                "Confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.OK)
            {
                _editor.RemoveTransport(this);
            }
            
        }
    }
}
