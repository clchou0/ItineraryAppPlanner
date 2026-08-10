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
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.FlowDirection = FlowDirection.TopDown;
            panel1.Location = new Point(0, 213);
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