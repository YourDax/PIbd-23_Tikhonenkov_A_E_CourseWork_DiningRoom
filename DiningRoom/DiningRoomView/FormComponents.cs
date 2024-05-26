using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
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
    public partial class FormComponents : Form
    {
        private readonly ILogger _logger;
        private readonly IComponentLogic _logic;
        public UserViewModel? _currentUser { get; set; }
        public FormComponents(ILogger<FormComponents> logger, IComponentLogic logic)
        {
            InitializeComponent();
            _logger = logger;
            _logic = logic;
        }
        private void FormComponents_Load(object sender, EventArgs e)
        {
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
            try
            {
                var list = _logic.ReadList((new ComponentSearchModel { UserId = _currentUser.Id }));
                if (list != null)
                {
                    dataGridView.DataSource = list;
                    dataGridView.Columns["Id"].Visible = false;
                    dataGridView.Columns["UserId"].Visible = false;
                    dataGridView.Columns["Login"].Visible = false;
                    dataGridView.Columns["ComponentName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
                _logger.LogInformation("Загрузка компонентов");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка загрузки компонентов");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var service = Program.ServiceProvider?.GetService(typeof(FormComponent));
            if (service is FormComponent form)
            {
                form.UserId = _currentUser.Id;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadData();
                }
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (_currentUser == null)
            {
                MessageBox.Show("Ошибка авторизации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dataGridView.SelectedRows.Count == 1)
            {
                var service = Program.ServiceProvider?.GetService(typeof(FormComponent));
                if (service is FormComponent form)
                {
                    form.UserId = _currentUser.Id;
                    form.Id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
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
                    int id = Convert.ToInt32(dataGridView.SelectedRows[0].Cells["Id"].Value);
                    _logger.LogInformation("Удаление компонента");
                    try
                    {
                        if (!_logic.Delete(new ComponentBindingModel { Id = id }))
                        {
                            throw new Exception("Ошибка при удалении. Дополнительная информация в логах.");
                        }
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Ошибка удаления компонента");
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
