using DiningRoomDataModels.Enums;
using DiningRoomDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.BindingModels
{
	public class UserBindingModel : IUserModel
	{
		public int Id { get; set; }
		
		public string Login { get; set; } = string.Empty;
		
		public string Password { get; set; } = string.Empty;
		
		public string Email { get; set; } = string.Empty;
		
	}
}
