namespace DiningRoomView
{
    partial class FormOrders
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
            ButtonCreateOrder = new Button();
            ButtonRef = new Button();
            ButtonIssuedOrder = new Button();
            ButtonOrderReady = new Button();
            ButtonTakeOrderInWork = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.Location = new Point(12, 12);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.Size = new Size(600, 371);
            dataGridView.TabIndex = 1;
            // 
            // ButtonCreateOrder
            // 
            ButtonCreateOrder.Location = new Point(618, 12);
            ButtonCreateOrder.Name = "ButtonCreateOrder";
            ButtonCreateOrder.Size = new Size(122, 23);
            ButtonCreateOrder.TabIndex = 2;
            ButtonCreateOrder.Text = "Создать заказ";
            ButtonCreateOrder.UseVisualStyleBackColor = true;
            ButtonCreateOrder.Click += ButtonCreateOrder_Click;
            // 
            // ButtonRef
            // 
            ButtonRef.Location = new Point(618, 147);
            ButtonRef.Name = "ButtonRef";
            ButtonRef.Size = new Size(122, 23);
            ButtonRef.TabIndex = 6;
            ButtonRef.Text = "Обновить список";
            ButtonRef.UseVisualStyleBackColor = true;
            ButtonRef.Click += ButtonRef_Click;
            // 
            // ButtonIssuedOrder
            // 
            ButtonIssuedOrder.Location = new Point(618, 118);
            ButtonIssuedOrder.Name = "ButtonIssuedOrder";
            ButtonIssuedOrder.Size = new Size(122, 23);
            ButtonIssuedOrder.TabIndex = 5;
            ButtonIssuedOrder.Text = "Заказ выдан";
            ButtonIssuedOrder.UseVisualStyleBackColor = true;
            ButtonIssuedOrder.Click += ButtonIssuedOrder_Click;
            // 
            // ButtonOrderReady
            // 
            ButtonOrderReady.Location = new Point(618, 89);
            ButtonOrderReady.Name = "ButtonOrderReady";
            ButtonOrderReady.Size = new Size(122, 23);
            ButtonOrderReady.TabIndex = 4;
            ButtonOrderReady.Text = "Заказ готов";
            ButtonOrderReady.UseVisualStyleBackColor = true;
            ButtonOrderReady.Click += ButtonOrderReady_Click;
            // 
            // ButtonTakeOrderInWork
            // 
            ButtonTakeOrderInWork.Location = new Point(618, 41);
            ButtonTakeOrderInWork.Name = "ButtonTakeOrderInWork";
            ButtonTakeOrderInWork.Size = new Size(122, 42);
            ButtonTakeOrderInWork.TabIndex = 3;
            ButtonTakeOrderInWork.Text = "Отдать на выполнение";
            ButtonTakeOrderInWork.UseVisualStyleBackColor = true;
            ButtonTakeOrderInWork.Click += ButtonTakeOrderInWork_Click;
            // 
            // FormOrders
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(752, 391);
            Controls.Add(ButtonRef);
            Controls.Add(ButtonIssuedOrder);
            Controls.Add(ButtonOrderReady);
            Controls.Add(ButtonTakeOrderInWork);
            Controls.Add(ButtonCreateOrder);
            Controls.Add(dataGridView);
            Name = "FormOrders";
            Text = "Заказы";
            Load += FormMain_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonCreateOrder;
        private System.Windows.Forms.Button ButtonRef;
        private Button ButtonIssuedOrder;
        private Button ButtonOrderReady;
        private Button ButtonTakeOrderInWork;
    }
}