namespace ItineraryPlannerApp.Forms
{
    partial class RegisterForm
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
            nameLabel = new Label();
            nameText = new TextBox();
            emailLabel = new Label();
            emailText = new TextBox();
            passLabel = new Label();
            passText = new TextBox();
            pass2Label = new Label();
            pass2Text = new TextBox();
            createButton = new Button();
            createLabel = new Label();
            loginButton = new Button();
            errorLabel = new Label();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(567, 112);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(334, 59);
            titleLabel.TabIndex = 0;
            titleLabel.Text = "Create Account";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(496, 217);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(83, 32);
            nameLabel.TabIndex = 6;
            nameLabel.Text = "Name:";
            // 
            // nameText
            // 
            nameText.Location = new Point(588, 214);
            nameText.Name = "nameText";
            nameText.Size = new Size(384, 39);
            nameText.TabIndex = 5;
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(503, 267);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(76, 32);
            emailLabel.TabIndex = 8;
            emailLabel.Text = "Email:";
            // 
            // emailText
            // 
            emailText.Location = new Point(588, 264);
            emailText.Name = "emailText";
            emailText.Size = new Size(384, 39);
            emailText.TabIndex = 7;
            // 
            // passLabel
            // 
            passLabel.AutoSize = true;
            passLabel.Location = new Point(463, 321);
            passLabel.Name = "passLabel";
            passLabel.Size = new Size(116, 32);
            passLabel.TabIndex = 10;
            passLabel.Text = "Password:";
            // 
            // passText
            // 
            passText.Location = new Point(588, 318);
            passText.Name = "passText";
            passText.Size = new Size(384, 39);
            passText.TabIndex = 9;
            // 
            // pass2Label
            // 
            pass2Label.AutoSize = true;
            pass2Label.Location = new Point(370, 376);
            pass2Label.Name = "pass2Label";
            pass2Label.Size = new Size(209, 32);
            pass2Label.TabIndex = 12;
            pass2Label.Text = "Confirm Password:";
            // 
            // pass2Text
            // 
            pass2Text.Location = new Point(588, 373);
            pass2Text.Name = "pass2Text";
            pass2Text.Size = new Size(384, 39);
            pass2Text.TabIndex = 11;
            // 
            // createButton
            // 
            createButton.Location = new Point(764, 439);
            createButton.Name = "createButton";
            createButton.Size = new Size(231, 46);
            createButton.TabIndex = 15;
            createButton.Text = "Create Account";
            createButton.UseVisualStyleBackColor = true;
            createButton.Click += createButton_Click;
            // 
            // createLabel
            // 
            createLabel.AutoSize = true;
            createLabel.Location = new Point(503, 630);
            createLabel.Name = "createLabel";
            createLabel.Size = new Size(287, 32);
            createLabel.TabIndex = 14;
            createLabel.Text = "Already have an account?";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(822, 623);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(150, 46);
            loginButton.TabIndex = 13;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            errorLabel.ForeColor = Color.Crimson;
            errorLabel.Location = new Point(370, 494);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(0, 32);
            errorLabel.TabIndex = 16;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 829);
            Controls.Add(errorLabel);
            Controls.Add(createButton);
            Controls.Add(createLabel);
            Controls.Add(loginButton);
            Controls.Add(pass2Label);
            Controls.Add(pass2Text);
            Controls.Add(passLabel);
            Controls.Add(passText);
            Controls.Add(emailLabel);
            Controls.Add(emailText);
            Controls.Add(nameLabel);
            Controls.Add(nameText);
            Controls.Add(titleLabel);
            Name = "RegisterForm";
            Text = "CreateAccountForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private Label nameLabel;
        private TextBox nameText;
        private Label emailLabel;
        private TextBox emailText;
        private Label passLabel;
        private TextBox passText;
        private Label pass2Label;
        private TextBox pass2Text;
        private Button createButton;
        private Label createLabel;
        private Button loginButton;
        private Label errorLabel;
    }
}