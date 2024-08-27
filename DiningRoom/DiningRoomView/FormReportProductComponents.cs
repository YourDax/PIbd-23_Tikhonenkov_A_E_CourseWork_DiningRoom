using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiningRoomView
{
    public partial class FormReportProductComponents : Form
    {
        private readonly ILogger _logger;

        private readonly IReportLogic _logic;

        public IComponentLogic _logicC;
        public UserViewModel? _currentUser { get; set; }

        public List<ComponentSearchModel> SelectedComp;

        public FormReportProductComponents(ILogger<FormReportProductComponents> logger, IReportLogic logic, IComponentLogic logicC)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _logicC = logicC; 
        }

        private void FormReportProductComponents_Load(object sender, EventArgs e)
        {
            try
            {

                using (var formProductSelection = new FormComponentSelection(_logicC, _currentUser))
                {

                    if (formProductSelection.ShowDialog() == DialogResult.OK)
                    {
                        var selectedProducts = formProductSelection.SelectedProducts;
                        SelectedComp = selectedProducts;
                        if (selectedProducts != null && selectedProducts.Any())
                        {
                            var reportData = _logic.GetReportComponentsWithOrders(selectedProducts);
                            DisplayDataInGridView(reportData);
                        }
                    }
                }

                _logger.LogInformation("Загрузка списка компонентов по заказам");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки списка изделий по компонентам");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayDataInGridView(List<ReportComponentOrderViewModel> reportData)
        {
            dataGridView.Rows.Clear();

            // Группируем данные по ComponentName
            var groupedData = reportData
                .GroupBy(item => item.ComponentName)
                .ToList();

            foreach (var group in groupedData)
            {
                // Добавляем строку для названия компонента
                var componentRow = new DataGridViewRow();
                componentRow.CreateCells(dataGridView);
                componentRow.Cells[0].Value = group.Key; // Название компонента
                componentRow.DefaultCellStyle.Font = new Font(dataGridView.DefaultCellStyle.Font, FontStyle.Bold);
                dataGridView.Rows.Add(componentRow);

                // Добавляем строки для каждого заказа, связанного с компонентом
                foreach (var order in group)
                {
                    var orderRow = new DataGridViewRow();
                    orderRow.CreateCells(dataGridView);
                    orderRow.Cells[1].Value = order.OrderName;
                    orderRow.Cells[2].Value = order.ProductCount;
                    dataGridView.Rows.Add(orderRow);
                }
            }
        }



        //private void ButtonSaveToExcel_Click(object sender, EventArgs e)
        //{
        //    using var dialog = new SaveFileDialog { Filter = "xlsx|*.xlsx" };
        //    if (dialog.ShowDialog() == DialogResult.OK)
        //    {
        //        try
        //        {

        //            _logic.SaveReportToExcelFile(new ReportBindingModel
        //            {
        //                FileName = dialog.FileName
        //            },SelectedComp);
        //            _logger.LogInformation("Сохранение списка изделий по компонентам");
        //            MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //        catch (Exception ex)
        //        {
        //            _logger.LogError(ex, "Ошибка сохранения списка изделий по компонентам");
        //            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }
        //    }
        //}
    }
}
