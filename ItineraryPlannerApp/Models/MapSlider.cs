using System;
using System.Collections.Generic;
using System.Text;
using Mapsui;
using Mapsui.Projections;

namespace ItineraryPlannerApp.Models
{
    // Defining the Max bounds and 
    public class MapSlider
    {
        public double? MaxX { get; private set; }
        public double? MaxY { get; private set; }
        public double? MinX { get; private set; }
        public double? MinY { get; private set; }
        public double? DefX { get; private set; }
        public double? DefY { get; private set; }
        private bool MaxSet => MaxX != null && MaxY != null;
        private bool MinSet => MinX != null && MinY != null;
        public MapSlider(double maxX, double maxY, double minX, double minY, double defX, double defY)
        {
            MaxX = maxX;
            MaxY = maxY;
            MinX = minX;
            MinY = minY;
            DefX = defX;
            DefY = defY;
        }
        public MapSlider() { }

        public bool IsValid =>
            MaxSet && MinSet &&
            DefX != null && DefY != null &&
            MaxX >= DefX && DefX >= MinX &&
            MaxY >= DefY && DefY >= MinY;

        // Check if target zoom point is valid within the bounds of the map
        public bool InRange(double x, double y)
        {
            return ((!MaxSet || (MaxX >= x && MaxY >= y)) && (!MinSet || (x >= MinX && y >= MinY)));
        }
        public bool SetBottomLeft(double? x, double? y)
        {
            if (!MaxSet || (x < MaxX && y < MaxY))
            {
                MinX = x;
                MinY = y;
                return true;
            }
            return false;
        }
        public bool SetTopRight(double? x, double? y)
        {
            if (!MinSet || (x > MinX && y > MinY))
            {
                MaxX = x;
                MaxY = y;
                return true;
            }
            return false;
        }
        public void SetDefault(double x, double y)
        {
            DefX = x;
            DefY = y;
        }
        public MRect PanBoundCreator()
        {
            var (_minX, _minY) = SphericalMercator.FromLonLat(MinX ?? -180, MinY ?? -90);
            var (_maxX, _maxY) = SphericalMercator.FromLonLat(MaxX ?? 180, MaxY ?? 90);
            return new MRect(_minX, _minY, _maxX, _maxY);
        }
        public MPoint? ZoomPoint()
        {
            return IsValid ? new MPoint(DefX!.Value, DefY!.Value) : null;
        }
        public override string ToString()
        {
            return $"Bottom Left: ({MinX}, {MinY})\nTop Right: ({MaxX}, {MaxY})\nDefault: ({DefX}, {DefY})";
        }
    }
}
