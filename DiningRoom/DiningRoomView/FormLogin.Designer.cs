namespace DiningRoomView
{
    partial class FormLogin
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
            labelPassword = new Label();
            labelLogin = new Label();
            textBoxPassword = new TextBox();
            textBoxLogin = new TextBox();
            buttonReg = new Button();
            buttonLogin = new Button();
            SuspendLayout();
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(23, 51);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(52, 15);
            labelPassword.TabIndex = 22;
            labelPassword.Text = "Пароль:";
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Location = new Point(23, 15);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(44, 15);
            labelLogin.TabIndex = 20;
            labelLogin.Text = "Логин:";
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(98, 48);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(301, 23);
            textBoxPassword.TabIndex = 19;
            // 
            // textBoxLogin
            // 
            textBoxLogin.Location = new Point(98, 12);
            textBoxLogin.Name = "textBoxLogin";
            textBoxLogin.Size = new Size(301, 23);
            textBoxLogin.TabIndex = 17;
            // 
            // buttonReg
            // 
            buttonReg.Location = new Point(12, 131);
            buttonReg.Name = "buttonReg";
            buttonReg.Size = new Size(129, 23);
            buttonReg.TabIndex = 15;
            buttonReg.Text = "Регистрация";
            buttonReg.UseVisualStyleBackColor = true;
            buttonReg.Click += RegButt_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(324, 131);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 23);
            buttonLogin.TabIndex = 1;
            buttonLogin.Text = "Логин";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += ButtonLogin_Click;
            // 
            // FormLogin
            // 
            AcceptButton = buttonLogin;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(413, 168);
            Controls.Add(buttonLogin);
            Controls.Add(labelPassword);
            Controls.Add(labelLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxLogin);
            Controls.Add(buttonReg);
            Name = "FormLogin";
            Text = "Логин";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPassword;
        private Label labelLogin;
        private TextBox textBoxPassword;
        private TextBox textBoxLogin;
        private Button buttonReg;
        private Button buttonLogin;
    }
}