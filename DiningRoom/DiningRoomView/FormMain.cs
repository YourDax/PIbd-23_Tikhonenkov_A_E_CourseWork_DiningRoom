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

namespace DiningRoomView
{
	public partial class FormMain : Form
	{
		private readonly ILogger _logger;
		private readonly IProductLogic _productLogic;
		private readonly IDrinkLogic _drinkLogic;
		public FormMain(ILogger<FormMain> logger, IProductLogic productLogic, IDrinkLogic drinkLogic)
		{
			InitializeComponent();
			_logger = logger;
            _productLogic = productLogic;
            _drinkLogic = drinkLogic;
		}
		private void FormMain_Load(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			_logger.LogInformation("Загрузка блюд");
			try
			{
				var list = _productLogic.ReadList(null);
				if (list != null)
				{
					dataGridView1.DataSource = list;
                    dataGridView1.Columns["Id"].Visible = false;
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
				var list = _drinkLogic.ReadList(null);
				if (list != null)
				{
                    dataGridView2.DataSource = list;
                    dataGridView2.Columns["Id"].Visible = false;
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
			var service = Program.ServiceProvider?.GetService(typeof(FormComponents));
			if (service is FormComponents form)
			{
				form.ShowDialog();
			}
		}
        private void ButtonAddProduct_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormProduct));
            if (service is FormProduct form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonUpdProduct_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormProduct));
                if (service is FormProduct form)
                {
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
            var service = Program.ServiceProvider?.GetService(typeof(FormDrink));
            if (service is FormDrink form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonUpdDrink_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormDrink));
                if (service is FormDrink form)
                {
                    form.Id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);
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

        //private void ButtonCreateSale_Click(object sender, EventArgs e)
        //{
        //	var service = Program.ServiceProvider?.GetService(typeof(FormCreateSale));
        //	if (service is FormCreateSale form)
        //	{
        //		form.ShowDialog();
        //		LoadData();
        //	}
        //}
        //private void ButtonCreateSupply_Click(object sender, EventArgs e)
        //{
        //	var service = Program.ServiceProvider?.GetService(typeof(FormCreateSupply));
        //	if (service is FormCreateSupply form)
        //	{
        //		form.ShowDialog();
        //		LoadData();
        //	}
        //}
    }
}
