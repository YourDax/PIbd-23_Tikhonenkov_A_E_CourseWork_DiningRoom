using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Models;
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
    public partial class FormProductComponent : Form
    {
        private readonly List<ComponentViewModel>? _list;
        public int Id { get { return Convert.ToInt32(comboBoxComponent.SelectedValue); } set { comboBoxComponent.SelectedValue = value; } }
        public IComponentModel? ComponentModel
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
        public int Count { get { return Convert.ToInt32(textBoxCount.Text); } set { textBoxCount.Text = value.ToString(); } }
        public FormProductComponent(IComponentLogic logic)
        {
            InitializeComponent();
            _list = logic.ReadList(null);
            if (_list != null)
            {
                comboBoxComponent.DisplayMember = "ComponentName";
                comboBoxComponent.ValueMember = "Id";
                comboBoxComponent.DataSource = _list;
                comboBoxComponent.SelectedItem = null;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxComponent.SelectedValue == null)
            {
                MessageBox.Show("Выберите компонент", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void labelComponent_Click(object sender, EventArgs e)
        {

        }
    }
}
