using DiningRoomContracts.BindingModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDatabaseImplement.Models
{
	public class User : IUserModel
	{
		public int Id { get; private set; }

		[Required]
		public string Login { get; set; } = string.Empty;

		[Required]
		public string Password { get; set; } = string.Empty;

		//!!!МБ ТУТ НУЖНА ДОП. АННОТАЦИЯ ПРОВЕРКИ ПОЧТЫ
		[Required]
		public string Email { get; set; } = string.Empty;


		//!!!МБ ТУТ НАДО БУДЕТ СОЗДАТЬ 2 РАЗНЫХ МЕТОДА: СОЗДАНИЕ ИСПОЛНИТЕЛЯ и СОЗДАНИЕ ПОРУЧИТЕЛЯ (хотя мб где-то потом будем задавать роль в BindingModel)
		public static User Create(UserBindingModel model)
		{
			return new User
			{
				Id = model.Id,
				Login = model.Login,
				Password = model.Password,
				Email = model.Email
			};
		}

		public void Update(UserBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			Login = model.Login;
			Password = model.Password;
			Email = model.Email;
		}

		//!!!МБ ТУТ НЕ НАДО РОЛЬ
		public UserViewModel GetViewModel => new()
		{
			Id = Id,
			Login = Login,
			Password = Password,
			Email = Email,
			Role = Role
		};
	}
}
