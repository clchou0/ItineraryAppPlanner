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

namespace ItineraryPlannerApp.Forms.CityForm
{
    // World map that asks aadmin to clamp items into place. 
    public partial class CityMapEditor : Form
    {
        // Depends on if this is an EDIT or CREATE screen
        private City? City;
        public MapSlider NewSlider { get; }
        public string CityName;
        public string NewDescription;
        private bool topRightLocked = false;
        private bool bottomLeftLocked = false;

        public CityMapEditor(string name, MapSlider slider, City? city)
        {
            CityName = name;
            NewSlider = slider;
            City = city;
            InitializeComponent();
        }

        private void CityMapEditor_Load(object sender, EventArgs e)
        {
            TitleLabel.Text = $"Configuring Map for {CityName}";
        }
        private void LockTopRight_Click(object sender, EventArgs e)
        {
            if (topRightLocked)
            {
                // Unlock
                NewSlider.SetTopRight(null, null);
                mapControl1.Map.Navigator.OverridePanBounds = NewSlider.PanBoundCreator();
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
                NewSlider.SetTopRight(maxLon, maxLat);
                mapControl1.Map.Navigator.OverridePanBounds = NewSlider.PanBoundCreator();

                LockTopRight.Text = "Unlock Top Right";
            }
            topRightLocked = !topRightLocked;
        }
        private void LockBottomLeft_Click(object sender, EventArgs e)
        {
            if (bottomLeftLocked)
            {
                // Unlock
                NewSlider.SetBottomLeft(null, null);
                mapControl1.Map.Navigator.OverridePanBounds = NewSlider.PanBoundCreator();
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
                NewSlider.SetBottomLeft(minLon, minLat);
                mapControl1.Map.Navigator.OverridePanBounds = NewSlider.PanBoundCreator();

                LockBottomLeft.Text = "Unlock Bottom Left";
            }
            topRightLocked = !topRightLocked;
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
            LoggingWidget.ShowLoggingInMap = ActiveMode.No;
            var layer = new TileLayer(KnownTileSources.Create(KnownTileSource.OpenStreetMap));
            mapControl1.Map.Layers.Add(layer);

            // Make it furthest zoom
            mapControl1.Map.Navigator.OverrideZoomBounds = new MMinMax(10, 200);

            MPoint center = NewSlider.ZoomPoint() ?? new MPoint(-118.2437, 34.0522);
            mapControl1.Map.Navigator.CenterOnAndZoomTo(
                SphericalMercator.FromLonLat(center),
                mapControl1.Map.Navigator.Resolutions[10]
            );
            mapControl1.Map.Navigator.Limiter = new ViewportLimiter();
        }
        private void LatTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void LngTextBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void ZoomTo_Click(object sender, EventArgs e)
        {
            bool latOk = LatTextBox.IsValid();
            bool lngOk = LngTextBox.IsValid();

            LatTextBox.BackColor = latOk ? Color.White : Color.MistyRose;
            LngTextBox.BackColor = lngOk ? Color.White : Color.MistyRose;

            if (latOk && lngOk)
            {
                var point = SphericalMercator.FromLonLat(
                    float.Parse(LngTextBox.Text, CultureInfo.InvariantCulture),
                    float.Parse(LatTextBox.Text, CultureInfo.InvariantCulture)
                ).ToMPoint();

                mapControl1.Map.Navigator.CenterOn(point);
            }
        }
        private void Confirm_Click(object sender, EventArgs e)
        {
            if (!NewSlider.IsValid)
                MessageBox.Show("Set both corners before confirming");
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
