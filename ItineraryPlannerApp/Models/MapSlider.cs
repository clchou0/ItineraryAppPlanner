using System;
using System.Collections.Generic;
using System.Text;
using Mapsui;
using Mapsui.Projections;

namespace ItineraryPlannerApp.Models
{
    // Defining the max bounds and 
    public class MapSlider
    {
        // minX, minY: BOTTOM-LEFT
        // maxX, maxY: TOP-RIGHT
        private double? minX, minY, maxX, maxY, defX, defY;

        public bool IsValid =>
            minX != null && minY != null &&
            maxX != null && maxY != null &&
            defX != null && defY != null;
        public void SetBottomLeft(double? x, double? y)
        {
            minX = x;
            minY = y;
        }
        public void SetTopRight(double? x, double? y)
        {
            maxX = x;
            maxY = y;
        }
        public void SetDefault(double x, double y)
        {
            defX = x;
            defY = y;
        }
        public MRect PanBoundCreator()
        {
            var (_minX, _minY) = SphericalMercator.FromLonLat(minX ?? -180, minY ?? -90);
            var (_maxX, _maxY) = SphericalMercator.FromLonLat(maxX ?? 180, maxY ?? 90);
            return new MRect(_minX, _minY, _maxX, _maxY);
        }
        public MPoint? ZoomPoint()
        {
            return IsValid ? new MPoint(defX!.Value, defY!.Value) : null;
        }
        public override string ToString()
        {
            return $"Bottom Left: ({minX}, {minY})\nTop Right: ({maxX}, {maxY})\nDefault: ({defX}, {defY})";
        }
    }
}
