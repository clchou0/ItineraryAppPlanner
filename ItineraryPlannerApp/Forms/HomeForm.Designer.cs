using Planner.WPF;

namespace ItineraryPlannerApp.Forms
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            headerPanel = new Panel();
            MenuButton = new Button();
            logoutButton = new Button();
            welcomeLabel = new Label();
            titleLabel = new Label();
            panel1 = new FlowLayoutPanel();
            label1 = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            buildItineraryToolStripMenuItem = new ToolStripMenuItem();
            itineraryHistoryToolStripMenuItem = new ToolStripMenuItem();
            headerPanel.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.Info;
            headerPanel.Controls.Add(MenuButton);
            headerPanel.Controls.Add(logoutButton);
            headerPanel.Controls.Add(welcomeLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1474, 70);
            headerPanel.TabIndex = 0;
            // 
            // MenuButton
            // 
            MenuButton.FlatAppearance.BorderSize = 0;
            MenuButton.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            MenuButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
            MenuButton.FlatStyle = FlatStyle.Flat;
            MenuButton.Font = new Font("Segoe UI", 10F);
            MenuButton.ForeColor = Color.DimGray;
            MenuButton.Location = new Point(7, 1);
            MenuButton.Margin = new Padding(5);
            MenuButton.Name = "MenuButton";
            MenuButton.Size = new Size(80, 74);
            MenuButton.TabIndex = 4;
            MenuButton.Text = "☰";
            MenuButton.UseVisualStyleBackColor = true;
            MenuButton.Click += MenuButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(1313, 13);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(150, 46);
            logoutButton.TabIndex = 3;
            logoutButton.Text = "Logout";
            logoutButton.UseVisualStyleBackColor = true;
            logoutButton.Click += logoutButton_Click;
            // 
            // welcomeLabel
            // 
            welcomeLabel.AutoSize = true;
            welcomeLabel.Font = new Font("Segoe UI", 10F);
            welcomeLabel.ForeColor = Color.DimGray;
            welcomeLabel.Location = new Point(1011, 17);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(133, 37);
            welcomeLabel.TabIndex = 2;
            welcomeLabel.Text = "Welcome,";
            welcomeLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleLabel.ForeColor = Color.Gray;
            titleLabel.Location = new Point(82, 13);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(233, 45);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Travel Planner";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Dock = DockStyle.Fill;
            panel1.FlowDirection = FlowDirection.TopDown;
            panel1.Location = new Point(0, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(1474, 759);
            panel1.TabIndex = 3;
            panel1.WrapContents = false;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(431, 99);
            label1.Name = "label1";
            label1.Size = new Size(589, 51);
            label1.TabIndex = 0;
            label1.Text = "Where is your next destination?";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { buildItineraryToolStripMenuItem, itineraryHistoryToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(258, 80);
            // 
            // buildItineraryToolStripMenuItem
            // 
            buildItineraryToolStripMenuItem.Name = "buildItineraryToolStripMenuItem";
            buildItineraryToolStripMenuItem.Size = new Size(257, 38);
            buildItineraryToolStripMenuItem.Text = "Build Itinerary";
            // 
            // itineraryHistoryToolStripMenuItem
            // 
            itineraryHistoryToolStripMenuItem.Name = "itineraryHistoryToolStripMenuItem";
            itineraryHistoryToolStripMenuItem.Size = new Size(257, 38);
            itineraryHistoryToolStripMenuItem.Text = "Itinerary History";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1474, 829);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(headerPanel);
            Name = "HomeForm";
            Text = "HomeForm";
            Load += HomeFormLoad;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel headerPanel;
        private Label titleLabel;
        private Button logoutButton;
        private Label welcomeLabel;
        private FlowLayoutPanel panel1;
        private Label label1;
        private Button MenuButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem buildItineraryToolStripMenuItem;
        private ToolStripMenuItem itineraryHistoryToolStripMenuItem;
    }
}