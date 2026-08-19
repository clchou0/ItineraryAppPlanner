using BruTile.Predefined;
using ItineraryPlannerApp.Models;
using Mapsui;
using Mapsui.Limiting;
using Mapsui.Projections;
using Mapsui.Tiling.Layers;
using Mapsui.UI;
using Mapsui.UI.WindowsForms;
using Mapsui.Widgets;
using Mapsui.Widgets.InfoWidgets;

namespace ItineraryPlannerApp.Helpers
{
    public class SliderMapControl : MapControl
    {
        public MapSlider Slider = new MapSlider();
        static Dictionary<MapMode, ZoomConfig> config = new()
        {
            [MapMode.CityView] = new ZoomConfig(2, 200),
            [MapMode.CityEdit] = new ZoomConfig(10, 200),
            [MapMode.AttractionView] = new ZoomConfig(2, 2),
            [MapMode.AttractionEdit] = new ZoomConfig(2, 100),
        };

        public SliderMapControl() { }
        public void Initialize(MapSlider slider, MapMode mode)
        {
            Slider = slider;
            LoggingWidget.ShowLoggingInMap = ActiveMode.No;
            var layer = new TileLayer(KnownTileSources.Create(KnownTileSource.OpenStreetMap));
            Map.Layers.Add(layer);

            // Given zoom / defaut zoom / whatever
            MPoint center = Slider.ZoomPoint() ?? new MPoint(-118.2437, 34.0522);

            Map.Navigator.OverrideZoomBounds = new MMinMax(config[mode].MinZoom, config[mode].MaxZoom);
            Map.Navigator.CenterOnAndZoomTo(
                SphericalMercator.FromLonLat(center),
                Map.Navigator.Resolutions[2]
            );

            setPanBounds();
            Slider.Changed += setPanBounds;
            Map.Navigator.Limiter = new ViewportLimiter();
        }
        public SliderMapControl(MapMode mode, Location location)
        {
            if (mode == MapMode.AttractionView)
            {
                var centerPoint = SphericalMercator.FromLonLat(location.ToMPoint());
                Map.Navigator.CenterOnAndZoomTo(
                    SphericalMercator.FromLonLat(centerPoint),
                    Map.Navigator.Resolutions[Map.Navigator.Resolutions.Count - 1]
                );
                Map.Navigator.OverrideZoomBounds = new MMinMax(config[mode].MinZoom, config[mode].MaxZoom);
                // Not allowed to move
                Map.Navigator.OverridePanBounds = new MRect(centerPoint.X, centerPoint.Y, centerPoint.X, centerPoint.Y);
            }
        }
        private void setPanBounds()
        {
            MessageBox.Show("PANBOUNDSSET");
            this.Map.Navigator.OverridePanBounds = Slider.PanBoundCreator();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // SliderMapControl
            // 
            Name = "SliderMapControl";
            Size = new Size(1474, 763);
            ResumeLayout(false);

        }
    }
    public enum MapMode { CityView, CityEdit, AttractionView, AttractionEdit };
    public readonly record struct ZoomConfig(double MinZoom, double MaxZoom);


}
