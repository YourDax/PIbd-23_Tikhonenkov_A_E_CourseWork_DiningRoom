namespace DiningRoomView
{
    partial class FormRegister
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
            buttonReg = new Button();
            buttonBack = new Button();
            textBoxLogin = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            labelLogin = new Label();
            labelEmail = new Label();
            labelPassword = new Label();
            SuspendLayout();
            // 
            // buttonReg
            // 
            buttonReg.Location = new Point(119, 139);
            buttonReg.Name = "buttonReg";
            buttonReg.Size = new Size(129, 23);
            buttonReg.TabIndex = 7;
            buttonReg.Text = "Зарегистрироваться";
            buttonReg.UseVisualStyleBackColor = true;
            buttonReg.Click += ButtonRegister_Click;
            // 
            // buttonBack
            // 
            buttonBack.Location = new Point(254, 139);
            buttonBack.Name = "buttonBack";
            buttonBack.Size = new Size(75, 23);
            buttonBack.TabIndex = 8;
            buttonBack.Text = "Назад";
            buttonBack.UseVisualStyleBackColor = true;
            buttonBack.Click += LoginButt_Click;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(94, 17);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(235, 23);
            textBoxLogin.TabIndex = 9;
            // 
            // textBoxEmail
            // 
            textBoxEmail.Location = new Point(94, 46);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(235, 23);
            textBoxEmail.TabIndex = 10;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(94, 75);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(235, 23);
            textBoxPassword.TabIndex = 11;
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(19, 20);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(44, 15);
            labelLogin.TabIndex = 12;
            labelLogin.Text = "Логин:";
            // 
            // labelEmail
            // 
            labelEmail.AutoSize = true;
            labelEmail.Location = new Point(19, 49);
            labelEmail.Name = "labelEmail";
            labelEmail.Size = new Size(44, 15);
            labelEmail.TabIndex = 13;
            labelEmail.Text = "Почта:";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(19, 78);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(52, 15);
            labelPassword.TabIndex = 14;
            labelPassword.Text = "Пароль:";
            // 
            // FormRegister
            // 
            AcceptButton = buttonReg;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 176);
            Controls.Add(labelPassword);
            Controls.Add(labelEmail);
            Controls.Add(labelLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxLogin);
            Controls.Add(buttonBack);
            Controls.Add(buttonReg);
            Name = "FormRegister";
            Text = "Регистрация";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonReg;
        private Button buttonBack;
        private TextBox textBoxLogin;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Label labelLogin;
        private Label labelEmail;
        private Label labelPassword;
    }
}