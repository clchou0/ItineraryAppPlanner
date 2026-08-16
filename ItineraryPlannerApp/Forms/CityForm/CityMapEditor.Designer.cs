namespace ItineraryPlannerApp.Forms.CityForm
{
    partial class CityMapEditor
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
            DefaultZoom = new Button();
            mapControl1 = new Mapsui.UI.WindowsForms.MapControl();
            LockTopRight = new Button();
            LockBottomLeft = new Button();
            LatLabel = new Label();
            LngLabel = new Label();
            RightToolBarNote = new Label();
            ZoomTo = new Button();
            Confirm = new Button();
            LatTextBox = new CoordinateTextBox();
            LngTextBox = new CoordinateTextBox();
            TitleLabel = new Label();
            ResetButton = new Button();
            SuspendLayout();
            // 
            // DefaultZoom
            // 
            DefaultZoom.Location = new Point(1082, 356);
            DefaultZoom.Name = "DefaultZoom";
            DefaultZoom.Size = new Size(111, 51);
            DefaultZoom.TabIndex = 2;
            DefaultZoom.Text = "Set Current as Default Zoom";
            DefaultZoom.UseVisualStyleBackColor = true;
            DefaultZoom.Click += DefaultZoom_Click;
            // 
            // mapControl1
            // 
            mapControl1.AutoSize = true;
            mapControl1.BackColor = Color.White;
            mapControl1.Dock = DockStyle.Fill;
            mapControl1.Location = new Point(0, 0);
            mapControl1.Name = "mapControl1";
            mapControl1.Size = new Size(1206, 712);
            mapControl1.TabIndex = 3;
            mapControl1.Load += mapControl1_Load;
            // 
            // LockTopRight
            // 
            LockTopRight.Location = new Point(1083, 245);
            LockTopRight.Name = "LockTopRight";
            LockTopRight.Size = new Size(111, 50);
            LockTopRight.TabIndex = 5;
            LockTopRight.Text = "Lock Top Right";
            LockTopRight.UseVisualStyleBackColor = true;
            LockTopRight.Click += LockTopRight_Click;
            // 
            // LockBottomLeft
            // 
            LockBottomLeft.Location = new Point(1082, 301);
            LockBottomLeft.Name = "LockBottomLeft";
            LockBottomLeft.Size = new Size(111, 49);
            LockBottomLeft.TabIndex = 7;
            LockBottomLeft.Text = "Lock Bottom Left";
            LockBottomLeft.UseVisualStyleBackColor = true;
            LockBottomLeft.Click += LockBottomLeft_Click;
            // 
            // LatLabel
            // 
            LatLabel.AutoSize = true;
            LatLabel.Location = new Point(14, 80);
            LatLabel.Name = "LatLabel";
            LatLabel.Size = new Size(70, 20);
            LatLabel.TabIndex = 10;
            LatLabel.Text = "Latitude: ";
            // 
            // LngLabel
            // 
            LngLabel.AutoSize = true;
            LngLabel.Location = new Point(198, 80);
            LngLabel.Name = "LngLabel";
            LngLabel.Size = new Size(83, 20);
            LngLabel.TabIndex = 11;
            LngLabel.Text = "Longitude: ";
            // 
            // RightToolBarNote
            // 
            RightToolBarNote.Location = new Point(0, 0);
            RightToolBarNote.Name = "RightToolBarNote";
            RightToolBarNote.Size = new Size(100, 23);
            RightToolBarNote.TabIndex = 0;
            RightToolBarNote.Text = "Set up city map";
            // 
            // ZoomTo
            // 
            ZoomTo.Location = new Point(415, 80);
            ZoomTo.Name = "ZoomTo";
            ZoomTo.Size = new Size(94, 29);
            ZoomTo.TabIndex = 12;
            ZoomTo.Text = "Zoom To";
            ZoomTo.UseVisualStyleBackColor = true;
            ZoomTo.Click += ZoomTo_Click;
            // 
            // Confirm
            // 
            Confirm.Location = new Point(1082, 413);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(111, 40);
            Confirm.TabIndex = 13;
            Confirm.Text = "Confirm";
            Confirm.UseVisualStyleBackColor = true;
            Confirm.Click += Confirm_Click;
            // 
            // LatTextBox
            // 
            LatTextBox.Location = new Point(90, 77);
            LatTextBox.Name = "LatTextBox";
            LatTextBox.Size = new Size(100, 27);
            LatTextBox.TabIndex = 8;
            // 
            // LngTextBox
            // 
            LngTextBox.Location = new Point(287, 76);
            LngTextBox.Name = "LngTextBox";
            LngTextBox.Size = new Size(100, 27);
            LngTextBox.TabIndex = 11;
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 15F);
            TitleLabel.Location = new Point(14, 23);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(0, 35);
            TitleLabel.TabIndex = 14;
            // 
            // ResetButton
            // 
            ResetButton.Location = new Point(1083, 210);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(110, 29);
            ResetButton.TabIndex = 15;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // CityMapEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1206, 712);
            Controls.Add(ResetButton);
            Controls.Add(TitleLabel);
            Controls.Add(LockBottomLeft);
            Controls.Add(LockTopRight);
            Controls.Add(DefaultZoom);
            Controls.Add(ZoomTo);
            Controls.Add(LatLabel);
            Controls.Add(Confirm);
            Controls.Add(LngLabel);
            Controls.Add(LatTextBox);
            Controls.Add(LngTextBox);
            Controls.Add(mapControl1);
            Name = "CityMapEditor";
            Load += CityMapEditor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button DefaultZoom;
        private Mapsui.UI.WindowsForms.MapControl mapControl1;
        private Button LockTopRight;
        private Button LockBottomLeft;
        private CoordinateTextBox LatTextBox;
        private CoordinateTextBox LngTextBox;
        private Label LatLabel;
        private Label LngLabel;
        private Label RightToolBarNote;
        private Button ZoomTo;
        private Button Confirm;
        private Label TitleLabel;
        private Button ResetButton;
    }
}
