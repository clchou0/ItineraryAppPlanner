using ItineraryPlannerApp.Data;
using ItineraryPlannerApp.Data.Services;
using ItineraryPlannerApp.Models.Itinerary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ItineraryPlannerApp.Forms
{
    public partial class MainForm : Form
    {
        private readonly ItineraryPlannerService _service;
        private readonly EmailService _emailService;

        public MainForm(ItineraryPlannerService service, EmailService emailService)
        {
            _service = service;
            InitializeComponent();
            content.Padding = new Padding(10);
            ShowPage(new LoginForm(this));
            _emailService = emailService;
        }
        public ItineraryPlannerService Service { get { return _service; } }

        public EmailService EmailService { get { return _emailService; } }

        public void ShowPage(Form page)
        {
            content.Controls.Clear();

            page.TopLevel = false;
            page.FormBorderStyle = FormBorderStyle.None;
            page.Dock = DockStyle.Fill;

            content.Controls.Add(page);
            page.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void content_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
