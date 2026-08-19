using ItineraryPlannerApp.Helpers;
using ItineraryPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning
{
    public partial class CityMap : UserControl
    {
        private MapSlider _slider;
        private readonly UserToggleComponent _component;
        public CityMap(MapSlider slider, UserToggleComponent component)
        {
            InitializeComponent();
            _slider = slider;
            _component = component;
            sliderMapControl1.Initialize(_slider, MapMode.CityView);
            ReloadAttractionList();
        }
        public void ReloadAttractionList()
        {
            sliderMapControl1.LoadAttractionPins(_component.AllAttractions, true);
        }
    }
}
