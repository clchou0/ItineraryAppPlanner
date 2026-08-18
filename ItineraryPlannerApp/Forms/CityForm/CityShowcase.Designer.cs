namespace ItineraryPlannerApp.Forms.CityForm
{
    partial class CityShowcase
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
            SearchTextBox = new TextBox();
            label1 = new Label();
            SearchButton = new Button();
            AddOrItButton = new Button();
            cardContainer = new TableLayoutPanel();
            SuspendLayout();
            // 
            // SearchTextBox
            // 
            SearchTextBox.Font = new Font("Segoe UI", 12F);
            SearchTextBox.Location = new Point(273, 28);
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(330, 34);
            SearchTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(40, 28);
            label1.Name = "label1";
            label1.Size = new Size(236, 28);
            label1.TabIndex = 1;
            label1.Text = "Search for City / Country: ";
            // 
            // SearchButton
            // 
            SearchButton.Font = new Font("Segoe UI", 12F);
            SearchButton.Location = new Point(622, 27);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(94, 35);
            SearchButton.TabIndex = 2;
            SearchButton.Text = "Search";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // AddOrItButton
            // 
            AddOrItButton.BackColor = SystemColors.Highlight;
            AddOrItButton.Font = new Font("Segoe UI", 12F);
            AddOrItButton.ForeColor = Color.White;
            AddOrItButton.Location = new Point(1089, 20);
            AddOrItButton.Name = "AddOrItButton";
            AddOrItButton.Size = new Size(153, 47);
            AddOrItButton.TabIndex = 4;
            AddOrItButton.Text = "Add New City..";
            AddOrItButton.TextAlign = ContentAlignment.MiddleRight;
            AddOrItButton.UseVisualStyleBackColor = false;
            AddOrItButton.Click += AddOrItButton_Click;
            // 
            // cardContainer
            // 
            cardContainer.AutoScroll = true;
            cardContainer.ColumnCount = 2;
            cardContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardContainer.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            cardContainer.Location = new Point(20, 78);
            cardContainer.Name = "cardContainer";
            cardContainer.RowCount = 2;
            cardContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardContainer.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            cardContainer.Size = new Size(1222, 612);
            cardContainer.TabIndex = 5;
            // 
            // CityShowcase
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cardContainer);
            Controls.Add(AddOrItButton);
            Controls.Add(SearchButton);
            Controls.Add(label1);
            Controls.Add(SearchTextBox);
            Name = "CityShowcase";
            Size = new Size(1262, 709);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox SearchTextBox;
        private Label label1;
        private Button SearchButton;
        private Button AddOrItButton;
        private TableLayoutPanel cardContainer;
    }
}
