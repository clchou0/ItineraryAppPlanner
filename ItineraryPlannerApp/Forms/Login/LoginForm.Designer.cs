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
            titleLabel.Location = new Point(552, 122);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(310, 59);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Travel Planner";
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 10F);
            subtitleLabel.Location = new Point(526, 204);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(351, 37);
            subtitleLabel.TabIndex = 1;
            subtitleLabel.Text = "Plan your upcoming journey";
            // 
            // emailTxt
            // 
            emailTxt.Location = new Point(592, 289);
            emailTxt.Name = "emailTxt";
            emailTxt.Size = new Size(384, 39);
            emailTxt.TabIndex = 2;
            emailTxt.TextChanged += emailLabel_TextChanged;
            // 
            // passwordTxt
            // 
            passwordTxt.Location = new Point(592, 339);
            passwordTxt.Name = "passwordTxt";
            passwordTxt.Size = new Size(384, 39);
            passwordTxt.TabIndex = 3;
            passwordTxt.UseSystemPasswordChar = true;
            passwordTxt.TextChanged += passwordTxt_TextChanged;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(500, 292);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(77, 32);
            emailLabel.TabIndex = 4;
            emailLabel.Text = "email:";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(460, 343);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(118, 32);
            passwordLabel.TabIndex = 5;
            passwordLabel.Text = "password:";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(826, 412);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(150, 46);
            loginButton.TabIndex = 6;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // createLabel
            // 
            createLabel.AutoSize = true;
            createLabel.Location = new Point(460, 628);
            createLabel.Name = "createLabel";
            createLabel.Size = new Size(266, 32);
            createLabel.TabIndex = 7;
            createLabel.Text = "Don't have an account?";
            // 
            // createButton
            // 
            createButton.Location = new Point(744, 622);
            createButton.Name = "createButton";
            createButton.Size = new Size(231, 46);
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
            errorLabel.Location = new Point(460, 469);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 32);
            errorLabel.TabIndex = 9;
            // 
            // resetLabel
            // 
            resetLabel.AutoSize = true;
            resetLabel.Location = new Point(460, 566);
            resetLabel.Name = "resetLabel";
            resetLabel.Size = new Size(201, 32);
            resetLabel.TabIndex = 10;
            resetLabel.Text = "Forgot password?";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(744, 559);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(231, 46);
            resetButton.TabIndex = 11;
            resetButton.Text = "Reset Password";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 829);
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
            MinimizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
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