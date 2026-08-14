namespace ItineraryPlannerApp.CityForms
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
            headerPanel = new Panel();
            logoutButton = new Button();
            welcomeLabel = new Label();
            titleLabel = new Label();
            panel1 = new FlowLayoutPanel();
            label1 = new Label();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = SystemColors.Info;
            headerPanel.Controls.Add(logoutButton);
            headerPanel.Controls.Add(welcomeLabel);
            headerPanel.Controls.Add(titleLabel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(2);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1262, 44);
            headerPanel.TabIndex = 0;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(1159, 7);
            logoutButton.Margin = new Padding(2);
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
            welcomeLabel.Location = new Point(1071, 8);
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
            titleLabel.Location = new Point(16, 8);
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
            panel1.Margin = new Padding(2);
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
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1262, 753);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(headerPanel);
            Margin = new Padding(2);
            Name = "HomeForm";
            Text = "HomeForm";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
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
    }
}