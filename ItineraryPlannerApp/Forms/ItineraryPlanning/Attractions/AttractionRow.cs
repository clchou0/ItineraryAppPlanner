using ItineraryPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ItineraryPlannerApp.Models;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class AttractionRow : UserControl
    {
        public Attraction Attraction;
        public bool IsAdmin;
        public AttractionRow(Attraction attraction, bool isAdmin)
        {
            InitializeComponent();
            Attraction = attraction;
            IsAdmin = isAdmin;

            NameLabel.Text = Attraction.AttractionName;
            AreaLabel.Text = $"Area: {Attraction.Area}";
            DescriptionText.Text = Attraction.ShortDesctiption;
            TransportLabel.Text = $"Access: {Attraction.TransportMethods}";

            if (isAdmin)
            {
                AddButton.Visible = false;
                AddButton.Enabled = false;
            }
            else
            {
                EditButton.Visible = false;
                DeleteButton.Visible = false;
                EditButton.Enabled = false;
                DeleteButton.Enabled = false;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!IsAdmin) return;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (!IsAdmin) return;
        }

        private void DetailsButton_Click(object sender, EventArgs e)
        {
            
        }

        private void AddButton_Click(object sender, EventArgs e)
        {

        }

        private void TransportLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
