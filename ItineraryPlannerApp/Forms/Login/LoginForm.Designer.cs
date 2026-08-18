namespace ItineraryPlannerApp.Forms
{
    partial class LoginForm
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
            titleLabel = new Label();
            subtitleLabel = new Label();
            emailTxt = new TextBox();
            passwordTxt = new TextBox();
            emailLabel = new Label();
            passwordLabel = new Label();
            loginButton = new Button();
            createLabel = new Label();
            createButton = new Button();
            errorLabel = new Label();
            resetLabel = new Label();
            resetButton = new Button();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(340, 76);
            titleLabel.Margin = new Padding(2, 0, 2, 0);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(200, 37);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Travel Planner";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 10F);
            subtitleLabel.Location = new Point(324, 128);
            subtitleLabel.Margin = new Padding(2, 0, 2, 0);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(226, 23);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Plan your upcoming journey";
            // 
            // emailTxt
            // 
            emailTxt.Location = new Point(364, 181);
            emailTxt.Margin = new Padding(2);
            emailTxt.Name = "emailTxt";
            emailTxt.Size = new Size(238, 27);
            emailTxt.TabIndex = 2;
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(364, 212);
            passwordTxt.Margin = new Padding(2);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(238, 27);
            passwordTxt.TabIndex = 3;
            passwordTxt.UseSystemPasswordChar = true;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(308, 182);
            emailLabel.Margin = new Padding(2, 0, 2, 0);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(49, 20);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "email:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(283, 214);
            passwordLabel.Margin = new Padding(2, 0, 2, 0);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(75, 20);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "password:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(508, 258);
            loginButton.Margin = new Padding(2);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(92, 29);
            loginButton.TabIndex = 6;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // createLabel
            // 
            createLabel.AutoSize = true;
            createLabel.Location = new Point(283, 392);
            createLabel.Margin = new Padding(2, 0, 2, 0);
            createLabel.Name = "createLabel";
            createLabel.Size = new Size(163, 20);
            createLabel.TabIndex = 7;
            createLabel.Text = "Don't have an account?";
            // 
            // createButton
            // 
            createButton.Location = new Point(458, 389);
            createButton.Margin = new Padding(2);
            createButton.Name = "createButton";
            createButton.Size = new Size(142, 29);
            createButton.TabIndex = 8;
            createButton.Text = "Create Account";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            errorLabel.ForeColor = Color.Crimson;
            errorLabel.Location = new Point(283, 293);
            errorLabel.Margin = new Padding(2, 0, 2, 0);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 20);
            errorLabel.TabIndex = 9;
            // 
            // resetLabel
            // 
            resetLabel.AutoSize = true;
            resetLabel.Location = new Point(283, 354);
            resetLabel.Margin = new Padding(2, 0, 2, 0);
            resetLabel.Name = "resetLabel";
            resetLabel.Size = new Size(127, 20);
            resetLabel.TabIndex = 10;
            resetLabel.Text = "Forgot password?";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(458, 349);
            resetButton.Margin = new Padding(2);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(142, 29);
            resetButton.TabIndex = 11;
            resetButton.Text = "Reset Password";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(907, 518);
            Controls.Add(resetButton);
            Controls.Add(resetLabel);
            Controls.Add(errorLabel);
            Controls.Add(createButton);
            Controls.Add(createLabel);
            Controls.Add(loginButton);
            Controls.Add(passwordLabel);
            Controls.Add(emailLabel);
            Controls.Add(passwordTxt);
            Controls.Add(emailTxt);
            Controls.Add(subtitleLabel);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(2);
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label subtitleLabel;
        private TextBox emailTxt;
        private TextBox passwordTxt;
        private Label emailLabel;
        private Label passwordLabel;
        private Button loginButton;
        private Label createLabel;
        private Button createButton;
        private Label errorLabel;
        private Label resetLabel;
        private Button resetButton;
    }
}