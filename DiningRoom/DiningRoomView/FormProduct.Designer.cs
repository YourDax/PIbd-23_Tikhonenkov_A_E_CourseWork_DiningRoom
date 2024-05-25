namespace DiningRoomView
{
    partial class FormProduct
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
            labelName = new Label();
            labelPrice = new Label();
            textBoxName = new TextBox();
            textBoxPrice = new TextBox();
            groupBox1 = new GroupBox();
            dataGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            ComponentName = new DataGridViewTextBoxColumn();
            Count = new DataGridViewTextBoxColumn();
            ButtonRef = new Button();
            ButtonDel = new Button();
            ButtonUpd = new Button();
            ButtonAdd = new Button();
            ButtonSave = new Button();
            ButtonCancel = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.Location = new Point(12, 9);
            labelName.Name = "labelName";
            labelName.Size = new Size(62, 15);
            labelName.TabIndex = 0;
            labelName.Text = "Название:";
            // 
            // labelPrice
            // 
            labelPrice.AutoSize = true;
            labelPrice.Location = new Point(12, 41);
            labelPrice.Name = "labelPrice";
            labelPrice.Size = new Size(38, 15);
            labelPrice.TabIndex = 1;
            labelPrice.Text = "Цена:";
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(94, 6);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(247, 23);
            textBoxName.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            textBoxPrice.Location = new Point(94, 38);
            textBoxPrice.Name = "textBoxPrice";
            textBoxPrice.Size = new Size(100, 23);
            textBoxPrice.TabIndex = 3;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dataGridView);
            groupBox1.Controls.Add(ButtonRef);
            groupBox1.Controls.Add(ButtonDel);
            groupBox1.Controls.Add(ButtonUpd);
            groupBox1.Controls.Add(ButtonAdd);
            groupBox1.Location = new Point(12, 67);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(510, 338);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Компонент";
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ID, ComponentName, Count });
            dataGridView.Location = new Point(0, 21);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(394, 311);
            dataGridView.TabIndex = 5;
            // 
            // ID
            // 
            ID.HeaderText = "Id";
            ID.Name = "ID";
            ID.Visible = false;
            ID.Width = 250;
            // 
            // ComponentName
            // 
            ComponentName.HeaderText = "Компоненте";
            ComponentName.Name = "ComponentName";
            ComponentName.Width = 250;
            // 
            // Count
            // 
            Count.HeaderText = "Количество";
            Count.Name = "Count";
            // 
            // ButtonRef
            // 
            ButtonRef.Location = new Point(400, 169);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(106, 28);
            ButtonRef.TabIndex = 4;
            ButtonRef.Text = "Обновить";
            ButtonRef.UseVisualStyleBackColor = true;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // ButtonDel
            // 
            ButtonDel.Location = new Point(400, 135);
            ButtonDel.Name = "ButtonDel";
            ButtonDel.Size = new Size(106, 28);
            ButtonDel.TabIndex = 3;
            ButtonDel.Text = "Удалить";
            ButtonDel.UseVisualStyleBackColor = true;
            ButtonDel.Click += ButtonDel_Click;
            // 
            // ButtonUpd
            // 
            ButtonUpd.Location = new Point(400, 101);
            ButtonUpd.Name = "ButtonUpd";
            ButtonUpd.Size = new Size(106, 28);
            ButtonUpd.TabIndex = 2;
            ButtonUpd.Text = "Изменить";
            ButtonUpd.UseVisualStyleBackColor = true;
            ButtonUpd.Click += ButtonUpd_Click;
            // 
            // ButtonAdd
            // 
            ButtonAdd.Location = new Point(400, 67);
            ButtonAdd.Name = "ButtonAdd";
            ButtonAdd.Size = new Size(106, 28);
            ButtonAdd.TabIndex = 1;
            ButtonAdd.Text = "Добавить";
            ButtonAdd.UseVisualStyleBackColor = true;
            ButtonAdd.Click += ButtonAdd_Click;
            // 
            // ButtonSave
            // 
            ButtonSave.Location = new Point(354, 415);
            ButtonSave.Name = "ButtonSave";
            ButtonSave.Size = new Size(75, 23);
            ButtonSave.TabIndex = 5;
            ButtonSave.Text = "Сохранить";
            ButtonSave.UseVisualStyleBackColor = true;
            ButtonSave.Click += ButtonSave_Click;
            // 
            // ButtonCancel
            // 
            ButtonCancel.Location = new Point(435, 415);
            ButtonCancel.Name = "ButtonCancel";
            ButtonCancel.Size = new Size(75, 23);
            ButtonCancel.TabIndex = 6;
            ButtonCancel.Text = "Отмена";
            ButtonCancel.UseVisualStyleBackColor = true;
            ButtonCancel.Click += ButtonCancel_Click;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(536, 450);
            Controls.Add(ButtonCancel);
            Controls.Add(ButtonSave);
            Controls.Add(groupBox1);
            Controls.Add(textBoxPrice);
            Controls.Add(textBoxName);
            Controls.Add(labelPrice);
            Controls.Add(labelName);
            Name = "FormProduct";
            Text = "Создание изделия";
            Load += FormProduct_Load;
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.Button ButtonDel;
        private System.Windows.Forms.Button ButtonUpd;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
    }
}