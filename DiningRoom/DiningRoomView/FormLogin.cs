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
    public partial class FormLogin : Form
    {
        private readonly IUserLogic _userLogic;

        public UserViewModel? LoggedInUser { get; private set; }

        public FormLogin(IUserLogic userLogic)
        {
            InitializeComponent();
            _userLogic = userLogic;
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            var user = _userLogic.ReadElement(new UserSearchModel
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text
            });

            if (user != null)
            {
                LoggedInUser = user;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void RegButt_Click(object sender, EventArgs e)
        {
            var service = Program.ServiceProvider?.GetService(typeof(FormRegister));
            if (service is FormRegister form)
            {
                form.ShowDialog();
            }
        }
    }
}
