using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using DiningRoomDatabaseImplement.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class OrderController : Controller
	{
		private readonly ILogger _logger;

		private readonly IOrderLogic _logic;

		public OrderController(IOrderLogic logic, ILogger<OrderController> logger)
		{
			_logger = logger;
			_logic = logic;
		}

		[HttpGet]
		public OrderViewModel? GetOrder(int id)
		{
			try
			{
				return _logic.ReadElement(new OrderSearchModel
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
		/// Получение заказов по id пользователя (полный список, кот. будет выводиться)
		/// </summary>
		/// <param name="userId"></param>
		/// <returns></returns>
		[HttpGet]
		public List<OrderViewModel>? GetOrders(int? userId)
		{
			try
			{
				return _logic.ReadList(new OrderSearchModel { UserId = userId });
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка заказов клиента id={Id}", userId);
				throw;
			}
		}

		[HttpPost]
		public void CreateOrder(OrderBindingModel model)
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
		public void UpdateOrder(OrderBindingModel model)
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
		public void DeleteOrder(OrderBindingModel model)
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
