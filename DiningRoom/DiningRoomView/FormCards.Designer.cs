namespace DiningRoomView
{
    partial class FormCards
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
            dataGridView = new DataGridView();
            ButtonAdd = new Button();
            ButtonUpd = new Button();
            ButtonDel = new Button();
            ButtonRef = new Button();
            textBoxName = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(0, 0);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(433, 448);
            dataGridView.TabIndex = 0;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Location = new Point(439, 116);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(225, 23);
            ButtonAdd.TabIndex = 1;
            ButtonAdd.Text = "Добавить";
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // ButtonUpd
            // 
            ButtonUpd.Location = new Point(439, 145);
            ButtonUpd.Name = "ButtonUpd";
            ButtonUpd.Size = new Size(225, 23);
            ButtonUpd.TabIndex = 2;
            ButtonUpd.Text = "Изменить";
            ButtonUpd.UseVisualStyleBackColor = true;
            ButtonUpd.Click += ButtonUpd_Click;
            // 
            // ButtonDel
            // 
            ButtonDel.Location = new Point(439, 174);
            ButtonDel.Name = "ButtonDel";
            ButtonDel.Size = new Size(225, 23);
            ButtonDel.TabIndex = 3;
            ButtonDel.Text = "Удалить";
            ButtonDel.UseVisualStyleBackColor = true;
            ButtonDel.Click += ButtonDel_Click;
            // 
            // ButtonRef
            // 
            ButtonRef.Location = new Point(439, 203);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(225, 23);
            ButtonRef.TabIndex = 4;
            ButtonRef.Text = "Обновить";
            ButtonRef.UseVisualStyleBackColor = true;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(439, 30);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(225, 23);
            textBoxName.TabIndex = 5;
            // 
            // FormCards
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(668, 450);
            Controls.Add(textBoxName);
            Controls.Add(ButtonRef);
            Controls.Add(ButtonDel);
            Controls.Add(ButtonUpd);
            Controls.Add(ButtonAdd);
            Controls.Add(dataGridView);
            Name = "FormCards";
            Text = "Изделия";
            Load += FormProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonUpd;
        private System.Windows.Forms.Button ButtonDel;
        private System.Windows.Forms.Button ButtonRef;
        private TextBox textBoxName;
    }
}