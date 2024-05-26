using DiningRoomBusinessLogic.BusinessLogic;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
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
    public partial class FormComponentSelection : Form
    {
        private readonly IComponentLogic _logic;
        private readonly List<ComponentViewModel>? _list;
        public UserViewModel? _currentUser { get; set; }
        public List<ComponentSearchModel> SelectedProducts { get; private set; }
        public FormComponentSelection(IComponentLogic logic, UserViewModel currentuser)
        {
            _logic = logic;
            _currentUser = currentuser;
            InitializeComponent();
            LoadData();
        }
        public void LoadData()
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public List<ComponentSearchModel> GetSelectedComponents(DataGridView dataGridView)
        {
            var selectedComponents = new List<ComponentSearchModel>();

            foreach (DataGridViewRow row in dataGridView.SelectedRows)
            {
                if (row.Cells["Id"].Value != null && row.Cells["ComponentName"].Value != null)
                {
                    var component = new ComponentSearchModel
                    {
                        Id = Convert.ToInt32(row.Cells["Id"].Value),
                        ComponentName = row.Cells["ComponentName"].Value.ToString()
                    };
                    selectedComponents.Add(component);
                }
            }

            return selectedComponents;
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        
        private void btnOK_Click(object sender, EventArgs e)
        {
            SelectedProducts = GetSelectedComponents(dataGridView);
            DialogResult = DialogResult.OK;
            Close();
        }

    }
}
