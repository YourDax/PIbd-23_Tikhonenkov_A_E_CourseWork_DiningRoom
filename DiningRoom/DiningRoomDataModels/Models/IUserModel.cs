using DiningRoomDataModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiningRoomDataModels.Models
{
	public interface IUserModel : IId
	{
		string Login { get; }
		string Password { get; }
		string Email { get; }
	}
}
