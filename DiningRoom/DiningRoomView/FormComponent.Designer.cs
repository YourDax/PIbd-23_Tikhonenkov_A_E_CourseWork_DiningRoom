namespace DiningRoomView
{
    partial class FormComponent
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonSave = new Button();
            ButtonCancel = new Button();
            label1 = new Label();
            textBoxName = new TextBox();
            textBoxCost = new TextBox();
            label2 = new Label();
            comboBoxUnit = new ComboBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new Point(192, 111);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(86, 23);
            ButtonSave.TabIndex = 0;
            ButtonSave.Text = "Сохранение";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(284, 111);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(75, 23);
            ButtonCancel.TabIndex = 1;
            ButtonCancel.Text = "Отмена";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 2;
            label1.Text = "Название:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(138, 12);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(222, 23);
            textBoxName.TabIndex = 3;
            // 
            // textBoxCost
            // 
            textBoxCost.Location = new Point(138, 38);
            textBoxCost.Name = "textBoxCost";
            textBoxCost.Size = new Size(222, 23);
            textBoxCost.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 41);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 5;
            label2.Text = "Цена:";
            // 
            // comboBoxUnit
            // 
            comboBoxUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUnit.FormattingEnabled = true;
            comboBoxUnit.Location = new Point(137, 64);
            comboBoxUnit.Name = "comboBoxUnit";
            comboBoxUnit.Size = new Size(222, 23);
            comboBoxUnit.TabIndex = 11;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 67);
            label3.Name = "label3";
            label3.Size = new Size(119, 15);
            label3.TabIndex = 12;
            label3.Text = "Единица измерения:";
            // 
            // FormComponent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(377, 151);
            Controls.Add(label3);
            Controls.Add(comboBoxUnit);
            Controls.Add(label2);
            Controls.Add(textBoxCost);
            Controls.Add(textBoxName);
            Controls.Add(label1);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonSave);
            Name = "FormComponent";
            Text = "Продукт";
            Load += FormComponent_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxName;
        private TextBox textBoxCost;
        private Label label2;
        private ComboBox comboBoxUnit;
        private Label label3;
    }
}