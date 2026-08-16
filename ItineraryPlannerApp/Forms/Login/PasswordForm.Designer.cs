namespace ItineraryPlannerApp.Forms.Login
{
    partial class PasswordForm
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
            verifyButton = new Button();
            passwordLabel = new Label();
            emailLabel = new Label();
            codeTxt = new TextBox();
            emailTxt = new TextBox();
            subtitleLabel = new Label();
            titleLabel = new Label();
            SendButton = new Button();
            errorLabel1 = new Label();
            panelSendCode = new Panel();
            errorLabel2 = new Label();
            panelResetPassword = new Panel();
            textPass1 = new TextBox();
            label2 = new Label();
            label3 = new Label();
            resetButton = new Button();
            textPass2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            createLabel = new Label();
            loginButton = new Button();
            panelSendCode.SuspendLayout();
            panelResetPassword.SuspendLayout();
            SuspendLayout();
            // 
            // verifyButton
            // 
            verifyButton.Location = new Point(365, 510);
            verifyButton.Name = "verifyButton";
            verifyButton.Size = new Size(164, 46);
            verifyButton.TabIndex = 13;
            verifyButton.Text = "Verify Code";
            verifyButton.UseVisualStyleBackColor = true;
            verifyButton.Click += verifyButton_Click;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(54, 455);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(75, 32);
            passwordLabel.TabIndex = 12;
            passwordLabel.Text = "Code:";
            // 
            // emailLabel
            // 
            emailLabel.AutoSize = true;
            emailLabel.Location = new Point(53, 250);
            emailLabel.Name = "emailLabel";
            emailLabel.Size = new Size(76, 32);
            emailLabel.TabIndex = 11;
            emailLabel.Text = "Email:";
            // 
            // codeTxt
            // 
            codeTxt.Location = new Point(145, 454);
            codeTxt.Name = "codeTxt";
            codeTxt.Size = new Size(384, 39);
            codeTxt.TabIndex = 10;
            codeTxt.UseSystemPasswordChar = true;
            // 
            // emailTxt
            // 
            emailTxt.Location = new Point(145, 247);
            emailTxt.Name = "emailTxt";
            emailTxt.Size = new Size(384, 39);
            emailTxt.TabIndex = 9;
            // 
            // subtitleLabel
            // 
            subtitleLabel.AutoSize = true;
            subtitleLabel.Font = new Font("Segoe UI", 10F);
            subtitleLabel.Location = new Point(51, 156);
            subtitleLabel.Name = "subtitleLabel";
            subtitleLabel.Size = new Size(228, 37);
            subtitleLabel.TabIndex = 8;
            subtitleLabel.Text = "Forgot password?";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            titleLabel.Location = new Point(51, 77);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(310, 59);
            titleLabel.TabIndex = 7;
            titleLabel.Text = "Travel Planner";
            // 
            // SendButton
            // 
            SendButton.Location = new Point(365, 305);
            SendButton.Name = "SendButton";
            SendButton.Size = new Size(164, 46);
            SendButton.TabIndex = 14;
            SendButton.Text = "Send Code";
            SendButton.UseVisualStyleBackColor = true;
            SendButton.Click += SendButton_Click;
            // 
            // errorLabel1
            // 
            errorLabel1.AutoSize = true;
            errorLabel1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            errorLabel1.ForeColor = Color.Crimson;
            errorLabel1.Location = new Point(54, 393);
            errorLabel1.Name = "errorLabel1";
            errorLabel1.Size = new Size(0, 32);
            errorLabel1.TabIndex = 15;
            // 
            // panelSendCode
            // 
            panelSendCode.Controls.Add(emailTxt);
            panelSendCode.Controls.Add(errorLabel1);
            panelSendCode.Controls.Add(titleLabel);
            panelSendCode.Controls.Add(SendButton);
            panelSendCode.Controls.Add(subtitleLabel);
            panelSendCode.Controls.Add(verifyButton);
            panelSendCode.Controls.Add(codeTxt);
            panelSendCode.Controls.Add(passwordLabel);
            panelSendCode.Controls.Add(emailLabel);
            panelSendCode.Location = new Point(99, 76);
            panelSendCode.Name = "panelSendCode";
            panelSendCode.Size = new Size(575, 601);
            panelSendCode.TabIndex = 16;
            // 
            // errorLabel2
            // 
            errorLabel2.AutoSize = true;
            errorLabel2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            errorLabel2.ForeColor = Color.Crimson;
            errorLabel2.Location = new Point(58, 377);
            errorLabel2.Name = "errorLabel2";
            errorLabel2.Size = new Size(0, 32);
            errorLabel2.TabIndex = 15;
            // 
            // panelResetPassword
            // 
            panelResetPassword.BackColor = SystemColors.InactiveBorder;
            panelResetPassword.BorderStyle = BorderStyle.Fixed3D;
            panelResetPassword.Controls.Add(textPass1);
            panelResetPassword.Controls.Add(errorLabel2);
            panelResetPassword.Controls.Add(label2);
            panelResetPassword.Controls.Add(label3);
            panelResetPassword.Controls.Add(resetButton);
            panelResetPassword.Controls.Add(textPass2);
            panelResetPassword.Controls.Add(label4);
            panelResetPassword.Controls.Add(label5);
            panelResetPassword.Location = new Point(680, 76);
            panelResetPassword.Name = "panelResetPassword";
            panelResetPassword.Size = new Size(679, 601);
            panelResetPassword.TabIndex = 17;
            // 
            // textPass1
            // 
            textPass1.Location = new Point(246, 247);
            textPass1.Name = "textPass1";
            textPass1.Size = new Size(384, 39);
            textPass1.TabIndex = 9;
            textPass1.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            label2.Location = new Point(51, 77);
            label2.Name = "label2";
            label2.Size = new Size(310, 59);
            label2.TabIndex = 7;
            label2.Text = "Travel Planner";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(51, 156);
            label3.Name = "label3";
            label3.Size = new Size(198, 37);
            label3.TabIndex = 8;
            label3.Text = "Reset Password";
            // 
            // resetButton
            // 
            resetButton.Location = new Point(417, 430);
            resetButton.Name = "resetButton";
            resetButton.Size = new Size(213, 46);
            resetButton.TabIndex = 13;
            resetButton.Text = "Reset Password";
            resetButton.UseVisualStyleBackColor = true;
            resetButton.Click += resetButton_Click;
            // 
            // textPass2
            // 
            textPass2.Location = new Point(246, 305);
            textPass2.Name = "textPass2";
            textPass2.Size = new Size(384, 39);
            textPass2.TabIndex = 10;
            textPass2.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(20, 308);
            label4.Name = "label4";
            label4.Size = new Size(209, 32);
            label4.TabIndex = 12;
            label4.Text = "Confirm Password:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(58, 250);
            label5.Name = "label5";
            label5.Size = new Size(171, 32);
            label5.TabIndex = 11;
            label5.Text = "New Password:";
            // 
            // createLabel
            // 
            createLabel.AutoSize = true;
            createLabel.Location = new Point(543, 719);
            createLabel.Name = "createLabel";
            createLabel.Size = new Size(181, 32);
            createLabel.TabIndex = 19;
            createLabel.Text = "< Back to Login";
            // 
            // loginButton
            // 
            loginButton.Location = new Point(733, 712);
            loginButton.Name = "loginButton";
            loginButton.Size = new Size(150, 46);
            loginButton.TabIndex = 18;
            loginButton.Text = "Login";
            loginButton.UseVisualStyleBackColor = true;
            loginButton.Click += loginButton_Click;
            // 
            // PasswordForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1474, 829);
            Controls.Add(createLabel);
            Controls.Add(loginButton);
            Controls.Add(panelResetPassword);
            Controls.Add(panelSendCode);
            Name = "PasswordForm";
            Text = "PasswordForm";
            panelSendCode.ResumeLayout(false);
            panelSendCode.PerformLayout();
            panelResetPassword.ResumeLayout(false);
            panelResetPassword.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button verifyButton;
        private Label passwordLabel;
        private Label emailLabel;
        private TextBox codeTxt;
        private TextBox emailTxt;
        private Label subtitleLabel;
        private Label titleLabel;
        private Button SendButton;
        private Label errorLabel1;
        private Panel panelSendCode;
        private Panel panelResetPassword;
        private TextBox textPass1;
        private Label errorLabel2;
        private Label label2;
        private Label label3;
        private Button resetButton;
        private TextBox textPass2;
        private Label label4;
        private Label label5;
        private Label createLabel;
        private Button loginButton;
    }
}