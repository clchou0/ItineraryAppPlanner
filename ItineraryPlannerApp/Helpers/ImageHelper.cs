using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Helpers
{
    public static class ImageHelper
    {
        public static Image? LoadImage(string? imagePath)
        {
            if (string.IsNullOrWhiteSpace(imagePath)) return null;

            string fullPath = Path.Combine(Application.StartupPath, imagePath);

            if (!File.Exists(fullPath))
            {
                return null;
            }

            return Image.FromFile(fullPath);
        }
    }
}
