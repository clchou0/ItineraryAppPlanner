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
            myItinerariesToolStripMenuItem = new ToolStripMenuItem();
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
            headerPanel.Margin = new Padding(2, 2, 2, 2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1262, 44);
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
            MenuButton.Location = new Point(4, 1);
            MenuButton.Name = "MenuButton";
            MenuButton.Size = new Size(49, 46);
            MenuButton.TabIndex = 4;
            MenuButton.Text = "☰";
            MenuButton.UseVisualStyleBackColor = true;
            MenuButton.Click += MenuButton_Click;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(1159, 8);
            logoutButton.Margin = new Padding(2, 2, 2, 2);
            logoutButton.Name = "logoutButton";
            logoutButton.Size = new Size(92, 29);
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
            welcomeLabel.Location = new Point(1071, 10);
            welcomeLabel.Margin = new Padding(2, 0, 2, 0);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(84, 23);
            welcomeLabel.TabIndex = 2;
            welcomeLabel.Text = "Welcome,";
            welcomeLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            titleLabel.ForeColor = Color.Gray;
            titleLabel.Location = new Point(50, 8);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(147, 28);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Travel Planner";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Dock = DockStyle.Fill;
            panel1.FlowDirection = FlowDirection.TopDown;
            panel1.Location = new Point(0, 44);
            panel1.Margin = new Padding(2, 2, 2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1262, 709);
            panel1.TabIndex = 3;
            panel1.WrapContents = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(265, 62);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(377, 32);
            label1.TabIndex = 0;
            label1.Text = "Where is your next destination?";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(32, 32);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { buildItineraryToolStripMenuItem, myItinerariesToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(184, 52);
            // 
            // buildItineraryToolStripMenuItem
            // 
            buildItineraryToolStripMenuItem.Name = "buildItineraryToolStripMenuItem";
            buildItineraryToolStripMenuItem.Size = new Size(300, 38);
            buildItineraryToolStripMenuItem.Size = new Size(183, 24);
            buildItineraryToolStripMenuItem.Text = "Build Itinerary";
            // 
            // myItinerariesToolStripMenuItem
            // 
            itineraryHistoryToolStripMenuItem.Name = "itineraryHistoryToolStripMenuItem";
            itineraryHistoryToolStripMenuItem.Size = new Size(183, 24);
            itineraryHistoryToolStripMenuItem.Text = "Itinerary History";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1262, 753);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(headerPanel);
            Margin = new Padding(2, 2, 2, 2);
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
        private ToolStripMenuItem myItinerariesToolStripMenuItem;
    }
}