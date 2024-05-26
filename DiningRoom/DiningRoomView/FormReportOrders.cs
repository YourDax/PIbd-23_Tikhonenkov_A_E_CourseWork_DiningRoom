using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.BusinessLogicsContracts;
using Microsoft.Extensions.Logging;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpentryWorkshopView
{
    public partial class FormReportOrders : Form
    {
        private readonly ReportViewer reportViewer;

        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public FormReportOrders(ILogger<FormReportOrders> logger, IReportLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            reportViewer = new ReportViewer
            {
                Dock = DockStyle.Fill
            };
            reportViewer.LocalReport.LoadReportDefinition(new FileStream("ReportOrders.rdlc", FileMode.Open));
            Controls.Clear();
            Controls.Add(reportViewer);
            Controls.Add(panel);
        }

        private void ButtonMake_Click(object sender, EventArgs e)
        {
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var dataSource = _logic.GetOrders(new ReportBindingModel
                {
                    DateFrom = DateTime.SpecifyKind(dateTimePickerFrom.Value, DateTimeKind.Utc),
                    DateTo = DateTime.SpecifyKind(dateTimePickerTo.Value, DateTimeKind.Utc)
                });
                var source = new ReportDataSource("DataSetOrders", dataSource);
                reportViewer.LocalReport.DataSources.Clear();
                reportViewer.LocalReport.DataSources.Add(source);
                var parameters = new[] {  new ReportParameter("ReportParameterPeriod",
                                            $"c {dateTimePickerFrom.Value.ToShortDateString()} по {dateTimePickerTo.Value.ToShortDateString()}") };
                reportViewer.LocalReport.SetParameters(parameters);

                reportViewer.RefreshReport();
                _logger.LogInformation("Загрузка списка заказов на период {From}-{To}", dateTimePickerFrom.Value.ToShortDateString(), dateTimePickerTo.Value.ToShortDateString());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка заказов на период");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ButtonToPdf_Click(object sender, EventArgs e)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            if (dateTimePickerFrom.Value.Date >= dateTimePickerTo.Value.Date)
            {
                MessageBox.Show("Дата начала должна быть меньше даты окончания", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            using var dialog = new SaveFileDialog { Filter = "pdf|*.pdf" };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _logic.SaveOrdersToPdfFile(new ReportBindingModel
                    {
                        FileName = dialog.FileName,
                        DateFrom = DateTime.SpecifyKind(dateTimePickerFrom.Value, DateTimeKind.Utc),
                        DateTo = DateTime.SpecifyKind(dateTimePickerTo.Value, DateTimeKind.Utc)
                    });
                    _logger.LogInformation("Сохранение списка заказов на период {From}-{To}", dateTimePickerFrom.Value.ToShortDateString(), dateTimePickerTo.Value.ToShortDateString());
                    MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка сохранения списка заказов на период");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
