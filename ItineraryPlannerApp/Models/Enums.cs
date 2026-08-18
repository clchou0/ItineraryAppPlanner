using System;
using System.Collections.Generic;
using System.Text;

namespace ItineraryPlannerApp.Models
{
    public enum UserRole { Admin, User };
    public enum AttractionCategory { ThemePark, Landmark };
    public enum TransportType { None, Metro, Train, Car, Cab, Ferry, LightRail, Bus }

    public enum ItineraryStatus { Draft, History }
}
