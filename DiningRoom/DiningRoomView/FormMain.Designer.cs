namespace DiningRoomView
{
	partial class FormMain
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
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            menuStrip1 = new MenuStrip();
            продуктыToolStripMenuItem = new ToolStripMenuItem();
            клиентыToolStripMenuItem = new ToolStripMenuItem();
            поставщикиToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            label1 = new Label();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            button2 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 53);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(455, 257);
            dataGridView1.TabIndex = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(12, 341);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(455, 240);
            dataGridView2.TabIndex = 1;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { продуктыToolStripMenuItem, клиентыToolStripMenuItem, поставщикиToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(666, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // продуктыToolStripMenuItem
            // 
            продуктыToolStripMenuItem.Name = "продуктыToolStripMenuItem";
            продуктыToolStripMenuItem.Size = new Size(74, 20);
            продуктыToolStripMenuItem.Text = "Продукты";
            продуктыToolStripMenuItem.Click += ПродуктыToolStripMenuItem_Click;
            // 
            // клиентыToolStripMenuItem
            // 
            клиентыToolStripMenuItem.Name = "клиентыToolStripMenuItem";
            клиентыToolStripMenuItem.Size = new Size(12, 20);
            // 
            // поставщикиToolStripMenuItem
            // 
            поставщикиToolStripMenuItem.Name = "поставщикиToolStripMenuItem";
            поставщикиToolStripMenuItem.Size = new Size(12, 20);
            // 
            // button1
            // 
            button1.Location = new Point(491, 139);
            button1.Name = "button1";
            button1.Size = new Size(153, 23);
            button1.TabIndex = 3;
            button1.Text = "Создать блюдо";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonAddProduct_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(179, 24);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 5;
            label1.Text = "Блюда";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(179, 313);
            label2.Name = "label2";
            label2.Size = new Size(85, 25);
            label2.TabIndex = 6;
            label2.Text = "Напитки";
            // 
            // button3
            // 
            button3.Location = new Point(491, 168);
            button3.Name = "button3";
            button3.Size = new Size(153, 23);
            button3.TabIndex = 7;
            button3.Text = "Редактировать блюдо";
            button3.UseVisualStyleBackColor = true;
            button3.Click += ButtonUpdProduct_Click;
            // 
            // button4
            // 
            button4.Location = new Point(491, 442);
            button4.Name = "button4";
            button4.Size = new Size(153, 23);
            button4.TabIndex = 8;
            button4.Text = "Редактировать напиток";
            button4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(491, 197);
            button2.Name = "button2";
            button2.Size = new Size(153, 23);
            button2.TabIndex = 9;
            button2.Text = "Удалить блюдо";
            button2.UseVisualStyleBackColor = true;
            button2.Click += ButtonDelProduct_Click;
            // 
            // button5
            // 
            button5.Location = new Point(491, 315);
            button5.Name = "button5";
            button5.Size = new Size(153, 23);
            button5.TabIndex = 10;
            button5.Text = "Обновить списки";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(491, 413);
            button6.Name = "button6";
            button6.Size = new Size(153, 23);
            button6.TabIndex = 11;
            button6.Text = "Создать напиток";
            button6.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(491, 471);
            button7.Name = "button7";
            button7.Size = new Size(153, 23);
            button7.TabIndex = 12;
            button7.Text = "Удалить напиток";
            button7.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 593);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button1);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            Text = "FormMain";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
		private DataGridView dataGridView2;
		private MenuStrip menuStrip1;
		private ToolStripMenuItem продуктыToolStripMenuItem;
		private ToolStripMenuItem клиентыToolStripMenuItem;
		private ToolStripMenuItem поставщикиToolStripMenuItem;
		private Button button1;
		private Label label1;
		private Label label2;
        private Button button3;
        private Button button4;
        private Button button2;
        private Button button5;
        private Button button6;
        private Button button7;
    }
}