using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class CardController : Controller
	{
		private readonly ILogger _logger;

		private readonly ICardLogic _logic;

		public CardController(ICardLogic logic, ILogger<CardController> logger)
		{
			_logger = logger;
			_logic = logic;
		}


		[HttpGet]
		public CardViewModel? GetCard(int id)
		{
			try
			{
				return _logic.ReadElement(new CardSearchModel
				{
					Id = id
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения заказа");
				throw;
			}
		}

		/// <summary>
		/// Получение карт по id(полный список, кот. будет выводиться)
		/// </summary>
		
		[HttpGet]
		public List<CardViewModel>? GetCards(int Id)
		{
			try
			{
				return _logic.ReadList(new CardSearchModel { Id = Id });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка заказов клиента id={Id}", Id);
				throw;
			}
		}


		[HttpPost]
		public void CreateCard(CardBindingModel model)
		{
			try
			{
				_logic.Create(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания заказа");
				throw;
			}
		}

		


		[HttpPost]
		public void UpdateCard(CardBindingModel model)
		{
			try
			{
				_logic.Update(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка обновления заказа");
				throw;
			}
		}

		[HttpDelete]
		public void DeleteCard(CardBindingModel model)
		{
			try
			{
				_logic.Delete(model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка удаления заказа");
				throw;
			}
		}
	}
}
