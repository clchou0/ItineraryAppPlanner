using BruTile.Predefined;
using ItineraryPlannerApp.Models;
using Mapsui;
using Mapsui.Extensions;
using Mapsui.Limiting;
using Mapsui.Projections;
using Mapsui.Tiling.Layers;
using Mapsui.Widgets;
using Mapsui.Widgets.InfoWidgets;
using System.Globalization;
using ItineraryPlannerApp.Helpers;

namespace ItineraryPlannerApp.Forms.CityForm
{
    /// <summary>
    /// Map view that allows admin to lock the map into place
    /// </summary>
    public partial class CityMapEditor : Form
    {
        // Depends on if this is an EDIT or CREATE screen
        public MapSlider NewSlider { get { return mapControl1.Slider; } }
        public string CityName;
        public CityMapEditor(string name, MapSlider slider)
        {
            CityName = name;
            
            InitializeComponent();
            LatTextBox.Cap = 90;
            LngTextBox.Cap = 180;
            if (slider.MaxSet) LockTopRight.Text = "Unlock Top Right";
            if (slider.MinSet) LockBottomLeft.Text = "Unlock Bottom Left";

            mapControl1.Initialize(slider, MapMode.CityEdit);
        }

        private void CityMapEditor_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = $"Configuring Map for {CityName}";
        }
        private void LockTopRight_Click(object sender, EventArgs e)
        {
            if (NewSlider.MaxSet)
            {
                NewSlider.SetTopRight(null, null);
                LockTopRight.Text = "Lock Top Right";
            }
            else
            {
                var viewport = mapControl1.Map.Navigator.Viewport;
                double halfWidthMap = (viewport.Width * viewport.Resolution) / 2;
                double halfHeightMap = (viewport.Height * viewport.Resolution) / 2;

                double maxX = viewport.CenterX + halfWidthMap;
                double maxY = viewport.CenterY + halfHeightMap;

                var (maxLon, maxLat) = SphericalMercator.ToLonLat(maxX, maxY);

                if (!NewSlider.SetTopRight(maxLon, maxLat))
                    MessageBox.Show("Top right setup failed");
                else
                    LockTopRight.Text = "Unlock Top Right";
            }
        }
        private void LockBottomLeft_Click(object sender, EventArgs e)
        {
            if (NewSlider.MinSet)
            {
                // Unlock
                NewSlider.SetBottomLeft(null, null);
                LockBottomLeft.Text = "Lock Bottom Left";
            }
            else
            {
                var viewport = mapControl1.Map.Navigator.Viewport;
                double halfWidthMap = (viewport.Width * viewport.Resolution) / 2;
                double halfHeightMap = (viewport.Height * viewport.Resolution) / 2;

                double minX = viewport.CenterX - halfWidthMap;
                double minY = viewport.CenterY - halfHeightMap;

                var (minLon, minLat) = SphericalMercator.ToLonLat(minX, minY);
                if (!NewSlider.SetBottomLeft(minLon, minLat))
                    mapControl1.Map.Navigator.OverridePanBounds = NewSlider.PanBoundCreator();
                else
                    LockBottomLeft.Text = "Unlock Bottom Left";
            }
        }
        private void DefaultZoom_Click(object sender, EventArgs e)
        {
            var viewport = mapControl1.Map.Navigator.Viewport;
            double x = viewport.CenterX;
            double y = viewport.CenterY;
            var (lon, lat) = SphericalMercator.ToLonLat(x, y);
            NewSlider.SetDefault(lon, lat);
        }
        private void mapControl1_Load(object sender, EventArgs e)
        {
            mapControl1.Dock = DockStyle.None;
        }

        private void ZoomTo_Click(object sender, EventArgs e)
        {
            bool latOk = LatTextBox.IsValid();
            bool lngOk = LngTextBox.IsValid();

            LatTextBox.BackColor = latOk ? Color.White : Color.MistyRose;
            LngTextBox.BackColor = lngOk ? Color.White : Color.MistyRose;

            if (latOk && lngOk)
            {
                var lat = float.Parse(LatTextBox.Text, CultureInfo.InvariantCulture);
                var lng = float.Parse(LngTextBox.Text, CultureInfo.InvariantCulture);
                if (NewSlider.InRange(lng, lat)) 
                {
                    var point = SphericalMercator.FromLonLat(lng, lat).ToMPoint();
                    mapControl1.Map.Navigator.CenterOn(point);
                }
                else
                {
                    MessageBox.Show("Choose a valid point to zoom to or unlock bounds");
                }
            }
        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (!NewSlider.IsValid)
                MessageBox.Show("Set all necessary fields before confirming");
            else 
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure to reset map configuration?",
                "confirm",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.OK) NewSlider.Reset();

        }

        private void DefaultZoomButton_Click(object sender, EventArgs e)
        {
            MPoint? center = NewSlider.ZoomPoint();
            if (center is null) { MessageBox.Show("Default zoom not set"); }
            else
            {
                mapControl1.Map.Navigator.CenterOnAndZoomTo(
                    SphericalMercator.FromLonLat(center),
                    mapControl1.Map.Navigator.Resolutions[10]
                );
            }
        }
    }
}
