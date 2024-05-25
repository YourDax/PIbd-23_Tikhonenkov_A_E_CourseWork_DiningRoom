using DiningRoomContracts.BindingModels;
using DiningRoomContracts.BusinessLogicContracts;
using DiningRoomContracts.SearchModels;
using DiningRoomContracts.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiningRoomRestApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	public class ProductController : Controller
	{
		private readonly ILogger _logger;
		private readonly IProductLogic _productLogic;

		public ProductController(IProductLogic Logic, ILogger<ProductController> Logger)
		{
			_logger = Logger;
			_productLogic = Logic;
		}

		[HttpGet]
		public ProductViewModel? GetProduct(int Id)
		{
			try
			{
				return _productLogic.ReadElement(new ProductSearchModel
				{
					Id = Id
				});
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка получения блюда");
				throw;
			}
		}


		[HttpPost]
		public void CreateProduct(ProductBindingModel Model)
		{
			try
			{
				_productLogic.Create(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка создания блюда");
				throw;
			}
		}

		[HttpPost]
		public void UpdateProduct(ProductBindingModel Model)
		{
			try
			{
				_productLogic.Update(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка обновления блюда");
				throw;
			}
		}

		[HttpDelete]
		public void DeleteProduct(ProductBindingModel Model)
		{
			try
			{
				_productLogic.Delete(Model);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Ошибка удаления блюда");
				throw;
			}
		}
	}
}
