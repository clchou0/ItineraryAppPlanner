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
            headerPanel = new Panel();
            logoutButton = new Button();
            welcomeLabel = new Label();
            titleLabel = new Label();
            contentPanel = new Panel();
            cityLabel = new Label();
            cityImage = new PictureBox();
            label1 = new Label();
            headerPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cityImage).BeginInit();
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
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1474, 70);
            headerPanel.TabIndex = 0;
            // 
            // logoutButton
            // 
            logoutButton.Location = new Point(1313, 12);
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
            welcomeLabel.Location = new Point(985, 17);
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
            titleLabel.Location = new Point(26, 12);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(233, 45);
            titleLabel.TabIndex = 1;
            titleLabel.Text = "Travel Planner";
            // 
            // contentPanel
            // 
            contentPanel.AutoScroll = true;
            contentPanel.Controls.Add(cityLabel);
            contentPanel.Controls.Add(cityImage);
            contentPanel.Controls.Add(label1);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 70);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1474, 759);
            contentPanel.TabIndex = 1;
            // 
            // cityLabel
            // 
            cityLabel.AutoSize = true;
            cityLabel.BackColor = Color.Transparent;
            cityLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            cityLabel.ForeColor = SystemColors.ControlLightLight;
            cityLabel.Location = new Point(610, 443);
            cityLabel.Name = "cityLabel";
            cityLabel.Size = new Size(252, 86);
            cityLabel.TabIndex = 2;
            cityLabel.Text = "Sydney";
            // 
            // cityImage
            // 
            cityImage.Location = new Point(90, 154);
            cityImage.Name = "cityImage";
            cityImage.Size = new Size(1280, 388);
            cityImage.TabIndex = 1;
            cityImage.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(413, 67);
            label1.Name = "label1";
            label1.Size = new Size(589, 51);
            label1.TabIndex = 0;
            label1.Text = "Where is your next destination?";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 829);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            Name = "HomeForm";
            Text = "HomeForm";
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cityImage).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel headerPanel;
        private Label titleLabel;
        private Button logoutButton;
        private Label welcomeLabel;
        private Panel contentPanel;
        private Label label1;
        private PictureBox cityImage;
        private Label cityLabel;
    }
}