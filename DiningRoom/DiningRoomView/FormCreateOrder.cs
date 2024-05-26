using DiningRoomBusinessLogic.BusinessLogic;
using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Enums;
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
    public partial class FormCreateOrder : Form
    {
        private readonly ILogger _logger;
        private readonly IProductLogic _logicP;
        private readonly IOrderLogic _logicO;
        public int Id { get ;  set ;  }
        public int UserId { get; set; }

        public FormCreateOrder(ILogger<FormCreateOrder> logger, IProductLogic logicP, IOrderLogic logicO)
        {
            InitializeComponent();
            _logger = logger;
            _logicP = logicP;
            _logicO = logicO;

        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            _logger.LogInformation("Загрузка изделий для заказа");
            // прописать логику
            List<ProductViewModel> list = _logicP.ReadList(null);
            if (list != null)
            {
                comboBoxProduct.DisplayMember = "ProductName";
                comboBoxProduct.ValueMember = "Id";
                comboBoxProduct.DataSource = list;
                comboBoxProduct.SelectedItem = null;
            }
        }
        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null && !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    var product = _logicP.ReadElement(new ProductSearchModel { Id = id });
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = Math.Round(count * (product?.Cost ?? 0), 2).ToString();
                    _logger.LogInformation("Расчет суммы заказа");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка расчета суммы заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                var model = new OrderBindingModel
                {
                    Id = Id,
                    Status = OrderStatus.Принят,
                    ProductId = comboBoxProduct.SelectedValue as int?,
                    Count = Convert.ToInt32(textBoxCount.Text),
                    Sum = Convert.ToDouble(textBoxSum.Text)

                };
                var operationResult = _logicO.Update(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения карты");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                
            DialogResult = DialogResult.OK;
            Close();
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
