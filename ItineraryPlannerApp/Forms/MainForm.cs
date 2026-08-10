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
        public MainForm()
        {
            InitializeComponent();

            ShowPage(new LoginForm(this));
        }

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
    }
}
