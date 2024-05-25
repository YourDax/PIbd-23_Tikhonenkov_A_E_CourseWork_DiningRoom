using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomDataModels.Models;
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
    public partial class FormProduct : Form
    {
        private readonly ILogger _logger;
        private readonly IProductLogic _logic;
        private int? _id;
        private Dictionary<int, (IComponentModel, int)> _productComponents;
        public int Id { set { _id = value; } }
        public FormProduct(ILogger<FormProduct> logger, IProductLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _productComponents = new Dictionary<int, (IComponentModel, int)>();
        }
        private void FormProduct_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка изделия");
                try
                {
                    var view = _logic.ReadElement(new ProductSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxName.Text = view.ProductName;
                        textBoxPrice.Text = view.Cost.ToString();
                        _productComponents = view.ProductComponents ?? new Dictionary<int, (IComponentModel, int)>();
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Ошибка загрузки изделия");
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadData()
        {
            _logger.LogInformation("Загрузка компонент изделия");
            try
            {
                if (_productComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in _productComponents)
                    {
                        dataGridView.Rows.Add(new object[] { pc.Key, pc.Value.Item1.ComponentName, pc.Value.Item2 });
                    }
                    textBoxPrice.Text = CalcPrice().ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки компонент изделия");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormProductComponent));
            if (service is FormProductComponent form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ComponentModel == null)
                    {
                        return;
                    }
                    _logger.LogInformation("Добавление нового компонента: {ComponentName} - {Count}", form.ComponentModel.ComponentName, form.Count);
                    if (_productComponents.ContainsKey(form.Id))
                    {
                        _productComponents[form.Id] = (form.ComponentModel, form.Count);
                    }
                    else
                    {
                        _productComponents.Add(form.Id, (form.ComponentModel, form.Count));
                    }
                    LoadData();
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormProductComponent));
                if (service is FormProductComponent form)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    form.Count = _productComponents[id].Item2;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.ComponentModel == null)
                        {
                            return;
                        }
                        _logger.LogInformation("Изменение компонента: {ComponentName} - {Count}", form.ComponentModel.ComponentName, form.Count);
                        _productComponents[form.Id] = (form.ComponentModel, form.Count);
                        LoadData();
                    }
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _logger.LogInformation("Удаление компонента: {ComponentName} - {Count}", dataGridView.SelectedRows[0].Cells[1].Value); _productComponents?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_productComponents == null || _productComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение изделия");
            try
            {
                var model = new ProductBindingModel
                {
                    Id = _id ?? 0,
                    ProductName = textBoxName.Text,
                    Cost = Convert.ToDouble(textBoxPrice.Text),
                    ProductComponents = _productComponents
                };
                var operationResult = _id.HasValue ? _logic.Update(model) : _logic.Create(model);
                if (!operationResult)
                {
                    throw new Exception("Ошибка при сохранении. Дополнительная информация в логах.");
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка сохранения изделия"); MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private double CalcPrice()
        {
            double price = 0;
            foreach (var elem in _productComponents)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}
