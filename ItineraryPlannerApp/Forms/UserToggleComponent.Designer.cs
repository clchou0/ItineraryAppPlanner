namespace ItineraryPlannerApp.Forms
{
    partial class UserToggleComponent
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
            panel1 = new Panel();
            button1 = new Button();
            label4 = new Label();
            CityMapTag = new Label();
            ItineraryPlannerTag = new Label();
            AttractionListTag = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label4);
            panel1.Location = new Point(-1, 64);
            panel1.Name = "panel1";
            panel1.Size = new Size(1260, 645);
            panel1.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(397, 117);
            button1.Name = "button1";
            button1.Size = new Size(8, 8);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveBorder;
            label4.Font = new Font("Segoe UI", 20F);
            label4.Location = new Point(509, 310);
            label4.Name = "label4";
            label4.Size = new Size(0, 46);
            label4.TabIndex = 3;
            // 
            // CityMapTag
            // 
            CityMapTag.BackColor = SystemColors.ButtonFace;
            CityMapTag.BorderStyle = BorderStyle.FixedSingle;
            CityMapTag.Font = new Font("Segoe UI", 10F);
            CityMapTag.Location = new Point(10, 32);
            CityMapTag.Name = "CityMapTag";
            CityMapTag.Size = new Size(200, 40);
            CityMapTag.TabIndex = 4;
            CityMapTag.Text = "City Map";
            CityMapTag.TextAlign = ContentAlignment.MiddleCenter;
            CityMapTag.Click += CityMapTag_Click;
            // 
            // ItineraryPlannerTag
            // 
            ItineraryPlannerTag.BackColor = SystemColors.ButtonFace;
            ItineraryPlannerTag.BorderStyle = BorderStyle.FixedSingle;
            ItineraryPlannerTag.Font = new Font("Segoe UI", 10F);
            ItineraryPlannerTag.Location = new Point(430, 32);
            ItineraryPlannerTag.Name = "ItineraryPlannerTag";
            ItineraryPlannerTag.Size = new Size(200, 46);
            ItineraryPlannerTag.TabIndex = 5;
            ItineraryPlannerTag.Text = "Itinerary Planner";
            ItineraryPlannerTag.TextAlign = ContentAlignment.MiddleCenter;
            ItineraryPlannerTag.Click += ItineraryPlannerTag_Click;
            // 
            // AttractionListTag
            // 
            AttractionListTag.BackColor = SystemColors.ButtonFace;
            AttractionListTag.BorderStyle = BorderStyle.FixedSingle;
            AttractionListTag.Font = new Font("Segoe UI", 10F);
            AttractionListTag.Location = new Point(220, 32);
            AttractionListTag.Name = "AttractionListTag";
            AttractionListTag.Size = new Size(200, 40);
            AttractionListTag.TabIndex = 6;
            AttractionListTag.Text = "Attractions List";
            AttractionListTag.TextAlign = ContentAlignment.MiddleCenter;
            AttractionListTag.Click += AttractionListTag_Click;
            // 
            // UserToggleComponent
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(AttractionListTag);
            Controls.Add(ItineraryPlannerTag);
            Controls.Add(CityMapTag);
            Name = "UserToggleComponent";
            Size = new Size(1262, 709);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label CityMapTag;
        private Label label4;
        private Label ItineraryPlannerTag;
        private Label AttractionListTag;
        private Button button1;
    }
}
