using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
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
			_logger = logger;
			_logic = logic;
		}
		[HttpGet]
		public UserViewModel? Login(string login, string password)
		{
			try
			{
                if (login.Contains("@"))
                {
                    return _logic.ReadElement(new UserSearchModel
                    {
                        Email = login,
                        Password = password
                    });
                }
                return _logic.ReadElement(new UserSearchModel
				{
                    Login = login,
                    Password = password
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Login error");
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
				_logger.LogError(ex, "Registration error");
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
				_logger.LogError(ex, "Update data error");
				throw;
			}
		}
	}
}
