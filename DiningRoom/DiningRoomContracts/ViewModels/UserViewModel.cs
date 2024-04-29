using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.ViewModels
{
	public class UserViewModel : IUserModel
	{
		public int Id { get; set; }
		

		[DisplayName("Логин")]
		public string Login { get; set; } = string.Empty;

		[DisplayName("Пароль")]
		public string Password { get; set; } = string.Empty;

		[DisplayName("Почта")]
		public string Email { get; set; } = string.Empty;

	}
}
