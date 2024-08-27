namespace DiningRoomView
{
    partial class FormReportProductComponents
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
            ColumnComponent = new DataGridViewTextBoxColumn();
            ColumnProduct = new DataGridViewTextBoxColumn();
            ColumnCount = new DataGridViewTextBoxColumn();
            //buttonSaveToExcel = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView
            // 
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToDeleteRows = false;
            dataGridView.AllowUserToOrderColumns = true;
            dataGridView.AllowUserToResizeColumns = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.BackgroundColor = SystemColors.ControlLightLight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnComponent, ColumnProduct, ColumnCount });
            dataGridView.Dock = DockStyle.Bottom;
            dataGridView.Location = new Point(0, 47);
            dataGridView.Margin = new Padding(4, 3, 4, 3);
            dataGridView.MultiSelect = false;
            dataGridView.Name = "dataGridView";
            dataGridView.ReadOnly = true;
            dataGridView.RowHeadersVisible = false;
            dataGridView.Size = new Size(616, 510);
            dataGridView.TabIndex = 0;
            // 
            // ColumnComponent
            // 
            ColumnComponent.HeaderText = "Продукт";
            ColumnComponent.Name = "ColumnComponent";
            ColumnComponent.ReadOnly = true;
            ColumnComponent.Width = 200;
            // 
            // ColumnProduct
            // 
            ColumnProduct.HeaderText = "Имя заказа";
            ColumnProduct.Name = "ColumnProduct";
            ColumnProduct.ReadOnly = true;
            ColumnProduct.Width = 200;
            // 
            // ColumnCount
            // 
            ColumnCount.HeaderText = "Количество блюд в заказе";
            ColumnCount.Name = "ColumnCount";
            ColumnCount.ReadOnly = true;
            // 
            // buttonSaveToExcel
            // 
            //buttonSaveToExcel.Location = new Point(14, 14);
            //buttonSaveToExcel.Margin = new Padding(4, 3, 4, 3);
            //buttonSaveToExcel.Name = "buttonSaveToExcel";
            //buttonSaveToExcel.Size = new Size(186, 27);
            //buttonSaveToExcel.TabIndex = 1;
            //buttonSaveToExcel.Text = "Сохранить в Excel";
            //buttonSaveToExcel.UseVisualStyleBackColor = true;
            //buttonSaveToExcel.Click += ButtonSaveToExcel_Click;
            // 
            // FormReportProductComponents
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 557);
            //Controls.Add(buttonSaveToExcel);
            Controls.Add(dataGridView);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormReportProductComponents";
            Text = "Заказы по продуктам";
            Load += FormReportProductComponents_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonSaveToExcel;
        private DataGridViewTextBoxColumn ColumnComponent;
        private DataGridViewTextBoxColumn ColumnProduct;
        private DataGridViewTextBoxColumn ColumnCount;
    }
}