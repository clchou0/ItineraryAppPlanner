namespace ItineraryPlannerApp.Forms.CityForm
{
    partial class CityDetailsEditor
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
            CityLabel = new Label();
            CityNameBox = new TextBox();
            DescriptionBox = new TextBox();
            DescriptionLabel = new Label();
            CountryBox = new TextBox();
            CountryLabel = new Label();
            ChangeMapButton = new Button();
            SaveButton = new Button();
            ImageLabel = new Label();
            PickImageButton = new Button();
            PreviewImageButton = new Button();
            CancelButton = new Button();
            SuspendLayout();
            // 
            // CityLabel
            // 
            CityLabel.AutoSize = true;
            CityLabel.Location = new Point(26, 24);
            CityLabel.Name = "CityLabel";
            CityLabel.Size = new Size(85, 20);
            CityLabel.TabIndex = 0;
            CityLabel.Text = "City Name: ";
            // 
            // CityNameBox
            // 
            CityNameBox.Location = new Point(125, 24);
            CityNameBox.Name = "CityNameBox";
            CityNameBox.Size = new Size(192, 27);
            CityNameBox.TabIndex = 1;
            CityNameBox.TextChanged += CityNameBox_TextChanged;
            // 
            // DescriptionBox
            // 
            DescriptionBox.Location = new Point(125, 159);
            DescriptionBox.Multiline = true;
            DescriptionBox.Name = "DescriptionBox";
            DescriptionBox.Size = new Size(1047, 485);
            DescriptionBox.TabIndex = 3;
            DescriptionBox.TextChanged += DescriptionBox_TextChanged_1;
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(26, 162);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(89, 20);
            DescriptionLabel.TabIndex = 2;
            DescriptionLabel.Text = "Description ";
            // 
            // CountryBox
            // 
            CountryBox.Location = new Point(125, 69);
            CountryBox.Name = "CountryBox";
            CountryBox.Size = new Size(192, 27);
            CountryBox.TabIndex = 5;
            CountryBox.TextChanged += CountryBox_TextChanged;
            // 
            // CountryLabel
            // 
            CountryLabel.AutoSize = true;
            CountryLabel.Location = new Point(26, 72);
            CountryLabel.Name = "CountryLabel";
            CountryLabel.Size = new Size(67, 20);
            CountryLabel.TabIndex = 4;
            CountryLabel.Text = "Country: ";
            // 
            // ChangeMapButton
            // 
            ChangeMapButton.Location = new Point(26, 650);
            ChangeMapButton.Name = "ChangeMapButton";
            ChangeMapButton.Size = new Size(174, 29);
            ChangeMapButton.TabIndex = 6;
            ChangeMapButton.Text = "Change Map Settings";
            ChangeMapButton.UseVisualStyleBackColor = true;
            ChangeMapButton.Click += ChangeMapButton_Click;
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(1003, 650);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 7;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // ImageLabel
            // 
            ImageLabel.AutoSize = true;
            ImageLabel.Location = new Point(26, 115);
            ImageLabel.Name = "ImageLabel";
            ImageLabel.Size = new Size(58, 20);
            ImageLabel.TabIndex = 8;
            ImageLabel.Text = "Image: ";
            // 
            // PickImageButton
            // 
            PickImageButton.Location = new Point(125, 111);
            PickImageButton.Name = "PickImageButton";
            PickImageButton.Size = new Size(94, 29);
            PickImageButton.TabIndex = 9;
            PickImageButton.Text = "Pick Image";
            PickImageButton.UseVisualStyleBackColor = true;
            // 
            // PreviewImageButton
            // 
            PreviewImageButton.Location = new Point(240, 111);
            PreviewImageButton.Name = "PreviewImageButton";
            PreviewImageButton.Size = new Size(77, 29);
            PreviewImageButton.TabIndex = 10;
            PreviewImageButton.Text = "Preview";
            PreviewImageButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(1103, 650);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(94, 29);
            CancelButton.TabIndex = 12;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // CityDetailsEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(CancelButton);
            Controls.Add(PreviewImageButton);
            Controls.Add(PickImageButton);
            Controls.Add(ImageLabel);
            Controls.Add(SaveButton);
            Controls.Add(ChangeMapButton);
            Controls.Add(CountryBox);
            Controls.Add(CountryLabel);
            Controls.Add(DescriptionBox);
            Controls.Add(DescriptionLabel);
            Controls.Add(CityNameBox);
            Controls.Add(CityLabel);
            Name = "CityDetailsEditor";
            Size = new Size(1262, 709);
            Load += CityDetailsEditor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label CityLabel;
        private Label DescriptionLabel;
        private TextBox CityNameBox;
        private TextBox DescriptionBox;
        private TextBox CountryBox;
        private Label CountryLabel;
        private Button ChangeMapButton;
        private Button SaveButton;
        private Label ImageLabel;
        private Button PickImageButton;
        private Button PreviewImageButton;
        private Button CancelButton;
    }
}