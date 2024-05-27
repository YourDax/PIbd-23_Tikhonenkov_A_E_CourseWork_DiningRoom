using Microsoft.Extensions.Logging;
using DiningRoomContracts.BusinessLogicContracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DiningRoomContracts.BindingModels;
using DiningRoomBusinessLogic.BusinessLogic;
using DiningRoomContracts.ViewModels;
using DiningRoomContracts.SearchModels;

namespace DiningRoomView
{
	public partial class FormMain : Form
	{
		private readonly ILogger _logger;
		private readonly IProductLogic _productLogic;
        private readonly IComponentLogic _logicC;
        private readonly IDrinkLogic _drinkLogic;
        private readonly IUserLogic _userLogic;
        private readonly IReportLogic _reportLogic;
        private UserViewModel? _currentUser;
        public List<ComponentSearchModel> SelectedComp;
        public FormMain(ILogger<FormMain> logger, IProductLogic productLogic, IDrinkLogic drinkLogic, IUserLogic userLogic, IReportLogic reportLogic, IComponentLogic logicC)
        {
            InitializeComponent();
            _logger = logger;
            _productLogic = productLogic;
            _drinkLogic = drinkLogic;
            _userLogic = userLogic;
            _reportLogic = reportLogic;
            _logicC = logicC;
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            var loginForm = new FormLogin(_userLogic);
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                Close();
                return;
            }
            _currentUser = loginForm.LoggedInUser;

            LoadData();
        }
        private void LoadData()
		{
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            _logger.LogInformation("Загрузка блюд");
            try
            {
                var list = _productLogic.ReadList(new ProductSearchModel { UserId = _currentUser.Id });
                if (list != null)
                {
                    dataGridView1.DataSource = list;
                    dataGridView1.Columns["Id"].Visible = false;
                    dataGridView1.Columns["UserId"].Visible = false;
                    dataGridView1.Columns["Login"].Visible = false;
                    dataGridView1.Columns["ProductComponents"].Visible = false;
                    dataGridView1.Columns["ProductName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка блюд успешна");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки блюд");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _logger.LogInformation("Загрузка напитков");
            try
            {
                var list = _drinkLogic.ReadList(new DrinkSearchModel { UserId = _currentUser.Id });
                if (list != null)
                {
                    dataGridView2.DataSource = list;
                    dataGridView2.Columns["Id"].Visible = false;
                    dataGridView2.Columns["UserId"].Visible = false;
                    dataGridView2.Columns["Login"].Visible = false;
                    dataGridView2.Columns["CardId"].Visible = false;
                    dataGridView2.Columns["DrinkComponents"].Visible = false;
                    dataGridView2.Columns["DrinkName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                _logger.LogInformation("Загрузка напитков успешна");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки напитков");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
		private void ПродуктыToolStripMenuItem_Click(object sender, EventArgs e)
		{
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = Program.ServiceProvider?.GetService(typeof(FormComponents));
			if (service is FormComponents form)
			{
                form._currentUser = _currentUser;
                form.ShowDialog();
			}
		}
        private void ЗаказыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = Program.ServiceProvider?.GetService(typeof(FormOrders));
            if (service is FormOrders form)
            {
                form._currentUser = _currentUser;
                form.ShowDialog();
            }
        }
        private void ОтчетыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = Program.ServiceProvider?.GetService(typeof(FormReportProductComponents));
            if (service is FormReportProductComponents form)
            {
                form._currentUser = _currentUser;
                form.ShowDialog();
            }
        }
        private void отчетWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using var dialog = new SaveFileDialog { Filter = "docx|*.docx" };
            if (dialog.ShowDialog() == DialogResult.OK)
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
                                var reportData = _reportLogic.GetReportComponentsWithOrders(selectedProducts);
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
                _reportLogic.SaveReportToWordFile(new ReportBindingModel { FileName = dialog.FileName },SelectedComp);
                MessageBox.Show("Выполнено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void списокПродуктовPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormReportComponentsByDate));
            if (service is FormReportComponentsByDate form)
            {
                form.ShowDialog();
            }
        }
        private void КартыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = Program.ServiceProvider?.GetService(typeof(FormCards));
            if (service is FormCards form)
            {
                form._currentUser = _currentUser;
                form.ShowDialog();
            }
        }
        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var service = Program.ServiceProvider?.GetService(typeof(FormProduct));
            if (service is FormProduct form)
            {
                form.UserId = _currentUser.Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonUpdProduct_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormProduct));
                if (service is FormProduct form)
                {
                    form.UserId = _currentUser.Id;
                    form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
        private void ButtonDelProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление блюда");
                    try
                    {
                        if (!_productLogic.Delete(new ProductBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления блюда");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ButtonAddDrink_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = Program.ServiceProvider?.GetService(typeof(FormDrink));
            if (service is FormDrink form)
            {
                form.UserId = _currentUser.Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonUpdDrink_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                if (_currentUser == null)
                {
                    MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var service = Program.ServiceProvider?.GetService(typeof(FormDrink));
                if (service is FormDrink form)
                {
                    form.UserId = _currentUser.Id;
                    form.Id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadData();
                    }
                }
            }
        }
        private void ButtonDelDrink_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление напитка");
                    try
                    {
                        if (!_drinkLogic.Delete(new DrinkBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления напитка");
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
