namespace DiningRoomView
{
    partial class FormDrinkComponent
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
            labelComponent = new Label();
            labelCount = new Label();
            textBoxCount = new TextBox();
            comboBoxComponent = new ComboBox();
            buttonCancel = new Button();
            buttonSave = new Button();
            SuspendLayout();
            // 
            // labelComponent
            // 
            labelComponent.AutoSize = true;
            labelComponent.Location = new Point(12, 9);
            labelComponent.Name = "labelComponent";
            labelComponent.Size = new Size(72, 15);
            labelComponent.TabIndex = 0;
            labelComponent.Text = "Компонент:";
            // 
            // labelCount
            // 
            labelCount.AutoSize = true;
            labelCount.Location = new Point(12, 37);
            labelCount.Name = "labelCount";
            labelCount.Size = new Size(75, 15);
            labelCount.TabIndex = 1;
            labelCount.Text = "Количество:";
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(90, 34);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(235, 23);
            textBoxCount.TabIndex = 3;
            // 
            // comboBoxComponent
            // 
            comboBoxComponent.BackColor = SystemColors.Window;
            comboBoxComponent.FormattingEnabled = true;
            comboBoxComponent.Location = new Point(90, 6);
            comboBoxComponent.Name = "comboBoxComponent";
            comboBoxComponent.Size = new Size(235, 23);
            comboBoxComponent.TabIndex = 4;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new Point(248, 63);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(75, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Отмена";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // buttonSave
            // 
            buttonSave.Location = new Point(167, 63);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(75, 23);
            buttonSave.TabIndex = 6;
            buttonSave.Text = "Сохранить";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // FormProductComponent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(337, 97);
            Controls.Add(buttonSave);
            Controls.Add(buttonCancel);
            Controls.Add(comboBoxComponent);
            Controls.Add(textBoxCount);
            Controls.Add(labelCount);
            Controls.Add(labelComponent);
            Name = "FormProductComponent";
            Text = "Компонент";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelComponent;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.TextBox textBoxCount;
        private System.Windows.Forms.ComboBox comboBoxComponent;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSave;
    }
}