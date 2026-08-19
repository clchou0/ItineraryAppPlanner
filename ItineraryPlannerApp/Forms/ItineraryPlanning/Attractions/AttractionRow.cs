using BruTile.Wms;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models;
using ItineraryPlannerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    public partial class AttractionRow : UserControl
    {
        public Attraction Attraction;
        private readonly ItineraryPlannerService _service;
        public bool IsAdmin;
        private readonly UserToggleComponent _component;

        // private readonly Attraction _attraction;
        public event Action<Attraction>? AddToItineraryRequested;

        public AttractionRow(ItineraryPlannerService service, Attraction attraction, bool isAdmin, UserToggleComponent component)
        {
            _service = service;
            Attraction = attraction;
            IsAdmin = isAdmin;

            InitializeComponent();

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

            _component = component;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (!IsAdmin) return;
            var editor = new AttractionDetailsEditor(_service, _component, Attraction, false);
            editor.BringToFront();
            editor.Dock = DockStyle.Fill;

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
            AddToItineraryRequested?.Invoke(Attraction);
        }

        private void TransportLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
