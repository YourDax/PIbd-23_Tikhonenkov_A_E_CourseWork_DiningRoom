using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
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
    public partial class FormDrink : Form
    {
        private readonly ILogger _logger;
        private readonly IDrinkLogic _logic;
        private readonly ICardLogic _cardLogic;
        private int? _id;
        
        private Dictionary<int, (IComponentModel, int)> _drinkComponents;
        public int Id { get { return Convert.ToInt32(comboBoxCards.SelectedValue); } set { comboBoxCards.SelectedValue = value; _id = value; } }

        private readonly List<CardViewModel>? _list;
        public ICardModel? CardModel
        {
            get
            {
                if (_list == null)
                {
                    return null;
                }
                foreach (var elem in _list)
                {
                    if (elem.Id == Id)
                    {
                        return elem;
                    }
                }
                return null;
            }
        }
        public FormDrink(ILogger<FormDrink> logger, IDrinkLogic logic, ICardLogic cardLogic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
            _cardLogic = cardLogic;
            _drinkComponents = new Dictionary<int, (IComponentModel, int)>();
            _list = _cardLogic.ReadList(null);
            if (_list != null)
            {
                comboBoxCards.DisplayMember = "CardName";
                comboBoxCards.ValueMember = "Id";
                comboBoxCards.DataSource = _list;
                comboBoxCards.SelectedItem = null;
            }
        }
        private void FormDrink_Load(object sender, EventArgs e)
        {
            if (_id.HasValue)
            {
                _logger.LogInformation("Загрузка изделия");
                try
                {
                    var view = _logic.ReadElement(new DrinkSearchModel { Id = _id.Value });
                    if (view != null)
                    {
                        textBoxName.Text = view.DrinkName;
                        textBoxPrice.Text = view.Cost.ToString();
                        _drinkComponents = view.DrinkComponents ?? new Dictionary<int, (IComponentModel, int)>();
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
                if (_drinkComponents != null)
                {
                    dataGridView.Rows.Clear();
                    foreach (var pc in _drinkComponents)
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
            var service = Program.ServiceProvider?.GetService(typeof(FormDrinkComponent));
            if (service is FormDrinkComponent form)
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    if (form.ComponentModel == null)
                    {
                        return;
                    }
                    _logger.LogInformation("Добавление нового компонента: {ComponentName} - {Count}", form.ComponentModel.ComponentName, form.Count);
                    if (_drinkComponents.ContainsKey(form.Id))
                    {
                        _drinkComponents[form.Id] = (form.ComponentModel, form.Count);
                    }
                    else
                    {
                        _drinkComponents.Add(form.Id, (form.ComponentModel, form.Count));
                    }
                    LoadData();
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormDrinkComponent));
                if (service is FormDrinkComponent form)
                {
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value);
                    form.Id = id;
                    form.Count = _drinkComponents[id].Item2;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        if (form.ComponentModel == null)
                        {
                            return;
                        }
                        _logger.LogInformation("Изменение компонента: {ComponentName} - {Count}", form.ComponentModel.ComponentName, form.Count);
                        _drinkComponents[form.Id] = (form.ComponentModel, form.Count);
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
                        _logger.LogInformation("Удаление компонента: {ComponentName} - {Count}", dataGridView.SelectedRows[0].Cells[1].Value); _drinkComponents?.Remove(Convert.ToInt32(dataGridView.SelectedRows[0].Cells[0].Value));
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
            if (_drinkComponents == null || _drinkComponents.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _logger.LogInformation("Сохранение изделия");
            try
            {
                var model = new DrinkBindingModel
                {
                    Id = _id ?? 0,
                    DrinkName = textBoxName.Text,
                    Cost = Convert.ToDouble(textBoxPrice.Text),
                    CardId = Convert.ToInt32(comboBoxCards.SelectedValue),
                    DrinkComponents = _drinkComponents
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
            foreach (var elem in _drinkComponents)
            {
                price += ((elem.Value.Item1?.Cost ?? 0) * elem.Value.Item2);
            }
            return Math.Round(price * 1.1, 2);
        }
    }
}
