namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    partial class AttractionRow
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
            pictureBox1 = new PictureBox();
            NameLabel = new Label();
            AreaLabel = new Label();
            DescriptionText = new Label();
            DetailsButton = new Button();
            AddButton = new Button();
            EditButton = new Button();
            DeleteButton = new Button();
            TransportLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(3, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(172, 172);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // NameLabel
            // 
            NameLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLabel.Location = new Point(181, 3);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(683, 39);
            NameLabel.TabIndex = 1;
            NameLabel.Text = "Sydney Opera House";
            // 
            // AreaLabel
            // 
            AreaLabel.AutoSize = true;
            AreaLabel.Font = new Font("Segoe UI", 12F);
            AreaLabel.Location = new Point(181, 42);
            AreaLabel.Name = "AreaLabel";
            AreaLabel.Size = new Size(61, 28);
            AreaLabel.TabIndex = 2;
            AreaLabel.Text = "Area: ";
            // 
            // DescriptionText
            // 
            DescriptionText.AutoSize = true;
            DescriptionText.Font = new Font("Segoe UI", 12F);
            DescriptionText.Location = new Point(181, 70);
            DescriptionText.Name = "DescriptionText";
            DescriptionText.Size = new Size(125, 28);
            DescriptionText.TabIndex = 3;
            DescriptionText.Text = "Lorem ipsum";
            // 
            // DetailsButton
            // 
            DetailsButton.Location = new Point(1027, 136);
            DetailsButton.Name = "DetailsButton";
            DetailsButton.Size = new Size(135, 29);
            DetailsButton.TabIndex = 5;
            DetailsButton.Text = "More Details..";
            DetailsButton.UseVisualStyleBackColor = true;
            DetailsButton.Click += DetailsButton_Click;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(1027, 101);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(135, 29);
            AddButton.TabIndex = 6;
            AddButton.Text = "Add to Itinerary";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.BackColor = SystemColors.HotTrack;
            EditButton.Font = new Font("Segoe UI", 10F);
            EditButton.ForeColor = SystemColors.ButtonFace;
            EditButton.Location = new Point(1083, 3);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(35, 35);
            EditButton.TabIndex = 12;
            EditButton.Text = "E";
            EditButton.UseVisualStyleBackColor = false;
            EditButton.Click += EditButton_Click;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.Red;
            DeleteButton.Font = new Font("Segoe UI", 10F);
            DeleteButton.ForeColor = SystemColors.ButtonFace;
            DeleteButton.Location = new Point(1124, 3);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(35, 35);
            DeleteButton.TabIndex = 13;
            DeleteButton.Text = "D";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // TransportLabel
            // 
            TransportLabel.AutoSize = true;
            TransportLabel.Font = new Font("Segoe UI", 12F);
            TransportLabel.Location = new Point(181, 133);
            TransportLabel.Name = "TransportLabel";
            TransportLabel.Size = new Size(125, 28);
            TransportLabel.TabIndex = 14;
            TransportLabel.Text = "Lorem ipsum";
            TransportLabel.Click += TransportLabel_Click;
            // 
            // AttractionRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(TransportLabel);
            Controls.Add(DeleteButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(DetailsButton);
            Controls.Add(DescriptionText);
            Controls.Add(AreaLabel);
            Controls.Add(NameLabel);
            Controls.Add(pictureBox1);
            Name = "AttractionRow";
            Size = new Size(1162, 173);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label NameLabel;
        private Label AreaLabel;
        private Label DescriptionText;
        private Button DetailsButton;
        private Button AddButton;
        private Button EditButton;
        private Button DeleteButton;
        private Label TransportLabel;
    }
}
