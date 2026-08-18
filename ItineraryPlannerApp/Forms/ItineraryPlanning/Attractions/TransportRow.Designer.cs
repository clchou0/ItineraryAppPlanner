namespace ItineraryPlannerApp.Forms.ItineraryPlanning.Attractions
{
    partial class TransportRow
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
            TypeComboBox = new ComboBox();
            StationTextBox = new TextBox();
            DeleteButton = new Button();
            walkUpDown = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)walkUpDown).BeginInit();
            SuspendLayout();
            // 
            // TypeComboBox
            // 
            TypeComboBox.FormattingEnabled = true;
            TypeComboBox.Location = new Point(16, 13);
            TypeComboBox.Name = "TypeComboBox";
            TypeComboBox.Size = new Size(151, 28);
            TypeComboBox.TabIndex = 0;
            TypeComboBox.Text = "-Station Type-";
            // 
            // StationTextBox
            // 
            StationTextBox.Location = new Point(173, 14);
            StationTextBox.Name = "StationTextBox";
            StationTextBox.PlaceholderText = "Station Name..";
            StationTextBox.Size = new Size(224, 27);
            StationTextBox.TabIndex = 1;
            // 
            // DeleteButton
            // 
            DeleteButton.BackColor = Color.Red;
            DeleteButton.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DeleteButton.ForeColor = SystemColors.ButtonFace;
            DeleteButton.Location = new Point(534, 14);
            DeleteButton.Name = "DeleteButton";
            DeleteButton.Size = new Size(29, 29);
            DeleteButton.TabIndex = 4;
            DeleteButton.Text = "✕";
            DeleteButton.UseVisualStyleBackColor = false;
            DeleteButton.Click += DeleteButton_Click;
            // 
            // walkUpDown
            // 
            walkUpDown.Location = new Point(403, 14);
            walkUpDown.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            walkUpDown.Name = "walkUpDown";
            walkUpDown.Size = new Size(56, 27);
            walkUpDown.TabIndex = 5;
            // 
            // TransportRow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(walkUpDown);
            Controls.Add(DeleteButton);
            Controls.Add(StationTextBox);
            Controls.Add(TypeComboBox);
            Name = "TransportRow";
            Size = new Size(570, 50);
            ((System.ComponentModel.ISupportInitialize)walkUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox TypeComboBox;
        private TextBox StationTextBox;
        private Button DeleteButton;
        private NumericUpDown walkUpDown;
    }
}
