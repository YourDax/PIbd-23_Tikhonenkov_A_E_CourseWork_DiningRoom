namespace DiningRoomView
{
    partial class FormReportComponentsByDate
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
            panel = new Panel();
            buttonToPdf = new Button();
            buttonMake = new Button();
            dateTimePickerTo = new DateTimePicker();
            labelTo = new Label();
            dateTimePickerFrom = new DateTimePicker();
            labelFrom = new Label();
            dataGridView = new DataGridView();
            panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).BeginInit();
            SuspendLayout();
            // 
            // panel
            // 
            panel.Controls.Add(buttonToPdf);
            panel.Controls.Add(buttonMake);
            panel.Controls.Add(dateTimePickerTo);
            panel.Controls.Add(labelTo);
            panel.Controls.Add(dateTimePickerFrom);
            panel.Controls.Add(labelFrom);
            panel.Dock = DockStyle.Top;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(4, 3, 4, 3);
            panel.Name = "panel";
            panel.Size = new Size(1031, 40);
            panel.TabIndex = 0;
            // 
            // buttonToPdf
            // 
            buttonToPdf.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonToPdf.Location = new Point(878, 8);
            buttonToPdf.Margin = new Padding(4, 3, 4, 3);
            buttonToPdf.Name = "buttonToPdf";
            buttonToPdf.Size = new Size(139, 27);
            buttonToPdf.TabIndex = 5;
            buttonToPdf.Text = "В Pdf";
            buttonToPdf.UseVisualStyleBackColor = true;
            buttonToPdf.Click += buttonGenerateAndSendPdf_Click;
            // 
            // buttonMake
            // 
            buttonMake.Location = new Point(476, 8);
            buttonMake.Margin = new Padding(4, 3, 4, 3);
            buttonMake.Name = "buttonMake";
            buttonMake.Size = new Size(139, 27);
            buttonMake.TabIndex = 4;
            buttonMake.Text = "Сформировать";
            buttonMake.UseVisualStyleBackColor = true;
            buttonMake.Click += ButtonMake_Click;
            // 
            // dateTimePickerTo
            // 
            dateTimePickerTo.Location = new Point(237, 7);
            dateTimePickerTo.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerTo.Name = "dateTimePickerTo";
            dateTimePickerTo.Size = new Size(163, 23);
            dateTimePickerTo.TabIndex = 3;
            // 
            // labelTo
            // 
            labelTo.AutoSize = true;
            labelTo.Location = new Point(208, 10);
            labelTo.Margin = new Padding(4, 0, 4, 0);
            labelTo.Name = "labelTo";
            labelTo.Size = new Size(21, 15);
            labelTo.TabIndex = 2;
            labelTo.Text = "по";
            // 
            // dateTimePickerFrom
            // 
            dateTimePickerFrom.Location = new Point(37, 7);
            dateTimePickerFrom.Margin = new Padding(4, 3, 4, 3);
            dateTimePickerFrom.Name = "dateTimePickerFrom";
            dateTimePickerFrom.Size = new Size(163, 23);
            dateTimePickerFrom.TabIndex = 1;
            // 
            // labelFrom
            // 
            labelFrom.AutoSize = true;
            labelFrom.Location = new Point(14, 10);
            labelFrom.Margin = new Padding(4, 0, 4, 0);
            labelFrom.Name = "labelFrom";
            labelFrom.Size = new Size(15, 15);
            labelFrom.TabIndex = 0;
            labelFrom.Text = "С";
            // 
            // dataGridView
            // 
            dataGridView.BackgroundColor = SystemColors.ButtonHighlight;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Location = new Point(12, 46);
            dataGridView.Name = "dataGridView";
            dataGridView.RowTemplate.Height = 25;
            dataGridView.Size = new Size(1005, 589);
            dataGridView.TabIndex = 1;
            // 
            // FormReportComponentsByDate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1031, 647);
            Controls.Add(dataGridView);
            Controls.Add(panel);
            Margin = new Padding(4, 3, 4, 3);
            Name = "FormReportComponentsByDate";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Заказы";
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button buttonToPdf;
        private System.Windows.Forms.Button buttonMake;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.Label labelTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Label labelFrom;
        private DataGridView dataGridView;
    }
}