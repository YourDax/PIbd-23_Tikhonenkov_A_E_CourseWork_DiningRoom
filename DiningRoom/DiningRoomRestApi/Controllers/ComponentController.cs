using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ComponentController : Controller
	{
		private readonly ILogger _logger;
		private readonly IComponentLogic _componentLogic;

		public ComponentController(IComponentLogic Logic, ILogger<ComponentController> Logger)
		{
			_logger = Logger;
			_componentLogic = Logic;
		}

		[HttpGet]
		public ComponentViewModel? GetComponent(int Id)
		{
			try
			{
				return _componentLogic.ReadElement(new ComponentSearchModel
				{
					Id = Id
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения продукта");
				throw;
			}
		}

		[HttpGet]
		public List<ComponentViewModel>? GetComponents(int? UserId)
		{
			try
			{
				return _componentLogic.ReadList(new ComponentSearchModel
				{
					UserId = UserId 
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения списка продуктов пользователя с Id = {Id}", UserId);
				throw;
			}
		}

		[HttpPost]
		public void CreateComponent(ComponentBindingModel Model)
		{
			try
			{
				_componentLogic.Create(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания продукта");
				throw;
			}
		}
		
		[HttpPost]
		public void UpdateComponent(ComponentBindingModel Model)
		{
			try
			{
				_componentLogic.Update(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка обновления продукта");
				throw;
			}
		}

		[HttpDelete]
		public void DeleteComponent(ComponentBindingModel Model)
		{
			try
			{
				_componentLogic.Delete(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка удаления продукта");
				throw;
			}
		}
	}
}
