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
    public class SliderMapControl: MapControl
    {
        public MapSlider Slider;
        static Dictionary<MapMode, ZoomConfig> config = new()
        {
            [MapMode.CityView] = new ZoomConfig(2, 200, 100),
            [MapMode.CityEdit] = new ZoomConfig(10, 200, 200),
            [MapMode.AttractionView] = new ZoomConfig(2, 2, 2),
            [MapMode.AttractionEdit] = new ZoomConfig(2, 100, 50),
        };

        public SliderMapControl() { }
        public SliderMapControl(MapSlider slider, MapMode mode, Location? location): base()
        {
            Slider = slider;
            LoggingWidget.ShowLoggingInMap = ActiveMode.No;
            var layer = new TileLayer(KnownTileSources.Create(KnownTileSource.OpenStreetMap));
            Map.Layers.Add(layer);

            // Given zoom / defaut zoom / whatever
            MPoint center = location?.ToMPoint() ?? Slider.ZoomPoint() ?? new MPoint(-118.2437, 34.0522);

            
            Map.Navigator.OverrideZoomBounds = new MMinMax(config[mode].MinZoom, config[mode].MaxZoom);
            Map.Navigator.CenterOnAndZoomTo(
                SphericalMercator.FromLonLat(center),
                Map.Navigator.Resolutions[config[mode].InitialResolutionIndex]
            );

            setPanBounds();
            Slider.Changed += setPanBounds;
            Map.Navigator.Limiter = new ViewportLimiter();
        }
        private void setPanBounds()
        {
            this.Map.Navigator.OverridePanBounds = Slider.PanBoundCreator();
        }
    }
    public enum MapMode { CityView, CityEdit, AttractionView, AttractionEdit };
    public readonly record struct ZoomConfig(double MinZoom, double MaxZoom, int InitialResolutionIndex);


}
