using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
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
    public partial class FormRegister : Form
    {
        private readonly IUserLogic _userLogic;
        private readonly ILogger _logger;

        public FormRegister(IUserLogic userLogic, ILogger<FormRegister> logger)
        {
            InitializeComponent();
            _userLogic = userLogic;
            _logger = logger;
        }

        private void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxLogin.Text) || string.IsNullOrEmpty(textBoxPassword.Text) || string.IsNullOrEmpty(textBoxEmail.Text))
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var model = new UserBindingModel
            {
                Login = textBoxLogin.Text,
                Password = textBoxPassword.Text,
                Email = textBoxEmail.Text
            };

            try
            {
                if (_userLogic.Create(model))
                {
                    MessageBox.Show("Регистрация прошла успешно", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("Ошибка при регистрации", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Ошибка регистрации");
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoginButt_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
