namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    partial class AttractionDetailsEditor
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
            panel1 = new Panel();
            ChangeImageButton = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            DescriptionTextBox = new TextBox();
            label2 = new Label();
            ShortDescTextBox = new TextBox();
            label3 = new Label();
            PriceTextBox = new TextBox();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel4 = new Panel();
            AddStationButton = new Button();
            TransportMethodPanel = new FlowLayoutPanel();
            label4 = new Label();
            SaveButton = new Button();
            panel3 = new Panel();
            HeaderPanel = new Panel();
            AreaTextBox = new TextBox();
            NameTextBox = new TextBox();
            CloseButton = new Button();
            flowLayoutPanel3 = new FlowLayoutPanel();
            panel5 = new Panel();
            flowLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            HeaderPanel.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.Controls.Add(panel1);
            flowLayoutPanel1.Controls.Add(panel2);
            flowLayoutPanel1.Location = new Point(3, 113);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1080, 490);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.AutoSize = true;
            panel1.Controls.Add(ChangeImageButton);
            panel1.Controls.Add(flowLayoutPanel2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1055, 324);
            panel1.TabIndex = 1;
            // 
            // ChangeImageButton
            // 
            ChangeImageButton.Location = new Point(930, 209);
            ChangeImageButton.Name = "ChangeImageButton";
            ChangeImageButton.Size = new Size(122, 29);
            ChangeImageButton.TabIndex = 3;
            ChangeImageButton.Text = "Change Image";
            ChangeImageButton.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(DescriptionTextBox);
            flowLayoutPanel2.Controls.Add(label2);
            flowLayoutPanel2.Controls.Add(ShortDescTextBox);
            flowLayoutPanel2.Controls.Add(label3);
            flowLayoutPanel2.Controls.Add(PriceTextBox);
            flowLayoutPanel2.Location = new Point(3, 3);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(803, 318);
            flowLayoutPanel2.TabIndex = 2;
            // 
            // DescriptionTextBox
            // 
            DescriptionTextBox.Location = new Point(3, 3);
            DescriptionTextBox.Multiline = true;
            DescriptionTextBox.Name = "DescriptionTextBox";
            DescriptionTextBox.PlaceholderText = "Please enter the description:...";
            DescriptionTextBox.Size = new Size(792, 147);
            DescriptionTextBox.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(3, 153);
            label2.Name = "label2";
            label2.Size = new Size(169, 20);
            label2.TabIndex = 3;
            label2.Text = "Short Form Description: ";
            // 
            // ShortDescTextBox
            // 
            ShortDescTextBox.Location = new Point(3, 176);
            ShortDescTextBox.Multiline = true;
            ShortDescTextBox.Name = "ShortDescTextBox";
            ShortDescTextBox.Size = new Size(792, 64);
            ShortDescTextBox.TabIndex = 2;
            // 
            // label3
            // 
            label3.Location = new Point(3, 243);
            label3.Name = "label3";
            label3.Size = new Size(109, 30);
            label3.TabIndex = 4;
            label3.Text = "Entry Prices: ";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // PriceTextBox
            // 
            PriceTextBox.Location = new Point(118, 246);
            PriceTextBox.Name = "PriceTextBox";
            PriceTextBox.Size = new Size(673, 27);
            PriceTextBox.TabIndex = 5;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(812, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(240, 200);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(SaveButton);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(3, 333);
            panel2.Name = "panel2";
            panel2.Size = new Size(1055, 300);
            panel2.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.AutoSize = true;
            panel4.Controls.Add(AddStationButton);
            panel4.Controls.Add(TransportMethodPanel);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(262, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(790, 250);
            panel4.TabIndex = 4;
            // 
            // AddStationButton
            // 
            AddStationButton.Location = new Point(668, 215);
            AddStationButton.Name = "AddStationButton";
            AddStationButton.Size = new Size(119, 29);
            AddStationButton.TabIndex = 2;
            AddStationButton.Text = "Add Station";
            AddStationButton.UseVisualStyleBackColor = true;
            AddStationButton.Click += AddStationButton_Click;
            // 
            // TransportMethodPanel
            // 
            TransportMethodPanel.AutoSize = true;
            TransportMethodPanel.FlowDirection = FlowDirection.TopDown;
            TransportMethodPanel.Location = new Point(3, 35);
            TransportMethodPanel.Name = "TransportMethodPanel";
            TransportMethodPanel.Size = new Size(784, 174);
            TransportMethodPanel.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(3, 9);
            label4.Name = "label4";
            label4.Size = new Size(163, 23);
            label4.TabIndex = 0;
            label4.Text = "Transport Methods: ";
            // 
            // SaveButton
            // 
            SaveButton.Location = new Point(955, 268);
            SaveButton.Name = "SaveButton";
            SaveButton.Size = new Size(94, 29);
            SaveButton.TabIndex = 3;
            SaveButton.Text = "Save";
            SaveButton.UseVisualStyleBackColor = true;
            SaveButton.Click += SaveButton_Click;
            // 
            // panel3
            // 
            panel3.Location = new Point(6, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(250, 250);
            panel3.TabIndex = 0;
            // 
            // HeaderPanel
            // 
            HeaderPanel.Controls.Add(AreaTextBox);
            HeaderPanel.Controls.Add(NameTextBox);
            HeaderPanel.Controls.Add(CloseButton);
            HeaderPanel.Dock = DockStyle.Top;
            HeaderPanel.Location = new Point(0, 0);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1083, 110);
            HeaderPanel.TabIndex = 0;
            // 
            // AreaTextBox
            // 
            AreaTextBox.Location = new Point(42, 66);
            AreaTextBox.Name = "AreaTextBox";
            AreaTextBox.Size = new Size(125, 27);
            AreaTextBox.TabIndex = 4;
            // 
            // NameTextBox
            // 
            NameTextBox.Font = new Font("Segoe UI", 15F);
            NameTextBox.Location = new Point(32, 19);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(342, 41);
            NameTextBox.TabIndex = 3;
            // 
            // CloseButton
            // 
            CloseButton.BackColor = Color.Red;
            CloseButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CloseButton.ForeColor = SystemColors.ButtonFace;
            CloseButton.Location = new Point(1017, 19);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(35, 35);
            CloseButton.TabIndex = 1;
            CloseButton.Text = "✕";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // flowLayoutPanel3
            // 
            flowLayoutPanel3.BackColor = Color.Transparent;
            flowLayoutPanel3.Controls.Add(panel5);
            flowLayoutPanel3.Location = new Point(0, 0);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            flowLayoutPanel3.Size = new Size(1280, 800);
            flowLayoutPanel3.TabIndex = 1;
            // 
            // panel5
            // 
            panel5.Controls.Add(HeaderPanel);
            panel5.Controls.Add(flowLayoutPanel1);
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(1083, 629);
            panel5.TabIndex = 0;
            // 
            // AttractionDetailsEditor
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(flowLayoutPanel3);
            Name = "AttractionDetailsEditor";
            Size = new Size(1280, 800);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panel1.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel2;
        private PictureBox pictureBox1;
        private TextBox DescriptionTextBox;
        private Label label2;
        private TextBox ShortDescTextBox;
        private Label label3;
        private TextBox PriceTextBox;
        private Button ChangeImageButton;
        private Panel panel2;
        private Panel panel3;
        private Button SaveButton;
        private Panel panel4;
        private Button AddStationButton;
        private FlowLayoutPanel TransportMethodPanel;
        private Label label4;
        private FlowLayoutPanel flowLayoutPanel3;
        private Panel HeaderPanel;
        private Button CloseButton;
        private Panel panel5;
        private TextBox NameTextBox;
        private TextBox AreaTextBox;
    }
}
