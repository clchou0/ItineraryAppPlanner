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
            flowLayoutPanel2 = new FlowLayoutPanel();
            SlidersPanel.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Location = new Point(20, 20);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1202, 608);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // SlidersPanel
            // 
            SlidersPanel.Controls.Add(AddButton);
            SlidersPanel.Location = new Point(20, 20);
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
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.AutoScroll = true;
            flowLayoutPanel2.Location = new Point(20, 110);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1199, 518);
            flowLayoutPanel2.TabIndex = 0;
            // 
            // AttractionList
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel2);
            Controls.Add(SlidersPanel);
            Controls.Add(flowLayoutPanel1);
            Name = "AttractionList";
            Size = new Size(1242, 628);
            Load += AttractionList_Load;
            SlidersPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private FlowLayoutPanel flowLayoutPanel1;
        private Panel SlidersPanel;
        private Button AddButton;
        private FlowLayoutPanel flowLayoutPanel2;
    }
}
