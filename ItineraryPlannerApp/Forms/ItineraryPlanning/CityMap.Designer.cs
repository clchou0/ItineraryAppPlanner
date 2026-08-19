namespace ItineraryPlannerApp.Forms.ItineraryPlanning
{
    partial class CityMap
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
            sliderMapControl1 = new ItineraryPlannerApp.Helpers.SliderMapControl();
            SuspendLayout();
            // 
            // sliderMapControl1
            // 
            sliderMapControl1.AutoSize = true;
            sliderMapControl1.BackColor = Color.White;
            sliderMapControl1.Dock = DockStyle.Fill;
            sliderMapControl1.Location = new Point(0, 0);
            sliderMapControl1.Name = "sliderMapControl1";
            sliderMapControl1.Size = new Size(1242, 628);
            sliderMapControl1.TabIndex = 0;
            // 
            // CityMap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(sliderMapControl1);
            Name = "CityMap";
            Size = new Size(1242, 628);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Helpers.SliderMapControl sliderMapControl1;
    }
}
