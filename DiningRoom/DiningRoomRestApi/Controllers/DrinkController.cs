using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class DrinkController : Controller
	{
		private readonly ILogger _logger;
		private readonly IDrinkLogic _DrinkLogic;

		public DrinkController(IDrinkLogic Logic, ILogger<DrinkController> Logger)
		{
			_logger = Logger;
			_DrinkLogic = Logic;
		}

		[HttpGet]
		public DrinkViewModel? GetDrink(int Id)
		{
			try
			{
				return _DrinkLogic.ReadElement(new DrinkSearchModel
				{
					Id = Id
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения напитка");
				throw;
			}
		}


        [HttpPost]
		public void CreateDrink(DrinkBindingModel Model)
		{
			try
			{
				_DrinkLogic.Create(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания напитка");
				throw;
			}
		}

		[HttpPost]
		public void UpdateDrink(DrinkBindingModel Model)
		{
			try
			{
				_DrinkLogic.Update(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка обновления напитка");
				throw;
			}
		}

		[HttpDelete]
		public void DeleteDrink(DrinkBindingModel Model)
		{
			try
			{
				_DrinkLogic.Delete(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка удаления напитка");
				throw;
			}
		}
	}
}
