namespace ItineraryPlannerApp.Forms.CityForm
{
    partial class CityCard
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProceedButton = new Button();
            pictureBox1 = new PictureBox();
            NameLabel = new Label();
            CountryLabel = new Label();
            button2 = new Button();
            EditButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // ProceedButton
            // 
            ProceedButton.Location = new Point(347, 296);
            ProceedButton.Name = "ProceedButton";
            ProceedButton.Size = new Size(119, 29);
            ProceedButton.TabIndex = 12;
            ProceedButton.Text = "Plan next trip..";
            ProceedButton.UseVisualStyleBackColor = true;
            ProceedButton.Click += ProceedButton_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(480, 270);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            // 
            // NameLabel
            // 
            NameLabel.BackColor = SystemColors.Info;
            NameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(0, 273);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(480, 42);
            NameLabel.TabIndex = 7;
            NameLabel.Text = "Sydney";
            NameLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CountryLabel
            // 
            CountryLabel.BackColor = SystemColors.Info;
            CountryLabel.Font = new Font("Segoe UI", 12F);
            CountryLabel.ForeColor = SystemColors.ControlDarkDark;
            CountryLabel.Location = new Point(0, 315);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(480, 27);
            CountryLabel.TabIndex = 8;
            CountryLabel.Text = "Australia";
            CountryLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            button2.Location = new Point(818, 211);
            button2.Name = "button2";
            button2.Size = new Size(0, 0);
            button2.TabIndex = 10;
            button2.Text = "E";
            button2.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            EditButton.BackColor = SystemColors.HotTrack;
            EditButton.Font = new Font("Segoe UI", 10F);
            EditButton.ForeColor = SystemColors.ButtonFace;
            EditButton.Location = new Point(445, 0);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(35, 35);
            EditButton.TabIndex = 11;
            EditButton.Text = "E";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += EditButton_Click;
            // 
            // CityCard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(ProceedButton);
            Controls.Add(EditButton);
            Controls.Add(button2);
            Controls.Add(CountryLabel);
            Controls.Add(NameLabel);
            Controls.Add(pictureBox1);
            Name = "CityCard";
            Size = new Size(478, 344);
            Load += CityCard_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button ProceedButton;
        private PictureBox pictureBox1;
        private Label NameLabel;
        private Label CountryLabel;
        private Button button2;
        private Button EditButton;
    }
}
