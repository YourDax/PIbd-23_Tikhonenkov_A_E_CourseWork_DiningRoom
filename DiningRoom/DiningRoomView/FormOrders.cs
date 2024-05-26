using DiningRoomBusinessLogic.BusinessLogic;
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
    public partial class FormOrders : Form
    {
        private readonly ILogger _logger;
        private readonly IOrderLogic _orderLogic;
        public UserViewModel? _currentUser { get; set; }
        public FormOrders(ILogger<FormMain> logger, IOrderLogic orderLogic)
        {
            InitializeComponent();
            _logger = logger;
            _orderLogic = orderLogic;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Загрузка заказов");
            // прописать логику
            try
            {
                var list = _orderLogic.ReadList(new OrderSearchModel { UserId = _currentUser.Id });
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["ProductId"].Visible = false;
                }
                _logger.LogInformation("Загрузка продуктов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки продуктов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCreateOrder_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = Program.ServiceProvider?.GetService(typeof(FormCreateOrder));
            if (service is FormCreateOrder form)
            {
                form.UserId = _currentUser.Id;
                form.ShowDialog();
                LoadData();
            }
        }
        private void ButtonTakeOrderInWork_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'В работе'", id);
                try
                {
                    var operationResult = _orderLogic.TakeOrderInWork(new OrderBindingModel { Id = id });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка передачи заказа в работу");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonOrderReady_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Готов'", id);
                try
                {
                    var operationResult = _orderLogic.FinishOrder(new OrderBindingModel { Id = id });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о готовности заказа"); MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonIssuedOrder_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                _logger.LogInformation("Заказ №{id}. Меняется статус на 'Выдан'", id);
                try
                {
                    var operationResult = _orderLogic.DeliveryOrder(new OrderBindingModel { Id = id });
                    if (!operationResult)
                    {
                        throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                    }
                    _logger.LogInformation("Заказ №{id} выдан", id);
                    LoadData();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка отметки о выдачи заказа");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
