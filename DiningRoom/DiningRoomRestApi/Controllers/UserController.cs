using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDataModels.Enums;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class UserController : Controller
	{
		private readonly ILogger _logger;
		private readonly IUserLogic _logic;

		public UserController(IUserLogic logic, ILogger<UserController> logger)
		{
			_logic = logic;
			_logger = logger;
		}


		[HttpGet]
		public UserViewModel? Login(string login, string password)
		{
			try
			{
				return _logic.ReadElement(new UserSearchModel
				{
					Login = login,
					Password = password,
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка входа в систему");
				throw;
			}
		}
		[HttpPost]
		public void Register(UserBindingModel model)
		{
			try
			{
				_logic.Create(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка регистрации");
				throw;
			}
		}

		[HttpPost]
		public void UpdateData(UserBindingModel model)
		{
			try
			{
				_logic.Update(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка обновления данных");
				throw;
			}
		}
	}
}
