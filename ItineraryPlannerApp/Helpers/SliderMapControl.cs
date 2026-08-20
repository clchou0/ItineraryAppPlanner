using BruTile.Predefined;
using ItineraryPlannerApp.Models;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Limiting;
using Mapsui.Projections;
using Mapsui.Tiling.Layers;
using Mapsui.UI.WindowsForms;
using Mapsui.Widgets;
using Mapsui.Widgets.InfoWidgets;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Helpers
{
    public class SliderMapControl : MapControl
    {
        public MapSlider Slider = new MapSlider();
        static Dictionary<MapMode, ZoomConfig> config = new()
        {
            [MapMode.CityView] = new ZoomConfig(2, 200, 10),
            [MapMode.CityEdit] = new ZoomConfig(10, 200, 10),
            [MapMode.AttractionView] = new ZoomConfig(2, 2, 16),
            [MapMode.AttractionEdit] = new ZoomConfig(2, 100, 14),
        };
        private MemoryLayer? AttractionLayer;

        public SliderMapControl() : base()
        {
            InitializeComponent();
            LoggingWidget.ShowLoggingInMap = ActiveMode.No;
            var layer = new TileLayer(KnownTileSources.Create(KnownTileSource.OpenStreetMap));
            Map.Layers.Add(layer);
        }
        public void Initialize(MapSlider slider, MapMode mode)
        {
            Slider = slider;
            // Given zoom / defaut zoom / whatever
            MPoint center = Slider.ZoomPoint() ?? new MPoint(-118.2437, 34.0522);

            Map.Navigator.OverrideZoomBounds = new MMinMax(config[mode].MinZoom, config[mode].MaxZoom);
            Map.Navigator.CenterOnAndZoomTo(
                SphericalMercator.FromLonLat(center),
                Map.Navigator.Resolutions[config[mode].resIndex]
            );
            setPanBounds();
            Slider.Changed += setPanBounds;
            Map.Navigator.Limiter = new ViewportLimiter();

            addLines();
        }
        public void Initialize(MapMode mode, Location location)
        {
            if (mode == MapMode.AttractionView)
            {
                var centerPoint = location.LatLngMPoint();
                Map.Navigator.OverrideZoomBounds = new MMinMax(Map.Navigator.Resolutions[14], Map.Navigator.Resolutions[14]);
                Map.Navigator.CenterOnAndZoomTo(
                    centerPoint,
                    Map.Navigator.Resolutions[15]
                );
                // Not allowed to move
                Map.Navigator.OverridePanBounds = new MRect(centerPoint.X - 0.01, centerPoint.Y - 0.01, centerPoint.X + 0.01, centerPoint.Y + 0.01);
            }
        }
        private void addLines()
        {
            var vLine = new Panel { BackColor = Color.Black, Width = 1, Height = Height, Left = Width / 2, Top = 0 };
            var hLine = new Panel { BackColor = Color.Black, Height = 1, Width = Width, Left = 0, Top = Height / 2 };
            Controls.Add(vLine);
            Controls.Add(hLine);
            vLine.BringToFront();
            hLine.BringToFront();
        }
        private void setPanBounds()
        {
            this.Map.Navigator.OverridePanBounds = Slider.PanBoundCreator();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // SliderMapControl
            // 
            Name = "SliderMapControl";
            Size = new System.Drawing.Size(1271, 794);
            ResumeLayout(false);

        }
        public void LoadAttractionPins(List<Attraction> attractions, bool activate)
        {
            if (AttractionLayer is not null) Map.Layers.Remove(AttractionLayer);

            List<PointFeature> pins = new List<PointFeature>();
            foreach (Attraction a in attractions)
            {
                var pin = new PointFeature(a.Location.LatLngMPoint());
                pin.Styles.Add(new Mapsui.Styles.SymbolStyle
                {
                    SymbolScale = 0.8,
                    Fill = new Mapsui.Styles.Brush(Mapsui.Styles.Color.Blue),
                    SymbolType = Mapsui.Styles.SymbolType.Ellipse,
                    Outline = new Mapsui.Styles.Pen(Mapsui.Styles.Color.White, 1)
                });
                pins.Add(pin);
            }
            AttractionLayer = new MemoryLayer { Features = pins };
            Map.Layers.Add(AttractionLayer!);
        }
    }
    public enum MapMode { CityView, CityEdit, AttractionView, AttractionEdit };
    public readonly record struct ZoomConfig(double MinZoom, double MaxZoom, int resIndex);


}
