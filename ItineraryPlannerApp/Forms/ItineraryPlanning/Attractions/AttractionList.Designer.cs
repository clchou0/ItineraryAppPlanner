namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    partial class AttractionList
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
            flowLayoutPanel1 = new FlowLayoutPanel();
            SlidersPanel = new Panel();
            AddButton = new Button();
            flowLayoutPanel1.SuspendLayout();
            SlidersPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(SlidersPanel);
            flowLayoutPanel1.Location = new Point(20, 20);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1202, 608);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // SlidersPanel
            // 
            SlidersPanel.Controls.Add(AddButton);
            SlidersPanel.Location = new Point(3, 3);
            SlidersPanel.Name = "SlidersPanel";
            SlidersPanel.Size = new Size(1199, 88);
            SlidersPanel.TabIndex = 0;
            // 
            // AddButton
            // 
            AddButton.Location = new Point(1109, 32);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(87, 52);
            AddButton.TabIndex = 0;
            AddButton.Text = "Add Attraction";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AttractionList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel1);
            Name = "AttractionList";
            Size = new Size(1242, 628);
            Load += AttractionList_Load;
            flowLayoutPanel1.ResumeLayout(false);
            SlidersPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel SlidersPanel;
        private Button AddButton;
    }
}
