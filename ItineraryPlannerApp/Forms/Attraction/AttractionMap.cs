using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Forms.Attraction
{
    // Small map of attraction's surrounding
    public partial class AttractionMap : UserControl
    {
        Location Location;
        public AttractionMap(Location _location)
        {
            Location = _location;
            InitializeComponent();
        }

        private void AttractionMap_Load(object sender, EventArgs e)
        {

        }
    }
}
