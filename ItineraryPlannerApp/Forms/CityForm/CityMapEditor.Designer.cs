using ItineraryPlannerApp.Helpers;
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
            mapControl1 = new SliderMapControl();
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
            DefaultZoomButton = new Button();
            SuspendLayout();
            // 
            // DefaultZoom
            // 
            DefaultZoom.Location = new Point(1108, 341);
            DefaultZoom.Name = "DefaultZoom";
            DefaultZoom.Size = new Size(110, 50);
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
            mapControl1.Size = new Size(1242, 628);
            mapControl1.TabIndex = 3;
            mapControl1.Load += mapControl1_Load;
            // 
            // LockTopRight
            // 
            LockTopRight.Location = new Point(1108, 229);
            LockTopRight.Name = "LockTopRight";
            LockTopRight.Size = new Size(110, 50);
            LockTopRight.TabIndex = 5;
            LockTopRight.Text = "Lock Top Right";
            LockTopRight.UseVisualStyleBackColor = true;
            LockTopRight.Click += LockTopRight_Click;
            // 
            // LockBottomLeft
            // 
            LockBottomLeft.Location = new Point(1108, 285);
            LockBottomLeft.Name = "LockBottomLeft";
            LockBottomLeft.Size = new Size(110, 50);
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
            Confirm.Location = new Point(1108, 453);
            Confirm.Name = "Confirm";
            Confirm.Size = new Size(110, 30);
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
            ResetButton.Location = new Point(1108, 193);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new Size(110, 30);
            ResetButton.TabIndex = 15;
            ResetButton.Text = "Reset";
            ResetButton.UseVisualStyleBackColor = true;
            ResetButton.Click += ResetButton_Click;
            // 
            // DefaultZoomButton
            // 
            DefaultZoomButton.Location = new Point(1108, 397);
            DefaultZoomButton.Name = "DefaultZoomButton";
            DefaultZoomButton.Size = new Size(110, 50);
            DefaultZoomButton.TabIndex = 16;
            DefaultZoomButton.Text = "Zoom to Default";
            DefaultZoomButton.UseVisualStyleBackColor = true;
            DefaultZoomButton.Click += DefaultZoomButton_Click;
            // 
            // CityMapEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(DefaultZoomButton);
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
            Size = new Size(1242, 628);
            Load += CityMapEditor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button DefaultZoom;
        private SliderMapControl mapControl1;
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
        private Button DefaultZoomButton;
    }
}
