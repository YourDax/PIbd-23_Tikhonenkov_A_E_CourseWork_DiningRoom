using DiningRoomDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomContracts.SearchModels
{
	public class UserSearchModel
	{
		public int? Id { get; set; }
		public string? Login { get; set; }

		public string Password { get; set; }

		public string? Email { get; set; }
		public UserRole? Role { get; set; }
	}
}
